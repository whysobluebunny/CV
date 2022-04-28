package steps;

import dto.PaintData;
import dto.PaintInfo;
import io.qameta.allure.Step;
import org.junit.jupiter.api.Assertions;
import support.TestUtils;

public class Steps {
    @Step("Проверка, что все данные в полях являются цветами")
    public void checkColors(PaintData paintData){
        for(PaintInfo paint : paintData.getData())
            Assertions.assertTrue(TestUtils.isHex(paint.getColor()));
    }

    @Step("Проверка, что количество элементов data соответсвует per_page")
    public void checkNumOfResources(PaintData paintData){
        Assertions.assertEquals(paintData.getPerPage(), paintData.getData().size());
    }

    @Step("Проверка, что хотя бы один элемент содержит год {year}")
    public void checkIfContainsYear(PaintData paintData, int year){
        Assertions.assertTrue(paintData.getData().stream().anyMatch(x-> x.getYear() == year));
    }
}
