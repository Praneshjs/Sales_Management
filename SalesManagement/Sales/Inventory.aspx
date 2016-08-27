<%@ Page Language="C#" AutoEventWireup="true" Title="Inventory" MasterPageFile="~/Sales/Sale.master"
    CodeFile="Inventory.aspx.cs" Inherits="Sales_Inventory" %>

<asp:Content ID="headContent" runat="server" ContentPlaceHolderID="head">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="Body">
    <div class="container">
        <h3>New Product</h3>
        <asp:ValidationSummary ID="ProfileValidation" runat="server" ValidationGroup="ReportGroup" ShowMessageBox="false" ShowSummary="false" />
        <asp:HiddenField ID="hdnInventoryID" runat="server" Value="0" />
        <div class="form-horizontal">
            <div id="errorMessage" runat="server"></div>
            <div class="form-group">
                <label class="control-label col-lg-2" for="email">Product Name*</label>
                <div class="col-lg-4">
                    <asp:TextBox ID="txtProductName" CssClass="form-control" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="ReqFullName" ForeColor="Red" ValidationGroup="ReportGroup" ErrorMessage="Product name is required"
                        ControlToValidate="txtProductName" runat="server"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="form-group">
                <label class="control-label col-lg-2" for="email">Quantity*</label>
                <div class="col-lg-4">
                    <asp:TextBox ID="txtQuantity" TextMode="Number" CssClass="form-control" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="ReportGroup" ErrorMessage="Quantiy is required"
                        ControlToValidate="txtQuantity" runat="server" ForeColor="Red"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="form-group">
                <label class="control-label col-lg-2" for="email">Unit Price*</label>
                <div class="col-lg-4">
                    <asp:TextBox ID="txtUnitPrice" TextMode="Number" CssClass="form-control" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" BorderColor="Red" ValidationGroup="ReportGroup" ErrorMessage="Price is required"
                        ControlToValidate="txtUnitPrice" runat="server" ForeColor="Red"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="form-group">
                <div class="col-sm-offset-2 col-lg-4">
                    <asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click" Text="Add" ValidationGroup="ReportGroup"
                        CssClass="btn btn-success btn-group-xs" />
                    <asp:Button ID="btnClear" runat="server" OnClick="btnClear_Click" Text="Clear" ValidationGroup="ReportGroup"
                        CssClass="btn btn-warning btn-group-xs" />
                </div>
            </div>
        </div>
        <asp:Panel ID="pnlProduct" runat="server" Style="height: 200px; overflow-y: auto">
            <asp:GridView ID="gvProduct" runat="server" DataKeyNames="Id" OnRowCommand="gvProduct_RowCommand"
                CssClass="table table-hover table-responsive table-bordered" AutoGenerateColumns="false">
                <EmptyDataTemplate>
                    No Data Found
                </EmptyDataTemplate>
                <Columns>
                    <asp:BoundField HeaderText="ID#" DataField="Id" />
                    <asp:BoundField HeaderText="Product Name" DataField="ProductName" />
                    <asp:BoundField HeaderText="Available Quantiy" DataField="Quantity" />
                    <asp:BoundField HeaderText="Unit Price" DataField="UnitPrice" />
                    <asp:BoundField HeaderText="Add Date" DataField="CreatedOn" />
                    <asp:TemplateField HeaderText="Select">
                        <ItemTemplate>
                            <asp:LinkButton ID="Button1" runat="server" CausesValidation="false" CommandName="ViewProduct"
                                Text="View" CommandArgument='<%# Eval("Id") %>'><span class="fa fa-2x fa-pencil-square-o"></span></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </asp:Panel>
    </div>
</asp:Content>
