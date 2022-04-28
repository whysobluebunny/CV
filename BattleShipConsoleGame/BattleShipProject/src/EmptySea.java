public class EmptySea extends Ship {
    public EmptySea() {
        length = 1;
        hit = new boolean[length];
    }

    @Override
    public String getShipType() {
        return "empty sea";
    }

    @Override
    public boolean okToPlaceShipAt(int row, int column, boolean horizontal, Ocean ocean) {
        return !ocean.isOccupied(row, column);
    }

    @Override
    public void placeShipAt(int row, int column, boolean horizontal, Ocean ocean) {
        ocean.getShipArray()[row][column] = this;
    }

    @Override
    public boolean shootAt(int row, int column) {
        hit[0] = true;
        return false;
    }

    @Override
    public boolean isSunk() {
        return false;
    }

    protected boolean[] hit;

    @Override
    public String toString(int row, int column) {
        if (hit[0]) return "\033[1;94m" + "o";
        return "\033[1;94m" + ".";
    }
}
