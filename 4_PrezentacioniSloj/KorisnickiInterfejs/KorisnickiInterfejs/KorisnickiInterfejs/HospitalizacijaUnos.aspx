<%@ Page Title="Unos Hospitalizacije" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="HospitalizacijaUnos.aspx.cs" Inherits="KorisnickiInterfejs.HospitalizacijaUnos" %>
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
            <strong>UNOS HOSPITALIZACIJA</strong></td>
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
            <asp:Label ID="Label1" runat="server" Text="ID hospitalizacije: "></asp:Label>
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
            <asp:Label ID="Label6" runat="server" Text="Datum Prijema:"></asp:Label>
        </td>
        <td class="style1">
            <asp:TextBox ID="txbDatumPrijema" runat="server" TextMode="Date"></asp:TextBox>
        </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style2">
            <asp:Label ID="Label2" runat="server" Text="Datum Otpusta:"></asp:Label>
        </td>
        <td class="style1">
            <asp:TextBox ID="txbDatumOtpusta" runat="server" TextMode="Date"></asp:TextBox>
        </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style2">
            <asp:Label ID="Label4" runat="server" Text="ID uputa:"></asp:Label>
        </td>
        <td class="style1">
            <asp:DropDownList ID="ddlIDUput" runat="server" Height="16px" Width="233px" AutoPostBack="True" OnSelectedIndexChanged="ddlIDUput_SelectedIndexChanged">
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
