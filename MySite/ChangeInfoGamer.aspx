<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ChangeInfoGamer.aspx.cs" Inherits="ChangeInfoGamer" MasterPageFile="~/Site.master" %>

<asp:Content ID="MainContent" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <div class="login">
        <div class="RegTable">
        <div class="TableRow">
            <div class="TableLeftCol">
                <asp:Label ID="NameLabel" runat="server" Text="Введите имя:"></asp:Label>
            </div>
            <div class="TableRightCol">
                <asp:TextBox ID="NameTextBox" runat="server" MaxLength="50"></asp:TextBox>
                <asp:RequiredFieldValidator ID="NameRequiredFieldValidator" ControlToValidate="NameTextBox" runat="server" ErrorMessage="The Name must be filled in." Text="*"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div class="TableRow">
            <div class="TableLeftCol">
                <asp:Label ID="LoginLabel" runat="server" Text="Введите логин:"></asp:Label>
            </div>
            <div class="TableRightCol">
                <asp:TextBox ID="LoginTextBox" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="LoginRequiredFieldValidator" ControlToValidate="LoginTextBox" runat="server" ErrorMessage="The Login must be filled in." Text="*"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div class="TableRow">
            <div class="TableLeftCol">
                <asp:Label ID="PasswordLabel" runat="server" Text="Введите пароль:"></asp:Label>
            </div>
            <div class="TableRightCol">
                <asp:TextBox ID="PasswordTextBox" runat="server" MaxLength="50"></asp:TextBox>
                <asp:RequiredFieldValidator ID="PasswordFieldValidator" ControlToValidate="PasswordTextBox" runat="server" ErrorMessage="The Password must be filled in." Text="*"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div class="TableRow">
            <div class="TableLeftCol">
                <asp:Label ID="PasswordLabel2" runat="server" Text="Введите пароль еще раз:"></asp:Label>
            </div>
            <div class="TableRightCol">
                <asp:TextBox ID="PasswordTextBox2" runat="server" MaxLength="10"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="PasswordTextBox2" runat="server" ErrorMessage="The Password must be filled in." Text="*"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div class="TableRow">
            <asp:Label ID="ErrorPassword" runat="server"></asp:Label>
        </div>
        <div class="TableRow">
            <div class="TableErrors">
                <asp:ValidationSummary ID="CustomerValidationSummary" runat="server"></asp:ValidationSummary>
            </div>
            <asp:Button ID="CustomerInsertButton" runat="server" Text="Сохранить" OnClick="CustomerInsertButton_Click" BackColor="YellowGreen"/>
        </div>
    </div>
    </div>
</asp:Content>
