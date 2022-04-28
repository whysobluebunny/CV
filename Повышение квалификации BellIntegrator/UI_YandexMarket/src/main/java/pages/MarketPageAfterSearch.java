package pages;

import helpers.PageUtils;
import org.openqa.selenium.By;
import org.openqa.selenium.JavascriptExecutor;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;
import org.openqa.selenium.support.FindBy;
import org.openqa.selenium.support.How;
import org.openqa.selenium.support.PageFactory;

import java.util.List;
import java.util.stream.Collectors;

public class MarketPageAfterSearch {
    private final WebDriver driver;
    @FindBy(how = How.ID, using = "glpricefrom")
    WebElement priceFrom;
    @FindBy(how = How.ID, using = "glpriceto")
    WebElement priceTo;
    @FindBy(how = How.XPATH, using = "//*[@data-apiary-widget-name=\"@MarketNode/SearchPager\"]//*[contains(@id, 'dropdown')]/..")
    WebElement numOfElementsSelector;
    @FindBy(how = How.XPATH, using = "//*[@data-apiary-widget-name=\"@MarketNode/HeaderSearch\"]//*[@placeholder=\"Искать товары\"]")
    WebElement searchField;
    @FindBy(how = How.XPATH, using = "//*[@data-apiary-widget-name=\"@MarketNode/HeaderSearch\"]//*[text()=\"Найти\"]")
    WebElement searchButton;

    By nextPage = By.xpath("//*[@data-apiary-widget-name=\"@MarketNode/SearchPager\"] //*[text()=\"Вперёд\"]");
    By results = By.xpath("//*[@data-apiary-widget-name=\"@MarketNode/SearchPartition\"]//*[@data-zone-name=\"snippet-card\"]");
    By loadingIMG = By.xpath("//*[@data-zone-name=\"SearchResultsPaged\"]//div[@role=\"main\"]/div[not(@data-apiary-widget-name)]");
    By titleSelector = By.xpath("//*[@data-zone-name=\"title\"]");

    String numOfElements = "//*[@data-apiary-widget-name=\"@MarketNode/SearchPager\"]//button[contains(., 'Показывать по XXX')]";
    String brandSelectorXPATH = "//*[@id=\"search-prepack\"]//*[text()='BRAND']";

    public MarketPageAfterSearch(WebDriver driver) {
        this.driver = driver;
        PageFactory.initElements(driver, this);
    }

    public void setPriceFilter(int from, int to) {
        priceFrom.sendKeys(Integer.toString(from));
        priceTo.sendKeys(Integer.toString(to));
    }

    public void setBrandSelector(String brand) {
        WebElement brandSelector = driver.findElement(By.xpath(brandSelectorXPATH.replace("BRAND", brand)));
        brandSelector.click();
    }

    public void setNumOfElementsShown(int num) {
        JavascriptExecutor executor = (JavascriptExecutor) driver;

        if (!PageUtils.isVisible(numOfElementsSelector))
            return;

        executor.executeScript("arguments[0].click();", numOfElementsSelector);
        executor.executeScript("arguments[0].click();",
                driver.findElement(By.xpath(numOfElements.replace("XXX", Integer.toString(num)))));
    }

    public List<String> getResults() {
        List<String> elements = driver.findElements(results).stream().map(WebElement::getText).collect(Collectors.toList());
        JavascriptExecutor executor = (JavascriptExecutor) driver;

        while (!driver.findElements(nextPage).isEmpty()) {
            executor.executeScript("arguments[0].click();", driver.findElement(nextPage));
            waitUntilPageLoaded();
            elements.addAll(driver.findElements(results).stream().map(WebElement::getText).collect(Collectors.toList()));
        }

        return elements;
    }

    public void waitUntilPageLoaded() {
        if (driver.findElements(loadingIMG).size() != 0)
            PageUtils.waitUntilElementInvisible(driver.findElement(loadingIMG));
    }

    public int getNumOfElementsOnPage() {
        return driver.findElements(results).size();
    }

    public String getTitleOfResult(int index) {
        return driver.findElements(results).get(index).findElement(titleSelector).getText();
    }

    public void search(String request) {
        searchField.sendKeys(request);
        searchButton.click();
    }
}
