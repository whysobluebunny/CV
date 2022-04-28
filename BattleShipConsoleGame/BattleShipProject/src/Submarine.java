public class Submarine extends Ship {
    /**
     * Constructor - sets ship's length to 1
     */
    public Submarine(){
        length = 1;
        hit = new boolean[length];
    }

    @Override
    public String getShipType() {
        return "Submarine";
    }
}
