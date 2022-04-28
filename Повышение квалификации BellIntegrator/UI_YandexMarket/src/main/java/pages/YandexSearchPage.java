package pages;

import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;
import org.openqa.selenium.support.FindBy;
import org.openqa.selenium.support.How;
import org.openqa.selenium.support.PageFactory;

public class YandexSearchPage {
    private final WebDriver driver;

    @FindBy(how = How.XPATH, using = "//*[@data-id='market']")
    WebElement marketButton;

    public YandexSearchPage(WebDriver driver) {
        this.driver = driver;
        PageFactory.initElements(driver, this);
    }

    public String getMarketURL() {
        return marketButton.getAttribute("href");
    }
}
