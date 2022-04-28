import java.util.Arrays;
import java.util.Random;

public class Ocean {
    private static Random randomizer = new Random();
    Ship[][] ships = new Ship[10][10];

    private int shotsFired = 0;
    private int hitCount = 0;
    private int shipsSunk = 0;

    public Ocean() {
        for (int i = 0; i < 10; i++)
            for (int j = 0; j < 10; j++)
                ships[i][j] = new EmptySea();
        placeAllShipsRandomly();
    }

    public int getShotsFired() {
        return shotsFired;
    }

    public int getHitCount() {
        return hitCount;
    }

    public int getShipsSunk() {
        return shipsSunk;
    }

    public Ship[][] getShipArray() {
        return ships;
    }

    public boolean isGameOver() {
        for (Ship[] row : ships)
            for (Ship ship : row)
                if (!ship.isSunk() & !(ship instanceof EmptySea)) return false;
        return true;
    }

    boolean isOccupied(int row, int column) {
        return !(ships[row][column] instanceof EmptySea);
    }

    boolean shootAt(int row, int column) throws BattleShipGameException {
        shotsFired++;
        boolean hit = ships[row][column].shootAt(row, column);
        if (hit) {
            hitCount++;
            if (ships[row][column].isSunk()) {
                ships[row][column].sank(this);
                shipsSunk++;
            }
        }
        return hit;
    }

    public void print() {
        System.out.print("  ");
        for (int i = 0; i < 10; i++)
            System.out.print(i + " ");
        System.out.println();
        for (int i = 0; i < 10; i++) {
            for (int j = 0; j < 10; j++) {
                if (j == 0) System.out.print(i + " ");
                System.out.print(ships[i][j].toString(i, j) + " ");
            }
            System.out.println();
        }
    }

    private void createAndPlaceShip(int i) {
        Ship newShip = null;
        while (newShip == null)
            try {
                switch (i) {
                    case 1:
                        newShip = new Battleship();
                        break;
                    case 2:
                        newShip = new Cruiser();
                        break;
                    case 3:
                        newShip = new Destroyer();
                        break;
                    case 4:
                        newShip = new Submarine();
                        break;
                }

                int row, column;
                do {
                    row = randomizer.nextInt(10);
                    column = randomizer.nextInt(10);
                } while (isOccupied(row, column));
                newShip.placeShipAt(row, column, randomizer.nextBoolean(), this);
            } catch (Exception e) {
                newShip = null;
            }
    }

    public void placeAllShipsRandomly() {
        for (int i = 1; i < 5; i++) {
            for (int j = 0; j < i; j++)
                createAndPlaceShip(i);
        }
    }
}
