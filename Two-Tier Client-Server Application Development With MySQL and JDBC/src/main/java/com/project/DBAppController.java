package com.project;

import javafx.beans.property.ReadOnlyStringWrapper;
import javafx.fxml.FXML;
import javafx.scene.control.*;

import java.sql.SQLException;
import java.util.ArrayList;
import java.util.List;

public class DBAppController {
    private ResultSetTableModel rstable = null;
    @FXML
    private TextField username;
    @FXML
    private TextField password;
    @FXML
    private TableView tableView;
    @FXML
    private ChoiceBox propertiesChoiceBox;
    @FXML
    private Label statusLabel;
    @FXML
    private TextArea queryArea;
    @FXML
    private Button executeButton;

    @FXML
    protected void onApplicationLoaded() {
        propertiesChoiceBox.getItems().add("root.properties");
        propertiesChoiceBox.getItems().add("client.properties");
        executeButton.setDisable(true);

    }

    @FXML
    private void onClearTableButtonClicked() {
        tableView.getItems().clear();
        tableView.getColumns().clear();
    }

    @FXML
    private void onClearQButtonClicked() {
        queryArea.clear();
    }

    @FXML
    private void onExecuteButtonClick() {
        onClearTableButtonClicked();
        try {
            if (queryArea.getText().contains("select") || queryArea.getText().contains("SELECT"))
                rstable.setQuery(queryArea.getText());
            else {
                rstable.setUpdate(queryArea.getText());
                showMessage("Success", "Table updated successfully", Alert.AlertType.INFORMATION);
                return;
            }
        } catch (SQLException | IllegalStateException e) {
            showMessage("Wrong query", "This query cannot be proccessed: " + e.getMessage(), Alert.AlertType.ERROR);
            e.printStackTrace();
            return;
        }

        for (int i = tableView.getColumns().size(); i < rstable.getColumnCount(); i++) {
            TableColumn<List<String>, String> col = new TableColumn<>(rstable.getColumnName(i));
            col.setMinWidth(80);
            final int colIndex = i;
            col.setCellValueFactory(data -> {
                List<String> rowValues = data.getValue();
                String cellValue;
                if (colIndex < rowValues.size()) {
                    cellValue = rowValues.get(colIndex);
                } else {
                    cellValue = "";
                }
                return new ReadOnlyStringWrapper(cellValue);
            });
            tableView.getColumns().add(col);
        }

        for (int i = 0; i < rstable.getRowCount(); i++) {
            List<String> rowList = new ArrayList<>();
            for (int j = 0; j < rstable.getColumnCount(); j++) {
                rowList.add(rstable.getValueAt(i, j).toString());
            }
            tableView.getItems().add(rowList);
        }
    }

    // As you can see I'm trying to handle the SQL Exception, but it just shuts down the app
    @FXML
    protected void onConnectButtonClick() throws SQLException, ClassNotFoundException {
        executeButton.setDisable(true);
        try {
            rstable = new ResultSetTableModel(propertiesChoiceBox.getSelectionModel().getSelectedItem().toString(), username.getText(), password.getText());
        } catch (SQLException e) {
            showMessage("Data Base connection error", "Cannot connect to Data Base: " + e.getMessage(), Alert.AlertType.ERROR);
            rstable = null;
            return;
        }
        statusLabel.setText("Successfully connected to " + rstable.getDataSource().getUrl());
        executeButton.setDisable(false);
    }

    /**
     * Shows message box
     *
     * @param title     title of the messagebox
     * @param content   content of the messagebox
     * @param alertType type of the messagebox
     */
    private void showMessage(String title, String content, Alert.AlertType alertType) {
        Alert alert = new Alert(alertType);
        alert.setTitle(title);
        alert.setContentText(content);
        alert.showAndWait().ifPresent(rs -> {
            if (rs == ButtonType.OK) {
                System.out.println("Pressed OK.");
            }
        });
    }
}