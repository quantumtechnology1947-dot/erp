<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Module_SalesDistribution_Transactions_CustEnquiry_Delete_Details, newerp_deploy" title="ERP" theme="Default" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../../../Css/StyleSheet.css" rel="stylesheet" type="text/css" />

    <script src="../../../Javascript/PopUpMsg.js" type="text/javascript"></script>

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

<table width="100%"  border="0" align="center" cellpadding="0" cellspacing="0" Class="fontcss">
  <tr valign="top"  >
    <th height="20" align="left" valign="middle"  scope="col" class="fontcsswhite" colspan="4" style="background:url(../../../images/hdbg.JPG)">
        &nbsp;&nbsp;<strong>Customer Enquiry - Delete</strong></th>
  </tr>
  <tr valign="top"  >
    <th width="17%" height="22" align="left" valign="middle"  scope="col" 
          class="fontcss">&nbsp; Enquiry Id</th>
    <th colspan="2" align="left" valign="middle"  scope="col">
        <asp:Label ID="hfEnqId" runat="server"></asp:Label>
      </th>
    <th align="right" valign="middle"  scope="col">
        <asp:Button ID="Delete" runat="server" Text="Delete" CssClass="redbox" 
            onclick="Delete_Click" onclientclick="return confirmationDelete()"/>&nbsp;<asp:Button ID="Button1" runat="server" 
            CssClass="redbox" onclick="Button1_Click" Text="Cancel" />
&nbsp;</th>
    </tr>
  <tr valign="top"  >
    <th width="17%" height="22" align="left" valign="middle"  scope="col" 
          class="fontcss">&nbsp;Customer's Name</th>
    <th colspan="2" align="left" valign="middle"  scope="col">
        <asp:Label ID="lblCustName" runat="server"></asp:Label>
        
        [<asp:Label ID="hfCustId" runat="server"></asp:Label>
        ]</th>
    <th align="right" valign="middle"  scope="col">
        &nbsp;</th>
    </tr>
  <tr valign="top"  >
    <th width="17%" height="23" align="center" valign="middle"  scope="col" style="background-color:Silver">Address/Details</th>
    <th width="27%" align="center" valign="middle"  scope="col" style="background-color:Silver">REGD. OFFICE</th>
    <th width="28%" align="center" valign="middle"  scope="col" style="background-color:Silver">WORKS/FACTORY</th>
    <th width="28%" align="center" valign="middle"  scope="col" style="background-color:Silver">MATERIAL DELIVERY</th>
  </tr>
  <tr valign="top"  >
    <th height="28" align="left" valign="top"  scope="col" class="fontcss">&nbsp;Address</th>
    <th align="left" valign="middle"  scope="col">
        <asp:TextBox ID="txtDeleteRegdAdd" runat="server" TextMode="MultiLine" CssClass="box3" 
            Width="230px" ReadOnly="True"></asp:TextBox>
      </th>
    <th width="28%" align="left" valign="middle"  scope="col">
        <asp:TextBox ID="txtDeleteWorkAdd" runat="server" TextMode="MultiLine" CssClass="box3" 
            Width="230px" ReadOnly="True"></asp:TextBox>    
      </th>
    <th width="28%" align="left" valign="middle"  scope="col">
        <asp:TextBox ID="txtDeleteMaterialDelAdd" runat="server" TextMode="MultiLine" CssClass="box3" 
            Width="230px" ReadOnly="True"></asp:TextBox>    
      </th>
  </tr>
  <tr valign="top"  >
    <th height="23" align="left" valign="middle"  scope="col" class="fontcss">&nbsp;Country</th>
    <th align="left" valign="middle"  scope="col">
        <asp:DropDownList ID="DDListDeleteRegdCountry" runat="server" CssClass="box3" 
            AutoPostBack="True" 
            onselectedindexchanged="DDListDeleteRegdCountry_SelectedIndexChanged"></asp:DropDownList>
      </th>
    <th align="left" valign="middle"  scope="col">
        <asp:DropDownList ID="DDListDeleteWorkCountry" runat="server" CssClass="box3" 
            AutoPostBack="True" 
            onselectedindexchanged="DDListDeleteWorkCountry_SelectedIndexChanged"></asp:DropDownList>    
      </th>
    <th align="left" valign="middle"  scope="col">
        <asp:DropDownList ID="DDListDeleteMaterialDelCountry" runat="server" 
            CssClass="box3" AutoPostBack="True" 
            onselectedindexchanged="DDListDeleteMaterialDelCountry_SelectedIndexChanged"></asp:DropDownList>    
      </th>
  </tr>
  <tr valign="top"  >
    <th height="23" align="left" valign="middle"  scope="col" class="fontcss">&nbsp;State</th>
    <th align="left" valign="middle"  scope="col">
        <asp:DropDownList ID="DDListDeleteRegdState" runat="server" CssClass="box3" 
            AutoPostBack="True" 
            onselectedindexchanged="DDListDeleteRegdState_SelectedIndexChanged"></asp:DropDownList>    
      </th>
    <th align="left" valign="middle"  scope="col">
        <asp:DropDownList ID="DDListDeleteWorkState" runat="server" CssClass="box3" 
            AutoPostBack="True" 
            onselectedindexchanged="DDListDeleteWorkState_SelectedIndexChanged"></asp:DropDownList>    
      </th>
    <th align="left" valign="middle"  scope="col">
        <asp:DropDownList ID="DDListDeleteMaterialDelState" runat="server" 
            CssClass="box3" AutoPostBack="True" 
            onselectedindexchanged="DDListDeleteMaterialDelState_SelectedIndexChanged"></asp:DropDownList>    
      </th>
  </tr>
  <tr valign="top"  >
    <th height="23" align="left" valign="middle"  scope="col" class="fontcss">&nbsp;City</th>
    <th align="left" valign="middle"  scope="col">
        <asp:DropDownList ID="DDListDeleteRegdCity" runat="server" CssClass="box3" 
            ></asp:DropDownList>    
      </th>
    <th align="left" valign="middle"  scope="col">
        <asp:DropDownList ID="DDListDeleteWorkCity" runat="server" CssClass="box3" 
            Height="18px"></asp:DropDownList>    
      </th>
    <th align="left" valign="middle"  scope="col">
        <asp:DropDownList ID="DDListDeleteMaterialDelCity" runat="server" 
            CssClass="box3"></asp:DropDownList>    
      </th>
  </tr>
  <tr valign="top"  >
    <th height="23" align="left" valign="middle"  scope="col" class="fontcss">&nbsp;PIN No.</th>
    <th align="left" valign="middle"  scope="col">
        <asp:TextBox ID="txtDeleteRegdPinNo" runat="server" CssClass="box3" 
            ReadOnly="True"></asp:TextBox>    
      </th>
    <th align="left" valign="middle"  scope="col" >
        <asp:TextBox ID="txtDeleteWorkPinNo" runat="server" CssClass="box3" 
            ReadOnly="True"></asp:TextBox>    
      </th>
    <th align="left" valign="middle"  scope="col">
        <asp:TextBox ID="txtDeleteMaterialDelPinNo" runat="server" CssClass="box3" 
            ReadOnly="True"></asp:TextBox>    
      </th>
  </tr>
  <tr valign="top"  >
    <th height="23" align="left" valign="middle"  scope="col" class="fontcss">&nbsp;Contact No.</th>
    <th align="left" valign="middle"  scope="col">
        <asp:TextBox ID="txtDeleteRegdContactNo" runat="server" CssClass="box3" 
            ReadOnly="True"></asp:TextBox>    
      </th>
    <th align="left" valign="middle"  scope="col">
        <asp:TextBox ID="txtDeleteWorkContactNo" runat="server" CssClass="box3" 
            ReadOnly="True"></asp:TextBox>    
      </th>
    <th align="left" valign="middle"  scope="col">
        <asp:TextBox ID="txtDeleteMaterialDelContactNo" runat="server" CssClass="box3" 
            ReadOnly="True"></asp:TextBox>    
      </th>
  </tr>
  <tr valign="top"  >
    <th height="23" align="left" valign="middle"  scope="col" class="fontcss">&nbsp;Fax No.</th>
    <th align="left" valign="middle"  scope="col">
        <asp:TextBox ID="txtDeleteRegdFaxNo" runat="server" CssClass="box3" 
            ReadOnly="True"></asp:TextBox>    
      </th>
    <th align="left" valign="middle"  scope="col">
        <asp:TextBox ID="txtDeleteWorkFaxNo" runat="server" CssClass="box3" 
            ReadOnly="True"></asp:TextBox>    
      </th>
    <th align="left" valign="middle"  scope="col">
        <asp:TextBox ID="txtDeleteMaterialDelFaxNo" runat="server" CssClass="box3" 
            ReadOnly="True"></asp:TextBox>    
      </th>
  </tr>
  
  <tr valign="top"  >
    <th height="23" colspan="4" align="left" valign="top"  scope="col">
    <table width="100%" border="0" cellspacing="0" cellpadding="1">
      <tr>
        <td height="23" align="left" valign="middle" class="fontcss">&nbsp;Contact person</td>
        <td align="left" valign="middle">
            <asp:TextBox ID="txtDeleteContactPerson" 
                runat="server" CssClass="box3" ReadOnly="True"></asp:TextBox>
          </td>
        <td align="left" valign="middle" class="fontcss">E-mail</td>
        <td align="left" valign="middle">
            <asp:TextBox ID="txtDeleteEmail" runat="server" 
                CssClass="box3" ReadOnly="True"></asp:TextBox>
          </td>
        <td align="left" valign="middle" class="fontcss">Contact No.</td>
        <td align="left" valign="middle">
            <asp:TextBox ID="txtDeleteContactNo" runat="server" CssClass="box3" 
                ReadOnly="True"></asp:TextBox>
          </td>
      </tr>
      <tr>
        <td width="17%" height="23" align="left" valign="middle" class="fontcss">&nbsp;Juridiction Code</td>
        <td width="21%" align="left" valign="middle">
            <asp:TextBox ID="txtDeleteJuridictionCode" runat="server" CssClass="box3" 
                ReadOnly="True"></asp:TextBox>
          </td>
        <td width="10%" align="left" valign="middle" class="fontcss">ECC.No.</td>
        <td width="20%" align="left" valign="middle">
            <asp:TextBox ID="txtDeleteEccNo" runat="server" CssClass="box3" ReadOnly="True"></asp:TextBox>
          </td>
        <td width="10%" align="left" valign="middle" class="fontcss">Range&nbsp;</td>
        <td width="22%" align="left" valign="middle">
            <asp:TextBox ID="txtDeleteRange" runat="server" CssClass="box3" ReadOnly="True"></asp:TextBox>
          </td>
      </tr>
      <tr>
        <td height="23" align="left" valign="middle" class="fontcss">&nbsp;Commissionurate&nbsp; </td>
        <td align="left" valign="middle">
            <asp:TextBox ID="txtDeleteCommissionurate" runat="server" CssClass="box3" 
                ReadOnly="True"></asp:TextBox>
          </td>
        <td align="left" valign="middle" class="fontcss">Divn</td>
        <td align="left" valign="middle">
            <asp:TextBox ID="txtDeleteDivn" runat="server" CssClass="box3" ReadOnly="True"></asp:TextBox>
          </td>
        <td align="left" valign="middle" class="fontcss">PAN No.</td>
        <td align="left" valign="middle">
            <asp:TextBox ID="txtDeletePanNo" runat="server" CssClass="box3" ReadOnly="True"></asp:TextBox>
          </td>
      </tr>
      <tr>
        <td height="23" align="left" valign="middle" class="fontcss">&nbsp;TIN/VAT No.</td>
        <td align="left" valign="middle">
            <asp:TextBox ID="txtDeleteTinVatNo" runat="server" CssClass="box3" 
                ReadOnly="True"></asp:TextBox>
          </td>
        <td align="left" valign="middle" class="fontcss">TIN/CST No.</td>
        <td align="left" valign="middle">
            <asp:TextBox ID="txtDeleteTinCstNo" runat="server" CssClass="box3" 
                ReadOnly="True"></asp:TextBox>
          </td>
        <td align="left" valign="middle" class="fontcss">TDS Code.</td>
        <td align="left" valign="middle">
            <asp:TextBox ID="txtDeleteTdsCode" runat="server" CssClass="box3" 
                ReadOnly="True"></asp:TextBox>
          </td>
      </tr>
      
    </table></th>
  </tr>
  
  <tr valign="top"  >
    <th height="23" align="left" valign="top"  scope="col" class="fontcss"> &nbsp;Remarks&nbsp;</th>
    <th colspan="2" align="left" valign="middle"  scope="col">
        <asp:TextBox ID="txtDeleteRemark" runat="server" TextMode="MultiLine" 
            CssClass="box3" ReadOnly="True"></asp:TextBox>    
      </th>
    <th align="right" valign="top"  scope="col">
        &nbsp;</th>
  </tr>
 
  <tr valign="top"  >
    <th height="23" align="left" valign="top"  scope="col" class="fontcss"> Enquiry For </th>
    <th colspan="3" align="left" valign="middle"  scope="col">
                                <asp:TextBox ID="txtDeleteEnquiryFor" runat="server" TextMode="MultiLine" 
                                    Width="500" Height="100" CssClass="box3" ReadOnly="True"></asp:TextBox>
      </th>
  </tr>
  
  <tr valign="top"  >
    <th height="23" align="left" valign="top"  scope="col" class="fontcss" 
          colspan="4"> &nbsp;</th>
  </tr>
  
</table>
            </td>
        </tr>
    </table>

</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

