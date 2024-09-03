<%@ Page Title="Unos Uputa" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="UputUnos.aspx.cs" Inherits="KorisnickiInterfejs.UputUnos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
    .style1
    {
        width: 423px;
    }
    .style2
    {
        width: 342px;
        text-align: right;
    }
    .style3
    {
        width: 423px;
        font-size: large;
    }
    .style4
    {
        font-size: large;
    }
    .style5
    {
        width: 342px;
        font-size: large;
        text-align: right;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table style="width:100%;">
    <tr>
        <td class="style5">
            &nbsp;</td>
        <td class="style3">
            <strong>UNOS UPUTA</strong></td>
        <td class="style4">
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style2">
            &nbsp;</td>
        <td class="style1">
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style2">
            <asp:Label ID="Label1" runat="server" Text="ID uputa: "></asp:Label>
        </td>
        <td class="style1">
            <asp:TextBox ID="txbID" runat="server"></asp:TextBox>
        </td>
        <td>
            &nbsp;</td>
    </tr>
        <tr>
        <td class="style2">
            <asp:Label ID="Label8" runat="server" Text="Jmbg pacijenta: "></asp:Label>
        </td>
        <td class="style1">
            <asp:TextBox ID="txbJmbgP" runat="server"></asp:TextBox>
        </td>
        <td>
            &nbsp;</td>
    </tr>
      <tr>
        <td class="style2">
            <asp:Label ID="Label5" runat="server" Text="Ime:"></asp:Label>
        </td>
        <td class="style1">
            <asp:TextBox ID="txbIme" runat="server"></asp:TextBox>
        </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style2">
            <asp:Label ID="Label2" runat="server" Text="Prezime"></asp:Label>
        </td>
        <td class="style1">
            <asp:TextBox ID="txbPrezime" runat="server"></asp:TextBox>
        </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style2">
            <asp:Label ID="Label6" runat="server" Text="Datum Uputa:"></asp:Label>
        </td>
        <td class="style1">
            <asp:TextBox ID="txbDatumUputa" runat="server" TextMode="Date"></asp:TextBox>
        </td>
        <td>
            &nbsp;</td>
    </tr>
         <tr>
        <td class="style2">
            <asp:Label ID="Label7" runat="server" Text="Pol:"></asp:Label>
        </td>
        <td class="style1">
            <asp:DropDownList ID="ddlPol" runat="server" Height="16px" Width="233px">
                <asp:ListItem Text="Izaberite..." Value="Izaberite..."></asp:ListItem>
                <asp:ListItem Text="Muski" Value="Muski"></asp:ListItem>
                <asp:ListItem Text="Zenski" Value="Zenski"></asp:ListItem>
            </asp:DropDownList>
        </td>
        <td>
            &nbsp;</td>
    </tr>
        <tr>
        <td class="style2">
            <asp:Label ID="Label3" runat="server" Text="Dijagnoza:"></asp:Label>
        </td>
        <td class="style1">
            <asp:TextBox ID="txbDijagnoza" runat="server"></asp:TextBox>
        </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style2">
            <asp:Label ID="Label4" runat="server" Text="Doktor:"></asp:Label>
        </td>
        <td class="style1">
            <asp:DropDownList ID="ddlDoktor" runat="server" Height="16px" Width="233px">
            </asp:DropDownList>
        </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style2">
            &nbsp;</td>
        <td class="style1">
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style2">
            &nbsp;</td>
        <td class="style1">
            <asp:Label ID="lblStatus" runat="server" Text="STATUS:"></asp:Label>
        </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style2">
            &nbsp;</td>
        <td class="style1">
            <asp:Button ID="btnSnimi" runat="server" Text="SNIMI" Width="69px" 
                onclick="btnSnimi_Click" CssClass="customButton"/>
            <asp:Button ID="btnPonisti" runat="server" Text="PONISTI" 
                onclick="btnPonisti_Click" CssClass="customButton"/>
        </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style2">
            &nbsp;</td>
        <td class="style1">
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
</table>
</asp:Content>
