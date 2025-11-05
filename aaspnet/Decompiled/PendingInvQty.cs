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
[XmlRoot("PendingInvQty")]
[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
[DesignerCategory("code")]
[ToolboxItem(true)]
public class PendingInvQty : DataSet
{
	public delegate void DataTable1RowChangeEventHandler(object sender, DataTable1RowChangeEvent e);

	public delegate void DataTable2RowChangeEventHandler(object sender, DataTable2RowChangeEvent e);

	[Serializable]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
	[XmlSchemaProvider("GetTypedTableSchema")]
	public class DataTable1DataTable : TypedTableBase<DataTable1Row>
	{
		private DataColumn columnWONo;

		private DataColumn columnPONo;

		private DataColumn columnItemCode;

		private DataColumn columnDescription;

		private DataColumn columnUOM;

		private DataColumn columnQty;

		private DataColumn columnInvoiceQty;

		private DataColumn columnPendingInvoiceQty;

		private DataColumn columnCustomerCode;

		private DataColumn columnRate;

		private DataColumn columnDiscount;

		[DebuggerNonUserCode]
		public DataColumn WONoColumn => columnWONo;

		[DebuggerNonUserCode]
		public DataColumn PONoColumn => columnPONo;

		[DebuggerNonUserCode]
		public DataColumn ItemCodeColumn => columnItemCode;

		[DebuggerNonUserCode]
		public DataColumn DescriptionColumn => columnDescription;

		[DebuggerNonUserCode]
		public DataColumn UOMColumn => columnUOM;

		[DebuggerNonUserCode]
		public DataColumn QtyColumn => columnQty;

		[DebuggerNonUserCode]
		public DataColumn InvoiceQtyColumn => columnInvoiceQty;

		[DebuggerNonUserCode]
		public DataColumn PendingInvoiceQtyColumn => columnPendingInvoiceQty;

		[DebuggerNonUserCode]
		public DataColumn CustomerCodeColumn => columnCustomerCode;

		[DebuggerNonUserCode]
		public DataColumn RateColumn => columnRate;

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
		public DataTable1Row AddDataTable1Row(string WONo, string PONo, string ItemCode, string Description, string UOM, double Qty, double InvoiceQty, double PendingInvoiceQty, string CustomerCode, double Rate, double Discount)
		{
			DataTable1Row dataTable1Row = (DataTable1Row)NewRow();
			object[] itemArray = new object[11]
			{
				WONo, PONo, ItemCode, Description, UOM, Qty, InvoiceQty, PendingInvoiceQty, CustomerCode, Rate,
				Discount
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
			columnWONo = base.Columns["WONo"];
			columnPONo = base.Columns["PONo"];
			columnItemCode = base.Columns["ItemCode"];
			columnDescription = base.Columns["Description"];
			columnUOM = base.Columns["UOM"];
			columnQty = base.Columns["Qty"];
			columnInvoiceQty = base.Columns["InvoiceQty"];
			columnPendingInvoiceQty = base.Columns["PendingInvoiceQty"];
			columnCustomerCode = base.Columns["CustomerCode"];
			columnRate = base.Columns["Rate"];
			columnDiscount = base.Columns["Discount"];
		}

		[DebuggerNonUserCode]
		private void InitClass()
		{
			columnWONo = new DataColumn("WONo", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnWONo);
			columnPONo = new DataColumn("PONo", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnPONo);
			columnItemCode = new DataColumn("ItemCode", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnItemCode);
			columnDescription = new DataColumn("Description", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnDescription);
			columnUOM = new DataColumn("UOM", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnUOM);
			columnQty = new DataColumn("Qty", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnQty);
			columnInvoiceQty = new DataColumn("InvoiceQty", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnInvoiceQty);
			columnPendingInvoiceQty = new DataColumn("PendingInvoiceQty", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnPendingInvoiceQty);
			columnCustomerCode = new DataColumn("CustomerCode", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnCustomerCode);
			columnRate = new DataColumn("Rate", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnRate);
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
			PendingInvQty pendingInvQty = new PendingInvQty();
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
			xmlSchemaAttribute.FixedValue = pendingInvQty.Namespace;
			xmlSchemaComplexType.Attributes.Add(xmlSchemaAttribute);
			XmlSchemaAttribute xmlSchemaAttribute2 = new XmlSchemaAttribute();
			xmlSchemaAttribute2.Name = "tableTypeName";
			xmlSchemaAttribute2.FixedValue = "DataTable1DataTable";
			xmlSchemaComplexType.Attributes.Add(xmlSchemaAttribute2);
			xmlSchemaComplexType.Particle = xmlSchemaSequence;
			XmlSchema schemaSerializable = pendingInvQty.GetSchemaSerializable();
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

	[Serializable]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
	[XmlSchemaProvider("GetTypedTableSchema")]
	public class DataTable2DataTable : TypedTableBase<DataTable2Row>
	{
		private DataColumn columnCustomerCode;

		private DataColumn columnCustomerName;

		private DataColumn columnCompId;

		[DebuggerNonUserCode]
		public DataColumn CustomerCodeColumn => columnCustomerCode;

		[DebuggerNonUserCode]
		public DataColumn CustomerNameColumn => columnCustomerName;

		[DebuggerNonUserCode]
		public DataColumn CompIdColumn => columnCompId;

		[DebuggerNonUserCode]
		[Browsable(false)]
		public int Count => base.Rows.Count;

		[DebuggerNonUserCode]
		public DataTable2Row this[int index] => (DataTable2Row)base.Rows[index];

		public event DataTable2RowChangeEventHandler DataTable2RowChanging;

		public event DataTable2RowChangeEventHandler DataTable2RowChanged;

		public event DataTable2RowChangeEventHandler DataTable2RowDeleting;

		public event DataTable2RowChangeEventHandler DataTable2RowDeleted;

		[DebuggerNonUserCode]
		public DataTable2DataTable()
		{
			base.TableName = "DataTable2";
			BeginInit();
			InitClass();
			EndInit();
		}

		[DebuggerNonUserCode]
		internal DataTable2DataTable(DataTable table)
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
		protected DataTable2DataTable(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
			InitVars();
		}

		[DebuggerNonUserCode]
		public void AddDataTable2Row(DataTable2Row row)
		{
			base.Rows.Add(row);
		}

		[DebuggerNonUserCode]
		public DataTable2Row AddDataTable2Row(DataTable1Row parentDataTable1RowByDataTable1_DataTable2, string CustomerName, int CompId)
		{
			DataTable2Row dataTable2Row = (DataTable2Row)NewRow();
			object[] array = new object[3] { null, CustomerName, CompId };
			if (parentDataTable1RowByDataTable1_DataTable2 != null)
			{
				array[0] = parentDataTable1RowByDataTable1_DataTable2[8];
			}
			dataTable2Row.ItemArray = array;
			base.Rows.Add(dataTable2Row);
			return dataTable2Row;
		}

		[DebuggerNonUserCode]
		public override DataTable Clone()
		{
			DataTable2DataTable dataTable2DataTable = (DataTable2DataTable)base.Clone();
			dataTable2DataTable.InitVars();
			return dataTable2DataTable;
		}

		[DebuggerNonUserCode]
		protected override DataTable CreateInstance()
		{
			return new DataTable2DataTable();
		}

		[DebuggerNonUserCode]
		internal void InitVars()
		{
			columnCustomerCode = base.Columns["CustomerCode"];
			columnCustomerName = base.Columns["CustomerName"];
			columnCompId = base.Columns["CompId"];
		}

		[DebuggerNonUserCode]
		private void InitClass()
		{
			columnCustomerCode = new DataColumn("CustomerCode", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnCustomerCode);
			columnCustomerName = new DataColumn("CustomerName", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnCustomerName);
			columnCompId = new DataColumn("CompId", typeof(int), null, MappingType.Element);
			base.Columns.Add(columnCompId);
		}

		[DebuggerNonUserCode]
		public DataTable2Row NewDataTable2Row()
		{
			return (DataTable2Row)NewRow();
		}

		[DebuggerNonUserCode]
		protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
		{
			return new DataTable2Row(builder);
		}

		[DebuggerNonUserCode]
		protected override Type GetRowType()
		{
			return typeof(DataTable2Row);
		}

		[DebuggerNonUserCode]
		protected override void OnRowChanged(DataRowChangeEventArgs e)
		{
			base.OnRowChanged(e);
			if (this.DataTable2RowChanged != null)
			{
				this.DataTable2RowChanged(this, new DataTable2RowChangeEvent((DataTable2Row)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		protected override void OnRowChanging(DataRowChangeEventArgs e)
		{
			base.OnRowChanging(e);
			if (this.DataTable2RowChanging != null)
			{
				this.DataTable2RowChanging(this, new DataTable2RowChangeEvent((DataTable2Row)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		protected override void OnRowDeleted(DataRowChangeEventArgs e)
		{
			base.OnRowDeleted(e);
			if (this.DataTable2RowDeleted != null)
			{
				this.DataTable2RowDeleted(this, new DataTable2RowChangeEvent((DataTable2Row)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		protected override void OnRowDeleting(DataRowChangeEventArgs e)
		{
			base.OnRowDeleting(e);
			if (this.DataTable2RowDeleting != null)
			{
				this.DataTable2RowDeleting(this, new DataTable2RowChangeEvent((DataTable2Row)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		public void RemoveDataTable2Row(DataTable2Row row)
		{
			base.Rows.Remove(row);
		}

		[DebuggerNonUserCode]
		public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
		{
			XmlSchemaComplexType xmlSchemaComplexType = new XmlSchemaComplexType();
			XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
			PendingInvQty pendingInvQty = new PendingInvQty();
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
			xmlSchemaAttribute.FixedValue = pendingInvQty.Namespace;
			xmlSchemaComplexType.Attributes.Add(xmlSchemaAttribute);
			XmlSchemaAttribute xmlSchemaAttribute2 = new XmlSchemaAttribute();
			xmlSchemaAttribute2.Name = "tableTypeName";
			xmlSchemaAttribute2.FixedValue = "DataTable2DataTable";
			xmlSchemaComplexType.Attributes.Add(xmlSchemaAttribute2);
			xmlSchemaComplexType.Particle = xmlSchemaSequence;
			XmlSchema schemaSerializable = pendingInvQty.GetSchemaSerializable();
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
		public string PONo
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.PONoColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'PONo' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.PONoColumn] = value;
			}
		}

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
		public string UOM
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.UOMColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'UOM' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.UOMColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public double Qty
		{
			get
			{
				try
				{
					return (double)base[tableDataTable1.QtyColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Qty' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.QtyColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public double InvoiceQty
		{
			get
			{
				try
				{
					return (double)base[tableDataTable1.InvoiceQtyColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'InvoiceQty' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.InvoiceQtyColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public double PendingInvoiceQty
		{
			get
			{
				try
				{
					return (double)base[tableDataTable1.PendingInvoiceQtyColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'PendingInvoiceQty' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.PendingInvoiceQtyColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string CustomerCode
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.CustomerCodeColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'CustomerCode' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.CustomerCodeColumn] = value;
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
		public bool IsPONoNull()
		{
			return IsNull(tableDataTable1.PONoColumn);
		}

		[DebuggerNonUserCode]
		public void SetPONoNull()
		{
			base[tableDataTable1.PONoColumn] = Convert.DBNull;
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
		public bool IsUOMNull()
		{
			return IsNull(tableDataTable1.UOMColumn);
		}

		[DebuggerNonUserCode]
		public void SetUOMNull()
		{
			base[tableDataTable1.UOMColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsQtyNull()
		{
			return IsNull(tableDataTable1.QtyColumn);
		}

		[DebuggerNonUserCode]
		public void SetQtyNull()
		{
			base[tableDataTable1.QtyColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsInvoiceQtyNull()
		{
			return IsNull(tableDataTable1.InvoiceQtyColumn);
		}

		[DebuggerNonUserCode]
		public void SetInvoiceQtyNull()
		{
			base[tableDataTable1.InvoiceQtyColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsPendingInvoiceQtyNull()
		{
			return IsNull(tableDataTable1.PendingInvoiceQtyColumn);
		}

		[DebuggerNonUserCode]
		public void SetPendingInvoiceQtyNull()
		{
			base[tableDataTable1.PendingInvoiceQtyColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsCustomerCodeNull()
		{
			return IsNull(tableDataTable1.CustomerCodeColumn);
		}

		[DebuggerNonUserCode]
		public void SetCustomerCodeNull()
		{
			base[tableDataTable1.CustomerCodeColumn] = Convert.DBNull;
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
		public bool IsDiscountNull()
		{
			return IsNull(tableDataTable1.DiscountColumn);
		}

		[DebuggerNonUserCode]
		public void SetDiscountNull()
		{
			base[tableDataTable1.DiscountColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public DataTable2Row[] GetDataTable2Rows()
		{
			if (base.Table.ChildRelations["DataTable1_DataTable2"] == null)
			{
				return new DataTable2Row[0];
			}
			return (DataTable2Row[])GetChildRows(base.Table.ChildRelations["DataTable1_DataTable2"]);
		}
	}

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
	public class DataTable2Row : DataRow
	{
		private DataTable2DataTable tableDataTable2;

		[DebuggerNonUserCode]
		public string CustomerCode
		{
			get
			{
				try
				{
					return (string)base[tableDataTable2.CustomerCodeColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'CustomerCode' in table 'DataTable2' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable2.CustomerCodeColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string CustomerName
		{
			get
			{
				try
				{
					return (string)base[tableDataTable2.CustomerNameColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'CustomerName' in table 'DataTable2' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable2.CustomerNameColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public int CompId
		{
			get
			{
				try
				{
					return (int)base[tableDataTable2.CompIdColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'CompId' in table 'DataTable2' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable2.CompIdColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public DataTable1Row DataTable1Row
		{
			get
			{
				return (DataTable1Row)GetParentRow(base.Table.ParentRelations["DataTable1_DataTable2"]);
			}
			set
			{
				SetParentRow(value, base.Table.ParentRelations["DataTable1_DataTable2"]);
			}
		}

		[DebuggerNonUserCode]
		internal DataTable2Row(DataRowBuilder rb)
			: base(rb)
		{
			tableDataTable2 = (DataTable2DataTable)base.Table;
		}

		[DebuggerNonUserCode]
		public bool IsCustomerCodeNull()
		{
			return IsNull(tableDataTable2.CustomerCodeColumn);
		}

		[DebuggerNonUserCode]
		public void SetCustomerCodeNull()
		{
			base[tableDataTable2.CustomerCodeColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsCustomerNameNull()
		{
			return IsNull(tableDataTable2.CustomerNameColumn);
		}

		[DebuggerNonUserCode]
		public void SetCustomerNameNull()
		{
			base[tableDataTable2.CustomerNameColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsCompIdNull()
		{
			return IsNull(tableDataTable2.CompIdColumn);
		}

		[DebuggerNonUserCode]
		public void SetCompIdNull()
		{
			base[tableDataTable2.CompIdColumn] = Convert.DBNull;
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

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
	public class DataTable2RowChangeEvent : EventArgs
	{
		private DataTable2Row eventRow;

		private DataRowAction eventAction;

		[DebuggerNonUserCode]
		public DataTable2Row Row => eventRow;

		[DebuggerNonUserCode]
		public DataRowAction Action => eventAction;

		[DebuggerNonUserCode]
		public DataTable2RowChangeEvent(DataTable2Row row, DataRowAction action)
		{
			eventRow = row;
			eventAction = action;
		}
	}

	private DataTable1DataTable tableDataTable1;

	private DataTable2DataTable tableDataTable2;

	private DataRelation relationDataTable1_DataTable2;

	private SchemaSerializationMode _schemaSerializationMode = SchemaSerializationMode.IncludeSchema;

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	[DebuggerNonUserCode]
	public DataTable1DataTable DataTable1 => tableDataTable1;

	[DebuggerNonUserCode]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	[Browsable(false)]
	public DataTable2DataTable DataTable2 => tableDataTable2;

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

	[DebuggerNonUserCode]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[DebuggerNonUserCode]
	public new DataRelationCollection Relations => base.Relations;

	[DebuggerNonUserCode]
	public PendingInvQty()
	{
		BeginInit();
		InitClass();
		CollectionChangeEventHandler value = SchemaChanged;
		base.Tables.CollectionChanged += value;
		base.Relations.CollectionChanged += value;
		EndInit();
	}

	[DebuggerNonUserCode]
	protected PendingInvQty(SerializationInfo info, StreamingContext context)
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
			if (dataSet.Tables["DataTable2"] != null)
			{
				base.Tables.Add(new DataTable2DataTable(dataSet.Tables["DataTable2"]));
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
		PendingInvQty pendingInvQty = (PendingInvQty)base.Clone();
		pendingInvQty.InitVars();
		pendingInvQty.SchemaSerializationMode = SchemaSerializationMode;
		return pendingInvQty;
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
			if (dataSet.Tables["DataTable2"] != null)
			{
				base.Tables.Add(new DataTable2DataTable(dataSet.Tables["DataTable2"]));
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
		tableDataTable2 = (DataTable2DataTable)base.Tables["DataTable2"];
		if (initTable && tableDataTable2 != null)
		{
			tableDataTable2.InitVars();
		}
		relationDataTable1_DataTable2 = Relations["DataTable1_DataTable2"];
	}

	[DebuggerNonUserCode]
	private void InitClass()
	{
		base.DataSetName = "PendingInvQty";
		base.Prefix = "";
		base.Namespace = "http://tempuri.org/PendingInvQty.xsd";
		base.EnforceConstraints = true;
		SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
		tableDataTable1 = new DataTable1DataTable();
		base.Tables.Add(tableDataTable1);
		tableDataTable2 = new DataTable2DataTable();
		base.Tables.Add(tableDataTable2);
		relationDataTable1_DataTable2 = new DataRelation("DataTable1_DataTable2", new DataColumn[1] { tableDataTable1.CustomerCodeColumn }, new DataColumn[1] { tableDataTable2.CustomerCodeColumn }, createConstraints: false);
		Relations.Add(relationDataTable1_DataTable2);
	}

	[DebuggerNonUserCode]
	private bool ShouldSerializeDataTable1()
	{
		return false;
	}

	[DebuggerNonUserCode]
	private bool ShouldSerializeDataTable2()
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
		PendingInvQty pendingInvQty = new PendingInvQty();
		XmlSchemaComplexType xmlSchemaComplexType = new XmlSchemaComplexType();
		XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
		XmlSchemaAny xmlSchemaAny = new XmlSchemaAny();
		xmlSchemaAny.Namespace = pendingInvQty.Namespace;
		xmlSchemaSequence.Items.Add(xmlSchemaAny);
		xmlSchemaComplexType.Particle = xmlSchemaSequence;
		XmlSchema schemaSerializable = pendingInvQty.GetSchemaSerializable();
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
