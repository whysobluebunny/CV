package pages;

import io.qameta.allure.Step;
import org.openqa.selenium.WebElement;
import org.openqa.selenium.support.FindBy;
import org.openqa.selenium.support.How;

import static com.codeborne.selenide.Selenide.$x;
import static com.codeborne.selenide.Selenide.page;

public class SberAstMainPage{
    String searchField = "//*[@id='txtUnitedPurchaseSearch']";
    String searchButton = "//*[@id='btnUnitedPurchaseSearch']";

    @Step("Выполнить поиск: {key}")
    public SberPurchaseListPage fillSearch(String key){
        $x(searchField).sendKeys(key);
        $x(searchButton).click();

        return page(SberPurchaseListPage.class);
    }
}
