<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Module_Machinery_Transactions_Schedule_Dashboard, newerp_deploy" title="ERP" theme="Default" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<%@ Register assembly="TimePicker" namespace="MKB.TimePicker" tagprefix="MKB" %>


<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../../../Css/yui-datatable.css" rel="stylesheet" type="text/css" />
    <link href="../../../Css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <link href="../../../Css/Calendar.MyCustomSkin.css" rel="stylesheet" type="text/css" />
    
    <script src="../../../Javascript/loadingNotifier.js" type="text/javascript"></script>
    <style type="text/css">
        .style2
        {
            width: 100%;
        }
        .style3
        {
            color: red;
        }
        .style4
        {
            color: #FF9900;
        }
        .style5
        {
            color: #00CC66;
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
    
    <script type="text/javascript">
        function OnChanged(sender, args)
        {
            ServerUtilities.SetTabIndex(sender.get_activeTabIndex());
        }
    </script>
    <table align="left" cellpadding="0" cellspacing="0" class="style2">
        <tr>
            <td align="left" class="fontcsswhite" height="20" scope="col" style="background: url(../../../images/hdbg.JPG)" valign="middle">&nbsp;<b>Machine Schedule Details</b></td>
        </tr>
        <tr>
            <td align="left">
                <cc1:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" 
                    Width="100%" AutoPostBack="True">
                    <cc1:TabPanel runat="server" HeaderText="Machine Details" ID="PR">                       
                        
                        
                        

                    
<HeaderTemplate>Machine Details</HeaderTemplate><ContentTemplate><table align="center" cellpadding="0" cellspacing="0" 
                                style="width: 100%"><tr><td height="25" valign="middle">&#160;<b>Schedule for :</b>&#160;<asp:Label ID="lblMachineName" runat="server" 
                                        style="font-weight: 700"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <span class="style3">* Days shown in</span> <span 
                                    class="style3"><asp:TextBox ID="TextBox4" runat="server" BackColor="Red" BorderColor="Red" 
                                    Enabled="False" ForeColor="Red" Height="10px" ReadOnly="True" Width="15px"></asp:TextBox>&#160;weekends.&#160;&#160; <asp:TextBox ID="TextBox2" runat="server" BackColor="Orange" 
                                    BorderColor="Orange" Enabled="False" ForeColor="Red" Height="10px" 
                                    ReadOnly="True" Width="15px"></asp:TextBox>&#160;&nbsp;</span><span class="style4">Machine&nbsp; Busy .</span><span class="style3">&nbsp; <asp:TextBox ID="TextBox3" runat="server" BackColor="#33CC33" 
                                    BorderColor="#33CC33" Enabled="False" ForeColor="Red" Height="10px" 
                                    ReadOnly="True" Width="15px"></asp:TextBox>&#160;</span><span class="style5">Machine&nbsp; Available.</span></td></tr><tr><td>
                            <telerik:RadCalendar 
        ID="RadCalendar1" runat="server" AutoPostBack="True"  SelectedDate=""
        SingleViewColumns="42" SingleViewRows="1" Skin="Vista" ViewSelectorText="x"  
        Width="100%" DayNameFormat="Short" EnableMultiSelect="False"  RangeMinDate=""
            EnableNavigationAnimation="True" ShowRowHeaders="False" ondayrender="RadCalendar1_DayRender" 
            
            DateRangeSeparator=" -" 
            EnableKeyboardNavigation="True" ><WeekendDayStyle   
        CssClass="rcWeekend"   Wrap="True" BorderStyle="Solid"></WeekendDayStyle><calendartablestyle cssclass="rcMainTable"></calendartablestyle><OtherMonthDayStyle CssClass="rcOtherMonth"></OtherMonthDayStyle><outofrangedaystyle cssclass="rcOutOfRange"></outofrangedaystyle><disableddaystyle cssclass="rcDisabled"></disableddaystyle><SelectedDayStyle CssClass="rcSelected"></SelectedDayStyle><dayoverstyle cssclass="rcHover"></dayoverstyle><fastnavigationstyle cssclass="RadCalendarMonthView RadCalendarMonthView_Vista"></fastnavigationstyle><viewselectorstyle cssclass="rcViewSel"></viewselectorstyle></telerik:RadCalendar></td></tr><tr><td  style="height:10px;"></td></tr><tr><td><asp:GridView ID="GridView1" runat="server" 
            AllowPaging="True" AutoGenerateColumns="False" CssClass="yui-datatable-theme" 
            DataKeyNames="Id" OnPageIndexChanging="GridView1_PageIndexChanging" 
            OnRowCommand="GridView1_RowCommand" PageSize="15" Width="100%"><Columns><asp:TemplateField HeaderText="SN"><ItemTemplate>
            <%#Container.DataItemIndex+1 %></ItemTemplate><ItemStyle HorizontalAlign="Right" VerticalAlign="Top" Width="2%"></ItemStyle></asp:TemplateField><asp:TemplateField HeaderText="WO No"><ItemTemplate><asp:Label ID="lblWONo" 
                    runat="server" Text='<%#Eval("WONo")%>'></asp:Label></ItemTemplate><ItemStyle HorizontalAlign="Center" Width="3.5%"></ItemStyle></asp:TemplateField><asp:TemplateField HeaderText="Job No"><ItemTemplate><asp:Label ID="lblJobNo" 
                    runat="server" Text='<%#Eval("JobNo")%>'></asp:Label></ItemTemplate><ItemStyle HorizontalAlign="Center" Width="3.5%"></ItemStyle></asp:TemplateField><asp:TemplateField HeaderText="Item Code"><ItemTemplate><asp:Label ID="lblItemCode" 
                    runat="server" Text='<%#Eval("ItemCode")%>'></asp:Label></ItemTemplate><ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle></asp:TemplateField><asp:TemplateField HeaderText="Description"><ItemTemplate><asp:Label ID="lblDesc" 
                    runat="server" Text='<%#Eval("ManfDesc")%>'></asp:Label></ItemTemplate><ItemStyle HorizontalAlign="Left" Width="12%"></ItemStyle></asp:TemplateField><asp:TemplateField HeaderText=" Qty"><ItemTemplate><asp:Label ID="lblBomQty" 
                    runat="server" Text='<%#Eval("BomQty")%>'></asp:Label></ItemTemplate><ItemStyle HorizontalAlign="Right" Width="4%"></ItemStyle></asp:TemplateField>
                    <asp:TemplateField HeaderText="UOM"><ItemTemplate><asp:Label ID="lblUOM" 
                    runat="server" Text='<%#Eval("UOM")%>'></asp:Label></ItemTemplate><ItemStyle HorizontalAlign="Center" Width="3%"></ItemStyle></asp:TemplateField>
                    <asp:TemplateField HeaderText="Shift"><ItemTemplate><asp:Label ID="lblShift" 
                    runat="server" Text='<%#Eval("Shift")%>'></asp:Label></ItemTemplate><ItemStyle HorizontalAlign="Center" Width="3%"></ItemStyle></asp:TemplateField>
                    <asp:TemplateField HeaderText="I/p Qty"><ItemTemplate><asp:Label ID="lblInputQty" 
                    runat="server" Text='<%#Eval("InputQty")%>'></asp:Label></ItemTemplate><ItemStyle HorizontalAlign="Right" Width="4%"></ItemStyle></asp:TemplateField><asp:TemplateField HeaderText="O/p Qty"><ItemTemplate><asp:Label 
                    ID="lblOutputQty" runat="server" Text='<%#Eval("OutputQty")%>'></asp:Label></ItemTemplate><ItemStyle HorizontalAlign="Right" Width="4%"></ItemStyle></asp:TemplateField><asp:TemplateField HeaderText="From Date"><ItemTemplate><asp:Label ID="lblfromDate" 
                    runat="server" Text='<%#Eval("FromDate")%>'></asp:Label></ItemTemplate><ItemStyle HorizontalAlign="Center" Width="4%"></ItemStyle></asp:TemplateField><asp:TemplateField HeaderText="To Date"><ItemTemplate><asp:Label ID="lblToDate" 
                    runat="server" Text='<%#Eval("ToDate")%>'></asp:Label></ItemTemplate><ItemStyle HorizontalAlign="Center" Width="4%"></ItemStyle></asp:TemplateField><asp:TemplateField HeaderText=" From Time"><ItemTemplate><asp:Label 
                    ID="lblFromTime" runat="server" Text='<%#Eval("FromTime")%>'></asp:Label></ItemTemplate><ItemStyle HorizontalAlign="Center" Width="5.5%"></ItemStyle></asp:TemplateField><asp:TemplateField HeaderText=" To Time"><ItemTemplate><asp:Label ID="lblToTime" 
                    runat="server" Text='<%#Eval("ToTime")%>'></asp:Label></ItemTemplate><ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle></asp:TemplateField><asp:TemplateField HeaderText="Process" ><ItemTemplate><asp:Label 
                    ID="lblProcess" runat="server" Text='<%#Eval("Process")%>'></asp:Label></ItemTemplate><ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle></asp:TemplateField><asp:TemplateField HeaderText="Operator" ><ItemTemplate><asp:Label 
                    ID="lblOperator" runat="server" Text='<%#Eval("Operator")%>'></asp:Label></ItemTemplate><ItemStyle HorizontalAlign="Center" Width="6%"></ItemStyle></asp:TemplateField><asp:TemplateField HeaderText="Id" Visible="False"><ItemTemplate><asp:Label 
                    ID="lblId" runat="server" Text='<%#Eval("Id")%>'></asp:Label></ItemTemplate><ItemStyle HorizontalAlign="Center" Width="1%"></ItemStyle></asp:TemplateField></Columns><EmptyDataTemplate><table class="fontcss" width="100%"><tr><td align="center"><asp:Label ID="Label1" runat="server" Font-Size="Larger" ForeColor="maroon" 
                            Text="No data to display !"> </asp:Label></td></tr></table></EmptyDataTemplate><FooterStyle 
            Wrap="True"></FooterStyle></asp:GridView></td></tr><tr><td align="center" height="25" valign="middle"><asp:Button ID="BtnCancel" runat="server" CssClass="redbox" 
                                        onclick="BtnCancel_Click" Text="Cancel" /></td><td 
            align="center" height="15">&#160;</td></tr></table></ContentTemplate></cc1:TabPanel>
                  
                </cc1:TabContainer>
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>


