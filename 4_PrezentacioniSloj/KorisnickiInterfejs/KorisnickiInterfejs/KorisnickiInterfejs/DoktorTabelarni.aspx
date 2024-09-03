<%@ Page Title="Tabelarni Prikaz Doktora" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="DoktorTabelarni.aspx.cs" Inherits="KorisnickiInterfejs.DoktorTabelarni" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
     <link href="~/Styles/Site.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .style1
        {
            width: 300px;
            text-align: right;
        }

    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table style="width:100%;">
        <tr>
            <td class="style1">
                &nbsp;</td>
            <td>
                <h3><strong>TABELARNI PRIKAZ DOKTORA</strong></h3></td>
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
        <tr>
            <td class="style1">
                Filter (prezime):</td>
            <td>
                <asp:TextBox ID="txbFilter" runat="server"></asp:TextBox>
                <asp:Button ID="btnFiltriraj" runat="server" onclick="btnFiltriraj_Click" 
                    Text="FILTRIRAJ" CssClass="customButton" />
                <asp:Button ID="btnSvi" runat="server" onclick="btnSvi_Click" Text="SVI" 
                   CssClass="customButton" Width="68px" />
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style1">
                &nbsp;</td>
            <td>
                <asp:Label ID="lblStatus" runat="server" Text="Status:"></asp:Label>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style1">
                &nbsp;</td>
            <td>
                <asp:GridView ID="gvSpisakDoktora" runat="server" Height="211px" Width="353px">
                </asp:GridView>
            </td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>
