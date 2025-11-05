<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="CustomerMaster_New.aspx.cs" Inherits="Module_SD_Cust_masters_CustomerMaster_New" Title="ERP" Theme="Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

    <script src="../../../Javascript/PopUpMsg.js" type="text/javascript"></script>

    <link href="../../../Css/StyleSheet.css" rel="stylesheet" type="text/css" />

    <script src="../../../Javascript/loadingNotifier.js" type="text/javascript"></script>
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
    <th height="20" align="left" valign="middle"  scope="col" class="fontcsswhite" 
          colspan="4" style="background:url(../../../images/hdbg.JPG)">
        &nbsp;<strong>Customer Master - New</strong></th>
  </tr>
  <tr valign="top">
    <th width="17%" height="22" align="left" valign="middle"  scope="col" class="fontcss">&nbsp;Customer's Name</th>
    <th colspan="2" align="left" valign="middle"  scope="col">
        <asp:TextBox ID="txtNewCustName" runat="server" CssClass="box3" Width="350px"></asp:TextBox>&nbsp;<asp:RequiredFieldValidator 
            ID="ReqCustNM" runat="server" ControlToValidate="txtNewCustName" 
            ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
      </th>
    <th align="right" valign="middle"  scope="col">
        <asp:Button ID="Submit" runat="server" Text="Submit" 
            OnClientClick="return confirmationAdd()" CssClass="redbox" 
            onclick="Submit_Click" ValidationGroup="A" /></th>
  </tr>
  <tr valign="top"  >
    <th width="17%" height="23" align="center" valign="middle"  scope="col" bgcolor="#e5e5e5">Address/Details</th>
    <th width="27%" align="center" valign="middle"  scope="col" bgcolor="#e5e5e5">REGD. OFFICE</th>
    <th width="28%" align="center" valign="middle"  scope="col" bgcolor="#e5e5e5">WORKS/FACTORY</th>
    <th width="28%" align="center" valign="middle"  scope="col" bgcolor="#e5e5e5">MATERIAL DELIVERY</th>
  </tr>
  <tr valign="top"  >
    <th height="28" align="left" valign="top"  scope="col"  class="fontcss">&nbsp;Address</th>
    <th align="left" valign="middle"  scope="col">
        <asp:TextBox ID="txtNewRegdAdd" runat="server" TextMode="MultiLine" CssClass="box3" 
            Width="230px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="ReqRegdAdd" runat="server" 
            ControlToValidate="txtNewRegdAdd" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
      </th>
    <th width="28%" align="left" valign="middle"  scope="col">
        <asp:TextBox ID="txtNewWorkAdd" runat="server" TextMode="MultiLine" CssClass="box3" 
            Width="230px"></asp:TextBox>    
        <asp:RequiredFieldValidator ID="ReqworkAdd" runat="server" 
            ControlToValidate="txtNewWorkAdd" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
      </th>
    <th width="28%" align="left" valign="middle"  scope="col">
        <asp:TextBox ID="txtNewMaterialDelAdd" runat="server" TextMode="MultiLine" CssClass="box3" 
            Width="230px"></asp:TextBox>    
        <asp:RequiredFieldValidator ID="ReqMaterialAdd" runat="server" 
            ControlToValidate="txtNewMaterialDelAdd" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
      </th>
  </tr>
  <tr valign="top"  >
    <th height="23" align="left" valign="middle"  scope="col" class="fontcss">&nbsp;Country</th>
    <th align="left" valign="middle"  scope="col">
        <asp:DropDownList ID="DDListNewRegdCountry" runat="server" CssClass="box3" 
            AutoPostBack="True" 
            onselectedindexchanged="DDListNewRegdCountry_SelectedIndexChanged"></asp:DropDownList>
        <asp:RequiredFieldValidator ID="ReqRegdCountry" runat="server" 
            ControlToValidate="DDListNewRegdCountry" ErrorMessage="*" InitialValue="Select" 
            ValidationGroup="A"></asp:RequiredFieldValidator>
      </th>
    <th align="left" valign="middle"  scope="col">
        <asp:DropDownList ID="DDListNewWorkCountry" runat="server" CssClass="box3" 
            AutoPostBack="True" 
            onselectedindexchanged="DDListNewWorkCountry_SelectedIndexChanged"></asp:DropDownList>    
        <asp:RequiredFieldValidator ID="ReqworkCountry" runat="server" 
            ControlToValidate="DDListNewWorkCountry" ErrorMessage="*" InitialValue="Select" 
            ValidationGroup="A"></asp:RequiredFieldValidator>
      </th>
    <th align="left" valign="middle"  scope="col">
        <asp:DropDownList ID="DDListNewMaterialDelCountry" runat="server" 
            CssClass="box3" AutoPostBack="True" 
            onselectedindexchanged="DDListNewMaterialDelCountry_SelectedIndexChanged"></asp:DropDownList>    
        <asp:RequiredFieldValidator ID="ReqMaterialCountry" runat="server" 
            ControlToValidate="DDListNewMaterialDelCountry" ErrorMessage="*" 
            InitialValue="Select" ValidationGroup="A"></asp:RequiredFieldValidator>
      </th>
  </tr>
  <tr valign="top"  >
    <th height="23" align="left" valign="middle"  scope="col"  class="fontcss">&nbsp;State</th>
    <th align="left" valign="middle"  scope="col">
        <asp:DropDownList ID="DDListNewRegdState" runat="server" CssClass="box3" 
            AutoPostBack="True" 
            onselectedindexchanged="DDListNewRegdState_SelectedIndexChanged"></asp:DropDownList>    
        <asp:RequiredFieldValidator ID="ReqRegdState" runat="server" 
            ControlToValidate="DDListNewRegdState" ErrorMessage="*" InitialValue="Select" 
            ValidationGroup="A"></asp:RequiredFieldValidator>
      </th>
    <th align="left" valign="middle"  scope="col">
        <asp:DropDownList ID="DDListNewWorkState" runat="server" CssClass="box3" 
            AutoPostBack="True" 
            onselectedindexchanged="DDListNewWorkState_SelectedIndexChanged"></asp:DropDownList>    
        <asp:RequiredFieldValidator ID="ReqWorkState" runat="server" 
            ControlToValidate="DDListNewWorkState" ErrorMessage="*" InitialValue="Select" 
            ValidationGroup="A"></asp:RequiredFieldValidator>
      </th>
    <th align="left" valign="middle"  scope="col">
        <asp:DropDownList ID="DDListNewMaterialDelState" runat="server" CssClass="box3" 
            AutoPostBack="True" 
            onselectedindexchanged="DDListNewMaterialDelState_SelectedIndexChanged"></asp:DropDownList>    
        <asp:RequiredFieldValidator ID="ReqMaterialState" runat="server" 
            ControlToValidate="DDListNewMaterialDelState" ErrorMessage="*" 
            InitialValue="Select" ValidationGroup="A"></asp:RequiredFieldValidator>
      </th>
  </tr>
  <tr valign="top"  >
    <th height="23" align="left" valign="middle"  scope="col" class="fontcss">&nbsp;City</th>
    <th align="left" valign="middle"  scope="col">
        <asp:DropDownList ID="DDListNewRegdCity" runat="server" CssClass="box3" 
            onselectedindexchanged="DDListNewRegdCity_SelectedIndexChanged"></asp:DropDownList>    
        <asp:RequiredFieldValidator ID="ReqRegdCity" runat="server" 
            ControlToValidate="DDListNewRegdCity" ErrorMessage="*" InitialValue="Select" 
            ValidationGroup="A"></asp:RequiredFieldValidator>
      </th>
    <th align="left" valign="middle"  scope="col">
        <asp:DropDownList ID="DDListNewWorkCity" runat="server" CssClass="box3"></asp:DropDownList>    
        <asp:RequiredFieldValidator ID="ReqWorkCity" runat="server" 
            ControlToValidate="DDListNewWorkCity" ErrorMessage="*" InitialValue="Select" 
            ValidationGroup="A"></asp:RequiredFieldValidator>
      </th>
    <th align="left" valign="middle"  scope="col">
        <asp:DropDownList ID="DDListNewMaterialDelCity" runat="server" CssClass="box3"></asp:DropDownList>    
        <asp:RequiredFieldValidator ID="ReqMaterialCity" runat="server" 
            ControlToValidate="DDListNewMaterialDelCity" ErrorMessage="*" 
            InitialValue="Select" ValidationGroup="A"></asp:RequiredFieldValidator>
      </th>
  </tr>
  <tr valign="top"  >
    <th height="23" align="left" valign="middle"  scope="col"  class="fontcss">&nbsp;PIN No.</th>
    <th align="left" valign="middle"  scope="col">
        <asp:TextBox ID="txtNewRegdPinNo" runat="server" CssClass="box3"></asp:TextBox>    
        <asp:RequiredFieldValidator ID="ReqRegdPin" runat="server" 
            ControlToValidate="txtNewRegdPinNo" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
      </th>
    <th align="left" valign="middle"  scope="col" >
        <asp:TextBox ID="txtNewWorkPinNo" runat="server" CssClass="box3"></asp:TextBox>    
        <asp:RequiredFieldValidator ID="ReqWorkPin" runat="server" 
            ControlToValidate="txtNewWorkPinNo" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
      </th>
    <th align="left" valign="middle"  scope="col">
        <asp:TextBox ID="txtNewMaterialDelPinNo" runat="server" CssClass="box3"></asp:TextBox>    
        <asp:RequiredFieldValidator ID="ReqMaterialPin" runat="server" 
            ControlToValidate="txtNewMaterialDelPinNo" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
      </th>
  </tr>
  <tr valign="top"  >
    <th height="23" align="left" valign="middle"  scope="col" class="fontcss">&nbsp;Contact No.</th>
    <th align="left" valign="middle"  scope="col">
        <asp:TextBox ID="txtNewRegdContactNo" runat="server" CssClass="box3"></asp:TextBox>    
        <asp:RequiredFieldValidator ID="ReqRegdContact" runat="server" 
            ControlToValidate="txtNewRegdContactNo" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
      </th>
    <th align="left" valign="middle"  scope="col">
        <asp:TextBox ID="txtNewWorkContactNo" runat="server" CssClass="box3"></asp:TextBox>    
        <asp:RequiredFieldValidator ID="ReqWorkContact" runat="server" 
            ControlToValidate="txtNewWorkContactNo" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
      </th>
    <th align="left" valign="middle"  scope="col">
        <asp:TextBox ID="txtNewMaterialDelContactNo" runat="server" CssClass="box3"></asp:TextBox>    
        <asp:RequiredFieldValidator ID="ReqMaterialContact" runat="server" 
            ControlToValidate="txtNewMaterialDelContactNo" ErrorMessage="*" 
            ValidationGroup="A"></asp:RequiredFieldValidator>
      </th>
  </tr>
  <tr valign="top"  >
    <th height="23" align="left" valign="middle"  scope="col" class="fontcss">&nbsp;</th>
    <th align="left" valign="middle"  scope="col">
        <asp:TextBox ID="txtNewRegdFaxNo" runat="server" CssClass="box3" 
            Visible="False">-</asp:TextBox>    
        <asp:RequiredFieldValidator ID="ReqRegdFax" runat="server" 
            ControlToValidate="txtNewRegdFaxNo" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
      </th>
    <th align="left" valign="middle"  scope="col">
        <asp:TextBox ID="txtNewWorkFaxNo" runat="server" CssClass="box3" 
            Visible="False">-</asp:TextBox>    
        <asp:RequiredFieldValidator ID="ReqWorkFax" runat="server" 
            ControlToValidate="txtNewWorkFaxNo" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
      </th>
    <th align="left" valign="middle"  scope="col">
        <asp:TextBox ID="txtNewMaterialDelFaxNo" runat="server" CssClass="box3" 
            Visible="False">-</asp:TextBox>    
        <asp:RequiredFieldValidator ID="ReqNMaterialFax" runat="server" 
            ControlToValidate="txtNewMaterialDelFaxNo" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
      </th>
  </tr>
  
  <tr valign="top"  >
    <th height="23" colspan="4" align="left" valign="top"  scope="col">
    <table width="100%" border="0" cellspacing="0" cellpadding="1">
      <tr>
        <td height="23" align="left" valign="middle" class="fontcss">&nbsp;Contact person</td>
        <td align="left" valign="middle"><asp:TextBox ID="txtNewContactPerson" 
                runat="server" CssClass="box3"></asp:TextBox>
            <asp:RequiredFieldValidator ID="ReqContPerson" runat="server" 
                ControlToValidate="txtNewContactPerson" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
          </td>
        <td align="left" valign="middle" class="fontcss">E-mail</td>
        <td align="left" valign="middle"><asp:TextBox ID="txtNewEmail" runat="server" 
                CssClass="box3"></asp:TextBox>
            <asp:RequiredFieldValidator ID="ReqEmail" runat="server" 
                ControlToValidate="txtNewEmail" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularEmail" runat="server" 
                ControlToValidate="txtNewEmail" ErrorMessage="*" 
                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                ValidationGroup="A"></asp:RegularExpressionValidator>
          </td>
        <td align="left" valign="middle" class="fontcss">Contact No.</td>
        <td align="left" valign="middle">
            <asp:TextBox ID="txtNewContactNo" runat="server" CssClass="box3"></asp:TextBox>
            <asp:RequiredFieldValidator ID="ReqContact" runat="server" 
                ControlToValidate="txtNewContactNo" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
          </td>
      </tr>
      <tr>
        <td width="17%" height="23" align="left" valign="middle" class="fontcss">&nbsp;</td>
        <td width="21%" align="left" valign="middle">
            <asp:TextBox ID="txtNewJuridictionCode" runat="server" CssClass="box3" 
                Visible="False">-</asp:TextBox>
            <asp:RequiredFieldValidator ID="ReqJuridCode" runat="server" 
                ControlToValidate="txtNewJuridictionCode" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
          </td>
        <td width="10%" align="left" valign="middle" class="fontcss">&nbsp;</td>
        <td width="20%" align="left" valign="middle">
            <asp:TextBox ID="txtNewEccNo" runat="server" CssClass="box3" Visible="False">-</asp:TextBox>
            <asp:RequiredFieldValidator ID="ReqECCNO" runat="server" 
                ControlToValidate="txtNewEccNo" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
          </td>
        <td width="10%" align="left" valign="middle" class="fontcss">&nbsp;</td>
        <td width="22%" align="left" valign="middle">
            <asp:TextBox ID="txtNewRange" runat="server" CssClass="box3" Visible="False">-</asp:TextBox>
            <asp:RequiredFieldValidator ID="ReqRange" runat="server" 
                ControlToValidate="txtNewRange" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
          </td>
      </tr>
      <tr class="fontcss">
        <td height="23" align="left" valign="middle" class="fontcss">&nbsp;</td>
        <td align="left" valign="middle">
            <asp:TextBox ID="txtNewCommissionurate" runat="server" CssClass="box3" 
                Visible="False">-</asp:TextBox>
            <asp:RequiredFieldValidator ID="ReqCommissinurate" runat="server" 
                ControlToValidate="txtNewCommissionurate" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
          </td>
        <td align="left" valign="middle" class="fontcss">&nbsp;</td>
        <td align="left" valign="middle">
            <asp:TextBox ID="txtNewDivn" runat="server" CssClass="box3" Visible="False">-</asp:TextBox>
            <asp:RequiredFieldValidator ID="ReqDivn" runat="server" 
                ControlToValidate="txtNewDivn" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
          </td>
        <td align="left" valign="middle" class="fontcss">&nbsp;</td>
        <td align="left" valign="middle">
            <asp:TextBox ID="txtNewPanNo" runat="server" CssClass="box3" Visible="False">-</asp:TextBox>
          <asp:RequiredFieldValidator ID="ReqPanNo" runat="server" 
                ControlToValidate="txtNewPanNo" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
          </td>
      </tr>
      <tr>
        <td height="23" align="left" valign="middle" class="fontcss">&nbsp;</td>
        <td align="left" valign="middle">
            <asp:TextBox ID="txtNewTinVatNo" runat="server" CssClass="box3" Visible="False">-</asp:TextBox>
            <asp:RequiredFieldValidator ID="ReqTinVat" runat="server" 
                ControlToValidate="txtNewTinVatNo" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
          </td>
        <td align="left" valign="middle" class="fontcss">GST No.</td>
        <td align="left" valign="middle">
            <asp:TextBox ID="txtNewTinCstNo" runat="server" CssClass="box3"></asp:TextBox>
            <asp:RequiredFieldValidator ID="ReqTinCST" runat="server" 
                ControlToValidate="txtNewTinCstNo" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
          </td>
        <td align="left" valign="middle" class="fontcss" visible="True">&nbsp;</td>
        <td align="left" valign="middle">
            <asp:TextBox ID="txtNewTdsCode" runat="server" CssClass="box3" Visible="False">-</asp:TextBox>
            <asp:RequiredFieldValidator Visible="True" ID="ReqTDS" runat="server" 
                ControlToValidate="txtNewTdsCode" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
          </td>
      </tr>
      
    </table></th>
  </tr>
  
  <tr valign="top"  >
    <th height="23" align="left" valign="top"  scope="col" class="fontcss"> &nbsp;Remarks&nbsp;</th>
    <th colspan="2" align="left" valign="middle"  scope="col">
        <asp:TextBox ID="txtNewRemark" runat="server" TextMode="MultiLine" 
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

