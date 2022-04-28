package pages;

import org.openqa.selenium.WebElement;
import org.openqa.selenium.support.FindBy;
import org.openqa.selenium.support.How;

public class MarketBeforeSearch implements Page {
    @FieldName("Каталог")
    @FindBy(how = How.XPATH, using = "//*[@data-apiary-widget-name='@MarketNode/HeaderCatalogEntrypoint']")
    WebElement catalogButton;

    @FieldName("Видеокарты")
    @FindBy(how = How.XPATH, using = "//*[@data-apiary-widget-name='@MarketNode/NavigationTree']//*[text()='Видеокарты']")
    WebElement cardsButton;

    @FieldName("Компьютеры")
    @FindBy(how = How.XPATH, using = "//*[@data-apiary-widget-name='@MarketNode/HeaderCatalog']//*[text()='Компьютеры']")
    WebElement computersButton;

    public MarketBeforeSearch() {
        initPage();
    }

    @Override
    public boolean isPageLoaded() {
        return true;
    }
}
