using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyLibrary;

public partial class ChangeInfoGamer : System.Web.UI.Page
{
    Player player;
    protected void Page_Load(object sender, EventArgs e)
    {
        player = (Player)Session["Player"];
        if (!Page.IsPostBack)
        {
            NameTextBox.Text = player.Name;
            LoginTextBox.Text = player.Login;
            PasswordTextBox.Text = player.Password;
        }
    }

    protected void CustomerInsertButton_Click(object sender, EventArgs e)
    {
        Player changePlayer = new Player();
        changePlayer.Name = NameTextBox.Text.Trim();
        changePlayer.Login = LoginTextBox.Text.Trim();
        changePlayer.Password = PasswordTextBox.Text.Trim();

        string connectionString = ConfigurationManager.ConnectionStrings["GameContext"].ConnectionString;

        using (SqlConnection sConn = new SqlConnection(connectionString))
        {
            sConn.Open();
            string sqlExpression = "UPDATE Players SET Name='" + changePlayer.Name + "', Login='" + changePlayer.Login
                    + "', Password='" + changePlayer.Password + "' WHERE Id='" + player.Id + "'";
            SqlCommand command = new SqlCommand(sqlExpression, sConn);
            int number = command.ExecuteNonQuery();

            player.Name = changePlayer.Name;
            player.Login = changePlayer.Login;
            player.Password = changePlayer.Password;
            Session["Player"] = player;

            sConn.Close();
        }
    }
}