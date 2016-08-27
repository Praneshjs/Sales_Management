<%@ Page Language="C#" AutoEventWireup="true" Title="Profile" MasterPageFile="~/Sales/Sale.master"
    CodeFile="Profile.aspx.cs" Inherits="Sales_Profile" %>

<asp:Content ID="headContent" runat="server" ContentPlaceHolderID="head">
    <style type="text/css">
        .Freezing {
            position: relative;
            top: expression(this.offsetParent.scrollTop);
            z-index: 10;
        }
    </style>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="Body">
    <div class="container">
        <h3>Profile</h3>
        <asp:ValidationSummary ID="ProfileValidation" runat="server" ValidationGroup="ReportGroup" ShowMessageBox="false" ShowSummary="false" />
        <asp:HiddenField ID="hdnProfileID" runat="server" Value="0" />
        <div class="form-horizontal">
            <div id="errorMessage" runat="server"></div>
            <div class="form-group">
                <label class="control-label col-lg-2" for="email">FullName*</label>
                <div class="col-lg-4">
                    <asp:TextBox ID="txtFullName" CssClass="form-control" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="ReqFullName" ForeColor="Red" ValidationGroup="ReportGroup" ErrorMessage="Full name is required"
                        ControlToValidate="txtFullName" runat="server"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="form-group">
                <label class="control-label col-lg-2" for="email">UserName*</label>
                <div class="col-lg-4">
                    <asp:TextBox ID="txtUserName" CssClass="form-control" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="ReportGroup" ErrorMessage="User name is required"
                        ControlToValidate="txtUserName" runat="server" ForeColor="Red"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="form-group">
                <label class="control-label col-lg-2" for="email">Password*</label>
                <div class="col-lg-4">
                    <asp:TextBox ID="txtPassword" CssClass="form-control" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" BorderColor="Red" ValidationGroup="ReportGroup" ErrorMessage="Password is required"
                        ControlToValidate="txtPassword" runat="server" ForeColor="Red"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="form-group">
                <label class="control-label col-lg-2" for="email">Confirm Password*</label>
                <div class="col-lg-4">
                    <asp:TextBox ID="txtConfirmPass" CssClass="form-control" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ValidationGroup="ReportGroup" ErrorMessage="Confirm Password is required"
                        ControlToValidate="txtConfirmPass" runat="server" ForeColor="Red"></asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="customvalidate" ValidationGroup="ReportGroup" Display="None"
                        ControlToValidate="txtConfirmPass" runat="server" ControlToCompare="txtPassword"
                        ErrorMessage="Password and confirm password does not match"></asp:CompareValidator>
                </div>
            </div>
            <div class="form-group">
                <label class="control-label col-lg-2" for="email">Date of Join*</label>
                <div class="col-lg-4">
                    <asp:TextBox ID="txtDateofJoin" Wrap="true" CssClass="form-control datepicker" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ValidationGroup="ReportGroup" ErrorMessage="Date of Join is required"
                        ControlToValidate="txtDateofJoin" runat="server" ForeColor="Red" BorderColor="Red"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="form-group">
                <label class="control-label col-lg-2" for="email">Date of Exit</label>
                <div class="col-lg-4">
                    <asp:TextBox ID="txtExitDate" CssClass="form-control datepicker" runat="server" Display="None"></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <label class="control-label col-lg-2" for="email">Is Manager</label>
                <div class="col-lg-4">
                    <asp:CheckBox ID="chkManager" CssClass="checkbox-inline" runat="server"></asp:CheckBox>
                </div>
            </div>
            <div class="form-group">
                <label class="control-label col-lg-2" for="email">Access Rights</label>
                <div class="col-lg-4">
                    <asp:CheckBoxList ID="chkAccessRightsList" CssClass="checkbox-inline" runat="server">
                        <asp:ListItem Text="Dashboard" Value="1"></asp:ListItem>
                        <asp:ListItem Text="Reports" Value="2"></asp:ListItem>
                        <asp:ListItem Text="POS" Value="3"></asp:ListItem>
                        <asp:ListItem Text="Profile" Value="4"></asp:ListItem>
                        <asp:ListItem Text="Inventory" Value="5"></asp:ListItem>
                    </asp:CheckBoxList>
                </div>
            </div>
            <div class="form-group">
                <div class="col-sm-offset-2 col-lg-4">
                    <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Submit" ValidationGroup="ReportGroup"
                        CssClass="btn btn-success btn-group-xs" />
                </div>
            </div>
        </div>

        <asp:Panel ID="pnlProfile" runat="server" Style="height: 300px; overflow-y: auto;">
            <asp:GridView ID="gvProfile" runat="server" DataKeyNames="Id" OnRowCommand="gvProfile_RowCommand"
                CssClass="table table-hover table-responsive table-bordered" AutoGenerateColumns="false">
                <HeaderStyle CssClass="Freezing" />

                <EmptyDataTemplate>
                    No Data Found
                </EmptyDataTemplate>
                <Columns>
                    <asp:BoundField HeaderText="ID#" DataField="Id" />
                    <asp:BoundField HeaderText="Full Name" DataField="FullName" />
                    <asp:BoundField HeaderText="Join Date" DataField="JoinDate" />
                    <asp:BoundField HeaderText="IsManager" DataField="IsManager" />
                    <asp:BoundField HeaderText="IsUser" DataField="IsUser" />
                    <asp:TemplateField HeaderText="Select">
                        <ItemTemplate>
                            <asp:LinkButton ID="Button1" runat="server" CausesValidation="false" CommandName="ViewProfile"
                                Text="View" CommandArgument='<%# Eval("Id") %>'><span class="fa fa-2x fa-pencil-square-o"></span></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </asp:Panel>
    </div>
     <script type="text/javascript">
        $(document).ready(function () {
            $('.datepicker').datepicker({
                format: "dd-mm-yyyy",
                autoclose: true
            });
        });
    </script>
</asp:Content>
