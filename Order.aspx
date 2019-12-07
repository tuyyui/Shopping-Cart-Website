<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Order.aspx.cs" Inherits="Order" %>

<!DOCTYPE html>
<html>
<head id="Head1" runat="server">
    <title>COMP4280: Shopping Cart</title>
    <link href="Styles/Main.css" rel="stylesheet" />
    <link href="Styles/Order.css" rel="stylesheet" />
</head>
<body>
    <header><img src="Images/banner.jpg" alt="Halloween Store" /></header>

    <section>
    <form id="form1" runat="server">
        <label>Please select a product&nbsp;</label>
        <asp:DropDownList ID="ddlProducts" runat="server" AutoPostBack="True" DataSourceID="SqlDataSource2" DataTextField="Name" DataValueField="ProductID" >
        </asp:DropDownList>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString='<%$ ConnectionStrings:HalloweenConnectionString %>' SelectCommand="SELECT [ProductID], [Name], [ShortDescription], [LongDescription], [ImageFile], [UnitPrice] FROM [Products] ORDER BY [Name]"></asp:SqlDataSource>
        <br />
        <div id="productData">
            <asp:Label ID="lblName" runat="server"></asp:Label>
            <asp:Label ID="lblShortDescription" runat="server"></asp:Label>
            <asp:Label ID="lblLongDescription" runat="server"></asp:Label>
            <asp:Label ID="lblUnitPrice" runat="server"></asp:Label>

            <label id="lblQuantity">Quantity&nbsp;</label>
            <asp:TextBox ID="txtQuantity" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" CssClass="validator"
                    runat="server" ControlToValidate="txtQuantity" Display="Dynamic" 
                    ErrorMessage="Quantity is a required field."></asp:RequiredFieldValidator>
                <asp:RangeValidator ID="RangeValidator1" runat="server" CssClass="validator" 
                    ControlToValidate="txtQuantity" Display="Dynamic" 
                    ErrorMessage="Quantity must range from 1 to 500."
                    MaximumValue="500" MinimumValue="1" Type="Integer"></asp:RangeValidator><br />

            <asp:Button ID="btnAdd" runat="server" Text="Add to Cart" OnClick="btnAdd_Click1" />
            <asp:Button ID="btnCart" runat="server" Text="Go to Cart" CausesValidation="False" 
                PostBackUrl="~/Cart.aspx" />
        </div>
        <asp:Image ID="imgProduct" runat="server" />        
    </form>
    </section>
</body>
</html>