//package pages;
//
//import org.openqa.selenium.WebElement;
//import org.openqa.selenium.support.FindBy;
//import org.openqa.selenium.support.How;
//
//public class TinkoffCurrencyPage implements CurrencyPage, Page{
//    djflkdjsfsldfdlsjfljfs
//
//    //div[@data-qa-type="uikit/portalWrapper"]//*[@role='option' and contains(.,'Евро')] селектор евро
//    //div[@data-qa-type="uikit/portalWrapper"]//*[@role='option' and contains(.,'Доллар')]
//
//    //TODO случайно сюда альфу написал
//    @FieldName("Курс покупки доллара")
//    @FindBy(how = How.XPATH, xpath = "//table/tbody/tr[1]/td[2]")
//    public WebElement usdBuyRate;
//
//    @FieldName("Курс покупки евро")
//    @FindBy(how = How.XPATH, xpath = "//table/tbody/tr[2]/td[2]")
//    public WebElement euroBuyRate;
//
//    @FieldName("Курс продажи выбранной валюты")
//    @FindBy(how = How.XPATH, xpath = "//table/tbody/tr[1]/td[2]")
//    public WebElement sellRate;
//
//    @FieldName("Выбрать рубли для обмена")
//    @FindBy(how = How.XPATH, xpath = "//button[@data-test-id='currency-RUB']")
//    public WebElement rubButton;
//
//    @FieldName("Выбрать доллар для обмена")
//    @FindBy(how = How.XPATH, xpath = "//button[@data-test-id='currency-USD']")
//    public WebElement usdButton;
//
//    @FieldName("Выбрать евро для обмена")
//    @FindBy(how = How.XPATH, xpath = "//button[@data-test-id='currency-EUR']")
//    public WebElement euroButton;
//
//    public TinkoffCurrencyPage() {
//        initPage();
//    }
//
//    @Override
//    public Double getCurrency(String currencyName, String operationType) {
//        if(currencyName.equals("USD")) {
//            if (operationType.equals("SELL")) {
//                usdButton.click();
//                return Double.parseDouble(sellRate.getText().replace(",","."));
//            }
//            rubButton.click();
//            return Double.parseDouble(usdBuyRate.getText().replace(",","."));
//        }
//        if(currencyName.equals("Euro")) {
//            if (operationType.equals("SELL")) {
//                euroButton.click();
//                return Double.parseDouble(sellRate.getText().replace(",","."));
//            }
//            rubButton.click();
//            return Double.parseDouble(euroBuyRate.getText().replace(",","."));
//        }
//        return null;
//    }
//
//    @Override
//    public void preActions() { }
//
//    @Override
//    public boolean isPageLoaded() {
//        return true;
//    }
//}
