<%@ Page Title="Manage Orders" Language="C#" MasterPageFile="~/AdminMaster.master" AutoEventWireup="true" CodeBehind="AdminOrders.aspx.cs" Inherits="PopMeals_WebApp.AdminPages.AdminOrders" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Manage Orders</h1>
    <asp:GridView 
        ID="gvOrders" 
        runat="server" 
        AutoGenerateColumns="False" 
        DataKeyNames="OrderID" 
        OnRowCommand="gvOrders_RowCommand" 
        CssClass="orders-grid">
        <Columns>
            <!-- Order ID -->
            <asp:BoundField DataField="OrderID" HeaderText="Order ID" />

            <!-- Customer Name -->
            <asp:BoundField DataField="CustomerName" HeaderText="Customer Name" />

            <!-- Order Date -->
            <asp:BoundField DataField="OrderDate" HeaderText="Order Date" DataFormatString="{0:yyyy-MM-dd}" />

            <!-- Order Status -->
            <asp:TemplateField HeaderText="Order Status">
                <ItemTemplate>
                    <asp:DropDownList ID="ddlOrderStatus" runat="server">
                        <asp:ListItem Text="Pending" Value="Pending"></asp:ListItem>
                        <asp:ListItem Text="Processing" Value="Processing"></asp:ListItem>
                        <asp:ListItem Text="Completed" Value="Completed"></asp:ListItem>
                        <asp:ListItem Text="Cancelled" Value="Cancelled"></asp:ListItem>
                    </asp:DropDownList>
                </ItemTemplate>
            </asp:TemplateField>

            <!-- Update Button -->
            <asp:ButtonField CommandName="UpdateStatus" Text="Update" />
        </Columns>
    </asp:GridView>
</asp:Content>




