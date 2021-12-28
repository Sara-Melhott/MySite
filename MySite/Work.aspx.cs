using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyLibrary;

public partial class Work : System.Web.UI.Page
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
    }
    protected void Timer1_Tick(object sender, EventArgs e)
    {
        frogs = (List<Frog>)Session["ListFrog"];
        endOfGameFrogTime = frogs[DropDownList1.SelectedIndex].WorkTime;
        DateTimeNextLabel.Text = DateTime.Parse(endOfGameFrogTime).Subtract(DateTime.Now).ToString(@"hh\:mm\:ss");
    }

    protected void ButtonWork4_Click(object sender, EventArgs e)
    {
        EnemyNameLabel.Text = "";
        bool waiting = false;
        if (frogs.Count == 0) return;
        Frog frog = frogs.ElementAtOrDefault(DropDownList1.SelectedIndex);
        string connectionString = ConfigurationManager.ConnectionStrings["GameContext"].ConnectionString;
        using (SqlConnection sConn = new SqlConnection(connectionString))
        {
            sConn.Open();
            int intelligence_point = frog.Intelligence_points;
            waiting = time.iswaitTime(frog.WorkTime);
            if (!waiting)
            {
                MyLibrary.Work work = new MyLibrary.Work();
                WinTextLabel.Text = "";
                intelligence_point += work.work4Hour(frog);
                EnemyNameLabel.Text = "Поздравляем!\nВы получаете " + String.Format("{0:d}", work.work4Hour(frog) + " очков к интеллекту.");
                if (work.workNotSuccess() && work.workGoodDay(frog))
                {
                    EnemyNameLabel.Text = "Поздравляем!<br/>Вы получаете " + String.Format("{0:d}", work.work4Hour(frog)) +
                        " очков<br/>к интеллекту.<br/>Ура! Вы получаете премию!<br/>Вы получаете дополнительно<br/>"
                        + String.Format("{0:d}", work.workExtraPoints(frog)) + " очков!";
                    intelligence_point += work.workExtraPoints(frog);
                }
                frogs.ElementAtOrDefault(DropDownList1.SelectedIndex).Intelligence_points = intelligence_point;
                frog.updateLevel();
                frogs.ElementAtOrDefault(DropDownList1.SelectedIndex).Level = frog.Level;
                frogs.ElementAtOrDefault(DropDownList1.SelectedIndex).WorkTime = DateTime.Now.Add(work.wait_time4).ToString();
                UpdateTextInfoAboutFrog();
                Session["ListFrog"] = frogs;
                string sqlExpression2 = "UPDATE Frogs SET Level=" + frog.Level + ", Intelligence_points=" + frog.Intelligence_points
                    + ", WorkTime='" + frog.WorkTime + "' WHERE Id='" + frog.ID + "'";
                SqlCommand command2 = new SqlCommand(sqlExpression2, sConn);
                int number = command2.ExecuteNonQuery();
            }
            sConn.Close();
        }
        if (waiting)
        {
            EnemyNameLabel.Text = "Привет!<br/>Здесь ты можешь отправить свою<br/>жабку на 4, 8 или 12 часов работать.<br/>Ты будешь развивать навык интеллекта!<br/>" +
            "Выбери время, на сколько хочешь<br/>отправить свою жабку и нажми<br/>соотвествующую кнопку.";
            endOfGameFrogTime = frog.WorkTime;
            WinTextLabel.Text = "Eще слишком рано!<br/>Ваша жабка работает.";
            Timer1.Interval = 1000;
            Timer1.Enabled = true;
        }
    }

    protected void ButtonWork8_Click(object sender, EventArgs e)
    {
        EnemyNameLabel.Text = "";
        bool waiting = false;
        if (frogs.Count == 0) return;
        Frog frog = frogs.ElementAtOrDefault(DropDownList1.SelectedIndex);
        string connectionString = ConfigurationManager.ConnectionStrings["GameContext"].ConnectionString;
        using (SqlConnection sConn = new SqlConnection(connectionString))
        {
            sConn.Open();
            int intelligence_point = frog.Intelligence_points;
            waiting = time.iswaitTime(frog.WorkTime);
            if (!waiting)
            {
                MyLibrary.Work work = new MyLibrary.Work();
                WinTextLabel.Text = "";
                intelligence_point += work.work8Hour(frog);
                EnemyNameLabel.Text = "Поздравляем!\nВы получаете " + String.Format("{0:d}", work.work8Hour(frog) + " очков к интеллекту.");
                if (work.workNotSuccess() && work.workGoodDay(frog))
                {
                    EnemyNameLabel.Text = "Поздравляем!<br/>Вы получаете " + String.Format("{0:d}", work.work8Hour(frog)) +
                        " очков<br/>к интеллекту.<br/>Ура! Вы получаете премию!<br/>Вы получаете дополнительно<br/>"
                        + String.Format("{0:d}", work.workExtraPoints(frog)) + " очков!";
                    intelligence_point += work.workExtraPoints(frog);
                }
                frogs.ElementAtOrDefault(DropDownList1.SelectedIndex).Intelligence_points = intelligence_point;
                frog.updateLevel();
                frogs.ElementAtOrDefault(DropDownList1.SelectedIndex).Level = frog.Level;
                frogs.ElementAtOrDefault(DropDownList1.SelectedIndex).WorkTime = DateTime.Now.Add(work.wait_time8).ToString();
                UpdateTextInfoAboutFrog();
                Session["ListFrog"] = frogs;
                string sqlExpression2 = "UPDATE Frogs SET Level=" + frog.Level + ", Intelligence_points=" + frog.Intelligence_points
                    + ", WorkTime='" + frog.WorkTime + "' WHERE Id='" + frog.ID + "'";
                SqlCommand command2 = new SqlCommand(sqlExpression2, sConn);
                int number = command2.ExecuteNonQuery();
            }
            sConn.Close();
        }
        if (waiting)
        {
            EnemyNameLabel.Text = "Привет!<br/>Здесь ты можешь отправить свою<br/>жабку на 4, 8 или 12 часов работать.<br/>Ты будешь развивать навык интеллекта!<br/>" +
            "Выбери время, на сколько хочешь<br/>отправить свою жабку и нажми<br/>соотвествующую кнопку.";
            endOfGameFrogTime = frog.WorkTime;
            WinTextLabel.Text = "Eще слишком рано!<br/>Ваша жабка работает.";
            Timer1.Interval = 1000;
            Timer1.Enabled = true;
        }
    }

    protected void ButtonWork12_Click(object sender, EventArgs e)
    {
        EnemyNameLabel.Text = "";
        bool waiting = false;
        if (frogs.Count == 0) return;
        Frog frog = frogs.ElementAtOrDefault(DropDownList1.SelectedIndex);
        string connectionString = ConfigurationManager.ConnectionStrings["GameContext"].ConnectionString;
        using (SqlConnection sConn = new SqlConnection(connectionString))
        {
            sConn.Open();
            int intelligence_point = frog.Intelligence_points;
            waiting = time.iswaitTime(frog.WorkTime);
            if (!waiting)
            {
                MyLibrary.Work work = new MyLibrary.Work();
                WinTextLabel.Text = "";
                intelligence_point += work.work12Hour(frog);
                EnemyNameLabel.Text = "Поздравляем!\nВы получаете " + String.Format("{0:d}", work.work12Hour(frog) + " очков к интеллекту.");
                if (work.workNotSuccess() && work.workGoodDay(frog))
                {
                    EnemyNameLabel.Text = "Поздравляем!<br/>Вы получаете " + String.Format("{0:d}", work.work12Hour(frog)) +
                        " очков<br/>к интеллекту.<br/>Ура! Вы получаете премию!<br/>Вы получаете дополнительно<br/>"
                        + String.Format("{0:d}", work.workExtraPoints(frog)) + " очков!";
                    intelligence_point += work.workExtraPoints(frog);
                }
                frogs.ElementAtOrDefault(DropDownList1.SelectedIndex).Intelligence_points = intelligence_point;
                frog.updateLevel();
                frogs.ElementAtOrDefault(DropDownList1.SelectedIndex).Level = frog.Level;
                frogs.ElementAtOrDefault(DropDownList1.SelectedIndex).WorkTime = DateTime.Now.Add(work.wait_time12).ToString();
                UpdateTextInfoAboutFrog();
                Session["ListFrog"] = frogs;
                string sqlExpression2 = "UPDATE Frogs SET Level=" + frog.Level + ", Intelligence_points=" + frog.Intelligence_points
                    + ", WorkTime='" + frog.WorkTime + "' WHERE Id='" + frog.ID + "'";
                SqlCommand command2 = new SqlCommand(sqlExpression2, sConn);
                int number = command2.ExecuteNonQuery();
            }
            sConn.Close();
        }
        if (waiting)
        {
            EnemyNameLabel.Text = "Привет!<br/>Здесь ты можешь отправить свою<br/>жабку на 4, 8 или 12 часов работать.<br/>Ты будешь развивать навык интеллекта!<br/>" +
            "Выбери время, на сколько хочешь<br/>отправить свою жабку и нажми<br/>соотвествующую кнопку.";
            endOfGameFrogTime = frog.WorkTime;
            WinTextLabel.Text = "Eще слишком рано!<br/>Ваша жабка работает.";
            Timer1.Interval = 1000;
            Timer1.Enabled = true;
        }
    }
}