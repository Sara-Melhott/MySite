<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Work.aspx.cs" Inherits="Work" MasterPageFile="~/Site.master"%>

<asp:Content ID="MainContent" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <div class="login">
    <div class="GameTable">
        <div class="GameRow2">
            <asp:Label ID="Label2" runat="server" Text="Здесь будут драки!"></asp:Label>
         </div>
        <div class="TableRow">
            <div class="GameLeftCol">
                <div>
                    <asp:Label ID="Label3" runat="server" Text="Выберите жабку"></asp:Label>
                </div>
                <div>
                    <asp:DropDownList ID="DropDownList1" runat="server" BackColor="YellowGreen" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                </div>
                <div>
                    <asp:Label ID="LevelFrogLabel" runat="server" Margin="20 80 0 80" Width="200" Height="25" FontSize="14"></asp:Label>
                </div>
                <div>
                    <asp:Label ID="PowerLevelFrogLabel" runat="server" Margin="20 140 10 0" Width="165" Height="25" FontSize="14"></asp:Label>
                    <asp:Label ID="PowerPointFrogLabel" runat="server" Margin="20 140 10 0" Width="165" Height="25" FontSize="14"></asp:Label>
                </div>
                <div>
                    <asp:Label ID="AgilityLevelFrogLabel" runat="server" Margin="20 140 10 0" Width="165" Height="25" FontSize="14"></asp:Label>
                    <asp:Label ID="AgilityPointFrogLabel" runat="server" Margin="20 140 10 0" Width="165" Height="25" FontSize="14"></asp:Label>
                </div>
                <div>
                    <asp:Label ID="IntelligenceLevelFrogLabel" runat="server" Margin="20 140 10 0" Width="165" Height="25" FontSize="14"></asp:Label>
                    <asp:Label ID="IntelligencePointFrogLabel" runat="server" Margin="20 140 10 0" Width="165" Height="25" FontSize="14"></asp:Label>
                </div>
                <div>
                    <asp:Label ID="luckFrogLabel" runat="server" ></asp:Label>
                </div>
            </div>
             <div class="GameRightCol">
                <div class="GameRowL">
                    <asp:Label ID="TypeOfGameLabel" runat="server" Text="Работа" FontSize="25" Width="200"></asp:Label>
                </div>
                 <div class="GameRowL">
                     <asp:Label ID="EnemyNameLabel" runat="server" Text="" MaximumSize ="150" Height="120"></asp:Label>
                 </div>
                 <div class="GameRowL">
                     <asp:Label ID="WinTextLabel" runat="server" Height="30" ></asp:Label>
                 </div>
                 <div class="GameRowL">
                     
                     <asp:ScriptManager ID="ScriptManager1" runat="server">
                     </asp:ScriptManager>
                         <asp:Timer ID="Timer1" runat="server" OnTick="Timer1_Tick"></asp:Timer>
                     <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                         <ContentTemplate>
                             <asp:Label ID="DateTimeNextLabel" runat="server" Height="30"></asp:Label>
                         </ContentTemplate>
                         <Triggers>
                             <asp:AsyncPostBackTrigger ControlID="Timer1" EventName="Tick" />
                         </Triggers>
                     </asp:UpdatePanel>
                     
                 </div>
                 <div class="GameButton">
                     <asp:Button ID="ButtonWork4" runat="server" Text="Работать 4 часа" Width="190" BackColor="#c49000" OnClick="ButtonWork4_Click" /> <br />
                     <asp:Button ID="ButtonWork8" runat="server" Text="Работать 8 часов" Width="190" Margin="0 30 0 0" BackColor="#c49000" OnClick="ButtonWork8_Click" /> <br />
                     <asp:Button ID="ButtonWork12" runat="server" Text="Работать 12 часов" Width="190" Margin="0 30 0 0" BackColor="#c49000" OnClick="ButtonWork12_Click" />
                 </div>
            </div>
         </div>   
     </div>
        </div>
</asp:Content>
