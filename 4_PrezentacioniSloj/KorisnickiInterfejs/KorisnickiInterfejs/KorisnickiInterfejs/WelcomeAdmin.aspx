<%@ Page Title="Pocetna Strana Admina" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="WelcomeAdmin.aspx.cs" Inherits="KorisnickiInterfejs.WelcomeAdmin" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <style type="text/css">
        .customParagraph {
            font-size: 1.4em;
            padding-top: 40px;
        }
    </style>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <p class="customParagraph">
        DOBRODOSLI, ADMINISTRATORE
        <asp:Label ID="lblImePrezimeAdmina" runat="server" Text="Ime i prezime admina"></asp:Label>
&nbsp;!</p>
</asp:Content>
