using System.ComponentModel;
using System.Data.Linq;
using System.Data.Linq.Mapping;

[Table(Name = "dbo.PrivateMessage")]
public class PrivateMessage : INotifyPropertyChanging, INotifyPropertyChanged
{
	private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(string.Empty);

	private int _PrivateMessageID;

	private int _UserID;

	private int _ToUserID;

	private EntityRef<User> _User;

	private EntityRef<User> _User1;

	[Column(Storage = "_PrivateMessageID", AutoSync = AutoSync.OnInsert, DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true)]
	public int PrivateMessageID
	{
		get
		{
			return _PrivateMessageID;
		}
		set
		{
			if (_PrivateMessageID != value)
			{
				SendPropertyChanging();
				_PrivateMessageID = value;
				SendPropertyChanged("PrivateMessageID");
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

	[Column(Storage = "_ToUserID", DbType = "Int NOT NULL")]
	public int ToUserID
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

	[Association(Name = "User_PrivateMessage", Storage = "_User", ThisKey = "UserID", IsForeignKey = true)]
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
					entity.PrivateMessages.Remove(this);
				}
				_User.Entity = value;
				if (value != null)
				{
					value.PrivateMessages.Add(this);
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

	[Association(Name = "User_PrivateMessage1", Storage = "_User1", ThisKey = "ToUserID", IsForeignKey = true)]
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
					entity.PrivateMessages1.Remove(this);
				}
				_User1.Entity = value;
				if (value != null)
				{
					value.PrivateMessages1.Add(this);
					_ToUserID = value.UserID;
				}
				else
				{
					_ToUserID = 0;
				}
				SendPropertyChanged("User1");
			}
		}
	}

	public event PropertyChangingEventHandler PropertyChanging;

	public event PropertyChangedEventHandler PropertyChanged;

	public PrivateMessage()
	{
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
