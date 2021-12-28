using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyLibrary;

public partial class Battle : Page
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
            Label1.Text = Session["id_player"].ToString();
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
                Label3.Text = "У вас нет жабок.<br/> Перейдите в Your Frog, чтобы получит жабку.";
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
        for (int i=0; i<frogs.Count; i++)
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
    }

    /// <summary>
    /// Кнопка начала битвы жабок
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ButtonBattle_Click(object sender, EventArgs e)
    {
        bool waiting = false;
        if (frogs.Count == 0) return;
        Frog frog = frogs.ElementAtOrDefault(DropDownList1.SelectedIndex);
        string connectionString = ConfigurationManager.ConnectionStrings["GameContext"].ConnectionString;
        using (SqlConnection sConn = new SqlConnection(connectionString))
        {
            sConn.Open();
            int power_points = frog.Power_point;
            waiting = time.iswaitTime(frog.BattleTime);
            if (!waiting)
            {
                Timer1.Enabled = false;
                DateTimeNextLabel.Text = "";
                MyLibrary.Battle buttle = new MyLibrary.Battle(frog);
                if (buttle.IsWin())
                {
                    power_points += buttle.ButtleWinPoints(frog);
                    frog.updateLevel();
                    string sqlExpression = "UPDATE Frogs SET Level="+ frog.Level + " WHERE Id='"+ frog.ID + "'";
                    SqlCommand command = new SqlCommand(sqlExpression, sConn);
                    int number2 = command.ExecuteNonQuery();
                    EnemyNameLabel.Text  = "Поздравляем, Вы победили!\nВы получаете " + String.Format("{0:d}", buttle.ButtleWinPoints(frog) + " очков к силе.");
                    frogs.ElementAtOrDefault(DropDownList1.SelectedIndex).Power_point = power_points;
                    frogs.ElementAtOrDefault(DropDownList1.SelectedIndex).Level = frog.Level;
                    UpdateTextInfoAboutFrog();
                }
                else
                {
                    EnemyNameLabel.Text = "Вы проиграли.";
                }

                LevelFrogLabel.Text = "Уровень: " + String.Format("{0:d}", frog.Level);
                PowerLevelFrogLabel.Text = "Сила: " + String.Format("{0:d}", buttle.MyFrog.levelOfPoints("power"));
                PowerPointFrogLabel.Text = "Очки силы: " + String.Format("{0:d}", power_points);
                EnemyNameLabel.Text = "Ваш враг<br/>" + "Уровень: " + String.Format("{0:d}", buttle.Enemy.Level) +
                    "<br/>Сила: " + String.Format("{0:d}", buttle.Enemy.levelOfPoints("power")) +
                    "<br/>Ловкость: " + String.Format("{0:d}", buttle.Enemy.levelOfPoints("agility")) +
                    "<br/>Интеллект: " + String.Format("{0:d}", buttle.Enemy.levelOfPoints("intelligence")) +
                    "<br/>Удача: " + String.Format("{0:f1}", buttle.Enemy.Luck);

                frogs.ElementAtOrDefault(DropDownList1.SelectedIndex).BattleTime = DateTime.Now.Add(buttle.wait_time).ToString();
                Session["ListFrog"] = frogs;
                string sqlExpression2 = "UPDATE Frogs SET BattleTime='" + frog.BattleTime + "' WHERE Id='" + frog.ID + "'";
                SqlCommand command2 = new SqlCommand(sqlExpression2, sConn);
                int number = command2.ExecuteNonQuery();
                //db.Database.ExecuteSqlCommand("UPDATE Frogs SET BattleTime={0} WHERE ID={1}", frogs.ElementAtOrDefault(frogNumberInTheList).BattleTime, frog.ID);
                sConn.Close();
            }
        }
        if (waiting)
        {
            EnemyNameLabel.Text = "Привет!\nЗдесь ты можешь отправить свою\nжабку драться с другой жабкой.\nТы будешь развивать навык силы!\n" +
           "Нажми на кнопку Битва.";

            endOfGameFrogTime = frog.BattleTime;
            WinTextLabel.Text = "Eще слишком рано.\nДайте вашей жабке отдохнуть! ";
            Timer1.Interval = 1000;
            Timer1.Enabled = true;
            //dispatcherTimer.Tick += dispatcherTimer_Tick;
            //dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            //dispatcherTimer.Start();
        }
    }

    protected void Timer1_Tick(object sender, EventArgs e)
    {
        frogs = (List<Frog>)Session["ListFrog"];
        endOfGameFrogTime = frogs[DropDownList1.SelectedIndex].BattleTime;
        DateTimeNextLabel.Text = DateTime.Parse(endOfGameFrogTime).Subtract(DateTime.Now).ToString(@"hh\:mm\:ss");
    }
}