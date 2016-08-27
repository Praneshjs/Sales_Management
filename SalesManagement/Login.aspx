<%@ Page Language="C#" Title="Sales Login" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Contents/Style/bootstrap.min.css" rel="stylesheet" />
    <link href="Contents/Style/font-awesome.min.css" rel="stylesheet" />
    <script src="Contents/Script/jquery.min.js"></script>
    <script src="Contents/Script/bootstrap.min.js"></script>
</head>
<body>
    <%--<div id="login-overlay" class="modal-form">
        <div class="modal-content">
            <div class="modal-header">
                <h4 class="modal-title" id="myModalLabel">Login to Sales Management</h4>
            </div>
            <div class="modal-body">
                <div class="row">
                    <div class="col-lg-4">
                        <div class="well">
                            <form id="loginForm" runat="server" novalidate="novalidate">
                                <asp:ValidationSummary ID="LoginValidaiton" runat="server" ValidationGroup="ReportGroup" ShowSummary="false" ShowMessageBox="true" />
                                <div id="errorMessage" runat="server"></div>
                                <div class="form-group">
                                    <label for="username" class="control-label">Username*</label>
                                    <asp:TextBox ID="txtUserName" CssClass="form-actions" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rqusername" runat="server" ValidationGroup="ReportGroup" ControlToValidate="txtUserName" ErrorMessage="User Name is required"></asp:RequiredFieldValidator>
                                </div>
                                <div class="form-group">
                                    <label for="password" class="control-label">Password*</label>
                                    <asp:TextBox ID="txtPassword" runat="server" CssClass="form-actions" TextMode="Password" ToolTip="Password" MaxLength="30"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="ReportGroup" ControlToValidate="txtPassword" ErrorMessage="Password is required"></asp:RequiredFieldValidator>
                                </div>
                                <div class="checkbox">
                                    <asp:CheckBox ID="chkRemember" runat="server" Text="Remember Me" />
                                </div>
                                <div class="form-group">
                                    <label for="username" class="control-label"></label>
                                    <asp:Button ID="btnLogin" runat="server" CssClass="btn btn-success btn-large" ValidationGroup="ReportGroup" OnClick="btnLogin_Click" Text="Log In" />
                                </div>
                            </form>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>--%>

    <div class="container">
        
        <div class="col-lg-6" style="border:2px solid #808080; margin-top:150px;">
            <h3>Sales Management Login</h3>
            <form class="form-horizontal" runat="server">
                <div id="errorMessage" runat="server"></div>
                <div class="form-group">
                    <label class="control-label col-lg-3" for="email">User Name</label>
                    <div class="col-lg-4">
                        <asp:TextBox ID="txtUserName" CssClass="form-control" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rqusername" runat="server" ValidationGroup="ReportGroup" ControlToValidate="txtUserName" ErrorMessage="User Name is required"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="form-group">
                    <label class="control-label col-lg-3" for="pwd">Password</label>
                    <div class="col-lg-4">
                        <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" TextMode="Password" ToolTip="Password" MaxLength="30"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="ReportGroup" ControlToValidate="txtPassword" ErrorMessage="Password is required"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="form-group">
                    <label class="control-label col-lg-3">Remember Me</label>
                    <div class="col-lg-4">
                        <asp:CheckBox ID="chkRemember" runat="server" Text="" />
                    </div>
                </div>
                <div class="form-group">
                    <label class="control-label col-lg-3"></label>
                    <div class="col-sm-offset-2 col-lg-4">
                        <asp:Button ID="btnLogin" runat="server" CssClass="btn btn-default btn-large" ValidationGroup="ReportGroup" OnClick="btnLogin_Click" Text="Log In" />
                    </div>
                </div>
            </form>
        </div>
    </div>
</body>
</html>
