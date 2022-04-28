import java.util.ArrayList;
import java.util.Random;

public class Hand {
    private final int MAX_VALUE;
    private final int numberOfDices;
    private static final Random random = new Random();

    public Hand(int number){
        numberOfDices = number;
        MAX_VALUE = number * 6;
    }

    public int roll(){
        int score = 0;
        for (int i = 0; i < numberOfDices; i++) score += random.nextInt(6) + 1;
        return score;
    }

    public boolean isMax(int value){
        return value == MAX_VALUE;
    }
}
