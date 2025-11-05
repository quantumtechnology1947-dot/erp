using System.Configuration;
using System.Data;
using System.Data.Linq;
using System.Data.Linq.Mapping;

[Database(Name = "LinqChat")]
public class LinqChatDataContext : DataContext
{
	private static MappingSource mappingSource = new AttributeMappingSource();

	public Table<LoggedInUser> LoggedInUsers => GetTable<LoggedInUser>();

	public Table<Message> Messages => GetTable<Message>();

	public Table<Room> Rooms => GetTable<Room>();

	public Table<User> User => GetTable<User>();

	public Table<PrivateMessage> PrivateMessages => GetTable<PrivateMessage>();

	public LinqChatDataContext()
		: base(ConfigurationManager.ConnectionStrings["LocalSqlServer"].ConnectionString, mappingSource)
	{
	}

	public LinqChatDataContext(string connection)
		: base(connection, mappingSource)
	{
	}

	public LinqChatDataContext(IDbConnection connection)
		: base(connection, mappingSource)
	{
	}

	public LinqChatDataContext(string connection, MappingSource mappingSource)
		: base(connection, mappingSource)
	{
	}

	public LinqChatDataContext(IDbConnection connection, MappingSource mappingSource)
		: base(connection, mappingSource)
	{
	}
}
