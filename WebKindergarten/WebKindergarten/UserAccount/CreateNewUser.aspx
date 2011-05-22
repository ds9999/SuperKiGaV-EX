<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreateNewUser.aspx.cs" Inherits="WebKindergarten.UserAccount.CreateNewUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style1
        {
            width: 180px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table style="width:100%;">
        <tr>
            <td class="style1">
                Username:</td>
            <td>
                <asp:TextBox ID="TxtUsername" runat="server" Width="290px"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style1">
                Vorname:</td>
            <td>
                <asp:TextBox ID="TxtVorname" runat="server" Width="290px"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style1">
                Nachname:</td>
            <td>
                <asp:TextBox ID="TxtNachname" runat="server" Width="290px"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style1">
                EMail:</td>
            <td>
                <asp:TextBox ID="TxtEmail" runat="server" Width="290px"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style1">
                Passwort:</td>
            <td>
                <asp:TextBox ID="TxtPasswort" runat="server" Width="290px"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style1">
                Passwort wiederholen:</td>
            <td>
                <asp:TextBox ID="TetPasswortWdh" runat="server" Width="290px"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
    <asp:Button ID="BtnSend" runat="server" onclick="BtnSend_Click" Text="Senden" />
</asp:Content>
