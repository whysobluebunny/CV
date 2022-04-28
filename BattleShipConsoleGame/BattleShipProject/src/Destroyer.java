public class Destroyer extends Ship{
    /**
     * Constructor - sets ship's length to 2
     */
    public Destroyer(){
        length = 2;
        hit = new boolean[length];
    }

    @Override
    public String getShipType() {
        return "Destroyer";
    }
}
