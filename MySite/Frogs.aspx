<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Frogs.aspx.cs" Inherits="Frogs" MasterPageFile="~/Site.master"%>

<asp:Content ID="MainContent" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <div class="login">
    <div class="GameTable">
        <div class="GameRow2">
            <asp:Label ID="Label2" runat="server" Text="Здесь будут драки!"></asp:Label>
         </div>
        <div class="TableRow">
            <div class="GameLeftCol">
                <div class="GameRowR">
                    <asp:Label ID="Label3" runat="server" Text="Выберите жабку"></asp:Label>
                </div>
                <div class="GameRowR">
                    <asp:DropDownList ID="DropDownList1" runat="server" BackColor="YellowGreen" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                </div>
                <div class="GameRowR">
                    <asp:Label ID="LevelFrogLabel" runat="server" Margin="20 80 0 80" Width="200" Height="25" FontSize="14"></asp:Label>
                </div>
                <div class="GameRowR">
                    <asp:Label ID="PowerLevelFrogLabel" runat="server" Margin="20 140 10 0" Width="165" Height="25" FontSize="14"></asp:Label>
                    <asp:Label ID="PowerPointFrogLabel" runat="server" Margin="20 140 10 0" Width="165" Height="25" FontSize="14"></asp:Label>
                </div>
                <div class="GameRowR">
                    <asp:Label ID="AgilityLevelFrogLabel" runat="server" Margin="20 140 10 0" Width="165" Height="25" FontSize="14"></asp:Label>
                    <asp:Label ID="AgilityPointFrogLabel" runat="server" Margin="20 140 10 0" Width="165" Height="25" FontSize="14"></asp:Label>
                </div>
                <div class="GameRowR">
                    <asp:Label ID="IntelligenceLevelFrogLabel" runat="server" Margin="20 140 10 0" Width="165" Height="25" FontSize="14"></asp:Label>
                    <asp:Label ID="IntelligencePointFrogLabel" runat="server" Margin="20 140 10 0" Width="165" Height="25" FontSize="14"></asp:Label>
                </div>
                <div class="GameRowR">
                    <asp:Label ID="luckFrogLabel" runat="server" ></asp:Label>
                </div>
                <div class="GameRowR">
                    <asp:Label ID="NewNextFrogTimeLabel" runat="server" Text="Вы можете получить жабку!" Margin="0 150 0 0" FontSize="15" Width="200" Height="30"></asp:Label>
                </div>
                <div class="GameRowR">
                    <asp:Button ID="ButtonRemoveFrog" runat="server" Text="Удалить жабку" Width="190"  BackColor="#c49000" OnClick="ButtonRemoveFrog_Click"/>
                </div>
                <div class="GameRowR">
                    <asp:Button ID="ButtonGetFrog" runat="server" Text="Получить жабку" Width="190" BackColor="#c49000" OnClick="ButtonGetFrog_Click"/>
                </div>
            </div>
             <div class="GameRightCol">
                <div>
                    <asp:Label ID="TypeOfGameLabel" runat="server" Text="Здесь ты можешь отпустить жабку или взять новую!" FontSize="25" Width="200"></asp:Label>
                </div>
                 <div>
                     <asp:Label ID="EnemyNameLabel" runat="server" Text="" MaximumSize ="150"></asp:Label>
                 </div>
                 <div>
                     <asp:Button ID="ButtonYes" runat="server" Text="Да" Margin="50 350 0 0" Width="100" Height="30" BackColor="#fbc02d" OnClick="ButtonYes_Click"/>
                     <asp:Button ID="ButtonNo" runat="server" Text="Нет" Margin="0 350 50 0" Width="100" Height="30" BackColor="#fbc02d" OnClick="ButtonNo_Click"/>
                 </div>
            </div>
         </div>   
     </div>
        </div>
</asp:Content>