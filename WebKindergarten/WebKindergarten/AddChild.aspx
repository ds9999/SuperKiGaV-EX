<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddChild.aspx.cs" Inherits="WebKindergarten.AddChild" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table style="width:100%;">
        <tr>
            <td>
                Vorname:</td>
            <td>
                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator runat="server" id="reqVorname" controltovalidate="TextBox1" errormessage="Bitte Vornamen eingeben!" />
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                Nachname:</td>
            <td>
                <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator runat="server" id="RequiredFieldValidator2" controltovalidate="TextBox2" errormessage="Bitte Nachnamen eingeben!" />
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                Geburtstag:</td>
            <td>
                <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator runat="server" id="RequiredFieldValidator3" controltovalidate="TextBox3" errormessage="Bitte Geburtsdatum eingeben!" />
                <asp:CustomValidator runat="server" id="CustomFieldValidator3" OnServerValidate="CustomDateValidator_ServerValidate" controltovalidate="TextBox3" errormessage="Bitte gültiges Geburtsdatum eingeben!" />
            </td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
    <asp:Button ID="Button1" runat="server" onclick="Button1_Click" 
        Text="Erstellen" />
</asp:Content>
