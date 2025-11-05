<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Module_Inventory_Masters_AutoWIS_Time_Set, newerp_deploy" title="ERP" theme="Default" %>
<%@ Register assembly="TimePicker" namespace="MKB.TimePicker" tagprefix="MKB" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link type="text/css" href="../../../Css/yui-datatable.css" rel="stylesheet" />
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
    <p><br /></p><p></p>
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">

    <table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td>
    <table cellpadding="0" cellspacing="0" width="40%" align="center">
        <tr>
            <td align="left" valign="middle">
                &nbsp;</td>
        </tr>
        <tr>
            <td align="left" valign="middle" style="background:url(../../../images/hdbg.JPG)" height="21" class="fontcsswhite"><b>&nbsp;Auto WIS Timer</b></td>
        </tr>
        <tr>
            <td align="center" valign="top">
                <asp:GridView ID="GridView1" 
                runat="server" 
                AllowPaging="True"
                ShowFooter="True" 
                AutoGenerateColumns="False" 
                DataKeyNames="Id" 
                FooterStyle-Wrap="True"
                OnRowDeleted="GridView1_RowDeleted"                 
                OnRowUpdated="GridView1_RowUpdated"                
                OnRowCommand="GridView1_RowCommand" 
                CssClass="yui-datatable-theme" 
                Width="100%" onrowdatabound="GridView1_RowDataBound" 
                onrowcancelingedit="GridView1_RowCancelingEdit" 
                onrowupdating="GridView1_RowUpdating" onrowediting="GridView1_RowEditing" 
                    PageSize="20" onrowdeleting="GridView1_RowDeleting" 
                    >                  
                    
<FooterStyle Wrap="True">
</FooterStyle>
                    <PagerSettings PageButtonCount="40" />
                    <Columns>
                        <asp:CommandField ButtonType="Link"  ShowEditButton="True" 
                            ValidationGroup="Shree">
                            <ItemStyle HorizontalAlign="Center" Width="5%" />
                        </asp:CommandField>
                        <asp:CommandField  ButtonType="Link" ShowDeleteButton="True"  >
                        
                            <ItemStyle HorizontalAlign="Center" Width="5%" />
                        </asp:CommandField>
                        
                        <asp:TemplateField HeaderText="SN" SortExpression="Id">
                        <ItemTemplate>
                        <%# Container.DataItemIndex+1 %>
                        </ItemTemplate>
                        <FooterTemplate>
                        <asp:Button ID="btnInsert" runat="server" Text="Insert" OnClientClick=" return confirmationAdd()" 
                        ValidationGroup="abc" CommandName="Add" CssClass="redbox" />
                        </FooterTemplate>
                        <ItemStyle HorizontalAlign="Right" Width="10%" />
                        </asp:TemplateField>
                           
                        <asp:TemplateField HeaderText="Time" SortExpression="TimeAuto">
                        <ItemTemplate>
                        <asp:Label ID="lblTimeAuto" runat="server" Text='<%#Eval("TimeAuto") %>'>
                        </asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>                                             
                        <MKB:TimeSelector ID="TimeSelEdit" runat="server" AmPm="AM" MinuteIncrement="1">
                            </MKB:TimeSelector> 
                            
                            <asp:Label ID="lblTimeAutoE" Visible="false" runat="server" Text='<%#Eval("TimeAuto") %>'>
                        </asp:Label> 
                        </EditItemTemplate>
                                            
                        <FooterTemplate> 
                           <MKB:TimeSelector ID="TimeSelFoot" runat="server" AmPm="AM" MinuteIncrement="1">
                            </MKB:TimeSelector>                     
                        </FooterTemplate>                                                
                        <ItemStyle Width="20%" />
                        </asp:TemplateField> 
                        <asp:TemplateField HeaderText="Id" Visible="false" SortExpression="Id">
                        <ItemTemplate>
                   <asp:Label ID="lblId" runat="server" Text='<%#Eval("Id") %>'>    </asp:Label>
                   </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    
                     <EmptyDataTemplate>
                     
                      <table  width="100%" border="1" style="border-color:Gray">
                    <tr>
                    <th></th>
                    <th align="center">
                    
                    
                        <asp:Label ID="Label1" Font-Bold="true" Font-Size="Medium" Font-Names="Times New Roman" runat="server" Text="Time"></asp:Label></th>                        
                        
                    <tr>
                        <td align="left">
            <asp:Button ID="btnInsert" runat="server" CommandName="Add1" OnClientClick=" return confirmationAdd()" 
            CssClass="redbox" ValidationGroup="pqr" Text="Insert" />
            </td>
            <td> 
            <MKB:TimeSelector ID="TimeSelEmpty" runat="server" AmPm="AM" MinuteIncrement="1">
                            </MKB:TimeSelector>
            </td>
                        
                        </tr>
                        </table>
        </EmptyDataTemplate>                    
                    
              </asp:GridView>
                
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:LocalSqlServer %>" 
                    DeleteCommand="DELETE FROM [tblinv_AutoWIS_TimeSchedule] WHERE [Id] = @Id "  
                    InsertCommand="INSERT INTO [tblinv_AutoWIS_TimeSchedule]([TimeAuto], [CompId], [FinYearId]) VALUES (@TimeAuto, @CompId, @FinYearId)" 
                    SelectCommand="SELECT Id,TimeAuto FROM tblinv_AutoWIS_TimeSchedule ORDER BY Id DESC"                 
                    UpdateCommand="UPDATE [tblinv_AutoWIS_TimeSchedule] SET  [TimeAuto] = @TimeAuto WHERE [Id] = @Id">
                    <DeleteParameters>
                        <asp:Parameter Name="Id" Type="Int32" />
                    </DeleteParameters>
                    <UpdateParameters>                        
                        <asp:Parameter Name="TimeAuto" Type="String" />
                        <asp:Parameter Name="Id" Type="Int32" />
                    </UpdateParameters>
                    <InsertParameters>
                        <asp:Parameter Name="TimeAuto" Type="String" />                        
                        <asp:SessionParameter Name="CompId" Type="Int32" />    
                        <asp:SessionParameter Name="FinYearId" Type="Int32" />                       
                    </InsertParameters>
                </asp:SqlDataSource>
                
               </td>
        </tr>
        <tr>
            <td align="center" valign="top" height="25">
                <asp:Label ID="lblMessage" runat="server" style="color: #FF0000"></asp:Label></td>
        </tr>
        </table>
            </td>
        </tr>
    </table>
    
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

