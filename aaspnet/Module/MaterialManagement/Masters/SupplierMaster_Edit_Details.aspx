<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Module_MaterialManagement_Masters_SupplierMaster_Edit_Details, newerp_deploy" title="ERP" theme="Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../../../Css/yui-datatable.css" rel="stylesheet" type="text/css" />
    <link href="../../../Css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <script src="../../../Javascript/PopUpMsg.js" type="text/javascript"></script>
     <script src="../../../Javascript/loadingNotifier.js" type="text/javascript"></script>
    
    <style type="text/css">
      
       
        .style9
        {
            width: 185px;
        }
        .style10
        {
        }
        
        .style13
        {
            width: 174px;
        }
        .style14
        {
            height: 23px;
        }
        .style15
        {
            width: 174px;
            height: 23px;
        }
        .style17
        {
            width: 185px;
            height: 23px;
        }
        .style20
        {
            width: 182px;
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
    <table cellpadding="0" cellspacing="0" class="box3" width="100%" align="center" >
        <tr>
            <td>

<table width="100%"  border="0" align="center" cellpadding="0" cellspacing="2" Class="fontcss">
  <tr valign="top"  >
    <th height="20" align="left" valign="middle"  scope="col" class="fontcsswhite" colspan="4" style="background:url(../../../images/hdbg.JPG)">
        &nbsp;<strong>Supplier Master - Edit</strong></th>
  </tr>
  <tr valign="top"  >
    <th width="17%" height="22" align="left" valign="middle"  scope="col" 
          class="fontcss">&nbsp;Supplier's Name</th>
    <th colspan="2" align="left" valign="middle"  scope="col">
        <asp:TextBox ID="txtSupplierName" runat="server" CssClass="box3" Width="350px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="ReqtxtSupplierName" runat="server" 
            ControlToValidate="txtSupplierName" ErrorMessage="*" 
            ValidationGroup="Shree"></asp:RequiredFieldValidator>
       <asp:Label ID="lblSupName" 
            runat="server" Visible="False"></asp:Label>
        <asp:Label ID="hfSupplierId" runat="server" Visible="False"></asp:Label>
&nbsp;</th>
    <th align="right" valign="middle"  scope="col">
        <asp:Button ID="Update" runat="server" Text="Update" CssClass="redbox"   
            OnClientClick=" return confirmationUpdate()" onclick="Update_Click" 
            ValidationGroup="Shree" />
        <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Cancel" 
            CssClass="redbox" />
        &nbsp;</th>
    </tr>
  <tr valign="top"  >
    <th width="17%" height="22" align="left" valign="middle"  scope="col" 
          class="fontcss">&nbsp;Scope of Supply</th>
    <th colspan="2" align="left" valign="middle"  scope="col">
        <asp:TextBox ID="txtEditScopeofSupply" runat="server" Height="45px" 
            TextMode="MultiLine" Width="350px" CssClass="box3"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
            ControlToValidate="txtEditScopeofSupply" ErrorMessage="*" 
            ValidationGroup="Shree"></asp:RequiredFieldValidator>
      </th>
    <th align="right" valign="middle"  scope="col">
        &nbsp;</th>
    </tr>
  <tr valign="top"  >
    <th width="17%" height="23" align="center" valign="middle"  scope="col" bgcolor="#e5e5e5">Address/Details</th>
    <th width="27%" align="center" valign="middle"  scope="col" bgcolor="#e5e5e5">REGD. OFFICE</th>
    <th width="28%" align="center" valign="middle"  scope="col" bgcolor="#e5e5e5">WORKS/FACTORY</th>
    <th width="28%" align="center" valign="middle"  scope="col" bgcolor="#e5e5e5">MATERIAL DELIVERY</th>
  </tr>
  <tr valign="top"  >
    <th height="28" align="left" valign="top"  scope="col" class="fontcss">&nbsp;Address</th>
    <th align="left" valign="middle"  scope="col">
        <asp:TextBox ID="txtEditRegdAdd" runat="server" TextMode="MultiLine" CssClass="box3" 
            Width="230px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
            ControlToValidate="txtEditRegdAdd" ErrorMessage="*" ValidationGroup="Shree"></asp:RequiredFieldValidator>
      </th>
    <th width="28%" align="left" valign="middle"  scope="col">
        <asp:TextBox ID="txtEditWorkAdd" runat="server" TextMode="MultiLine" CssClass="box3" 
            Width="230px"></asp:TextBox>    
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
            ControlToValidate="txtEditWorkAdd" ErrorMessage="*" ValidationGroup="Shree"></asp:RequiredFieldValidator>
      </th>
    <th width="28%" align="left" valign="middle"  scope="col">
        <asp:TextBox ID="txtEditMaterialDelAdd" runat="server" TextMode="MultiLine" CssClass="box3" 
            Width="230px" ValidationGroup="Shree"></asp:TextBox>    
        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
            ControlToValidate="txtEditMaterialDelAdd" ErrorMessage="*"></asp:RequiredFieldValidator>
      </th>
  </tr>
  <tr valign="top"  >
    <th height="23" align="left" valign="middle"  scope="col" class="fontcss">&nbsp;Country</th>
    <th align="left" valign="middle"  scope="col">
        <asp:DropDownList ID="DDListEditRegdCountry" runat="server" CssClass="box3" 
            AutoPostBack="True" 
            onselectedindexchanged="DDListEditRegdCountry_SelectedIndexChanged"></asp:DropDownList>
        <asp:RequiredFieldValidator ID="ReqRegdCountry" runat="server" 
            ControlToValidate="DDListEditRegdCountry" ErrorMessage="*" InitialValue="Select" 
            ValidationGroup="Shree"></asp:RequiredFieldValidator>
      </th>
    <th align="left" valign="middle"  scope="col">
        <asp:DropDownList ID="DDListEditWorkCountry" runat="server" CssClass="box3" 
            AutoPostBack="True" 
            onselectedindexchanged="DDListEditWorkCountry_SelectedIndexChanged"></asp:DropDownList>    
        <asp:RequiredFieldValidator ID="ReqworkCountry" runat="server" 
            ControlToValidate="DDListEditWorkCountry" ErrorMessage="*" InitialValue="Select" 
            ValidationGroup="Shree"></asp:RequiredFieldValidator>
      </th>
    <th align="left" valign="middle"  scope="col">
        <asp:DropDownList ID="DDListEditMaterialDelCountry" runat="server" 
            CssClass="box3" AutoPostBack="True" 
            onselectedindexchanged="DDListEditMaterialDelCountry_SelectedIndexChanged"></asp:DropDownList>    
        <asp:RequiredFieldValidator ID="ReqMaterialCountry" runat="server" 
            ControlToValidate="DDListEditMaterialDelCountry" ErrorMessage="*" 
            InitialValue="Select" ValidationGroup="Shree"></asp:RequiredFieldValidator>
      </th>
  </tr>
  <tr valign="top"  >
    <th height="23" align="left" valign="middle"  scope="col" class="fontcss">&nbsp;State</th>
    <th align="left" valign="middle"  scope="col">
        <asp:DropDownList ID="DDListEditRegdState" runat="server" CssClass="box3" 
            AutoPostBack="True" 
            onselectedindexchanged="DDListEditRegdState_SelectedIndexChanged"></asp:DropDownList>    
        <asp:RequiredFieldValidator ID="ReqRegdState" runat="server" 
            ControlToValidate="DDListEditRegdState" ErrorMessage="*" InitialValue="Select" 
            ValidationGroup="Shree"></asp:RequiredFieldValidator>
      </th>
    <th align="left" valign="middle"  scope="col">
        <asp:DropDownList ID="DDListEditWorkState" runat="server" CssClass="box3" 
            AutoPostBack="True" 
            onselectedindexchanged="DDListEditWorkState_SelectedIndexChanged"></asp:DropDownList>    
        <asp:RequiredFieldValidator ID="ReqWorkState" runat="server" 
            ControlToValidate="DDListEditWorkState" ErrorMessage="*" InitialValue="Select" 
            ValidationGroup="Shree"></asp:RequiredFieldValidator>
      </th>
    <th align="left" valign="middle"  scope="col">
        <asp:DropDownList ID="DDListEditMaterialDelState" runat="server" 
            CssClass="box3" AutoPostBack="True" 
            onselectedindexchanged="DDListEditMaterialDelState_SelectedIndexChanged"></asp:DropDownList>    
        <asp:RequiredFieldValidator ID="ReqMaterialState" runat="server" 
            ControlToValidate="DDListEditMaterialDelState" ErrorMessage="*" 
            InitialValue="Select" ValidationGroup="Shree"></asp:RequiredFieldValidator>
      </th>
  </tr>
  <tr valign="top"  >
    <th height="23" align="left" valign="top"  scope="col" class="fontcss">&nbsp;City</th>
    <th align="left" valign="middle"  scope="col">
        <asp:DropDownList ID="DDListEditRegdCity" runat="server" CssClass="box3"></asp:DropDownList>    
        <asp:RequiredFieldValidator ID="ReqRegdCity" runat="server" 
            ControlToValidate="DDListEditRegdCity" ErrorMessage="*" InitialValue="Select" 
            ValidationGroup="Shree"></asp:RequiredFieldValidator>
      </th>
    <th align="left" valign="middle"  scope="col">
        <asp:DropDownList ID="DDListEditWorkCity" runat="server" CssClass="box3"></asp:DropDownList>    
        <asp:RequiredFieldValidator ID="ReqWorkCity0" runat="server" 
            ControlToValidate="DDListEditWorkCity" ErrorMessage="*" InitialValue="Select" 
            ValidationGroup="Shree"></asp:RequiredFieldValidator>
      </th>
    <th align="left" valign="middle"  scope="col">
        <asp:DropDownList ID="DDListEditMaterialDelCity" runat="server" CssClass="box3"></asp:DropDownList>    
        <asp:RequiredFieldValidator ID="ReqMaterialCity" runat="server" 
            ControlToValidate="DDListEditMaterialDelCity" ErrorMessage="*" 
            InitialValue="Select" ValidationGroup="Shree"></asp:RequiredFieldValidator>
      </th>
  </tr>
  <tr valign="top"  >
    <th height="23" align="left" valign="middle"  scope="col" class="fontcss">&nbsp;PIN No.</th>
    <th align="left" valign="middle"  scope="col">
        <asp:TextBox ID="txtEditRegdPinNo" runat="server" CssClass="box3"></asp:TextBox>    
        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
            ControlToValidate="txtEditRegdPinNo" ErrorMessage="*" ValidationGroup="Shree"></asp:RequiredFieldValidator>
      </th>
    <th align="left" valign="middle"  scope="col" >
        <asp:TextBox ID="txtEditWorkPinNo" runat="server" CssClass="box3"></asp:TextBox>    
        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
            ControlToValidate="txtEditWorkPinNo" ErrorMessage="*" ValidationGroup="Shree"></asp:RequiredFieldValidator>
      </th>
    <th align="left" valign="middle"  scope="col">
        <asp:TextBox ID="txtEditMaterialDelPinNo" runat="server" CssClass="box3"></asp:TextBox>    
        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
            ControlToValidate="txtEditMaterialDelPinNo" ErrorMessage="*" 
            ValidationGroup="Shree"></asp:RequiredFieldValidator>
      </th>
  </tr>
  <tr valign="top"  >
    <th height="23" align="left" valign="middle"  scope="col" class="fontcss">&nbsp;Contact No.</th>
    <th align="left" valign="middle"  scope="col">
        <asp:TextBox ID="txtEditRegdContactNo" runat="server" CssClass="box3"></asp:TextBox>    
        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" 
            ControlToValidate="txtEditRegdContactNo" ErrorMessage="*" 
            ValidationGroup="Shree"></asp:RequiredFieldValidator>
      </th>
    <th align="left" valign="middle"  scope="col">
        <asp:TextBox ID="txtEditWorkContactNo" runat="server" CssClass="box3"></asp:TextBox>    
        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" 
            ControlToValidate="txtEditWorkContactNo" ErrorMessage="*" 
            ValidationGroup="Shree"></asp:RequiredFieldValidator>
      </th>
    <th align="left" valign="middle"  scope="col">
        <asp:TextBox ID="txtEditMaterialDelContactNo" runat="server" CssClass="box3"></asp:TextBox>    
        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" 
            ControlToValidate="txtEditMaterialDelContactNo" ErrorMessage="*" 
            ValidationGroup="Shree"></asp:RequiredFieldValidator>
      </th>
  </tr>
  <tr valign="top"  >
    <th height="23" align="left" valign="middle"  scope="col" class="fontcss">&nbsp;</th>
    <th align="left" valign="middle"  scope="col">
        <asp:TextBox ID="txtEditRegdFaxNo" runat="server" CssClass="box3" 
            Visible="False">-</asp:TextBox>    
        <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" 
            ControlToValidate="txtEditRegdFaxNo" ErrorMessage="*" ValidationGroup="Shree"></asp:RequiredFieldValidator>
      </th>
    <th align="left" valign="middle"  scope="col">
        <asp:TextBox ID="txtEditWorkFaxNo" runat="server" CssClass="box3" 
            Visible="False">-</asp:TextBox>    
        <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" 
            ControlToValidate="txtEditWorkFaxNo" ErrorMessage="*" ValidationGroup="Shree"></asp:RequiredFieldValidator>
      </th>
    <th align="left" valign="middle"  scope="col">
        <asp:TextBox ID="txtEditMaterialDelFaxNo" runat="server" CssClass="box3" 
            Visible="False">-</asp:TextBox>    
        <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" 
            ControlToValidate="txtEditMaterialDelFaxNo" ErrorMessage="*" 
            ValidationGroup="Shree"></asp:RequiredFieldValidator>
      </th>
  </tr>
  
  <tr valign="top"  >
    <th height="23" colspan="4" align="left" valign="top"  scope="col">
    <table width="100%" border="0" cellspacing="0" cellpadding="1">
      <tr>
        <td height="23" align="left" valign="middle" class="fontcss">&nbsp;Contact person</td>
        <td align="left" valign="middle" class="style13"><asp:TextBox ID="txtEditContactPerson" 
                runat="server" CssClass="box3"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" 
                ControlToValidate="txtEditContactPerson" ErrorMessage="*" 
                ValidationGroup="Shree"></asp:RequiredFieldValidator>
          </td>
        <td align="left" valign="middle" class="fontcss">E-mail</td>
        <td align="left" valign="middle" class="style9"><asp:TextBox ID="txtEditEmail" runat="server" 
                CssClass="box3"></asp:TextBox>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                ControlToValidate="txtEditEmail" ErrorMessage="*" 
                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                ValidationGroup="Shree"></asp:RegularExpressionValidator>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator20" runat="server" 
                ControlToValidate="txtEditEmail" ErrorMessage="*" ValidationGroup="Shree"></asp:RequiredFieldValidator>
          </td>
        <td align="left" valign="middle" class="fontcss">Contact No.</td>
        <td align="left" valign="middle">
            <asp:TextBox ID="txtEditContactNo" runat="server" CssClass="box3"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator26" runat="server" 
                ControlToValidate="txtEditContactNo" ErrorMessage="*" ValidationGroup="Shree"></asp:RequiredFieldValidator>
          </td>
      </tr>
      <tr>
        <td width="17%" height="23" align="left" valign="middle" class="fontcss">&nbsp;</td>
        <td align="left" valign="middle" class="style13">
            <asp:TextBox ID="txtEditJuridictionCode" runat="server" CssClass="box3" 
                Visible="False">-</asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" 
                ControlToValidate="txtEditJuridictionCode" ErrorMessage="*" 
                ValidationGroup="Shree"></asp:RequiredFieldValidator>
          </td>
        <td align="left" valign="middle" class="fontcss">&nbsp;</td>
        <td align="left" valign="middle" class="style9">
            <asp:TextBox ID="txtEditEccNo" runat="server" CssClass="box3" Visible="False">-</asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator21" runat="server" 
                ControlToValidate="txtEditEccNo" ErrorMessage="*" ValidationGroup="Shree"></asp:RequiredFieldValidator>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
          </td>
        <td align="left" valign="middle" class="fontcss">&nbsp;</td>
        <td width="22%" align="left" valign="middle">
            <asp:TextBox ID="txtEditRange" runat="server" CssClass="box3" Visible="False">-</asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator27" runat="server" 
                ControlToValidate="txtEditRange" ErrorMessage="*" ValidationGroup="Shree"></asp:RequiredFieldValidator>
          </td>
      </tr>
      <tr>
        <td height="23" align="left" valign="middle" class="fontcss">&nbsp;</td>
        <td align="left" valign="middle" class="style13">
            <asp:TextBox ID="txtEditCommissionurate" runat="server" CssClass="box3" 
                Visible="False">-</asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" 
                ControlToValidate="txtEditCommissionurate" ErrorMessage="*" 
                ValidationGroup="Shree"></asp:RequiredFieldValidator>
          </td>
        <td align="left" valign="middle" class="fontcss">&nbsp;</td>
        <td align="left" valign="middle" class="style9">
            <asp:TextBox ID="txtEditDivn" runat="server" CssClass="box3" Visible="False">-</asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator22" runat="server" 
                ControlToValidate="txtEditDivn" ErrorMessage="*" ValidationGroup="Shree"></asp:RequiredFieldValidator>
          </td>
        <td align="left" valign="middle" class="fontcss">&nbsp;</td>
        <td align="left" valign="middle">
            <asp:TextBox ID="txtEditPanNo" runat="server" CssClass="box3" Visible="False">-</asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator28" runat="server" 
                ControlToValidate="txtEditPanNo" ErrorMessage="*" ValidationGroup="Shree"></asp:RequiredFieldValidator>
          </td>
      </tr>
      <tr>
        <td height="23" align="left" valign="middle" class="fontcss">GST No.</td>
        <td align="left" valign="middle" class="style13">
            <asp:TextBox ID="txtEditTinVatNo" runat="server" CssClass="box3"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" 
                ControlToValidate="txtEditTinVatNo" ErrorMessage="*" ValidationGroup="Shree"></asp:RequiredFieldValidator>
          </td>
        <td align="left" valign="middle" class="fontcss">&nbsp;</td>
        <td align="left" valign="middle" class="style9">
            <asp:TextBox ID="txtEditTinCstNo" runat="server" CssClass="box3" 
                Visible="False">-</asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator23" runat="server" 
                ControlToValidate="txtEditTinCstNo" ErrorMessage="*" ValidationGroup="Shree"></asp:RequiredFieldValidator>
          </td>
        <td align="left" valign="middle" class="fontcss">&nbsp;</td>
        <td align="left" valign="middle">
            <asp:TextBox ID="txtEditTdsCode" runat="server" CssClass="box3" Visible="False">-</asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator29" runat="server" 
                ControlToValidate="txtEditTdsCode" ErrorMessage="*" ValidationGroup="Shree"></asp:RequiredFieldValidator>
          </td>
      </tr>
      
      <tr>
        <td height="23" align="left" valign="middle" class="fontcss">&nbsp;Mod Vat Applicable</td>
        <td align="left" valign="middle" id="rbMVAYes" class="style13">
            <asp:RadioButton ID="rbMVAYes" runat="server" GroupName="MVA" Text="Yes" />
&nbsp;<asp:RadioButton ID="rbMVANo" runat="server" GroupName="MVA" 
                Text="No" />
          </td>
        <td align="left" valign="middle" class="fontcss">Mod Vat Invoice</td>
        <td align="left" valign="middle" class="style9">
            <asp:RadioButton ID="rbMVIYes" runat="server" GroupName="MVI" Text="Yes" />
            <asp:RadioButton ID="rbMVINo" runat="server" GroupName="MVI" 
                Text="No" />
          </td>
        <td align="left" valign="middle" class="style20">&nbsp;</td>
        <td align="left" valign="middle">
            &nbsp;</td>
      </tr>
      
      <tr>
        <td align="left" valign="middle" class="fontcss">&nbsp;Bank Acc No</td>
        <td align="left" valign="middle" class="style15">
            <asp:TextBox ID="txtBankAccNo" runat="server" CssClass="box3"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" 
                ControlToValidate="txtBankAccNo" ErrorMessage="*" ValidationGroup="Shree"></asp:RequiredFieldValidator>
          </td>
        <td align="left" valign="middle" class="fontcss">Bank Name</td>
        <td align="left" valign="middle" class="style17">
            <asp:TextBox ID="txtBankName" runat="server" CssClass="box3"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator24" runat="server" 
                ControlToValidate="txtBankName" ErrorMessage="*" ValidationGroup="Shree"></asp:RequiredFieldValidator>
          </td>
        <td align="left" valign="middle" class="fontcss">Bank Branch</td>
        <td align="left" valign="middle" class="style14">
            <asp:TextBox ID="txtBankBranch" runat="server" CssClass="box3"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator30" runat="server" 
                ControlToValidate="txtBankBranch" ErrorMessage="*" ValidationGroup="Shree"></asp:RequiredFieldValidator>
          </td>
      </tr>
      
      <tr>
        <td height="23" align="left" valign="top" class="fontcss">&nbsp;Bank Address</td>
        <td align="left" valign="middle" class="style13">
            <asp:TextBox ID="txtBankAddress" runat="server" TextMode="MultiLine" 
                Width="156px" CssClass="box3"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" 
                ControlToValidate="txtBankAddress" ErrorMessage="*" ValidationGroup="Shree"></asp:RequiredFieldValidator>
          </td>
        <td align="left" valign="top" class="fontcss" width="200">Bank Acc Type</td>
        <td align="left" valign="top" class="style9">
            <asp:TextBox ID="txtBankAccType" runat="server" CssClass="box3"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator25" runat="server" 
                ControlToValidate="txtBankAccType" ErrorMessage="*" ValidationGroup="Shree"></asp:RequiredFieldValidator>
          </td>
        <td align="left" valign="top" class="fontcss">Service Coverage</td>
        <td align="left" valign="top">
            <asp:DropDownList ID="DDLServiceCoverage" runat="server" 
                DataSourceID="SqlDataSource3" DataTextField="Type" DataValueField="Id" 
                Width="150px" CssClass="box3">
                <asp:ListItem Value="1">Local</asp:ListItem>
                <asp:ListItem Value="2">Reginal</asp:ListItem>
                <asp:ListItem Value="3">Statewide</asp:ListItem>
                <asp:ListItem Value="4">Nationwide</asp:ListItem>
                <asp:ListItem Value="5">Global</asp:ListItem>
            </asp:DropDownList>
          </td>
      </tr>
      
      <tr>
        <td height="23" align="left" valign="top" class="fontcss">&nbsp;
            <asp:Label ID="Label2" runat="server" Text="P &amp; F"></asp:Label>
          </td>
        <td align="left" valign="middle" class="style13">
             <asp:DropDownList ID="DDLPF" runat="server" DataSourceID="SqlDataSourcePF" 
                            DataTextField="Terms" DataValueField="Id" CssClass="box3">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSourcePF" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:LocalSqlServer %>" 
                        SelectCommand="SELECT [Id], [Terms] FROM [tblPacking_Master]">
                    </asp:SqlDataSource>
          </td>
        <td align="left" valign="top" class="fontcss" width="200">
            <asp:Label ID="Label3" runat="server" Text="Excies / Service Tax/CGST/IGST"></asp:Label>
          </td>
        <td align="left" valign="top" class="style9">
            <asp:DropDownList ID="DDLExcies" runat="server" DataSourceID="SqlDataSourceExSer" 
                        DataTextField="Terms" DataValueField="Id" CssClass="box3">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSourceExSer" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:LocalSqlServer %>" 
                        SelectCommand="SELECT [Id], [Terms] FROM [tblExciseser_Master]">
                    </asp:SqlDataSource>
          </td>
        <td align="left" valign="top" class="fontcss">
            <asp:Label ID="Label4" runat="server" Text="SGST"></asp:Label>
          </td>
        <td align="left" valign="top">
            <asp:DropDownList ID="DDLVat" runat="server" DataSourceID="SqlDataSourceAsh" 
                        DataTextField="Terms" DataValueField="Id" CssClass="box3">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSourceAsh" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:LocalSqlServer %>" 
                        SelectCommand="SELECT [Id], [Terms] FROM [tblVAT_Master]">
                    </asp:SqlDataSource>
          </td>
      </tr>
      
      <tr>
        <td height="23" align="left" valign="top" class="fontcss">&nbsp;Business Nature</td>
        <td align="left" valign="top" class="style10" colspan="2">
            <asp:Panel ID="Panel1" runat="server" CssClass="box3" Height="90px" 
                ScrollBars="Auto">
                <asp:CheckBoxList ID="CBLBusinessNature" runat="server" CssClass="fontcss">
                </asp:CheckBoxList>
            </asp:Panel>
          </td>
        <td align="right" valign="top" class="fontcss">
            Business Type</td>
        <td align="left" valign="top" class="fontcss" colspan="2">
            <asp:Panel ID="Panel2" runat="server" CssClass="box3" Height="90px" 
                ScrollBars="Auto">
                <asp:CheckBoxList ID="CBLBusinessType" runat="server" ValidationGroup="Shree">
                </asp:CheckBoxList>
            </asp:Panel>
          </td>
      </tr>
      
      </table></th>
  </tr>
  
  <tr valign="top"  >
    <th height="23" align="left" valign="top"  scope="col" class="fontcss"> &nbsp;Remarks&nbsp;</th>
    <th colspan="2" align="left" valign="middle"  scope="col">
        <asp:TextBox ID="txtEditRemark" runat="server" TextMode="MultiLine" 
            CssClass="box3" Width="471px"></asp:TextBox>    
        <asp:RequiredFieldValidator ID="RequiredFieldValidator31" runat="server" 
            ControlToValidate="txtEditRemark" ErrorMessage="*" ValidationGroup="Shree"></asp:RequiredFieldValidator>
      </th>
    <th align="right" valign="top"  scope="col">
            <asp:SqlDataSource ID="SqlDataSource3" runat="server" 
                ConnectionString="<%$ ConnectionStrings:LocalSqlServer %>" 
                SelectCommand="SELECT * FROM [tblMM_Supplier_ServiceCoverage]">
            </asp:SqlDataSource>
          </th>
  </tr>
</table>
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

