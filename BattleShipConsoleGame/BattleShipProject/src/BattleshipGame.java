import java.util.Scanner;

public class BattleshipGame {
    /** Current ocean */
    private static Ocean ocean;
    /** Scanner to read coordinates */
    private static Scanner in = new Scanner(System.in);

    /**
     * Gets coordinates from a user
     * @return integer value which represents one of the coordinates
     */
    private static int getCoordinate(){
        int num;
        while(true){
            try {
                String input = in.nextLine();
                num = Integer.parseInt(input);
                if (num > 9 || num < 0)
                    throw new IllegalArgumentException("Number must be greater " +
                            "than 0 and less than 9!");
                break;
            }
            catch (Exception e) {
                System.out.println(e.getMessage());
            }
        }
        return num;
    }

    /** Prints game rules */
    private static void printHowToPlay(){
        System.out.println("The battlefield contains:");
        System.out.println("One Battleship (4 tiles)");
        System.out.println("Two Cruisers (3 tiles)");
        System.out.println("Three Destroyers (2 tiles)");
        System.out.println("Four Submarines (1 tile)");
        System.out.println("Ships can be both horizontal and vertical");
    }

    /** Prints UI (Field, statistic) */
    private static void printUI(){
        System.out.println("\nShots fired: " + ocean.getShotsFired());
        System.out.println("Number of hits: " + ocean.getHitCount());
        System.out.println("Ships sunk: " + ocean.getShipsSunk());
        ocean.print();
    }

    /** Gets place to fire and fires there */
    private static void fire(){
        System.out.println("Input row to fire");
        int row = getCoordinate();
        System.out.println("Input column to fire");
        int column = getCoordinate();
        try{
            boolean shootAt = ocean.shootAt(row,column);
            if(shootAt & ocean.getShipArray()[row][column].isSunk())
                System.out.println("\nYou sank a " +
                        ocean.getShipArray()[row][column].getShipType());
            else if(shootAt)
                System.out.println("\nHit!");
            else
                System.out.println("\nMiss!");
        } catch (BattleShipGameException e) {
            System.out.println(e.getMessage());
        }
    }

    /** Start(restart) game method */
    private static void startGame() {
        ocean = new Ocean();
        printHowToPlay();
        while (!ocean.isGameOver()){
            printUI();
            fire();
        }
    }

    /** Prints final statistics */
    private static void endGame() {
        printUI();
        System.out.println("You won!");
    }

    /**
     * Checks if user wants to play again
     * @return true if user wants to replay
     */
    private static boolean restartGame(){
        System.out.println("Input anything to restart or type " +
                "\"quit\" to exit.");
        return !in.nextLine().equals("quit");
    }

    public static void main(String[] args) {
        do {
            startGame();
            endGame();
        } while (restartGame());
    }
}
