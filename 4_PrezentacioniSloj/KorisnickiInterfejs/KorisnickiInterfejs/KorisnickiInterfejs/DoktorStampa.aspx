<%@ Page Title="Informacije o Doktorima" Language="C#" MasterPageFile="~/StampaZaglavlje.Master" AutoEventWireup="true" CodeBehind="DoktorStampa.aspx.cs" Inherits="KorisnickiInterfejs.DoktorStampa" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style6
        {
            width: 500px;       

        }
        .style7
        {
            color: #0D47A1;
        }
        .style8
        {
            font-size: large;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table style="width:100%;">
        <tr>
            <td class="style6">
                <span class="style8">
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style6">
                &nbsp;</td>
            <td class="style7">
                <strong>
                <asp:Label ID="lblNaslov" runat="server" Text="SPISAK DOKTORA"></asp:Label>
                </strong>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td class="style6">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style6">
                &nbsp;</td>
            <td>
                <asp:GridView ID="gvspisakDoktora" runat="server" Height="286px" Width="433px">
                </asp:GridView>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style6">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style6">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>
