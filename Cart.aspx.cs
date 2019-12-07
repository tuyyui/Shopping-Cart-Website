using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Cart : System.Web.UI.Page
{
    private CartItemList cart;
    protected void Page_Load(Object sender, EventArgs e)
    {
        cart = CartItemList.GetCart();
        if (!IsPostBack)
            this.DisplayCart();
    }
   private void DisplayCart()
    {
        lstCart.Items.Clear();
        CartItem item;
        for (int i = 0; i < cart.Count; i++)
        {
            item = cart[i];
            lstCart.Items.Insert(i, item.ToString());
        }
    }
    protected void btnRemove_Click(object sender, EventArgs e)
    {
        if (cart.Count > 0)
        {
            if (lstCart.SelectedIndex > -1)
            {
                lstCart.SelectedValue.Remove(lstCart.SelectedIndex);
            }
            else
                lblMessage.Text = "Please select Item you wish to remove.";
        }
    }
    protected void btnEmpty_Click(object sender, EventArgs e)
    {
        if (cart.Count > 0)
        {
            lstCart.Items.Clear();
            cart.Clear();
        }
    }
    protected void btnCheckout_Click(object sender, EventArgs e)
    {
        lblMessage.Text = "Sorry that function has yet to be implmented.";
    }
}