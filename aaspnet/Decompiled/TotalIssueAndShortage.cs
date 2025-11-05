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
[HelpKeyword("vs.data.DataSet")]
[DesignerCategory("code")]
[ToolboxItem(true)]
[XmlRoot("TotalIssueAndShortage")]
[XmlSchemaProvider("GetTypedDataSetSchema")]
public class TotalIssueAndShortage : DataSet
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

		private DataColumn columnBOMQty;

		private DataColumn columnIssuedQty;

		private DataColumn columnShortageQty;

		private DataColumn columnAC;

		private DataColumn columnCompId;

		private DataColumn columnWONo;

		private DataColumn columnRate;

		private DataColumn columnAmount;

		[DebuggerNonUserCode]
		public DataColumn ItemCodeColumn => columnItemCode;

		[DebuggerNonUserCode]
		public DataColumn ManfDescColumn => columnManfDesc;

		[DebuggerNonUserCode]
		public DataColumn UOMBasicColumn => columnUOMBasic;

		[DebuggerNonUserCode]
		public DataColumn BOMQtyColumn => columnBOMQty;

		[DebuggerNonUserCode]
		public DataColumn IssuedQtyColumn => columnIssuedQty;

		[DebuggerNonUserCode]
		public DataColumn ShortageQtyColumn => columnShortageQty;

		[DebuggerNonUserCode]
		public DataColumn ACColumn => columnAC;

		[DebuggerNonUserCode]
		public DataColumn CompIdColumn => columnCompId;

		[DebuggerNonUserCode]
		public DataColumn WONoColumn => columnWONo;

		[DebuggerNonUserCode]
		public DataColumn RateColumn => columnRate;

		[DebuggerNonUserCode]
		public DataColumn AmountColumn => columnAmount;

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
		public DataTable1Row AddDataTable1Row(string ItemCode, string ManfDesc, string UOMBasic, double BOMQty, double IssuedQty, double ShortageQty, string AC, int CompId, string WONo, double Rate, double Amount)
		{
			DataTable1Row dataTable1Row = (DataTable1Row)NewRow();
			object[] itemArray = new object[11]
			{
				ItemCode, ManfDesc, UOMBasic, BOMQty, IssuedQty, ShortageQty, AC, CompId, WONo, Rate,
				Amount
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
			columnBOMQty = base.Columns["BOMQty"];
			columnIssuedQty = base.Columns["IssuedQty"];
			columnShortageQty = base.Columns["ShortageQty"];
			columnAC = base.Columns["AC"];
			columnCompId = base.Columns["CompId"];
			columnWONo = base.Columns["WONo"];
			columnRate = base.Columns["Rate"];
			columnAmount = base.Columns["Amount"];
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
			columnBOMQty = new DataColumn("BOMQty", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnBOMQty);
			columnIssuedQty = new DataColumn("IssuedQty", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnIssuedQty);
			columnShortageQty = new DataColumn("ShortageQty", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnShortageQty);
			columnAC = new DataColumn("AC", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnAC);
			columnCompId = new DataColumn("CompId", typeof(int), null, MappingType.Element);
			base.Columns.Add(columnCompId);
			columnWONo = new DataColumn("WONo", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnWONo);
			columnRate = new DataColumn("Rate", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnRate);
			columnAmount = new DataColumn("Amount", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnAmount);
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
			TotalIssueAndShortage totalIssueAndShortage = new TotalIssueAndShortage();
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
			xmlSchemaAttribute.FixedValue = totalIssueAndShortage.Namespace;
			xmlSchemaComplexType.Attributes.Add(xmlSchemaAttribute);
			XmlSchemaAttribute xmlSchemaAttribute2 = new XmlSchemaAttribute();
			xmlSchemaAttribute2.Name = "tableTypeName";
			xmlSchemaAttribute2.FixedValue = "DataTable1DataTable";
			xmlSchemaComplexType.Attributes.Add(xmlSchemaAttribute2);
			xmlSchemaComplexType.Particle = xmlSchemaSequence;
			XmlSchema schemaSerializable = totalIssueAndShortage.GetSchemaSerializable();
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
		public double BOMQty
		{
			get
			{
				try
				{
					return (double)base[tableDataTable1.BOMQtyColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'BOMQty' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.BOMQtyColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public double IssuedQty
		{
			get
			{
				try
				{
					return (double)base[tableDataTable1.IssuedQtyColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'IssuedQty' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.IssuedQtyColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public double ShortageQty
		{
			get
			{
				try
				{
					return (double)base[tableDataTable1.ShortageQtyColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'ShortageQty' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.ShortageQtyColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string AC
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.ACColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'AC' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.ACColumn] = value;
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
		public string WONo
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.WONoColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'WONo' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.WONoColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public double Rate
		{
			get
			{
				try
				{
					return (double)base[tableDataTable1.RateColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Rate' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.RateColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public double Amount
		{
			get
			{
				try
				{
					return (double)base[tableDataTable1.AmountColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Amount' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.AmountColumn] = value;
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
		public bool IsBOMQtyNull()
		{
			return IsNull(tableDataTable1.BOMQtyColumn);
		}

		[DebuggerNonUserCode]
		public void SetBOMQtyNull()
		{
			base[tableDataTable1.BOMQtyColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsIssuedQtyNull()
		{
			return IsNull(tableDataTable1.IssuedQtyColumn);
		}

		[DebuggerNonUserCode]
		public void SetIssuedQtyNull()
		{
			base[tableDataTable1.IssuedQtyColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsShortageQtyNull()
		{
			return IsNull(tableDataTable1.ShortageQtyColumn);
		}

		[DebuggerNonUserCode]
		public void SetShortageQtyNull()
		{
			base[tableDataTable1.ShortageQtyColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsACNull()
		{
			return IsNull(tableDataTable1.ACColumn);
		}

		[DebuggerNonUserCode]
		public void SetACNull()
		{
			base[tableDataTable1.ACColumn] = Convert.DBNull;
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
		public bool IsWONoNull()
		{
			return IsNull(tableDataTable1.WONoColumn);
		}

		[DebuggerNonUserCode]
		public void SetWONoNull()
		{
			base[tableDataTable1.WONoColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsRateNull()
		{
			return IsNull(tableDataTable1.RateColumn);
		}

		[DebuggerNonUserCode]
		public void SetRateNull()
		{
			base[tableDataTable1.RateColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsAmountNull()
		{
			return IsNull(tableDataTable1.AmountColumn);
		}

		[DebuggerNonUserCode]
		public void SetAmountNull()
		{
			base[tableDataTable1.AmountColumn] = Convert.DBNull;
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
	[DebuggerNonUserCode]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public DataTable1DataTable DataTable1 => tableDataTable1;

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
	[DebuggerNonUserCode]
	[Browsable(true)]
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
	public TotalIssueAndShortage()
	{
		BeginInit();
		InitClass();
		CollectionChangeEventHandler value = SchemaChanged;
		base.Tables.CollectionChanged += value;
		base.Relations.CollectionChanged += value;
		EndInit();
	}

	[DebuggerNonUserCode]
	protected TotalIssueAndShortage(SerializationInfo info, StreamingContext context)
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
		TotalIssueAndShortage totalIssueAndShortage = (TotalIssueAndShortage)base.Clone();
		totalIssueAndShortage.InitVars();
		totalIssueAndShortage.SchemaSerializationMode = SchemaSerializationMode;
		return totalIssueAndShortage;
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
		base.DataSetName = "TotalIssueAndShortage";
		base.Prefix = "";
		base.Namespace = "http://tempuri.org/TotalIssueAndShortage.xsd";
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
		TotalIssueAndShortage totalIssueAndShortage = new TotalIssueAndShortage();
		XmlSchemaComplexType xmlSchemaComplexType = new XmlSchemaComplexType();
		XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
		XmlSchemaAny xmlSchemaAny = new XmlSchemaAny();
		xmlSchemaAny.Namespace = totalIssueAndShortage.Namespace;
		xmlSchemaSequence.Items.Add(xmlSchemaAny);
		xmlSchemaComplexType.Particle = xmlSchemaSequence;
		XmlSchema schemaSerializable = totalIssueAndShortage.GetSchemaSerializable();
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
