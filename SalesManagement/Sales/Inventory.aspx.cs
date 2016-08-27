using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Sales_Inventory : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        errorMessage.InnerHtml = string.Empty;
        if (!IsPostBack)
        {
            LoadProduct();
        }
    }

    protected void LoadProduct()
    {
        List<Product> userInfo = dc.Products.ToList();
        gvProduct.DataSource = userInfo;
        gvProduct.DataBind();
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        try
        {
            Product productInfo = new Product();
            if (btnAdd.Text == "Add")
            {
                dc.Products.InsertOnSubmit(productInfo);
                productInfo.ProductName = txtProductName.Text.Trim();
                productInfo.Quantity = Convert.ToInt16(txtQuantity.Text.Trim());
                productInfo.UnitPrice = Convert.ToDouble(txtUnitPrice.Text.Trim());
                productInfo.CreatedBy = AppSession.UserID;
                productInfo.CreatedOn = DateTime.Now;
            }
            else if (btnAdd.Text == "Edit")
            {
                productInfo = dc.Products.Where(s => s.Id == Convert.ToInt16(hdnInventoryID.Value)).SingleOrDefault();
                productInfo.ProductName = txtProductName.Text.Trim();
                productInfo.Quantity = Convert.ToInt16(txtQuantity.Text.Trim());
                productInfo.UnitPrice = Convert.ToDouble(txtUnitPrice.Text.Trim());
                productInfo.CreatedOn = DateTime.Now;
            }
            dc.SubmitChanges();
            LoadProduct();
            errorMessage.InnerHtml = "<div class='alert alert-success' role='alert'>Product added</div>";
            btnClear_Click(null,null);
        }
        catch (Exception ex)
        {
            errorMessage.InnerHtml = "<div class='alert alert-danger' role='alert'>Error: " + ex.Message + "</div>";
        }
    }
    protected void gvProduct_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName != "ViewProduct") return;
        hdnInventoryID.Value = e.CommandArgument.ToString();
        LoadProduct(Convert.ToInt32(e.CommandArgument));

    }

    protected void LoadProduct(int id)
    {
        Product productInfo = new Product();
        productInfo = dc.Products.Where(s => s.Id == id).SingleOrDefault();

        txtProductName.Text = productInfo.ProductName;
        txtQuantity.Text = productInfo.Quantity.ToString();
        txtUnitPrice.Text = productInfo.UnitPrice.ToString();
        btnAdd.Text = "Edit";
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        txtProductName.Text = string.Empty;
        txtQuantity.Text = string.Empty;
        txtUnitPrice.Text = string.Empty;
    }
}