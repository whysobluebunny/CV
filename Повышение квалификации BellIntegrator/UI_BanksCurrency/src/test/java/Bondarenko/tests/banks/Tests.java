package Bondarenko.tests.banks;

import driver.WebDriverManager;
import org.junit.jupiter.api.Assertions;
import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;
import org.junit.jupiter.params.ParameterizedTest;
import org.junit.jupiter.params.provider.CsvSource;
import pages.*;
import steps.Steps;

import java.util.HashMap;
import java.util.Map;

public class Tests {
    Steps steps;

    @BeforeEach
    public void beforeEach() {
        WebDriverManager.initChrome();
        steps = new Steps();
    }

    //@AfterEach
    public void closeBellTest() {
        WebDriverManager.killCurrentDriver();
    }

    @ParameterizedTest(name = "{displayName}: {arguments}")
    @CsvSource({"USD, SELL", "USD, BUY", "Euro, SELL", "Euro, BUY"})
    public void sellCurrencyTest(String value, String procedure) {
        Map<String, Double> currencies = new HashMap<>();

        steps.goPage("https://alfabank.ru/currency/");
        AlfaCurrencyPage alfaCurrencyPage = new AlfaCurrencyPage();
        currencies.put("Альфа", steps.getCurrency(value, procedure, alfaCurrencyPage));

        steps.goPage("https://open.ru");
        OpenCurrencyPage openCurrencyPage = new OpenCurrencyPage();
        currencies.put("Открытие", steps.getCurrency(value, procedure, openCurrencyPage));

        steps.goPage("https://www.vtb.ru/personal/platezhi-i-perevody/obmen-valjuty/");
        VTBCurrencyPage vtbCurrencyPage = new VTBCurrencyPage();
        currencies.put("ВТБ", steps.getCurrency(value, procedure, vtbCurrencyPage));

        for (Map.Entry<String, Double> entry : currencies.entrySet()) {
            System.out.println(entry.getKey() + " " + entry.getValue());
        }

        Assertions.assertTrue(steps.getLeastProfitable(currencies, procedure)
                - steps.getMostProfitable(currencies, procedure) < 1, "Разница более 1р");

        if(value.equals("USD") && procedure.equals("BUY"))
            steps.checkBuyRate(72.1, currencies);
    }

    @Test
    public void YandexMarketTest(){
        steps.goPage("https://market.yandex.ru/");
        MarketBeforeSearch yaBefore = new MarketBeforeSearch();
        steps.clickOnElement("Каталог", yaBefore);
        steps.hoverOnElement("Компьютеры", yaBefore);
        steps.clickOnElement("Видеокарты", yaBefore);

        MarketAfterSearch yaAfter = new MarketAfterSearch();
        steps.clickOnElement("Показать все", yaAfter);

        steps.sendKeysToElement("Поле поиска",yaAfter, "GTX 1060");
        steps.clickOnElement("GTX1060", yaAfter);
        steps.clickOnElement("Сортировка по цене", yaAfter);
        yaAfter.waitUntilPageLoaded();
        double gtx = steps.getPrice(yaAfter);

        steps.clickOnElement("GTX1060", yaAfter);
        yaAfter.waitUntilPageLoaded();
        steps.sendKeysToElement("Поле поиска",yaAfter, "RTX 3060");
        steps.clickOnElement("RTX3060", yaAfter);
        yaAfter.waitUntilPageLoaded();
        double rtx = steps.getPrice(yaAfter);

        steps.confirmPrices(gtx, rtx);
    }
}
