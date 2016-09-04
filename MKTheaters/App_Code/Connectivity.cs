using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

/// <summary>
/// Summary description for SqlConnection
/// </summary>
public static class Connectivity
{
    /// <summary>
    /// connectionString saved in App.config, which is used for establishing a connection with Database
    /// </summary>
    private static readonly string connectionString = ConfigurationManager.ConnectionStrings["Test"].ConnectionString;

    static public List<User> getUsers()
    {
        List<User> lista = new List<User>();
        SqlConnection connection = new SqlConnection(connectionString);
        SqlCommand command = new SqlCommand("SELECT * FROM Users", connection);
        {
            try
            {
                User user = null;
                connection.Open();
                SqlDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    user = new User(dataReader[0].ToString(), dataReader[1].ToString(), dataReader[2].ToString(), dataReader[3].ToString(), dataReader[4].ToString(), dataReader[5].ToString());
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

    public static HashSet<string> getUsernames()
    {
        HashSet<string> set = new HashSet<string>();
        SqlConnection connection = new SqlConnection(connectionString);
        SqlCommand command = new SqlCommand("SELECT * FROM Users", connection);
        {
            try
            {
                connection.Open();
                SqlDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    set.Add(dataReader[2].ToString());
                }
                dataReader.Close();
            }
            finally
            {
                connection.Close();
            }
        }
        return set;
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
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            try
            {
                connection.Open();
                /// <summary>
                /// SqlCommand object contains SqlConnection object and queryString (INSERT command with parameters) 
                /// </summary>
                SqlCommand commandInsert = new SqlCommand("INSERT INTO Users(Ime,Prezime,Username,Password,Email,Admin) VALUES(@ime,@prezime,@username,@password,@email,@admin)", connection);
                commandInsert.Parameters.AddWithValue("@ime", user.Ime);
                commandInsert.Parameters.AddWithValue("@prezime", user.Prezime);
                commandInsert.Parameters.AddWithValue("@email", user.Email);
                commandInsert.Parameters.AddWithValue("@username", user.Username);
                commandInsert.Parameters.AddWithValue("@password", user.Password.GetHashCode().ToString());
                commandInsert.Parameters.AddWithValue("@admin", "False");
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
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            try
            {
                connection.Open();
                User user = null;
                /// <summary>
                /// queryString = Search in table Users for all records whose username is equal with the username given as a parameter
                /// </summary>
                SqlCommand command = new SqlCommand("SELECT * FROM Users WHERE Username='" + username + "'", connection);
                SqlDataReader dataReader = command.ExecuteReader();
                if (dataReader.Read() == false) user = null;
                else
                {
                    user = new User(dataReader[0].ToString(), dataReader[1].ToString(), dataReader[2].ToString(), dataReader[3].ToString(), dataReader[4].ToString(), dataReader[5].ToString());
                }
                return user;

            }
            catch (Exception)
            {
                return null;
            }
        }
    }

    public static void updateUserInformation(User user)
    {
        SqlConnection connection = new SqlConnection(connectionString);
        string commandString = "UPDATE Users SET Ime=@ime, Prezime=@prezime, Email=@email, Password=@password WHERE Username=@username";
        SqlCommand command = new SqlCommand(commandString, connection);
        command.Parameters.AddWithValue("@username", user.Username);
        command.Parameters.AddWithValue("@ime", user.Ime);
        command.Parameters.AddWithValue("@prezime", user.Prezime);
        command.Parameters.AddWithValue("@email", user.Email);
        command.Parameters.AddWithValue("@password", user.Password);
        try
        {
            connection.Open();
            command.ExecuteNonQuery();
        }
        finally
        {
            connection.Close();
        }
    }

}