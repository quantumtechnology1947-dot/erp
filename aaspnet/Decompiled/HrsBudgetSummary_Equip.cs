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
[XmlRoot("HrsBudgetSummary_Equip")]
[DesignerCategory("code")]
[ToolboxItem(true)]
[XmlSchemaProvider("GetTypedDataSetSchema")]
[HelpKeyword("vs.data.DataSet")]
[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
public class HrsBudgetSummary_Equip : DataSet
{
	public delegate void DataTable1RowChangeEventHandler(object sender, DataTable1RowChangeEvent e);

	[Serializable]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
	[XmlSchemaProvider("GetTypedTableSchema")]
	public class DataTable1DataTable : TypedTableBase<DataTable1Row>
	{
		private DataColumn columnCompId;

		private DataColumn columnWoNo;

		private DataColumn columnProjectTitle;

		private DataColumn columnEquipNo;

		private DataColumn columnDescription;

		private DataColumn columnMDBHrs;

		private DataColumn columnMDUHrs;

		private DataColumn columnMABHrs;

		private DataColumn columnMAUHrs;

		private DataColumn columnMCBHrs;

		private DataColumn columnMCUHrs;

		private DataColumn columnMTBHrs;

		private DataColumn columnMTUHrs;

		private DataColumn columnMIBHrs;

		private DataColumn columnMIUHrs;

		private DataColumn columnMTRBHrs;

		private DataColumn columnMTRUHrs;

		private DataColumn columnEDBHrs;

		private DataColumn columnEDUHrs;

		private DataColumn columnEABHrs;

		private DataColumn columnEAUHrs;

		private DataColumn columnECBHrs;

		private DataColumn columnECUHrs;

		private DataColumn columnETBHrs;

		private DataColumn columnETUHrs;

		private DataColumn columnEIBHrs;

		private DataColumn columnEIUHrs;

		private DataColumn columnETRBHrs;

		private DataColumn columnETRUHrs;

		private DataColumn columnMDIBHrs;

		private DataColumn columnMDIUHrs;

		private DataColumn columnEDIBHrs;

		private DataColumn columnEDIUHrs;

		[DebuggerNonUserCode]
		public DataColumn CompIdColumn => columnCompId;

		[DebuggerNonUserCode]
		public DataColumn WoNoColumn => columnWoNo;

		[DebuggerNonUserCode]
		public DataColumn ProjectTitleColumn => columnProjectTitle;

		[DebuggerNonUserCode]
		public DataColumn EquipNoColumn => columnEquipNo;

		[DebuggerNonUserCode]
		public DataColumn DescriptionColumn => columnDescription;

		[DebuggerNonUserCode]
		public DataColumn MDBHrsColumn => columnMDBHrs;

		[DebuggerNonUserCode]
		public DataColumn MDUHrsColumn => columnMDUHrs;

		[DebuggerNonUserCode]
		public DataColumn MABHrsColumn => columnMABHrs;

		[DebuggerNonUserCode]
		public DataColumn MAUHrsColumn => columnMAUHrs;

		[DebuggerNonUserCode]
		public DataColumn MCBHrsColumn => columnMCBHrs;

		[DebuggerNonUserCode]
		public DataColumn MCUHrsColumn => columnMCUHrs;

		[DebuggerNonUserCode]
		public DataColumn MTBHrsColumn => columnMTBHrs;

		[DebuggerNonUserCode]
		public DataColumn MTUHrsColumn => columnMTUHrs;

		[DebuggerNonUserCode]
		public DataColumn MIBHrsColumn => columnMIBHrs;

		[DebuggerNonUserCode]
		public DataColumn MIUHrsColumn => columnMIUHrs;

		[DebuggerNonUserCode]
		public DataColumn MTRBHrsColumn => columnMTRBHrs;

		[DebuggerNonUserCode]
		public DataColumn MTRUHrsColumn => columnMTRUHrs;

		[DebuggerNonUserCode]
		public DataColumn EDBHrsColumn => columnEDBHrs;

		[DebuggerNonUserCode]
		public DataColumn EDUHrsColumn => columnEDUHrs;

		[DebuggerNonUserCode]
		public DataColumn EABHrsColumn => columnEABHrs;

		[DebuggerNonUserCode]
		public DataColumn EAUHrsColumn => columnEAUHrs;

		[DebuggerNonUserCode]
		public DataColumn ECBHrsColumn => columnECBHrs;

		[DebuggerNonUserCode]
		public DataColumn ECUHrsColumn => columnECUHrs;

		[DebuggerNonUserCode]
		public DataColumn ETBHrsColumn => columnETBHrs;

		[DebuggerNonUserCode]
		public DataColumn ETUHrsColumn => columnETUHrs;

		[DebuggerNonUserCode]
		public DataColumn EIBHrsColumn => columnEIBHrs;

		[DebuggerNonUserCode]
		public DataColumn EIUHrsColumn => columnEIUHrs;

		[DebuggerNonUserCode]
		public DataColumn ETRBHrsColumn => columnETRBHrs;

		[DebuggerNonUserCode]
		public DataColumn ETRUHrsColumn => columnETRUHrs;

		[DebuggerNonUserCode]
		public DataColumn MDIBHrsColumn => columnMDIBHrs;

		[DebuggerNonUserCode]
		public DataColumn MDIUHrsColumn => columnMDIUHrs;

		[DebuggerNonUserCode]
		public DataColumn EDIBHrsColumn => columnEDIBHrs;

		[DebuggerNonUserCode]
		public DataColumn EDIUHrsColumn => columnEDIUHrs;

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
		public DataTable1Row AddDataTable1Row(int CompId, string WoNo, string ProjectTitle, string EquipNo, string Description, double MDBHrs, double MDUHrs, double MABHrs, double MAUHrs, double MCBHrs, double MCUHrs, double MTBHrs, double MTUHrs, double MIBHrs, double MIUHrs, double MTRBHrs, double MTRUHrs, double EDBHrs, double EDUHrs, double EABHrs, double EAUHrs, double ECBHrs, double ECUHrs, double ETBHrs, double ETUHrs, double EIBHrs, double EIUHrs, double ETRBHrs, double ETRUHrs, double MDIBHrs, double MDIUHrs, double EDIBHrs, double EDIUHrs)
		{
			DataTable1Row dataTable1Row = (DataTable1Row)NewRow();
			object[] itemArray = new object[33]
			{
				CompId, WoNo, ProjectTitle, EquipNo, Description, MDBHrs, MDUHrs, MABHrs, MAUHrs, MCBHrs,
				MCUHrs, MTBHrs, MTUHrs, MIBHrs, MIUHrs, MTRBHrs, MTRUHrs, EDBHrs, EDUHrs, EABHrs,
				EAUHrs, ECBHrs, ECUHrs, ETBHrs, ETUHrs, EIBHrs, EIUHrs, ETRBHrs, ETRUHrs, MDIBHrs,
				MDIUHrs, EDIBHrs, EDIUHrs
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
			columnCompId = base.Columns["CompId"];
			columnWoNo = base.Columns["WoNo"];
			columnProjectTitle = base.Columns["ProjectTitle"];
			columnEquipNo = base.Columns["EquipNo"];
			columnDescription = base.Columns["Description"];
			columnMDBHrs = base.Columns["MDBHrs"];
			columnMDUHrs = base.Columns["MDUHrs"];
			columnMABHrs = base.Columns["MABHrs"];
			columnMAUHrs = base.Columns["MAUHrs"];
			columnMCBHrs = base.Columns["MCBHrs"];
			columnMCUHrs = base.Columns["MCUHrs"];
			columnMTBHrs = base.Columns["MTBHrs"];
			columnMTUHrs = base.Columns["MTUHrs"];
			columnMIBHrs = base.Columns["MIBHrs"];
			columnMIUHrs = base.Columns["MIUHrs"];
			columnMTRBHrs = base.Columns["MTRBHrs"];
			columnMTRUHrs = base.Columns["MTRUHrs"];
			columnEDBHrs = base.Columns["EDBHrs"];
			columnEDUHrs = base.Columns["EDUHrs"];
			columnEABHrs = base.Columns["EABHrs"];
			columnEAUHrs = base.Columns["EAUHrs"];
			columnECBHrs = base.Columns["ECBHrs"];
			columnECUHrs = base.Columns["ECUHrs"];
			columnETBHrs = base.Columns["ETBHrs"];
			columnETUHrs = base.Columns["ETUHrs"];
			columnEIBHrs = base.Columns["EIBHrs"];
			columnEIUHrs = base.Columns["EIUHrs"];
			columnETRBHrs = base.Columns["ETRBHrs"];
			columnETRUHrs = base.Columns["ETRUHrs"];
			columnMDIBHrs = base.Columns["MDIBHrs"];
			columnMDIUHrs = base.Columns["MDIUHrs"];
			columnEDIBHrs = base.Columns["EDIBHrs"];
			columnEDIUHrs = base.Columns["EDIUHrs"];
		}

		[DebuggerNonUserCode]
		private void InitClass()
		{
			columnCompId = new DataColumn("CompId", typeof(int), null, MappingType.Element);
			base.Columns.Add(columnCompId);
			columnWoNo = new DataColumn("WoNo", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnWoNo);
			columnProjectTitle = new DataColumn("ProjectTitle", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnProjectTitle);
			columnEquipNo = new DataColumn("EquipNo", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnEquipNo);
			columnDescription = new DataColumn("Description", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnDescription);
			columnMDBHrs = new DataColumn("MDBHrs", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnMDBHrs);
			columnMDUHrs = new DataColumn("MDUHrs", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnMDUHrs);
			columnMABHrs = new DataColumn("MABHrs", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnMABHrs);
			columnMAUHrs = new DataColumn("MAUHrs", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnMAUHrs);
			columnMCBHrs = new DataColumn("MCBHrs", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnMCBHrs);
			columnMCUHrs = new DataColumn("MCUHrs", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnMCUHrs);
			columnMTBHrs = new DataColumn("MTBHrs", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnMTBHrs);
			columnMTUHrs = new DataColumn("MTUHrs", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnMTUHrs);
			columnMIBHrs = new DataColumn("MIBHrs", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnMIBHrs);
			columnMIUHrs = new DataColumn("MIUHrs", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnMIUHrs);
			columnMTRBHrs = new DataColumn("MTRBHrs", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnMTRBHrs);
			columnMTRUHrs = new DataColumn("MTRUHrs", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnMTRUHrs);
			columnEDBHrs = new DataColumn("EDBHrs", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnEDBHrs);
			columnEDUHrs = new DataColumn("EDUHrs", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnEDUHrs);
			columnEABHrs = new DataColumn("EABHrs", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnEABHrs);
			columnEAUHrs = new DataColumn("EAUHrs", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnEAUHrs);
			columnECBHrs = new DataColumn("ECBHrs", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnECBHrs);
			columnECUHrs = new DataColumn("ECUHrs", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnECUHrs);
			columnETBHrs = new DataColumn("ETBHrs", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnETBHrs);
			columnETUHrs = new DataColumn("ETUHrs", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnETUHrs);
			columnEIBHrs = new DataColumn("EIBHrs", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnEIBHrs);
			columnEIUHrs = new DataColumn("EIUHrs", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnEIUHrs);
			columnETRBHrs = new DataColumn("ETRBHrs", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnETRBHrs);
			columnETRUHrs = new DataColumn("ETRUHrs", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnETRUHrs);
			columnMDIBHrs = new DataColumn("MDIBHrs", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnMDIBHrs);
			columnMDIUHrs = new DataColumn("MDIUHrs", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnMDIUHrs);
			columnEDIBHrs = new DataColumn("EDIBHrs", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnEDIBHrs);
			columnEDIUHrs = new DataColumn("EDIUHrs", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnEDIUHrs);
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
			HrsBudgetSummary_Equip hrsBudgetSummary_Equip = new HrsBudgetSummary_Equip();
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
			xmlSchemaAttribute.FixedValue = hrsBudgetSummary_Equip.Namespace;
			xmlSchemaComplexType.Attributes.Add(xmlSchemaAttribute);
			XmlSchemaAttribute xmlSchemaAttribute2 = new XmlSchemaAttribute();
			xmlSchemaAttribute2.Name = "tableTypeName";
			xmlSchemaAttribute2.FixedValue = "DataTable1DataTable";
			xmlSchemaComplexType.Attributes.Add(xmlSchemaAttribute2);
			xmlSchemaComplexType.Particle = xmlSchemaSequence;
			XmlSchema schemaSerializable = hrsBudgetSummary_Equip.GetSchemaSerializable();
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
		public string WoNo
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.WoNoColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'WoNo' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.WoNoColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string ProjectTitle
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.ProjectTitleColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'ProjectTitle' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.ProjectTitleColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string EquipNo
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.EquipNoColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'EquipNo' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.EquipNoColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string Description
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.DescriptionColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Description' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.DescriptionColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public double MDBHrs
		{
			get
			{
				try
				{
					return (double)base[tableDataTable1.MDBHrsColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'MDBHrs' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.MDBHrsColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public double MDUHrs
		{
			get
			{
				try
				{
					return (double)base[tableDataTable1.MDUHrsColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'MDUHrs' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.MDUHrsColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public double MABHrs
		{
			get
			{
				try
				{
					return (double)base[tableDataTable1.MABHrsColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'MABHrs' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.MABHrsColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public double MAUHrs
		{
			get
			{
				try
				{
					return (double)base[tableDataTable1.MAUHrsColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'MAUHrs' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.MAUHrsColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public double MCBHrs
		{
			get
			{
				try
				{
					return (double)base[tableDataTable1.MCBHrsColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'MCBHrs' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.MCBHrsColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public double MCUHrs
		{
			get
			{
				try
				{
					return (double)base[tableDataTable1.MCUHrsColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'MCUHrs' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.MCUHrsColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public double MTBHrs
		{
			get
			{
				try
				{
					return (double)base[tableDataTable1.MTBHrsColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'MTBHrs' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.MTBHrsColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public double MTUHrs
		{
			get
			{
				try
				{
					return (double)base[tableDataTable1.MTUHrsColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'MTUHrs' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.MTUHrsColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public double MIBHrs
		{
			get
			{
				try
				{
					return (double)base[tableDataTable1.MIBHrsColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'MIBHrs' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.MIBHrsColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public double MIUHrs
		{
			get
			{
				try
				{
					return (double)base[tableDataTable1.MIUHrsColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'MIUHrs' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.MIUHrsColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public double MTRBHrs
		{
			get
			{
				try
				{
					return (double)base[tableDataTable1.MTRBHrsColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'MTRBHrs' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.MTRBHrsColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public double MTRUHrs
		{
			get
			{
				try
				{
					return (double)base[tableDataTable1.MTRUHrsColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'MTRUHrs' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.MTRUHrsColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public double EDBHrs
		{
			get
			{
				try
				{
					return (double)base[tableDataTable1.EDBHrsColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'EDBHrs' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.EDBHrsColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public double EDUHrs
		{
			get
			{
				try
				{
					return (double)base[tableDataTable1.EDUHrsColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'EDUHrs' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.EDUHrsColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public double EABHrs
		{
			get
			{
				try
				{
					return (double)base[tableDataTable1.EABHrsColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'EABHrs' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.EABHrsColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public double EAUHrs
		{
			get
			{
				try
				{
					return (double)base[tableDataTable1.EAUHrsColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'EAUHrs' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.EAUHrsColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public double ECBHrs
		{
			get
			{
				try
				{
					return (double)base[tableDataTable1.ECBHrsColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'ECBHrs' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.ECBHrsColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public double ECUHrs
		{
			get
			{
				try
				{
					return (double)base[tableDataTable1.ECUHrsColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'ECUHrs' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.ECUHrsColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public double ETBHrs
		{
			get
			{
				try
				{
					return (double)base[tableDataTable1.ETBHrsColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'ETBHrs' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.ETBHrsColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public double ETUHrs
		{
			get
			{
				try
				{
					return (double)base[tableDataTable1.ETUHrsColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'ETUHrs' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.ETUHrsColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public double EIBHrs
		{
			get
			{
				try
				{
					return (double)base[tableDataTable1.EIBHrsColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'EIBHrs' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.EIBHrsColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public double EIUHrs
		{
			get
			{
				try
				{
					return (double)base[tableDataTable1.EIUHrsColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'EIUHrs' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.EIUHrsColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public double ETRBHrs
		{
			get
			{
				try
				{
					return (double)base[tableDataTable1.ETRBHrsColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'ETRBHrs' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.ETRBHrsColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public double ETRUHrs
		{
			get
			{
				try
				{
					return (double)base[tableDataTable1.ETRUHrsColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'ETRUHrs' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.ETRUHrsColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public double MDIBHrs
		{
			get
			{
				try
				{
					return (double)base[tableDataTable1.MDIBHrsColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'MDIBHrs' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.MDIBHrsColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public double MDIUHrs
		{
			get
			{
				try
				{
					return (double)base[tableDataTable1.MDIUHrsColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'MDIUHrs' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.MDIUHrsColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public double EDIBHrs
		{
			get
			{
				try
				{
					return (double)base[tableDataTable1.EDIBHrsColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'EDIBHrs' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.EDIBHrsColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public double EDIUHrs
		{
			get
			{
				try
				{
					return (double)base[tableDataTable1.EDIUHrsColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'EDIUHrs' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.EDIUHrsColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		internal DataTable1Row(DataRowBuilder rb)
			: base(rb)
		{
			tableDataTable1 = (DataTable1DataTable)base.Table;
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
		public bool IsWoNoNull()
		{
			return IsNull(tableDataTable1.WoNoColumn);
		}

		[DebuggerNonUserCode]
		public void SetWoNoNull()
		{
			base[tableDataTable1.WoNoColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsProjectTitleNull()
		{
			return IsNull(tableDataTable1.ProjectTitleColumn);
		}

		[DebuggerNonUserCode]
		public void SetProjectTitleNull()
		{
			base[tableDataTable1.ProjectTitleColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsEquipNoNull()
		{
			return IsNull(tableDataTable1.EquipNoColumn);
		}

		[DebuggerNonUserCode]
		public void SetEquipNoNull()
		{
			base[tableDataTable1.EquipNoColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsDescriptionNull()
		{
			return IsNull(tableDataTable1.DescriptionColumn);
		}

		[DebuggerNonUserCode]
		public void SetDescriptionNull()
		{
			base[tableDataTable1.DescriptionColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsMDBHrsNull()
		{
			return IsNull(tableDataTable1.MDBHrsColumn);
		}

		[DebuggerNonUserCode]
		public void SetMDBHrsNull()
		{
			base[tableDataTable1.MDBHrsColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsMDUHrsNull()
		{
			return IsNull(tableDataTable1.MDUHrsColumn);
		}

		[DebuggerNonUserCode]
		public void SetMDUHrsNull()
		{
			base[tableDataTable1.MDUHrsColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsMABHrsNull()
		{
			return IsNull(tableDataTable1.MABHrsColumn);
		}

		[DebuggerNonUserCode]
		public void SetMABHrsNull()
		{
			base[tableDataTable1.MABHrsColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsMAUHrsNull()
		{
			return IsNull(tableDataTable1.MAUHrsColumn);
		}

		[DebuggerNonUserCode]
		public void SetMAUHrsNull()
		{
			base[tableDataTable1.MAUHrsColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsMCBHrsNull()
		{
			return IsNull(tableDataTable1.MCBHrsColumn);
		}

		[DebuggerNonUserCode]
		public void SetMCBHrsNull()
		{
			base[tableDataTable1.MCBHrsColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsMCUHrsNull()
		{
			return IsNull(tableDataTable1.MCUHrsColumn);
		}

		[DebuggerNonUserCode]
		public void SetMCUHrsNull()
		{
			base[tableDataTable1.MCUHrsColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsMTBHrsNull()
		{
			return IsNull(tableDataTable1.MTBHrsColumn);
		}

		[DebuggerNonUserCode]
		public void SetMTBHrsNull()
		{
			base[tableDataTable1.MTBHrsColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsMTUHrsNull()
		{
			return IsNull(tableDataTable1.MTUHrsColumn);
		}

		[DebuggerNonUserCode]
		public void SetMTUHrsNull()
		{
			base[tableDataTable1.MTUHrsColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsMIBHrsNull()
		{
			return IsNull(tableDataTable1.MIBHrsColumn);
		}

		[DebuggerNonUserCode]
		public void SetMIBHrsNull()
		{
			base[tableDataTable1.MIBHrsColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsMIUHrsNull()
		{
			return IsNull(tableDataTable1.MIUHrsColumn);
		}

		[DebuggerNonUserCode]
		public void SetMIUHrsNull()
		{
			base[tableDataTable1.MIUHrsColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsMTRBHrsNull()
		{
			return IsNull(tableDataTable1.MTRBHrsColumn);
		}

		[DebuggerNonUserCode]
		public void SetMTRBHrsNull()
		{
			base[tableDataTable1.MTRBHrsColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsMTRUHrsNull()
		{
			return IsNull(tableDataTable1.MTRUHrsColumn);
		}

		[DebuggerNonUserCode]
		public void SetMTRUHrsNull()
		{
			base[tableDataTable1.MTRUHrsColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsEDBHrsNull()
		{
			return IsNull(tableDataTable1.EDBHrsColumn);
		}

		[DebuggerNonUserCode]
		public void SetEDBHrsNull()
		{
			base[tableDataTable1.EDBHrsColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsEDUHrsNull()
		{
			return IsNull(tableDataTable1.EDUHrsColumn);
		}

		[DebuggerNonUserCode]
		public void SetEDUHrsNull()
		{
			base[tableDataTable1.EDUHrsColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsEABHrsNull()
		{
			return IsNull(tableDataTable1.EABHrsColumn);
		}

		[DebuggerNonUserCode]
		public void SetEABHrsNull()
		{
			base[tableDataTable1.EABHrsColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsEAUHrsNull()
		{
			return IsNull(tableDataTable1.EAUHrsColumn);
		}

		[DebuggerNonUserCode]
		public void SetEAUHrsNull()
		{
			base[tableDataTable1.EAUHrsColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsECBHrsNull()
		{
			return IsNull(tableDataTable1.ECBHrsColumn);
		}

		[DebuggerNonUserCode]
		public void SetECBHrsNull()
		{
			base[tableDataTable1.ECBHrsColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsECUHrsNull()
		{
			return IsNull(tableDataTable1.ECUHrsColumn);
		}

		[DebuggerNonUserCode]
		public void SetECUHrsNull()
		{
			base[tableDataTable1.ECUHrsColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsETBHrsNull()
		{
			return IsNull(tableDataTable1.ETBHrsColumn);
		}

		[DebuggerNonUserCode]
		public void SetETBHrsNull()
		{
			base[tableDataTable1.ETBHrsColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsETUHrsNull()
		{
			return IsNull(tableDataTable1.ETUHrsColumn);
		}

		[DebuggerNonUserCode]
		public void SetETUHrsNull()
		{
			base[tableDataTable1.ETUHrsColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsEIBHrsNull()
		{
			return IsNull(tableDataTable1.EIBHrsColumn);
		}

		[DebuggerNonUserCode]
		public void SetEIBHrsNull()
		{
			base[tableDataTable1.EIBHrsColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsEIUHrsNull()
		{
			return IsNull(tableDataTable1.EIUHrsColumn);
		}

		[DebuggerNonUserCode]
		public void SetEIUHrsNull()
		{
			base[tableDataTable1.EIUHrsColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsETRBHrsNull()
		{
			return IsNull(tableDataTable1.ETRBHrsColumn);
		}

		[DebuggerNonUserCode]
		public void SetETRBHrsNull()
		{
			base[tableDataTable1.ETRBHrsColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsETRUHrsNull()
		{
			return IsNull(tableDataTable1.ETRUHrsColumn);
		}

		[DebuggerNonUserCode]
		public void SetETRUHrsNull()
		{
			base[tableDataTable1.ETRUHrsColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsMDIBHrsNull()
		{
			return IsNull(tableDataTable1.MDIBHrsColumn);
		}

		[DebuggerNonUserCode]
		public void SetMDIBHrsNull()
		{
			base[tableDataTable1.MDIBHrsColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsMDIUHrsNull()
		{
			return IsNull(tableDataTable1.MDIUHrsColumn);
		}

		[DebuggerNonUserCode]
		public void SetMDIUHrsNull()
		{
			base[tableDataTable1.MDIUHrsColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsEDIBHrsNull()
		{
			return IsNull(tableDataTable1.EDIBHrsColumn);
		}

		[DebuggerNonUserCode]
		public void SetEDIBHrsNull()
		{
			base[tableDataTable1.EDIBHrsColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsEDIUHrsNull()
		{
			return IsNull(tableDataTable1.EDIUHrsColumn);
		}

		[DebuggerNonUserCode]
		public void SetEDIUHrsNull()
		{
			base[tableDataTable1.EDIUHrsColumn] = Convert.DBNull;
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

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
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

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[DebuggerNonUserCode]
	public new DataRelationCollection Relations => base.Relations;

	[DebuggerNonUserCode]
	public HrsBudgetSummary_Equip()
	{
		BeginInit();
		InitClass();
		CollectionChangeEventHandler value = SchemaChanged;
		base.Tables.CollectionChanged += value;
		base.Relations.CollectionChanged += value;
		EndInit();
	}

	[DebuggerNonUserCode]
	protected HrsBudgetSummary_Equip(SerializationInfo info, StreamingContext context)
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
		HrsBudgetSummary_Equip hrsBudgetSummary_Equip = (HrsBudgetSummary_Equip)base.Clone();
		hrsBudgetSummary_Equip.InitVars();
		hrsBudgetSummary_Equip.SchemaSerializationMode = SchemaSerializationMode;
		return hrsBudgetSummary_Equip;
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
		base.DataSetName = "HrsBudgetSummary_Equip";
		base.Prefix = "";
		base.Namespace = "http://tempuri.org/HrsBudgetSummary_Equip.xsd";
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
		HrsBudgetSummary_Equip hrsBudgetSummary_Equip = new HrsBudgetSummary_Equip();
		XmlSchemaComplexType xmlSchemaComplexType = new XmlSchemaComplexType();
		XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
		XmlSchemaAny xmlSchemaAny = new XmlSchemaAny();
		xmlSchemaAny.Namespace = hrsBudgetSummary_Equip.Namespace;
		xmlSchemaSequence.Items.Add(xmlSchemaAny);
		xmlSchemaComplexType.Particle = xmlSchemaSequence;
		XmlSchema schemaSerializable = hrsBudgetSummary_Equip.GetSchemaSerializable();
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
