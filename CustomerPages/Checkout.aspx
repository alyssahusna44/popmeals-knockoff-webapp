<%@ Page Title="Checkout" Language="C#" MasterPageFile="~/CustomerMaster.master" AutoEventWireup="true" CodeBehind="Checkout.aspx.cs" Inherits="PopMeals_WebApp.Checkout" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Checkout</h2>

    <h3>Order Summary</h3>
    <asp:GridView ID="gvCart" runat="server" AutoGenerateColumns="False" CssClass="cart-grid">
        <Columns>
            
            <asp:BoundField DataField="Name" HeaderText="Item Name" />
            <asp:BoundField DataField="Price" HeaderText="Price (RM)" DataFormatString="{0:N2}" />
            <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
            <asp:TemplateField HeaderText="Total (RM)">
                <ItemTemplate>
                    <asp:Label ID="lblTotalPrice" runat="server" Text='<%# Eval("Total", "{0:N2}") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>

    <div class="checkout-summary">
        <h3>Total Amount: RM <asp:Label ID="lblGrandTotal" runat="server"></asp:Label></h3>
    </div>

    <h3>Delivery Details</h3>
    <label>Name:</label>
    <asp:TextBox ID="txtName" runat="server" CssClass="form-control"></asp:TextBox><br />
    <label>Delivery Address:</label>
    <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control"></asp:TextBox><br />
    <label>Payment Method:</label>
    <asp:DropDownList ID="ddlPaymentMethod" runat="server" CssClass="form-control">
        <asp:ListItem Text="Online Banking" Value="Online Banking"></asp:ListItem>
        <asp:ListItem Text="e-Wallet" Value="e-Wallet"></asp:ListItem>
        <asp:ListItem Text="Card" Value="Card"></asp:ListItem>
    </asp:DropDownList><br />

    <asp:Button ID="btnPlaceOrder" runat="server" Text="Place Order" OnClick="btnPlaceOrder_Click" CssClass="btn-checkout" />

    <div id="thankYouModal" class="modal" style="display:none;">
        <div class="modal-content">
            <h2>Thank You for Your Order!</h2>
            <p>Your order has been placed successfully.</p>
            <asp:Button ID="btnGoToOrders" runat="server" Text="View My Orders" OnClick="btnGoToOrders_Click" CssClass="btn-modal" />
        </div>
    </div>
</asp:Content>
