<%@ Page Title="View Sales" Language="C#" MasterPageFile="~/AdminMaster.master" AutoEventWireup="true" CodeBehind="AdminSales.aspx.cs" Inherits="PopMeals_WebApp.AdminPages.AdminSales" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Sales Data</h2>
    <asp:GridView ID="gvSalesData" runat="server" AutoGenerateColumns="true" CssClass="sales-grid" />
</asp:Content>

