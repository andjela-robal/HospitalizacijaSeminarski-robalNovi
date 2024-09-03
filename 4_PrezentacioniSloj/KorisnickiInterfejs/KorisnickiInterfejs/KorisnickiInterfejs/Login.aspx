<%@ Page Title="Prijavi se" Language="C#" MasterPageFile="~/Login.Master" AutoEventWireup="true" 
     CodeBehind="Login.aspx.cs" Inherits="KorisnickiInterfejs.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link href="~/Styles/Site.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .style1
        {
            width: 360px;
            text-align: right;
            margin-left: 160px;
        }
        .style2
        {
            font-size: medium;
        }
        .large-top-padding {
            padding-top: 100px; 
        }
         .customButton{
            background-color: #43A047 !important;
            color: #FFFFFF !important;
            border: none !important;
            padding: 10px 14px !important;
            text-align: center !important;
            text-decoration: none !important;
            display: inline-block !important;
            font-size: 1.1em !important;
            margin: 4px 2px !important;
            cursor: pointer !important;
            border-radius: 4px !important;
}

          .customButton:hover {
            background-color: #08380A !important;
}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table style="width:100%;">
        <tr>
            <td class="style1">
                &nbsp;</td>
            <td class="style2 large-top-padding">
                <strong>PRIJAVA KORISNIKA</strong></td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style1">
                <asp:Label ID="Label1" runat="server" Text="Korisnicko ime:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txbKorisnickoIme" runat="server" Width="165px"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style1">
                <asp:Label ID="Label2" runat="server" Text="Sifra:"></asp:Label>
            </td>
            <td>
        <asp:TextBox ID="txbSifra" runat="server" Width="165px" TextMode="Password"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style1">
                &nbsp;</td>
            <td>
                <asp:Label ID="lblStatus" runat="server" Text="Status"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
        </tr>
          <tr>
            <td class="style1">
                &nbsp;</td>
            <td style="margin-left: 40px">
                <asp:Button ID="btnPRIJAVA" runat="server" OnClick="btnPRIJAVA_Click" 
                    Text="PRIJAVA" CssClass="customButton"/>
                <asp:Button ID="btnOdustani" runat="server" OnClick="btnOdustani_Click" 
                    Text="Odustani" CssClass="customButton" />
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style1">
                &nbsp;</td>
            <td style="margin-left: 40px">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>
