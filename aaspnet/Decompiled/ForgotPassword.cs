using System;
using System.Data;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;

public class ForgotPassword : Page, IRequiresSessionState
{
	protected PasswordRecovery PasswordRecovery1;

	private clsFunctions fun = new clsFunctions();

	private int CompId;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			CompId = Convert.ToInt32(Session["compid"]);
			string connectionString = fun.Connection();
			SqlConnection connection = new SqlConnection(connectionString);
			string cmdText = fun.select("ErpSysmail", "tblCompany_master", "CompId='" + CompId + "'");
			SqlCommand selectCommand = new SqlCommand(cmdText, connection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			string text = dataSet.Tables[0].Rows[0]["ErpSysmail"].ToString();
			PasswordRecovery1.MailDefinition.From = text;
			PasswordRecovery1.MailDefinition.IsBodyHtml = true;
			PasswordRecovery1.MailDefinition.Priority = MailPriority.High;
			PasswordRecovery1.MailDefinition.Subject = "Your New,Temporary password.";
		}
		catch (Exception)
		{
		}
	}

	protected void SubmitButton_Click(object sender, EventArgs e)
	{
	}

	protected void PasswordRecovery1_SendingMail(object sender, MailMessageEventArgs e)
	{
	}
}
