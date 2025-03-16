<%@ Page Title="My Orders" Language="C#" MasterPageFile="~/CustomerMaster.master" AutoEventWireup="true" CodeBehind="MyOrders.aspx.cs" Inherits="PopMeals_WebApp.MyOrders" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>My Orders</h2>

    <asp:GridView ID="gvOrders" runat="server" AutoGenerateColumns="False" CssClass="orders-grid" OnRowCommand="gvOrders_RowCommand">
        <Columns>
            <asp:BoundField DataField="OrderID" HeaderText="Order ID" />
            <asp:BoundField DataField="OrderDate" HeaderText="Order Date" DataFormatString="{0:yyyy-MM-dd}" />
            <asp:BoundField DataField="OrderTime" HeaderText="Order Time" DataFormatString="{0:hh\\:mm}" />
            <asp:BoundField DataField="OrderStatus" HeaderText="Status" />
            <asp:BoundField DataField="TotalPrice" HeaderText="Total (RM)" DataFormatString="{0:N2}" />
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Button ID="btnViewDetails" runat="server" Text="View Details" CommandName="ViewDetails" CommandArgument='<%# Eval("OrderID") %>' CssClass="btn-details" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>

