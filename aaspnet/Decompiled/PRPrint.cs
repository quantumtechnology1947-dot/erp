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
[XmlSchemaProvider("GetTypedDataSetSchema")]
[XmlRoot("PRPrint")]
public class PRPrint : DataSet
{
	public delegate void DataTable1RowChangeEventHandler(object sender, DataTable1RowChangeEvent e);

	[Serializable]
	[XmlSchemaProvider("GetTypedTableSchema")]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
	public class DataTable1DataTable : TypedTableBase<DataTable1Row>
	{
		private DataColumn columnItemCode;

		private DataColumn columnPurchDesc;

		private DataColumn columnUomPurch;

		private DataColumn columnDelDate;

		private DataColumn columnSPRQTY;

		private DataColumn columnRate;

		private DataColumn columnWONo;

		private DataColumn columnSupplierName;

		private DataColumn columnAcHead;

		private DataColumn columnRemarks;

		private DataColumn columnCompId;

		private DataColumn columnIntender;

		private DataColumn columnTaskProjectTitle;

		private DataColumn columnDiscount;

		[DebuggerNonUserCode]
		public DataColumn ItemCodeColumn => columnItemCode;

		[DebuggerNonUserCode]
		public DataColumn PurchDescColumn => columnPurchDesc;

		[DebuggerNonUserCode]
		public DataColumn UomPurchColumn => columnUomPurch;

		[DebuggerNonUserCode]
		public DataColumn DelDateColumn => columnDelDate;

		[DebuggerNonUserCode]
		public DataColumn SPRQTYColumn => columnSPRQTY;

		[DebuggerNonUserCode]
		public DataColumn RateColumn => columnRate;

		[DebuggerNonUserCode]
		public DataColumn WONoColumn => columnWONo;

		[DebuggerNonUserCode]
		public DataColumn SupplierNameColumn => columnSupplierName;

		[DebuggerNonUserCode]
		public DataColumn AcHeadColumn => columnAcHead;

		[DebuggerNonUserCode]
		public DataColumn RemarksColumn => columnRemarks;

		[DebuggerNonUserCode]
		public DataColumn CompIdColumn => columnCompId;

		[DebuggerNonUserCode]
		public DataColumn IntenderColumn => columnIntender;

		[DebuggerNonUserCode]
		public DataColumn TaskProjectTitleColumn => columnTaskProjectTitle;

		[DebuggerNonUserCode]
		public DataColumn DiscountColumn => columnDiscount;

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
		public DataTable1Row AddDataTable1Row(string ItemCode, string PurchDesc, string UomPurch, string DelDate, double SPRQTY, double Rate, string WONo, string SupplierName, string AcHead, string Remarks, int CompId, string Intender, string TaskProjectTitle, double Discount)
		{
			DataTable1Row dataTable1Row = (DataTable1Row)NewRow();
			object[] itemArray = new object[14]
			{
				ItemCode, PurchDesc, UomPurch, DelDate, SPRQTY, Rate, WONo, SupplierName, AcHead, Remarks,
				CompId, Intender, TaskProjectTitle, Discount
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
			columnPurchDesc = base.Columns["PurchDesc"];
			columnUomPurch = base.Columns["UomPurch"];
			columnDelDate = base.Columns["DelDate"];
			columnSPRQTY = base.Columns["SPRQTY"];
			columnRate = base.Columns["Rate"];
			columnWONo = base.Columns["WONo"];
			columnSupplierName = base.Columns["SupplierName"];
			columnAcHead = base.Columns["AcHead"];
			columnRemarks = base.Columns["Remarks"];
			columnCompId = base.Columns["CompId"];
			columnIntender = base.Columns["Intender"];
			columnTaskProjectTitle = base.Columns["TaskProjectTitle"];
			columnDiscount = base.Columns["Discount"];
		}

		[DebuggerNonUserCode]
		private void InitClass()
		{
			columnItemCode = new DataColumn("ItemCode", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnItemCode);
			columnPurchDesc = new DataColumn("PurchDesc", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnPurchDesc);
			columnUomPurch = new DataColumn("UomPurch", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnUomPurch);
			columnDelDate = new DataColumn("DelDate", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnDelDate);
			columnSPRQTY = new DataColumn("SPRQTY", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnSPRQTY);
			columnRate = new DataColumn("Rate", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnRate);
			columnWONo = new DataColumn("WONo", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnWONo);
			columnSupplierName = new DataColumn("SupplierName", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnSupplierName);
			columnAcHead = new DataColumn("AcHead", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnAcHead);
			columnRemarks = new DataColumn("Remarks", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnRemarks);
			columnCompId = new DataColumn("CompId", typeof(int), null, MappingType.Element);
			base.Columns.Add(columnCompId);
			columnIntender = new DataColumn("Intender", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnIntender);
			columnTaskProjectTitle = new DataColumn("TaskProjectTitle", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnTaskProjectTitle);
			columnDiscount = new DataColumn("Discount", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnDiscount);
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
			PRPrint pRPrint = new PRPrint();
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
			xmlSchemaAttribute.FixedValue = pRPrint.Namespace;
			xmlSchemaComplexType.Attributes.Add(xmlSchemaAttribute);
			XmlSchemaAttribute xmlSchemaAttribute2 = new XmlSchemaAttribute();
			xmlSchemaAttribute2.Name = "tableTypeName";
			xmlSchemaAttribute2.FixedValue = "DataTable1DataTable";
			xmlSchemaComplexType.Attributes.Add(xmlSchemaAttribute2);
			xmlSchemaComplexType.Particle = xmlSchemaSequence;
			XmlSchema schemaSerializable = pRPrint.GetSchemaSerializable();
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
		public string PurchDesc
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.PurchDescColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'PurchDesc' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.PurchDescColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string UomPurch
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.UomPurchColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'UomPurch' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.UomPurchColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string DelDate
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.DelDateColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'DelDate' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.DelDateColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public double SPRQTY
		{
			get
			{
				try
				{
					return (double)base[tableDataTable1.SPRQTYColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'SPRQTY' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.SPRQTYColumn] = value;
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
		public string SupplierName
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.SupplierNameColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'SupplierName' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.SupplierNameColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string AcHead
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.AcHeadColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'AcHead' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.AcHeadColumn] = value;
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
		public string Intender
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.IntenderColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Intender' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.IntenderColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string TaskProjectTitle
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.TaskProjectTitleColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'TaskProjectTitle' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.TaskProjectTitleColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public double Discount
		{
			get
			{
				try
				{
					return (double)base[tableDataTable1.DiscountColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Discount' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.DiscountColumn] = value;
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
		public bool IsPurchDescNull()
		{
			return IsNull(tableDataTable1.PurchDescColumn);
		}

		[DebuggerNonUserCode]
		public void SetPurchDescNull()
		{
			base[tableDataTable1.PurchDescColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsUomPurchNull()
		{
			return IsNull(tableDataTable1.UomPurchColumn);
		}

		[DebuggerNonUserCode]
		public void SetUomPurchNull()
		{
			base[tableDataTable1.UomPurchColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsDelDateNull()
		{
			return IsNull(tableDataTable1.DelDateColumn);
		}

		[DebuggerNonUserCode]
		public void SetDelDateNull()
		{
			base[tableDataTable1.DelDateColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsSPRQTYNull()
		{
			return IsNull(tableDataTable1.SPRQTYColumn);
		}

		[DebuggerNonUserCode]
		public void SetSPRQTYNull()
		{
			base[tableDataTable1.SPRQTYColumn] = Convert.DBNull;
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
		public bool IsSupplierNameNull()
		{
			return IsNull(tableDataTable1.SupplierNameColumn);
		}

		[DebuggerNonUserCode]
		public void SetSupplierNameNull()
		{
			base[tableDataTable1.SupplierNameColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsAcHeadNull()
		{
			return IsNull(tableDataTable1.AcHeadColumn);
		}

		[DebuggerNonUserCode]
		public void SetAcHeadNull()
		{
			base[tableDataTable1.AcHeadColumn] = Convert.DBNull;
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
		public bool IsIntenderNull()
		{
			return IsNull(tableDataTable1.IntenderColumn);
		}

		[DebuggerNonUserCode]
		public void SetIntenderNull()
		{
			base[tableDataTable1.IntenderColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsTaskProjectTitleNull()
		{
			return IsNull(tableDataTable1.TaskProjectTitleColumn);
		}

		[DebuggerNonUserCode]
		public void SetTaskProjectTitleNull()
		{
			base[tableDataTable1.TaskProjectTitleColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsDiscountNull()
		{
			return IsNull(tableDataTable1.DiscountColumn);
		}

		[DebuggerNonUserCode]
		public void SetDiscountNull()
		{
			base[tableDataTable1.DiscountColumn] = Convert.DBNull;
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

	[DebuggerNonUserCode]
	[Browsable(true)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
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

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[DebuggerNonUserCode]
	public new DataRelationCollection Relations => base.Relations;

	[DebuggerNonUserCode]
	public PRPrint()
	{
		BeginInit();
		InitClass();
		CollectionChangeEventHandler value = SchemaChanged;
		base.Tables.CollectionChanged += value;
		base.Relations.CollectionChanged += value;
		EndInit();
	}

	[DebuggerNonUserCode]
	protected PRPrint(SerializationInfo info, StreamingContext context)
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
		PRPrint pRPrint = (PRPrint)base.Clone();
		pRPrint.InitVars();
		pRPrint.SchemaSerializationMode = SchemaSerializationMode;
		return pRPrint;
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
		base.DataSetName = "PRPrint";
		base.Prefix = "";
		base.Namespace = "http://tempuri.org/PRPrint.xsd";
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
		PRPrint pRPrint = new PRPrint();
		XmlSchemaComplexType xmlSchemaComplexType = new XmlSchemaComplexType();
		XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
		XmlSchemaAny xmlSchemaAny = new XmlSchemaAny();
		xmlSchemaAny.Namespace = pRPrint.Namespace;
		xmlSchemaSequence.Items.Add(xmlSchemaAny);
		xmlSchemaComplexType.Particle = xmlSchemaSequence;
		XmlSchema schemaSerializable = pRPrint.GetSchemaSerializable();
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
