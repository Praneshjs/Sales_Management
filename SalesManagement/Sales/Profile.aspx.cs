using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Sales_Profile : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        errorMessage.InnerHtml = string.Empty;
        if (!IsPostBack)
        {
            errorMessage.InnerHtml = string.Empty;
            this.txtExitDate.Text = string.Empty;
            this.txtDateofJoin.Text = DateTime.Now.ToString(DateFormat);
            LoadProfile();
        }
        
        txtPassword.Attributes["type"] = "password";
        txtConfirmPass.Attributes["type"] = "password";
    }

    protected void LoadProfile()
    {
        List<Account> userInfo = dc.Accounts.ToList();
        gvProfile.DataSource = userInfo;
        gvProfile.DataBind();
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            Account userInfo = new Account();
            if (btnSubmit.Text == "Add")
            {
                if (dc.Accounts.Where(s => s.UserName == txtUserName.Text.Trim()).Any())
                {
                    errorMessage.InnerHtml = "<div class='alert alert-danger' role='alert'>User name already exist!</div>";
                    return;
                }
                dc.Accounts.InsertOnSubmit(userInfo);
                userInfo.FullName = txtFullName.Text.Trim();
                userInfo.UserName = txtUserName.Text.Trim();
                userInfo.Password = txtPassword.Text.Trim();
                userInfo.JoinDate = Convert.ToDateTime(txtDateofJoin.Text.Trim());
                if (txtExitDate.Text.Trim() != string.Empty)
                    userInfo.ExitDate = Convert.ToDateTime(txtExitDate.Text.Trim());
                else
                    userInfo.ExitDate = null;

                if (chkManager.Checked)
                {
                    userInfo.IsManager = true;
                    userInfo.IsUser = false;
                }
                else
                {
                    userInfo.IsManager = false;
                    userInfo.IsUser = true;
                }
                dc.SubmitChanges();
                int id = userInfo.Id;
                UserInRole accessDetail = null;
                List<ListItem> selected = chkAccessRightsList.Items.Cast<ListItem>().Where(li => li.Selected).ToList();
                foreach (var item in selected)
                {
                    accessDetail = new UserInRole();
                    dc.UserInRoles.InsertOnSubmit(accessDetail);
                    accessDetail.UserID = id;
                    accessDetail.RoleID = Convert.ToInt16(item.Value);
                    dc.SubmitChanges();
                }
                errorMessage.InnerHtml = "<div class='alert alert-success' role='alert'>Profile created</div>";
            }
            else if (btnSubmit.Text == "Edit")
            {
                userInfo = dc.Accounts.Where(s => s.Id == Convert.ToInt16(hdnProfileID.Value)).SingleOrDefault();
                userInfo.FullName = txtFullName.Text.Trim();
                userInfo.JoinDate = Convert.ToDateTime(txtDateofJoin.Text.Trim());
                if (txtExitDate.Text.Trim() != string.Empty)
                    userInfo.ExitDate = Convert.ToDateTime(txtExitDate.Text.Trim());
                else
                    userInfo.ExitDate = null;

                if (chkManager.Checked)
                {
                    userInfo.IsManager = true;
                    userInfo.IsUser = false;
                }
                else
                {
                    userInfo.IsManager = false;
                    userInfo.IsUser = true;
                }
                dc.SubmitChanges();
                int id = userInfo.Id;

                List<UserInRole> existingUserRoles = dc.UserInRoles.Where(s => s.UserID == id).ToList();
                dc.UserInRoles.DeleteAllOnSubmit(existingUserRoles);
                dc.SubmitChanges();

                UserInRole accessDetail = null;
                List<ListItem> selected = chkAccessRightsList.Items.Cast<ListItem>().Where(li => li.Selected).ToList();
                foreach (var item in selected)
                {
                    accessDetail = new UserInRole();
                    dc.UserInRoles.InsertOnSubmit(accessDetail);
                    accessDetail.UserID = id;
                    accessDetail.RoleID = Convert.ToInt16(item.Value);
                    dc.SubmitChanges();
                }
                errorMessage.InnerHtml = "<div class='alert alert-success' role='alert'>Profile Updated</div>";
            }
            LoadProfile();
        }
        catch (Exception ex)
        {
            errorMessage.InnerHtml = "<div class='alert alert-danger' role='alert'>Error: " + ex.Message + "</div>";
        }
    }
    protected void gvProfile_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName != "ViewProfile") return;

        LoadUserProfile(Convert.ToInt32(e.CommandArgument));
        hdnProfileID.Value = e.CommandArgument.ToString();
        btnSubmit.Text = "Edit";
    }

    protected void LoadUserProfile(int id)
    {
        Account userInfo = new Account();
        userInfo = dc.Accounts.Where(s => s.Id == id).SingleOrDefault();
        txtFullName.Text = userInfo.FullName;
        txtUserName.Text = userInfo.UserName;
        txtUserName.ReadOnly = true;
        this.txtPassword.Text = userInfo.Password.ToString();
        txtPassword.ReadOnly = true;
        this.txtConfirmPass.Text = userInfo.Password;
        txtConfirmPass.ReadOnly = true;
        this.txtDateofJoin.Text = userInfo.JoinDate.ToString().Split(' ')[0];

        if (userInfo.ExitDate != null)
            this.txtExitDate.Text = userInfo.ExitDate.ToString().Split(' ')[0];
        else
            this.txtExitDate.Text = string.Empty;
        if ((bool)userInfo.IsManager)
            chkManager.Checked = true;

        List<UserInRole> existingUserRoles = dc.UserInRoles.Where(s => s.UserID == id).ToList();
        foreach (UserInRole item in existingUserRoles)
        {
            if (item.RoleID == 1)
            {
                chkAccessRightsList.Items[0].Selected = true;
            }
            else if (item.RoleID == 2)
            {
                chkAccessRightsList.Items[1].Selected = true;
            }
            else if (item.RoleID == 3)
            {
                chkAccessRightsList.Items[2].Selected = true;
            }
            else if (item.RoleID == 4)
            {
                chkAccessRightsList.Items[3].Selected = true;
            }
            else if (item.RoleID == 5)
            {
                chkAccessRightsList.Items[4].Selected = true;
            }
        }
    }
}