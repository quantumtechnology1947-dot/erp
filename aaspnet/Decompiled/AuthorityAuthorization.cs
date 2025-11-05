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
[XmlRoot("AuthorityAuthorization")]
[HelpKeyword("vs.data.DataSet")]
[DesignerCategory("code")]
[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
[ToolboxItem(true)]
[XmlSchemaProvider("GetTypedDataSetSchema")]
public class AuthorityAuthorization : DataSet
{
	public delegate void DataTable1RowChangeEventHandler(object sender, DataTable1RowChangeEvent e);

	[Serializable]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
	[XmlSchemaProvider("GetTypedTableSchema")]
	public class DataTable1DataTable : TypedTableBase<DataTable1Row>
	{
		private DataColumn columnId;

		private DataColumn columnCompId;

		private DataColumn columnSysDate;

		private DataColumn columnSysPwd;

		private DataColumn columnERPPwd;

		private DataColumn columnEmailId;

		private DataColumn columnEmailPwd;

		private DataColumn columnEmpId;

		private DataColumn columnEmployeeName;

		private DataColumn columnHOD;

		private DataColumn columnDesignation;

		private DataColumn columnDepartment;

		[DebuggerNonUserCode]
		public DataColumn IdColumn => columnId;

		[DebuggerNonUserCode]
		public DataColumn CompIdColumn => columnCompId;

		[DebuggerNonUserCode]
		public DataColumn SysDateColumn => columnSysDate;

		[DebuggerNonUserCode]
		public DataColumn SysPwdColumn => columnSysPwd;

		[DebuggerNonUserCode]
		public DataColumn ERPPwdColumn => columnERPPwd;

		[DebuggerNonUserCode]
		public DataColumn EmailIdColumn => columnEmailId;

		[DebuggerNonUserCode]
		public DataColumn EmailPwdColumn => columnEmailPwd;

		[DebuggerNonUserCode]
		public DataColumn EmpIdColumn => columnEmpId;

		[DebuggerNonUserCode]
		public DataColumn EmployeeNameColumn => columnEmployeeName;

		[DebuggerNonUserCode]
		public DataColumn HODColumn => columnHOD;

		[DebuggerNonUserCode]
		public DataColumn DesignationColumn => columnDesignation;

		[DebuggerNonUserCode]
		public DataColumn DepartmentColumn => columnDepartment;

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
		public DataTable1Row AddDataTable1Row(int Id, int CompId, string SysDate, string SysPwd, string ERPPwd, string EmailId, string EmailPwd, string EmpId, string EmployeeName, string HOD, string Designation, string Department)
		{
			DataTable1Row dataTable1Row = (DataTable1Row)NewRow();
			object[] itemArray = new object[12]
			{
				Id, CompId, SysDate, SysPwd, ERPPwd, EmailId, EmailPwd, EmpId, EmployeeName, HOD,
				Designation, Department
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
			columnSysDate = base.Columns["SysDate"];
			columnSysPwd = base.Columns["SysPwd"];
			columnERPPwd = base.Columns["ERPPwd"];
			columnEmailId = base.Columns["EmailId"];
			columnEmailPwd = base.Columns["EmailPwd"];
			columnEmpId = base.Columns["EmpId"];
			columnEmployeeName = base.Columns["EmployeeName"];
			columnHOD = base.Columns["HOD"];
			columnDesignation = base.Columns["Designation"];
			columnDepartment = base.Columns["Department"];
		}

		[DebuggerNonUserCode]
		private void InitClass()
		{
			columnId = new DataColumn("Id", typeof(int), null, MappingType.Element);
			base.Columns.Add(columnId);
			columnCompId = new DataColumn("CompId", typeof(int), null, MappingType.Element);
			base.Columns.Add(columnCompId);
			columnSysDate = new DataColumn("SysDate", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnSysDate);
			columnSysPwd = new DataColumn("SysPwd", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnSysPwd);
			columnERPPwd = new DataColumn("ERPPwd", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnERPPwd);
			columnEmailId = new DataColumn("EmailId", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnEmailId);
			columnEmailPwd = new DataColumn("EmailPwd", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnEmailPwd);
			columnEmpId = new DataColumn("EmpId", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnEmpId);
			columnEmployeeName = new DataColumn("EmployeeName", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnEmployeeName);
			columnHOD = new DataColumn("HOD", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnHOD);
			columnDesignation = new DataColumn("Designation", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnDesignation);
			columnDepartment = new DataColumn("Department", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnDepartment);
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
			AuthorityAuthorization authorityAuthorization = new AuthorityAuthorization();
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
			xmlSchemaAttribute.FixedValue = authorityAuthorization.Namespace;
			xmlSchemaComplexType.Attributes.Add(xmlSchemaAttribute);
			XmlSchemaAttribute xmlSchemaAttribute2 = new XmlSchemaAttribute();
			xmlSchemaAttribute2.Name = "tableTypeName";
			xmlSchemaAttribute2.FixedValue = "DataTable1DataTable";
			xmlSchemaComplexType.Attributes.Add(xmlSchemaAttribute2);
			xmlSchemaComplexType.Particle = xmlSchemaSequence;
			XmlSchema schemaSerializable = authorityAuthorization.GetSchemaSerializable();
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
		public string SysDate
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.SysDateColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'SysDate' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.SysDateColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string SysPwd
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.SysPwdColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'SysPwd' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.SysPwdColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string ERPPwd
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.ERPPwdColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'ERPPwd' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.ERPPwdColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string EmailId
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.EmailIdColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'EmailId' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.EmailIdColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string EmailPwd
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.EmailPwdColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'EmailPwd' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.EmailPwdColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string EmpId
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.EmpIdColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'EmpId' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.EmpIdColumn] = value;
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
		public string HOD
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.HODColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'HOD' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.HODColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string Designation
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.DesignationColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Designation' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.DesignationColumn] = value;
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
		public bool IsSysDateNull()
		{
			return IsNull(tableDataTable1.SysDateColumn);
		}

		[DebuggerNonUserCode]
		public void SetSysDateNull()
		{
			base[tableDataTable1.SysDateColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsSysPwdNull()
		{
			return IsNull(tableDataTable1.SysPwdColumn);
		}

		[DebuggerNonUserCode]
		public void SetSysPwdNull()
		{
			base[tableDataTable1.SysPwdColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsERPPwdNull()
		{
			return IsNull(tableDataTable1.ERPPwdColumn);
		}

		[DebuggerNonUserCode]
		public void SetERPPwdNull()
		{
			base[tableDataTable1.ERPPwdColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsEmailIdNull()
		{
			return IsNull(tableDataTable1.EmailIdColumn);
		}

		[DebuggerNonUserCode]
		public void SetEmailIdNull()
		{
			base[tableDataTable1.EmailIdColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsEmailPwdNull()
		{
			return IsNull(tableDataTable1.EmailPwdColumn);
		}

		[DebuggerNonUserCode]
		public void SetEmailPwdNull()
		{
			base[tableDataTable1.EmailPwdColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsEmpIdNull()
		{
			return IsNull(tableDataTable1.EmpIdColumn);
		}

		[DebuggerNonUserCode]
		public void SetEmpIdNull()
		{
			base[tableDataTable1.EmpIdColumn] = Convert.DBNull;
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
		public bool IsHODNull()
		{
			return IsNull(tableDataTable1.HODColumn);
		}

		[DebuggerNonUserCode]
		public void SetHODNull()
		{
			base[tableDataTable1.HODColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsDesignationNull()
		{
			return IsNull(tableDataTable1.DesignationColumn);
		}

		[DebuggerNonUserCode]
		public void SetDesignationNull()
		{
			base[tableDataTable1.DesignationColumn] = Convert.DBNull;
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

	[DebuggerNonUserCode]
	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public DataTable1DataTable DataTable1 => tableDataTable1;

	[Browsable(true)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
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
	public AuthorityAuthorization()
	{
		BeginInit();
		InitClass();
		CollectionChangeEventHandler value = SchemaChanged;
		base.Tables.CollectionChanged += value;
		base.Relations.CollectionChanged += value;
		EndInit();
	}

	[DebuggerNonUserCode]
	protected AuthorityAuthorization(SerializationInfo info, StreamingContext context)
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
		AuthorityAuthorization authorityAuthorization = (AuthorityAuthorization)base.Clone();
		authorityAuthorization.InitVars();
		authorityAuthorization.SchemaSerializationMode = SchemaSerializationMode;
		return authorityAuthorization;
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
		base.DataSetName = "AuthorityAuthorization";
		base.Prefix = "";
		base.Namespace = "http://tempuri.org/AuthorityAuthorization.xsd";
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
		AuthorityAuthorization authorityAuthorization = new AuthorityAuthorization();
		XmlSchemaComplexType xmlSchemaComplexType = new XmlSchemaComplexType();
		XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
		XmlSchemaAny xmlSchemaAny = new XmlSchemaAny();
		xmlSchemaAny.Namespace = authorityAuthorization.Namespace;
		xmlSchemaSequence.Items.Add(xmlSchemaAny);
		xmlSchemaComplexType.Particle = xmlSchemaSequence;
		XmlSchema schemaSerializable = authorityAuthorization.GetSchemaSerializable();
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
