<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Module_Accounts_Masters_TDS_Code, newerp_deploy" title="ERP" theme="Default" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<link type="text/css" href="../../../Css/yui-datatable.css" rel="stylesheet" />

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
    <p><br /></p><p></p>
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">

   
   
    <table align="center" style="width: 100%">
    
        <tr align="center">
            <td align="left" valign="middle" style="background:url(../../../images/hdbg.JPG)" height="21" class="fontcsswhite"><b>
                &nbsp; TDS Code </b></td>
        </tr>
        <tr align="center">
            <td align="center" valign="top">
               <asp:GridView ID="GridView1"  Width="80%"
                runat="server" 
                AllowPaging="True"
                ShowFooter="True"
                AutoGenerateColumns="False" 
                DataKeyNames="Id" 
                FooterStyle-Wrap="True"
                OnRowDeleted="GridView1_RowDeleted" 
               
              OnRowUpdated="GridView1_RowUpdated" 
              OnRowCommand="GridView1_RowCommand"
              CssClass="yui-datatable-theme" onrowdatabound="GridView1_RowDataBound" 
                    onrowupdating="GridView1_RowUpdating" 
                    onrowdeleting="GridView1_RowDeleting" onrowediting="GridView1_RowEditing" 
                    onrowcancelingedit="GridView1_RowCancelingEdit" PageSize="19" 
                    onpageindexchanged="GridView1_PageIndexChanged" 
                    onpageindexchanging="GridView1_PageIndexChanging">
                    
<FooterStyle Wrap="True"></FooterStyle>
                    <Columns>
                        <asp:CommandField ButtonType="Link"  ShowEditButton="True" ValidationGroup="C"/>
                        <asp:CommandField   ButtonType="Link" ShowDeleteButton="True"  />
                        
                        <asp:TemplateField HeaderText="SN" SortExpression="Id" >
                        <ItemTemplate>
                       <%# Container.DataItemIndex+1 %>
                        </ItemTemplate>
                        <FooterTemplate>
                        <asp:Button ID="btnInsert" runat="server" Text="Insert"  ValidationGroup="A"
                         OnClientClick="return confirmationAdd()" CommandName="Add" CssClass="redbox" />
                        </FooterTemplate>
                            <ItemStyle HorizontalAlign="Right" />
                        </asp:TemplateField>
                        
                     
                        
                        <asp:TemplateField HeaderText="Section No" >
                        <ItemTemplate>
                        <asp:Label ID="lblSectionNo" runat="server" Text='<%#Eval("SectionNo") %>'></asp:Label>
                        </ItemTemplate>
                        
                        <EditItemTemplate>
                            <asp:TextBox ID="TextSectionNo" Width="50px" runat="server" Text='<%#Eval("SectionNo") %>'>  </asp:TextBox>
                              <asp:RequiredFieldValidator ID="ReqSectionNo" ValidationGroup="C" ControlToValidate="TextSectionNo"
                          runat="server" ErrorMessage="*">
                          </asp:RequiredFieldValidator>  
                              
                        </EditItemTemplate>
                        
                        <FooterTemplate>
                      <asp:TextBox ID="TextFSectionNo" runat="server" Width="50px" Text='<%#Eval("SectionNo") %>'>  </asp:TextBox>  
                        <asp:RequiredFieldValidator ID="ReqFSectionNo" ValidationGroup="A" ControlToValidate="TextFSectionNo"
                          runat="server" ErrorMessage="*">
                          </asp:RequiredFieldValidator>  
                        </FooterTemplate>
                            <FooterStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" Width="10%" />
                        </asp:TemplateField>
                        
                      
                        
                        <asp:TemplateField HeaderText="Nature Of Payment">
                        <ItemTemplate>
                        <asp:Label ID="lblNatureOfPayment" runat="server" Text='<%#Eval("NatureOfPayment") %>'>    </asp:Label>
                        </ItemTemplate>
                        
                        <EditItemTemplate>
                        <asp:TextBox ID="txtNatureOfPayment" Width="85%" runat="server" Text='<%#Bind("NatureOfPayment") %>'>
                        </asp:TextBox>
                        
                         <asp:RequiredFieldValidator ID="ReqNatureOfPayment" ValidationGroup="C" ControlToValidate="txtNatureOfPayment"
                          runat="server" ErrorMessage="*">
                          </asp:RequiredFieldValidator>                         

                        </EditItemTemplate>
                        
                        <FooterTemplate>
                        <asp:TextBox ID="txtFNatureOfPayment" runat="server" Width="85%">
                        </asp:TextBox>
                       
                         <asp:RequiredFieldValidator ID="ReqFNatureOfPayment" ValidationGroup="A" ControlToValidate="txtFNatureOfPayment"
                          runat="server" ErrorMessage="*">
                          </asp:RequiredFieldValidator>
            				
                        </FooterTemplate>
                           
                            <ItemStyle Width="50%"  />
                           
                        </asp:TemplateField>
                        
                       
                        
                              <asp:TemplateField HeaderText="Payment Range">
                        <ItemTemplate>
                        <asp:Label ID="lblPaymentRange" runat="server" Text='<%#Eval("PaymentRange") %>'>    </asp:Label>
                        </ItemTemplate>
                        
                        <EditItemTemplate>
                        <asp:TextBox ID="txtPaymentRange" Width="50px" runat="server" Text='<%#Bind("PaymentRange") %>'>
                        </asp:TextBox>
                        
                         <asp:RequiredFieldValidator ID="ReqPaymentRange" ValidationGroup="C" ControlToValidate="txtPaymentRange"
                          runat="server" ErrorMessage="*">
                          </asp:RequiredFieldValidator>  
                          
                        </EditItemTemplate>
                        
                        <FooterTemplate>
                        <asp:TextBox ID="txtFPaymentRange" runat="server" Text="0"  Width="50px">
                        </asp:TextBox>
                       
                         <asp:RequiredFieldValidator ID="ReqFPaymentRange" ValidationGroup="A" ControlToValidate="txtFPaymentRange"
                          runat="server" ErrorMessage="*">
                          </asp:RequiredFieldValidator>
            				
                        </FooterTemplate>
                           
                            <ItemStyle Width="10%" HorizontalAlign="Right" />
                           
                        </asp:TemplateField>
                        
                              <asp:TemplateField HeaderText="Individual/HUF">
                        <ItemTemplate>
                        <asp:Label ID="lblPayToIndividual" runat="server" Text='<%#Eval("PayToIndividual") %>'></asp:Label>
                        </ItemTemplate>
                        
                        <EditItemTemplate>
                        <asp:TextBox ID="txtPayToIndividual" Width="50px" runat="server" Text='<%#Bind("PayToIndividual") %>'>
                        </asp:TextBox>
                        
                         <asp:RequiredFieldValidator ID="ReqPayToIndividual" ValidationGroup="C" ControlToValidate="txtPayToIndividual"
                          runat="server" ErrorMessage="*">
                          </asp:RequiredFieldValidator>   
                          
                        </EditItemTemplate>
                        
                        <FooterTemplate>
                        <asp:TextBox ID="txtFPayToIndividual" runat="server" Text="0" Width="50px">
                        </asp:TextBox>
                       
                         <asp:RequiredFieldValidator ID="ReqFPayToIndividual" ValidationGroup="A" ControlToValidate="txtFPayToIndividual"
                          runat="server" ErrorMessage="*">
                          </asp:RequiredFieldValidator>
                              
                        </FooterTemplate>
                           
                            <ItemStyle Width="10%" HorizontalAlign="Center" />
                           
                        </asp:TemplateField>   
                        
                        <asp:TemplateField HeaderText="Others">
                        <ItemTemplate>
                        <asp:Label ID="lblOthers" runat="server" Text='<%#Eval("Others") %>'>    </asp:Label>
                        </ItemTemplate>
                        
                        <EditItemTemplate>
                        <asp:TextBox ID="txtOthers" Width="50px" runat="server" Text='<%#Bind("Others") %>'>
                        </asp:TextBox>
                        
                         <asp:RequiredFieldValidator ID="ReqOthers" ValidationGroup="C" ControlToValidate="txtOthers"
                          runat="server" ErrorMessage="*">
                          </asp:RequiredFieldValidator> 
                          
                        </EditItemTemplate>
                        
                        <FooterTemplate>
                        <asp:TextBox ID="txtFOthers" runat="server" Text="0" Width="50px">
                        </asp:TextBox>
                       
                         <asp:RequiredFieldValidator ID="ReqFOthers" ValidationGroup="A" ControlToValidate="txtFOthers"
                          runat="server" ErrorMessage="*">
                          </asp:RequiredFieldValidator>
                          
                        </FooterTemplate>
                           
                            <ItemStyle Width="10%" HorizontalAlign="Center" />
                           
                        </asp:TemplateField>   
                        
                     
                        
                        <asp:TemplateField HeaderText="WithOut PAN">
                        <ItemTemplate>
                        <asp:Label ID="lblWithOutPAN" runat="server" Text='<%#Eval("WithOutPAN") %>'></asp:Label>
                        </ItemTemplate>
                        
                        <EditItemTemplate>
                        <asp:TextBox ID="txtWithOutPAN" Width="50px" runat="server" Text='<%#Bind("WithOutPAN") %>'>
                        </asp:TextBox>
                        
                         <asp:RequiredFieldValidator ID="ReqWithOutPAN" ValidationGroup="C" ControlToValidate="txtWithOutPAN"
                          runat="server" ErrorMessage="*">
                          </asp:RequiredFieldValidator>                         

                        </EditItemTemplate>
                        
                        <FooterTemplate>
                        <asp:TextBox ID="txtFWithOutPAN" runat="server" Text="20" Width="50px">
                        </asp:TextBox>
                       
                         <asp:RequiredFieldValidator ID="ReqFWithOutPAN" ValidationGroup="A" ControlToValidate="txtFWithOutPAN"
                          runat="server" ErrorMessage="*">
                          </asp:RequiredFieldValidator>
                          
                        </FooterTemplate>                           
                            <ItemStyle Width="7%" HorizontalAlign="Center" />
                        </asp:TemplateField>
                        
                        
                    </Columns>
                    <EmptyDataTemplate>
                    <table>
                    <tr>
                    <td></td>
                    <td align="center">
                        <asp:Label ID="Label1" Font-Bold="true" Font-Size="Medium" Font-Names="Times New Roman" runat="server" Text="Section No"></asp:Label></td>
                        
                        <td align="center">
                         <asp:Label ID="Label2" runat="server" Font-Size="Medium" Font-Names="Times New Roman"  Font-Bold="true" Text="Nature Of Payment"></asp:Label></td>
                 
                        <td align="center">
                         <asp:Label ID="Label3" runat="server" Font-Size="Medium" Font-Names="Times New Roman"  Font-Bold="true" Text="Payment Range"></asp:Label></td>
                 <td align="center">
                         <asp:Label ID="Label4" runat="server" Font-Size="Medium" Font-Names="Times New Roman"  Font-Bold="true" Text="Pay To Individual"></asp:Label></td>
                 
                 
                 <td align="center">
                         <asp:Label ID="Label5" runat="server" Font-Size="Medium" Font-Names="Times New Roman"  Font-Bold="true" Text="Others"></asp:Label></td>
                 
               </tr>
               <tr>
                    <td>
                   <asp:Button ID="btnInsert" runat="server" Text="Insert" ValidationGroup="B" OnClientClick="return confirmationAdd()" CommandName="Add1" CssClass="redbox" /></td>
                <td>
                   
                      <asp:TextBox ID="TxtESectionNo" runat="server" Width="80%" />
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="B" ControlToValidate="TxtESectionNo" 
                     runat="server" ErrorMessage="*">
                     </asp:RequiredFieldValidator>    
                   
                 </td>
                   <td>
                   <asp:TextBox ID="TxtENatureOfPayment" runat="server" Width="80%" />
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="B" ControlToValidate="TxtENatureOfPayment" 
                     runat="server" ErrorMessage="*">
                     </asp:RequiredFieldValidator>                    
                     </td>
                     
                      <td>
                   <asp:TextBox ID="TxtEPaymentRange" runat="server" Width="80%" />
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ValidationGroup="B" ControlToValidate="TxtEPaymentRange" 
                     runat="server" ErrorMessage="*">
                     </asp:RequiredFieldValidator>
                               	         
                        
                          
                            <asp:CompareValidator ID="CompareValidator3" runat="server" ErrorMessage="*" ControlToValidate="TxtEPaymentRange" Type="Double" ValidationGroup="B" ></asp:CompareValidator>                        
				            
                     </td>
                     
                     
                       </td>
                            <td>
                   <asp:TextBox ID="TxtEPayToIndividual" runat="server" Width="80%" />
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ValidationGroup="B" ControlToValidate="TxtEPayToIndividual" 
                     runat="server" ErrorMessage="*">
                     </asp:RequiredFieldValidator>                               	         
                    
                     </td>
                            <td>
                   <asp:TextBox ID="TxtEOthers" runat="server" Width="80%" />
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ValidationGroup="B" ControlToValidate="TxtEOthers" 
                     runat="server" ErrorMessage="*">
                     </asp:RequiredFieldValidator>
                     
                     </td>
                     <td>
                   <asp:TextBox ID="txtWithOutPAN0" runat="server" Width="80%" />
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ValidationGroup="B" ControlToValidate="txtWithOutPAN0" 
                     runat="server" ErrorMessage="*">
                     </asp:RequiredFieldValidator>
                     
                     </td>
                     </tr>
                     </table>
                   </EmptyDataTemplate>
              </asp:GridView>
                            
             
                </td>
        </tr>
   <tr>
            <td align="center">
                
    <asp:Label ID="lblMessage" runat="server"></asp:Label>
    
            </td>
            </td>
        </tr>
    </table>
<br />    
            
              

</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

