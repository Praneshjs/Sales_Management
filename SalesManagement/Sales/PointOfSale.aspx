<%@ Page Language="C#" AutoEventWireup="true" Title="POS" MasterPageFile="~/Sales/Sale.master"
    CodeFile="PointOfSale.aspx.cs" Inherits="Sales_PointOfSale" %>


<asp:Content ID="headContent" runat="server" ContentPlaceHolderID="head">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="Body">
    <div class="container">
        <h3>Point Of Sale</h3>
        <asp:ValidationSummary ID="ProfileValidation" runat="server" ValidationGroup="ReportGroup" ShowMessageBox="false" ShowSummary="false" />
        <asp:HiddenField ID="hdnInventoryID" runat="server" Value="0" />
        <div id="errorMessage" runat="server"></div>
        <div class="form-inline">
            <div class="form-group row">
                <label>Product Name*</label>
                <asp:TextBox ID="txtProductName" CssClass="form-control textboxAuto" Font-Size="12px" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="ReqFullName" ForeColor="Red" ValidationGroup="ReportGroup" ErrorMessage="Product name is required"
                    ControlToValidate="txtProductName" runat="server"></asp:RequiredFieldValidator>
            </div>
            <div class="form-group">
                <label>Unit Price*</label>
                <asp:TextBox ReadOnly="true" ID="txtUnitPrice" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
        </div>
        <br />
        <div class="form-inline">
            <div class="form-group">
                <label>Quantity*</label>
                <asp:TextBox ID="txtQuantity" TextMode="Number" onkeyup="TotalCost();" CssClass="form-control" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="ReportGroup" ErrorMessage="Quantiy is required"
                    ControlToValidate="txtQuantity" runat="server" ForeColor="Red"></asp:RequiredFieldValidator>
            </div>
            <div class="form-group">
                <label>Quantity Cost</label>
                <asp:TextBox ID="txtQuantiyCost" ReadOnly="true" CssClass="form-control" runat="server"></asp:TextBox>
            </div>

            <asp:Button ID="btnAddToPurchase" runat="server" OnClick="btnAddToPurchase_Click" Text="Add" ValidationGroup="ReportGroup" CssClass="btn btn-success btn-group-xs" />
            <asp:Button ID="btnClear" Text="Clear" runat="server" OnClick="btnClear_Click" CssClass="btn btn-warning" />
        </div>
        <div class="form-group-lg">
            <h4>Sale Detailes</h4>

            <asp:Table ID="saleTable" CssClass="table table-bordered table-hover table-responsive" runat="server" Width="100%">
                <asp:TableRow>
                    <asp:TableCell>Item No.</asp:TableCell>
                    <asp:TableCell>Name</asp:TableCell>
                    <asp:TableCell>Unit Price</asp:TableCell>
                    <asp:TableCell>Quantity</asp:TableCell>
                    <asp:TableCell>Quantity Cost</asp:TableCell>
                </asp:TableRow>
            </asp:Table>
        </div>
        <asp:Button ID="Button1" runat="server" OnClick="btnCheckOut_Click" Text="CheckOut" ValidationGroup="ReportGroup" CssClass="btn btn-success btn-group-xs" />
    </div>
    <link href="../Contents/Style/jquery-ui.css" rel="stylesheet" />
    <script src="../Contents/Script/jquery-1.9.1.js"></script>
    <script src="../Contents/Script/jquery-ui.js"></script>

    <script type="text/javascript">
        $(function () {
            $('#<%=txtProductName.ClientID%>').autocomplete({
                    source: function (request, response) {
                        $.ajax({
                            url: "PointOfSale.aspx/GetProuctName",
                            data: "{ 'pre':'" + request.term + "'}",
                            dataType: "json",
                            type: "POST",
                            contentType: "application/json; charset=utf-8",
                            success: function (data) {
                                response($.map(data.d, function (item) {
                                    return {
                                        ProductName: item.ProductName,
                                        UnitPrice: item.UnitPrice,
                                        json: item
                                    }
                                }))
                            },
                            error: function (XMLHttpRequest, textStatus, errorThrown) {
                                alert(textStatus);
                            }
                        });
                    },
                    focus: function (event, ui) {
                        $('#<%=txtProductName.ClientID%>').val(ui.item.ProductName);
                        return false;
                    },
                    select: function (event, ui) {
                        $('#<%=txtProductName.ClientID%>').val(ui.item.ProductName);
                        $('#<%=txtUnitPrice.ClientID%>').val(ui.item.UnitPrice);
                        return false;
                    },
                }).data("ui-autocomplete")._renderItem = function (ul, item) {
                    return $("<li>")
                    .append("<a>Product:" + item.ProductName + "<br>Unit Price: " + item.UnitPrice + "</a>")
                    .appendTo(ul);
                };
            });

            function TotalCost() {
                $('#<%=txtQuantiyCost.ClientID%>').val($('#<%=txtUnitPrice.ClientID%>').val() * $('#<%=txtQuantity.ClientID%>').val());
        }
    </script>
</asp:Content>
