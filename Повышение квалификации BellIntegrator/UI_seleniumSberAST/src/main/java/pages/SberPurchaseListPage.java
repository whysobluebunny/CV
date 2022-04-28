package pages;

import driver.WebDriverManager;
import dto.PurchaseInfo;
import helpers.PageUtils;
import org.openqa.selenium.By;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;
import org.openqa.selenium.support.FindBy;
import org.openqa.selenium.support.How;

import java.util.List;
import java.util.stream.Collectors;

public class SberPurchaseListPage implements Page {
    @FieldName("Селектор количества отображаемых результатов")
    @FindBy(how = How.XPATH, xpath = "//*[@id='headerPagerSelect']")
    WebElement resultNumberSelector;

    @FieldName("Кнопка перехода на следующую страницу")
    @FindBy(how = How.XPATH, xpath = "//*[text()='>']")
    WebElement nextPageButton;

    @FindBy(how = How.XPATH, xpath = "//*[@class='nbt-grid-ajax-loader']")
    WebElement loader;
    By loaderXPATH = By.xpath("//*[@class='nbt-grid-ajax-loader']");

    By resultTableElement = By.xpath("//span[text()='Госзакупки по 44-ФЗ']/ancestor::table");
    By purchaseName = By.xpath(".//*[@class='es-el-type-name']");
    By purchaseID = By.xpath(".//*[@class='es-el-code-term']");
    By purchasePrice = By.xpath(".//*[@class='es-el-amount']");

    public SberPurchaseListPage() {
        initPage();
    }

    public void waitUntilPageLoaded() {
        if (WebDriverManager.getCurrentDriver().findElements(loaderXPATH).size() != 0)
            PageUtils.waitUntilElementInvisible(loader);
    }

    @Override
    public boolean isPageLoaded() {
        return true;
    }

    public PurchaseInfo getPurchaseInfo(WebElement from) {
        PurchaseInfo pInfo = new PurchaseInfo(from.findElement(purchaseName).getText(),
                Double.parseDouble(from.findElement(purchasePrice).getText().replaceAll(" ", "")),
                from.findElement(purchaseID).getText());
        return pInfo;
    }

    public List<PurchaseInfo> getPurchaseInfoList(WebDriver driver, Double price) {
        return driver.findElements(resultTableElement).stream()
                .map(element -> getPurchaseInfo(element))
                .filter(x -> x.getPrice() > price).collect(Collectors.toList());
    }
}
