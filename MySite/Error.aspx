<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Error.aspx.cs" Inherits="Error" MasterPageFile="~/AutReg.master" %>

<asp:Content ID="MainContent" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <div class="login">
        <div class="RegTable">
        <div class="TableRow">
            <asp:Label ID="Label1" runat="server" Text="Пожалуйста, авторизируйтесь, чтобы поиграть!"></asp:Label>
         </div>
        <div class="TableRow">
            <asp:Button ID="Button1" runat="server" Text="Авторизироваться" Width="157px" OnClick="Button1_Click" BackColor="YellowGreen"/>
        </div>
    </div>  
        </div>
</asp:Content>
