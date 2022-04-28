package steps;

import driver.WebDriverManager;
import helpers.AllureEdit;
import helpers.CustomUtils;
import helpers.PageUtils;
import io.qameta.allure.Step;
import org.junit.jupiter.api.Assertions;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;
import org.openqa.selenium.interactions.Actions;
import pages.CurrencyPage;
import pages.MarketAfterSearch;
import pages.Page;

import java.util.HashMap;
import java.util.Map;

public class Steps {

    private final WebDriver driver;

    Map<String, String> pageNames = new HashMap<>();

    public Steps() {
        this.driver = WebDriverManager.getCurrentDriver();
    }

    @Step("Перейти на страницу {url}")
    public void goPage(String url) {
        driver.get(url);
        AllureEdit.setLastStepName("Перейти на страницу " + driver.getTitle());
        if (pageNames.containsKey(url)) {
            Assertions.assertTrue(driver.getTitle().contains(pageNames.get(url)));
        }
    }

    @Step("Кликнуть на элемент {elementName}")
    public void clickOnElement(String elementName, Page page) {
        WebElement element = page.getElement(elementName);
        element.click();
    }

    @Step("Заполнить поле")
    public void sendKeysToElement(String elementName, Page page, String keys) {
        WebElement element = page.getElement(elementName);
        element.clear();
        element.sendKeys(keys);
    }

    @Step("Навести на элемент {elementName}")
    public void hoverOnElement(String elementName, Page page) {
        WebElement element = page.getElement(elementName);
        Actions actions = new Actions(driver);
        actions.moveToElement(element);
        actions.build().perform();
    }

    @Step("Получить курс валюты {currencyName} по операции {operationType}")
    public Double getCurrency(String currencyName, String operationType, CurrencyPage page) {
        AllureEdit.deleteLastStepParameter("page");
        page.preActions();
        return page.getCurrency(currencyName, operationType);
    }

    @Step
    public double getMostProfitable(Map<String, Double> currencies, String procedure) {
        if (procedure.equals("SELL"))
            return findMin(currencies);
        return findMax(currencies);
    }

    @Step
    public double getLeastProfitable(Map<String, Double> currencies, String procedure) {
        if (procedure.equals("SELL"))
            return findMax(currencies);
        return findMin(currencies);
    }

    @Step("Определение лучшего курса")
    public double findMax(Map<String, Double> currencies) {
        double max = 0D;
        String mostProfitableBank = "";
        for (Map.Entry<String, Double> entry : currencies.entrySet()) {
            if (max < entry.getValue()) {
                max = entry.getValue();
                mostProfitableBank = entry.getKey();
            }
        }
        CustomUtils.print("Наилучшее предложение: " + mostProfitableBank + ". Текущий курс: " + max);
        return currencies.get(mostProfitableBank);
    }

    @Step("Определение худшего курса")
    public double findMin(Map<String, Double> currencies) {
        double min = 9999;
        String lessProfitableBank = "";
        for (Map.Entry<String, Double> entry : currencies.entrySet()) {
            if (min > entry.getValue()) {
                min = entry.getValue();
                lessProfitableBank = entry.getKey();
            }
        }
        CustomUtils.print("Наименее выгодное предложение: " + lessProfitableBank + ". Текущий курс: " + min);
        return currencies.get(lessProfitableBank);
    }

    @Step("Проверка, что курс не превышает {rate}")
    public void checkBuyRate(Double rate, Map<String, Double> currencies) {
        boolean flag = true;
        for (Map.Entry<String, Double> entry : currencies.entrySet()) {
            if (!checkParticularBankRate(rate, entry.getKey(), entry.getValue())) {
                flag = false;
                AllureEdit.setLastStepStatusFailed();
            }
        }

        Assertions.assertTrue(flag, "Курс одного или нескольких банков превышает проверяемое значение");
    }

    @Step("Проверка, что курс банка {bank} не превышает {rate}")
    public boolean checkParticularBankRate(Double rate, String bank, Double bankRate) {
        return bankRate <= rate;
    }

    @Step("Самый дешевый представленный вариант")
    public double getPrice(MarketAfterSearch page) {
        CustomUtils.print(PageUtils.findElements(page.getResultXPATH()).get(0));
        return Double.parseDouble(PageUtils.findElements(page.getResultPriceXPATH()).get(0).replaceAll("\\D+", ""));
    }

    @Step("Убедимся, что цена на RTX выше цены на GTX")
    public void confirmPrices(double rtx, double gtx) {
        Assertions.assertTrue(rtx > gtx);
    }
}
