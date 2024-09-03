<%@ Page Title="Izmena I Brisanje Doktora - Detalji" Language="C#" MasterPageFile="~/Admin.Master"
     AutoEventWireup="true" CodeBehind="DoktorDetaljiEdit.aspx.cs" Inherits="KorisnickiInterfejs.DoktorDetaljiEdit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
<style type="text/css">
    .style1
    {
         width: 275px;
        text-align: right;
    }
    .style2
    {
        width: 400px;
        padding:10px;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table style="width:100%;">
        <tr>
            <td class="style1">&nbsp;</td>
            <td class="style2"><h3><strong>DOKTOR - DETALJNI PRIKAZ ZA EDITOVANJE</strong></h3></td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="style1">Jmbg:</td>
            <td class="style2">
                <asp:TextBox ID="txbJmbg" runat="server" Enabled="False"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="style1">Ime:</td>
            <td class="style2">
                <asp:TextBox ID="txbIme" runat="server" Enabled="False"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="style1">Prezime:</td>
            <td class="style2">
                <asp:TextBox ID="txbPrezime" runat="server" Enabled="False"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="style1">&nbsp;</td>
            <td class="style2">
                <asp:Label ID="lblStatus" runat="server" Text="Status:"></asp:Label>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="style1">&nbsp;</td>
            <td class="style2">
                <asp:Button ID="btnObrisi" runat="server" Text="OBRISI" 
                     CssClass="customButton" onclick="btnObrisi_Click" />
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="style1">&nbsp;</td>
            <td class="style2">
                <asp:Button ID="btnIzmeni" runat="server" Text="Omoguci izmenu" 
                     CssClass="customButton" onclick="btnIzmeni_Click" Width="130px" />
                <asp:Button ID="btnSnimiIzmenu" runat="server" onclick="btnSnimiIzmenu_Click" Text="SNIMI IZMENU"
                     CssClass="customButton"/>
            </td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>
