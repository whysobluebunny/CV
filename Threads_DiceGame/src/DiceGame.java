import java.util.ArrayList;

public class DiceGame implements Runnable {
    private static final String[] NAMES = {"Jonathan Joestar", "Joseph Joestar", "Jotaro Kujo", "Josuke Higashikata", "Giorno Giovanna", "Jolyne Joestar"};
    private ArrayList<Player> players = new ArrayList<>();
    private final int playerNum;
    private final int winsNum;
    private int winnerScore;
    private int currentMaxScore;

    public Player currentPlayer;
    private Player currentTurnLeader;
    private Player overallLeader;
    private Hand playersHand;

    /**
     * These were made to be able to switch between threads properly
     */
    public final Object roundMonitor = new Object();
    public final Object playerTurnMonitor = new Object();

    private boolean roundEnded;
    public boolean playerTurnEnded;
    private boolean ongoingGame;
    public boolean maximumAchieved;

    public DiceGame(int playerNum, int diceNum, int winsNum) {
        if (!areLegalStartingParameters(playerNum, diceNum, winsNum))
            throw new IllegalArgumentException("Invalid parameters. " +
                    "Restrictions are: \n 2 <= N <= 6\n" +
                    "2 <= K <= 5\n" +
                    "1 <= M <= 100\n");

        this.playerNum = playerNum;
        this.winsNum = winsNum;
        playersHand = new Hand(diceNum);
        for (int i = 0; i < playerNum; i++)
            players.add(new Player(NAMES[i], playersHand, this));
    }

    public boolean isOngoingGame() {
        return ongoingGame;
    }

    public void start() {
        if (!ongoingGame) {
            ongoingGame = true;
            roundEnded = true;
            (new Thread(this)).start();

            for (Player player : players)
                (new Thread(player)).start();
        }
    }

    private boolean areLegalStartingParameters(int N, int K, int M) {
        return N >= 2 & N <= 6
                & K >= 2 & K <= 5
                & M >= 1 & M <= 100;
    }

    private void reset() {
        currentMaxScore = 0;
        maximumAchieved = false;
        roundEnded = false;
        currentTurnLeader = null;
    }

    private void checkRoundLeader() {
        if (currentPlayer.currentScore > currentMaxScore) {
            currentTurnLeader = currentPlayer;
            currentMaxScore = currentPlayer.currentScore;
        }
    }

    private void checkOverallLeader() {
        if (currentTurnLeader.totalWins >= winnerScore) {
            overallLeader = currentTurnLeader;
            winnerScore = currentTurnLeader.totalWins;
        }
    }

    private void printSummary() {
        System.out.println("\nThe Game has ended!");
        System.out.println(String.format("%s is a winner! Total wins: %s", overallLeader.name, overallLeader.totalWins));

        players.sort((a, b) -> Integer.compare(b.totalWins, a.totalWins));
        System.out.println("\nScore table:");
        for (Player player : players)
            System.out.println(String.format("%s. Total wins: %s", player.name, player.totalWins));
    }

    private void printCurrentTurn() {
        System.out.println(String.format("%s scored: %d, Total wins: %s", currentPlayer.name, currentPlayer.currentScore, currentPlayer.totalWins));
    }

    private void printRoundSummary() {
        System.out.println(String.format("%s is a leader! Total wins: %s. Round score: %d \n\n", currentTurnLeader.name, currentTurnLeader.totalWins, currentTurnLeader.currentScore));
    }


    /**
     * The concept is:
     * the game requires some flags: if it has ended, if the round has ended
     * so playerTurnMonitor is responsible for players to commit a turn
     * when it is done we refresh all required fields and print result
     * after the player has committed a turn next player does his turn
     * after all of the current round's turns we print a current leader and all the info
     */
    @Override
    public void run() {
        while (ongoingGame) {
            reset();
            int turnNumber = 0;
            while (!roundEnded) {
                synchronized (playerTurnMonitor) {
                    playerTurnEnded = false;
                    while (!playerTurnEnded)
                        try {
                            playerTurnMonitor.wait();
                        } catch (InterruptedException e) {
                            e.printStackTrace();
                        }

                    checkRoundLeader();
                    turnNumber++;
                    if (turnNumber == playerNum) {
                        currentTurnLeader.totalWins++;
                        checkOverallLeader();
                        roundEnded = true;
                        if (overallLeader.totalWins == winsNum) {
                            ongoingGame = false;
                            printSummary();
                        }
                    }
                    if (ongoingGame)
                        printCurrentTurn();
                }
            }
            if (ongoingGame)
                printRoundSummary();
            synchronized (roundMonitor) {
                roundMonitor.notifyAll();
            }
        }
    }
}
