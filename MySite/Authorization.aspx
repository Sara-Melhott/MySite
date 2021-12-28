<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Authorization.aspx.cs" Inherits="Authorization" MasterPageFile="~/AutReg.master"%>

<asp:Content ID="MainContent" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
         <div class="login">
            <asp:Login ID="Login1" runat="server" OnAuthenticate="Login1_Authenticate" Width="435px">
                <LayoutTemplate>
                    <table cellpadding="1" cellspacing="0" class="aut">
                        <tr>
                            <td class="auto-style1" style="width: 428px">
                                <table cellpadding="0">
                                    <tr>
                                        <td align="center" colspan="2">Выполнить вход</td>
                                    </tr>
                                    <tr>
                                        <td align="right" valign="top" style="width: 307px" >
                                            <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">Имя пользователя:</asp:Label>
                                        </td>
                                        <td class="auto-style2" style="width: 318px">
                                            <asp:TextBox ID="UserName" runat="server"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName" ErrorMessage="Поле &quot;Имя пользователя&quot; является обязательным." ToolTip="Поле &quot;Имя пользователя&quot; является обязательным." ValidationGroup="Login1">*</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" valign="top" style="width: 307px">
                                            <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">Пароль:</asp:Label>
                                        </td>
                                        <td class="auto-style2" style="width: 318px">
                                            <asp:TextBox ID="Password" runat="server" TextMode="Password"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password" ErrorMessage="Поле &quot;Пароль&quot; является обязательным." ToolTip="Поле &quot;Пароль&quot; является обязательным." ValidationGroup="Login1">*</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td align="center" colspan="2" style="color:Red;">
                                            <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Button ID="RegButton" runat="server" OnClick="RegButton_Click" style="margin-left: 0px" Text="Зарегистрироваться" Width="158px" BackColor="YellowGreen" />
                                        </td>
                                        <td align="left" colspan="2">
                                            <asp:Button ID="LoginButton" runat="server" CommandName="Login" Text="Выполнить вход" ValidationGroup="Login1" BackColor="YellowGreen" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </LayoutTemplate>
            </asp:Login>
          </div>
</asp:Content>
