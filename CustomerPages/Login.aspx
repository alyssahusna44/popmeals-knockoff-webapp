<%@ Page Title="Login" Language="C#" MasterPageFile="~/CustomerMaster.master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="PopMeals_WebApp.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Customer Login</h2>

    <div class="login-container">
        <label for="txtEmailPhone">Email or Phone Number:</label>
        <asp:TextBox ID="txtEmailPhone" runat="server" CssClass="form-control"></asp:TextBox><br />

        <label for="txtVerificationCode">Verification Code:</label>
        <asp:TextBox ID="txtVerificationCode" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox><br />

        <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" CssClass="btn-login" />
        <asp:Button ID="btnAdminLogin" runat="server" Text="Login as Admin" OnClick="btnAdminLogin_Click" CssClass="btn-admin-login" />
    </div>
</asp:Content>
