using System.ComponentModel;
using System.Data.Linq;
using System.Data.Linq.Mapping;

[Table(Name = "dbo.[tblHR_OfficeStaff]")]
public class User : INotifyPropertyChanging, INotifyPropertyChanged
{
	private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(string.Empty);

	private int _UserID;

	private string _EmpId;

	private string _EmployeeName;

	private string _Gender;

	private EntitySet<LoggedInUser> _LoggedInUsers;

	private EntitySet<Message> _Messages;

	private EntitySet<Message> _Messages1;

	private EntitySet<PrivateMessage> _PrivateMessages;

	private EntitySet<PrivateMessage> _PrivateMessages1;

	[Column(Storage = "_UserID", AutoSync = AutoSync.OnInsert, DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true)]
	public int UserID
	{
		get
		{
			return _UserID;
		}
		set
		{
			if (_UserID != value)
			{
				SendPropertyChanging();
				_UserID = value;
				SendPropertyChanged("UserID");
			}
		}
	}

	[Column(Storage = "_EmpId", DbType = "VarChar(30) NOT NULL", CanBeNull = false)]
	public string EmpId
	{
		get
		{
			return _EmpId;
		}
		set
		{
			if (_EmpId != value)
			{
				SendPropertyChanging();
				_EmpId = value;
				SendPropertyChanged("EmpId");
			}
		}
	}

	[Column(Storage = "_EmployeeName", DbType = "VarChar(30) NOT NULL", CanBeNull = false)]
	public string EmployeeName
	{
		get
		{
			return _EmployeeName;
		}
		set
		{
			if (_EmployeeName != value)
			{
				SendPropertyChanging();
				_EmployeeName = value;
				SendPropertyChanged("EmployeeName");
			}
		}
	}

	[Column(Storage = "_Gender", DbType = "VarChar(50) NOT NULL", CanBeNull = false)]
	public string Gender
	{
		get
		{
			return _Gender;
		}
		set
		{
			if (_Gender != value)
			{
				SendPropertyChanging();
				_Gender = value;
				SendPropertyChanged("Gender");
			}
		}
	}

	[Association(Name = "User_LoggedInUser", Storage = "_LoggedInUsers", OtherKey = "UserID")]
	public EntitySet<LoggedInUser> LoggedInUsers
	{
		get
		{
			return _LoggedInUsers;
		}
		set
		{
			_LoggedInUsers.Assign(value);
		}
	}

	[Association(Name = "User_Message", Storage = "_Messages", OtherKey = "UserID")]
	public EntitySet<Message> Messages
	{
		get
		{
			return _Messages;
		}
		set
		{
			_Messages.Assign(value);
		}
	}

	[Association(Name = "User_Message1", Storage = "_Messages1", OtherKey = "ToUserID")]
	public EntitySet<Message> Messages1
	{
		get
		{
			return _Messages1;
		}
		set
		{
			_Messages1.Assign(value);
		}
	}

	[Association(Name = "User_PrivateMessage", Storage = "_PrivateMessages", OtherKey = "UserID")]
	public EntitySet<PrivateMessage> PrivateMessages
	{
		get
		{
			return _PrivateMessages;
		}
		set
		{
			_PrivateMessages.Assign(value);
		}
	}

	[Association(Name = "User_PrivateMessage1", Storage = "_PrivateMessages1", OtherKey = "ToUserID")]
	public EntitySet<PrivateMessage> PrivateMessages1
	{
		get
		{
			return _PrivateMessages1;
		}
		set
		{
			_PrivateMessages1.Assign(value);
		}
	}

	public event PropertyChangingEventHandler PropertyChanging;

	public event PropertyChangedEventHandler PropertyChanged;

	public User()
	{
		_LoggedInUsers = new EntitySet<LoggedInUser>(attach_LoggedInUsers, detach_LoggedInUsers);
		_Messages = new EntitySet<Message>(attach_Messages, detach_Messages);
		_Messages1 = new EntitySet<Message>(attach_Messages1, detach_Messages1);
		_PrivateMessages = new EntitySet<PrivateMessage>(attach_PrivateMessages, detach_PrivateMessages);
		_PrivateMessages1 = new EntitySet<PrivateMessage>(attach_PrivateMessages1, detach_PrivateMessages1);
	}

	protected virtual void SendPropertyChanging()
	{
		if (this.PropertyChanging != null)
		{
			this.PropertyChanging(this, emptyChangingEventArgs);
		}
	}

	protected virtual void SendPropertyChanged(string propertyName)
	{
		if (this.PropertyChanged != null)
		{
			this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
		}
	}

	private void attach_LoggedInUsers(LoggedInUser entity)
	{
		SendPropertyChanging();
		entity.User = this;
	}

	private void detach_LoggedInUsers(LoggedInUser entity)
	{
		SendPropertyChanging();
		entity.User = null;
	}

	private void attach_Messages(Message entity)
	{
		SendPropertyChanging();
		entity.User = this;
	}

	private void detach_Messages(Message entity)
	{
		SendPropertyChanging();
		entity.User = null;
	}

	private void attach_Messages1(Message entity)
	{
		SendPropertyChanging();
		entity.User1 = this;
	}

	private void detach_Messages1(Message entity)
	{
		SendPropertyChanging();
		entity.User1 = null;
	}

	private void attach_PrivateMessages(PrivateMessage entity)
	{
		SendPropertyChanging();
		entity.User = this;
	}

	private void detach_PrivateMessages(PrivateMessage entity)
	{
		SendPropertyChanging();
		entity.User = null;
	}

	private void attach_PrivateMessages1(PrivateMessage entity)
	{
		SendPropertyChanging();
		entity.User1 = this;
	}

	private void detach_PrivateMessages1(PrivateMessage entity)
	{
		SendPropertyChanging();
		entity.User1 = null;
	}
}
