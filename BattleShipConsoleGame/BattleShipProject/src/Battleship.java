public class Battleship extends Ship {
    /**
     * Constructor - sets ship's length to 4
     */
    public Battleship() {
        length = 4;
        hit = new boolean[length];
    }

    @Override
    public String getShipType() {
        return "Battleship";
    }
}
