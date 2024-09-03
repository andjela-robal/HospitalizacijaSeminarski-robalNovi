<%@ Page Title="Unos Doktora" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="DoktorUnos.aspx.cs" Inherits="KorisnickiInterfejs.DoktorUnos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style1
        {
            width: 320px;
            text-align: right;
            padding: 10px;
        }
        .style2
        {
            width: 320px;
            text-align: right;
            font-weight: bold;
            padding:20px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table style="width:100%;">
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td>
                <h3><strong>UNOS NOVOG DOKTORA</strong></h3></td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style1">
                Jmbg: </td>
            <td>
                <asp:TextBox ID="txbJmbg" runat="server"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style1">
                Ime:</td>
            <td>
                <asp:TextBox ID="txbIme" runat="server"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style1">
                Prezime:</td>
            <td>
                <asp:TextBox ID="txbPrezime" runat="server"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style1">
                &nbsp;</td>
            <td>
                <asp:Label ID="lblStatus" runat="server" Text="status"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style1">
                &nbsp;</td>
            <td>
                <asp:Button ID="btnSnimi" runat="server" onclick="btnSnimi_Click" Text="SNIMI" 
                    CssClass="customButton" Width="90px"/>
                <asp:Button ID="btnOdustani" runat="server" onclick="btnOdustani_Click" 
                    Text="ODUSTANI"  CssClass="customButton" />
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style1">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>