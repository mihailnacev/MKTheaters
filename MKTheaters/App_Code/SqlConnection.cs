using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

/// <summary>
/// Summary description for SqlConnection
/// </summary>
public static class SqlConnection
{
    /// <summary>
    /// connectionString saved in App.config, which is used for establishing a connection with Database
    /// </summary>
    private static readonly string connectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;

    static public List<User> getUsers()
    {
        List<User> lista = new List<User>();
        MySqlConnection connection = new MySqlConnection(connectionString);
        MySqlCommand command = new MySqlCommand("SELECT * FROM USERS", connection);
        {
            try
            {
                User user = null;
                connection.Open();
                MySqlDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    user = new User(dataReader[0].ToString(), dataReader[1].ToString(), dataReader[2].ToString(), dataReader[3].ToString(), dataReader[4].ToString());
                    lista.Add(user);
                }
                dataReader.Close();
            }
            finally
            {
                connection.Close();
            }
        }
        return lista;
    }

    public static string hesiranje(string input)
    {
        string final = "";
        for (int i = 0; i < input.Length; i++)
        {
            char c = (char)((int)input[i] + 5);
            final += c;
        }
        return final;
    }
    /// <summary>
    /// SignUp method inserts a new record for each registered user in table Users
    /// </summary>
    static public void SignUp(User user)
    {
        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            try
            {
                connection.Open();
                /// <summary>
                /// SqlCommand object contains SqlConnection object and queryString (INSERT command with parameters) 
                /// </summary>
                MySqlCommand commandInsert = new MySqlCommand("INSERT INTO USERS(Username,Password,Ime,Prezime,Email) VALUES(@username,@password,@ime,@prezime,@email)", connection);
                commandInsert.Parameters.AddWithValue("@username", user.Username);
                commandInsert.Parameters.AddWithValue("@password", user.Password);
                commandInsert.Parameters.AddWithValue("@ime", user.Ime);
                commandInsert.Parameters.AddWithValue("@prezime", user.Prezime);
                commandInsert.Parameters.AddWithValue("@email", user.Email);
                commandInsert.ExecuteNonQuery();
                commandInsert.Parameters.Clear();
            }
            catch (Exception)
            {

            }
            finally
            {
                connection.Close();
            }
        }
    }

    /// <summary>
    /// SignIn method returns the user which is LoggedIn (Description)
    /// </summary>
    static public User SignIn(string username)
    {
        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            try
            {
                connection.Open();
                User user = null;
                /// <summary>
                /// queryString = Search in table Users for all records whose username is equal with the username given as a parameter
                /// </summary>
                MySqlCommand command = new MySqlCommand("SELECT * FROM USERS WHERE Username='" + username + "'", connection);
                MySqlDataReader dataReader = command.ExecuteReader();
                if (dataReader.Read() == false) user = null;
                else
                {
                    user = new User(dataReader[0].ToString(), dataReader[1].ToString(), dataReader[2].ToString(), dataReader[3].ToString(), dataReader[4].ToString());
                }
                return user;

            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}