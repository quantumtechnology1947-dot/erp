using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;

namespace LinqChat;

public class Chatroom : Page, IRequiresSessionState, ICallbackEventHandler
{
	protected Label lblRoomName;

	protected Label lblRoomId;

	protected Timer Timer1;

	protected Literal litMessages;

	protected Literal litUsers;

	protected Label lblChatNowUser;

	protected Button btnChatNow;

	protected Button btnCancel;

	protected Panel pnlChatNow;

	protected TextBox txtMessage;

	protected Button btnSend;

	protected UpdatePanel UpdatePanel1;

	private clsFunctions fun = new clsFunctions();

	private string _callBackStatus;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			if (!base.IsPostBack)
			{
				string text = base.Request["roomId"];
				lblRoomId.Text = text;
				clearmessage();
				GetRoomInformation();
				GetLoggedInUsers();
				InsertMessage(ConfigurationManager.AppSettings["ChatLoggedInText"] + " " + DateTime.Now.ToString());
				GetMessages();
				FocusThisWindow();
				string callbackEventReference = Page.ClientScript.GetCallbackEventReference(this, "arg", "LogOutUser", "");
				string script = "function LogOutUserCallBack(arg, context) { " + callbackEventReference + "; }";
				Page.ClientScript.RegisterClientScriptBlock(GetType(), "LogOutUserCallBack", script, addScriptTags: true);
				string callbackEventReference2 = Page.ClientScript.GetCallbackEventReference(this, "arg", "FocusThisWindow", "");
				string script2 = "function FocusThisWindowCallBack(arg, context) { " + callbackEventReference2 + "; }";
				Page.ClientScript.RegisterClientScriptBlock(GetType(), "FocusThisWindowCallBack", script2, addScriptTags: true);
			}
		}
		catch (Exception)
		{
		}
	}

	private void clearmessage()
	{
		string connectionString = fun.Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		sqlConnection.Open();
		SqlCommand sqlCommand = new SqlCommand("Delete Message Where DATEDIFF(day, TimeStamp, getdate()) > 0", sqlConnection);
		sqlCommand.ExecuteNonQuery();
		sqlConnection.Close();
	}

	private void GetRoomInformation()
	{
		try
		{
			LinqChatDataContext linqChatDataContext = new LinqChatDataContext();
			Room room = linqChatDataContext.Rooms.Where((Room r) => r.RoomID == Convert.ToInt32(lblRoomId.Text)).SingleOrDefault();
			lblRoomId.Text = room.RoomID.ToString();
			lblRoomName.Text = room.Name;
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
				InsertMessage(null);
				GetMessages();
				txtMessage.Text = string.Empty;
				GetPrivateMessages();
				FocusThisWindow();
			}
		}
		catch (Exception)
		{
		}
	}

	protected void Timer1_OnTick(object sender, EventArgs e)
	{
		try
		{
			GetLoggedInUsers();
			GetMessages();
			GetPrivateMessages();
			if (Session["DefaultWindow"] != null && Session["DefaultWindow"].ToString() == "MainWindow")
			{
				FocusThisWindow();
			}
		}
		catch (Exception)
		{
		}
	}

	private void InsertMessage(string text)
	{
		try
		{
			LinqChatDataContext linqChatDataContext = new LinqChatDataContext();
			Message message = new Message();
			message.RoomID = Convert.ToInt32(lblRoomId.Text);
			message.UserID = Convert.ToInt32(Session["ChatUserID"]);
			if (string.IsNullOrEmpty(text))
			{
				message.Text = txtMessage.Text.Replace("<", "");
			}
			else
			{
				message.Text = text;
			}
			message.ToUserID = null;
			message.TimeStamp = DateTime.Now;
			linqChatDataContext.Messages.InsertOnSubmit(message);
			linqChatDataContext.SubmitChanges();
		}
		catch (Exception)
		{
		}
	}

	private void GetLoggedInUsers()
	{
		try
		{
			LinqChatDataContext linqChatDataContext = new LinqChatDataContext();
			LoggedInUser loggedInUser = linqChatDataContext.LoggedInUsers.Where((LoggedInUser u) => u.UserID == Convert.ToInt32(Session["ChatUserID"]) && u.RoomID == Convert.ToInt32(lblRoomId.Text)).SingleOrDefault();
			if (loggedInUser == null)
			{
				LoggedInUser loggedInUser2 = new LoggedInUser();
				loggedInUser2.UserID = Convert.ToInt32(Session["ChatUserID"]);
				loggedInUser2.RoomID = Convert.ToInt32(lblRoomId.Text);
				linqChatDataContext.LoggedInUsers.InsertOnSubmit(loggedInUser2);
				linqChatDataContext.SubmitChanges();
			}
			StringBuilder stringBuilder = new StringBuilder();
			IQueryable<LoggedInUser> queryable = linqChatDataContext.LoggedInUsers.Where((LoggedInUser l) => l.RoomID == Convert.ToInt32(lblRoomId.Text));
			foreach (LoggedInUser item in queryable)
			{
				string text = ((!(item.User.Gender.ToString().ToLower() == "m")) ? "<img src='../../images/womanIcon.gif' style='vertical-align:middle' alt=''>  " : "<img src='../../images/manIcon.gif' style='vertical-align:middle' alt=''>  ");
				if (item.User.EmpId != (string)Session["ChatUsername"])
				{
					stringBuilder.Append(string.Concat(text, "<a href=# onclick=\"window.open('ChatWindow.aspx?FromUserId=", Session["ChatUserID"], "&ToUserId=", item.User.UserID, "&Username=", item.User.EmployeeName, "','','width=400,height=200,scrollbars=no,toolbars=no,titlebar=no,menubar=no'); isLostFocus = 'true';\">", item.User.EmployeeName, "</a><br>"));
				}
				else
				{
					stringBuilder.Append(text + "<b>" + item.User.EmployeeName + "</b><br>");
				}
			}
			litUsers.Text = stringBuilder.ToString();
		}
		catch (Exception)
		{
		}
	}

	private void GetMessages()
	{
		try
		{
			LinqChatDataContext linqChatDataContext = new LinqChatDataContext();
			IQueryable<Message> queryable = (from m in linqChatDataContext.Messages
				where m.RoomID == (int?)Convert.ToInt32(lblRoomId.Text)
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
				if (item.User.Gender.ToString().ToLower() == "m")
				{
					stringBuilder.Append("<img src='../../images/manIcon.gif' style='vertical-align:middle' alt=''> <span style='color: black; font-weight: bold;'>" + item.User.EmployeeName + ":</span>  " + item.Text + "</div>");
				}
				else
				{
					stringBuilder.Append("<img src='../../images/womanIcon.gif' style='vertical-align:middle' alt=''> <span style='color: black; font-weight: bold;'>" + item.User.EmployeeName + ":</span>  " + item.Text + "</div>");
				}
			}
			litMessages.Text = stringBuilder.ToString();
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
			PrivateMessage privateMessage = linqChatDataContext.PrivateMessages.Where((PrivateMessage pm) => pm.ToUserID == Convert.ToInt32(Session["ChatUserID"])).SingleOrDefault();
			if (privateMessage != null)
			{
				lblChatNowUser.Text = privateMessage.User.EmployeeName;
				btnChatNow.OnClientClick = string.Concat("window.open('ChatWindow.aspx?FromUserId=", Session["ChatUserID"], "&ToUserId=", privateMessage.UserID, "&Username=", privateMessage.User.EmployeeName, "&IsReply=yes','','width=400,height=200,scrollbars=no,toolbars=no,titlebar=no,menubar=no'); isLostFocus = 'true';");
				pnlChatNow.Visible = true;
				linqChatDataContext.PrivateMessages.DeleteOnSubmit(privateMessage);
				linqChatDataContext.SubmitChanges();
			}
		}
		catch (Exception)
		{
		}
	}

	protected void BtnChatNow_Click(object sender, EventArgs e)
	{
		pnlChatNow.Visible = false;
	}

	protected void BtnCancel_Click(object sender, EventArgs e)
	{
		pnlChatNow.Visible = false;
	}

	private void FocusThisWindow()
	{
		try
		{
			txtMessage.Focus();
			Session["DefaultWindow"] = "MainWindow";
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
			_callBackStatus = "failed";
			if (!string.IsNullOrEmpty(eventArgument) && eventArgument == "FocusThisWindow")
			{
				FocusThisWindow();
			}
			if (!string.IsNullOrEmpty(eventArgument) && eventArgument == "LogOut")
			{
				LinqChatDataContext linqChatDataContext = new LinqChatDataContext();
				LoggedInUser entity = linqChatDataContext.LoggedInUsers.Where((LoggedInUser l) => l.UserID == Convert.ToInt32(Session["ChatUserID"]) && l.RoomID == Convert.ToInt32(lblRoomId.Text)).SingleOrDefault();
				linqChatDataContext.LoggedInUsers.DeleteOnSubmit(entity);
				linqChatDataContext.SubmitChanges();
				InsertMessage("Just logged out! " + DateTime.Now.ToString());
			}
			_callBackStatus = "success";
		}
		catch (Exception)
		{
		}
	}
}
