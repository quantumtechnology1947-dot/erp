<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Module_SD_Cust_masters_CustomerMaster_Edit, newerp_deploy" title="ERP" theme="Default" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../../../Css/StyleSheet.css" rel="stylesheet" type="text/css" />

    <script src="../../../Javascript/PopUpMsg.js" type="text/javascript"></script>

    <script src="../../../Javascript/loadingNotifier.js" type="text/javascript"></script>
    <style type="text/css">
        .style2
        {
            font-family: Verdana, Arial, Helvetica, sans-serif;
            font-size: 11px;
            font-style: normal;
            line-height: normal;
            font-variant: normal;
            text-transform: none;
            color: #000000;
            text-decoration: none;
        }
        .style3
        {
            font-family: Verdana, Arial, Helvetica, sans-serif;
            font-size: 11px;
            font-style: normal;
            line-height: normal;
            font-weight: normal;
            font-variant: normal;
            text-transform: none;
            color: #000000;
            text-decoration: none;
            height: 23px;
        }
        .style4
        {
            height: 23px;
        }
        .style5
        {
            font-family: Verdana, Arial, Helvetica, sans-serif;
            font-size: 11px;
            font-style: normal;
            line-height: normal;
            font-variant: normal;
            text-transform: none;
            color: #000000;
            text-decoration: none;
            height: 23px;
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
        &nbsp;<strong> Customer Master-Edit</strong></th>
  </tr>
  <tr valign="top"  >
    <th width="17%" height="22" align="left" valign="middle"  scope="col" 
          class="fontcss">&nbsp;<b>Customer's Name</b></th>
    <th colspan="2" align="left" valign="middle"  scope="col">
       <asp:Label ID="lblCustName" 
            runat="server"></asp:Label>
        <asp:Label ID="hfCustomerId" runat="server" Visible="False"></asp:Label>
&nbsp;</th>
    <th align="right" valign="middle"  scope="col">
        <asp:Button ID="Update" runat="server" Text="Update" CssClass="redbox" 
            onclick="Update_Click" onclientclick="return confirmationUpdate()" 
            ValidationGroup="A" />&nbsp;
        <asp:Button ID="btnCancel" runat="server" CssClass="redbox" Text="Cancel" 
            onclick="btnCancel_Click" />
&nbsp;&nbsp;</th>
    </tr>
  <tr valign="top"  >
    <th width="17%" height="23" align="center" valign="middle"  scope="col" bgcolor="#e5e5e5">Address/Details</th>
    <th width="27%" align="center" valign="middle"  scope="col" bgcolor="#e5e5e5">REGD. OFFICE</th>
    <th width="28%" align="center" valign="middle"  scope="col" bgcolor="#e5e5e5">WORKS/FACTORY</th>
    <th width="28%" align="center" valign="middle"  scope="col" bgcolor="#e5e5e5">MATERIAL DELIVERY</th>
  </tr>
  <tr valign="top"  >
    <th height="28" align="left" valign="top"  scope="col" class="fontcss">&nbsp;<b>Address</b></th>
    <th align="left" valign="middle"  scope="col">
        <asp:TextBox ID="txtEditRegdAdd" runat="server" TextMode="MultiLine" CssClass="box3" 
            Width="230px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="ReqregdAdd" runat="server" 
            ControlToValidate="txtEditRegdAdd" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
      </th>
    <th width="28%" align="left" valign="middle"  scope="col">
        <asp:TextBox ID="txtEditWorkAdd" runat="server" TextMode="MultiLine" CssClass="box3" 
            Width="230px"></asp:TextBox>    
        <asp:RequiredFieldValidator ID="ReqworkAdd" runat="server" 
            ControlToValidate="txtEditWorkAdd" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
      </th>
    <th width="28%" align="left" valign="middle"  scope="col">
        <asp:TextBox ID="txtEditMaterialDelAdd" runat="server" TextMode="MultiLine" CssClass="box3" 
            Width="230px"></asp:TextBox>    
        <asp:RequiredFieldValidator ID="ReqMaterialAdd" runat="server" 
            ControlToValidate="txtEditMaterialDelAdd" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
      </th>
  </tr>
  <tr valign="top"  >
    <th height="23" align="left" valign="middle"  scope="col" class="fontcss">&nbsp;<b>Country</b></th>
    <th align="left" valign="middle"  scope="col">
        <asp:DropDownList ID="DDListEditRegdCountry" runat="server" CssClass="box3" 
            AutoPostBack="True" 
            onselectedindexchanged="DDListEditRegdCountry_SelectedIndexChanged"></asp:DropDownList>
        <asp:RequiredFieldValidator ID="ReqregdCountry" runat="server" 
            ControlToValidate="DDListEditRegdCountry" ErrorMessage="*" 
            InitialValue="Select" ValidationGroup="A"></asp:RequiredFieldValidator>
      </th>
    <th align="left" valign="middle"  scope="col">
        <asp:DropDownList ID="DDListEditWorkCountry" runat="server" CssClass="box3" 
            AutoPostBack="True" 
            onselectedindexchanged="DDListEditWorkCountry_SelectedIndexChanged"></asp:DropDownList>    
        <asp:RequiredFieldValidator ID="ReqWorkCountry" runat="server" 
            ControlToValidate="DDListEditWorkCountry" ErrorMessage="*" 
            InitialValue="Select" ValidationGroup="A"></asp:RequiredFieldValidator>
      </th>
    <th align="left" valign="middle"  scope="col">
        <asp:DropDownList ID="DDListEditMaterialDelCountry" runat="server" 
            CssClass="box3" AutoPostBack="True" 
            onselectedindexchanged="DDListEditMaterialDelCountry_SelectedIndexChanged"></asp:DropDownList>    
        <asp:RequiredFieldValidator ID="ReqMaterialCountry" runat="server" 
            ControlToValidate="DDListEditMaterialDelCountry" ErrorMessage="*" 
            InitialValue="Select" ValidationGroup="A"></asp:RequiredFieldValidator>
      </th>
  </tr>
  <tr valign="top"  >
    <th height="23" align="left" valign="middle"  scope="col" class="fontcss">&nbsp;<b>State</b></th>
    <th align="left" valign="middle"  scope="col">
        <asp:DropDownList ID="DDListEditRegdState" runat="server" CssClass="box3" 
            AutoPostBack="True" 
            onselectedindexchanged="DDListEditRegdState_SelectedIndexChanged"></asp:DropDownList>    
        <asp:RequiredFieldValidator ID="ReqregdState" runat="server" 
            ControlToValidate="DDListEditRegdState" ErrorMessage="*" InitialValue="Select" 
            ValidationGroup="A"></asp:RequiredFieldValidator>
      </th>
    <th align="left" valign="middle"  scope="col">
        <asp:DropDownList ID="DDListEditWorkState" runat="server" CssClass="box3" 
            AutoPostBack="True" 
            onselectedindexchanged="DDListEditWorkState_SelectedIndexChanged"></asp:DropDownList>    
        <asp:RequiredFieldValidator ID="ReqWorkState" runat="server" 
            ControlToValidate="DDListEditWorkState" ErrorMessage="*" InitialValue="Select" 
            ValidationGroup="A"></asp:RequiredFieldValidator>
      </th>
    <th align="left" valign="middle"  scope="col">
        <asp:DropDownList ID="DDListEditMaterialDelState" runat="server" 
            CssClass="box3" AutoPostBack="True" 
            onselectedindexchanged="DDListEditMaterialDelState_SelectedIndexChanged"></asp:DropDownList>    
        <asp:RequiredFieldValidator ID="ReqMaterialState" runat="server" 
            ControlToValidate="DDListEditMaterialDelState" ErrorMessage="*" 
            InitialValue="Select" ValidationGroup="A"></asp:RequiredFieldValidator>
      </th>
  </tr>
  <tr valign="top"  >
    <th height="23" align="left" valign="middle"  scope="col" class="fontcss">&nbsp;<b>City</b></th>
    <th align="left" valign="middle"  scope="col">
        <asp:DropDownList ID="DDListEditRegdCity" runat="server" CssClass="box3"></asp:DropDownList>    
        <asp:RequiredFieldValidator ID="ReqregdCity" runat="server" 
            ControlToValidate="DDListEditRegdCity" ErrorMessage="*" InitialValue="Select" 
            ValidationGroup="A"></asp:RequiredFieldValidator>
      </th>
    <th align="left" valign="middle"  scope="col">
        <asp:DropDownList ID="DDListEditWorkCity" runat="server" CssClass="box3" 
            Height="18px"></asp:DropDownList>    
        <asp:RequiredFieldValidator ID="ReqWorkCity" runat="server" 
            ControlToValidate="DDListEditWorkCity" ErrorMessage="*" InitialValue="Select" 
            ValidationGroup="A"></asp:RequiredFieldValidator>
      </th>
    <th align="left" valign="middle"  scope="col">
        <asp:DropDownList ID="DDListEditMaterialDelCity" runat="server" CssClass="box3"></asp:DropDownList>    
        <asp:RequiredFieldValidator ID="ReqMaterialCity" runat="server" 
            ControlToValidate="DDListEditMaterialDelCity" ErrorMessage="*" 
            InitialValue="Select" ValidationGroup="A"></asp:RequiredFieldValidator>
      </th>
  </tr>
  <tr valign="top"  >
    <th height="23" align="left" valign="middle"  scope="col" class="fontcss">&nbsp;<b>PIN No.</b></th>
    <th align="left" valign="middle"  scope="col">
        <asp:TextBox ID="txtEditRegdPinNo" runat="server" CssClass="box3"></asp:TextBox>    
        <asp:RequiredFieldValidator ID="ReqregdPIN" runat="server" 
            ControlToValidate="txtEditRegdPinNo" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
      </th>
    <th align="left" valign="middle"  scope="col" >
        <asp:TextBox ID="txtEditWorkPinNo" runat="server" CssClass="box3"></asp:TextBox>    
        <asp:RequiredFieldValidator ID="Reqworkpin" runat="server" 
            ControlToValidate="txtEditWorkPinNo" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
      </th>
    <th align="left" valign="middle"  scope="col">
        <asp:TextBox ID="txtEditMaterialDelPinNo" runat="server" CssClass="box3"></asp:TextBox>    
        <asp:RequiredFieldValidator ID="ReqMaterialPIN" runat="server" 
            ControlToValidate="txtEditMaterialDelPinNo" ErrorMessage="*" 
            ValidationGroup="A"></asp:RequiredFieldValidator>
      </th>
  </tr>
  <tr valign="top"  >
    <th height="23" align="left" valign="middle"  scope="col" class="fontcss">&nbsp;<b>Contact No.</b></th>
    <th align="left" valign="middle"  scope="col">
        <asp:TextBox ID="txtEditRegdContactNo" runat="server" CssClass="box3"></asp:TextBox>    
        <asp:RequiredFieldValidator ID="ReqregdContNO" runat="server" 
            ControlToValidate="txtEditRegdContactNo" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
      </th>
    <th align="left" valign="middle"  scope="col">
        <asp:TextBox ID="txtEditWorkContactNo" runat="server" CssClass="box3"></asp:TextBox>    
        <asp:RequiredFieldValidator ID="ReqWorkContNo" runat="server" 
            ControlToValidate="txtEditWorkContactNo" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
      </th>
    <th align="left" valign="middle"  scope="col">
        <asp:TextBox ID="txtEditMaterialDelContactNo" runat="server" CssClass="box3"></asp:TextBox>    
        <asp:RequiredFieldValidator ID="ReqMateContNo" runat="server" 
            ControlToValidate="txtEditMaterialDelContactNo" ErrorMessage="*" 
            ValidationGroup="A"></asp:RequiredFieldValidator>
      </th>
  </tr>
  <tr valign="top"  >
    <th height="23" align="left" valign="middle"  scope="col" class="fontcss">&nbsp;</th>
    <th align="left" valign="middle"  scope="col">
        <asp:TextBox ID="txtEditRegdFaxNo" runat="server" CssClass="box3" 
            Visible="False"></asp:TextBox>    
        <asp:RequiredFieldValidator ID="ReqregdFaxNo" runat="server" 
            ControlToValidate="txtEditRegdFaxNo" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
      </th>
    <th align="left" valign="middle"  scope="col">
        <asp:TextBox ID="txtEditWorkFaxNo" runat="server" CssClass="box3" 
            Visible="False"></asp:TextBox>    
        <asp:RequiredFieldValidator ID="ReqWorkFaxNo" runat="server" 
            ControlToValidate="txtEditWorkFaxNo" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
      </th>
    <th align="left" valign="middle"  scope="col">
        <asp:TextBox ID="txtEditMaterialDelFaxNo" runat="server" CssClass="box3" 
            Visible="False"></asp:TextBox>    
        <asp:RequiredFieldValidator ID="ReqMaterialFax" runat="server" 
            ControlToValidate="txtEditMaterialDelFaxNo" ErrorMessage="*" 
            ValidationGroup="A"></asp:RequiredFieldValidator>
      </th>
  </tr>
  
  <tr valign="top"  >
    <th height="23" colspan="4" align="left" valign="top"  scope="col">
    <table width="100%" border="0" cellspacing="0" cellpadding="1">
      <tr>
        <td align="left" valign="middle" class="style3">&nbsp;<b>Contact person</b></td>
        <td align="left" valign="middle" class="style4"><asp:TextBox ID="txtEditContactPerson" 
                runat="server" CssClass="box3"></asp:TextBox>
            <asp:RequiredFieldValidator ID="ReqContactPerson" runat="server" 
                ControlToValidate="txtEditContactPerson" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
          </td>
        <td align="left" valign="middle" class="style5">E-mail</td>
        <td align="left" valign="middle" class="style4"><asp:TextBox ID="txtEditEmail" runat="server" 
                CssClass="box3"></asp:TextBox>
            <asp:RequiredFieldValidator ID="ReqEmail" runat="server" 
                ControlToValidate="txtEditEmail" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegEmail" runat="server" 
                ControlToValidate="txtEditEmail" ErrorMessage="*" 
                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                ValidationGroup="A"></asp:RegularExpressionValidator>
          </td>
        <td align="left" valign="middle" class="style5">Contact No.</td>
        <td align="left" valign="middle" class="style4">
            <asp:TextBox ID="txtEditContactNo" runat="server" CssClass="box3"></asp:TextBox>
            <asp:RequiredFieldValidator ID="ReqContNo" runat="server" 
                ControlToValidate="txtEditContactNo" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
          </td>
      </tr>
      <tr>
        <td width="17%" height="23" align="left" valign="middle" class="fontcss">&nbsp;</td>
        <td width="21%" align="left" valign="middle">
            <asp:TextBox ID="txtEditJuridictionCode" runat="server" CssClass="box3" 
                Visible="False"></asp:TextBox>
            <asp:RequiredFieldValidator ID="ReqjuridctNo" runat="server" 
                ControlToValidate="txtEditJuridictionCode" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
          </td>
        <td width="10%" align="left" valign="middle" class="style2">&nbsp;</td>
        <td width="20%" align="left" valign="middle">
            <asp:TextBox ID="txtEditEccNo" runat="server" CssClass="box3" Visible="False"></asp:TextBox>
            <asp:RequiredFieldValidator ID="ReqEcc" runat="server" 
                ControlToValidate="txtEditEccNo" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
          </td>
        <td width="10%" align="left" valign="middle" class="style2">&nbsp;</td>
        <td width="22%" align="left" valign="middle">
            <asp:TextBox ID="txtEditRange" runat="server" CssClass="box3" Visible="False"></asp:TextBox>
            <asp:RequiredFieldValidator ID="ReqRange" runat="server" 
                ControlToValidate="txtEditRange" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
          </td>
      </tr>
      <tr>
        <td height="23" align="left" valign="middle" class="fontcss">&nbsp;</td>
        <td align="left" valign="middle">
            <asp:TextBox ID="txtEditCommissionurate" runat="server" CssClass="box3" 
                Visible="False"></asp:TextBox>
            <asp:RequiredFieldValidator ID="ReqCommisnurate" runat="server" 
                ControlToValidate="txtEditCommissionurate" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
          </td>
        <td align="left" valign="middle" class="style2">&nbsp;</td>
        <td align="left" valign="middle">
            <asp:TextBox ID="txtEditDivn" runat="server" CssClass="box3" Visible="False"></asp:TextBox>
            <asp:RequiredFieldValidator ID="ReqDivn" runat="server" 
                ControlToValidate="txtEditDivn" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
          </td>
        <td align="left" valign="middle" class="style2">&nbsp;</td>
        <td align="left" valign="middle">
            <asp:TextBox ID="txtEditPanNo" runat="server" CssClass="box3" Visible="False"></asp:TextBox>
            <asp:RequiredFieldValidator ID="ReqPanNO" runat="server" 
                ControlToValidate="txtEditPanNo" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
          </td>
      </tr>
      <tr>
        <td height="23" align="left" valign="middle" class="fontcss">&nbsp;</td>
        <td align="left" valign="middle">
            <asp:TextBox ID="txtEditTinVatNo" runat="server" CssClass="box3" 
                Visible="False"></asp:TextBox>
            <asp:RequiredFieldValidator ID="ReqTinVat" runat="server" 
                ControlToValidate="txtEditTinVatNo" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
          </td>
        <td align="left" valign="middle" class="fontcss"><b>GST No.</b></td>
        <td align="left" valign="middle">
            <asp:TextBox ID="txtEditTinCstNo" runat="server" CssClass="box3"></asp:TextBox>
            <asp:RequiredFieldValidator ID="ReqTINCST" runat="server" 
                ControlToValidate="txtEditTinCstNo" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
          </td>
        <td align="left" valign="middle" class="style2" visible=false></td>
        <td align="left" valign="middle">
            <asp:TextBox ID="txtEditTdsCode" runat="server" CssClass="box3" Visible=false></asp:TextBox>
            <asp:RequiredFieldValidator ID="ReqTDS" runat="server" 
                ControlToValidate="txtEditTdsCode" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
          </td>
      </tr>
      
    </table></th>
  </tr>
  
  <tr valign="top"  >
    <th height="23" align="left" valign="top"  scope="col" class="fontcss"> &nbsp;<b>Remarks&nbsp;</b></th>
    <th colspan="2" align="left" valign="middle"  scope="col">
        <asp:TextBox ID="txtEditRemark" runat="server" TextMode="MultiLine" 
            CssClass="box3"></asp:TextBox>    
      </th>
    <th align="right" valign="top"  scope="col">
        &nbsp;</th>
  </tr>
</table>
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

