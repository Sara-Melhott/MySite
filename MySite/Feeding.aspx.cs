using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyLibrary;

public partial class Feeding : System.Web.UI.Page
{
    int id_player;
    int frogNumberInTheList = 0;
    int numberOfFrogs = 0;
    List<Frog> frogs = new List<Frog>();
    Time time = new Time();
    string endOfGameFrogTime = null;
    Frog newFrog = new Frog();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            id_player = (int)Session["id_player"];
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
                EnemyNameLabel.Text = "Привет!<br/>Здесь ты можешь отправить свою<br/>жабку на озеро ловить себе еду.<br/>Ты будешь развивать навык ловкости!<br/>" +
           "Нажми на кнопку покормить.";

                sConn.Close();
            }
            if (numberOfFrogs == 0)
            {
                DropDownList1.SelectedIndex = 0;
                DropDownList1.Visible = false;
                Label3.Text = "У вас нет жабок.<br/>Перейдите в Ваши жабки, чтобы получит жабку.";
            }
            else
            {
                UpdateComboBox();
                DropDownList1.SelectedIndex = 0;
                UpdateTextInfoAboutFrog();
            }
            Timer1.Enabled = false;
            DateTimeNextLabel.Text = "";
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
        Timer1.Enabled = false;
        DateTimeNextLabel.Text = "";
        WinTextLabel.Text = "";
    }
    
    /// <summary>
    /// Кнопка начала поиска еды
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ButtonFeeding_Click(object sender, EventArgs e)
    {
        bool waiting = false;
        if (frogs.Count == 0) return;
        Frog frog = frogs.ElementAtOrDefault(DropDownList1.SelectedIndex);
        string connectionString = ConfigurationManager.ConnectionStrings["GameContext"].ConnectionString;
        using (SqlConnection sConn = new SqlConnection(connectionString))
        {
            sConn.Open();
            int agility_point = frog.Agility_point;
            waiting = time.iswaitTime(frog.FeedingTime);
            if (!waiting)
            {
                MyLibrary.Feeding feeding = new MyLibrary.Feeding();
                WinTextLabel.Text = "";
                if (feeding.feedingBadDay())
                {
                    agility_point += feeding.feedingPoints(frog);
                    EnemyNameLabel.Text = "Поздравляем!<br/>Вы получаете " + String.Format("{0:d}", feeding.feedingPoints(frog) + " очков к ловкости.");
                    if (feeding.feedingGoodDay(frog))
                    {
                        EnemyNameLabel.Text = "Поздравляем!<bt/>Вы получаете " + String.Format("{0:d}", feeding.feedingPoints(frog)) +
                            " очков<br/>к ловкости.<br/>Ура! Вас угостили по пути домой!<br/>Вы получаете дополнительно<br/>"
                            + String.Format("{0:d}", feeding.feedingExtraPoints(frog)) + " очков!";
                        agility_point += feeding.feedingExtraPoints(frog);
                    }
                    frog.updateLevel();
                    frogs.ElementAtOrDefault(DropDownList1.SelectedIndex).Agility_point = agility_point;
                    frogs.ElementAtOrDefault(DropDownList1.SelectedIndex).Level = frog.Level;
                    string sqlExpression = "UPDATE Frogs SET Level=" + frog.Level + ", Agility_point=" + frog.Agility_point
                        + " WHERE Id='" + frog.ID + "'";
                    SqlCommand command = new SqlCommand(sqlExpression, sConn);
                    int number2 = command.ExecuteNonQuery();
                    
                }
                else
                {
                    EnemyNameLabel.Text = "Ваша жабка ничего<br/>не смогла поймать.<br/>Попробуйте еще раз завтра.";
                }
                frogs.ElementAtOrDefault(DropDownList1.SelectedIndex).FeedingTime = DateTime.Now.Add(feeding.wait_time).ToString();
                UpdateTextInfoAboutFrog();
                Session["ListFrog"] = frogs;
                string sqlExpression2 = "UPDATE Frogs SET FeedingTime='" + frog.FeedingTime + "' WHERE Id='" + frog.ID + "'";
                SqlCommand command2 = new SqlCommand(sqlExpression2, sConn);
                int number = command2.ExecuteNonQuery();
                sConn.Close();
            }
        }
        if (waiting)
        {
            EnemyNameLabel.Text = "Привет!<br/>Здесь ты можешь отправить свою<br/>жабку на озеро ловить себе еду.<br/>Ты будешь развивать навык ловкости!<br/>" +
           "Нажми на кнопку покормить.";

            endOfGameFrogTime = frog.FeedingTime;
            WinTextLabel.Text = "Eще слишком рано. ";
            Timer1.Interval = 1000;
            Timer1.Enabled = true;
        }
    }
    protected void Timer1_Tick(object sender, EventArgs e)
    {
        frogs = (List<Frog>)Session["ListFrog"];
        endOfGameFrogTime = frogs[DropDownList1.SelectedIndex].FeedingTime;
        DateTimeNextLabel.Text = DateTime.Parse(endOfGameFrogTime).Subtract(DateTime.Now).ToString(@"hh\:mm\:ss");
    }

    
}