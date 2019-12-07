using System;
using System.Web.UI;
using System.Data;
public partial class Order : System.Web.UI.Page
{
    
    private Product selectedProduct;
     protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            
            ddlProducts.DataBind();
            selectedProduct = this.GetSelectedProduct();
            //Showing the Product name, short Description, and Longdescription
            lblName.Text = selectedProduct.Name;
            lblShortDescription.Text = selectedProduct.ShortDescription;
            lblLongDescription.Text = selectedProduct.LongDescription;
            lblUnitPrice.Text = selectedProduct.UnitPrice.ToString("c") + " each";
            
            imgProduct.ImageUrl = "Images/Products/" + selectedProduct.ImageFile;
        }
    }

    
   

    protected void btnAdd_Click1(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            selectedProduct = this.GetSelectedProduct();
            CartItemList cart = CartItemList.GetCart();
            CartItem cartItem = cart[selectedProduct.ProductID];
            if (cartItem.Product != selectedProduct)
            {
                cart.AddItem(selectedProduct, 1);
            }
            else
            {
                cartItem.AddQuantity(1);
            }
            Console.WriteLine("PageLoad");
            Response.Redirect("Cart.aspx", false);
        }
    }

    private Product GetSelectedProduct()
    {
        DataView productsTable = (DataView)SqlDataSource2.Select(DataSourceSelectArguments.Empty);
        productsTable.RowFilter = "ProductID = '" + ddlProducts.SelectedValue + "'";
        DataRowView row = (DataRowView)productsTable[0];

       
        Product p = new Product();
        p.ProductID = row["ProductID"].ToString();
        p.Name = row["Name"].ToString();
        p.ShortDescription = row["ShortDescription"].ToString();
        p.LongDescription = row["LongDescription"].ToString();
        p.UnitPrice = (decimal)row["UnitPrice"];
        p.ImageFile = row["ImageFile"].ToString();
        return p;
    }
}
