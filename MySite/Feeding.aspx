<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Feeding.aspx.cs" Inherits="Feeding" MasterPageFile="~/Site.master"%>

<asp:Content ID="MainContent" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <div class="Table">
        <div class="TableRow">
            <asp:Label ID="Label2" runat="server" Text="Здесь будут драки!"></asp:Label>
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
         </div>
        <div class="TableRow">
            <div class="TableLeftCol">
                <div>
                    <asp:Label ID="Label3" runat="server" Text="Выберите жабку"></asp:Label>
                </div>
                <div>
                    <asp:DropDownList ID="DropDownList1" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
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
             <div class="TableRightCol">
                <div>
                    <asp:Label ID="TypeOfGameLabel" runat="server" Text="Битва" FontSize="25" Width="200"></asp:Label>
                </div>
                 <div>
                     <asp:Label ID="EnemyNameLabel" runat="server" Text="" MaximumSize ="150"></asp:Label>
                 </div>
                 <div>
                     <asp:Label ID="WinTextLabel" runat="server" ></asp:Label>
                 </div>
                 <div>
                     
                     <asp:ScriptManager ID="ScriptManager1" runat="server">
                     </asp:ScriptManager>
                         <asp:Timer ID="Timer1" runat="server" OnTick="Timer1_Tick"></asp:Timer>
                     <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                         <ContentTemplate>
                             <asp:Label ID="DateTimeNextLabel" runat="server" ></asp:Label>
                         </ContentTemplate>
                         <Triggers>
                             <asp:AsyncPostBackTrigger ControlID="Timer1" EventName="Tick" />
                         </Triggers>
                     </asp:UpdatePanel>
                     
                 </div>
                 <div>
                     <asp:Button ID="ButtonFeeding" runat="server" Text="Отправить искать еду" Width="190" BackColor="#c49000" OnClick="ButtonFeeding_Click" />
                 </div>
            </div>
         </div>   
     </div>
</asp:Content>