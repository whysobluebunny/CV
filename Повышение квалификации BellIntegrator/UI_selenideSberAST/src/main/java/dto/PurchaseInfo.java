package dto;

import lombok.Data;
import lombok.RequiredArgsConstructor;

@Data
@RequiredArgsConstructor
public class PurchaseInfo {
    private final String name;
    private final Double price;
    private final String id;

    @Override
    public String toString() {
        return "Заказ '" + name + "', Номер: " + id + ", Сумма: " + price;
    }
}
