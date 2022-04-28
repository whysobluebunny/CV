package steps;

import driver.WebDriverManager;
import dto.PurchaseInfo;
import io.qameta.allure.Step;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;
import org.openqa.selenium.support.ui.Select;
import pages.Page;
import pages.SberPurchaseListPage;

import java.util.List;

public class Steps {
    private final WebDriver driver;

    public Steps() {
        this.driver = WebDriverManager.getCurrentDriver();
    }

    @Step("Кликнуть на элемент {elementName}")
    public void clickOnElement(String elementName, Page page) {
        WebElement element = page.getElement(elementName);
//        try {
        element.click();
//        } catch (ElementNotInteractableException e) {
//            ((JavascriptExecutor) driver).executeScript("arguments[0].click();", element);
//        }
    }

    @Step("Заполнить поле")
    public void sendKeysToElement(String elementName, Page page, String keys) {
        WebElement element = page.getElement(elementName);
        element.clear();
        element.sendKeys(keys);
    }

    @Step("Выбрать количество отображаемых результатов: {num}")
    public void selectAmountOfResults(int num, SberPurchaseListPage page) {
        page.waitUntilPageLoaded();
        Select select = new Select(page.getElement("Селектор количества отображаемых результатов"));
        select.selectByVisibleText(Integer.toString(num));
    }

    @Step("Получить список заказов стоимостью больше {price}")
    public void getPurchasesOfPrice(double price, SberPurchaseListPage page) {
        page.waitUntilPageLoaded();
        List<PurchaseInfo> purchaseInfoList = page.getPurchaseInfoList(driver, price);
        clickOnElement("Кнопка перехода на следующую страницу", page);
        page.waitUntilPageLoaded();
        selectAmountOfResults(20, page);
        page.waitUntilPageLoaded();
        purchaseInfoList.addAll(page.getPurchaseInfoList(driver, price));
        System.out.println("Size: " + purchaseInfoList.size());

        for(var elem : purchaseInfoList)
            System.out.println(elem);
    }

    public void goPage(String url) {
        driver.get(url);
//        AllureEdit.setLastStepName("Перейти на страницу " + driver.getTitle());
    }
}
