package pages;

import org.openqa.selenium.By;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;
import org.openqa.selenium.interactions.Actions;
import org.openqa.selenium.support.FindBy;
import org.openqa.selenium.support.How;
import org.openqa.selenium.support.PageFactory;

public class MarketPageBeforeSearch {
    private final WebDriver driver;

    @FindBy(how = How.XPATH, using = "//*[@data-apiary-widget-name=\"@MarketNode/HeaderCatalogEntrypoint\"]")
    WebElement catalogButton;

    By advertisement = By.xpath("//*[@data-apiary-widget-id=\"/dailyBonusesPopup\"]//*[local-name()='svg']");

    String categoryButtonXPATH = "//*[@data-apiary-widget-name=\"@MarketNode/HeaderCatalog\"]//*[text()='XXXXXX']";

    String subcategoryButtonXPATH = "//*[@data-apiary-widget-name=\"@MarketNode/NavigationTree\"]//*[text()=\"XXXXXX\"]";

    public MarketPageBeforeSearch(WebDriver driver) {
        this.driver = driver;
        PageFactory.initElements(driver, this);
    }

    public void clickCategory(String category, String subcategory) {
        catalogButton.click();
        Actions action = new Actions(driver);
        action.moveToElement(driver.findElement(By.xpath(categoryButtonXPATH.replace("XXXXXX", category))));
        action.perform();
        driver.findElement(By.xpath(subcategoryButtonXPATH.replace("XXXXXX", subcategory))).click();
    }

    public void closeAds() {
        if(driver.findElements(advertisement).size()!=0)
            driver.findElement(advertisement).click();
    }
}
