package ru.market.yandex;

import io.qameta.allure.Feature;
import org.junit.jupiter.api.Assertions;
import org.junit.jupiter.api.DisplayName;
import org.junit.jupiter.api.Test;
import org.junit.jupiter.params.ParameterizedTest;
import org.junit.jupiter.params.provider.CsvSource;
import pages.MarketPageAfterSearch;
import pages.MarketPageBeforeSearch;
import pages.YandexSearchPage;

import java.util.List;
import java.util.Locale;

public class Tests extends BaseTests {
    @Feature("Задание 1.3")
    @DisplayName("Проверка результатов поиска ноутбуков")
    @Test
    public void testTask3() {
        chromeDriver.get("https://yandex.ru/");
        YandexSearchPage yaPage = new YandexSearchPage(chromeDriver);
        chromeDriver.get(yaPage.getMarketURL());

        MarketPageBeforeSearch pageBeforeSearch = new MarketPageBeforeSearch(chromeDriver);

        pageBeforeSearch.closeAds();
        pageBeforeSearch.clickCategory("Компьютеры", "Ноутбуки");

        MarketPageAfterSearch pageAfterSearch = new MarketPageAfterSearch(chromeDriver);
        pageAfterSearch.setPriceFilter(10000, 30000);
        pageAfterSearch.setBrandSelector("HP");
        pageAfterSearch.setBrandSelector("Lenovo");
        pageAfterSearch.setNumOfElementsShown(12);

        pageAfterSearch.waitUntilPageLoaded();
        Assertions.assertEquals(12, pageAfterSearch.getNumOfElementsOnPage());

        String firstResult = pageAfterSearch.getTitleOfResult(0);
        pageAfterSearch.search(firstResult);

        pageAfterSearch.waitUntilPageLoaded();
        Assertions.assertTrue(firstResult.contains(pageAfterSearch.getTitleOfResult(0)));
    }

    @Feature("Задание 1.4")
    @DisplayName("Проверка результатов поиска смартфонов по производителю")
    @ParameterizedTest(name = "{displayName}: {arguments}")
    @CsvSource({"Apple"})
    public void test4(String brand) {
        chromeDriver.get("https://yandex.ru/");
        YandexSearchPage yaPage = new YandexSearchPage(chromeDriver);
        chromeDriver.get(yaPage.getMarketURL());

        MarketPageBeforeSearch pageBeforeSearch = new MarketPageBeforeSearch(chromeDriver);
        pageBeforeSearch.closeAds();
        pageBeforeSearch.clickCategory("Электроника", "Смартфоны");

        MarketPageAfterSearch pageAfterSearch = new MarketPageAfterSearch(chromeDriver);
        pageAfterSearch.setBrandSelector(brand);

        pageAfterSearch.setNumOfElementsShown(12);

        pageAfterSearch.waitUntilPageLoaded();
        Assertions.assertEquals(12, pageAfterSearch.getNumOfElementsOnPage());

        List<String> results = pageAfterSearch.getResults();
        Assertions.assertTrue(results.stream().allMatch(x ->
                        x.toLowerCase(Locale.ROOT).contains(brand.toLowerCase(Locale.ROOT))),
                "Не все результаты совпадают с параметрами");
    }


}
