package pages;

import com.codeborne.selenide.Condition;
import com.codeborne.selenide.SelenideElement;
import dto.PurchaseInfo;
import io.qameta.allure.Step;
import org.openqa.selenium.By;

import java.util.List;
import java.util.stream.Collectors;

import static com.codeborne.selenide.Selenide.*;

public class SberPurchaseListPage {
    String resultNumberSelector = "//*[@id='headerPagerSelect']";
    String nextPageButton = "//*[text()='>']";
    String loader = "//*[@class='nbt-grid-ajax-loader']";
    String resultTableElement = "//span[text()='Госзакупки по 44-ФЗ']/ancestor::table";
    String purchaseName = ".//*[@class='es-el-type-name']";
    String purchaseID = ".//*[@class='es-el-code-term']";
    String purchasePrice = ".//*[@class='es-el-amount']";


    private void waitUntilPageLoaded() {
        $x(loader).should(Condition.disappear);
    }

    private PurchaseInfo getPurchaseInfo(SelenideElement from) {
        PurchaseInfo pInfo = new PurchaseInfo(from.find(By.xpath(purchaseName)).getText(),
                Double.parseDouble(from.find(By.xpath(purchasePrice)).getText().replaceAll(" ", "")),
                from.find(By.xpath(purchaseID)).getText());
        return pInfo;
    }

    private List<PurchaseInfo> getPurchaseInfoList(Double price) {
        return $$x(resultTableElement).stream()
                .map(element -> getPurchaseInfo(element))
                .filter(x -> x.getPrice() > price).collect(Collectors.toList());
    }

    @Step("Выбрать количество отображаемых результатов: {num}")
    public SberPurchaseListPage selectAmountOfResults(int num) {
        waitUntilPageLoaded();
        $x(resultNumberSelector).selectOption(Integer.toString(num));
        return this;
    }

    @Step("Получить список заказов стоимостью больше {price}")
    public SberPurchaseListPage getPurchasesOfPrice(double price) {
        waitUntilPageLoaded();
        List<PurchaseInfo> purchaseInfoList = getPurchaseInfoList(price);
        $x(nextPageButton).click();

        waitUntilPageLoaded();
        selectAmountOfResults(20);
        waitUntilPageLoaded();

        purchaseInfoList.addAll(getPurchaseInfoList( price));
        System.out.println("Size: " + purchaseInfoList.size());

        for(var elem : purchaseInfoList)
            System.out.println(elem);
        return this;
    }
}
