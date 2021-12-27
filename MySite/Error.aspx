<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Error.aspx.cs" Inherits="Error" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="Table">
        <div class="TableRow">
            <asp:Label ID="Label1" runat="server" Text="Пожалуйста, авторизируйтесь, чтобы поиграть!"></asp:Label>
         </div>
        <div class="TableRow">
            <asp:Button ID="Button1" runat="server" Text="Авторизироваться" Width="121px" OnClick="Button1_Click" />
        </div>
    </div>  
    </form>
</body>
</html>
