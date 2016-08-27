using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Web.Script.Services;
using System.Configuration;
public partial class Sales_PointOfSale : BasePage
{
    public int counter = 0;
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnCheckOut_Click(object sender, EventArgs e)
    {

    }

    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public static List<Product> GetProuctName(string pre)
    {
        List<Product> possibleProduct = new List<Product>();
        using (SalesContextDataContext dc = new SalesContextDataContext(ConfigurationManager.ConnectionStrings["SalesConnectionString"].ConnectionString))
        {
            possibleProduct = (from a in dc.Products
                               where a.ProductName.StartsWith(pre)
                               select a).ToList();
        }
        return possibleProduct;
    }
    protected void btnAddToPurchase_Click(object sender, EventArgs e)
    {
        counter++;
        TableRow row = new TableRow();
        TableCell itemNo = new TableCell();
        itemNo.Text = counter.ToString();
        row.Cells.Add(itemNo);

        TableCell productName = new TableCell();
        productName.Text = txtProductName.Text;
        row.Cells.Add(productName);
        
        TableCell unitPrie = new TableCell();
        unitPrie.Text = txtUnitPrice.Text;
        row.Cells.Add(unitPrie);
        
        TableCell quantity = new TableCell();
        quantity.Text = txtQuantity.Text;
        row.Cells.Add(quantity);
        
        TableCell quantityCost = new TableCell();
        quantityCost.Text = txtQuantiyCost.Text;
        row.Cells.Add(quantityCost);
        saleTable.Rows.Add(row);

        btnClear_Click(null,null);
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        txtProductName.Text = string.Empty;
        txtUnitPrice.Text = string.Empty;
        txtQuantity.Text = string.Empty;
        txtQuantiyCost.Text = string.Empty;
    }
}