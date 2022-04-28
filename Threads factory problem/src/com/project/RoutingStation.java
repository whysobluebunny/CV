package com.project;

import java.util.Random;

public class RoutingStation implements Runnable {
    protected static Random rand = new Random();
    protected final int stationNum;
    protected final int workload;
    protected Conveyor inputConveyor;
    protected Conveyor outputConveyor;
    protected int workLoadCounter;

    public RoutingStation(int stationNum, int workload, Conveyor inconveyor, Conveyor outconveyor) {
        this.stationNum = stationNum;
        this.workload = workload;
        this.inputConveyor = inconveyor;
        this.outputConveyor = outconveyor;
        workLoadCounter = workload;
        this.waitTillNextTry();
    }

    public void waitTillNextTry() {
        try {
            Thread.sleep(rand.nextInt(500));
        } catch (InterruptedException e) {
            e.printStackTrace();
        }
    }

    public void movePackages() {
        System.out.println("Routing Station " + stationNum + ": CURRENTLY HARD AT WORK MOVING PACKAGES");
        workLoadCounter--;
        System.out.println("Routing Station " + stationNum + ": has " + workLoadCounter + " package groups left to move.");
        waitTillNextTry();

        if (workLoadCounter == 0) {
            System.out.println("\n* * Station " + stationNum + ": Workload successfully completed." +
                    " * * Station " + stationNum + " releasing locks and going offline * * ");
        }
    }

    @Override
    public void run() {
        boolean holdsBothLocks = false;
        System.out.println("Routing Station " + stationNum + ": Input conveyor set to conveyor number C" + inputConveyor.getConveyorNum());
        System.out.println("Routing Station " + stationNum + ": Output conveyor set to conveyor number C" + outputConveyor.getConveyorNum());
        System.out.println("Routing Station " + stationNum + ": Workload set. Station "
                + stationNum + " has a total of " + workload + " package groups to move.");

        for (int i = 0; i < workload; i++) {
            System.out.println();
            holdsBothLocks = false;
            while (!holdsBothLocks) {
                if (inputConveyor.lockConveyor()) {
                    System.out.println("Routing Station " + stationNum + ": holds lock on input conveyor C" + inputConveyor.getConveyorNum());
                    if (outputConveyor.lockConveyor()) {
                        holdsBothLocks = true;
                        System.out.println("Routing Station " + stationNum + ": holds lock on output conveyor C" + outputConveyor.getConveyorNum());

                        movePackages();

                        inputConveyor.unlockConveyor();
                        System.out.println("Routing Station " + stationNum + ": unlocks/releases input conveyor C" + inputConveyor.getConveyorNum());
                        outputConveyor.unlockConveyor();
                        System.out.println("Routing Station " + stationNum + ": unlocks/releases output conveyor C" + outputConveyor.getConveyorNum());
                    } else {
                        System.out.println("Routing Station " + stationNum + ": unable to lock output conveyor C" + outputConveyor.getConveyorNum()
                                + ", unlocks input conveyor C" + inputConveyor.getConveyorNum());
                        inputConveyor.unlockConveyor();
                        waitTillNextTry();
                    }
                }
                waitTillNextTry();
            }
        }
        System.out.println();
    }
}
