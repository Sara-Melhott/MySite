using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyLibrary;

public partial class Frogs : System.Web.UI.Page
{
    int id_player;
    int frogNumberInTheList = 0;
    int numberOfFrogs = 0;
    List<Frog> frogs = new List<Frog>();
    Time time = new Time();
    Frog newFrog = new Frog();
    //System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            id_player = (int)Session["id_player"];
            Label1.Text = Session["id_player"].ToString();
            ButtonNo.Visible = false;
            ButtonYes.Visible = false;
            //Заполнение списка жабок
            string connectionString = ConfigurationManager.ConnectionStrings["GameContext"].ConnectionString;
            //Подключение к БД
            using (SqlConnection sConn = new SqlConnection(connectionString))
            {
                sConn.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM Frogs WHERE Id_Player = '" + (int)Session["id_player"] + "'", sConn);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    object val = null;
                    while (reader.Read())
                    {
                        string var8;
                        if (reader.IsDBNull(8))
                            var8 = null;
                        else
                            var8 = (string)reader.GetValue(8);
                        string var9;
                        if (reader.IsDBNull(9))
                            var9 = null;
                        else
                            var9 = (string)reader.GetValue(9);
                        string var10;
                        if (reader.IsDBNull(10))
                            var10 = null;
                        else
                            var10 = (string)reader.GetValue(10);

                        Frog frog = new Frog((int)reader.GetValue(0), (int)reader.GetValue(1), (string)reader.GetValue(2), (int)reader.GetValue(3),
                            (int)reader.GetValue(4), (int)reader.GetValue(5), (double)reader.GetValue(6), (int)reader.GetValue(7),
                            var8, var9, var10);
                        frogs.Add(frog);
                        numberOfFrogs++;
                        Session["ListFrog"] = frogs;
                    }
                }


                sConn.Close();
            }
            if (numberOfFrogs == 0)
            {
                DropDownList1.SelectedIndex = 0;
                DropDownList1.Visible = false;
                Label3.Text = "У вас нет жабок.<br/> Нажмите кнопку 'Получить жабку'.";
            }
            else
            {
                UpdateComboBox();
                DropDownList1.SelectedIndex = 0;
                UpdateTextInfoAboutFrog();
            }
        }
        else
        {
            id_player = (int)Session["id_player"];
            if (Session["ListFrog"] != null)
                frogs = (List<Frog>)Session["ListFrog"];
            if (frogs != null)
                numberOfFrogs = frogs.Count;
            newFrog = (Frog)Session["NewFrog"];
        }
    }
    private void UpdateTextInfoAboutFrog()
    {
        if (frogs.Count == 0)
        {
            LevelFrogLabel.Text = "";
            PowerLevelFrogLabel.Text = "";
            AgilityLevelFrogLabel.Text = "";
            IntelligenceLevelFrogLabel.Text = "";
            PowerPointFrogLabel.Text = "";
            AgilityPointFrogLabel.Text = "";
            IntelligencePointFrogLabel.Text = "";
            luckFrogLabel.Text = "";
        }
        else
        {
            int frogNumberInTheList = DropDownList1.SelectedIndex;
            LevelFrogLabel.Text = "Уровень: " + String.Format("{0:d}", frogs.ElementAt(frogNumberInTheList).Level);
            PowerLevelFrogLabel.Text = "Сила: " + String.Format("{0:d}", frogs.ElementAt(frogNumberInTheList).levelOfPoints("power"));
            AgilityLevelFrogLabel.Text = "Ловкость: " + String.Format("{0:d}", frogs.ElementAt(frogNumberInTheList).levelOfPoints("agility"));
            IntelligenceLevelFrogLabel.Text = "Интеллект: " + String.Format("{0:d}", frogs.ElementAt(frogNumberInTheList).levelOfPoints("intelligence"));
            PowerPointFrogLabel.Text = "Очки силы: " + String.Format("{0:d}", frogs.ElementAt(frogNumberInTheList).Power_point);
            AgilityPointFrogLabel.Text = "Очки ловкоси: " + String.Format("{0:d}", frogs.ElementAt(frogNumberInTheList).Agility_point);
            IntelligencePointFrogLabel.Text = "Очки интеллекта: " + String.Format("{0:d}", frogs.ElementAt(frogNumberInTheList).Intelligence_points);
            luckFrogLabel.Text = "Удача: " + String.Format("{0:f1}", frogs.ElementAt(frogNumberInTheList).Luck);

        }
    }

    private void UpdateComboBox()
    {
        DropDownList1.Items.Clear();
        for (int i = 0; i < frogs.Count; i++)
        {
            DropDownList1.Items.Add(frogs[i].Name);
        }
    }

    /// <summary>
    /// Изменение выбора игровой жабки
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        UpdateTextInfoAboutFrog();
    }

    protected void ButtonRemoveFrog_Click(object sender, EventArgs e)
    {
        try
        {
            string connectionString = ConfigurationManager.ConnectionStrings["GameContext"].ConnectionString;
            Frog frog = frogs.ElementAtOrDefault(DropDownList1.SelectedIndex);
            using (SqlConnection sConn = new SqlConnection(connectionString))
            {
                sConn.Open();
                string sqlExpression = "DELETE FROM Frogs WHERE Id='" + frog.ID + "'";
                SqlCommand command = new SqlCommand(sqlExpression, sConn);
                int number = command.ExecuteNonQuery();

                frogs.RemoveAt(DropDownList1.SelectedIndex);

                sConn.Close();
            }
            UpdateTextInfoAboutFrog();
            if (frogs.Count == 0)
            {
                DropDownList1.Visible = false;
                Label3.Text = "У вас нет жабок.<br/> Нажмите кнопку 'Получить жабку'.";
            }
            else
            {
                DropDownList1.SelectedIndex = 0;
            }
            Session["ListFrog"] = frogs;
            UpdateComboBox();

            numberOfFrogs--;
            NewNextFrogTimeLabel.Text = "Вы можете получить жабку!";
        }
        catch
        {
            return;
        }
        //обновления выпадающего списка (комбо бокс)
        //ResetFields(); //выключение все полей
    }
    protected void ButtonGetFrog_Click(object sender, EventArgs e)
    {
        if (numberOfFrogs < 3)
        {
            Random rnd = new Random();
            int level = rnd.Next(1, 4);
            string str = null;
            newFrog = new Frog(level);
            TypeOfGameLabel.Text = "Нравится жабка?";
            //EnemyName.Visibility = Visibility.Visible;
            string connectionString = ConfigurationManager.ConnectionStrings["GameContext"].ConnectionString;
            using (SqlConnection sConn = new SqlConnection(connectionString))
            {
                sConn.Open();
                while (true)
                {
                    int number = rnd.Next(1, 1000);
                    str = "Frog" + String.Format("{0:d}", number);
                    SqlCommand command = new SqlCommand("SELECT * FROM Frogs WHERE Name = '" + str + "'", sConn);
                    SqlDataReader reader = command.ExecuteReader();
                    if (!reader.HasRows)
                    {
                        EnemyNameLabel.Text = str;
                        newFrog.Name = str;
                        break;
                    }
                    reader.Close();
                }
                sConn.Close();
            }
            EnemyNameLabel.Text += "<br/>" + "\nУровень: " + String.Format("{0:d}", newFrog.Level) + "<br/>" +
                "\nСила: " + String.Format("{0:d}", newFrog.levelOfPoints("power")) + "<br/>" +
                "\nЛовкость: " + String.Format("{0:d}", newFrog.levelOfPoints("agility")) + "<br/>" +
                "\nИнтеллект: " + String.Format("{0:d}", newFrog.levelOfPoints("intelligence")) + "<br/>" +
                "\nУдача: " + String.Format("{0:f1}", newFrog.Luck);
            ButtonNo.Visible = true;
            ButtonYes.Visible = true;
            Session["NewFrog"] = newFrog;
        }
        else
        {
            NewNextFrogTimeLabel.Text = "У вас слишком много жабок!";
        }

    }
    /// <summary>
    /// Кнопка сохрнения жабки
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ButtonYes_Click(object sender, EventArgs e)
    {
        newFrog.ID_Player = id_player;
        string connectionString = ConfigurationManager.ConnectionStrings["GameContext"].ConnectionString;
        //Подключение к БД
        using (SqlConnection sConn = new SqlConnection(connectionString))
        {
            sConn.Open();
            string sqlExpression = "INSERT INTO Frogs (Id_Player, Name, Power_point, Agility_point," +
                " Intelligence_points, Luck, Level, BattleTime, FeedingTime, WorkTime) VALUES ('" +
                id_player + "', '" + newFrog.Name + "', '" + newFrog.Power_point + "', '" +
                newFrog.Agility_point + "', '" + newFrog.Intelligence_points + "', @Luck, '" + newFrog.Level + "', " +
                "@DbNull, @DbNull, @DbNull)";
            SqlCommand command = new SqlCommand(sqlExpression, sConn);
            command.Parameters.AddWithValue("@Luck", newFrog.Luck);
            command.Parameters.AddWithValue("@DbNull", DBNull.Value);
            int number = command.ExecuteNonQuery();
            //sqlExpression = "UPDATE Frogs";
            //command.ExecuteNonQuery();

            //SqlDataAdapter adapter = new SqlDataAdapter();

            frogs.Add(newFrog);
            Session["ListFrog"] = frogs;
            numberOfFrogs++;

            UpdateComboBox();
            DropDownList1.Visible = true;
            DropDownList1.SelectedIndex = 0;
            UpdateTextInfoAboutFrog();

            sConn.Close();
        }

        TypeOfGameLabel.Text = "Битва";
        ButtonNo.Visible = false;
        ButtonYes.Visible = false;
        EnemyNameLabel.Text = "";
        if (numberOfFrogs < 3)
            NewNextFrogTimeLabel.Text = "Вы можете получить жабку!";
        else
            NewNextFrogTimeLabel.Text = "У вас слишком много жабок!";
    }
    /// <summary>
    /// Кнопка отказа от жабки
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ButtonNo_Click(object sender, EventArgs e)
    {
        TypeOfGameLabel.Text = "Битва";
        ButtonNo.Visible = false;
        ButtonYes.Visible = false;
        EnemyNameLabel.Text = "";
        if (numberOfFrogs < 3)
            NewNextFrogTimeLabel.Text = "Вы можете получить жабку!";
        else
            NewNextFrogTimeLabel.Text = "У вас слишком много жабок!";
    }
}