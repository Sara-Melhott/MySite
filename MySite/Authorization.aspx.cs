using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Configuration;

public partial class Authorization : System.Web.UI.Page
{
    string dbName = "DataBase.db";
    SqlConnection sConn;
    SqlDataAdapter sAdapter;
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void authorizationButton_Click(object sender, EventArgs e)
    {
        
    }
    /// <summary>
    /// Ауэнтотификация
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
    {
        string login = Login1.UserName;
        string password = Login1.Password;
        int id_player;
        string connectionString = ConfigurationManager.ConnectionStrings["GameContext"].ConnectionString;
        //Подключение к БД
        using (sConn = new SqlConnection(connectionString)) {
            sConn.Open();
            SqlCommand command = new SqlCommand("SELECT * FROM Players WHERE Login = '" + login + "' AND " +
                "Password = '" + password + "'", sConn);
            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                reader.Read();
                id_player = (int)reader.GetValue(0);
                Response.Redirect("Default.aspx?value=" + id_player);
            }
                
            sConn.Close();
        }
    }
    /// <summary>
    /// Кнопка перехода к регистрации 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void RegButton_Click(object sender, EventArgs e)
    {
        Response.Redirect("Registration.aspx");
    }
}