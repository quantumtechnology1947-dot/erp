using System.ComponentModel;
using System.Data.Linq;
using System.Data.Linq.Mapping;

[Table(Name = "dbo.LoggedInUser")]
public class LoggedInUser : INotifyPropertyChanging, INotifyPropertyChanged
{
	private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(string.Empty);

	private int _LoggedInUserID;

	private int _UserID;

	private int _RoomID;

	private EntityRef<Room> _Room;

	private EntityRef<User> _User;

	[Column(Storage = "_LoggedInUserID", AutoSync = AutoSync.OnInsert, DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true)]
	public int LoggedInUserID
	{
		get
		{
			return _LoggedInUserID;
		}
		set
		{
			if (_LoggedInUserID != value)
			{
				SendPropertyChanging();
				_LoggedInUserID = value;
				SendPropertyChanged("LoggedInUserID");
			}
		}
	}

	[Column(Storage = "_UserID", DbType = "Int NOT NULL")]
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
				if (_User.HasLoadedOrAssignedValue)
				{
					throw new ForeignKeyReferenceAlreadyHasValueException();
				}
				SendPropertyChanging();
				_UserID = value;
				SendPropertyChanged("UserID");
			}
		}
	}

	[Column(Storage = "_RoomID", DbType = "Int NOT NULL")]
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
				if (_Room.HasLoadedOrAssignedValue)
				{
					throw new ForeignKeyReferenceAlreadyHasValueException();
				}
				SendPropertyChanging();
				_RoomID = value;
				SendPropertyChanged("RoomID");
			}
		}
	}

	[Association(Name = "Room_LoggedInUser", Storage = "_Room", ThisKey = "RoomID", IsForeignKey = true)]
	public Room Room
	{
		get
		{
			return _Room.Entity;
		}
		set
		{
			Room entity = _Room.Entity;
			if (entity != value || !_Room.HasLoadedOrAssignedValue)
			{
				SendPropertyChanging();
				if (entity != null)
				{
					_Room.Entity = null;
					entity.LoggedInUsers.Remove(this);
				}
				_Room.Entity = value;
				if (value != null)
				{
					value.LoggedInUsers.Add(this);
					_RoomID = value.RoomID;
				}
				else
				{
					_RoomID = 0;
				}
				SendPropertyChanged("Room");
			}
		}
	}

	[Association(Name = "User_LoggedInUser", Storage = "_User", ThisKey = "UserID", IsForeignKey = true)]
	public User User
	{
		get
		{
			return _User.Entity;
		}
		set
		{
			User entity = _User.Entity;
			if (entity != value || !_User.HasLoadedOrAssignedValue)
			{
				SendPropertyChanging();
				if (entity != null)
				{
					_User.Entity = null;
					entity.LoggedInUsers.Remove(this);
				}
				_User.Entity = value;
				if (value != null)
				{
					value.LoggedInUsers.Add(this);
					_UserID = value.UserID;
				}
				else
				{
					_UserID = 0;
				}
				SendPropertyChanged("User");
			}
		}
	}

	public event PropertyChangingEventHandler PropertyChanging;

	public event PropertyChangedEventHandler PropertyChanged;

	public LoggedInUser()
	{
		_Room = default(EntityRef<Room>);
		_User = default(EntityRef<User>);
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
}
