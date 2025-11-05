<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Module_Scheduler_Scheduling, newerp_deploy" title="ERP" theme="Default" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../../Css/styles.css" rel="stylesheet" type="text/css" />
    <script src="../../Javascript/loadingNotifier.js" type="text/javascript"></script>
<style type="text/css">    
    #ConfiguratorPanel1 ul
    {
        list-style: none;
        padding: 7px 0;
        margin:0 auto;
        width: 600px;
        height: 24px;
    }

    #ConfiguratorPanel1 ul li
    {
        line-height: 24px;
        float:left;
        border-left: solid 1px #b1d8eb;
        padding-left: 11px;
        margin-left: 10px;
        height: 24px;
    }    

    #ConfiguratorPanel1 .RadComboBox
    {
        vertical-align: middle;
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
<table width="100%">
<tr>
<td>
<telerik:RadAjaxManager UpdatePanelsRenderMode="Block" runat="Server" ID="RadAjaxManager1">
            <AjaxSettings >                
                <telerik:AjaxSetting AjaxControlID="RadAjaxPanel1" >
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="RadAjaxPanel1" LoadingPanelID="RadAjaxLoadingPanel1" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
            </AjaxSettings>
        </telerik:RadAjaxManager>

<br />
<telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" 
        Skin="Windows7" InitialDelayTime="50"  />
        <telerik:RadAjaxPanel runat="server" ID="RadAjaxPanel1" Width="100%" LoadingPanelID="RadAjaxLoadingPanel1" CssClass="exampleContainer">

<table style="width: 100%">

    <tr>
        <td>
            <asp:CheckBox ID="GroupByRoomCheckBox" runat="server" AutoPostBack="true" 
                Enabled="true" OnCheckedChanged="GroupByRoomCheckBox_CheckedChanged" 
                Text="Group by Departments" Visible="false" />
        </td>
        <td>
            <asp:CheckBox ID="GroupByDateCheckBox" runat="server" AutoPostBack="true" 
                OnCheckedChanged="GroupByDateCheckBox_CheckedChanged" Text="Group by date" Visible="false" />
        </td>
        <td>
           
            <telerik:RadComboBox ID="GroupingDirectionComboBox" runat="Server" 
                AutoPostBack="True"  Visible ="false"
                OnSelectedIndexChanged="GroupingDirectionComboBox_SelectedIndexChanged" 
                Skin="Vista">
                <Items>
                    <telerik:RadComboBoxItem Text="Horizontal" Value="Horizontal" />
                    <telerik:RadComboBoxItem Text="Vertical" Value="Vertical" />
                </Items>
            </telerik:RadComboBox>
        </td>
    </tr>   

</table>
            <telerik:RadScheduler runat="server" ID="RadScheduler1" Skin="Windows7" GroupBy="Departments" 
                    GroupingDirection="Horizontal" DayStartTime="08:00:00" 
                    DayEndTime="19:00:00" TimeZoneOffset="03:00:00"
                DataSourceID="EventsDataSource" DataKeyField="ID" DataSubjectField="Subject"
                DataStartField="Start" DataEndField="End" DataRecurrenceField="RecurrenceRule"
                DataRecurrenceParentKeyField="RecurrenceParentID" SelectedView="WeekView" FirstDayOfWeek="Monday"
                LastDayOfWeek="Sunday" RowHeaderWidth="52px" 
                    Width="100%" EditFormDateFormat="dd/MM/yyyy" ShowFullTime="True" 
                    DataDescriptionField="Description" Height="492px" RowHeight="22px" 
                    DataReminderField="Reminder" Reminders-Enabled="true"  >
                <Reminders Enabled="True"  />
                <DayView HeaderDateFormat="dd/MM/yyyy" />
                <AdvancedForm Modal="true" DateFormat="dd/MM/yyyy" />
                <MonthView HeaderDateFormat="dd/MM/yyyy" ColumnHeaderDateFormat="dd/MM/yyyy" 
                    DayHeaderDateFormat="dd/MM/yyyy" FirstDayHeaderDateFormat="dd/MM/yyyy" />
                <ResourceTypes>
                    <telerik:ResourceType KeyField="ModuleId" Name="Departments" AllowMultipleValues="true" TextField="Name" ForeignKeyField="ModuleId"
                        DataSourceID="RoomsDataSource" />
                </ResourceTypes>                
                <TimelineView ColumnHeaderDateFormat="dd/MM/yyyy" 
                    HeaderDateFormat="dd/MM/yyyy" NumberOfSlots="7" />
                <WeekView ColumnHeaderDateFormat="dd/MM/yyyy" HeaderDateFormat="dd/MM/yyyy"  />
                <MultiDayView ColumnHeaderDateFormat="dd/MM/yyyy" 
                    HeaderDateFormat="dd/MM/yyyy" NumberOfDays="7" UserSelectable="True" /> 
                    <AppointmentTemplate>
                            <div class="rsAptSubject">
                                <%# Eval("Subject") %>
                            </div>
                            <%# Eval("Description") %>
                    </AppointmentTemplate>
         <TimeSlotContextMenuSettings EnableDefault="true" />
         <AppointmentContextMenuSettings EnableDefault="true" />
            </telerik:RadScheduler>
           
        </telerik:RadAjaxPanel>
        </td>
</tr>

</table>
    <asp:SqlDataSource ID="EventsDataSource" runat="server" ProviderName="System.Data.SqlClient" ConnectionString="<%$ ConnectionStrings:LocalSqlServer %>" SelectCommand="SELECT [ID],[Subject],[Description], [Start], [End], [ModuleId], [RecurrenceRule], [RecurrenceParentID],[Reminder] FROM [Grouping_Events] Where [CompId]=@CompId And [FinYearId]<=@FinYearId AND [SessionId]=@SessionId"
    
            InsertCommand="INSERT INTO [Grouping_Events] ([Description],[Subject] ,[Start], [End], [ModuleId], [RecurrenceRule], [RecurrenceParentID],[CompId],[FinYearId],[SessionId],[Reminder]) VALUES (@Description,@Subject, @Start, @End , @ModuleId, @RecurrenceRule, @RecurrenceParentID,@CompId,@FinYearId ,@SessionId,@Reminder)"
            UpdateCommand="UPDATE [Grouping_Events] SET [Description] = @Description,[Subject]=@Subject, [Start] = @Start, [End] = @End, [ModuleId] = @ModuleId, [RecurrenceRule] = @RecurrenceRule, [RecurrenceParentID] = @RecurrenceParentID,[Reminder]=@Reminder WHERE (ID = @ID)"
            DeleteCommand="DELETE FROM [Grouping_Events] WHERE [ID] = @ID">
            <DeleteParameters>
                <asp:Parameter Name="ID" Type="Int32" />
            </DeleteParameters>
            <UpdateParameters>
                <asp:Parameter Name="ID" Type="Int32" />
                <asp:Parameter Name="Subject" Type="String" />
                <asp:Parameter Name="Description" Type="String" />                
                <asp:Parameter Name="Start" Type="DateTime" />
                <asp:Parameter Name="End" Type="DateTime" />
                <asp:Parameter Name="ModuleId" Type="Int32" />
                <asp:Parameter Name="RecurrenceRule" Type="String" />
                <asp:Parameter Name="RecurrenceParentID" Type="Int32" />
                <asp:Parameter Name="Reminder" Type="String" />
            </UpdateParameters>
            <InsertParameters>
                <asp:Parameter Name="Subject" Type="String" />
                <asp:Parameter Name="Description" Type="String" />
                <asp:Parameter Name="Start" Type="DateTime" />
                <asp:Parameter Name="End" Type="DateTime" />
                <asp:Parameter Name="ModuleId" Type="Int32" />
                <asp:Parameter Name="RecurrenceRule" Type="String" />
                <asp:Parameter Name="RecurrenceParentID" Type="Int32" />
                <asp:SessionParameter Name="SessionId" SessionField="username" DbType="String" />
                <asp:SessionParameter Name="CompId" SessionField="compid" DbType="Int32" />
                <asp:SessionParameter Name="FinYearId" SessionField="finyear" DbType="Int32" />
                <asp:Parameter Name="Reminder" Type="String" />
            </InsertParameters>  
            <SelectParameters>
                <asp:SessionParameter Name="SessionId" SessionField="username" DbType="String" />
                <asp:SessionParameter Name="CompId" SessionField="compid" DbType="Int32" />
                <asp:SessionParameter Name="FinYearId" SessionField="finyear" DbType="Int32" /> 
            </SelectParameters>
               
    </asp:SqlDataSource>
        
    <asp:SqlDataSource ID="RoomsDataSource" runat="server" ProviderName="System.Data.SqlClient" ConnectionString="<%$ ConnectionStrings:LocalSqlServer %>"
            SelectCommand="SELECT [ModuleId], [Name] FROM [Grouping_Rooms]">
            
     </asp:SqlDataSource>
        

</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>



