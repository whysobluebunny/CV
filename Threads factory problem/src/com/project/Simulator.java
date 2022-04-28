package com.project;

import java.io.File;
import java.io.FileNotFoundException;
import java.util.ArrayList;
import java.util.Scanner;
import java.util.concurrent.ExecutorService;
import java.util.concurrent.Executors;
import java.util.concurrent.TimeUnit;

public class Simulator {
    static final int MAX = 10;

    private static ArrayList<Integer> getConfig(String path) throws FileNotFoundException {
        Scanner file = new Scanner(new File(path));
        ArrayList<Integer> config = new ArrayList<>();
        while (file.hasNext()) {
            int number = file.nextInt();
            config.add(number);
        }
        file.close();

        return config;
    }

    private static void printStationInfo(ArrayList<Integer> config) {
        int stationNum = config.get(0);
        for (int i = 0; i < stationNum; i++)
            System.out.println("Routing Station " + i + " Has Total Workload Of " + config.get(i + 1));
    }

    private static void executeSimulation(ArrayList<Integer> config, ExecutorService simulation) {
        int stationNum = config.get(0);
        ArrayList<Conveyor> conveyors = new ArrayList<>();
        for (int i = 0; i < stationNum; i++)
            conveyors.add(new Conveyor(i));


        for (int i = 0; i < stationNum; i++) {
            try {
                simulation.execute(new RoutingStation(i, config.get(i + 1), conveyors.get(i), conveyors.get((i - 1) < 0 ? conveyors.size() - 1 : i - 1)));
            } catch (Exception e) {
                e.printStackTrace();
            }
        }
    }

    public static void main(String[] args) {
        try {
            // is used to redirect console output to file
            //System.setOut(new PrintStream(new FileOutputStream("output.txt")));
            ExecutorService simulation = Executors.newFixedThreadPool(MAX);
            System.out.println("* PACKAGE MANAGEMENT FACILITY SIMULATION BEGINS *\n");

            ArrayList<Integer> config = getConfig("config.txt");
            printStationInfo(config);
            executeSimulation(config, simulation);

            simulation.shutdown();
            simulation.awaitTermination(1, TimeUnit.MINUTES);

            System.out.println("\n ********* ALL WORKLOADS COMPLETE *** PACKAGE MANAGEMENT FACILITY SIMULATION ENDS ************");
        } catch (FileNotFoundException | InterruptedException e) {
            e.printStackTrace();
        }
    }
}
