import jakarta.servlet.RequestDispatcher;
import jakarta.servlet.ServletConfig;
import jakarta.servlet.ServletException;
import jakarta.servlet.UnavailableException;
import jakarta.servlet.annotation.WebServlet;
import jakarta.servlet.http.HttpServlet;
import jakarta.servlet.http.HttpServletRequest;
import jakarta.servlet.http.HttpServletResponse;
import jakarta.servlet.http.HttpSession;

import java.io.IOException;
import java.sql.*;

@WebServlet(name = "SQLQueryClientServlet", urlPatterns = "/SQLQueryClientServlet")
public class SQLQueryClientServlet extends HttpServlet {
    private Statement statement;

    public SQLQueryClientServlet() {
    }

    public void init(ServletConfig config) throws ServletException {
        super.init(config);

        try {
            Class.forName("com.mysql.jdbc.Driver");
            Connection connection = DriverManager.getConnection("jdbc:mysql://localhost:3306/project4", "client", "1q2w3e4r");
            this.statement = connection.createStatement();
        } catch (Exception e) {
            e.printStackTrace();
            throw new UnavailableException(e.getMessage());
        }
    }

    protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
        String command = request.getParameter("command");
        String UpperCase = command.toUpperCase();
        String result = null;
        if (UpperCase.contains("SELECT")) {
            try {
                result = this.select(command);
            } catch (SQLException e) {
                result = "<span>" + e.getMessage() + "</span>";
                e.printStackTrace();
            }
        } else {
            try {
                this.statement.executeUpdate(command);
            } catch (SQLException e) {
                result = "<span>" + e.getMessage() + "</span>";
                e.printStackTrace();
            }
        }

        HttpSession session = request.getSession();
        session.setAttribute("result", result);
        session.setAttribute("command", command);
        RequestDispatcher dispatcher = this.getServletContext().getRequestDispatcher("/client.jsp");
        dispatcher.forward(request, response);
    }

    protected void doPost(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
        this.doGet(request, response);
    }

    public String select(String command) throws SQLException {
        ResultSet table = this.statement.executeQuery(command);
        ResultSetMetaData metaData = table.getMetaData();
        String header = "<div style='height: 150px; overflow: auto'><table class='table'>";
        StringBuilder tColumns = new StringBuilder("<thead><tr>");
        StringBuilder tBody = new StringBuilder("<tbody>");
        int columns = metaData.getColumnCount();

        for (int i = 1; i <= columns; ++i)
            tColumns.append("<th scope='col'>").append(metaData.getColumnName(i)).append("</th>");

        tColumns.append("</tr></thead>");


        for (; table.next(); tBody.append("</tr>")) {
            tBody.append("<tr>");
            for (int i = 1; i <= columns; ++i) {
                if (i == 1)
                    tBody.append("<td scope'row'>").append(table.getString(i)).append("</th>");
                else
                    tBody.append("<td>").append(table.getString(i)).append("</th>");
            }
        }
        tBody.append("</tbody>");
        return header + tColumns + tBody + "</table></div>";
    }
}
