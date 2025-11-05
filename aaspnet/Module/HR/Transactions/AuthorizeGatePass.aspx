<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Module_HR_Transactions_AuthorizeGatePass, newerp_deploy" title="ERP" theme="Default" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../../../Css/yui-datatable.css" rel="stylesheet" type="text/css" />
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
 
   
   
   
   <table align="left" cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td height="20" align="left" valign="middle"  scope="col" class="fontcsswhite" 
                style="background:url(../../../images/hdbg.JPG)">
        &nbsp;<b>GatePass - Authorize</b></td>
        </tr>
        <tr ><td align="left" valign="middle" height="25">
                From Date: <asp:TextBox ID="txtFromDate" CssClass="box3" runat="server" 
                    Width="80px"></asp:TextBox>
                <cc1:CalendarExtender ID="txtFromDate_CalendarExtender" runat="server" CssClass="cal_Theme2" PopupPosition="BottomLeft"
                            Enabled="True" Format="dd-MM-yyyy" TargetControlID="txtFromDate">
                        </cc1:CalendarExtender>
                To Date: <asp:TextBox ID="txtToDate" CssClass="box3" runat="server" Width="80px"></asp:TextBox>
                <cc1:CalendarExtender ID="txtToDate_CalendarExtender" runat="server"  CssClass="cal_Theme2" PopupPosition="BottomLeft"
                            Enabled="True" Format="dd-MM-yyyy" TargetControlID="txtToDate">
                </cc1:CalendarExtender>
        
           
                       
                       
                           
                            Employee Name&nbsp; &nbsp;<asp:TextBox ID="txtEmpName" runat="server" 
                                CssClass="box3"  Width="150px"></asp:TextBox>
                            <cc1:AutoCompleteExtender ID="txtEmpName_AutoCompleteExtender" runat="server" 
                                DelimiterCharacters="" Enabled="True" ServiceMethod="GetCompletionList" 
                                ServicePath="" TargetControlID="txtEmpName" UseContextKey="True"
                                 CompletionInterval="100" CompletionSetCount="2" FirstRowSelected="True" MinimumPrefixLength="1" ShowOnlyCurrentWordInCompletionListItem="True" CompletionListItemCssClass="bg" CompletionListHighlightedItemCssClass="bgtext" CompletionListCssClass="almt">
                            </cc1:AutoCompleteExtender>
                            &nbsp;&nbsp;<asp:Button ID="Button1" runat="server" CssClass="redbox" onclick="Button1_Click" Text="Search" />
                        &nbsp;<asp:Button ID="Check" runat="server" CommandName="check" CssClass="redbox" 
                                onclick="Check_Click" OnClientClick=" return confirmation()" Text="Authorize" />
                        &nbsp;</td>
                       
                    </tr>
        
        <tr>
        <td valign="top">
<table align="left" cellpadding="0" 
            cellspacing="0" width="100%" style="height: 162px">
                            
                <tr>
        <td width="35%" valign="top">
         <asp:Panel ID="Panel1" runat="server"  ScrollBars="Auto"  Height="430px"  >
         
          <asp:GridView ID="GridView2" CssClass="yui-datatable-theme" runat="server" 
                    Width="98%" PageSize="20"
                    onpageindexchanging="GridView2_PageIndexChanging"  onrowcommand="GridView2_RowCommand" 
                   AutoGenerateColumns="False" DataKeyNames="Id"  >
                   
                    <PagerSettings PageButtonCount="40" />
                   
                    <Columns>
                        <asp:TemplateField HeaderText="SN" ItemStyle-HorizontalAlign="Right">
                <ItemTemplate><%#Container.DataItemIndex+1%></ItemTemplate>             
                <HeaderStyle Font-Size="10pt" />
                <ItemStyle HorizontalAlign="Right" VerticalAlign="Top" Width="4%"/>
                </asp:TemplateField>                       
                        
                      <asp:TemplateField  HeaderText="Id" Visible="false">
                        <ItemTemplate>
                      <asp:Label ID="lblId" runat="server" Text='<%#Eval("Id") %>'></asp:Label>                        
                        </ItemTemplate>
                        </asp:TemplateField>
                     
                         <asp:TemplateField HeaderText="Fin Year">
                         <ItemTemplate>
                        <asp:Label ID="lblFinYear" runat="server" Text='<%#Eval("FinYear") %>'></asp:Label>
                        </ItemTemplate>
                             <ItemStyle HorizontalAlign="Center" Width="15%" />
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="Date">
                         <ItemTemplate>
                        <asp:Label ID="lblDate" runat="server" Text='<%#Eval("SysDate") %>'></asp:Label>
                        </ItemTemplate>
                             <ItemStyle HorizontalAlign="Center" Width="15%" />
                        </asp:TemplateField>
                          
                        <asp:TemplateField HeaderText="GP No">
                         <ItemTemplate>
                          <asp:LinkButton ID="BtnGPNo" ValidationGroup="A" CommandName="Sel" Text='<%# Bind("GPNo") %>' runat="server"></asp:LinkButton>
                         
                       <asp:Label ID="lblGPNo" runat="server"  Visible="false" Text='<%#Eval("GPNo") %>'></asp:Label>
                        </ItemTemplate>
                             <ItemStyle HorizontalAlign="Center" Width="15%" />
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="Employee Name">
                         <ItemTemplate>
                        <asp:Label ID="lblEmpName" runat="server" Text='<%#Eval("EmpName") %>'></asp:Label>
                        </ItemTemplate>
                            <ItemStyle HorizontalAlign="Left" Width="40%" />
                        </asp:TemplateField>
                        
                         <asp:TemplateField HeaderText="Authorize" ItemStyle-HorizontalAlign="center">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="CK" runat="server"/>
                                               <asp:Label ID="lblcheck" runat="server" Text='<%# Bind("AuthorizeDate") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                           
                                        </asp:TemplateField>
                    </Columns>
                    
                     <EmptyDataTemplate>
                    <table width="100%" class="fontcss">
                    <tr>
                    <td align="center">
                    <asp:Label ID="Label1" runat="server"  Text="No data to display !" Font-Size="Larger" ForeColor="maroon">
                    </asp:Label>
                    </td>
                    </tr>
                    </table>
                    </EmptyDataTemplate>
                </asp:GridView>           
             </asp:Panel>
             
             
                    </td>
                    <td valign="top" width="70%">

         <div id="Up" runat="server" >
        
        
          <asp:Panel ID="Panel2" runat="server"  ScrollBars="Auto" Height="430px"  >          
            <asp:GridView ID="GridView3" runat="server"   DataKeyNames="Id"
                                AutoGenerateColumns="False" CssClass="yui-datatable-theme"                                
                                Width="100%" 
                 onpageindexchanging="GridView3_PageIndexChanging" PageSize="20" 
                  onrowcommand="GridView3_RowCommand1">
                                <PagerSettings PageButtonCount="40" />
                                <Columns>
                                    <asp:TemplateField HeaderText="SN">
                                        <ItemTemplate>
                                            <%#Container.DataItemIndex+1 %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    
                                      <asp:TemplateField >
                                        <ItemTemplate>
                             <asp:LinkButton ID="LinkButton1" CommandName="Del" runat="server">Delete</asp:LinkButton>  
                                        </ItemTemplate>
                                        
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Id" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblId" runat="server" Text='<%#Eval("Id") %>'></asp:Label>
                                        </ItemTemplate>
                                        
                                    </asp:TemplateField>
                                    
                                    <asp:TemplateField HeaderText="Date">
                                        <ItemTemplate>
                                            <asp:Label ID="lblDate" runat="server" Text='<%#Eval("FromDate") %>'></asp:Label>
                                        </ItemTemplate>
                                        
                                    </asp:TemplateField>
                                    
                                                             <asp:TemplateField HeaderText="Employee Name">
                         <ItemTemplate>
                        <asp:Label ID="lblEmpName" runat="server" Text='<%#Eval("EmpName") %>'></asp:Label>
                        </ItemTemplate>
                            <ItemStyle HorizontalAlign="Left" Width="22%" />
                        </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Type">
                                        <ItemTemplate>
                                            <asp:Label ID="lblType" runat="server" Text='<%#Eval("Type") %>' ></asp:Label>
                                        </ItemTemplate>
                                        
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Type Of">
                                        <ItemTemplate>
                                            <asp:Label ID="lblTypeOf" runat="server" Text='<%#Eval("TypeOf") %>'></asp:Label>
                                        </ItemTemplate>
                                        
                                    </asp:TemplateField>
                                    <asp:TemplateField  HeaderText="Type For" >
                                        <ItemTemplate>
                                            <asp:Label ID="lblTypeFor" runat="server" Text='<%#Eval("TypeFor") %>'></asp:Label>
                                        </ItemTemplate>
                                        
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="F Time">
                                        <ItemTemplate>
                                            <asp:Label ID="lblFTime" runat="server"  Text='<%#Eval("FromTime") %>' ></asp:Label>
                                        </ItemTemplate>
                                        
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="T Time">
                                        <ItemTemplate>
                                            <asp:Label ID="lblTTime" runat="server"  Text='<%#Eval("ToTime") %>'></asp:Label>
                                        </ItemTemplate>
                                        
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Visit Place">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPlace" runat="server" Text='<%#Eval("Place") %>'></asp:Label>
                                        </ItemTemplate>
                                        
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Contact Person">
                                        <ItemTemplate>
                                            <asp:Label ID="lblContPerson" runat="server" Text='<%#Eval("ContactPerson") %>'></asp:Label>
                                        </ItemTemplate>
                                        
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Contact No">
                                        <ItemTemplate>
                                            <asp:Label ID="lblContNo" runat="server" Text='<%#Eval("ContactNo") %>'></asp:Label>
                                        </ItemTemplate>
                                        
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Reason">
                                        <ItemTemplate>
                                            <asp:Label ID="lblReason" runat="server" Text='<%#Eval("Reason") %>'></asp:Label>
                                        </ItemTemplate>
                                        </asp:TemplateField>
                                  
                                </Columns>
                                <EmptyDataTemplate>
                                  <table width="100%" class="fontcss">
                                            <tr>
                                                <td align="center">
                                                    <asp:Label ID="Label1" runat="server"  Text="No data to display !" 
                            Font-Size="Larger" ForeColor="maroon"> </asp:Label>
                                                </td>
                                            </tr>
                                        </table>  
                                </EmptyDataTemplate>
                            </asp:GridView>       
       </asp:Panel>
             </div>

    </td>
    </tr>                    
    </table>
    </td> 


    </tr> 
    
    
    </table>
    
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

