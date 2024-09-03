<%@ Page Title="Pocetna Strana" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" 
     CodeBehind="Default.aspx.cs" Inherits="KorisnickiInterfejs._Default" %>

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
    Dobrodosli na početnu stranicu bolnice <strong>Mir I Zdravlje</strong>,
        <asp:Label ID="lblStatusKonekcije" runat="server" Text="STATUS KONEKCIJE"></asp:Label>
        !
    </p>
</asp:Content>
