<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Registration.aspx.cs" Inherits="Registration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="~/Styles/Site.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="Table">
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
            <asp:Button ID="CustomerInsertButton" runat="server" Text="Зарегистрироваться" OnClick="CustomerInsertButton_Click"/>
            &nbsp;<asp:Button ID="CustomerCancelButton" runat="server" Text="Назад" OnClick="CustomerCancelButton_Click" />
        </div>
    </div>
    </form>
</body>
</html>
