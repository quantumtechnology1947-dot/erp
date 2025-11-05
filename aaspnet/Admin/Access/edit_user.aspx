<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Admin_Access_edit_user, newerp_deploy" title="ERP" theme="Default" %>


    
<script runat="server">
	string username;
    string email;
    string coment;
	MembershipUser user;
	
	private void Page_Load()
	{try
    {
       
		username = Request.QueryString["username"];
        email = Request.QueryString["email"];
        coment = Request.QueryString["comment"];
		if (username == null || username == "")
		{
			Response.Redirect("users.aspx");
		}
		user = Membership.GetUser(username);
		UserUpdateMessage.Text = "";
        CheckBox1.Attributes.Add("onclick", "checkAll(this);");
    }
    catch (Exception ex) { }
	}
    
    
    

	protected void UserInfo_ItemUpdating(object sender, DetailsViewUpdateEventArgs e)
	{
		//Need to handle the update manually because MembershipUser does not have a
		//parameterless constructor 
        username = Request.QueryString["username"]; 
        user = Membership.GetUser(username);
        user.Email = (string)e.NewValues[0];       
		user.Comment = (string)e.NewValues[1]; 
		user.IsApproved = (bool)e.NewValues[2];

		try
		{
			// Update user info:
			Membership.UpdateUser(user);
			
			// Update user roles:
			UpdateUserRoles();
			
			UserUpdateMessage.Text = "Update Successful.";
			
			e.Cancel = true;
			UserInfo.ChangeMode(DetailsViewMode.ReadOnly);
		}
		catch (Exception ex)
		{
			UserUpdateMessage.Text = "Update Failed: " + ex.Message;

			e.Cancel = true;
			UserInfo.ChangeMode(DetailsViewMode.ReadOnly);
		}
	}

	private void Page_PreRender()
	{
		// Load the User Roles into checkboxes.
		UserRoles.DataSource = Roles.GetAllRoles();
		UserRoles.DataBind();
        username = Request.QueryString["username"];
		// Disable checkboxes if appropriate:
		if (UserInfo.CurrentMode != DetailsViewMode.Edit)
		{
			foreach (ListItem checkbox in UserRoles.Items)
			{
				checkbox.Enabled = false;
			}
		}
		
        
		// Bind these checkboxes to the User's own set of roles.
		string[] userRoles = Roles.GetRolesForUser(username);
		foreach (string role in userRoles)
		{
			ListItem checkbox = UserRoles.Items.FindByValue(role);
			checkbox.Selected = true;
		}
	}
	
	private void UpdateUserRoles()
	{
        try
        {
        username = Request.QueryString["username"];
		foreach (ListItem rolebox in UserRoles.Items)
		{
			if (rolebox.Selected)
			{
				if (!Roles.IsUserInRole(username, rolebox.Text))
				{
					Roles.AddUserToRole(username, rolebox.Text);
				}
			}
			else
			{
				if (Roles.IsUserInRole(username, rolebox.Text))
				{
					Roles.RemoveUserFromRole(username, rolebox.Text);
				}
			}
		}
         }catch(Exception ex){}
	}

	private void DeleteUser(object sender, EventArgs e)
	{
        try
        {
        username = Request.QueryString["username"];
		//Membership.DeleteUser(username, false); // DC: My apps will NEVER delete the related data.
		Membership.DeleteUser(username, true); // DC: except during testing, of course!
		Response.Redirect("users.aspx");
         }catch(Exception ex){}
	}

    //private void UnlockUser(object sender, EventArgs e)
    //{
    //    // Dan Clem, added 5/30/2007 post-live upgrade.
		
    //    //try
    //    //{
    //    user.UnlockUser();
    //    //user.UnlockUser();
		
    //    // DataBind the GridView to reflect same.
    //    UserInfo.DataBind();
    //    // }catch(Exception ex){}
    //}
</script>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

    <script src="../../Javascript/loadingNotifier.js" type="text/javascript"></script>
    <style type="text/css">
        .style2
        {
            font-size: 12pt;
            font-weight: bold;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cp3" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cp1" Runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cp2" Runat="Server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="MainContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
    <!-- #include file="_nav.aspx -->
<!-- #include file="_nav3.aspx -->

<script type="text/javascript">  
      
    function checkAll(obj1)  
    {  
        var checkboxCollection = document.getElementById('<%=UserRoles.ClientID %>').getElementsByTagName('input');  
                 
        for(var i=0;i<checkboxCollection.length;i++)  
        {  
            if(checkboxCollection[i].type.toString().toLowerCase() == "checkbox")  
            {  
                checkboxCollection[i].checked = obj1.checked;  
            }  
        }  
    }  
      
    </script>  
<table class="webparts" width="900">
<tr>
	<th width="500">User Information</th>
	<th>&nbsp;</th>
</tr>
<tr>
<td class="details" valign="top">

    <b>Roles:</b><asp:Panel ID="Panel1" runat="server" Height="300px" 
        ScrollBars="Auto">
        <asp:CheckBoxList ID="UserRoles" runat="server" />
    </asp:Panel>
    <h3>
    <asp:CheckBox ID="CheckBox1" runat="server"  
        Text="Select All"   
    onclick="checkAll(this);"/>


<asp:ObjectDataSource ID="MemberData" runat="server" DataObjectTypeName="System.Web.Security.MembershipUser" SelectMethod="GetUser" UpdateMethod="UpdateUser" TypeName="System.Web.Security.Membership">
	<SelectParameters>
		<asp:QueryStringParameter Name="username" QueryStringField="username" />
		<%--<asp:QueryStringParameter Name="email" QueryStringField="email" />
		<asp:QueryStringParameter Name="comment" QueryStringField="comment" />--%>
	</SelectParameters>
	
	<UpdateParameters>
	
	<asp:QueryStringParameter Name="username" QueryStringField="username" />
	</UpdateParameters>
</asp:ObjectDataSource> 
    </h3>
</td>

<td class="details" valign="top">
   
        <span class="style2">Main Info:</span><asp:DetailsView AutoGenerateRows="False" DataSourceID="MemberData"
  ID="UserInfo" runat="server" OnItemUpdating="UserInfo_ItemUpdating"
  >
  
<Fields>
	<asp:BoundField DataField="UserName" HeaderText="User Name" ReadOnly="True" HeaderStyle-CssClass="detailheader" ItemStyle-CssClass="detailitem">
	</asp:BoundField>
	<asp:BoundField  DataField="Email" HeaderText="Email" HeaderStyle-CssClass="detailheader" ItemStyle-CssClass="detailitem"></asp:BoundField>
	<asp:BoundField DataField="Comment" HeaderText="Comment" HeaderStyle-CssClass="detailheader" ItemStyle-CssClass="detailitem"></asp:BoundField>
	<asp:CheckBoxField DataField="IsApproved" HeaderText="Active User" HeaderStyle-CssClass="detailheader" ItemStyle-CssClass="detailitem" />
	<asp:CheckBoxField DataField="IsLockedOut" HeaderText="Is Locked Out"  HeaderStyle-CssClass="detailheader" ItemStyle-CssClass="detailitem" />
	
	<asp:CheckBoxField DataField="IsOnline" HeaderText="Is Online" ReadOnly="True" HeaderStyle-CssClass="detailheader" ItemStyle-CssClass="detailitem" />
	<asp:BoundField DataField="CreationDate" HeaderText="CreationDate" ReadOnly="True"
	 HeaderStyle-CssClass="detailheader" ItemStyle-CssClass="detailitem"></asp:BoundField>
	<asp:BoundField DataField="LastActivityDate" HeaderText="LastActivityDate" ReadOnly="True" HeaderStyle-CssClass="detailheader" ItemStyle-CssClass="detailitem">
	</asp:BoundField>
	<asp:BoundField DataField="LastLoginDate" HeaderText="LastLoginDate" ReadOnly="True" HeaderStyle-CssClass="detailheader" ItemStyle-CssClass="detailitem">
	</asp:BoundField>
	<asp:BoundField DataField="LastLockoutDate" HeaderText="LastLockoutDate" ReadOnly="True" HeaderStyle-CssClass="detailheader" ItemStyle-CssClass="detailitem"></asp:BoundField>
	<asp:BoundField DataField="LastPasswordChangedDate" HeaderText="LastPasswordChangedDate"
	ReadOnly="True" HeaderStyle-CssClass="detailheader" ItemStyle-CssClass="detailitem"></asp:BoundField>
	<asp:CommandField ButtonType="button" ShowEditButton="true" EditText="Edit User Info" />
</Fields>
</asp:DetailsView>
    


<div style="text-align: right; width: 100%; margin: 20px 0px;">
<asp:Button ID="Button1" runat="server" Text="Unlock User" OnClick="UnlockUser" Visible="false" OnClientClick="return confirm('Click OK to unlock this user.')" />
&nbsp;&nbsp;&nbsp;
<asp:Button ID="Button3" runat="server" Text="Lock User" OnClick="LockUser" Visible="false" OnClientClick="return confirm('Click OK to Lock this user.')" />
&nbsp;&nbsp;&nbsp;
<asp:Button ID="Button2" runat="server" Text="Delete User" OnClick="DeleteUser" OnClientClick="return confirm('Are Your Sure?')" />
<div class="alert" style="padding: 5px;">
<asp:Literal ID="UserUpdateMessage" runat="server">&nbsp;</asp:Literal>
</div>
</div>


</td>

</tr></table>


</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

