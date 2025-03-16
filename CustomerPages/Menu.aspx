<%@ Page Title="Menu" Language="C#" MasterPageFile="~/CustomerMaster.master" AutoEventWireup="true" CodeBehind="Menu.aspx.cs" Inherits="PopMeals_WebApp.Menu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Filter by Category</h2>

    <asp:DropDownList ID="ddlCategory" runat="server" AutoPostBack="true" CssClass="dropdown" OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged">
        <asp:ListItem Value="All">All</asp:ListItem>
        <asp:ListItem Value="Mac & Cheese Classics">Mac & Cheese Classics</asp:ListItem>
        <asp:ListItem Value="Nasi Nasi Nasi">Nasi Nasi Nasi</asp:ListItem>
        <asp:ListItem Value="Pasta">Pasta</asp:ListItem>
        <asp:ListItem Value="Kiddie Meals">Kiddie Meals</asp:ListItem>
        <asp:ListItem Value="Sauces & Sambals">Sauces & Sambals</asp:ListItem>
        <asp:ListItem Value="Snacks">Snacks</asp:ListItem>
        <asp:ListItem Value="Drinks">Drinks</asp:ListItem>
    </asp:DropDownList>

    <h2>Menu</h2>
    <asp:GridView ID="gvMenu" runat="server" AutoGenerateColumns="False" CssClass="gridview" OnRowCommand="gvMenu_RowCommand">
        <Columns>
            <asp:TemplateField HeaderText="Image">
                <ItemTemplate>
                    <img src='<%# ResolveUrl("~/" + Eval("ImageURL").ToString()) %>' alt="<%# Eval("Name") %>" class="menu-image" width="100" height="100"/>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:BoundField DataField="Name" HeaderText="Item Name" />
            <asp:BoundField DataField="Description" HeaderText="Description" />
            <asp:BoundField DataField="Price" HeaderText="Price (RM)" DataFormatString="{0:F2}" />

            <asp:TemplateField HeaderText="Action">
                <ItemTemplate>
                    <asp:Button ID="btnAddToCart" runat="server" Text="Add to Cart" CssClass="btn btn-add-cart" CommandName="AddToCart" CommandArgument='<%# Eval("MenuItemID") %>' />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>

