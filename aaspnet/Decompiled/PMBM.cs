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
[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
[ToolboxItem(true)]
[HelpKeyword("vs.data.DataSet")]
[DesignerCategory("code")]
[XmlSchemaProvider("GetTypedDataSetSchema")]
[XmlRoot("PMBM")]
public class PMBM : DataSet
{
	public delegate void DataTable1RowChangeEventHandler(object sender, DataTable1RowChangeEvent e);

	[Serializable]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
	[XmlSchemaProvider("GetTypedTableSchema")]
	public class DataTable1DataTable : TypedTableBase<DataTable1Row>
	{
		private DataColumn columnId;

		private DataColumn columnSysDate;

		private DataColumn columnCompId;

		private DataColumn columnMachineId;

		private DataColumn columnPMBM;

		private DataColumn columnFromDate;

		private DataColumn columnToDate;

		private DataColumn columnFromTime;

		private DataColumn columnToTime;

		private DataColumn columnNameOfAgency;

		private DataColumn columnNameOfEngineer;

		private DataColumn columnNextPMDueOn;

		private DataColumn columnRemarks;

		private DataColumn columnModel;

		private DataColumn columnMake;

		private DataColumn columnCapacity;

		private DataColumn columnLocation;

		private DataColumn columnMachineCode;

		private DataColumn columnUOMBasic;

		private DataColumn columnName;

		[DebuggerNonUserCode]
		public DataColumn IdColumn => columnId;

		[DebuggerNonUserCode]
		public DataColumn SysDateColumn => columnSysDate;

		[DebuggerNonUserCode]
		public DataColumn CompIdColumn => columnCompId;

		[DebuggerNonUserCode]
		public DataColumn MachineIdColumn => columnMachineId;

		[DebuggerNonUserCode]
		public DataColumn PMBMColumn => columnPMBM;

		[DebuggerNonUserCode]
		public DataColumn FromDateColumn => columnFromDate;

		[DebuggerNonUserCode]
		public DataColumn ToDateColumn => columnToDate;

		[DebuggerNonUserCode]
		public DataColumn FromTimeColumn => columnFromTime;

		[DebuggerNonUserCode]
		public DataColumn ToTimeColumn => columnToTime;

		[DebuggerNonUserCode]
		public DataColumn NameOfAgencyColumn => columnNameOfAgency;

		[DebuggerNonUserCode]
		public DataColumn NameOfEngineerColumn => columnNameOfEngineer;

		[DebuggerNonUserCode]
		public DataColumn NextPMDueOnColumn => columnNextPMDueOn;

		[DebuggerNonUserCode]
		public DataColumn RemarksColumn => columnRemarks;

		[DebuggerNonUserCode]
		public DataColumn ModelColumn => columnModel;

		[DebuggerNonUserCode]
		public DataColumn MakeColumn => columnMake;

		[DebuggerNonUserCode]
		public DataColumn CapacityColumn => columnCapacity;

		[DebuggerNonUserCode]
		public DataColumn LocationColumn => columnLocation;

		[DebuggerNonUserCode]
		public DataColumn MachineCodeColumn => columnMachineCode;

		[DebuggerNonUserCode]
		public DataColumn UOMBasicColumn => columnUOMBasic;

		[DebuggerNonUserCode]
		public DataColumn NameColumn => columnName;

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
		public DataTable1Row AddDataTable1Row(int Id, string SysDate, int CompId, int MachineId, string PMBM, string FromDate, string ToDate, string FromTime, string ToTime, string NameOfAgency, string NameOfEngineer, string NextPMDueOn, string Remarks, string Model, string Make, string Capacity, string Location, string MachineCode, string UOMBasic, string Name)
		{
			DataTable1Row dataTable1Row = (DataTable1Row)NewRow();
			object[] itemArray = new object[20]
			{
				Id, SysDate, CompId, MachineId, PMBM, FromDate, ToDate, FromTime, ToTime, NameOfAgency,
				NameOfEngineer, NextPMDueOn, Remarks, Model, Make, Capacity, Location, MachineCode, UOMBasic, Name
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
			columnSysDate = base.Columns["SysDate"];
			columnCompId = base.Columns["CompId"];
			columnMachineId = base.Columns["MachineId"];
			columnPMBM = base.Columns["PMBM"];
			columnFromDate = base.Columns["FromDate"];
			columnToDate = base.Columns["ToDate"];
			columnFromTime = base.Columns["FromTime"];
			columnToTime = base.Columns["ToTime"];
			columnNameOfAgency = base.Columns["NameOfAgency"];
			columnNameOfEngineer = base.Columns["NameOfEngineer"];
			columnNextPMDueOn = base.Columns["NextPMDueOn"];
			columnRemarks = base.Columns["Remarks"];
			columnModel = base.Columns["Model"];
			columnMake = base.Columns["Make"];
			columnCapacity = base.Columns["Capacity"];
			columnLocation = base.Columns["Location"];
			columnMachineCode = base.Columns["MachineCode"];
			columnUOMBasic = base.Columns["UOMBasic"];
			columnName = base.Columns["Name"];
		}

		[DebuggerNonUserCode]
		private void InitClass()
		{
			columnId = new DataColumn("Id", typeof(int), null, MappingType.Element);
			base.Columns.Add(columnId);
			columnSysDate = new DataColumn("SysDate", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnSysDate);
			columnCompId = new DataColumn("CompId", typeof(int), null, MappingType.Element);
			base.Columns.Add(columnCompId);
			columnMachineId = new DataColumn("MachineId", typeof(int), null, MappingType.Element);
			base.Columns.Add(columnMachineId);
			columnPMBM = new DataColumn("PMBM", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnPMBM);
			columnFromDate = new DataColumn("FromDate", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnFromDate);
			columnToDate = new DataColumn("ToDate", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnToDate);
			columnFromTime = new DataColumn("FromTime", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnFromTime);
			columnToTime = new DataColumn("ToTime", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnToTime);
			columnNameOfAgency = new DataColumn("NameOfAgency", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnNameOfAgency);
			columnNameOfEngineer = new DataColumn("NameOfEngineer", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnNameOfEngineer);
			columnNextPMDueOn = new DataColumn("NextPMDueOn", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnNextPMDueOn);
			columnRemarks = new DataColumn("Remarks", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnRemarks);
			columnModel = new DataColumn("Model", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnModel);
			columnMake = new DataColumn("Make", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnMake);
			columnCapacity = new DataColumn("Capacity", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnCapacity);
			columnLocation = new DataColumn("Location", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnLocation);
			columnMachineCode = new DataColumn("MachineCode", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnMachineCode);
			columnUOMBasic = new DataColumn("UOMBasic", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnUOMBasic);
			columnName = new DataColumn("Name", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnName);
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
			PMBM pMBM = new PMBM();
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
			xmlSchemaAttribute.FixedValue = pMBM.Namespace;
			xmlSchemaComplexType.Attributes.Add(xmlSchemaAttribute);
			XmlSchemaAttribute xmlSchemaAttribute2 = new XmlSchemaAttribute();
			xmlSchemaAttribute2.Name = "tableTypeName";
			xmlSchemaAttribute2.FixedValue = "DataTable1DataTable";
			xmlSchemaComplexType.Attributes.Add(xmlSchemaAttribute2);
			xmlSchemaComplexType.Particle = xmlSchemaSequence;
			XmlSchema schemaSerializable = pMBM.GetSchemaSerializable();
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
		public int MachineId
		{
			get
			{
				try
				{
					return (int)base[tableDataTable1.MachineIdColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'MachineId' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.MachineIdColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string PMBM
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.PMBMColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'PMBM' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.PMBMColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string FromDate
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.FromDateColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'FromDate' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.FromDateColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string ToDate
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.ToDateColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'ToDate' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.ToDateColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string FromTime
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.FromTimeColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'FromTime' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.FromTimeColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string ToTime
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.ToTimeColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'ToTime' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.ToTimeColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string NameOfAgency
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.NameOfAgencyColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'NameOfAgency' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.NameOfAgencyColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string NameOfEngineer
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.NameOfEngineerColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'NameOfEngineer' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.NameOfEngineerColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string NextPMDueOn
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.NextPMDueOnColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'NextPMDueOn' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.NextPMDueOnColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string Remarks
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.RemarksColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Remarks' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.RemarksColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string Model
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.ModelColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Model' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.ModelColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string Make
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.MakeColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Make' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.MakeColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string Capacity
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.CapacityColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Capacity' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.CapacityColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string Location
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.LocationColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Location' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.LocationColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string MachineCode
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.MachineCodeColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'MachineCode' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.MachineCodeColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string UOMBasic
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.UOMBasicColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'UOMBasic' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.UOMBasicColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string Name
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.NameColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Name' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.NameColumn] = value;
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
		public bool IsMachineIdNull()
		{
			return IsNull(tableDataTable1.MachineIdColumn);
		}

		[DebuggerNonUserCode]
		public void SetMachineIdNull()
		{
			base[tableDataTable1.MachineIdColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsPMBMNull()
		{
			return IsNull(tableDataTable1.PMBMColumn);
		}

		[DebuggerNonUserCode]
		public void SetPMBMNull()
		{
			base[tableDataTable1.PMBMColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsFromDateNull()
		{
			return IsNull(tableDataTable1.FromDateColumn);
		}

		[DebuggerNonUserCode]
		public void SetFromDateNull()
		{
			base[tableDataTable1.FromDateColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsToDateNull()
		{
			return IsNull(tableDataTable1.ToDateColumn);
		}

		[DebuggerNonUserCode]
		public void SetToDateNull()
		{
			base[tableDataTable1.ToDateColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsFromTimeNull()
		{
			return IsNull(tableDataTable1.FromTimeColumn);
		}

		[DebuggerNonUserCode]
		public void SetFromTimeNull()
		{
			base[tableDataTable1.FromTimeColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsToTimeNull()
		{
			return IsNull(tableDataTable1.ToTimeColumn);
		}

		[DebuggerNonUserCode]
		public void SetToTimeNull()
		{
			base[tableDataTable1.ToTimeColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsNameOfAgencyNull()
		{
			return IsNull(tableDataTable1.NameOfAgencyColumn);
		}

		[DebuggerNonUserCode]
		public void SetNameOfAgencyNull()
		{
			base[tableDataTable1.NameOfAgencyColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsNameOfEngineerNull()
		{
			return IsNull(tableDataTable1.NameOfEngineerColumn);
		}

		[DebuggerNonUserCode]
		public void SetNameOfEngineerNull()
		{
			base[tableDataTable1.NameOfEngineerColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsNextPMDueOnNull()
		{
			return IsNull(tableDataTable1.NextPMDueOnColumn);
		}

		[DebuggerNonUserCode]
		public void SetNextPMDueOnNull()
		{
			base[tableDataTable1.NextPMDueOnColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsRemarksNull()
		{
			return IsNull(tableDataTable1.RemarksColumn);
		}

		[DebuggerNonUserCode]
		public void SetRemarksNull()
		{
			base[tableDataTable1.RemarksColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsModelNull()
		{
			return IsNull(tableDataTable1.ModelColumn);
		}

		[DebuggerNonUserCode]
		public void SetModelNull()
		{
			base[tableDataTable1.ModelColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsMakeNull()
		{
			return IsNull(tableDataTable1.MakeColumn);
		}

		[DebuggerNonUserCode]
		public void SetMakeNull()
		{
			base[tableDataTable1.MakeColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsCapacityNull()
		{
			return IsNull(tableDataTable1.CapacityColumn);
		}

		[DebuggerNonUserCode]
		public void SetCapacityNull()
		{
			base[tableDataTable1.CapacityColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsLocationNull()
		{
			return IsNull(tableDataTable1.LocationColumn);
		}

		[DebuggerNonUserCode]
		public void SetLocationNull()
		{
			base[tableDataTable1.LocationColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsMachineCodeNull()
		{
			return IsNull(tableDataTable1.MachineCodeColumn);
		}

		[DebuggerNonUserCode]
		public void SetMachineCodeNull()
		{
			base[tableDataTable1.MachineCodeColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsUOMBasicNull()
		{
			return IsNull(tableDataTable1.UOMBasicColumn);
		}

		[DebuggerNonUserCode]
		public void SetUOMBasicNull()
		{
			base[tableDataTable1.UOMBasicColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsNameNull()
		{
			return IsNull(tableDataTable1.NameColumn);
		}

		[DebuggerNonUserCode]
		public void SetNameNull()
		{
			base[tableDataTable1.NameColumn] = Convert.DBNull;
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

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[DebuggerNonUserCode]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataRelationCollection Relations => base.Relations;

	[DebuggerNonUserCode]
	public PMBM()
	{
		BeginInit();
		InitClass();
		CollectionChangeEventHandler value = SchemaChanged;
		base.Tables.CollectionChanged += value;
		base.Relations.CollectionChanged += value;
		EndInit();
	}

	[DebuggerNonUserCode]
	protected PMBM(SerializationInfo info, StreamingContext context)
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
		PMBM pMBM = (PMBM)base.Clone();
		pMBM.InitVars();
		pMBM.SchemaSerializationMode = SchemaSerializationMode;
		return pMBM;
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
		base.DataSetName = "PMBM";
		base.Prefix = "";
		base.Namespace = "http://tempuri.org/PMBM.xsd";
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
		PMBM pMBM = new PMBM();
		XmlSchemaComplexType xmlSchemaComplexType = new XmlSchemaComplexType();
		XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
		XmlSchemaAny xmlSchemaAny = new XmlSchemaAny();
		xmlSchemaAny.Namespace = pMBM.Namespace;
		xmlSchemaSequence.Items.Add(xmlSchemaAny);
		xmlSchemaComplexType.Particle = xmlSchemaSequence;
		XmlSchema schemaSerializable = pMBM.GetSchemaSerializable();
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
