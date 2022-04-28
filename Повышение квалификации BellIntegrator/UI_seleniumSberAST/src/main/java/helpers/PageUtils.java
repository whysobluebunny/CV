package helpers;

import driver.WebDriverManager;
import org.openqa.selenium.By;
import org.openqa.selenium.NoSuchElementException;
import org.openqa.selenium.TimeoutException;
import org.openqa.selenium.WebElement;
import org.openqa.selenium.support.ui.ExpectedCondition;
import org.openqa.selenium.support.ui.ExpectedConditions;
import org.openqa.selenium.support.ui.WebDriverWait;

import java.util.List;
import java.util.stream.Collectors;

public class PageUtils {
    public static boolean isVisible(WebElement element) {
        return element.isDisplayed();
    }

    public static void waitUntilElementInvisible(WebElement element) {
        try {
            new WebDriverWait(WebDriverManager.getCurrentDriver(), Constants.DEFAULT_TIMEOUT)
                    .until(ExpectedConditions.invisibilityOf(element));
        } catch (TimeoutException ignored) {
        }
    }

    public static void waitUntilElementBeVisible(WebElement element) {
        if (isVisible(element)) return;
        new WebDriverWait(WebDriverManager.getCurrentDriver(), Constants.DEFAULT_TIMEOUT)
                .until(ExpectedConditions.visibilityOf(element));
    }

    private static void waitUntilElementBeClickable(WebElement element) {
        new WebDriverWait(WebDriverManager.getCurrentDriver(), Constants.DEFAULT_TIMEOUT)
                .until(ExpectedConditions.elementToBeClickable(element));
    }

    private static void waitUntilElementTextContains(WebElement element, String text) {
        new WebDriverWait(WebDriverManager.getCurrentDriver(), Constants.DEFAULT_TIMEOUT)
                .until(ExpectedConditions.textToBePresentInElement(element, text));
    }


    public static void waitUntilElementsCountWillBe(String xpath, Integer number) {
        new WebDriverWait(WebDriverManager.getCurrentDriver(), Constants.DEFAULT_TIMEOUT)
                .until(ExpectedConditions.numberOfElementsToBe(By.xpath(xpath), number));
    }

    public static boolean isClickable(WebElement element) {
        try {
            waitUntilElementBeClickable(element);
        } catch (TimeoutException e) {
            return false;
        }
        return true;
    }

    public static boolean isElementTextContains(WebElement element, String text) {
        try {
            waitUntilElementTextContains(element, text);
        } catch (TimeoutException e) {
            return false;
        }
        return true;
    }

    public static boolean isElementNotExist(WebElement element) {
        int timer = 0;
        try {
            while (isVisible(element) && timer < 10) {
                try {
                    Thread.sleep(3000);
                } catch (InterruptedException e) {
                    e.printStackTrace();
                }
                timer++;
            }
            return false;
        } catch (NoSuchElementException e) {
            return true;
        }
    }

    public static void waitUntilAttributeWillBe(WebElement element, String attribute, String value) {
        new WebDriverWait(WebDriverManager.getCurrentDriver(), Constants.DEFAULT_TIMEOUT)
                .until((ExpectedCondition<Boolean>) driver -> element.getAttribute(attribute).contains(value));
    }

    public static List<String> findElements(By by) {
        return WebDriverManager.getCurrentDriver().findElements(by).stream().map(WebElement::getText).collect(Collectors.toList());
    }
}
