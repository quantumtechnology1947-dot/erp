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
[HelpKeyword("vs.data.DataSet")]
[ToolboxItem(true)]
[XmlRoot("ItemMaster")]
[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
[XmlSchemaProvider("GetTypedDataSetSchema")]
public class ItemMaster : DataSet
{
	public delegate void DataTable1RowChangeEventHandler(object sender, DataTable1RowChangeEvent e);

	[Serializable]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
	[XmlSchemaProvider("GetTypedTableSchema")]
	public class DataTable1DataTable : TypedTableBase<DataTable1Row>
	{
		private DataColumn columnItemCode;

		private DataColumn columnManfDesc;

		private DataColumn columnUOMBasic;

		private DataColumn columnId;

		private DataColumn columnMinOrderQty;

		private DataColumn columnMinStockQty;

		private DataColumn columnStockQty;

		private DataColumn columnLocation;

		private DataColumn columnAbsolute;

		private DataColumn columnCompId;

		private DataColumn columnBuyer;

		private DataColumn columnClass;

		private DataColumn columnSysDate;

		private DataColumn columnSysTime;

		private DataColumn columnFinyear;

		private DataColumn columnAHId;

		private DataColumn columnExcise;

		private DataColumn columnImportLocal;

		private DataColumn columnOpeningBalDate;

		private DataColumn columnInspectionDays;

		private DataColumn columnLeadDays;

		private DataColumn columnUOMconv;

		[DebuggerNonUserCode]
		public DataColumn ItemCodeColumn => columnItemCode;

		[DebuggerNonUserCode]
		public DataColumn ManfDescColumn => columnManfDesc;

		[DebuggerNonUserCode]
		public DataColumn UOMBasicColumn => columnUOMBasic;

		[DebuggerNonUserCode]
		public DataColumn IdColumn => columnId;

		[DebuggerNonUserCode]
		public DataColumn MinOrderQtyColumn => columnMinOrderQty;

		[DebuggerNonUserCode]
		public DataColumn MinStockQtyColumn => columnMinStockQty;

		[DebuggerNonUserCode]
		public DataColumn StockQtyColumn => columnStockQty;

		[DebuggerNonUserCode]
		public DataColumn LocationColumn => columnLocation;

		[DebuggerNonUserCode]
		public DataColumn AbsoluteColumn => columnAbsolute;

		[DebuggerNonUserCode]
		public DataColumn CompIdColumn => columnCompId;

		[DebuggerNonUserCode]
		public DataColumn BuyerColumn => columnBuyer;

		[DebuggerNonUserCode]
		public DataColumn ClassColumn => columnClass;

		[DebuggerNonUserCode]
		public DataColumn SysDateColumn => columnSysDate;

		[DebuggerNonUserCode]
		public DataColumn SysTimeColumn => columnSysTime;

		[DebuggerNonUserCode]
		public DataColumn FinyearColumn => columnFinyear;

		[DebuggerNonUserCode]
		public DataColumn AHIdColumn => columnAHId;

		[DebuggerNonUserCode]
		public DataColumn ExciseColumn => columnExcise;

		[DebuggerNonUserCode]
		public DataColumn ImportLocalColumn => columnImportLocal;

		[DebuggerNonUserCode]
		public DataColumn OpeningBalDateColumn => columnOpeningBalDate;

		[DebuggerNonUserCode]
		public DataColumn InspectionDaysColumn => columnInspectionDays;

		[DebuggerNonUserCode]
		public DataColumn LeadDaysColumn => columnLeadDays;

		[DebuggerNonUserCode]
		public DataColumn UOMconvColumn => columnUOMconv;

		[Browsable(false)]
		[DebuggerNonUserCode]
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
		public DataTable1Row AddDataTable1Row(string ItemCode, string ManfDesc, string UOMBasic, int Id, double MinOrderQty, double MinStockQty, double StockQty, string Location, string Absolute, int CompId, string Buyer, string Class, string SysDate, string SysTime, string Finyear, string AHId, string Excise, string ImportLocal, string OpeningBalDate, string InspectionDays, string LeadDays, string UOMconv)
		{
			DataTable1Row dataTable1Row = (DataTable1Row)NewRow();
			object[] itemArray = new object[22]
			{
				ItemCode, ManfDesc, UOMBasic, Id, MinOrderQty, MinStockQty, StockQty, Location, Absolute, CompId,
				Buyer, Class, SysDate, SysTime, Finyear, AHId, Excise, ImportLocal, OpeningBalDate, InspectionDays,
				LeadDays, UOMconv
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
			columnItemCode = base.Columns["ItemCode"];
			columnManfDesc = base.Columns["ManfDesc"];
			columnUOMBasic = base.Columns["UOMBasic"];
			columnId = base.Columns["Id"];
			columnMinOrderQty = base.Columns["MinOrderQty"];
			columnMinStockQty = base.Columns["MinStockQty"];
			columnStockQty = base.Columns["StockQty"];
			columnLocation = base.Columns["Location"];
			columnAbsolute = base.Columns["Absolute"];
			columnCompId = base.Columns["CompId"];
			columnBuyer = base.Columns["Buyer"];
			columnClass = base.Columns["Class"];
			columnSysDate = base.Columns["SysDate"];
			columnSysTime = base.Columns["SysTime"];
			columnFinyear = base.Columns["Finyear"];
			columnAHId = base.Columns["AHId"];
			columnExcise = base.Columns["Excise"];
			columnImportLocal = base.Columns["ImportLocal"];
			columnOpeningBalDate = base.Columns["OpeningBalDate"];
			columnInspectionDays = base.Columns["InspectionDays"];
			columnLeadDays = base.Columns["LeadDays"];
			columnUOMconv = base.Columns["UOMconv"];
		}

		[DebuggerNonUserCode]
		private void InitClass()
		{
			columnItemCode = new DataColumn("ItemCode", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnItemCode);
			columnManfDesc = new DataColumn("ManfDesc", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnManfDesc);
			columnUOMBasic = new DataColumn("UOMBasic", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnUOMBasic);
			columnId = new DataColumn("Id", typeof(int), null, MappingType.Element);
			base.Columns.Add(columnId);
			columnMinOrderQty = new DataColumn("MinOrderQty", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnMinOrderQty);
			columnMinStockQty = new DataColumn("MinStockQty", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnMinStockQty);
			columnStockQty = new DataColumn("StockQty", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnStockQty);
			columnLocation = new DataColumn("Location", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnLocation);
			columnAbsolute = new DataColumn("Absolute", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnAbsolute);
			columnCompId = new DataColumn("CompId", typeof(int), null, MappingType.Element);
			base.Columns.Add(columnCompId);
			columnBuyer = new DataColumn("Buyer", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnBuyer);
			columnClass = new DataColumn("Class", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnClass);
			columnSysDate = new DataColumn("SysDate", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnSysDate);
			columnSysTime = new DataColumn("SysTime", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnSysTime);
			columnFinyear = new DataColumn("Finyear", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnFinyear);
			columnAHId = new DataColumn("AHId", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnAHId);
			columnExcise = new DataColumn("Excise", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnExcise);
			columnImportLocal = new DataColumn("ImportLocal", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnImportLocal);
			columnOpeningBalDate = new DataColumn("OpeningBalDate", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnOpeningBalDate);
			columnInspectionDays = new DataColumn("InspectionDays", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnInspectionDays);
			columnLeadDays = new DataColumn("LeadDays", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnLeadDays);
			columnUOMconv = new DataColumn("UOMconv", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnUOMconv);
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
			ItemMaster itemMaster = new ItemMaster();
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
			xmlSchemaAttribute.FixedValue = itemMaster.Namespace;
			xmlSchemaComplexType.Attributes.Add(xmlSchemaAttribute);
			XmlSchemaAttribute xmlSchemaAttribute2 = new XmlSchemaAttribute();
			xmlSchemaAttribute2.Name = "tableTypeName";
			xmlSchemaAttribute2.FixedValue = "DataTable1DataTable";
			xmlSchemaComplexType.Attributes.Add(xmlSchemaAttribute2);
			xmlSchemaComplexType.Particle = xmlSchemaSequence;
			XmlSchema schemaSerializable = itemMaster.GetSchemaSerializable();
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
		public string ItemCode
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.ItemCodeColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'ItemCode' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.ItemCodeColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string ManfDesc
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.ManfDescColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'ManfDesc' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.ManfDescColumn] = value;
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
		public double MinOrderQty
		{
			get
			{
				try
				{
					return (double)base[tableDataTable1.MinOrderQtyColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'MinOrderQty' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.MinOrderQtyColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public double MinStockQty
		{
			get
			{
				try
				{
					return (double)base[tableDataTable1.MinStockQtyColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'MinStockQty' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.MinStockQtyColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public double StockQty
		{
			get
			{
				try
				{
					return (double)base[tableDataTable1.StockQtyColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'StockQty' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.StockQtyColumn] = value;
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
		public string Absolute
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.AbsoluteColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Absolute' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.AbsoluteColumn] = value;
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
		public string Buyer
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.BuyerColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Buyer' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.BuyerColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string Class
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.ClassColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Class' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.ClassColumn] = value;
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
		public string SysTime
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.SysTimeColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'SysTime' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.SysTimeColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string Finyear
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.FinyearColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Finyear' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.FinyearColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string AHId
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.AHIdColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'AHId' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.AHIdColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string Excise
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.ExciseColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Excise' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.ExciseColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string ImportLocal
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.ImportLocalColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'ImportLocal' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.ImportLocalColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string OpeningBalDate
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.OpeningBalDateColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'OpeningBalDate' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.OpeningBalDateColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string InspectionDays
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.InspectionDaysColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'InspectionDays' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.InspectionDaysColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string LeadDays
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.LeadDaysColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'LeadDays' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.LeadDaysColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string UOMconv
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.UOMconvColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'UOMconv' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.UOMconvColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		internal DataTable1Row(DataRowBuilder rb)
			: base(rb)
		{
			tableDataTable1 = (DataTable1DataTable)base.Table;
		}

		[DebuggerNonUserCode]
		public bool IsItemCodeNull()
		{
			return IsNull(tableDataTable1.ItemCodeColumn);
		}

		[DebuggerNonUserCode]
		public void SetItemCodeNull()
		{
			base[tableDataTable1.ItemCodeColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsManfDescNull()
		{
			return IsNull(tableDataTable1.ManfDescColumn);
		}

		[DebuggerNonUserCode]
		public void SetManfDescNull()
		{
			base[tableDataTable1.ManfDescColumn] = Convert.DBNull;
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
		public bool IsMinOrderQtyNull()
		{
			return IsNull(tableDataTable1.MinOrderQtyColumn);
		}

		[DebuggerNonUserCode]
		public void SetMinOrderQtyNull()
		{
			base[tableDataTable1.MinOrderQtyColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsMinStockQtyNull()
		{
			return IsNull(tableDataTable1.MinStockQtyColumn);
		}

		[DebuggerNonUserCode]
		public void SetMinStockQtyNull()
		{
			base[tableDataTable1.MinStockQtyColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsStockQtyNull()
		{
			return IsNull(tableDataTable1.StockQtyColumn);
		}

		[DebuggerNonUserCode]
		public void SetStockQtyNull()
		{
			base[tableDataTable1.StockQtyColumn] = Convert.DBNull;
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
		public bool IsAbsoluteNull()
		{
			return IsNull(tableDataTable1.AbsoluteColumn);
		}

		[DebuggerNonUserCode]
		public void SetAbsoluteNull()
		{
			base[tableDataTable1.AbsoluteColumn] = Convert.DBNull;
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
		public bool IsBuyerNull()
		{
			return IsNull(tableDataTable1.BuyerColumn);
		}

		[DebuggerNonUserCode]
		public void SetBuyerNull()
		{
			base[tableDataTable1.BuyerColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsClassNull()
		{
			return IsNull(tableDataTable1.ClassColumn);
		}

		[DebuggerNonUserCode]
		public void SetClassNull()
		{
			base[tableDataTable1.ClassColumn] = Convert.DBNull;
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
		public bool IsSysTimeNull()
		{
			return IsNull(tableDataTable1.SysTimeColumn);
		}

		[DebuggerNonUserCode]
		public void SetSysTimeNull()
		{
			base[tableDataTable1.SysTimeColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsFinyearNull()
		{
			return IsNull(tableDataTable1.FinyearColumn);
		}

		[DebuggerNonUserCode]
		public void SetFinyearNull()
		{
			base[tableDataTable1.FinyearColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsAHIdNull()
		{
			return IsNull(tableDataTable1.AHIdColumn);
		}

		[DebuggerNonUserCode]
		public void SetAHIdNull()
		{
			base[tableDataTable1.AHIdColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsExciseNull()
		{
			return IsNull(tableDataTable1.ExciseColumn);
		}

		[DebuggerNonUserCode]
		public void SetExciseNull()
		{
			base[tableDataTable1.ExciseColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsImportLocalNull()
		{
			return IsNull(tableDataTable1.ImportLocalColumn);
		}

		[DebuggerNonUserCode]
		public void SetImportLocalNull()
		{
			base[tableDataTable1.ImportLocalColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsOpeningBalDateNull()
		{
			return IsNull(tableDataTable1.OpeningBalDateColumn);
		}

		[DebuggerNonUserCode]
		public void SetOpeningBalDateNull()
		{
			base[tableDataTable1.OpeningBalDateColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsInspectionDaysNull()
		{
			return IsNull(tableDataTable1.InspectionDaysColumn);
		}

		[DebuggerNonUserCode]
		public void SetInspectionDaysNull()
		{
			base[tableDataTable1.InspectionDaysColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsLeadDaysNull()
		{
			return IsNull(tableDataTable1.LeadDaysColumn);
		}

		[DebuggerNonUserCode]
		public void SetLeadDaysNull()
		{
			base[tableDataTable1.LeadDaysColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsUOMconvNull()
		{
			return IsNull(tableDataTable1.UOMconvColumn);
		}

		[DebuggerNonUserCode]
		public void SetUOMconvNull()
		{
			base[tableDataTable1.UOMconvColumn] = Convert.DBNull;
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
	[DebuggerNonUserCode]
	[Browsable(false)]
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
	public ItemMaster()
	{
		BeginInit();
		InitClass();
		CollectionChangeEventHandler value = SchemaChanged;
		base.Tables.CollectionChanged += value;
		base.Relations.CollectionChanged += value;
		EndInit();
	}

	[DebuggerNonUserCode]
	protected ItemMaster(SerializationInfo info, StreamingContext context)
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
		ItemMaster itemMaster = (ItemMaster)base.Clone();
		itemMaster.InitVars();
		itemMaster.SchemaSerializationMode = SchemaSerializationMode;
		return itemMaster;
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
		base.DataSetName = "ItemMaster";
		base.Prefix = "";
		base.Namespace = "http://tempuri.org/ItemMaster.xsd";
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
		ItemMaster itemMaster = new ItemMaster();
		XmlSchemaComplexType xmlSchemaComplexType = new XmlSchemaComplexType();
		XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
		XmlSchemaAny xmlSchemaAny = new XmlSchemaAny();
		xmlSchemaAny.Namespace = itemMaster.Namespace;
		xmlSchemaSequence.Items.Add(xmlSchemaAny);
		xmlSchemaComplexType.Particle = xmlSchemaSequence;
		XmlSchema schemaSerializable = itemMaster.GetSchemaSerializable();
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
