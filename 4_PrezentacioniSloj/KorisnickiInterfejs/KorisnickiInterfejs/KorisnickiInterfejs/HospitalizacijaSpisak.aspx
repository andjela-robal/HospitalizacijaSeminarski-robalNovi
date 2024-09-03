﻿<%@ Page Title="Spisak Hospitalizacija" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="HospitalizacijaSpisak.aspx.cs" Inherits="KorisnickiInterfejs.HospitalizacijaSpisak" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
    .style1
    {
        width: 174px;
    }
    .style2
    {
        width: 513px;
    }
    .style3
    {
        width: 513px;
        font-size: large;
        font-family: Arial;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table style="width:100%;">
    <tr>
        <td class="style1">
            &nbsp;</td>
        <td class="style3" style="padding-left: 150px; padding-top:20px;">
            <strong>SPISAK HOSPITALIZACIJA</strong></td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style1">
            &nbsp;</td>
        <td class="style2">
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style1">
            &nbsp;</td>
        <td class="style2">
            <asp:Label ID="Label1" runat="server" Text="JMBG PACIJENTA:"></asp:Label>
            <asp:TextBox ID="txbFilter" runat="server"></asp:TextBox>
            <asp:Button ID="btnFiltriraj" runat="server" Text="FILTRIRAJ" 
                onclick="btnFiltriraj_Click" CssClass="customButton" />
            <asp:Button ID="btnSvi" runat="server" Text="SVI" Width="97px" 
                onclick="btnSvi_Click" CssClass="customButton" />
        </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style1">
            &nbsp;</td>
        <td class="style2">       
                <asp:Label ID="lblStatus" runat="server" Text="Status:"></asp:Label>
                &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style1">
            &nbsp;</td>
        <td class="style2">
            <asp:GridView ID="gvHospitalizacije" runat="server" Height="199px" Width="484px">
            </asp:GridView>
        </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style1">
            &nbsp;</td>
        <td class="style2">
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style1">
            &nbsp;</td>
        <td class="style2">
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
</table>
</asp:Content>
