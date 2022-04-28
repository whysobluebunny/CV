package support;

import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class TestUtils {
    public static boolean isHex(String sample){
        String HEX_PATTERN = "^#([A-Fa-f0-9]{6}|[A-Fa-f0-9]{3})$";
        Pattern pattern = Pattern.compile(HEX_PATTERN);
        Matcher matcher = pattern.matcher(sample);

        return matcher.matches();
    }
}
