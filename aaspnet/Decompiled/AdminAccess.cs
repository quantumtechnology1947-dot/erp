using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

[Serializable]
[DesignerCategory("code")]
[ToolboxItem(true)]
[HelpKeyword("vs.data.DataSet")]
[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
[XmlSchemaProvider("GetTypedDataSetSchema")]
[XmlRoot("AdminAccess")]
public class AdminAccess : DataSet
{
	public delegate void DataTable1RowChangeEventHandler(object sender, DataTable1RowChangeEvent e);

	[Serializable]
	[XmlSchemaProvider("GetTypedTableSchema")]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
	public class DataTable1DataTable : TypedTableBase<DataTable1Row>
	{
		private DataColumn columnId;

		private DataColumn columnCompId;

		private DataColumn columnFinYear;

		private DataColumn columnEmployeeName;

		private DataColumn columnDepartment;

		private DataColumn columnDesination;

		private DataColumn columnContactNo;

		private DataColumn columnCompanyEmail;

		private DataColumn columnExtNo;

		private DataColumn columnModName;

		private DataColumn columnSubModName;

		private DataColumn columnAccessType;

		private DataColumn columnAccess;

		private DataColumn columnType;

		[DebuggerNonUserCode]
		public DataColumn IdColumn => columnId;

		[DebuggerNonUserCode]
		public DataColumn CompIdColumn => columnCompId;

		[DebuggerNonUserCode]
		public DataColumn FinYearColumn => columnFinYear;

		[DebuggerNonUserCode]
		public DataColumn EmployeeNameColumn => columnEmployeeName;

		[DebuggerNonUserCode]
		public DataColumn DepartmentColumn => columnDepartment;

		[DebuggerNonUserCode]
		public DataColumn DesinationColumn => columnDesination;

		[DebuggerNonUserCode]
		public DataColumn ContactNoColumn => columnContactNo;

		[DebuggerNonUserCode]
		public DataColumn CompanyEmailColumn => columnCompanyEmail;

		[DebuggerNonUserCode]
		public DataColumn ExtNoColumn => columnExtNo;

		[DebuggerNonUserCode]
		public DataColumn ModNameColumn => columnModName;

		[DebuggerNonUserCode]
		public DataColumn SubModNameColumn => columnSubModName;

		[DebuggerNonUserCode]
		public DataColumn AccessTypeColumn => columnAccessType;

		[DebuggerNonUserCode]
		public DataColumn AccessColumn => columnAccess;

		[DebuggerNonUserCode]
		public DataColumn TypeColumn => columnType;

		[DebuggerNonUserCode]
		[Browsable(false)]
		public int Count => base.Rows.Count;

		[DebuggerNonUserCode]
		public DataTable1Row this[int index] => (DataTable1Row)base.Rows[index];

		public event DataTable1RowChangeEventHandler DataTable1RowChanging;

		public event DataTable1RowChangeEventHandler DataTable1RowChanged;

		public event DataTable1RowChangeEventHandler DataTable1RowDeleting;

		public event DataTable1RowChangeEventHandler DataTable1RowDeleted;

		[DebuggerNonUserCode]
		public DataTable1DataTable()
		{
			base.TableName = "DataTable1";
			BeginInit();
			InitClass();
			EndInit();
		}

		[DebuggerNonUserCode]
		internal DataTable1DataTable(DataTable table)
		{
			base.TableName = table.TableName;
			if (table.CaseSensitive != table.DataSet.CaseSensitive)
			{
				base.CaseSensitive = table.CaseSensitive;
			}
			if (table.Locale.ToString() != table.DataSet.Locale.ToString())
			{
				base.Locale = table.Locale;
			}
			if (table.Namespace != table.DataSet.Namespace)
			{
				base.Namespace = table.Namespace;
			}
			base.Prefix = table.Prefix;
			base.MinimumCapacity = table.MinimumCapacity;
		}

		[DebuggerNonUserCode]
		protected DataTable1DataTable(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
			InitVars();
		}

		[DebuggerNonUserCode]
		public void AddDataTable1Row(DataTable1Row row)
		{
			base.Rows.Add(row);
		}

		[DebuggerNonUserCode]
		public DataTable1Row AddDataTable1Row(int Id, int CompId, string FinYear, string EmployeeName, string Department, string Desination, string ContactNo, string CompanyEmail, string ExtNo, string ModName, string SubModName, string AccessType, string Access, string Type)
		{
			DataTable1Row dataTable1Row = (DataTable1Row)NewRow();
			object[] itemArray = new object[14]
			{
				Id, CompId, FinYear, EmployeeName, Department, Desination, ContactNo, CompanyEmail, ExtNo, ModName,
				SubModName, AccessType, Access, Type
			};
			dataTable1Row.ItemArray = itemArray;
			base.Rows.Add(dataTable1Row);
			return dataTable1Row;
		}

		[DebuggerNonUserCode]
		public override DataTable Clone()
		{
			DataTable1DataTable dataTable1DataTable = (DataTable1DataTable)base.Clone();
			dataTable1DataTable.InitVars();
			return dataTable1DataTable;
		}

		[DebuggerNonUserCode]
		protected override DataTable CreateInstance()
		{
			return new DataTable1DataTable();
		}

		[DebuggerNonUserCode]
		internal void InitVars()
		{
			columnId = base.Columns["Id"];
			columnCompId = base.Columns["CompId"];
			columnFinYear = base.Columns["FinYear"];
			columnEmployeeName = base.Columns["EmployeeName"];
			columnDepartment = base.Columns["Department"];
			columnDesination = base.Columns["Desination"];
			columnContactNo = base.Columns["ContactNo"];
			columnCompanyEmail = base.Columns["CompanyEmail"];
			columnExtNo = base.Columns["ExtNo"];
			columnModName = base.Columns["ModName"];
			columnSubModName = base.Columns["SubModName"];
			columnAccessType = base.Columns["AccessType"];
			columnAccess = base.Columns["Access"];
			columnType = base.Columns["Type"];
		}

		[DebuggerNonUserCode]
		private void InitClass()
		{
			columnId = new DataColumn("Id", typeof(int), null, MappingType.Element);
			base.Columns.Add(columnId);
			columnCompId = new DataColumn("CompId", typeof(int), null, MappingType.Element);
			base.Columns.Add(columnCompId);
			columnFinYear = new DataColumn("FinYear", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnFinYear);
			columnEmployeeName = new DataColumn("EmployeeName", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnEmployeeName);
			columnDepartment = new DataColumn("Department", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnDepartment);
			columnDesination = new DataColumn("Desination", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnDesination);
			columnContactNo = new DataColumn("ContactNo", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnContactNo);
			columnCompanyEmail = new DataColumn("CompanyEmail", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnCompanyEmail);
			columnExtNo = new DataColumn("ExtNo", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnExtNo);
			columnModName = new DataColumn("ModName", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnModName);
			columnSubModName = new DataColumn("SubModName", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnSubModName);
			columnAccessType = new DataColumn("AccessType", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnAccessType);
			columnAccess = new DataColumn("Access", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnAccess);
			columnType = new DataColumn("Type", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnType);
		}

		[DebuggerNonUserCode]
		public DataTable1Row NewDataTable1Row()
		{
			return (DataTable1Row)NewRow();
		}

		[DebuggerNonUserCode]
		protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
		{
			return new DataTable1Row(builder);
		}

		[DebuggerNonUserCode]
		protected override Type GetRowType()
		{
			return typeof(DataTable1Row);
		}

		[DebuggerNonUserCode]
		protected override void OnRowChanged(DataRowChangeEventArgs e)
		{
			base.OnRowChanged(e);
			if (this.DataTable1RowChanged != null)
			{
				this.DataTable1RowChanged(this, new DataTable1RowChangeEvent((DataTable1Row)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		protected override void OnRowChanging(DataRowChangeEventArgs e)
		{
			base.OnRowChanging(e);
			if (this.DataTable1RowChanging != null)
			{
				this.DataTable1RowChanging(this, new DataTable1RowChangeEvent((DataTable1Row)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		protected override void OnRowDeleted(DataRowChangeEventArgs e)
		{
			base.OnRowDeleted(e);
			if (this.DataTable1RowDeleted != null)
			{
				this.DataTable1RowDeleted(this, new DataTable1RowChangeEvent((DataTable1Row)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		protected override void OnRowDeleting(DataRowChangeEventArgs e)
		{
			base.OnRowDeleting(e);
			if (this.DataTable1RowDeleting != null)
			{
				this.DataTable1RowDeleting(this, new DataTable1RowChangeEvent((DataTable1Row)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		public void RemoveDataTable1Row(DataTable1Row row)
		{
			base.Rows.Remove(row);
		}

		[DebuggerNonUserCode]
		public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
		{
			XmlSchemaComplexType xmlSchemaComplexType = new XmlSchemaComplexType();
			XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
			AdminAccess adminAccess = new AdminAccess();
			XmlSchemaAny xmlSchemaAny = new XmlSchemaAny();
			xmlSchemaAny.Namespace = "http://www.w3.org/2001/XMLSchema";
			xmlSchemaAny.MinOccurs = 0m;
			xmlSchemaAny.MaxOccurs = decimal.MaxValue;
			xmlSchemaAny.ProcessContents = XmlSchemaContentProcessing.Lax;
			xmlSchemaSequence.Items.Add(xmlSchemaAny);
			XmlSchemaAny xmlSchemaAny2 = new XmlSchemaAny();
			xmlSchemaAny2.Namespace = "urn:schemas-microsoft-com:xml-diffgram-v1";
			xmlSchemaAny2.MinOccurs = 1m;
			xmlSchemaAny2.ProcessContents = XmlSchemaContentProcessing.Lax;
			xmlSchemaSequence.Items.Add(xmlSchemaAny2);
			XmlSchemaAttribute xmlSchemaAttribute = new XmlSchemaAttribute();
			xmlSchemaAttribute.Name = "namespace";
			xmlSchemaAttribute.FixedValue = adminAccess.Namespace;
			xmlSchemaComplexType.Attributes.Add(xmlSchemaAttribute);
			XmlSchemaAttribute xmlSchemaAttribute2 = new XmlSchemaAttribute();
			xmlSchemaAttribute2.Name = "tableTypeName";
			xmlSchemaAttribute2.FixedValue = "DataTable1DataTable";
			xmlSchemaComplexType.Attributes.Add(xmlSchemaAttribute2);
			xmlSchemaComplexType.Particle = xmlSchemaSequence;
			XmlSchema schemaSerializable = adminAccess.GetSchemaSerializable();
			if (xs.Contains(schemaSerializable.TargetNamespace))
			{
				MemoryStream memoryStream = new MemoryStream();
				MemoryStream memoryStream2 = new MemoryStream();
				try
				{
					XmlSchema xmlSchema = null;
					schemaSerializable.Write(memoryStream);
					IEnumerator enumerator = xs.Schemas(schemaSerializable.TargetNamespace).GetEnumerator();
					while (enumerator.MoveNext())
					{
						xmlSchema = (XmlSchema)enumerator.Current;
						memoryStream2.SetLength(0L);
						xmlSchema.Write(memoryStream2);
						if (memoryStream.Length == memoryStream2.Length)
						{
							memoryStream.Position = 0L;
							memoryStream2.Position = 0L;
							while (memoryStream.Position != memoryStream.Length && memoryStream.ReadByte() == memoryStream2.ReadByte())
							{
							}
							if (memoryStream.Position == memoryStream.Length)
							{
								return xmlSchemaComplexType;
							}
						}
					}
				}
				finally
				{
					memoryStream?.Close();
					memoryStream2?.Close();
				}
			}
			xs.Add(schemaSerializable);
			return xmlSchemaComplexType;
		}
	}

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
	public class DataTable1Row : DataRow
	{
		private DataTable1DataTable tableDataTable1;

		[DebuggerNonUserCode]
		public int Id
		{
			get
			{
				try
				{
					return (int)base[tableDataTable1.IdColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Id' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.IdColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public int CompId
		{
			get
			{
				try
				{
					return (int)base[tableDataTable1.CompIdColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'CompId' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.CompIdColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string FinYear
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.FinYearColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'FinYear' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.FinYearColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string EmployeeName
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.EmployeeNameColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'EmployeeName' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.EmployeeNameColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string Department
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.DepartmentColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Department' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.DepartmentColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string Desination
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.DesinationColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Desination' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.DesinationColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string ContactNo
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.ContactNoColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'ContactNo' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.ContactNoColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string CompanyEmail
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.CompanyEmailColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'CompanyEmail' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.CompanyEmailColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string ExtNo
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.ExtNoColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'ExtNo' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.ExtNoColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string ModName
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.ModNameColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'ModName' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.ModNameColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string SubModName
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.SubModNameColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'SubModName' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.SubModNameColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string AccessType
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.AccessTypeColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'AccessType' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.AccessTypeColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string Access
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.AccessColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Access' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.AccessColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string Type
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.TypeColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Type' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.TypeColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		internal DataTable1Row(DataRowBuilder rb)
			: base(rb)
		{
			tableDataTable1 = (DataTable1DataTable)base.Table;
		}

		[DebuggerNonUserCode]
		public bool IsIdNull()
		{
			return IsNull(tableDataTable1.IdColumn);
		}

		[DebuggerNonUserCode]
		public void SetIdNull()
		{
			base[tableDataTable1.IdColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsCompIdNull()
		{
			return IsNull(tableDataTable1.CompIdColumn);
		}

		[DebuggerNonUserCode]
		public void SetCompIdNull()
		{
			base[tableDataTable1.CompIdColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsFinYearNull()
		{
			return IsNull(tableDataTable1.FinYearColumn);
		}

		[DebuggerNonUserCode]
		public void SetFinYearNull()
		{
			base[tableDataTable1.FinYearColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsEmployeeNameNull()
		{
			return IsNull(tableDataTable1.EmployeeNameColumn);
		}

		[DebuggerNonUserCode]
		public void SetEmployeeNameNull()
		{
			base[tableDataTable1.EmployeeNameColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsDepartmentNull()
		{
			return IsNull(tableDataTable1.DepartmentColumn);
		}

		[DebuggerNonUserCode]
		public void SetDepartmentNull()
		{
			base[tableDataTable1.DepartmentColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsDesinationNull()
		{
			return IsNull(tableDataTable1.DesinationColumn);
		}

		[DebuggerNonUserCode]
		public void SetDesinationNull()
		{
			base[tableDataTable1.DesinationColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsContactNoNull()
		{
			return IsNull(tableDataTable1.ContactNoColumn);
		}

		[DebuggerNonUserCode]
		public void SetContactNoNull()
		{
			base[tableDataTable1.ContactNoColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsCompanyEmailNull()
		{
			return IsNull(tableDataTable1.CompanyEmailColumn);
		}

		[DebuggerNonUserCode]
		public void SetCompanyEmailNull()
		{
			base[tableDataTable1.CompanyEmailColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsExtNoNull()
		{
			return IsNull(tableDataTable1.ExtNoColumn);
		}

		[DebuggerNonUserCode]
		public void SetExtNoNull()
		{
			base[tableDataTable1.ExtNoColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsModNameNull()
		{
			return IsNull(tableDataTable1.ModNameColumn);
		}

		[DebuggerNonUserCode]
		public void SetModNameNull()
		{
			base[tableDataTable1.ModNameColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsSubModNameNull()
		{
			return IsNull(tableDataTable1.SubModNameColumn);
		}

		[DebuggerNonUserCode]
		public void SetSubModNameNull()
		{
			base[tableDataTable1.SubModNameColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsAccessTypeNull()
		{
			return IsNull(tableDataTable1.AccessTypeColumn);
		}

		[DebuggerNonUserCode]
		public void SetAccessTypeNull()
		{
			base[tableDataTable1.AccessTypeColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsAccessNull()
		{
			return IsNull(tableDataTable1.AccessColumn);
		}

		[DebuggerNonUserCode]
		public void SetAccessNull()
		{
			base[tableDataTable1.AccessColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsTypeNull()
		{
			return IsNull(tableDataTable1.TypeColumn);
		}

		[DebuggerNonUserCode]
		public void SetTypeNull()
		{
			base[tableDataTable1.TypeColumn] = Convert.DBNull;
		}
	}

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
	public class DataTable1RowChangeEvent : EventArgs
	{
		private DataTable1Row eventRow;

		private DataRowAction eventAction;

		[DebuggerNonUserCode]
		public DataTable1Row Row => eventRow;

		[DebuggerNonUserCode]
		public DataRowAction Action => eventAction;

		[DebuggerNonUserCode]
		public DataTable1RowChangeEvent(DataTable1Row row, DataRowAction action)
		{
			eventRow = row;
			eventAction = action;
		}
	}

	private DataTable1DataTable tableDataTable1;

	private SchemaSerializationMode _schemaSerializationMode = SchemaSerializationMode.IncludeSchema;

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	[Browsable(false)]
	[DebuggerNonUserCode]
	public DataTable1DataTable DataTable1 => tableDataTable1;

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
	[Browsable(true)]
	[DebuggerNonUserCode]
	public override SchemaSerializationMode SchemaSerializationMode
	{
		get
		{
			return _schemaSerializationMode;
		}
		set
		{
			_schemaSerializationMode = value;
		}
	}

	[DebuggerNonUserCode]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataRelationCollection Relations => base.Relations;

	[DebuggerNonUserCode]
	public AdminAccess()
	{
		BeginInit();
		InitClass();
		CollectionChangeEventHandler value = SchemaChanged;
		base.Tables.CollectionChanged += value;
		base.Relations.CollectionChanged += value;
		EndInit();
	}

	[DebuggerNonUserCode]
	protected AdminAccess(SerializationInfo info, StreamingContext context)
		: base(info, context, ConstructSchema: false)
	{
		if (IsBinarySerialized(info, context))
		{
			InitVars(initTable: false);
			CollectionChangeEventHandler value = SchemaChanged;
			Tables.CollectionChanged += value;
			Relations.CollectionChanged += value;
			return;
		}
		string s = (string)info.GetValue("XmlSchema", typeof(string));
		if (DetermineSchemaSerializationMode(info, context) == SchemaSerializationMode.IncludeSchema)
		{
			DataSet dataSet = new DataSet();
			dataSet.ReadXmlSchema(new XmlTextReader(new StringReader(s)));
			if (dataSet.Tables["DataTable1"] != null)
			{
				base.Tables.Add(new DataTable1DataTable(dataSet.Tables["DataTable1"]));
			}
			base.DataSetName = dataSet.DataSetName;
			base.Prefix = dataSet.Prefix;
			base.Namespace = dataSet.Namespace;
			base.Locale = dataSet.Locale;
			base.CaseSensitive = dataSet.CaseSensitive;
			base.EnforceConstraints = dataSet.EnforceConstraints;
			Merge(dataSet, preserveChanges: false, MissingSchemaAction.Add);
			InitVars();
		}
		else
		{
			ReadXmlSchema(new XmlTextReader(new StringReader(s)));
		}
		GetSerializationData(info, context);
		CollectionChangeEventHandler value2 = SchemaChanged;
		base.Tables.CollectionChanged += value2;
		Relations.CollectionChanged += value2;
	}

	[DebuggerNonUserCode]
	protected override void InitializeDerivedDataSet()
	{
		BeginInit();
		InitClass();
		EndInit();
	}

	[DebuggerNonUserCode]
	public override DataSet Clone()
	{
		AdminAccess adminAccess = (AdminAccess)base.Clone();
		adminAccess.InitVars();
		adminAccess.SchemaSerializationMode = SchemaSerializationMode;
		return adminAccess;
	}

	[DebuggerNonUserCode]
	protected override bool ShouldSerializeTables()
	{
		return false;
	}

	[DebuggerNonUserCode]
	protected override bool ShouldSerializeRelations()
	{
		return false;
	}

	[DebuggerNonUserCode]
	protected override void ReadXmlSerializable(XmlReader reader)
	{
		if (DetermineSchemaSerializationMode(reader) == SchemaSerializationMode.IncludeSchema)
		{
			Reset();
			DataSet dataSet = new DataSet();
			dataSet.ReadXml(reader);
			if (dataSet.Tables["DataTable1"] != null)
			{
				base.Tables.Add(new DataTable1DataTable(dataSet.Tables["DataTable1"]));
			}
			base.DataSetName = dataSet.DataSetName;
			base.Prefix = dataSet.Prefix;
			base.Namespace = dataSet.Namespace;
			base.Locale = dataSet.Locale;
			base.CaseSensitive = dataSet.CaseSensitive;
			base.EnforceConstraints = dataSet.EnforceConstraints;
			Merge(dataSet, preserveChanges: false, MissingSchemaAction.Add);
			InitVars();
		}
		else
		{
			ReadXml(reader);
			InitVars();
		}
	}

	[DebuggerNonUserCode]
	protected override XmlSchema GetSchemaSerializable()
	{
		MemoryStream memoryStream = new MemoryStream();
		WriteXmlSchema(new XmlTextWriter(memoryStream, null));
		memoryStream.Position = 0L;
		return XmlSchema.Read(new XmlTextReader(memoryStream), null);
	}

	[DebuggerNonUserCode]
	internal void InitVars()
	{
		InitVars(initTable: true);
	}

	[DebuggerNonUserCode]
	internal void InitVars(bool initTable)
	{
		tableDataTable1 = (DataTable1DataTable)base.Tables["DataTable1"];
		if (initTable && tableDataTable1 != null)
		{
			tableDataTable1.InitVars();
		}
	}

	[DebuggerNonUserCode]
	private void InitClass()
	{
		base.DataSetName = "AdminAccess";
		base.Prefix = "";
		base.Namespace = "http://tempuri.org/AdminAccess.xsd";
		base.EnforceConstraints = true;
		SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
		tableDataTable1 = new DataTable1DataTable();
		base.Tables.Add(tableDataTable1);
	}

	[DebuggerNonUserCode]
	private bool ShouldSerializeDataTable1()
	{
		return false;
	}

	[DebuggerNonUserCode]
	private void SchemaChanged(object sender, CollectionChangeEventArgs e)
	{
		if (e.Action == CollectionChangeAction.Remove)
		{
			InitVars();
		}
	}

	[DebuggerNonUserCode]
	public static XmlSchemaComplexType GetTypedDataSetSchema(XmlSchemaSet xs)
	{
		AdminAccess adminAccess = new AdminAccess();
		XmlSchemaComplexType xmlSchemaComplexType = new XmlSchemaComplexType();
		XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
		XmlSchemaAny xmlSchemaAny = new XmlSchemaAny();
		xmlSchemaAny.Namespace = adminAccess.Namespace;
		xmlSchemaSequence.Items.Add(xmlSchemaAny);
		xmlSchemaComplexType.Particle = xmlSchemaSequence;
		XmlSchema schemaSerializable = adminAccess.GetSchemaSerializable();
		if (xs.Contains(schemaSerializable.TargetNamespace))
		{
			MemoryStream memoryStream = new MemoryStream();
			MemoryStream memoryStream2 = new MemoryStream();
			try
			{
				XmlSchema xmlSchema = null;
				schemaSerializable.Write(memoryStream);
				IEnumerator enumerator = xs.Schemas(schemaSerializable.TargetNamespace).GetEnumerator();
				while (enumerator.MoveNext())
				{
					xmlSchema = (XmlSchema)enumerator.Current;
					memoryStream2.SetLength(0L);
					xmlSchema.Write(memoryStream2);
					if (memoryStream.Length == memoryStream2.Length)
					{
						memoryStream.Position = 0L;
						memoryStream2.Position = 0L;
						while (memoryStream.Position != memoryStream.Length && memoryStream.ReadByte() == memoryStream2.ReadByte())
						{
						}
						if (memoryStream.Position == memoryStream.Length)
						{
							return xmlSchemaComplexType;
						}
					}
				}
			}
			finally
			{
				memoryStream?.Close();
				memoryStream2?.Close();
			}
		}
		xs.Add(schemaSerializable);
		return xmlSchemaComplexType;
	}
}
