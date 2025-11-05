using System.Data;
using System.Data.Linq;
using System.Data.Linq.Mapping;

public class DataClassesDataContext : DataContext
{
	private static MappingSource mappingSource = new AttributeMappingSource();

	public DataClassesDataContext(string connection)
		: base(connection, mappingSource)
	{
	}

	public DataClassesDataContext(IDbConnection connection)
		: base(connection, mappingSource)
	{
	}

	public DataClassesDataContext(string connection, MappingSource mappingSource)
		: base(connection, mappingSource)
	{
	}

	public DataClassesDataContext(IDbConnection connection, MappingSource mappingSource)
		: base(connection, mappingSource)
	{
	}
}
