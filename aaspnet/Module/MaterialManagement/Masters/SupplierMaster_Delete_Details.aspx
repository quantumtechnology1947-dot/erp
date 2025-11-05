<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Module_MaterialManagement_Masters_SupplierMaster_Delete_Details, newerp_deploy" title="ERP" theme="Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../../../Css/yui-datatable.css" rel="stylesheet" type="text/css" />
    <link href="../../../Css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <script src="../../../Javascript/PopUpMsg.js" type="text/javascript"></script>
     <script src="../../../Javascript/loadingNotifier.js" type="text/javascript"></script>
    <style type="text/css">
       
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
    <table cellpadding="0" cellspacing="0" class="box3" width="97%" align="center" >
        <tr>
            <td>

<table width="100%"  border="0" align="center" cellpadding="0" cellspacing="2" Class="fontcss">
  <tr valign="top"  >
    <th height="20" align="left" valign="middle"  scope="col" class="fontcsswhite" colspan="4" style="background:url(../../../images/hdbg.JPG)">
        &nbsp;<strong>Supplier Master - Delete</strong></th>
  </tr>
  <tr valign="top"  >
    <th width="17%" height="22" align="left" valign="middle"  scope="col" 
          class="fontcss">&nbsp;Supplier's Name</th>
    <th colspan="2" align="left" valign="middle"  scope="col">
       <asp:Label ID="lblSupName" 
            runat="server"></asp:Label>
        <asp:Label ID="hfSupplierId" runat="server" Visible="False"></asp:Label>
&nbsp;</th>
    <th align="right" valign="middle"  scope="col">
                            <asp:Button ID="Delete" runat="server" Text="Delete" CssClass="redbox" 
                               OnClientClick=" return confirmationDelete()"   onclick="Delete_Click" />
                            <asp:Button ID="Button1" runat="server" CssClass="redbox" 
                                onclick="Button1_Click" Text="Cancel" />
                            &nbsp;</th>
    </tr>
  <tr valign="top"  >
    <th width="17%" height="22" align="left" valign="top"  scope="col" 
          class="fontcss">&nbsp;Scope of Supply</th>
    <th colspan="2" align="left" valign="middle"  scope="col">
        <asp:TextBox ID="txtEditScopeofSupply" runat="server" Height="45px" 
            TextMode="MultiLine" Width="350px"></asp:TextBox>
      </th>
    <th align="right" valign="middle"  scope="col">
        &nbsp;</th>
    </tr>
  <tr valign="top"  >
    <th width="17%" height="23" align="center" valign="middle"  scope="col" bgcolor="#e5e5e5">&nbsp;Address/Details</th>
    <th width="27%" align="center" valign="middle"  scope="col" bgcolor="#e5e5e5">REGD. OFFICE</th>
    <th align="center" valign="middle"  scope="col" bgcolor="#e5e5e5" class="style4">WORKS/FACTORY</th>
    <th width="28%" align="center" valign="middle"  scope="col" bgcolor="#e5e5e5">MATERIAL DELIVERY</th>
  </tr>
  <tr valign="top"  >
    <th height="28" align="left" valign="top"  scope="col" class="fontcss">&nbsp;Address</th>
    <th align="left" valign="middle"  scope="col">
        <asp:TextBox ID="txtEditRegdAdd" runat="server" TextMode="MultiLine" CssClass="box3" 
            Width="230px"></asp:TextBox>
      </th>
    <th align="left" valign="middle"  scope="col" class="style4">
        <asp:TextBox ID="txtEditWorkAdd" runat="server" TextMode="MultiLine" CssClass="box3" 
            Width="230px"></asp:TextBox>    
      </th>
    <th width="28%" align="left" valign="middle"  scope="col">
        <asp:TextBox ID="txtEditMaterialDelAdd" runat="server" TextMode="MultiLine" CssClass="box3" 
            Width="230px"></asp:TextBox>    
      </th>
  </tr>
  <tr valign="top"  >
    <th height="23" align="left" valign="middle"  scope="col" class="fontcss">&nbsp;Country</th>
    <th align="left" valign="middle"  scope="col">
        <asp:DropDownList ID="DDListEditRegdCountry" runat="server" CssClass="box3" 
            AutoPostBack="True" 
            onselectedindexchanged="DDListEditRegdCountry_SelectedIndexChanged"></asp:DropDownList>
      </th>
    <th align="left" valign="middle"  scope="col" class="style4">
        <asp:DropDownList ID="DDListEditWorkCountry" runat="server" CssClass="box3" 
            AutoPostBack="True" 
            onselectedindexchanged="DDListEditWorkCountry_SelectedIndexChanged"></asp:DropDownList>    
      </th>
    <th align="left" valign="middle"  scope="col">
        <asp:DropDownList ID="DDListEditMaterialDelCountry" runat="server" 
            CssClass="box3" AutoPostBack="True" 
            onselectedindexchanged="DDListEditMaterialDelCountry_SelectedIndexChanged"></asp:DropDownList>    
      </th>
  </tr>
  <tr valign="top"  >
    <th height="23" align="left" valign="middle"  scope="col" class="fontcss">&nbsp;State</th>
    <th align="left" valign="middle"  scope="col">
        <asp:DropDownList ID="DDListEditRegdState" runat="server" CssClass="box3" 
            AutoPostBack="True" 
            onselectedindexchanged="DDListEditRegdState_SelectedIndexChanged"></asp:DropDownList>    
      </th>
    <th align="left" valign="middle"  scope="col" class="style4">
        <asp:DropDownList ID="DDListEditWorkState" runat="server" CssClass="box3" 
            AutoPostBack="True" 
            onselectedindexchanged="DDListEditWorkState_SelectedIndexChanged"></asp:DropDownList>    
      </th>
    <th align="left" valign="middle"  scope="col">
        <asp:DropDownList ID="DDListEditMaterialDelState" runat="server" 
            CssClass="box3" AutoPostBack="True" 
            onselectedindexchanged="DDListEditMaterialDelState_SelectedIndexChanged"></asp:DropDownList>    
      </th>
  </tr>
  <tr valign="top"  >
    <th height="23" align="left" valign="middle"  scope="col" class="fontcss">&nbsp;City</th>
    <th align="left" valign="middle"  scope="col">
        <asp:DropDownList ID="DDListEditRegdCity" runat="server" CssClass="box3"></asp:DropDownList>    
      </th>
    <th align="left" valign="middle"  scope="col" class="style4">
        <asp:DropDownList ID="DDListEditWorkCity" runat="server" CssClass="box3" 
            Height="18px"></asp:DropDownList>    
      </th>
    <th align="left" valign="middle"  scope="col">
        <asp:DropDownList ID="DDListEditMaterialDelCity" runat="server" CssClass="box3"></asp:DropDownList>    
      </th>
  </tr>
  <tr valign="top"  >
    <th height="23" align="left" valign="middle"  scope="col" class="fontcss">&nbsp;PIN No.</th>
    <th align="left" valign="middle"  scope="col">
        <asp:TextBox ID="txtEditRegdPinNo" runat="server" CssClass="box3"></asp:TextBox>    
      </th>
    <th align="left" valign="middle"  scope="col" class="style4" >
        <asp:TextBox ID="txtEditWorkPinNo" runat="server" CssClass="box3"></asp:TextBox>    
      </th>
    <th align="left" valign="middle"  scope="col">
        <asp:TextBox ID="txtEditMaterialDelPinNo" runat="server" CssClass="box3"></asp:TextBox>    
      </th>
  </tr>
  <tr valign="top"  >
    <th height="23" align="left" valign="middle"  scope="col" class="fontcss">&nbsp;Contact No.</th>
    <th align="left" valign="middle"  scope="col">
        <asp:TextBox ID="txtEditRegdContactNo" runat="server" CssClass="box3"></asp:TextBox>    
      </th>
    <th align="left" valign="middle"  scope="col" class="style4">
        <asp:TextBox ID="txtEditWorkContactNo" runat="server" CssClass="box3"></asp:TextBox>    
      </th>
    <th align="left" valign="middle"  scope="col">
        <asp:TextBox ID="txtEditMaterialDelContactNo" runat="server" CssClass="box3"></asp:TextBox>    
      </th>
  </tr>
  <tr valign="top"  >
    <th height="23" align="left" valign="middle"  scope="col" class="fontcss">&nbsp;Fax No.</th>
    <th align="left" valign="middle"  scope="col">
        <asp:TextBox ID="txtEditRegdFaxNo" runat="server" CssClass="box3"></asp:TextBox>    
      </th>
    <th align="left" valign="middle"  scope="col" class="style4">
        <asp:TextBox ID="txtEditWorkFaxNo" runat="server" CssClass="box3"></asp:TextBox>    
      </th>
    <th align="left" valign="middle"  scope="col">
        <asp:TextBox ID="txtEditMaterialDelFaxNo" runat="server" CssClass="box3"></asp:TextBox>    
      </th>
  </tr>
  
  <tr valign="top"  >
    <th height="23" colspan="4" align="left" valign="top"  scope="col">
    <table width="100%" border="0" cellspacing="0" cellpadding="1">
      <tr>
        <td height="23" align="left" valign="middle" class="fontcss">&nbsp;Contact person</td>
        <td align="left" valign="middle" class="style6"><asp:TextBox ID="txtEditContactPerson" 
                runat="server" CssClass="box3"></asp:TextBox>
          </td>
        <td align="left" valign="middle" class="fontcss" width="15%">E-mail</td>
        <td align="left" valign="middle" class="style5" width="23%"><asp:TextBox ID="txtEditEmail" runat="server" 
                CssClass="box3"></asp:TextBox>
          </td>
        <td align="left" valign="middle" class="fontcss" width="15%">Contact No.</td>
        <td align="left" valign="middle">
            <asp:TextBox ID="txtEditContactNo" runat="server" CssClass="box3"></asp:TextBox>
          </td>
      </tr>
      <tr>
        <td width="17%" height="23" align="left" valign="middle" class="fontcss">&nbsp;Juridiction Code</td>
        <td align="left" valign="middle" class="style6">
            <asp:TextBox ID="txtEditJuridictionCode" runat="server" CssClass="box3"></asp:TextBox>
          </td>
        <td align="left" valign="middle" class="fontcss">ECC.No.</td>
        <td align="left" valign="middle" class="style5">
            <asp:TextBox ID="txtEditEccNo" runat="server" CssClass="box3"></asp:TextBox>
          </td>
        <td align="left" valign="middle" class="fontcss">Range&nbsp;</td>
        <td width="22%" align="left" valign="middle">
            <asp:TextBox ID="txtEditRange" runat="server" CssClass="box3"></asp:TextBox>
          </td>
      </tr>
      <tr>
        <td height="23" align="left" valign="middle" class="fontcss">&nbsp;Commissionurate&nbsp; </td>
        <td align="left" valign="middle" class="style6">
            <asp:TextBox ID="txtEditCommissionurate" runat="server" CssClass="box3"></asp:TextBox>
          </td>
        <td align="left" valign="middle" class="fontcss">Divn</td>
        <td align="left" valign="middle" class="style5">
            <asp:TextBox ID="txtEditDivn" runat="server" CssClass="box3"></asp:TextBox>
          </td>
        <td align="left" valign="middle" class="fontcss">PAN No.</td>
        <td align="left" valign="middle">
            <asp:TextBox ID="txtEditPanNo" runat="server" CssClass="box3"></asp:TextBox>
          </td>
      </tr>
      <tr>
        <td height="23" align="left" valign="middle" class="fontcss">&nbsp;TIN/VAT No.</td>
        <td align="left" valign="middle" class="style6">
            <asp:TextBox ID="txtEditTinVatNo" runat="server" CssClass="box3"></asp:TextBox>
          </td>
        <td align="left" valign="middle" class="fontcss">TIN/CST No.</td>
        <td align="left" valign="middle" class="style5">
            <asp:TextBox ID="txtEditTinCstNo" runat="server" CssClass="box3"></asp:TextBox>
          </td>
        <td align="left" valign="middle" class="fontcss">TDS Code.</td>
        <td align="left" valign="middle">
            <asp:TextBox ID="txtEditTdsCode" runat="server" CssClass="box3"></asp:TextBox>
          </td>
      </tr>
      
      <tr>
        <td height="23" align="left" valign="middle" class="fontcss">&nbsp;Mod Vat Applicable</td>
        <td align="left" valign="middle" id="rbMVAYes" class="style6">
            <asp:RadioButton ID="rbMVAYes" runat="server" GroupName="MVA" Text="Yes" />
&nbsp;<asp:RadioButton ID="rbMVANo" runat="server" GroupName="MVA" 
                Text="No" />
          </td>
        <td align="left" valign="middle" class="fontcss">Mod Vat Invoice</td>
        <td align="left" valign="middle" class="style5">
            <asp:RadioButton ID="rbMVIYes" runat="server" GroupName="MVI" Text="Yes" />
            <asp:RadioButton ID="rbMVINo" runat="server" GroupName="MVI" 
                Text="No" />
          </td>
        <td align="left" valign="middle" class="style3">&nbsp;</td>
        <td align="left" valign="middle">
            &nbsp;</td>
      </tr>
      
      <tr>
        <td height="23" align="left" valign="top" class="fontcss">&nbsp;Bank Acc No</td>
        <td align="left" valign="middle" class="style6">
            <asp:TextBox ID="txtBankAccNo" runat="server"></asp:TextBox>
          </td>
        <td align="left" valign="middle" class="fontcss">Bank Name</td>
        <td align="left" valign="middle" class="style5">
            <asp:TextBox ID="txtBankName" runat="server"></asp:TextBox>
          </td>
        <td align="left" valign="middle" class="fontcss">Bank Branch</td>
        <td align="left" valign="middle">
            <asp:TextBox ID="txtBankBranch" runat="server"></asp:TextBox>
          </td>
      </tr>
      
      <tr>
        <td height="23" align="left" valign="top" class="fontcss">&nbsp;Bank Address</td>
        <td align="left" valign="middle" class="style6">
            <asp:TextBox ID="txtBankAddress" runat="server" TextMode="MultiLine" 
                Width="166px"></asp:TextBox>
          </td>
        <td align="left" valign="top" class="fontcss">Bank Acc Type</td>
        <td align="left" valign="top" class="style5">
            <asp:TextBox ID="txtBankAccType" runat="server"></asp:TextBox>
          </td>
        <td align="left" valign="top" class="fontcss">Service Coverage</td>
        <td align="left" valign="top">
            <asp:DropDownList ID="DDLServiceCoverage" runat="server" 
                DataSourceID="SqlDataSource3" DataTextField="Type" DataValueField="Id" 
                Width="150px">
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
        <td align="left" valign="middle" class="style6">
             <asp:DropDownList ID="DDLPF" runat="server" DataSourceID="SqlDataSourcePF" 
                            DataTextField="Terms" DataValueField="Id" CssClass="box3">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSourcePF" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:LocalSqlServer %>" 
                        SelectCommand="SELECT [Id], [Terms] FROM [tblPacking_Master]">
                    </asp:SqlDataSource>
          </td>
        <td align="left" valign="top" class="fontcss">
            <asp:Label ID="Label3" runat="server" Text="Excies / Service Tax"></asp:Label>
          </td>
        <td align="left" valign="top" class="style5">
            <asp:DropDownList ID="DDLExcies" runat="server" DataSourceID="SqlDataSourceExSer" 
                        DataTextField="Terms" DataValueField="Id" CssClass="box3">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSourceExSer" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:LocalSqlServer %>" 
                        SelectCommand="SELECT [Id], [Terms] FROM [tblExciseser_Master]">
                    </asp:SqlDataSource>
          </td>
        <td align="left" valign="top" class="fontcss">
            <asp:Label ID="Label4" runat="server" Text="VAT/CST"></asp:Label>
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
        <td align="left" valign="top" class="style6" colspan="2">
            <asp:Panel ID="Panel1" runat="server" CssClass="box3" Height="90px" 
                ScrollBars="Auto">
                <asp:CheckBoxList ID="CBLBusinessNature" runat="server" CssClass="fontcss">
                </asp:CheckBoxList>
            </asp:Panel>
          </td>
        <td align="right" valign="top" class="fontcss">
            Business Type</td>
        <td align="left" valign="top" class="style3" colspan="2">
            <asp:Panel ID="Panel2" runat="server" CssClass="box3" Height="90px" 
                ScrollBars="Auto">
                <asp:CheckBoxList ID="CBLBusinessType" runat="server" CssClass="fontcss">
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
            CssClass="box3" Width="496px"></asp:TextBox>    
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

