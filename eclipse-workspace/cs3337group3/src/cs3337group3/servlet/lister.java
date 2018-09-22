package cs3337group3.servlet;

import java.io.BufferedReader;
import java.io.IOException;
import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.PreparedStatement;
import java.sql.SQLException;

import javax.servlet.ServletConfig;
import javax.servlet.ServletException;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

import org.json.simple.JSONObject;
import org.json.simple.parser.JSONParser;
import org.json.simple.parser.ParseException;


@WebServlet("/lister")
public class lister extends HttpServlet {
	private static final long serialVersionUID = 1L;
       
    public lister() {
        super();
        // TODO Auto-generated constructor stub
    }

	public void init(ServletConfig config) throws ServletException {
		super.init( config );
		try
        {
            Class.forName( "com.mysql.jdbc.Driver" );
        }
        catch( ClassNotFoundException e )
        {
            throw new ServletException( e );
        }
	}

	
	protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
		
		try
        {
            String url = "jdbc:mysql://localhost/cs3337group3";
            String username = "cs3337";
            String password = "csula2017";
            
            String testLocation = "John", testLevel = "Do", testEmail = "John.Doe@nowhere.com", testPass = "password";
            String testComment = "Honda";
           
            
            Connection c = DriverManager
                    .getConnection( url, username, password );
           
            //Do I Change Users Here or in Database?
            PreparedStatement insertUsers = c.prepareStatement(
                    "insert into Users(FName, LName, Email, Pass, Comment)  values(?,?,?,?,?)");
            
            insertUsers.setString(1, testLocation);
            insertUsers.setString(2, testLevel);
            insertUsers.setString(3, testEmail);
            insertUsers.setString(4, testPass);
            insertUsers.setString(5, testComment);
            
            insertUsers.executeUpdate();
            
            
            //Do I need this select ID from users code?
            /*PreparedStatement insertCars = c.prepareStatement(
            		"insert into Users_Cars(User_ID, Make, Model, Color, License_Plate, Plate_State) "
            		           + "values((select ID from Users where Email = ?), ?, ?, ?, ?, ?)");*/
            		           
           
        }
        catch( SQLException e )
        {
            throw new ServletException( e );
        }
	}

	
	protected void doPost(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
		
JSONParser parser = new JSONParser();
        
        String url = "jdbc:mysql://localhost/cs3337group3";
        String username = "cs3337";
        String password = "csula2017";
        
        String Location = "", Level = "", Email = "", Pass = "";
        String Comment = "";
        
        try {
			JSONObject data = (JSONObject) parser.parse(request.getReader());
			//Location = (String) data.get("location");
			//Level = (String) data.get("level");
			//Email = (String) data.get("email");
			//Pass = (String) data.get("password");
			Comment = (String) data.get("comment");
			
		} catch (ParseException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
	    try {
	        Connection c = DriverManager
	                .getConnection( url, username, password );
	       //Where do I change this here or database?
	        PreparedStatement insertUsers = c.prepareStatement(
	                "insert into Users(FName, LName, Comment, Email, Pass)  values(?,?,?,?,?)");
	        
	        insertUsers.setString(1, Location);
	        insertUsers.setString(2, Level);
	        //insertUsers.setString(3, Email);
	        //insertUsers.setString(4, Pass);
	        insertUsers.setString(3, Comment);
	
	        insertUsers.executeUpdate();
	        
	    }
	    catch( SQLException e )
	    {
	    	throw new ServletException( e );
	    }
	}

}
