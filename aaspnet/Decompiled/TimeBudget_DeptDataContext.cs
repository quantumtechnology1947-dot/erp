using System.Configuration;
using System.Data;
using System.Data.Linq;
using System.Data.Linq.Mapping;

[Database(Name = "D:\\INETPUB\\WWWROOT\\NEWERP\\APP_DATA\\ERP_DB.MDF")]
public class TimeBudget_DeptDataContext : DataContext
{
	private static MappingSource mappingSource = new AttributeMappingSource();

	public Table<tblACC_Budget_Dept_Time> tblACC_Budget_Dept_Times => GetTable<tblACC_Budget_Dept_Time>();

	public Table<tblACC_Budget_WO_Time> tblACC_Budget_WO_Times => GetTable<tblACC_Budget_WO_Time>();

	public TimeBudget_DeptDataContext()
		: base(ConfigurationManager.ConnectionStrings["LocalSqlServer"].ConnectionString, mappingSource)
	{
	}

	public TimeBudget_DeptDataContext(string connection)
		: base(connection, mappingSource)
	{
	}

	public TimeBudget_DeptDataContext(IDbConnection connection)
		: base(connection, mappingSource)
	{
	}

	public TimeBudget_DeptDataContext(string connection, MappingSource mappingSource)
		: base(connection, mappingSource)
	{
	}

	public TimeBudget_DeptDataContext(IDbConnection connection, MappingSource mappingSource)
		: base(connection, mappingSource)
	{
	}
}
