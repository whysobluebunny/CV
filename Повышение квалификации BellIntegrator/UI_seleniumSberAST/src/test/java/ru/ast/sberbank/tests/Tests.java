package ru.ast.sberbank.tests;

import driver.WebDriverManager;
import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;
import pages.SberAstMainPage;
import pages.SberPurchaseListPage;
import steps.Steps;

public class Tests {
    Steps steps;

    @BeforeEach
    public void beforeEach() {
        WebDriverManager.initChrome();
        steps = new Steps();
    }

    //@AfterEach
    public void endTest() {
        WebDriverManager.killCurrentDriver();
    }

    @Test
    public void astTest() {
        steps.goPage("https://www.sberbank-ast.ru/");
        SberAstMainPage main = new SberAstMainPage();
        steps.sendKeysToElement("Поле поиска", main, "Страхование");
        steps.clickOnElement("Кнопка поиска", main);
        SberPurchaseListPage purchaseListPage = new SberPurchaseListPage();
        steps.selectAmountOfResults(100, purchaseListPage);
        steps.getPurchasesOfPrice(600000, purchaseListPage);
    }
}
