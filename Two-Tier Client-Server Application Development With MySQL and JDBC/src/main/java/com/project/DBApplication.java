// username: root \ client
// password: 1q2w3e4r5t6y \ 1q2w3e4r

package com.project;

import javafx.application.Application;
import javafx.event.EventHandler;
import javafx.fxml.FXMLLoader;
import javafx.scene.Scene;
import javafx.stage.Stage;
import javafx.stage.WindowEvent;

import java.io.IOException;

public class DBApplication extends Application {
    @Override
    public void start(Stage stage) throws IOException {
        FXMLLoader fxmlLoader = new FXMLLoader(DBApplication.class.getResource("hello-view.fxml"));
        Scene scene = new Scene(fxmlLoader.load());
        stage.setTitle("Project Three: Two-Tier Client-Server Application Development With MySQL and JDBC");
        stage.setScene(scene);
        stage.setResizable(false);
        DBAppController appController = fxmlLoader.getController();
        stage.setOnShowing(new EventHandler<WindowEvent>() {
            @Override
            public void handle(WindowEvent event) {
                appController.onApplicationLoaded();
            }
        });
        stage.show();
    }

    public static void main(String[] args) {
        launch();
    }
}