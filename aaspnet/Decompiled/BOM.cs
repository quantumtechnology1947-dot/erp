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
[HelpKeyword("vs.data.DataSet")]
[XmlRoot("BOM")]
[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
[DesignerCategory("code")]
[ToolboxItem(true)]
[XmlSchemaProvider("GetTypedDataSetSchema")]
public class BOM : DataSet
{
	public delegate void DataTable1RowChangeEventHandler(object sender, DataTable1RowChangeEvent e);

	public delegate void DataTable2RowChangeEventHandler(object sender, DataTable2RowChangeEvent e);

	[Serializable]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
	[XmlSchemaProvider("GetTypedTableSchema")]
	public class DataTable1DataTable : TypedTableBase<DataTable1Row>
	{
		private DataColumn columnItemCode;

		private DataColumn columnManfDesc;

		private DataColumn columnUOM;

		private DataColumn columnQty;

		private DataColumn columnBOMQty;

		private DataColumn columnWONo;

		private DataColumn columnCompId;

		private DataColumn columnAC;

		private DataColumn columnStartDate;

		private DataColumn columnRate;

		private DataColumn columnAmount;

		private DataColumn columnRevision;

		[DebuggerNonUserCode]
		public DataColumn ItemCodeColumn => columnItemCode;

		[DebuggerNonUserCode]
		public DataColumn ManfDescColumn => columnManfDesc;

		[DebuggerNonUserCode]
		public DataColumn UOMColumn => columnUOM;

		[DebuggerNonUserCode]
		public DataColumn QtyColumn => columnQty;

		[DebuggerNonUserCode]
		public DataColumn BOMQtyColumn => columnBOMQty;

		[DebuggerNonUserCode]
		public DataColumn WONoColumn => columnWONo;

		[DebuggerNonUserCode]
		public DataColumn CompIdColumn => columnCompId;

		[DebuggerNonUserCode]
		public DataColumn ACColumn => columnAC;

		[DebuggerNonUserCode]
		public DataColumn StartDateColumn => columnStartDate;

		[DebuggerNonUserCode]
		public DataColumn RateColumn => columnRate;

		[DebuggerNonUserCode]
		public DataColumn AmountColumn => columnAmount;

		[DebuggerNonUserCode]
		public DataColumn RevisionColumn => columnRevision;

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
		public DataTable1Row AddDataTable1Row(string ItemCode, string ManfDesc, string UOM, double Qty, double BOMQty, DataTable2Row parentDataTable2RowByDataTable2_DataTable1, int CompId, string AC, string StartDate, double Rate, double Amount, string Revision)
		{
			DataTable1Row dataTable1Row = (DataTable1Row)NewRow();
			object[] array = new object[12]
			{
				ItemCode, ManfDesc, UOM, Qty, BOMQty, null, CompId, AC, StartDate, Rate,
				Amount, Revision
			};
			if (parentDataTable2RowByDataTable2_DataTable1 != null)
			{
				array[5] = parentDataTable2RowByDataTable2_DataTable1[1];
			}
			dataTable1Row.ItemArray = array;
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
			columnUOM = base.Columns["UOM"];
			columnQty = base.Columns["Qty"];
			columnBOMQty = base.Columns["BOMQty"];
			columnWONo = base.Columns["WONo"];
			columnCompId = base.Columns["CompId"];
			columnAC = base.Columns["AC"];
			columnStartDate = base.Columns["StartDate"];
			columnRate = base.Columns["Rate"];
			columnAmount = base.Columns["Amount"];
			columnRevision = base.Columns["Revision"];
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
			columnBOMQty = new DataColumn("BOMQty", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnBOMQty);
			columnWONo = new DataColumn("WONo", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnWONo);
			columnCompId = new DataColumn("CompId", typeof(int), null, MappingType.Element);
			base.Columns.Add(columnCompId);
			columnAC = new DataColumn("AC", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnAC);
			columnStartDate = new DataColumn("StartDate", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnStartDate);
			columnRate = new DataColumn("Rate", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnRate);
			columnAmount = new DataColumn("Amount", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnAmount);
			columnRevision = new DataColumn("Revision", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnRevision);
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
			BOM bOM = new BOM();
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
			xmlSchemaAttribute.FixedValue = bOM.Namespace;
			xmlSchemaComplexType.Attributes.Add(xmlSchemaAttribute);
			XmlSchemaAttribute xmlSchemaAttribute2 = new XmlSchemaAttribute();
			xmlSchemaAttribute2.Name = "tableTypeName";
			xmlSchemaAttribute2.FixedValue = "DataTable1DataTable";
			xmlSchemaComplexType.Attributes.Add(xmlSchemaAttribute2);
			xmlSchemaComplexType.Particle = xmlSchemaSequence;
			XmlSchema schemaSerializable = bOM.GetSchemaSerializable();
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
		private DataColumn columnId;

		private DataColumn columnWONo;

		private DataColumn columnPitch;

		private DataColumn columnType;

		private DataColumn columnLongrailNo;

		private DataColumn columnLongrailLength;

		private DataColumn columnCrossrailLength;

		private DataColumn columnCrossrailNo;

		[DebuggerNonUserCode]
		public DataColumn IdColumn => columnId;

		[DebuggerNonUserCode]
		public DataColumn WONoColumn => columnWONo;

		[DebuggerNonUserCode]
		public DataColumn PitchColumn => columnPitch;

		[DebuggerNonUserCode]
		public DataColumn TypeColumn => columnType;

		[DebuggerNonUserCode]
		public DataColumn LongrailNoColumn => columnLongrailNo;

		[DebuggerNonUserCode]
		public DataColumn LongrailLengthColumn => columnLongrailLength;

		[DebuggerNonUserCode]
		public DataColumn CrossrailLengthColumn => columnCrossrailLength;

		[DebuggerNonUserCode]
		public DataColumn CrossrailNoColumn => columnCrossrailNo;

		[Browsable(false)]
		[DebuggerNonUserCode]
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
		public DataTable2Row AddDataTable2Row(int Id, string WONo, double Pitch, string Type, double LongrailNo, double LongrailLength, double CrossrailLength, double CrossrailNo)
		{
			DataTable2Row dataTable2Row = (DataTable2Row)NewRow();
			object[] itemArray = new object[8] { Id, WONo, Pitch, Type, LongrailNo, LongrailLength, CrossrailLength, CrossrailNo };
			dataTable2Row.ItemArray = itemArray;
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
			columnId = base.Columns["Id"];
			columnWONo = base.Columns["WONo"];
			columnPitch = base.Columns["Pitch"];
			columnType = base.Columns["Type"];
			columnLongrailNo = base.Columns["LongrailNo"];
			columnLongrailLength = base.Columns["LongrailLength"];
			columnCrossrailLength = base.Columns["CrossrailLength"];
			columnCrossrailNo = base.Columns["CrossrailNo"];
		}

		[DebuggerNonUserCode]
		private void InitClass()
		{
			columnId = new DataColumn("Id", typeof(int), null, MappingType.Element);
			base.Columns.Add(columnId);
			columnWONo = new DataColumn("WONo", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnWONo);
			columnPitch = new DataColumn("Pitch", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnPitch);
			columnType = new DataColumn("Type", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnType);
			columnLongrailNo = new DataColumn("LongrailNo", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnLongrailNo);
			columnLongrailLength = new DataColumn("LongrailLength", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnLongrailLength);
			columnCrossrailLength = new DataColumn("CrossrailLength", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnCrossrailLength);
			columnCrossrailNo = new DataColumn("CrossrailNo", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnCrossrailNo);
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
			BOM bOM = new BOM();
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
			xmlSchemaAttribute.FixedValue = bOM.Namespace;
			xmlSchemaComplexType.Attributes.Add(xmlSchemaAttribute);
			XmlSchemaAttribute xmlSchemaAttribute2 = new XmlSchemaAttribute();
			xmlSchemaAttribute2.Name = "tableTypeName";
			xmlSchemaAttribute2.FixedValue = "DataTable2DataTable";
			xmlSchemaComplexType.Attributes.Add(xmlSchemaAttribute2);
			xmlSchemaComplexType.Particle = xmlSchemaSequence;
			XmlSchema schemaSerializable = bOM.GetSchemaSerializable();
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
		public string StartDate
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.StartDateColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'StartDate' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.StartDateColumn] = value;
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
		public string Revision
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.RevisionColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Revision' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.RevisionColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public DataTable2Row DataTable2Row
		{
			get
			{
				return (DataTable2Row)GetParentRow(base.Table.ParentRelations["DataTable2_DataTable1"]);
			}
			set
			{
				SetParentRow(value, base.Table.ParentRelations["DataTable2_DataTable1"]);
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
		public bool IsStartDateNull()
		{
			return IsNull(tableDataTable1.StartDateColumn);
		}

		[DebuggerNonUserCode]
		public void SetStartDateNull()
		{
			base[tableDataTable1.StartDateColumn] = Convert.DBNull;
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

		[DebuggerNonUserCode]
		public bool IsRevisionNull()
		{
			return IsNull(tableDataTable1.RevisionColumn);
		}

		[DebuggerNonUserCode]
		public void SetRevisionNull()
		{
			base[tableDataTable1.RevisionColumn] = Convert.DBNull;
		}
	}

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
	public class DataTable2Row : DataRow
	{
		private DataTable2DataTable tableDataTable2;

		[DebuggerNonUserCode]
		public int Id
		{
			get
			{
				try
				{
					return (int)base[tableDataTable2.IdColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Id' in table 'DataTable2' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable2.IdColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string WONo
		{
			get
			{
				try
				{
					return (string)base[tableDataTable2.WONoColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'WONo' in table 'DataTable2' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable2.WONoColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public double Pitch
		{
			get
			{
				try
				{
					return (double)base[tableDataTable2.PitchColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Pitch' in table 'DataTable2' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable2.PitchColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string Type
		{
			get
			{
				try
				{
					return (string)base[tableDataTable2.TypeColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Type' in table 'DataTable2' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable2.TypeColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public double LongrailNo
		{
			get
			{
				try
				{
					return (double)base[tableDataTable2.LongrailNoColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'LongrailNo' in table 'DataTable2' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable2.LongrailNoColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public double LongrailLength
		{
			get
			{
				try
				{
					return (double)base[tableDataTable2.LongrailLengthColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'LongrailLength' in table 'DataTable2' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable2.LongrailLengthColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public double CrossrailLength
		{
			get
			{
				try
				{
					return (double)base[tableDataTable2.CrossrailLengthColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'CrossrailLength' in table 'DataTable2' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable2.CrossrailLengthColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public double CrossrailNo
		{
			get
			{
				try
				{
					return (double)base[tableDataTable2.CrossrailNoColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'CrossrailNo' in table 'DataTable2' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable2.CrossrailNoColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		internal DataTable2Row(DataRowBuilder rb)
			: base(rb)
		{
			tableDataTable2 = (DataTable2DataTable)base.Table;
		}

		[DebuggerNonUserCode]
		public bool IsIdNull()
		{
			return IsNull(tableDataTable2.IdColumn);
		}

		[DebuggerNonUserCode]
		public void SetIdNull()
		{
			base[tableDataTable2.IdColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsWONoNull()
		{
			return IsNull(tableDataTable2.WONoColumn);
		}

		[DebuggerNonUserCode]
		public void SetWONoNull()
		{
			base[tableDataTable2.WONoColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsPitchNull()
		{
			return IsNull(tableDataTable2.PitchColumn);
		}

		[DebuggerNonUserCode]
		public void SetPitchNull()
		{
			base[tableDataTable2.PitchColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsTypeNull()
		{
			return IsNull(tableDataTable2.TypeColumn);
		}

		[DebuggerNonUserCode]
		public void SetTypeNull()
		{
			base[tableDataTable2.TypeColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsLongrailNoNull()
		{
			return IsNull(tableDataTable2.LongrailNoColumn);
		}

		[DebuggerNonUserCode]
		public void SetLongrailNoNull()
		{
			base[tableDataTable2.LongrailNoColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsLongrailLengthNull()
		{
			return IsNull(tableDataTable2.LongrailLengthColumn);
		}

		[DebuggerNonUserCode]
		public void SetLongrailLengthNull()
		{
			base[tableDataTable2.LongrailLengthColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsCrossrailLengthNull()
		{
			return IsNull(tableDataTable2.CrossrailLengthColumn);
		}

		[DebuggerNonUserCode]
		public void SetCrossrailLengthNull()
		{
			base[tableDataTable2.CrossrailLengthColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsCrossrailNoNull()
		{
			return IsNull(tableDataTable2.CrossrailNoColumn);
		}

		[DebuggerNonUserCode]
		public void SetCrossrailNoNull()
		{
			base[tableDataTable2.CrossrailNoColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public DataTable1Row[] GetDataTable1Rows()
		{
			if (base.Table.ChildRelations["DataTable2_DataTable1"] == null)
			{
				return new DataTable1Row[0];
			}
			return (DataTable1Row[])GetChildRows(base.Table.ChildRelations["DataTable2_DataTable1"]);
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

	private DataRelation relationDataTable2_DataTable1;

	private SchemaSerializationMode _schemaSerializationMode = SchemaSerializationMode.IncludeSchema;

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	[DebuggerNonUserCode]
	public DataTable1DataTable DataTable1 => tableDataTable1;

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	[DebuggerNonUserCode]
	public DataTable2DataTable DataTable2 => tableDataTable2;

	[DebuggerNonUserCode]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
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
	public BOM()
	{
		BeginInit();
		InitClass();
		CollectionChangeEventHandler value = SchemaChanged;
		base.Tables.CollectionChanged += value;
		base.Relations.CollectionChanged += value;
		EndInit();
	}

	[DebuggerNonUserCode]
	protected BOM(SerializationInfo info, StreamingContext context)
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
		BOM bOM = (BOM)base.Clone();
		bOM.InitVars();
		bOM.SchemaSerializationMode = SchemaSerializationMode;
		return bOM;
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
		relationDataTable2_DataTable1 = Relations["DataTable2_DataTable1"];
	}

	[DebuggerNonUserCode]
	private void InitClass()
	{
		base.DataSetName = "BOM";
		base.Prefix = "";
		base.Namespace = "http://tempuri.org/BOM.xsd";
		base.EnforceConstraints = true;
		SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
		tableDataTable1 = new DataTable1DataTable();
		base.Tables.Add(tableDataTable1);
		tableDataTable2 = new DataTable2DataTable();
		base.Tables.Add(tableDataTable2);
		relationDataTable2_DataTable1 = new DataRelation("DataTable2_DataTable1", new DataColumn[1] { tableDataTable2.WONoColumn }, new DataColumn[1] { tableDataTable1.WONoColumn }, createConstraints: false);
		Relations.Add(relationDataTable2_DataTable1);
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
		BOM bOM = new BOM();
		XmlSchemaComplexType xmlSchemaComplexType = new XmlSchemaComplexType();
		XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
		XmlSchemaAny xmlSchemaAny = new XmlSchemaAny();
		xmlSchemaAny.Namespace = bOM.Namespace;
		xmlSchemaSequence.Items.Add(xmlSchemaAny);
		xmlSchemaComplexType.Particle = xmlSchemaSequence;
		XmlSchema schemaSerializable = bOM.GetSchemaSerializable();
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
