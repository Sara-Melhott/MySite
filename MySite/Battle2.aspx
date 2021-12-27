<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Battle2.aspx.cs" Inherits="Battle2" MasterPageFile="~/Site.master"%>

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
                    <asp:DropDownList ID="DropDownList1" runat="server"></asp:DropDownList>
                </div>
                <div>
                    <asp:Label ID="Label5" runat="server" Text="Здесь будут драки!4"></asp:Label>
                </div>
            </div>
             <div class="TableRightCol">
                <div>
                    <asp:Label ID="Label4" runat="server" Text="Здесь будут драки!1"></asp:Label>
                </div>
            </div>
         </div>   
     </div>
</asp:Content>
