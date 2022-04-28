package pages;

import org.openqa.selenium.WebElement;
import org.openqa.selenium.support.FindBy;
import org.openqa.selenium.support.How;

public class VTBCurrencyPage implements CurrencyPage, Page {
    @FieldName("Курс покупки доллара")
    @FindBy(how = How.XPATH, xpath = "//table[@class='exchange-rate-table_no-width']//tr[contains(@class, ng-scope)][2]/td[2]")
    public WebElement usdBuyRate;

    @FieldName("Курс продажи доллара")
    @FindBy(how = How.XPATH, xpath = "//table[@class='exchange-rate-table_no-width']//tr[contains(@class, ng-scope)][2]/td[3]")
    public WebElement usdSellRate;

    @FieldName("Курс покупки евро")
    @FindBy(how = How.XPATH, xpath = "//table[@class='exchange-rate-table_no-width']//tr[contains(@class, ng-scope)][3]/td[2]")
    public WebElement euroBuyRate;

    @FieldName("Курс продажи евро")
    @FindBy(how = How.XPATH, xpath = "//table[@class='exchange-rate-table_no-width']//tr[contains(@class, ng-scope)][3]/td[3]")
    public WebElement euroSellRate;

    public VTBCurrencyPage() {
        initPage();
    }

    @Override
    public Double getCurrency(String currencyName, String operationType) {
        if(currencyName.equals("USD")) {
            if (operationType.equals("SELL")) {
                return Double.parseDouble(usdSellRate.getText().replace(",","."));
            }
            return Double.parseDouble(usdBuyRate.getText().replace(",","."));
        }
        if(currencyName.equals("Euro")) {
            if (operationType.equals("SELL")) {
                return Double.parseDouble(euroSellRate.getText().replace(",","."));
            }
            return Double.parseDouble(euroBuyRate.getText().replace(",","."));
        }
        return null;
    }

    @Override
    public void preActions() { }

    @Override
    public boolean isPageLoaded() {
        return true;
    }
}
