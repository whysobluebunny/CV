public class Main {
    public static void main(String[] args) {
        try {
//            args = new String[3];
//            args[0] = "6";
//            args[1] = "5";
//            args[2] = "97";
            if (args.length != 3)
                throw new IllegalArgumentException("There must be 3 parameters");

            int N = Integer.parseInt(args[0]);
            int K = Integer.parseInt(args[1]);
            int M = Integer.parseInt(args[2]);

            DiceGame diceGame = new DiceGame(N, K, M);
            diceGame.start();
        } catch (Exception ex) {
            System.out.println(ex.getMessage());
        }
    }
}
