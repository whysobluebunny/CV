public class Cruiser extends Ship {
    /**
     * Constructor - sets ship's length to 3
     */
    public Cruiser(){
        length = 3;
        hit = new boolean[length];
    }

    @Override
    public String getShipType() {
        return "Cruiser";
    }
}
