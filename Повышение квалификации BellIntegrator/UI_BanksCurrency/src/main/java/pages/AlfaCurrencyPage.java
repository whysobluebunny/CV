package pages;

import driver.WebDriverManager;
import helpers.PageUtils;
import org.openqa.selenium.By;
import org.openqa.selenium.WebElement;
import org.openqa.selenium.support.FindBy;
import org.openqa.selenium.support.How;

public class AlfaCurrencyPage implements CurrencyPage, Page {
    @FieldName("Курс покупки доллара")
    @FindBy(how = How.XPATH, xpath = "//table/tbody/tr[1]/td[2]")
    public WebElement usdBuyRate;

    @FieldName("Курс покупки евро")
    @FindBy(how = How.XPATH, xpath = "//table/tbody/tr[2]/td[2]")
    public WebElement euroBuyRate;

    @FieldName("Курс продажи выбранной валюты")
    @FindBy(how = How.XPATH, xpath = "//table/tbody/tr[1]/td[2]")
    public WebElement sellRate;

    @FieldName("Выбрать рубли для обмена")
    @FindBy(how = How.XPATH, xpath = "//button[@data-test-id='currency-RUB']")
    public WebElement rubButton;

    @FieldName("Выбрать доллар для обмена")
    @FindBy(how = How.XPATH, xpath = "//button[@data-test-id='currency-USD']")
    public WebElement usdButton;

    @FieldName("Выбрать евро для обмена")
    @FindBy(how = How.XPATH, xpath = "//button[@data-test-id='currency-EUR']")
    public WebElement euroButton;

    @FieldName("Элемент отображения загрузки страницы")
    @FindBy(how = How.XPATH, xpath = "//div[@data-test-id='spinner']")
    public WebElement spinner;
    By spinnerXPATH = By.xpath("//div[@data-test-id='spinner']");

    public AlfaCurrencyPage() {
        initPage();
    }

    public void waitUntilPageLoaded() {
        if (WebDriverManager.getCurrentDriver().findElements(spinnerXPATH).size() != 0)
            PageUtils.waitUntilElementInvisible(spinner);
    }

    public void clickButton(WebElement button){
        waitUntilPageLoaded();
        button.click();
    }

    @Override
    public Double getCurrency(String currencyName, String operationType) {
        if (currencyName.equals("USD")) {
            if (operationType.equals("SELL")) {
                clickButton(rubButton);
                return Double.parseDouble(usdBuyRate.getText().replace(",", ".").substring(0,5));
            }
            clickButton(usdButton);
            return Double.parseDouble(sellRate.getText().replace(",", ".").substring(0,5));
        }
        if (currencyName.equals("Euro")) {
            if (operationType.equals("SELL")) {
                clickButton(rubButton);
                return Double.parseDouble(euroBuyRate.getText().replace(",", ".").substring(0,5));
            }
            clickButton(euroButton);
            return Double.parseDouble(sellRate.getText().replace(",", ".").substring(0,5));
        }
        return null;
    }

    @Override
    public void preActions() {
    }

    @Override
    public boolean isPageLoaded() {
        return true;
    }
}
