using System.ComponentModel;
using System.Data.Linq;
using System.Data.Linq.Mapping;

[Table(Name = "dbo.Room")]
public class Room : INotifyPropertyChanging, INotifyPropertyChanged
{
	private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(string.Empty);

	private int _RoomID;

	private string _Name;

	private EntitySet<LoggedInUser> _LoggedInUsers;

	private EntitySet<Message> _Messages;

	[Column(Storage = "_RoomID", AutoSync = AutoSync.OnInsert, DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true)]
	public int RoomID
	{
		get
		{
			return _RoomID;
		}
		set
		{
			if (_RoomID != value)
			{
				SendPropertyChanging();
				_RoomID = value;
				SendPropertyChanged("RoomID");
			}
		}
	}

	[Column(Storage = "_Name", DbType = "VarChar(50) NOT NULL", CanBeNull = false)]
	public string Name
	{
		get
		{
			return _Name;
		}
		set
		{
			if (_Name != value)
			{
				SendPropertyChanging();
				_Name = value;
				SendPropertyChanged("Name");
			}
		}
	}

	[Association(Name = "Room_LoggedInUser", Storage = "_LoggedInUsers", OtherKey = "RoomID")]
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

	[Association(Name = "Room_Message", Storage = "_Messages", OtherKey = "RoomID")]
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

	public event PropertyChangingEventHandler PropertyChanging;

	public event PropertyChangedEventHandler PropertyChanged;

	public Room()
	{
		_LoggedInUsers = new EntitySet<LoggedInUser>(attach_LoggedInUsers, detach_LoggedInUsers);
		_Messages = new EntitySet<Message>(attach_Messages, detach_Messages);
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
		entity.Room = this;
	}

	private void detach_LoggedInUsers(LoggedInUser entity)
	{
		SendPropertyChanging();
		entity.Room = null;
	}

	private void attach_Messages(Message entity)
	{
		SendPropertyChanging();
		entity.Room = this;
	}

	private void detach_Messages(Message entity)
	{
		SendPropertyChanging();
		entity.Room = null;
	}
}
