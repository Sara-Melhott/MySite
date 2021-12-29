using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyLibrary;

public partial class Registration : System.Web.UI.Page
{
    SqlConnection sConn;
    protected void Page_Load(object sender, EventArgs e)
    {
        Session["Aut"] = false;
    }
    /// <summary>
    /// Кнопка назад
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void CancelButton_Click(object sender, EventArgs e)
    {
        Response.Redirect("Authorization.aspx");
    }
    /// <summary>
    /// Кнопка зарегистрироваться
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void RegButton_Click(object sender, EventArgs e)
    {
        string name = NameTextBox.Text;
        string login = LoginTextBox.Text;
        string password = PasswordTextBox.Text;
        string password2 = PasswordTextBox2.Text;
        int id_player;
        Player player;
        if (!Page.IsValid)
            return;
        if (password != password2)
        {
            ErrorPassword.Text = "Пароли не совпадают!";
            return;
        }

        //Запись в бд
        string connectionString = ConfigurationManager.ConnectionStrings["GameContext"].ConnectionString;
        //Подключение к БД
        using (sConn = new SqlConnection(connectionString))
        {
            sConn.Open();
            string sqlExpression = "INSERT INTO Players (Name, Login, Password) VALUES ('" + name + "', '"+ login 
                +"', '"+ password +"')";
            SqlCommand command = new SqlCommand(sqlExpression, sConn);
            int number = command.ExecuteNonQuery();

            command = new SqlCommand("SELECT Id FROM Players WHERE Login = '" + login + "' AND " +
                "Password = '" + password + "'", sConn);
            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                reader.Read();
                //id_player = (int)reader.GetValue(0);
                //Session["id_player"] = id_player;
                Session["Aut"] = true;
                player = new Player((int)reader.GetValue(0), (string)reader.GetValue(1), (string)reader.GetValue(2), (string)reader.GetValue(3));
                Session["Player"] = player;
                Response.Redirect("Default.aspx");
            }
            sConn.Close();
        }
        
    }
}