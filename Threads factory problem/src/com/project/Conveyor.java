package com.project;

import java.util.concurrent.locks.Lock;
import java.util.concurrent.locks.ReentrantLock;

public class Conveyor {
    private final int conveyorNum;

    private Lock theLock = new ReentrantLock();

    public Conveyor(int conveyorNum) {
        this.conveyorNum = conveyorNum;
    }

    public int getConveyorNum() {
        return conveyorNum;
    }

    public boolean lockConveyor() {
        return theLock.tryLock();
    }

    public void unlockConveyor() {
        theLock.unlock();
    }
}
