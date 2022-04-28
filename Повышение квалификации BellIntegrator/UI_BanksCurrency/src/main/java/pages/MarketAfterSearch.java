package pages;

import driver.WebDriverManager;
import helpers.CustomUtils;
import helpers.PageUtils;
import org.openqa.selenium.By;
import org.openqa.selenium.JavascriptExecutor;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;
import org.openqa.selenium.support.FindBy;
import org.openqa.selenium.support.How;

import java.util.List;
import java.util.Locale;
import java.util.Map;
import java.util.stream.Collectors;

public class MarketAfterSearch implements Page {
    @FieldName("Поиск")
    @FindBy(how = How.XPATH, using = "//*[@data-apiary-widget-name='@MarketNode/HeaderSearch']//*[@placeholder='Искать товары']")
    WebElement searchField;

    @FieldName("Кнопка поиска")
    @FindBy(how = How.XPATH, using = "//*[@data-apiary-widget-name='@MarketNode/HeaderSearch']//*[text()='Найти']")
    WebElement searchButton;

    @FieldName("Сортировка по цене")
    @FindBy(how = How.XPATH, using = "//div[@data-apiary-widget-name='@MarketNode/SortPanel']//*[text()='по цене']")
    WebElement sortButton;

    @FindBy(how = How.XPATH, using = "//*[@data-apiary-widget-name='@MarketNode/SearchPager'] //*[text()='Вперёд']")
    WebElement nextPageButton;
    By nextPageXPATH = By.xpath("//*[@data-apiary-widget-name='@MarketNode/SearchPager'] //*[text()='Вперёд']");

    @FindBy(how = How.XPATH, using = "//*[@data-apiary-widget-name='@MarketNode/SearchPartition']//*[@data-zone-name='snippet-card']")
    WebElement result;
    By resultXPATH = By.xpath("//*[@data-apiary-widget-name='@MarketNode/SearchPartition']//*[@data-zone-name='snippet-card']");
    By resultPriceXPATH = By.xpath("//*[@data-apiary-widget-name='@MarketNode/SearchPartition']//div[@data-zone-name='price']");

    @FindBy(how = How.XPATH, using = "//*[@data-zone-name='SearchResultsPaged']//div[@role='main']/div[not(@data-apiary-widget-name)]")
    WebElement loadingIMG;
    By loadingIMGXPATH = By.xpath("//*[@data-zone-name='SearchResultsPaged']//div[@role='main']/div[not(@data-apiary-widget-name)]");

    @FieldName("Показать все")
    @FindBy(how = How.XPATH, using = "//*[text()='Название видеокарты']/..//*[text()='Показать всё']")
    WebElement showAll;

    @FieldName("GTX1060")
    @FindBy(how = How.XPATH, using = "//*[text()='Название видеокарты']/..//*[text()='NVIDIA GeForce GTX 1060']")
    WebElement gtx1060;

    @FieldName("RTX3060")
    @FindBy(how = How.XPATH, using = "//*[text()='Название видеокарты']/..//*[text()='NVIDIA GeForce RTX 3060']")
    WebElement rtx3060;

    @FieldName("Поле поиска")
    @FindBy(how = How.XPATH, using = "//*[@name='Поле поиска']")
    WebElement modelSearch;

    public MarketAfterSearch(){
        initPage();
    }

    public By getResultXPATH(){return resultXPATH;}
    public By getResultPriceXPATH(){return resultPriceXPATH;}

    public void waitUntilPageLoaded() {
        if (WebDriverManager.getCurrentDriver().findElements(loadingIMGXPATH).size() != 0)
            PageUtils.waitUntilElementInvisible(loadingIMG);
    }

    @Override
    public boolean isPageLoaded() {
        return true;
    }
}
