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
                    user = new User(dataReader[0].ToString(), dataReader[1].ToString(), dataReader[2].ToString(), dataReader[3].ToString());
                    lista.Add(user);
                }
                dataReader.Close();
            }
            catch (SystemException ex)
            {
               
            }

            finally
            {
                connection.Close();
            }
        }
        return lista;
    }
}