<%@ Page Title="Admin Login" Language="C#" MasterPageFile="~/AdminMaster.master" AutoEventWireup="true" CodeBehind="AdminLogin.aspx.cs" Inherits="PopMeals_WebApp.AdminPages.AdminLogin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="login-container">
        <h2>Admin Login</h2>
        <!-- Label for Error Message -->
        <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label><br />

        <!-- Email Input -->
        <asp:TextBox ID="txtEmail" runat="server" placeholder="Enter Email" CssClass="form-control"></asp:TextBox><br />

        <!-- Password Input -->
        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" placeholder="Enter Password" CssClass="form-control"></asp:TextBox><br />

        <!-- Login Button -->
        <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" CssClass="btn-login" />
    </div>
</asp:Content>

