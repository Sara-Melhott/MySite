using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Configuration;
using MyLibrary;

public partial class Authorization : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Session["Aut"] = false;
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
        Player player;
        string connectionString = ConfigurationManager.ConnectionStrings["GameContext"].ConnectionString;
        //Подключение к БД
        using (SqlConnection sConn = new SqlConnection(connectionString)) {
            sConn.Open();
            SqlCommand command = new SqlCommand("SELECT * FROM Players WHERE Login = '" + login + "' AND " +
                "Password = '" + password + "'", sConn);
            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                reader.Read();
                id_player = (int)reader.GetValue(0);
                //Session["id_player"] = id_player;
                //Session["Name"] = reader.GetValue(1);
                Session["Aut"] = true;
                player = new Player((int)reader.GetValue(0), (string)reader.GetValue(1), (string)reader.GetValue(2), (string)reader.GetValue(3));
                Session["Player"] = player;
                Response.Redirect("Default.aspx");
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