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

@WebServlet(name = "SQLQueryServlet", urlPatterns = "/SQLQueryServlet")
public class SQLQueryServlet extends HttpServlet {
    private Statement statement;

    public SQLQueryServlet() {
    }

    private String update(String command) throws SQLException {
        String result;
        result = "<div> The statement is successful.</div><div>" + this.statement.executeUpdate(command) + " rows changed</div>";
        if (command.contains("00")) {
            int incrementBy5 = this.statement.executeUpdate("update suppliers set status = status + 5 where snum in ( select distinct snum from shipments)");
            result = result + "<div>Business Logic Detected! - Updating Supplier Status</div>";
            result = result + "<div>Business Logic updated " + incrementBy5 + " supplier status marks</div>";
        }

        return result;
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

    public void init(ServletConfig config) throws ServletException {
        super.init(config);

        try {
            Class.forName("com.mysql.jdbc.Driver");
            Connection connection = DriverManager.getConnection("jdbc:mysql://localhost:3306/project4", "root", "1q2w3e4r5t6y");
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
                result = this.update(command);
            } catch (SQLException e) {
                result = "<span>" + e.getMessage() + "</span>";
                e.printStackTrace();
            }
        }

        HttpSession session = request.getSession();
        session.setAttribute("result", result);
        session.setAttribute("command", command);
        RequestDispatcher dispatcher = this.getServletContext().getRequestDispatcher("/admin.jsp");
        dispatcher.forward(request, response);
    }

    protected void doPost(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
        this.doGet(request, response);
    }
}
