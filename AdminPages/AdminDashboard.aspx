<%@ Page Title="Admin Dashboard" Language="C#" MasterPageFile="~/AdminMaster.master" AutoEventWireup="true" CodeBehind="AdminDashboard.aspx.cs" Inherits="PopMeals_WebApp.AdminPages.AdminDashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="dashboard-container">
        <h2>Admin Dashboard</h2>

        <!-- Welcome Label -->
        <asp:Label ID="lblWelcome" runat="server" CssClass="welcome-label"></asp:Label>

        <!-- Notifications Section -->
        <div class="notifications">
            <h2>Notifications</h2>
            <!-- Label for No Notifications -->
            <asp:Label ID="lblNoNotifications" runat="server" CssClass="no-notifications"></asp:Label>
            <!-- Repeater for Notifications -->
            <asp:Repeater ID="rptNotifications" runat="server">
                <HeaderTemplate>
                    <ul>
                </HeaderTemplate>
                <ItemTemplate>
                    <li>
                        <strong>Order ID:</strong> <%# Eval("OrderID") %>, 
                        <strong>Customer:</strong> <%# Eval("CustomerName") %>, 
                        <strong>Status:</strong> <%# Eval("OrderStatus") %>
                    </li>
                </ItemTemplate>
                <FooterTemplate>
                    </ul>
                </FooterTemplate>
            </asp:Repeater>
        </div>

        <!-- Logout Button -->
        <asp:Button ID="btnLogout" runat="server" Text="Logout" OnClick="btnLogout_Click" CssClass="btn-logout" />
    </div>
</asp:Content>

