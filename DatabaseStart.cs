using System;
using System.Data.SqlClient; // https://docs.microsoft.com/en-us/dotnet/api/system.data.sqlclient?view=dotnet-plat-ext-6.0
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using MySql.Data;


public class DatabaseStart
{
    static string username = "mk750"; // to be adjusted later to take from inputFieldUsername
    static string password = "wa*rexa"; // to be adjusted later to take from inputFieldPassword

    //mysql -h dragon.kent.ac.uk -u mk750 -p

    static void Main()
    {
        //EstablishLogin(username, password);
        EstablishLogin2();
    }

    public static Boolean hasNext(MySqlDataReader readerInput, int i)
    {
        try
        {
            readerInput.Read();
            readerInput.GetString(i++);
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    public static void EstablishLogin2()
    {
        string connectionString = "SERVER=*****;DATABASE=*****;User ID=*****;Password=*****";
        MySqlConnection connection = new MySqlConnection();
        try
        {
            
            Console.WriteLine("Attempting to establish connection.");
            connection.ConnectionString = connectionString;
            connection.Open();
            Console.WriteLine("Connection established.");

            //READ TABLE PlayerCredentials
            var cmd = new MySqlCommand("SELECT * FROM PlayerCredentials", connection);
            var countRows = new MySqlCommand("SELECT COUNT(*) FROM PlayerCredentials;");
            
            //Console.WriteLine(countRows.ExecuteNonQuery());
            MySqlDataReader Reader;
            Reader = cmd.ExecuteReader();
            int i = 0;
            Console.WriteLine("");
            Console.WriteLine("Print Player Credentials");
            if (Reader.HasRows)
            {
                while (Reader.Read())
                {
                    while(hasNext(Reader, i) == true)
                    {
                        Console.Write("|" + Reader.GetString(i));
                        i++;
                    }
                    
                    Console.WriteLine("|");
                }
            }
            Reader.Close();
            Console.WriteLine("");
            //---------------------------
            //CREATE NEW ACCOUNT
            //cmd = new MySqlCommand("INSERT INTO PlayerCredentials (PlayerNo, Username, Password) VALUES (2, '****', '***');", connection);
            //cmd.ExecuteNonQuery();
            //----------

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);            
        }
        connection.Close();
        Console.WriteLine("Connection closed.");
    }

}