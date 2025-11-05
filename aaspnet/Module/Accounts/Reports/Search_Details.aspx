<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Module_Accounts_Reports_Search_Details, newerp_deploy" title="ERP" theme="Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<link href="../../../Css/yui-datatable.css" rel="stylesheet" type="text/css" />
    <link href="../../../Css/StyleSheet.css" rel="stylesheet" type="text/css" />

    <script src="../../../Javascript/PopUpMsg.js" type="text/javascript"></script>

    <script src="../../../Javascript/loadingNotifier.js" type="text/javascript"></script>   
  

    <style type="text/css">
        .style2
        {
            width: 100%;
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
<script  type="text/javascript">

    var GridId = "<%=GridView1.ClientID %>";
    var ScrollHeight = 300;
    window.onload = function () {
        var grid = document.getElementById(GridId);
        var gridWidth = grid.offsetWidth;
        var gridHeight = grid.offsetHeight;
        var headerCellWidths = new Array();
        for (var i = 0; i < grid.getElementsByTagName("TH").length; i++) {
            headerCellWidths[i] = grid.getElementsByTagName("TH")[i].offsetWidth;
                    }
        grid.parentNode.appendChild(document.createElement("div"));
        var parentDiv = grid.parentNode; 
        var table = document.createElement("table");
        for (i = 0; i < grid.attributes.length; i++) {
            if (grid.attributes[i].specified && grid.attributes[i].name != "id") {
                table.setAttribute(grid.attributes[i].name, grid.attributes[i].value);
            }
        }
        table.style.cssText = grid.style.cssText;
        table.style.width = gridWidth + "px";
        table.appendChild(document.createElement("tbody"));
        table.getElementsByTagName("tbody")[0].appendChild(grid.getElementsByTagName("TR")[0]);
        var cells = table.getElementsByTagName("TH");
 
        var gridRow = grid.getElementsByTagName("TR")[0];
        for (var i = 0; i < cells.length; i++) {
            var width;
            if (headerCellWidths[i] > gridRow.getElementsByTagName("TD")[i].offsetWidth) {
                width = headerCellWidths[i];
            }
            else {
                width = gridRow.getElementsByTagName("TD")[i].offsetWidth;
            }
            cells[i].style.width = parseInt(width - 3) + "px";
            gridRow.getElementsByTagName("TD")[i].style.width = parseInt(width - 3) + "px";
        }
        parentDiv.removeChild(grid); 
        var dummyHeader = document.createElement("div");
        dummyHeader.appendChild(table);
        parentDiv.appendChild(dummyHeader);
        var scrollableDiv = document.createElement("div");
        if(parseInt(gridHeight) > ScrollHeight){
             gridWidth = parseInt(gridWidth) + 17;
        }
        scrollableDiv.style.cssText = "overflow:auto;height:" + ScrollHeight + "px;width:" + gridWidth + "px";
        scrollableDiv.appendChild(grid);
        parentDiv.appendChild(scrollableDiv);
    }


</script>
<div > 
 <div >
     <strong>&nbsp; Select column to show in the GridView:</strong>&nbsp;<b>&nbsp;Check All:</b> <asp:CheckBox ID="checkAll" runat="server" 
         AutoPostBack="True" oncheckedchanged="checkAll_CheckedChanged" />   
     
     <table class="style2">
         <tr>
             <td valign="top">
                 <asp:Panel ID="Panel2" BorderWidth="1"  BorderStyle="Solid"  runat="server"> 
                 <table width="100%"><tr><td align="center">
                     <asp:Label ID="lblGIN" runat="server" style="font-weight: 700" ></asp:Label></td></tr></table>
                 <asp:CheckBoxList ID="chkFields" runat="server" DataTextField="Column_name" 
                             DataValueField="Column_name" RepeatColumns="10" RepeatDirection="Horizontal" 
                             RepeatLayout="Table" />
                 </asp:Panel>    
                
              
              </td>
             
             
             
         </tr>
     </table>
        
     <asp:Button ID="btnSub" CssClass="redbox" runat="server" Text="Show" OnClick="ShowGrid" />  
     &nbsp;<asp:Button ID="btnExport" runat="server" CssClass="redbox" 
         onclick="btnExport_Click" Text="Export To Excel" />
&nbsp;<asp:Button ID="btnCancel" runat="server" CssClass="redbox" Text="Cancel" onclick="btnCancel_Click" />
<br />
 </div> 
 <asp:Panel ID="Panel1" ScrollBars="Auto" Height="340px"   runat="server">   
      <asp:GridView ID="GridView1" runat="server"   EnableViewState="false" AutoGenerateColumns="false" />   
 </asp:Panel>
</div>
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

