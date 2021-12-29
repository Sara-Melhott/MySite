<%@Page Language="C#" AutoEventWireup="true" CodeFile="Battle.aspx.cs" Inherits="Battle" MasterPageFile="~/Site.master" %>

<asp:Content ID="MainContent" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <div class="login">
    <div class="GameTable">
        <div class="GameRow2">
            <asp:Label ID="Label2" runat="server" Text="Здесь можно драться!"></asp:Label>
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
                    <asp:Label ID="luckFrogLabel" runat="server" Height="40"></asp:Label>
                </div>
            </div>
             <div class="GameRightCol">
                 <div>
                     <asp:Label ID="EnemyNameLabel" runat="server" Text="" MaximumSize ="150" Height="150"></asp:Label>
                 </div>
                 <div>
                     <asp:Label ID="WinTextLabel" runat="server" Height="30"></asp:Label>
                 </div>
                 <div>
                     
                     <asp:ScriptManager ID="ScriptManager1" runat="server">
                     </asp:ScriptManager>
                         <asp:Timer ID="Timer1" runat="server" OnTick="Timer1_Tick"></asp:Timer>
                     <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                         <ContentTemplate>
                             <asp:Label ID="DateTimeNextLabel" runat="server" Height="30" ></asp:Label>
                         </ContentTemplate>
                         <Triggers>
                             <asp:AsyncPostBackTrigger ControlID="Timer1" EventName="Tick" />
                         </Triggers>
                     </asp:UpdatePanel>
                     
                 </div>
                 <div >
                     <asp:Button ID="ButtonBattle" runat="server" Text="Битва" Width="190" BackColor="#c49000" OnClick="ButtonBattle_Click"/>
                 </div>
            </div>
         </div>   
     </div>
        </div>
</asp:Content>

