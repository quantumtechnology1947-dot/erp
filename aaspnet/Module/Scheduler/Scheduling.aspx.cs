using System;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;
using Telerik.Web.UI;

public class Module_Scheduler_Scheduling : Page, IRequiresSessionState
{
	protected RadAjaxManager RadAjaxManager1;

	protected RadAjaxLoadingPanel RadAjaxLoadingPanel1;

	protected CheckBox GroupByRoomCheckBox;

	protected CheckBox GroupByDateCheckBox;

	protected RadComboBox GroupingDirectionComboBox;

	protected RadScheduler RadScheduler1;

	protected RadAjaxPanel RadAjaxPanel1;

	protected SqlDataSource EventsDataSource;

	protected SqlDataSource RoomsDataSource;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	private string GroupByExpression
	{
		get
		{
			if (!GroupByRoomCheckBox.Checked)
			{
				return string.Empty;
			}
			if (!GroupByDateCheckBox.Checked)
			{
				return "Departments";
			}
			return "Date, Departments";
		}
	}

	private void Page_Load(object sender, EventArgs e)
	{
	}

	private void UpdateScheduler()
	{
		RadScheduler1.GroupBy = GroupByExpression;
		RadScheduler1.GroupingDirection = (GroupingDirection)Enum.Parse(typeof(GroupingDirection), GroupingDirectionComboBox.SelectedValue);
		RadScheduler1.Rebind();
	}

	protected void GroupingDirectionComboBox_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
	{
		UpdateScheduler();
	}

	protected void GroupByDateCheckBox_CheckedChanged(object sender, EventArgs e)
	{
		UpdateScheduler();
	}

	protected void GroupByRoomCheckBox_CheckedChanged(object sender, EventArgs e)
	{
		GroupByDateCheckBox.Enabled = GroupByRoomCheckBox.Checked;
		GroupingDirectionComboBox.Enabled = GroupByRoomCheckBox.Checked;
		UpdateScheduler();
	}
}
