package ru.ast.sberbank.tests;

import com.codeborne.selenide.Configuration;
import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;
import org.openqa.selenium.chrome.ChromeOptions;
import org.openqa.selenium.remote.DesiredCapabilities;
import pages.SberAstMainPage;
import pages.SberPurchaseListPage;

import static com.codeborne.selenide.Selenide.open;

public class Tests {
    @BeforeEach
    public void setConfig(){
        Configuration.timeout=60000;
        Configuration.browser="chrome";
        Configuration.startMaximized=true;

        ChromeOptions options = new ChromeOptions();
        options.addArguments("--disable-extensions");

        DesiredCapabilities capabilities = new DesiredCapabilities();
        capabilities.setCapability(ChromeOptions.CAPABILITY, options);
        Configuration.browserCapabilities = capabilities;
    }

    @Test
    public void astTest() {
        open("https://www.sberbank-ast.ru/", SberAstMainPage.class)
                .fillSearch("Страхование")
                .selectAmountOfResults(100)
                .getPurchasesOfPrice(600000);
    }
}
