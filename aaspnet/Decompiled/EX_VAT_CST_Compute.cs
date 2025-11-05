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
[XmlRoot("EX_VAT_CST_Compute")]
[HelpKeyword("vs.data.DataSet")]
[DesignerCategory("code")]
[ToolboxItem(true)]
[XmlSchemaProvider("GetTypedDataSetSchema")]
public class EX_VAT_CST_Compute : DataSet
{
	public delegate void DataTable1RowChangeEventHandler(object sender, DataTable1RowChangeEvent e);

	public delegate void DataTable2RowChangeEventHandler(object sender, DataTable2RowChangeEvent e);

	public delegate void DataTable3RowChangeEventHandler(object sender, DataTable3RowChangeEvent e);

	public delegate void DataTable4RowChangeEventHandler(object sender, DataTable4RowChangeEvent e);

	public delegate void DataTable5RowChangeEventHandler(object sender, DataTable5RowChangeEvent e);

	public delegate void DataTable6RowChangeEventHandler(object sender, DataTable6RowChangeEvent e);

	[Serializable]
	[XmlSchemaProvider("GetTypedTableSchema")]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
	public class DataTable1DataTable : TypedTableBase<DataTable1Row>
	{
		private DataColumn columnCompId;

		private DataColumn columnVATerms;

		private DataColumn columnVATAmt;

		[DebuggerNonUserCode]
		public DataColumn CompIdColumn => columnCompId;

		[DebuggerNonUserCode]
		public DataColumn VATermsColumn => columnVATerms;

		[DebuggerNonUserCode]
		public DataColumn VATAmtColumn => columnVATAmt;

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
		public DataTable1Row AddDataTable1Row(int CompId, string VATerms, double VATAmt)
		{
			DataTable1Row dataTable1Row = (DataTable1Row)NewRow();
			object[] itemArray = new object[3] { CompId, VATerms, VATAmt };
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
			columnVATerms = base.Columns["VATerms"];
			columnVATAmt = base.Columns["VATAmt"];
		}

		[DebuggerNonUserCode]
		private void InitClass()
		{
			columnCompId = new DataColumn("CompId", typeof(int), null, MappingType.Element);
			base.Columns.Add(columnCompId);
			columnVATerms = new DataColumn("VATerms", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnVATerms);
			columnVATAmt = new DataColumn("VATAmt", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnVATAmt);
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
			EX_VAT_CST_Compute eX_VAT_CST_Compute = new EX_VAT_CST_Compute();
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
			xmlSchemaAttribute.FixedValue = eX_VAT_CST_Compute.Namespace;
			xmlSchemaComplexType.Attributes.Add(xmlSchemaAttribute);
			XmlSchemaAttribute xmlSchemaAttribute2 = new XmlSchemaAttribute();
			xmlSchemaAttribute2.Name = "tableTypeName";
			xmlSchemaAttribute2.FixedValue = "DataTable1DataTable";
			xmlSchemaComplexType.Attributes.Add(xmlSchemaAttribute2);
			xmlSchemaComplexType.Particle = xmlSchemaSequence;
			XmlSchema schemaSerializable = eX_VAT_CST_Compute.GetSchemaSerializable();
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
		private DataColumn columnCSTerms;

		private DataColumn columnCSTAmt;

		[DebuggerNonUserCode]
		public DataColumn CSTermsColumn => columnCSTerms;

		[DebuggerNonUserCode]
		public DataColumn CSTAmtColumn => columnCSTAmt;

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
		public DataTable2Row AddDataTable2Row(string CSTerms, double CSTAmt)
		{
			DataTable2Row dataTable2Row = (DataTable2Row)NewRow();
			object[] itemArray = new object[2] { CSTerms, CSTAmt };
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
			columnCSTerms = base.Columns["CSTerms"];
			columnCSTAmt = base.Columns["CSTAmt"];
		}

		[DebuggerNonUserCode]
		private void InitClass()
		{
			columnCSTerms = new DataColumn("CSTerms", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnCSTerms);
			columnCSTAmt = new DataColumn("CSTAmt", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnCSTAmt);
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
			EX_VAT_CST_Compute eX_VAT_CST_Compute = new EX_VAT_CST_Compute();
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
			xmlSchemaAttribute.FixedValue = eX_VAT_CST_Compute.Namespace;
			xmlSchemaComplexType.Attributes.Add(xmlSchemaAttribute);
			XmlSchemaAttribute xmlSchemaAttribute2 = new XmlSchemaAttribute();
			xmlSchemaAttribute2.Name = "tableTypeName";
			xmlSchemaAttribute2.FixedValue = "DataTable2DataTable";
			xmlSchemaComplexType.Attributes.Add(xmlSchemaAttribute2);
			xmlSchemaComplexType.Particle = xmlSchemaSequence;
			XmlSchema schemaSerializable = eX_VAT_CST_Compute.GetSchemaSerializable();
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
	[XmlSchemaProvider("GetTypedTableSchema")]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
	public class DataTable3DataTable : TypedTableBase<DataTable3Row>
	{
		private DataColumn columnExciseTerm;

		private DataColumn columnExBasicAmt;

		[DebuggerNonUserCode]
		public DataColumn ExciseTermColumn => columnExciseTerm;

		[DebuggerNonUserCode]
		public DataColumn ExBasicAmtColumn => columnExBasicAmt;

		[Browsable(false)]
		[DebuggerNonUserCode]
		public int Count => base.Rows.Count;

		[DebuggerNonUserCode]
		public DataTable3Row this[int index] => (DataTable3Row)base.Rows[index];

		public event DataTable3RowChangeEventHandler DataTable3RowChanging;

		public event DataTable3RowChangeEventHandler DataTable3RowChanged;

		public event DataTable3RowChangeEventHandler DataTable3RowDeleting;

		public event DataTable3RowChangeEventHandler DataTable3RowDeleted;

		[DebuggerNonUserCode]
		public DataTable3DataTable()
		{
			base.TableName = "DataTable3";
			BeginInit();
			InitClass();
			EndInit();
		}

		[DebuggerNonUserCode]
		internal DataTable3DataTable(DataTable table)
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
		protected DataTable3DataTable(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
			InitVars();
		}

		[DebuggerNonUserCode]
		public void AddDataTable3Row(DataTable3Row row)
		{
			base.Rows.Add(row);
		}

		[DebuggerNonUserCode]
		public DataTable3Row AddDataTable3Row(string ExciseTerm, double ExBasicAmt)
		{
			DataTable3Row dataTable3Row = (DataTable3Row)NewRow();
			object[] itemArray = new object[2] { ExciseTerm, ExBasicAmt };
			dataTable3Row.ItemArray = itemArray;
			base.Rows.Add(dataTable3Row);
			return dataTable3Row;
		}

		[DebuggerNonUserCode]
		public override DataTable Clone()
		{
			DataTable3DataTable dataTable3DataTable = (DataTable3DataTable)base.Clone();
			dataTable3DataTable.InitVars();
			return dataTable3DataTable;
		}

		[DebuggerNonUserCode]
		protected override DataTable CreateInstance()
		{
			return new DataTable3DataTable();
		}

		[DebuggerNonUserCode]
		internal void InitVars()
		{
			columnExciseTerm = base.Columns["ExciseTerm"];
			columnExBasicAmt = base.Columns["ExBasicAmt"];
		}

		[DebuggerNonUserCode]
		private void InitClass()
		{
			columnExciseTerm = new DataColumn("ExciseTerm", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnExciseTerm);
			columnExBasicAmt = new DataColumn("ExBasicAmt", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnExBasicAmt);
		}

		[DebuggerNonUserCode]
		public DataTable3Row NewDataTable3Row()
		{
			return (DataTable3Row)NewRow();
		}

		[DebuggerNonUserCode]
		protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
		{
			return new DataTable3Row(builder);
		}

		[DebuggerNonUserCode]
		protected override Type GetRowType()
		{
			return typeof(DataTable3Row);
		}

		[DebuggerNonUserCode]
		protected override void OnRowChanged(DataRowChangeEventArgs e)
		{
			base.OnRowChanged(e);
			if (this.DataTable3RowChanged != null)
			{
				this.DataTable3RowChanged(this, new DataTable3RowChangeEvent((DataTable3Row)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		protected override void OnRowChanging(DataRowChangeEventArgs e)
		{
			base.OnRowChanging(e);
			if (this.DataTable3RowChanging != null)
			{
				this.DataTable3RowChanging(this, new DataTable3RowChangeEvent((DataTable3Row)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		protected override void OnRowDeleted(DataRowChangeEventArgs e)
		{
			base.OnRowDeleted(e);
			if (this.DataTable3RowDeleted != null)
			{
				this.DataTable3RowDeleted(this, new DataTable3RowChangeEvent((DataTable3Row)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		protected override void OnRowDeleting(DataRowChangeEventArgs e)
		{
			base.OnRowDeleting(e);
			if (this.DataTable3RowDeleting != null)
			{
				this.DataTable3RowDeleting(this, new DataTable3RowChangeEvent((DataTable3Row)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		public void RemoveDataTable3Row(DataTable3Row row)
		{
			base.Rows.Remove(row);
		}

		[DebuggerNonUserCode]
		public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
		{
			XmlSchemaComplexType xmlSchemaComplexType = new XmlSchemaComplexType();
			XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
			EX_VAT_CST_Compute eX_VAT_CST_Compute = new EX_VAT_CST_Compute();
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
			xmlSchemaAttribute.FixedValue = eX_VAT_CST_Compute.Namespace;
			xmlSchemaComplexType.Attributes.Add(xmlSchemaAttribute);
			XmlSchemaAttribute xmlSchemaAttribute2 = new XmlSchemaAttribute();
			xmlSchemaAttribute2.Name = "tableTypeName";
			xmlSchemaAttribute2.FixedValue = "DataTable3DataTable";
			xmlSchemaComplexType.Attributes.Add(xmlSchemaAttribute2);
			xmlSchemaComplexType.Particle = xmlSchemaSequence;
			XmlSchema schemaSerializable = eX_VAT_CST_Compute.GetSchemaSerializable();
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
	public class DataTable4DataTable : TypedTableBase<DataTable4Row>
	{
		private DataColumn columnVATTerm;

		private DataColumn columnAmt;

		[DebuggerNonUserCode]
		public DataColumn VATTermColumn => columnVATTerm;

		[DebuggerNonUserCode]
		public DataColumn AmtColumn => columnAmt;

		[DebuggerNonUserCode]
		[Browsable(false)]
		public int Count => base.Rows.Count;

		[DebuggerNonUserCode]
		public DataTable4Row this[int index] => (DataTable4Row)base.Rows[index];

		public event DataTable4RowChangeEventHandler DataTable4RowChanging;

		public event DataTable4RowChangeEventHandler DataTable4RowChanged;

		public event DataTable4RowChangeEventHandler DataTable4RowDeleting;

		public event DataTable4RowChangeEventHandler DataTable4RowDeleted;

		[DebuggerNonUserCode]
		public DataTable4DataTable()
		{
			base.TableName = "DataTable4";
			BeginInit();
			InitClass();
			EndInit();
		}

		[DebuggerNonUserCode]
		internal DataTable4DataTable(DataTable table)
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
		protected DataTable4DataTable(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
			InitVars();
		}

		[DebuggerNonUserCode]
		public void AddDataTable4Row(DataTable4Row row)
		{
			base.Rows.Add(row);
		}

		[DebuggerNonUserCode]
		public DataTable4Row AddDataTable4Row(string VATTerm, double Amt)
		{
			DataTable4Row dataTable4Row = (DataTable4Row)NewRow();
			object[] itemArray = new object[2] { VATTerm, Amt };
			dataTable4Row.ItemArray = itemArray;
			base.Rows.Add(dataTable4Row);
			return dataTable4Row;
		}

		[DebuggerNonUserCode]
		public override DataTable Clone()
		{
			DataTable4DataTable dataTable4DataTable = (DataTable4DataTable)base.Clone();
			dataTable4DataTable.InitVars();
			return dataTable4DataTable;
		}

		[DebuggerNonUserCode]
		protected override DataTable CreateInstance()
		{
			return new DataTable4DataTable();
		}

		[DebuggerNonUserCode]
		internal void InitVars()
		{
			columnVATTerm = base.Columns["VATTerm"];
			columnAmt = base.Columns["Amt"];
		}

		[DebuggerNonUserCode]
		private void InitClass()
		{
			columnVATTerm = new DataColumn("VATTerm", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnVATTerm);
			columnAmt = new DataColumn("Amt", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnAmt);
		}

		[DebuggerNonUserCode]
		public DataTable4Row NewDataTable4Row()
		{
			return (DataTable4Row)NewRow();
		}

		[DebuggerNonUserCode]
		protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
		{
			return new DataTable4Row(builder);
		}

		[DebuggerNonUserCode]
		protected override Type GetRowType()
		{
			return typeof(DataTable4Row);
		}

		[DebuggerNonUserCode]
		protected override void OnRowChanged(DataRowChangeEventArgs e)
		{
			base.OnRowChanged(e);
			if (this.DataTable4RowChanged != null)
			{
				this.DataTable4RowChanged(this, new DataTable4RowChangeEvent((DataTable4Row)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		protected override void OnRowChanging(DataRowChangeEventArgs e)
		{
			base.OnRowChanging(e);
			if (this.DataTable4RowChanging != null)
			{
				this.DataTable4RowChanging(this, new DataTable4RowChangeEvent((DataTable4Row)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		protected override void OnRowDeleted(DataRowChangeEventArgs e)
		{
			base.OnRowDeleted(e);
			if (this.DataTable4RowDeleted != null)
			{
				this.DataTable4RowDeleted(this, new DataTable4RowChangeEvent((DataTable4Row)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		protected override void OnRowDeleting(DataRowChangeEventArgs e)
		{
			base.OnRowDeleting(e);
			if (this.DataTable4RowDeleting != null)
			{
				this.DataTable4RowDeleting(this, new DataTable4RowChangeEvent((DataTable4Row)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		public void RemoveDataTable4Row(DataTable4Row row)
		{
			base.Rows.Remove(row);
		}

		[DebuggerNonUserCode]
		public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
		{
			XmlSchemaComplexType xmlSchemaComplexType = new XmlSchemaComplexType();
			XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
			EX_VAT_CST_Compute eX_VAT_CST_Compute = new EX_VAT_CST_Compute();
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
			xmlSchemaAttribute.FixedValue = eX_VAT_CST_Compute.Namespace;
			xmlSchemaComplexType.Attributes.Add(xmlSchemaAttribute);
			XmlSchemaAttribute xmlSchemaAttribute2 = new XmlSchemaAttribute();
			xmlSchemaAttribute2.Name = "tableTypeName";
			xmlSchemaAttribute2.FixedValue = "DataTable4DataTable";
			xmlSchemaComplexType.Attributes.Add(xmlSchemaAttribute2);
			xmlSchemaComplexType.Particle = xmlSchemaSequence;
			XmlSchema schemaSerializable = eX_VAT_CST_Compute.GetSchemaSerializable();
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
	[XmlSchemaProvider("GetTypedTableSchema")]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
	public class DataTable5DataTable : TypedTableBase<DataTable5Row>
	{
		private DataColumn columnCSTTerm;

		private DataColumn columnCSTAmt;

		[DebuggerNonUserCode]
		public DataColumn CSTTermColumn => columnCSTTerm;

		[DebuggerNonUserCode]
		public DataColumn CSTAmtColumn => columnCSTAmt;

		[DebuggerNonUserCode]
		[Browsable(false)]
		public int Count => base.Rows.Count;

		[DebuggerNonUserCode]
		public DataTable5Row this[int index] => (DataTable5Row)base.Rows[index];

		public event DataTable5RowChangeEventHandler DataTable5RowChanging;

		public event DataTable5RowChangeEventHandler DataTable5RowChanged;

		public event DataTable5RowChangeEventHandler DataTable5RowDeleting;

		public event DataTable5RowChangeEventHandler DataTable5RowDeleted;

		[DebuggerNonUserCode]
		public DataTable5DataTable()
		{
			base.TableName = "DataTable5";
			BeginInit();
			InitClass();
			EndInit();
		}

		[DebuggerNonUserCode]
		internal DataTable5DataTable(DataTable table)
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
		protected DataTable5DataTable(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
			InitVars();
		}

		[DebuggerNonUserCode]
		public void AddDataTable5Row(DataTable5Row row)
		{
			base.Rows.Add(row);
		}

		[DebuggerNonUserCode]
		public DataTable5Row AddDataTable5Row(string CSTTerm, double CSTAmt)
		{
			DataTable5Row dataTable5Row = (DataTable5Row)NewRow();
			object[] itemArray = new object[2] { CSTTerm, CSTAmt };
			dataTable5Row.ItemArray = itemArray;
			base.Rows.Add(dataTable5Row);
			return dataTable5Row;
		}

		[DebuggerNonUserCode]
		public override DataTable Clone()
		{
			DataTable5DataTable dataTable5DataTable = (DataTable5DataTable)base.Clone();
			dataTable5DataTable.InitVars();
			return dataTable5DataTable;
		}

		[DebuggerNonUserCode]
		protected override DataTable CreateInstance()
		{
			return new DataTable5DataTable();
		}

		[DebuggerNonUserCode]
		internal void InitVars()
		{
			columnCSTTerm = base.Columns["CSTTerm"];
			columnCSTAmt = base.Columns["CSTAmt"];
		}

		[DebuggerNonUserCode]
		private void InitClass()
		{
			columnCSTTerm = new DataColumn("CSTTerm", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnCSTTerm);
			columnCSTAmt = new DataColumn("CSTAmt", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnCSTAmt);
		}

		[DebuggerNonUserCode]
		public DataTable5Row NewDataTable5Row()
		{
			return (DataTable5Row)NewRow();
		}

		[DebuggerNonUserCode]
		protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
		{
			return new DataTable5Row(builder);
		}

		[DebuggerNonUserCode]
		protected override Type GetRowType()
		{
			return typeof(DataTable5Row);
		}

		[DebuggerNonUserCode]
		protected override void OnRowChanged(DataRowChangeEventArgs e)
		{
			base.OnRowChanged(e);
			if (this.DataTable5RowChanged != null)
			{
				this.DataTable5RowChanged(this, new DataTable5RowChangeEvent((DataTable5Row)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		protected override void OnRowChanging(DataRowChangeEventArgs e)
		{
			base.OnRowChanging(e);
			if (this.DataTable5RowChanging != null)
			{
				this.DataTable5RowChanging(this, new DataTable5RowChangeEvent((DataTable5Row)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		protected override void OnRowDeleted(DataRowChangeEventArgs e)
		{
			base.OnRowDeleted(e);
			if (this.DataTable5RowDeleted != null)
			{
				this.DataTable5RowDeleted(this, new DataTable5RowChangeEvent((DataTable5Row)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		protected override void OnRowDeleting(DataRowChangeEventArgs e)
		{
			base.OnRowDeleting(e);
			if (this.DataTable5RowDeleting != null)
			{
				this.DataTable5RowDeleting(this, new DataTable5RowChangeEvent((DataTable5Row)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		public void RemoveDataTable5Row(DataTable5Row row)
		{
			base.Rows.Remove(row);
		}

		[DebuggerNonUserCode]
		public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
		{
			XmlSchemaComplexType xmlSchemaComplexType = new XmlSchemaComplexType();
			XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
			EX_VAT_CST_Compute eX_VAT_CST_Compute = new EX_VAT_CST_Compute();
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
			xmlSchemaAttribute.FixedValue = eX_VAT_CST_Compute.Namespace;
			xmlSchemaComplexType.Attributes.Add(xmlSchemaAttribute);
			XmlSchemaAttribute xmlSchemaAttribute2 = new XmlSchemaAttribute();
			xmlSchemaAttribute2.Name = "tableTypeName";
			xmlSchemaAttribute2.FixedValue = "DataTable5DataTable";
			xmlSchemaComplexType.Attributes.Add(xmlSchemaAttribute2);
			xmlSchemaComplexType.Particle = xmlSchemaSequence;
			XmlSchema schemaSerializable = eX_VAT_CST_Compute.GetSchemaSerializable();
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
	public class DataTable6DataTable : TypedTableBase<DataTable6Row>
	{
		private DataColumn columnEXTerm;

		private DataColumn columnEXAmt;

		[DebuggerNonUserCode]
		public DataColumn EXTermColumn => columnEXTerm;

		[DebuggerNonUserCode]
		public DataColumn EXAmtColumn => columnEXAmt;

		[Browsable(false)]
		[DebuggerNonUserCode]
		public int Count => base.Rows.Count;

		[DebuggerNonUserCode]
		public DataTable6Row this[int index] => (DataTable6Row)base.Rows[index];

		public event DataTable6RowChangeEventHandler DataTable6RowChanging;

		public event DataTable6RowChangeEventHandler DataTable6RowChanged;

		public event DataTable6RowChangeEventHandler DataTable6RowDeleting;

		public event DataTable6RowChangeEventHandler DataTable6RowDeleted;

		[DebuggerNonUserCode]
		public DataTable6DataTable()
		{
			base.TableName = "DataTable6";
			BeginInit();
			InitClass();
			EndInit();
		}

		[DebuggerNonUserCode]
		internal DataTable6DataTable(DataTable table)
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
		protected DataTable6DataTable(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
			InitVars();
		}

		[DebuggerNonUserCode]
		public void AddDataTable6Row(DataTable6Row row)
		{
			base.Rows.Add(row);
		}

		[DebuggerNonUserCode]
		public DataTable6Row AddDataTable6Row(string EXTerm, double EXAmt)
		{
			DataTable6Row dataTable6Row = (DataTable6Row)NewRow();
			object[] itemArray = new object[2] { EXTerm, EXAmt };
			dataTable6Row.ItemArray = itemArray;
			base.Rows.Add(dataTable6Row);
			return dataTable6Row;
		}

		[DebuggerNonUserCode]
		public override DataTable Clone()
		{
			DataTable6DataTable dataTable6DataTable = (DataTable6DataTable)base.Clone();
			dataTable6DataTable.InitVars();
			return dataTable6DataTable;
		}

		[DebuggerNonUserCode]
		protected override DataTable CreateInstance()
		{
			return new DataTable6DataTable();
		}

		[DebuggerNonUserCode]
		internal void InitVars()
		{
			columnEXTerm = base.Columns["EXTerm"];
			columnEXAmt = base.Columns["EXAmt"];
		}

		[DebuggerNonUserCode]
		private void InitClass()
		{
			columnEXTerm = new DataColumn("EXTerm", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnEXTerm);
			columnEXAmt = new DataColumn("EXAmt", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnEXAmt);
		}

		[DebuggerNonUserCode]
		public DataTable6Row NewDataTable6Row()
		{
			return (DataTable6Row)NewRow();
		}

		[DebuggerNonUserCode]
		protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
		{
			return new DataTable6Row(builder);
		}

		[DebuggerNonUserCode]
		protected override Type GetRowType()
		{
			return typeof(DataTable6Row);
		}

		[DebuggerNonUserCode]
		protected override void OnRowChanged(DataRowChangeEventArgs e)
		{
			base.OnRowChanged(e);
			if (this.DataTable6RowChanged != null)
			{
				this.DataTable6RowChanged(this, new DataTable6RowChangeEvent((DataTable6Row)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		protected override void OnRowChanging(DataRowChangeEventArgs e)
		{
			base.OnRowChanging(e);
			if (this.DataTable6RowChanging != null)
			{
				this.DataTable6RowChanging(this, new DataTable6RowChangeEvent((DataTable6Row)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		protected override void OnRowDeleted(DataRowChangeEventArgs e)
		{
			base.OnRowDeleted(e);
			if (this.DataTable6RowDeleted != null)
			{
				this.DataTable6RowDeleted(this, new DataTable6RowChangeEvent((DataTable6Row)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		protected override void OnRowDeleting(DataRowChangeEventArgs e)
		{
			base.OnRowDeleting(e);
			if (this.DataTable6RowDeleting != null)
			{
				this.DataTable6RowDeleting(this, new DataTable6RowChangeEvent((DataTable6Row)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		public void RemoveDataTable6Row(DataTable6Row row)
		{
			base.Rows.Remove(row);
		}

		[DebuggerNonUserCode]
		public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
		{
			XmlSchemaComplexType xmlSchemaComplexType = new XmlSchemaComplexType();
			XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
			EX_VAT_CST_Compute eX_VAT_CST_Compute = new EX_VAT_CST_Compute();
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
			xmlSchemaAttribute.FixedValue = eX_VAT_CST_Compute.Namespace;
			xmlSchemaComplexType.Attributes.Add(xmlSchemaAttribute);
			XmlSchemaAttribute xmlSchemaAttribute2 = new XmlSchemaAttribute();
			xmlSchemaAttribute2.Name = "tableTypeName";
			xmlSchemaAttribute2.FixedValue = "DataTable6DataTable";
			xmlSchemaComplexType.Attributes.Add(xmlSchemaAttribute2);
			xmlSchemaComplexType.Particle = xmlSchemaSequence;
			XmlSchema schemaSerializable = eX_VAT_CST_Compute.GetSchemaSerializable();
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
		public string VATerms
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.VATermsColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'VATerms' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.VATermsColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public double VATAmt
		{
			get
			{
				try
				{
					return (double)base[tableDataTable1.VATAmtColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'VATAmt' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.VATAmtColumn] = value;
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
		public bool IsVATermsNull()
		{
			return IsNull(tableDataTable1.VATermsColumn);
		}

		[DebuggerNonUserCode]
		public void SetVATermsNull()
		{
			base[tableDataTable1.VATermsColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsVATAmtNull()
		{
			return IsNull(tableDataTable1.VATAmtColumn);
		}

		[DebuggerNonUserCode]
		public void SetVATAmtNull()
		{
			base[tableDataTable1.VATAmtColumn] = Convert.DBNull;
		}
	}

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
	public class DataTable2Row : DataRow
	{
		private DataTable2DataTable tableDataTable2;

		[DebuggerNonUserCode]
		public string CSTerms
		{
			get
			{
				try
				{
					return (string)base[tableDataTable2.CSTermsColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'CSTerms' in table 'DataTable2' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable2.CSTermsColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public double CSTAmt
		{
			get
			{
				try
				{
					return (double)base[tableDataTable2.CSTAmtColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'CSTAmt' in table 'DataTable2' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable2.CSTAmtColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		internal DataTable2Row(DataRowBuilder rb)
			: base(rb)
		{
			tableDataTable2 = (DataTable2DataTable)base.Table;
		}

		[DebuggerNonUserCode]
		public bool IsCSTermsNull()
		{
			return IsNull(tableDataTable2.CSTermsColumn);
		}

		[DebuggerNonUserCode]
		public void SetCSTermsNull()
		{
			base[tableDataTable2.CSTermsColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsCSTAmtNull()
		{
			return IsNull(tableDataTable2.CSTAmtColumn);
		}

		[DebuggerNonUserCode]
		public void SetCSTAmtNull()
		{
			base[tableDataTable2.CSTAmtColumn] = Convert.DBNull;
		}
	}

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
	public class DataTable3Row : DataRow
	{
		private DataTable3DataTable tableDataTable3;

		[DebuggerNonUserCode]
		public string ExciseTerm
		{
			get
			{
				try
				{
					return (string)base[tableDataTable3.ExciseTermColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'ExciseTerm' in table 'DataTable3' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable3.ExciseTermColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public double ExBasicAmt
		{
			get
			{
				try
				{
					return (double)base[tableDataTable3.ExBasicAmtColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'ExBasicAmt' in table 'DataTable3' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable3.ExBasicAmtColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		internal DataTable3Row(DataRowBuilder rb)
			: base(rb)
		{
			tableDataTable3 = (DataTable3DataTable)base.Table;
		}

		[DebuggerNonUserCode]
		public bool IsExciseTermNull()
		{
			return IsNull(tableDataTable3.ExciseTermColumn);
		}

		[DebuggerNonUserCode]
		public void SetExciseTermNull()
		{
			base[tableDataTable3.ExciseTermColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsExBasicAmtNull()
		{
			return IsNull(tableDataTable3.ExBasicAmtColumn);
		}

		[DebuggerNonUserCode]
		public void SetExBasicAmtNull()
		{
			base[tableDataTable3.ExBasicAmtColumn] = Convert.DBNull;
		}
	}

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
	public class DataTable4Row : DataRow
	{
		private DataTable4DataTable tableDataTable4;

		[DebuggerNonUserCode]
		public string VATTerm
		{
			get
			{
				try
				{
					return (string)base[tableDataTable4.VATTermColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'VATTerm' in table 'DataTable4' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable4.VATTermColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public double Amt
		{
			get
			{
				try
				{
					return (double)base[tableDataTable4.AmtColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Amt' in table 'DataTable4' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable4.AmtColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		internal DataTable4Row(DataRowBuilder rb)
			: base(rb)
		{
			tableDataTable4 = (DataTable4DataTable)base.Table;
		}

		[DebuggerNonUserCode]
		public bool IsVATTermNull()
		{
			return IsNull(tableDataTable4.VATTermColumn);
		}

		[DebuggerNonUserCode]
		public void SetVATTermNull()
		{
			base[tableDataTable4.VATTermColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsAmtNull()
		{
			return IsNull(tableDataTable4.AmtColumn);
		}

		[DebuggerNonUserCode]
		public void SetAmtNull()
		{
			base[tableDataTable4.AmtColumn] = Convert.DBNull;
		}
	}

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
	public class DataTable5Row : DataRow
	{
		private DataTable5DataTable tableDataTable5;

		[DebuggerNonUserCode]
		public string CSTTerm
		{
			get
			{
				try
				{
					return (string)base[tableDataTable5.CSTTermColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'CSTTerm' in table 'DataTable5' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable5.CSTTermColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public double CSTAmt
		{
			get
			{
				try
				{
					return (double)base[tableDataTable5.CSTAmtColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'CSTAmt' in table 'DataTable5' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable5.CSTAmtColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		internal DataTable5Row(DataRowBuilder rb)
			: base(rb)
		{
			tableDataTable5 = (DataTable5DataTable)base.Table;
		}

		[DebuggerNonUserCode]
		public bool IsCSTTermNull()
		{
			return IsNull(tableDataTable5.CSTTermColumn);
		}

		[DebuggerNonUserCode]
		public void SetCSTTermNull()
		{
			base[tableDataTable5.CSTTermColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsCSTAmtNull()
		{
			return IsNull(tableDataTable5.CSTAmtColumn);
		}

		[DebuggerNonUserCode]
		public void SetCSTAmtNull()
		{
			base[tableDataTable5.CSTAmtColumn] = Convert.DBNull;
		}
	}

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
	public class DataTable6Row : DataRow
	{
		private DataTable6DataTable tableDataTable6;

		[DebuggerNonUserCode]
		public string EXTerm
		{
			get
			{
				try
				{
					return (string)base[tableDataTable6.EXTermColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'EXTerm' in table 'DataTable6' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable6.EXTermColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public double EXAmt
		{
			get
			{
				try
				{
					return (double)base[tableDataTable6.EXAmtColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'EXAmt' in table 'DataTable6' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable6.EXAmtColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		internal DataTable6Row(DataRowBuilder rb)
			: base(rb)
		{
			tableDataTable6 = (DataTable6DataTable)base.Table;
		}

		[DebuggerNonUserCode]
		public bool IsEXTermNull()
		{
			return IsNull(tableDataTable6.EXTermColumn);
		}

		[DebuggerNonUserCode]
		public void SetEXTermNull()
		{
			base[tableDataTable6.EXTermColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsEXAmtNull()
		{
			return IsNull(tableDataTable6.EXAmtColumn);
		}

		[DebuggerNonUserCode]
		public void SetEXAmtNull()
		{
			base[tableDataTable6.EXAmtColumn] = Convert.DBNull;
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

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
	public class DataTable3RowChangeEvent : EventArgs
	{
		private DataTable3Row eventRow;

		private DataRowAction eventAction;

		[DebuggerNonUserCode]
		public DataTable3Row Row => eventRow;

		[DebuggerNonUserCode]
		public DataRowAction Action => eventAction;

		[DebuggerNonUserCode]
		public DataTable3RowChangeEvent(DataTable3Row row, DataRowAction action)
		{
			eventRow = row;
			eventAction = action;
		}
	}

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
	public class DataTable4RowChangeEvent : EventArgs
	{
		private DataTable4Row eventRow;

		private DataRowAction eventAction;

		[DebuggerNonUserCode]
		public DataTable4Row Row => eventRow;

		[DebuggerNonUserCode]
		public DataRowAction Action => eventAction;

		[DebuggerNonUserCode]
		public DataTable4RowChangeEvent(DataTable4Row row, DataRowAction action)
		{
			eventRow = row;
			eventAction = action;
		}
	}

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
	public class DataTable5RowChangeEvent : EventArgs
	{
		private DataTable5Row eventRow;

		private DataRowAction eventAction;

		[DebuggerNonUserCode]
		public DataTable5Row Row => eventRow;

		[DebuggerNonUserCode]
		public DataRowAction Action => eventAction;

		[DebuggerNonUserCode]
		public DataTable5RowChangeEvent(DataTable5Row row, DataRowAction action)
		{
			eventRow = row;
			eventAction = action;
		}
	}

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
	public class DataTable6RowChangeEvent : EventArgs
	{
		private DataTable6Row eventRow;

		private DataRowAction eventAction;

		[DebuggerNonUserCode]
		public DataTable6Row Row => eventRow;

		[DebuggerNonUserCode]
		public DataRowAction Action => eventAction;

		[DebuggerNonUserCode]
		public DataTable6RowChangeEvent(DataTable6Row row, DataRowAction action)
		{
			eventRow = row;
			eventAction = action;
		}
	}

	private DataTable1DataTable tableDataTable1;

	private DataTable2DataTable tableDataTable2;

	private DataTable3DataTable tableDataTable3;

	private DataTable4DataTable tableDataTable4;

	private DataTable5DataTable tableDataTable5;

	private DataTable6DataTable tableDataTable6;

	private SchemaSerializationMode _schemaSerializationMode = SchemaSerializationMode.IncludeSchema;

	[DebuggerNonUserCode]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	[Browsable(false)]
	public DataTable1DataTable DataTable1 => tableDataTable1;

	[DebuggerNonUserCode]
	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public DataTable2DataTable DataTable2 => tableDataTable2;

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	[DebuggerNonUserCode]
	public DataTable3DataTable DataTable3 => tableDataTable3;

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	[Browsable(false)]
	[DebuggerNonUserCode]
	public DataTable4DataTable DataTable4 => tableDataTable4;

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	[DebuggerNonUserCode]
	public DataTable5DataTable DataTable5 => tableDataTable5;

	[Browsable(false)]
	[DebuggerNonUserCode]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public DataTable6DataTable DataTable6 => tableDataTable6;

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
	public EX_VAT_CST_Compute()
	{
		BeginInit();
		InitClass();
		CollectionChangeEventHandler value = SchemaChanged;
		base.Tables.CollectionChanged += value;
		base.Relations.CollectionChanged += value;
		EndInit();
	}

	[DebuggerNonUserCode]
	protected EX_VAT_CST_Compute(SerializationInfo info, StreamingContext context)
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
			if (dataSet.Tables["DataTable3"] != null)
			{
				base.Tables.Add(new DataTable3DataTable(dataSet.Tables["DataTable3"]));
			}
			if (dataSet.Tables["DataTable4"] != null)
			{
				base.Tables.Add(new DataTable4DataTable(dataSet.Tables["DataTable4"]));
			}
			if (dataSet.Tables["DataTable5"] != null)
			{
				base.Tables.Add(new DataTable5DataTable(dataSet.Tables["DataTable5"]));
			}
			if (dataSet.Tables["DataTable6"] != null)
			{
				base.Tables.Add(new DataTable6DataTable(dataSet.Tables["DataTable6"]));
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
		EX_VAT_CST_Compute eX_VAT_CST_Compute = (EX_VAT_CST_Compute)base.Clone();
		eX_VAT_CST_Compute.InitVars();
		eX_VAT_CST_Compute.SchemaSerializationMode = SchemaSerializationMode;
		return eX_VAT_CST_Compute;
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
			if (dataSet.Tables["DataTable3"] != null)
			{
				base.Tables.Add(new DataTable3DataTable(dataSet.Tables["DataTable3"]));
			}
			if (dataSet.Tables["DataTable4"] != null)
			{
				base.Tables.Add(new DataTable4DataTable(dataSet.Tables["DataTable4"]));
			}
			if (dataSet.Tables["DataTable5"] != null)
			{
				base.Tables.Add(new DataTable5DataTable(dataSet.Tables["DataTable5"]));
			}
			if (dataSet.Tables["DataTable6"] != null)
			{
				base.Tables.Add(new DataTable6DataTable(dataSet.Tables["DataTable6"]));
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
		tableDataTable3 = (DataTable3DataTable)base.Tables["DataTable3"];
		if (initTable && tableDataTable3 != null)
		{
			tableDataTable3.InitVars();
		}
		tableDataTable4 = (DataTable4DataTable)base.Tables["DataTable4"];
		if (initTable && tableDataTable4 != null)
		{
			tableDataTable4.InitVars();
		}
		tableDataTable5 = (DataTable5DataTable)base.Tables["DataTable5"];
		if (initTable && tableDataTable5 != null)
		{
			tableDataTable5.InitVars();
		}
		tableDataTable6 = (DataTable6DataTable)base.Tables["DataTable6"];
		if (initTable && tableDataTable6 != null)
		{
			tableDataTable6.InitVars();
		}
	}

	[DebuggerNonUserCode]
	private void InitClass()
	{
		base.DataSetName = "EX_VAT_CST_Compute";
		base.Prefix = "";
		base.Namespace = "http://tempuri.org/EX_VAT_CST_Compute.xsd";
		base.EnforceConstraints = true;
		SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
		tableDataTable1 = new DataTable1DataTable();
		base.Tables.Add(tableDataTable1);
		tableDataTable2 = new DataTable2DataTable();
		base.Tables.Add(tableDataTable2);
		tableDataTable3 = new DataTable3DataTable();
		base.Tables.Add(tableDataTable3);
		tableDataTable4 = new DataTable4DataTable();
		base.Tables.Add(tableDataTable4);
		tableDataTable5 = new DataTable5DataTable();
		base.Tables.Add(tableDataTable5);
		tableDataTable6 = new DataTable6DataTable();
		base.Tables.Add(tableDataTable6);
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
	private bool ShouldSerializeDataTable3()
	{
		return false;
	}

	[DebuggerNonUserCode]
	private bool ShouldSerializeDataTable4()
	{
		return false;
	}

	[DebuggerNonUserCode]
	private bool ShouldSerializeDataTable5()
	{
		return false;
	}

	[DebuggerNonUserCode]
	private bool ShouldSerializeDataTable6()
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
		EX_VAT_CST_Compute eX_VAT_CST_Compute = new EX_VAT_CST_Compute();
		XmlSchemaComplexType xmlSchemaComplexType = new XmlSchemaComplexType();
		XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
		XmlSchemaAny xmlSchemaAny = new XmlSchemaAny();
		xmlSchemaAny.Namespace = eX_VAT_CST_Compute.Namespace;
		xmlSchemaSequence.Items.Add(xmlSchemaAny);
		xmlSchemaComplexType.Particle = xmlSchemaSequence;
		XmlSchema schemaSerializable = eX_VAT_CST_Compute.GetSchemaSerializable();
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
