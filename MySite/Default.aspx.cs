using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!(bool)Session["Aut"])
            Response.Redirect("Error.aspx");
        Label1.Text = "Привет!<br/>Здесь ты сможешь прокачивать своих персонажей - жабок!<br/>Во вкладке 'Игра' ты найдешь 3 мини игры (" +
            "Битва, Поиск еды и Работа) и страничку 'Ваши жабки'.<br/>Если ты играешь в первый раз загляни туда сначало.<br/>Там ты сможешь получить новую жабку" +
            ", чтобы начать играть.<br/>На страничках с мини играми ты найдешь их описание.<br/>И не забывай что жабки не могут все время драться, искать еду и " +
            "работать.<br/>Им нужен отдых.<br/>Удачи!";
    }
}