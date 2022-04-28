public class Player implements Runnable {
    String name;
    Hand hand;
    DiceGame game;
    boolean turnPlayed;
    int currentScore;
    int totalWins = 0;

    public Player(String name, Hand hand, DiceGame game) {
        this.name = name;
        this.hand = hand;
        this.game = game;
    }

    /**
     * We skip if the max has been achieved
     * and roll if not
     * SmaRt PlAy oO
     */
    private void playTurn() {
        if (game.maximumAchieved) {
            currentScore = 0;
            return;
        }

        currentScore = hand.roll();

        if (hand.isMax(currentScore))
            game.maximumAchieved = true;
    }

    /**
     * The concept is to not to do anything if we have made a turn
     * to wait for others to make their turns
     */
    @Override
    public void run() {
        System.out.println(this);
        while (game.isOngoingGame()) {
            synchronized (game.roundMonitor) {
                if (turnPlayed) {
                    try {
                        game.roundMonitor.wait();
                    } catch (InterruptedException e) {
                        e.printStackTrace();
                    }
                }
                turnPlayed = false;

                synchronized (game.playerTurnMonitor) {
                    if (!game.playerTurnEnded) {
                        if (!game.isOngoingGame())
                            break;

                        playTurn();

                        game.playerTurnEnded = true;
                        game.currentPlayer = this;

                        turnPlayed = true;

                        game.playerTurnMonitor.notify();
                    }
                }
            }

        }
    }

        @Override
        public String toString ()
        {
            return new StringBuilder("Hello! I'm ").append(name).toString();
        }
    }
