using System.ComponentModel;
using System.Data.Linq.Mapping;

[Table(Name = "dbo.tblACC_Budget_WO_Time")]
public class tblACC_Budget_WO_Time : INotifyPropertyChanging, INotifyPropertyChanged
{
	private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(string.Empty);

	private int _Id;

	private string _SysDate;

	private string _SysTime;

	private int? _CompId;

	private int? _FinYearId;

	private string _SessionId;

	private string _WONo;

	private double? _Hour;

	private int? _BudgetCodeId;

	[Column(Storage = "_Id", AutoSync = AutoSync.OnInsert, DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true)]
	public int Id
	{
		get
		{
			return _Id;
		}
		set
		{
			if (_Id != value)
			{
				SendPropertyChanging();
				_Id = value;
				SendPropertyChanged("Id");
			}
		}
	}

	[Column(Storage = "_SysDate", DbType = "VarChar(50)")]
	public string SysDate
	{
		get
		{
			return _SysDate;
		}
		set
		{
			if (_SysDate != value)
			{
				SendPropertyChanging();
				_SysDate = value;
				SendPropertyChanged("SysDate");
			}
		}
	}

	[Column(Storage = "_SysTime", DbType = "VarChar(50)")]
	public string SysTime
	{
		get
		{
			return _SysTime;
		}
		set
		{
			if (_SysTime != value)
			{
				SendPropertyChanging();
				_SysTime = value;
				SendPropertyChanged("SysTime");
			}
		}
	}

	[Column(Storage = "_CompId", DbType = "Int")]
	public int? CompId
	{
		get
		{
			return _CompId;
		}
		set
		{
			if (_CompId != value)
			{
				SendPropertyChanging();
				_CompId = value;
				SendPropertyChanged("CompId");
			}
		}
	}

	[Column(Storage = "_FinYearId", DbType = "Int")]
	public int? FinYearId
	{
		get
		{
			return _FinYearId;
		}
		set
		{
			if (_FinYearId != value)
			{
				SendPropertyChanging();
				_FinYearId = value;
				SendPropertyChanged("FinYearId");
			}
		}
	}

	[Column(Storage = "_SessionId", DbType = "VarChar(MAX)")]
	public string SessionId
	{
		get
		{
			return _SessionId;
		}
		set
		{
			if (_SessionId != value)
			{
				SendPropertyChanging();
				_SessionId = value;
				SendPropertyChanged("SessionId");
			}
		}
	}

	[Column(Storage = "_WONo", DbType = "VarChar(MAX)")]
	public string WONo
	{
		get
		{
			return _WONo;
		}
		set
		{
			if (_WONo != value)
			{
				SendPropertyChanging();
				_WONo = value;
				SendPropertyChanged("WONo");
			}
		}
	}

	[Column(Storage = "_Hour", DbType = "Float")]
	public double? Hour
	{
		get
		{
			return _Hour;
		}
		set
		{
			if (_Hour != value)
			{
				SendPropertyChanging();
				_Hour = value;
				SendPropertyChanged("Hour");
			}
		}
	}

	[Column(Storage = "_BudgetCodeId", DbType = "Int")]
	public int? BudgetCodeId
	{
		get
		{
			return _BudgetCodeId;
		}
		set
		{
			if (_BudgetCodeId != value)
			{
				SendPropertyChanging();
				_BudgetCodeId = value;
				SendPropertyChanged("BudgetCodeId");
			}
		}
	}

	public event PropertyChangingEventHandler PropertyChanging;

	public event PropertyChangedEventHandler PropertyChanged;

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
