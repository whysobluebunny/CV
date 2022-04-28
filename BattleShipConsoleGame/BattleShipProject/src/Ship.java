import javax.swing.plaf.metal.OceanTheme;
import java.util.Arrays;

/**
 * This describes characteristics common to all the ships
 *
 * @author Bondarenko Artyom BSE181
 */
public abstract class Ship {
    /**
     * the row (0 to 9) which contains the bow (front) of the ship.
     */
    protected int bowRow;
    /**
     * the column (0 to 9) which contains the bow (front) of the ship.
     */
    protected int bowColumn;
    /**
     * the number of squares occupied by the ship.
     */
    protected int length;
    /**
     * true if the ship occupies a single row, false otherwise
     */
    protected boolean horizontal;
    /**
     * -- an array of booleans telling whether that part of the ship has been hit
     */
    protected boolean[] hit = new boolean[4];

    /**
     * Used to get length value
     *
     * @return length
     */
    public int getLength() {
        return length;
    }


    /**
     * Used to get bowRow value
     *
     * @return bowRow
     */
    public int getBowRow() {
        return bowRow;
    }


    /**
     * Used to get bowColumn value
     *
     * @return bowColumn
     */
    public int getBowColumn() {
        return bowColumn;
    }


    /**
     * Used to get ship type value
     */
    public abstract String getShipType();


    /**
     * Used to get horizontal value
     *
     * @return horizontal
     */
    public boolean isHorizontal() {
        return horizontal;
    }


    /**
     * Used to set bowRow value
     */
    public void setBowRow(int row) {
        bowRow = row;
    }

    /**
     * Used to set bowColumn value
     */
    public void setBowColumn(int column) {
        bowColumn = column;
    }

    /**
     * Used to set horizontal value
     */
    public void setHorizontal(boolean horizontal) {
        this.horizontal = horizontal;
    }

    /**
     * Checks upper bounds of the ship area
     *
     * @param row        - bow row of the ship
     * @param column     - bow column of the ship
     * @param horizontal - true if ship is going to be horizontally placed
     * @param ocean      - current ocean
     * @return returns true if it's legal to place ship in this area
     */
    public boolean checkUpper(int row, int column, boolean horizontal, Ocean ocean) {
        for (int ind = -1; ind <= 1; ind += 2)
            for (int i = 0; i < length; i++) {
                try {
                    int iRow = horizontal ? row + ind : row + i;
                    int iColumn = horizontal ? column + i : column + ind;
                    if (!(ocean.getShipArray()[iRow][iColumn] instanceof EmptySea)) return false;
                } catch (IndexOutOfBoundsException e) {
                    continue;
                }
            }
        return true;
    }

    /**
     * Checks lower bounds of the ship area
     *
     * @param row        - bow row of the ship
     * @param column     - bow column of the ship
     * @param horizontal - true if ship is going to be horizontally placed
     * @param ocean      - current ocean
     * @return returns true if it's legal to place ship in this area
     */
    public boolean checkLower(int row, int column, boolean horizontal, Ocean ocean) {
        for (int ind = -1; ind <= length; ind += length + 1)
            for (int i = 0; i < 3; i++) {
                try {
                    int iRow = horizontal ? row + i - 1 : row + ind;
                    int iColumn = horizontal ? column + ind : column + i - 1;
                    if (!(ocean.getShipArray()[iRow][iColumn] instanceof EmptySea)) return false;
                } catch (IndexOutOfBoundsException e) {
                    continue;
                }
            }
        return true;
    }

    /**
     * Checks ship area to place a ship
     *
     * @param row        - bow row of the ship
     * @param column     - bow column of the ship
     * @param horizontal - true if ship is going to be horizontally placed
     * @param ocean      - current ocean
     * @return returns true if it's legal to place ship in this area
     */
    protected boolean checkSurrounding(int row, int column, boolean horizontal, Ocean ocean) {
        return checkUpper(row, column, horizontal, ocean) && checkLower(row, column, horizontal, ocean);
    }

    /**
     * Checks if it's legal to place a new ship here
     *
     * @param row        - bow row of the ship
     * @param column     - bow column of the ship
     * @param horizontal - true if ship is going to be horizontally placed
     * @param ocean      - current ocean
     * @return returns true if it's legal to place ship in this area
     */
    public boolean okToPlaceShipAt(int row, int column, boolean horizontal, Ocean ocean) {
        if (!checkSurrounding(row, column, horizontal, ocean)) return false;
        for (int i = 0; i < length; i++)
            if (horizontal) {
                if (ocean.isOccupied(row, column + i)) return false;
            } else {
                if (ocean.isOccupied(row + i, column)) return false;
            }
        return true;
    }

    /**
     * Places a new ship in passed coordinates
     *
     * @param row        - bow row of the ship
     * @param column     - bow column of the ship
     * @param horizontal - true if ship is going to be horizontally placed
     * @param ocean      - current ocean
     * @throws BattleShipGameException - appears if it is impossible to place ship here
     */
    public void placeShipAt(int row, int column, boolean horizontal, Ocean ocean) throws BattleShipGameException {
        if (!okToPlaceShipAt(row, column, horizontal, ocean))
            throw new BattleShipGameException("Unable to place ship here");
        for (int i = 0; i < length; i++) {
            if (horizontal)
                ocean.getShipArray()[row][column + i] = this;
            else
                ocean.getShipArray()[row + i][column] = this;
        }
        setBowColumn(column);
        setBowRow(row);
        setHorizontal(horizontal);
    }

    /**
     * Method to fire at passed coordinates
     *
     * @param row    - row to fire at
     * @param column - column to fire at
     * @return true if there is a hit
     * @throws BattleShipGameException - appears if user has previously hit this place
     */
    public boolean shootAt(int row, int column) throws BattleShipGameException {
        for (int i = 0; i < length; i++) {
            if (horizontal && row == bowRow && column == (bowColumn + i)) {
                if (hit[i]) throw new BattleShipGameException("This place has been hit already");
                hit[i] = true;
                return true;
            }
            if (!horizontal && row == (bowRow + i) && column == bowColumn) {
                if (hit[i]) throw new BattleShipGameException("This place has been hit already");
                hit[i] = true;
                return true;
            }
        }
        return false;
    }

    /**
     * Check if the ship is sunk
     *
     * @return true if every part of ship has been hit
     */
    public boolean isSunk() {
        for (boolean part : hit)
            if (!part)
                return false;
        return true;
    }

    public boolean isHit(int row, int column){
        for (int i = 0; i < length; i++) {
            if (horizontal && row == bowRow && column == (bowColumn + i)) {
                return hit[i];
            }
            if (!horizontal && row == (bowRow + i) && column == bowColumn) {
                return hit[i];
            }
        }
        return false;
    }

    public void sank(Ocean ocean) {
        if (horizontal) {
            for (int i = -1; i < length + 1; i++) {
                try {
                    ocean.ships[bowRow + 1][bowColumn + i].shootAt(ocean.ships[bowRow + 1][bowColumn + i].bowRow, ocean.ships[bowRow + 1][bowColumn + i].bowColumn);
                } catch (BattleShipGameException | IndexOutOfBoundsException ignored) { }

                try {
                    ocean.ships[bowRow - 1][bowColumn + i].shootAt(ocean.ships[bowRow + 1][bowColumn + i].bowRow, ocean.ships[bowRow + 1][bowColumn + i].bowColumn);
                } catch (BattleShipGameException | IndexOutOfBoundsException ignored) { }
            }

            try {
                ocean.ships[bowRow][bowColumn + length].shootAt(ocean.ships[bowRow][bowColumn + length].bowRow, ocean.ships[bowRow][bowColumn + length].bowColumn);
            }catch (BattleShipGameException | IndexOutOfBoundsException ignored) { }

            try {
            ocean.ships[bowRow][bowColumn - 1].shootAt(ocean.ships[bowRow][bowColumn - 1].bowRow, ocean.ships[bowRow][bowColumn - 1].bowColumn);
            }catch (BattleShipGameException | IndexOutOfBoundsException ignored) { }
        }
        else{
//            for (int i = -1; i < length + 1; i++) {
//                try {
//                    ocean.ships[bowRow + i][bowColumn + 1].shootAt(ocean.ships[bowRow + i][bowColumn + 1].bowRow, ocean.ships[bowRow + i][bowColumn + 1].bowColumn);
//                    ocean.ships[bowRow + i][bowColumn - 1].shootAt(ocean.ships[bowRow + i][bowColumn - 1].bowRow, ocean.ships[bowRow + i][bowColumn - 1].bowColumn);
//                } catch (BattleShipGameException | IndexOutOfBoundsException e) {
//                }
//            }
//            try {
//                ocean.ships[bowRow + length][bowColumn].shootAt(ocean.ships[bowRow + length][bowColumn].bowRow, ocean.ships[bowRow + length][bowColumn].bowColumn);
//                ocean.ships[bowRow - 1][bowColumn].shootAt(ocean.ships[bowRow - 1][bowColumn].bowRow, ocean.ships[bowRow - 1][bowColumn].bowColumn);
//            }catch (BattleShipGameException | IndexOutOfBoundsException e) {
//            }


            for (int i = -1; i < length + 1; i++) {
                try {
                    ocean.ships[bowRow + i][bowColumn + 1].shootAt(ocean.ships[bowRow + i][bowColumn + 1].bowRow, ocean.ships[bowRow + i][bowColumn + 1].bowColumn);
                } catch (BattleShipGameException | IndexOutOfBoundsException ignored) {
                }

                try {
                    ocean.ships[bowRow + i][bowColumn - 1].shootAt(ocean.ships[bowRow + i][bowColumn - 1].bowRow, ocean.ships[bowRow + i][bowColumn - 1].bowColumn);
                } catch (BattleShipGameException | IndexOutOfBoundsException ignored) {
                }
            }
            try {
                ocean.ships[bowRow + length][bowColumn].shootAt(ocean.ships[bowRow + length][bowColumn].bowRow, ocean.ships[bowRow + length][bowColumn].bowColumn);
            }catch (BattleShipGameException | IndexOutOfBoundsException ignored) {
            }

            try {
                ocean.ships[bowRow - 1][bowColumn].shootAt(ocean.ships[bowRow - 1][bowColumn].bowRow, ocean.ships[bowRow - 1][bowColumn].bowColumn);
            }catch (BattleShipGameException | IndexOutOfBoundsException ignored) {
            }
        }

    }

    /**
     * Used to display the status of the ship
     * s - if the part has been hit
     * X - if the ship has been destroyed
     * . - if this part is unbroken
     *
     * @param row    - row of the ship part
     * @param column - column of the ship part
     * @return displays the status of the ship
     */
    public String toString(int row, int column) {
        if (isSunk())
            return "\033[1;91m" + "X";
        for (int i = 0; i < hit.length; i++) {
            if ((row == bowRow && column == (bowColumn + i)) ||
                    (row == (bowRow + i) && column == bowColumn)) {
                if (hit[i]) return "\033[1;93m" + "s";
                else return "\033[1;94m" + ".";
            }
        }
        return "?";
    }
}
