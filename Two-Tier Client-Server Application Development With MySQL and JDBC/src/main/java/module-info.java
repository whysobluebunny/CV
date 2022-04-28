module com.example.demo {
    requires javafx.controls;
    requires javafx.fxml;

    requires java.naming;
    requires org.controlsfx.controls;
    requires com.dlsc.formsfx;
    requires org.kordamp.ikonli.javafx;
    requires java.sql;
    requires java.desktop;
    requires mysql.connector.java;
    requires lombok;

    opens com.project to javafx.fxml;
    exports com.project;
}