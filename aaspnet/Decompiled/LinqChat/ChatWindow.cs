using System;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ASP;

namespace LinqChat;

public class ChatWindow : Page, IRequiresSessionState, ICallbackEventHandler
{
	protected HtmlHead Head1;

	protected Label lblFromUserId;

	protected Label lblToUserId;

	protected Label lblFromUsername;

	protected Label lblMessageSent;

	protected ScriptManager ScriptManager1;

	protected Timer Timer1;

	protected Literal litMessages;

	protected TextBox txtMessage;

	protected Button btnSend;

	protected UpdatePanel UpdatePanel1;

	protected HtmlForm form1;

	private string _callBackStatus = "";

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			Page.Title = lblFromUsername.Text + " - Private Message ..................................................................";
			if (!base.IsPostBack)
			{
				lblFromUsername.Text = base.Request["Username"];
				Page.Title = lblFromUsername.Text + " - Private Message ..................................................................";
				lblFromUserId.Text = base.Request["FromUserId"];
				lblToUserId.Text = base.Request["ToUserId"];
				string text = base.Request["IsReply"];
				if (text == "yes")
				{
					lblMessageSent.Text = ConfigurationManager.AppSettings["ChatWindowMessageSent"];
				}
				string value = lblFromUserId.Text + "_" + lblToUserId.Text;
				Session["DefaultWindow"] = value;
				FocusThisWindow();
				string callbackEventReference = Page.ClientScript.GetCallbackEventReference(this, "arg", "FocusThisWindow", "");
				string script = "function FocusThisWindowCallBack(arg, context) { " + callbackEventReference + "; }";
				Page.ClientScript.RegisterClientScriptBlock(GetType(), "FocusThisWindowCallBack", script, addScriptTags: true);
			}
		}
		catch (Exception)
		{
		}
	}

	protected void BtnSend_Click(object sender, EventArgs e)
	{
		try
		{
			if (txtMessage.Text.Length > 0)
			{
				InsertPrivateMessage();
				InsertMessage();
				GetPrivateMessages();
				txtMessage.Text = string.Empty;
				FocusThisWindow();
				ScriptManager1.SetFocus(txtMessage.ClientID);
			}
		}
		catch (Exception)
		{
		}
	}

	private void InsertPrivateMessage()
	{
		try
		{
			if (string.IsNullOrEmpty(lblMessageSent.Text))
			{
				PrivateMessage privateMessage = new PrivateMessage();
				privateMessage.UserID = Convert.ToInt32(lblFromUserId.Text);
				privateMessage.ToUserID = Convert.ToInt32(lblToUserId.Text);
				LinqChatDataContext linqChatDataContext = new LinqChatDataContext();
				linqChatDataContext.PrivateMessages.InsertOnSubmit(privateMessage);
				linqChatDataContext.SubmitChanges();
				lblMessageSent.Text = ConfigurationManager.AppSettings["ChatWindowMessageSent"];
			}
		}
		catch (Exception)
		{
		}
	}

	private void InsertMessage()
	{
		try
		{
			Message message = new Message();
			message.UserID = Convert.ToInt32(lblFromUserId.Text);
			message.ToUserID = Convert.ToInt32(lblToUserId.Text);
			message.TimeStamp = DateTime.Now;
			message.Text = txtMessage.Text.Replace("<", "");
			LinqChatDataContext linqChatDataContext = new LinqChatDataContext();
			linqChatDataContext.Messages.InsertOnSubmit(message);
			linqChatDataContext.SubmitChanges();
		}
		catch (Exception)
		{
		}
	}

	private void GetPrivateMessages()
	{
		try
		{
			LinqChatDataContext linqChatDataContext = new LinqChatDataContext();
			IQueryable<Message> queryable = (from m in linqChatDataContext.Messages
				where (m.UserID == Convert.ToInt32(lblFromUserId.Text) && m.ToUserID == (int?)Convert.ToInt32(lblToUserId.Text)) || (m.UserID == Convert.ToInt32(lblToUserId.Text) && m.ToUserID == (int?)Convert.ToInt32(lblFromUserId.Text))
				orderby m.TimeStamp descending
				select m).Take(20);
			if (queryable == null)
			{
				return;
			}
			StringBuilder stringBuilder = new StringBuilder();
			int num = 0;
			foreach (Message item in queryable)
			{
				if (num == 0)
				{
					stringBuilder.Append("<div style='padding: 10px;'>");
					num = 1;
				}
				else
				{
					stringBuilder.Append("<div style='background-color: #EFEFEF; padding: 10px;'>");
					num = 0;
				}
				stringBuilder.Append("<span style='color: black; font-weight: bold;'>" + item.User.EmployeeName + ":</span>  " + item.Text + "</div>");
			}
			litMessages.Text = stringBuilder.ToString();
		}
		catch (Exception)
		{
		}
	}

	protected void Timer1_OnTick(object sender, EventArgs e)
	{
		try
		{
			GetPrivateMessages();
			if (Session["DefaultWindow"] != null)
			{
				FocusThisWindow();
			}
		}
		catch (Exception)
		{
		}
	}

	private void FocusThisWindow()
	{
		try
		{
			string text = lblFromUserId.Text + "_" + lblToUserId.Text;
			if (Session["DefaultWindow"].ToString() == text)
			{
				form1.DefaultButton = "btnSend";
				form1.DefaultFocus = "txtMessage";
			}
		}
		catch (Exception)
		{
		}
	}

	string ICallbackEventHandler.GetCallbackResult()
	{
		return _callBackStatus;
	}

	void ICallbackEventHandler.RaiseCallbackEvent(string eventArgument)
	{
		try
		{
			if (!string.IsNullOrEmpty(eventArgument) && eventArgument == "FocusThisWindow")
			{
				string value = lblFromUserId.Text + "_" + lblToUserId.Text;
				Session["DefaultWindow"] = value;
				FocusThisWindow();
			}
		}
		catch (Exception)
		{
		}
	}
}
