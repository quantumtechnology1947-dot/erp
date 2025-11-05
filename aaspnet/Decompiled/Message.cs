using System;
using System.ComponentModel;
using System.Data.Linq;
using System.Data.Linq.Mapping;

[Table(Name = "dbo.Message")]
public class Message : INotifyPropertyChanging, INotifyPropertyChanged
{
	private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(string.Empty);

	private int _MessageID;

	private int? _RoomID;

	private int _UserID;

	private int? _ToUserID;

	private string _Text;

	private DateTime _TimeStamp;

	private EntityRef<Room> _Room;

	private EntityRef<User> _User;

	private EntityRef<User> _User1;

	[Column(Storage = "_MessageID", AutoSync = AutoSync.OnInsert, DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true)]
	public int MessageID
	{
		get
		{
			return _MessageID;
		}
		set
		{
			if (_MessageID != value)
			{
				SendPropertyChanging();
				_MessageID = value;
				SendPropertyChanged("MessageID");
			}
		}
	}

	[Column(Storage = "_RoomID", DbType = "Int")]
	public int? RoomID
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

	[Column(Storage = "_ToUserID", DbType = "Int")]
	public int? ToUserID
	{
		get
		{
			return _ToUserID;
		}
		set
		{
			if (_ToUserID != value)
			{
				if (_User1.HasLoadedOrAssignedValue)
				{
					throw new ForeignKeyReferenceAlreadyHasValueException();
				}
				SendPropertyChanging();
				_ToUserID = value;
				SendPropertyChanged("ToUserID");
			}
		}
	}

	[Column(Storage = "_Text", DbType = "VarChar(100) NOT NULL", CanBeNull = false)]
	public string Text
	{
		get
		{
			return _Text;
		}
		set
		{
			if (_Text != value)
			{
				SendPropertyChanging();
				_Text = value;
				SendPropertyChanged("Text");
			}
		}
	}

	[Column(Storage = "_TimeStamp", DbType = "DateTime NOT NULL")]
	public DateTime TimeStamp
	{
		get
		{
			return _TimeStamp;
		}
		set
		{
			if (_TimeStamp != value)
			{
				SendPropertyChanging();
				_TimeStamp = value;
				SendPropertyChanged("TimeStamp");
			}
		}
	}

	[Association(Name = "Room_Message", Storage = "_Room", ThisKey = "RoomID", IsForeignKey = true)]
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
					entity.Messages.Remove(this);
				}
				_Room.Entity = value;
				if (value != null)
				{
					value.Messages.Add(this);
					_RoomID = value.RoomID;
				}
				else
				{
					_RoomID = null;
				}
				SendPropertyChanged("Room");
			}
		}
	}

	[Association(Name = "User_Message", Storage = "_User", ThisKey = "UserID", IsForeignKey = true)]
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
					entity.Messages.Remove(this);
				}
				_User.Entity = value;
				if (value != null)
				{
					value.Messages.Add(this);
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

	[Association(Name = "User_Message1", Storage = "_User1", ThisKey = "ToUserID", IsForeignKey = true)]
	public User User1
	{
		get
		{
			return _User1.Entity;
		}
		set
		{
			User entity = _User1.Entity;
			if (entity != value || !_User1.HasLoadedOrAssignedValue)
			{
				SendPropertyChanging();
				if (entity != null)
				{
					_User1.Entity = null;
					entity.Messages1.Remove(this);
				}
				_User1.Entity = value;
				if (value != null)
				{
					value.Messages1.Add(this);
					_ToUserID = value.UserID;
				}
				else
				{
					_ToUserID = null;
				}
				SendPropertyChanged("User1");
			}
		}
	}

	public event PropertyChangingEventHandler PropertyChanging;

	public event PropertyChangedEventHandler PropertyChanged;

	public Message()
	{
		_Room = default(EntityRef<Room>);
		_User = default(EntityRef<User>);
		_User1 = default(EntityRef<User>);
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
