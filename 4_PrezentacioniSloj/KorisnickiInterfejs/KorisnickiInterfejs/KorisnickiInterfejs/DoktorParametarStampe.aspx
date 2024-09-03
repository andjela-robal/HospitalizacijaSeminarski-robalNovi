<%@ Page Title="Doktori - Unos Parametara" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true"
     CodeBehind="DoktorParametarStampe.aspx.cs" Inherits="KorisnickiInterfejs.DoktorParametarStampa" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style1
        {
            text-align: right;
            width: 385px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<table style="width:100%;">
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
            <asp:Label ID="Label1" runat="server" style="text-align: right" 
                Text="Prezime doktora: "></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txbFilter" runat="server"></asp:TextBox>
        </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td colspan="3" style="height: 30px;">&nbsp;</td> 
    </tr>
<tr>
    <td colspan="3" style="text-align: center;">
        <asp:Button ID="btnFilterStampa" runat="server" onclick="btnFilterStampa_Click" 
            Text="PRIKAZI FILTRIRANI SPISAK ZA STAMPU" CssClass="customButton" Width="297px" />
    </td>
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
