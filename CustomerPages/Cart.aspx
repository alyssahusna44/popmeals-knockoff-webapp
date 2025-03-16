<%@ Page Title="Cart" Language="C#" MasterPageFile="~/CustomerMaster.master" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="PopMeals_WebApp.Cart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Your Cart</h2>
    <asp:GridView ID="gvCart" runat="server" AutoGenerateColumns="False" OnRowCommand="gvCart_RowCommand" CssClass="cart-grid" DataKeyNames="MenuItemID">
        <Columns>
            <asp:BoundField DataField="Name" HeaderText="Item Name" />
            <asp:BoundField DataField="Price" HeaderText="Price (RM)" DataFormatString="{0:N2}" />
            <asp:TemplateField HeaderText="Quantity">
                <ItemTemplate>
                    <asp:TextBox ID="txtQuantity" runat="server" Text='<%# Bind("Quantity") %>' CssClass="quantity-box" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Total (RM)">
                <ItemTemplate>
                    <asp:Label ID="lblTotalPrice" runat="server" Text='<%# Eval("Total", "{0:N2}") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Button ID="btnRemove" runat="server" CommandName="Remove" CommandArgument='<%# Eval("MenuItemID") %>' Text="Remove" CssClass="remove-btn" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>

    <div class="cart-summary">
        <h3>Total: RM <asp:Label ID="lblGrandTotal" runat="server"></asp:Label></h3>
    </div>

    <div class="cart-actions">
        <asp:Button ID="btnUpdateCart" runat="server" Text="Update Cart" OnClick="btnUpdateCart_Click" CssClass="btn-update" />
        <asp:Button ID="btnCheckout" runat="server" Text="Proceed to Checkout" OnClick="btnCheckout_Click" CssClass="btn-checkout" />
    </div>
</asp:Content>
