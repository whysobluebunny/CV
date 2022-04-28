package pages;

import org.openqa.selenium.WebElement;
import org.openqa.selenium.support.FindBy;

public class OpenCurrencyPage implements CurrencyPage, Page {

    @FindBy(xpath = "//div[@role = 'tablist']//div[@role = 'tab' and contains(., 'Стандартный')]")
    private WebElement standardCurrencyButton;

    @FindBy(xpath = "//div[@aria-hidden='false']//table//tr[2]/td[2]")
    private WebElement dollarBuyCurrency;
    @FindBy(xpath = "//div[@aria-hidden='false']//table//tr[2]/td[4]")
    private WebElement dollarSellCurrency;
    @FindBy(xpath = "//div[@aria-hidden='false']//table//tr[3]/td[2]")
    private WebElement euroBuyCurrency;
    @FindBy(xpath = "//div[@aria-hidden='false']//table//tr[3]/td[4]")
    private WebElement euroSellCurrency;



    public OpenCurrencyPage() {
        initPage();
    }

    @Override
    public Double getCurrency(String currencyName, String operationType) {
        if(currencyName.equals("USD")) {
            if (operationType.equals("SELL")) {
                return Double.parseDouble(dollarSellCurrency.getText().replace(",","."));
            }
            return Double.parseDouble(dollarBuyCurrency.getText().replace(",","."));
        }
        if(currencyName.equals("Euro")) {
            if (operationType.equals("SELL")) {
                return Double.parseDouble(euroSellCurrency.getText().replace(",","."));
            }
            return Double.parseDouble(euroBuyCurrency.getText().replace(",","."));
        }
        return null;
    }

    @Override
    public void preActions() {
        standardCurrencyButton.click();
    }

    @Override
    public boolean isPageLoaded() {
        return true;
    }
}
