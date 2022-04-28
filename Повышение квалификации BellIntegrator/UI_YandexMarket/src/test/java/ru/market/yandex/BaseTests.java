package ru.market.yandex;

import driver.WebDriverHelper;
import org.junit.jupiter.api.AfterEach;
import org.junit.jupiter.api.BeforeEach;
import org.openqa.selenium.WebDriver;

public class BaseTests {
    protected WebDriver chromeDriver;

    @BeforeEach
    public void before() {
        WebDriverHelper.initChrome();
        chromeDriver = WebDriverHelper.getCurrentDriver();
    }

    @AfterEach
    public void closeBellTest() {
        WebDriverHelper.killCurrentDriver();
    }
}
