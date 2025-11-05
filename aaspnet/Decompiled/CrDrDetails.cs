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
[XmlSchemaProvider("GetTypedDataSetSchema")]
[HelpKeyword("vs.data.DataSet")]
[DesignerCategory("code")]
[XmlRoot("CrDrDetails")]
[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
[ToolboxItem(true)]
public class CrDrDetails : DataSet
{
	public delegate void DataTable1RowChangeEventHandler(object sender, DataTable1RowChangeEvent e);

	[Serializable]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
	[XmlSchemaProvider("GetTypedTableSchema")]
	public class DataTable1DataTable : TypedTableBase<DataTable1Row>
	{
		private DataColumn columnVchDate;

		private DataColumn columnCompId;

		private DataColumn columnVchNo;

		private DataColumn columnVchType;

		private DataColumn columnParticulars;

		private DataColumn columnCredit;

		private DataColumn columnDebit;

		private DataColumn columnOtherCharges;

		private DataColumn columnVchLinkData;

		private DataColumn columnDTSort;

		private DataColumn columnBillNo;

		private DataColumn columnBillDate;

		[DebuggerNonUserCode]
		public DataColumn VchDateColumn => columnVchDate;

		[DebuggerNonUserCode]
		public DataColumn CompIdColumn => columnCompId;

		[DebuggerNonUserCode]
		public DataColumn VchNoColumn => columnVchNo;

		[DebuggerNonUserCode]
		public DataColumn VchTypeColumn => columnVchType;

		[DebuggerNonUserCode]
		public DataColumn ParticularsColumn => columnParticulars;

		[DebuggerNonUserCode]
		public DataColumn CreditColumn => columnCredit;

		[DebuggerNonUserCode]
		public DataColumn DebitColumn => columnDebit;

		[DebuggerNonUserCode]
		public DataColumn OtherChargesColumn => columnOtherCharges;

		[DebuggerNonUserCode]
		public DataColumn VchLinkDataColumn => columnVchLinkData;

		[DebuggerNonUserCode]
		public DataColumn DTSortColumn => columnDTSort;

		[DebuggerNonUserCode]
		public DataColumn BillNoColumn => columnBillNo;

		[DebuggerNonUserCode]
		public DataColumn BillDateColumn => columnBillDate;

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
		public DataTable1Row AddDataTable1Row(string VchDate, int CompId, string VchNo, string VchType, string Particulars, double Credit, double Debit, double OtherCharges, string VchLinkData, DateTime DTSort, string BillNo, string BillDate)
		{
			DataTable1Row dataTable1Row = (DataTable1Row)NewRow();
			object[] itemArray = new object[12]
			{
				VchDate, CompId, VchNo, VchType, Particulars, Credit, Debit, OtherCharges, VchLinkData, DTSort,
				BillNo, BillDate
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
			columnVchDate = base.Columns["VchDate"];
			columnCompId = base.Columns["CompId"];
			columnVchNo = base.Columns["VchNo"];
			columnVchType = base.Columns["VchType"];
			columnParticulars = base.Columns["Particulars"];
			columnCredit = base.Columns["Credit"];
			columnDebit = base.Columns["Debit"];
			columnOtherCharges = base.Columns["OtherCharges"];
			columnVchLinkData = base.Columns["VchLinkData"];
			columnDTSort = base.Columns["DTSort"];
			columnBillNo = base.Columns["BillNo"];
			columnBillDate = base.Columns["BillDate"];
		}

		[DebuggerNonUserCode]
		private void InitClass()
		{
			columnVchDate = new DataColumn("VchDate", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnVchDate);
			columnCompId = new DataColumn("CompId", typeof(int), null, MappingType.Element);
			base.Columns.Add(columnCompId);
			columnVchNo = new DataColumn("VchNo", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnVchNo);
			columnVchType = new DataColumn("VchType", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnVchType);
			columnParticulars = new DataColumn("Particulars", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnParticulars);
			columnCredit = new DataColumn("Credit", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnCredit);
			columnDebit = new DataColumn("Debit", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnDebit);
			columnOtherCharges = new DataColumn("OtherCharges", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnOtherCharges);
			columnVchLinkData = new DataColumn("VchLinkData", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnVchLinkData);
			columnDTSort = new DataColumn("DTSort", typeof(DateTime), null, MappingType.Element);
			base.Columns.Add(columnDTSort);
			columnBillNo = new DataColumn("BillNo", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnBillNo);
			columnBillDate = new DataColumn("BillDate", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnBillDate);
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
			CrDrDetails crDrDetails = new CrDrDetails();
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
			xmlSchemaAttribute.FixedValue = crDrDetails.Namespace;
			xmlSchemaComplexType.Attributes.Add(xmlSchemaAttribute);
			XmlSchemaAttribute xmlSchemaAttribute2 = new XmlSchemaAttribute();
			xmlSchemaAttribute2.Name = "tableTypeName";
			xmlSchemaAttribute2.FixedValue = "DataTable1DataTable";
			xmlSchemaComplexType.Attributes.Add(xmlSchemaAttribute2);
			xmlSchemaComplexType.Particle = xmlSchemaSequence;
			XmlSchema schemaSerializable = crDrDetails.GetSchemaSerializable();
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
		public string VchDate
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.VchDateColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'VchDate' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.VchDateColumn] = value;
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
		public string VchNo
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.VchNoColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'VchNo' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.VchNoColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string VchType
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.VchTypeColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'VchType' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.VchTypeColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string Particulars
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.ParticularsColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Particulars' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.ParticularsColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public double Credit
		{
			get
			{
				try
				{
					return (double)base[tableDataTable1.CreditColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Credit' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.CreditColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public double Debit
		{
			get
			{
				try
				{
					return (double)base[tableDataTable1.DebitColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Debit' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.DebitColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public double OtherCharges
		{
			get
			{
				try
				{
					return (double)base[tableDataTable1.OtherChargesColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'OtherCharges' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.OtherChargesColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string VchLinkData
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.VchLinkDataColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'VchLinkData' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.VchLinkDataColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public DateTime DTSort
		{
			get
			{
				try
				{
					return (DateTime)base[tableDataTable1.DTSortColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'DTSort' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.DTSortColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string BillNo
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.BillNoColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'BillNo' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.BillNoColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string BillDate
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.BillDateColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'BillDate' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.BillDateColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		internal DataTable1Row(DataRowBuilder rb)
			: base(rb)
		{
			tableDataTable1 = (DataTable1DataTable)base.Table;
		}

		[DebuggerNonUserCode]
		public bool IsVchDateNull()
		{
			return IsNull(tableDataTable1.VchDateColumn);
		}

		[DebuggerNonUserCode]
		public void SetVchDateNull()
		{
			base[tableDataTable1.VchDateColumn] = Convert.DBNull;
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
		public bool IsVchNoNull()
		{
			return IsNull(tableDataTable1.VchNoColumn);
		}

		[DebuggerNonUserCode]
		public void SetVchNoNull()
		{
			base[tableDataTable1.VchNoColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsVchTypeNull()
		{
			return IsNull(tableDataTable1.VchTypeColumn);
		}

		[DebuggerNonUserCode]
		public void SetVchTypeNull()
		{
			base[tableDataTable1.VchTypeColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsParticularsNull()
		{
			return IsNull(tableDataTable1.ParticularsColumn);
		}

		[DebuggerNonUserCode]
		public void SetParticularsNull()
		{
			base[tableDataTable1.ParticularsColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsCreditNull()
		{
			return IsNull(tableDataTable1.CreditColumn);
		}

		[DebuggerNonUserCode]
		public void SetCreditNull()
		{
			base[tableDataTable1.CreditColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsDebitNull()
		{
			return IsNull(tableDataTable1.DebitColumn);
		}

		[DebuggerNonUserCode]
		public void SetDebitNull()
		{
			base[tableDataTable1.DebitColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsOtherChargesNull()
		{
			return IsNull(tableDataTable1.OtherChargesColumn);
		}

		[DebuggerNonUserCode]
		public void SetOtherChargesNull()
		{
			base[tableDataTable1.OtherChargesColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsVchLinkDataNull()
		{
			return IsNull(tableDataTable1.VchLinkDataColumn);
		}

		[DebuggerNonUserCode]
		public void SetVchLinkDataNull()
		{
			base[tableDataTable1.VchLinkDataColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsDTSortNull()
		{
			return IsNull(tableDataTable1.DTSortColumn);
		}

		[DebuggerNonUserCode]
		public void SetDTSortNull()
		{
			base[tableDataTable1.DTSortColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsBillNoNull()
		{
			return IsNull(tableDataTable1.BillNoColumn);
		}

		[DebuggerNonUserCode]
		public void SetBillNoNull()
		{
			base[tableDataTable1.BillNoColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsBillDateNull()
		{
			return IsNull(tableDataTable1.BillDateColumn);
		}

		[DebuggerNonUserCode]
		public void SetBillDateNull()
		{
			base[tableDataTable1.BillDateColumn] = Convert.DBNull;
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
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
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

	[DebuggerNonUserCode]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataRelationCollection Relations => base.Relations;

	[DebuggerNonUserCode]
	public CrDrDetails()
	{
		BeginInit();
		InitClass();
		CollectionChangeEventHandler value = SchemaChanged;
		base.Tables.CollectionChanged += value;
		base.Relations.CollectionChanged += value;
		EndInit();
	}

	[DebuggerNonUserCode]
	protected CrDrDetails(SerializationInfo info, StreamingContext context)
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
		CrDrDetails crDrDetails = (CrDrDetails)base.Clone();
		crDrDetails.InitVars();
		crDrDetails.SchemaSerializationMode = SchemaSerializationMode;
		return crDrDetails;
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
		base.DataSetName = "CrDrDetails";
		base.Prefix = "";
		base.Namespace = "http://tempuri.org/CrDrDetails.xsd";
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
		CrDrDetails crDrDetails = new CrDrDetails();
		XmlSchemaComplexType xmlSchemaComplexType = new XmlSchemaComplexType();
		XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
		XmlSchemaAny xmlSchemaAny = new XmlSchemaAny();
		xmlSchemaAny.Namespace = crDrDetails.Namespace;
		xmlSchemaSequence.Items.Add(xmlSchemaAny);
		xmlSchemaComplexType.Particle = xmlSchemaSequence;
		XmlSchema schemaSerializable = crDrDetails.GetSchemaSerializable();
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
