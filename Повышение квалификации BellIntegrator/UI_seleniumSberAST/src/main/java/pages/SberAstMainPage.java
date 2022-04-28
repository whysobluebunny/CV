package pages;

import org.openqa.selenium.WebElement;
import org.openqa.selenium.support.FindBy;
import org.openqa.selenium.support.How;

public class SberAstMainPage implements Page {
    @FieldName("Поле поиска")
    @FindBy(how = How.XPATH, xpath = "//*[@id='txtUnitedPurchaseSearch']")
    WebElement searchField;

    @FieldName("Кнопка поиска")
    @FindBy(how = How.XPATH, xpath = "//*[@id='btnUnitedPurchaseSearch']")
    WebElement searchButton;

    public SberAstMainPage() {
        initPage();
    }

    @Override
    public boolean isPageLoaded() {
        return true;
    }
}
