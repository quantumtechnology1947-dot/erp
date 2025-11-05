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
[XmlRoot("WO_Shortage")]
public class WO_Shortage : DataSet
{
	public delegate void WO_ShortageRowChangeEventHandler(object sender, WO_ShortageRowChangeEvent e);

	[Serializable]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
	[XmlSchemaProvider("GetTypedTableSchema")]
	public class WO_ShortageDataTable : TypedTableBase<WO_ShortageRow>
	{
		private DataColumn columnItemCode;

		private DataColumn columnManfDesc;

		private DataColumn columnUOM;

		private DataColumn columnQty;

		private DataColumn columnWONo;

		private DataColumn columnCompId;

		private DataColumn columnIssueQty;

		private DataColumn columnRate;

		[DebuggerNonUserCode]
		public DataColumn ItemCodeColumn => columnItemCode;

		[DebuggerNonUserCode]
		public DataColumn ManfDescColumn => columnManfDesc;

		[DebuggerNonUserCode]
		public DataColumn UOMColumn => columnUOM;

		[DebuggerNonUserCode]
		public DataColumn QtyColumn => columnQty;

		[DebuggerNonUserCode]
		public DataColumn WONoColumn => columnWONo;

		[DebuggerNonUserCode]
		public DataColumn CompIdColumn => columnCompId;

		[DebuggerNonUserCode]
		public DataColumn IssueQtyColumn => columnIssueQty;

		[DebuggerNonUserCode]
		public DataColumn RateColumn => columnRate;

		[DebuggerNonUserCode]
		[Browsable(false)]
		public int Count => base.Rows.Count;

		[DebuggerNonUserCode]
		public WO_ShortageRow this[int index] => (WO_ShortageRow)base.Rows[index];

		public event WO_ShortageRowChangeEventHandler WO_ShortageRowChanging;

		public event WO_ShortageRowChangeEventHandler WO_ShortageRowChanged;

		public event WO_ShortageRowChangeEventHandler WO_ShortageRowDeleting;

		public event WO_ShortageRowChangeEventHandler WO_ShortageRowDeleted;

		[DebuggerNonUserCode]
		public WO_ShortageDataTable()
		{
			base.TableName = "WO_Shortage";
			BeginInit();
			InitClass();
			EndInit();
		}

		[DebuggerNonUserCode]
		internal WO_ShortageDataTable(DataTable table)
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
		protected WO_ShortageDataTable(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
			InitVars();
		}

		[DebuggerNonUserCode]
		public void AddWO_ShortageRow(WO_ShortageRow row)
		{
			base.Rows.Add(row);
		}

		[DebuggerNonUserCode]
		public WO_ShortageRow AddWO_ShortageRow(string ItemCode, string ManfDesc, string UOM, double Qty, string WONo, int CompId, double IssueQty, double Rate)
		{
			WO_ShortageRow wO_ShortageRow = (WO_ShortageRow)NewRow();
			object[] itemArray = new object[8] { ItemCode, ManfDesc, UOM, Qty, WONo, CompId, IssueQty, Rate };
			wO_ShortageRow.ItemArray = itemArray;
			base.Rows.Add(wO_ShortageRow);
			return wO_ShortageRow;
		}

		[DebuggerNonUserCode]
		public override DataTable Clone()
		{
			WO_ShortageDataTable wO_ShortageDataTable = (WO_ShortageDataTable)base.Clone();
			wO_ShortageDataTable.InitVars();
			return wO_ShortageDataTable;
		}

		[DebuggerNonUserCode]
		protected override DataTable CreateInstance()
		{
			return new WO_ShortageDataTable();
		}

		[DebuggerNonUserCode]
		internal void InitVars()
		{
			columnItemCode = base.Columns["ItemCode"];
			columnManfDesc = base.Columns["ManfDesc"];
			columnUOM = base.Columns["UOM"];
			columnQty = base.Columns["Qty"];
			columnWONo = base.Columns["WONo"];
			columnCompId = base.Columns["CompId"];
			columnIssueQty = base.Columns["IssueQty"];
			columnRate = base.Columns["Rate"];
		}

		[DebuggerNonUserCode]
		private void InitClass()
		{
			columnItemCode = new DataColumn("ItemCode", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnItemCode);
			columnManfDesc = new DataColumn("ManfDesc", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnManfDesc);
			columnUOM = new DataColumn("UOM", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnUOM);
			columnQty = new DataColumn("Qty", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnQty);
			columnWONo = new DataColumn("WONo", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnWONo);
			columnCompId = new DataColumn("CompId", typeof(int), null, MappingType.Element);
			base.Columns.Add(columnCompId);
			columnIssueQty = new DataColumn("IssueQty", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnIssueQty);
			columnRate = new DataColumn("Rate", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnRate);
			base.ExtendedProperties.Add("Generator_TablePropName", "_WO_Shortage");
			base.ExtendedProperties.Add("Generator_UserTableName", "WO_Shortage");
		}

		[DebuggerNonUserCode]
		public WO_ShortageRow NewWO_ShortageRow()
		{
			return (WO_ShortageRow)NewRow();
		}

		[DebuggerNonUserCode]
		protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
		{
			return new WO_ShortageRow(builder);
		}

		[DebuggerNonUserCode]
		protected override Type GetRowType()
		{
			return typeof(WO_ShortageRow);
		}

		[DebuggerNonUserCode]
		protected override void OnRowChanged(DataRowChangeEventArgs e)
		{
			base.OnRowChanged(e);
			if (this.WO_ShortageRowChanged != null)
			{
				this.WO_ShortageRowChanged(this, new WO_ShortageRowChangeEvent((WO_ShortageRow)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		protected override void OnRowChanging(DataRowChangeEventArgs e)
		{
			base.OnRowChanging(e);
			if (this.WO_ShortageRowChanging != null)
			{
				this.WO_ShortageRowChanging(this, new WO_ShortageRowChangeEvent((WO_ShortageRow)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		protected override void OnRowDeleted(DataRowChangeEventArgs e)
		{
			base.OnRowDeleted(e);
			if (this.WO_ShortageRowDeleted != null)
			{
				this.WO_ShortageRowDeleted(this, new WO_ShortageRowChangeEvent((WO_ShortageRow)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		protected override void OnRowDeleting(DataRowChangeEventArgs e)
		{
			base.OnRowDeleting(e);
			if (this.WO_ShortageRowDeleting != null)
			{
				this.WO_ShortageRowDeleting(this, new WO_ShortageRowChangeEvent((WO_ShortageRow)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		public void RemoveWO_ShortageRow(WO_ShortageRow row)
		{
			base.Rows.Remove(row);
		}

		[DebuggerNonUserCode]
		public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
		{
			XmlSchemaComplexType xmlSchemaComplexType = new XmlSchemaComplexType();
			XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
			WO_Shortage wO_Shortage = new WO_Shortage();
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
			xmlSchemaAttribute.FixedValue = wO_Shortage.Namespace;
			xmlSchemaComplexType.Attributes.Add(xmlSchemaAttribute);
			XmlSchemaAttribute xmlSchemaAttribute2 = new XmlSchemaAttribute();
			xmlSchemaAttribute2.Name = "tableTypeName";
			xmlSchemaAttribute2.FixedValue = "WO_ShortageDataTable";
			xmlSchemaComplexType.Attributes.Add(xmlSchemaAttribute2);
			xmlSchemaComplexType.Particle = xmlSchemaSequence;
			XmlSchema schemaSerializable = wO_Shortage.GetSchemaSerializable();
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
	public class WO_ShortageRow : DataRow
	{
		private WO_ShortageDataTable tableWO_Shortage;

		[DebuggerNonUserCode]
		public string ItemCode
		{
			get
			{
				try
				{
					return (string)base[tableWO_Shortage.ItemCodeColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'ItemCode' in table 'WO_Shortage' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableWO_Shortage.ItemCodeColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string ManfDesc
		{
			get
			{
				try
				{
					return (string)base[tableWO_Shortage.ManfDescColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'ManfDesc' in table 'WO_Shortage' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableWO_Shortage.ManfDescColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string UOM
		{
			get
			{
				try
				{
					return (string)base[tableWO_Shortage.UOMColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'UOM' in table 'WO_Shortage' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableWO_Shortage.UOMColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public double Qty
		{
			get
			{
				try
				{
					return (double)base[tableWO_Shortage.QtyColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Qty' in table 'WO_Shortage' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableWO_Shortage.QtyColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string WONo
		{
			get
			{
				try
				{
					return (string)base[tableWO_Shortage.WONoColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'WONo' in table 'WO_Shortage' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableWO_Shortage.WONoColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public int CompId
		{
			get
			{
				try
				{
					return (int)base[tableWO_Shortage.CompIdColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'CompId' in table 'WO_Shortage' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableWO_Shortage.CompIdColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public double IssueQty
		{
			get
			{
				try
				{
					return (double)base[tableWO_Shortage.IssueQtyColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'IssueQty' in table 'WO_Shortage' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableWO_Shortage.IssueQtyColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public double Rate
		{
			get
			{
				try
				{
					return (double)base[tableWO_Shortage.RateColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Rate' in table 'WO_Shortage' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableWO_Shortage.RateColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		internal WO_ShortageRow(DataRowBuilder rb)
			: base(rb)
		{
			tableWO_Shortage = (WO_ShortageDataTable)base.Table;
		}

		[DebuggerNonUserCode]
		public bool IsItemCodeNull()
		{
			return IsNull(tableWO_Shortage.ItemCodeColumn);
		}

		[DebuggerNonUserCode]
		public void SetItemCodeNull()
		{
			base[tableWO_Shortage.ItemCodeColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsManfDescNull()
		{
			return IsNull(tableWO_Shortage.ManfDescColumn);
		}

		[DebuggerNonUserCode]
		public void SetManfDescNull()
		{
			base[tableWO_Shortage.ManfDescColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsUOMNull()
		{
			return IsNull(tableWO_Shortage.UOMColumn);
		}

		[DebuggerNonUserCode]
		public void SetUOMNull()
		{
			base[tableWO_Shortage.UOMColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsQtyNull()
		{
			return IsNull(tableWO_Shortage.QtyColumn);
		}

		[DebuggerNonUserCode]
		public void SetQtyNull()
		{
			base[tableWO_Shortage.QtyColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsWONoNull()
		{
			return IsNull(tableWO_Shortage.WONoColumn);
		}

		[DebuggerNonUserCode]
		public void SetWONoNull()
		{
			base[tableWO_Shortage.WONoColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsCompIdNull()
		{
			return IsNull(tableWO_Shortage.CompIdColumn);
		}

		[DebuggerNonUserCode]
		public void SetCompIdNull()
		{
			base[tableWO_Shortage.CompIdColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsIssueQtyNull()
		{
			return IsNull(tableWO_Shortage.IssueQtyColumn);
		}

		[DebuggerNonUserCode]
		public void SetIssueQtyNull()
		{
			base[tableWO_Shortage.IssueQtyColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsRateNull()
		{
			return IsNull(tableWO_Shortage.RateColumn);
		}

		[DebuggerNonUserCode]
		public void SetRateNull()
		{
			base[tableWO_Shortage.RateColumn] = Convert.DBNull;
		}
	}

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
	public class WO_ShortageRowChangeEvent : EventArgs
	{
		private WO_ShortageRow eventRow;

		private DataRowAction eventAction;

		[DebuggerNonUserCode]
		public WO_ShortageRow Row => eventRow;

		[DebuggerNonUserCode]
		public DataRowAction Action => eventAction;

		[DebuggerNonUserCode]
		public WO_ShortageRowChangeEvent(WO_ShortageRow row, DataRowAction action)
		{
			eventRow = row;
			eventAction = action;
		}
	}

	private WO_ShortageDataTable tableWO_Shortage;

	private SchemaSerializationMode _schemaSerializationMode = SchemaSerializationMode.IncludeSchema;

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	[DebuggerNonUserCode]
	[Browsable(false)]
	public WO_ShortageDataTable _WO_Shortage => tableWO_Shortage;

	[Browsable(true)]
	[DebuggerNonUserCode]
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
	public WO_Shortage()
	{
		BeginInit();
		InitClass();
		CollectionChangeEventHandler value = SchemaChanged;
		base.Tables.CollectionChanged += value;
		base.Relations.CollectionChanged += value;
		EndInit();
	}

	[DebuggerNonUserCode]
	protected WO_Shortage(SerializationInfo info, StreamingContext context)
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
			if (dataSet.Tables["WO_Shortage"] != null)
			{
				base.Tables.Add(new WO_ShortageDataTable(dataSet.Tables["WO_Shortage"]));
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
		WO_Shortage wO_Shortage = (WO_Shortage)base.Clone();
		wO_Shortage.InitVars();
		wO_Shortage.SchemaSerializationMode = SchemaSerializationMode;
		return wO_Shortage;
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
			if (dataSet.Tables["WO_Shortage"] != null)
			{
				base.Tables.Add(new WO_ShortageDataTable(dataSet.Tables["WO_Shortage"]));
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
		tableWO_Shortage = (WO_ShortageDataTable)base.Tables["WO_Shortage"];
		if (initTable && tableWO_Shortage != null)
		{
			tableWO_Shortage.InitVars();
		}
	}

	[DebuggerNonUserCode]
	private void InitClass()
	{
		base.DataSetName = "WO_Shortage";
		base.Prefix = "";
		base.Namespace = "http://tempuri.org/WO_Shortage.xsd";
		base.EnforceConstraints = true;
		SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
		tableWO_Shortage = new WO_ShortageDataTable();
		base.Tables.Add(tableWO_Shortage);
	}

	[DebuggerNonUserCode]
	private bool ShouldSerialize_WO_Shortage()
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
		WO_Shortage wO_Shortage = new WO_Shortage();
		XmlSchemaComplexType xmlSchemaComplexType = new XmlSchemaComplexType();
		XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
		XmlSchemaAny xmlSchemaAny = new XmlSchemaAny();
		xmlSchemaAny.Namespace = wO_Shortage.Namespace;
		xmlSchemaSequence.Items.Add(xmlSchemaAny);
		xmlSchemaComplexType.Particle = xmlSchemaSequence;
		XmlSchema schemaSerializable = wO_Shortage.GetSchemaSerializable();
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
