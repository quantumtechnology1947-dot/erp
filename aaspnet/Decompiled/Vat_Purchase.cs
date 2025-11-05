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
[XmlSchemaProvider("GetTypedDataSetSchema")]
[XmlRoot("Vat_Purchase")]
[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
public class Vat_Purchase : DataSet
{
	public delegate void DataTable1RowChangeEventHandler(object sender, DataTable1RowChangeEvent e);

	public delegate void DataTable2RowChangeEventHandler(object sender, DataTable2RowChangeEvent e);

	[Serializable]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
	[XmlSchemaProvider("GetTypedTableSchema")]
	public class DataTable1DataTable : TypedTableBase<DataTable1Row>
	{
		private DataColumn columnSysDate;

		private DataColumn columnCompId;

		private DataColumn columnSupplierName;

		private DataColumn columnBasicAmt;

		private DataColumn columnPFTerms;

		private DataColumn columnPF;

		private DataColumn columnExciseValues;

		private DataColumn columnExciseAmt;

		private DataColumn columnEDUCess;

		private DataColumn columnEDUValue;

		private DataColumn columnSHECess;

		private DataColumn columnSHEValue;

		private DataColumn columnVATCSTTerms;

		private DataColumn columnVATCSTAmt;

		private DataColumn columnFreightAmt;

		private DataColumn columnTotAmt;

		private DataColumn columnExciseBasic;

		private DataColumn columnExBasicAmt;

		[DebuggerNonUserCode]
		public DataColumn SysDateColumn => columnSysDate;

		[DebuggerNonUserCode]
		public DataColumn CompIdColumn => columnCompId;

		[DebuggerNonUserCode]
		public DataColumn SupplierNameColumn => columnSupplierName;

		[DebuggerNonUserCode]
		public DataColumn BasicAmtColumn => columnBasicAmt;

		[DebuggerNonUserCode]
		public DataColumn PFTermsColumn => columnPFTerms;

		[DebuggerNonUserCode]
		public DataColumn PFColumn => columnPF;

		[DebuggerNonUserCode]
		public DataColumn ExciseValuesColumn => columnExciseValues;

		[DebuggerNonUserCode]
		public DataColumn ExciseAmtColumn => columnExciseAmt;

		[DebuggerNonUserCode]
		public DataColumn EDUCessColumn => columnEDUCess;

		[DebuggerNonUserCode]
		public DataColumn EDUValueColumn => columnEDUValue;

		[DebuggerNonUserCode]
		public DataColumn SHECessColumn => columnSHECess;

		[DebuggerNonUserCode]
		public DataColumn SHEValueColumn => columnSHEValue;

		[DebuggerNonUserCode]
		public DataColumn VATCSTTermsColumn => columnVATCSTTerms;

		[DebuggerNonUserCode]
		public DataColumn VATCSTAmtColumn => columnVATCSTAmt;

		[DebuggerNonUserCode]
		public DataColumn FreightAmtColumn => columnFreightAmt;

		[DebuggerNonUserCode]
		public DataColumn TotAmtColumn => columnTotAmt;

		[DebuggerNonUserCode]
		public DataColumn ExciseBasicColumn => columnExciseBasic;

		[DebuggerNonUserCode]
		public DataColumn ExBasicAmtColumn => columnExBasicAmt;

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
		public DataTable1Row AddDataTable1Row(string SysDate, int CompId, string SupplierName, double BasicAmt, string PFTerms, double PF, string ExciseValues, double ExciseAmt, string EDUCess, double EDUValue, string SHECess, double SHEValue, string VATCSTTerms, double VATCSTAmt, double FreightAmt, double TotAmt, string ExciseBasic, double ExBasicAmt)
		{
			DataTable1Row dataTable1Row = (DataTable1Row)NewRow();
			object[] itemArray = new object[18]
			{
				SysDate, CompId, SupplierName, BasicAmt, PFTerms, PF, ExciseValues, ExciseAmt, EDUCess, EDUValue,
				SHECess, SHEValue, VATCSTTerms, VATCSTAmt, FreightAmt, TotAmt, ExciseBasic, ExBasicAmt
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
			columnSysDate = base.Columns["SysDate"];
			columnCompId = base.Columns["CompId"];
			columnSupplierName = base.Columns["SupplierName"];
			columnBasicAmt = base.Columns["BasicAmt"];
			columnPFTerms = base.Columns["PFTerms"];
			columnPF = base.Columns["PF"];
			columnExciseValues = base.Columns["ExciseValues"];
			columnExciseAmt = base.Columns["ExciseAmt"];
			columnEDUCess = base.Columns["EDUCess"];
			columnEDUValue = base.Columns["EDUValue"];
			columnSHECess = base.Columns["SHECess"];
			columnSHEValue = base.Columns["SHEValue"];
			columnVATCSTTerms = base.Columns["VATCSTTerms"];
			columnVATCSTAmt = base.Columns["VATCSTAmt"];
			columnFreightAmt = base.Columns["FreightAmt"];
			columnTotAmt = base.Columns["TotAmt"];
			columnExciseBasic = base.Columns["ExciseBasic"];
			columnExBasicAmt = base.Columns["ExBasicAmt"];
		}

		[DebuggerNonUserCode]
		private void InitClass()
		{
			columnSysDate = new DataColumn("SysDate", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnSysDate);
			columnCompId = new DataColumn("CompId", typeof(int), null, MappingType.Element);
			base.Columns.Add(columnCompId);
			columnSupplierName = new DataColumn("SupplierName", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnSupplierName);
			columnBasicAmt = new DataColumn("BasicAmt", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnBasicAmt);
			columnPFTerms = new DataColumn("PFTerms", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnPFTerms);
			columnPF = new DataColumn("PF", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnPF);
			columnExciseValues = new DataColumn("ExciseValues", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnExciseValues);
			columnExciseAmt = new DataColumn("ExciseAmt", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnExciseAmt);
			columnEDUCess = new DataColumn("EDUCess", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnEDUCess);
			columnEDUValue = new DataColumn("EDUValue", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnEDUValue);
			columnSHECess = new DataColumn("SHECess", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnSHECess);
			columnSHEValue = new DataColumn("SHEValue", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnSHEValue);
			columnVATCSTTerms = new DataColumn("VATCSTTerms", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnVATCSTTerms);
			columnVATCSTAmt = new DataColumn("VATCSTAmt", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnVATCSTAmt);
			columnFreightAmt = new DataColumn("FreightAmt", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnFreightAmt);
			columnTotAmt = new DataColumn("TotAmt", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnTotAmt);
			columnExciseBasic = new DataColumn("ExciseBasic", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnExciseBasic);
			columnExBasicAmt = new DataColumn("ExBasicAmt", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnExBasicAmt);
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
			Vat_Purchase vat_Purchase = new Vat_Purchase();
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
			xmlSchemaAttribute.FixedValue = vat_Purchase.Namespace;
			xmlSchemaComplexType.Attributes.Add(xmlSchemaAttribute);
			XmlSchemaAttribute xmlSchemaAttribute2 = new XmlSchemaAttribute();
			xmlSchemaAttribute2.Name = "tableTypeName";
			xmlSchemaAttribute2.FixedValue = "DataTable1DataTable";
			xmlSchemaComplexType.Attributes.Add(xmlSchemaAttribute2);
			xmlSchemaComplexType.Particle = xmlSchemaSequence;
			XmlSchema schemaSerializable = vat_Purchase.GetSchemaSerializable();
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
	public class DataTable2DataTable : TypedTableBase<DataTable2Row>
	{
		private DataColumn columnSysDate;

		private DataColumn columnCompId;

		private DataColumn columnSupplierName;

		private DataColumn columnBasicAmt;

		private DataColumn columnPFTerms;

		private DataColumn columnPF;

		private DataColumn columnExciseValues;

		private DataColumn columnExciseAmt;

		private DataColumn columnEDUCess;

		private DataColumn columnEDUValue;

		private DataColumn columnSHECess;

		private DataColumn columnSHEValue;

		private DataColumn columnVATCSTTerms;

		private DataColumn columnVATCSTAmt;

		private DataColumn columnFreightAmt;

		private DataColumn columnTotAmt;

		private DataColumn columnExciseBasic;

		private DataColumn columnExBasicAmt;

		[DebuggerNonUserCode]
		public DataColumn SysDateColumn => columnSysDate;

		[DebuggerNonUserCode]
		public DataColumn CompIdColumn => columnCompId;

		[DebuggerNonUserCode]
		public DataColumn SupplierNameColumn => columnSupplierName;

		[DebuggerNonUserCode]
		public DataColumn BasicAmtColumn => columnBasicAmt;

		[DebuggerNonUserCode]
		public DataColumn PFTermsColumn => columnPFTerms;

		[DebuggerNonUserCode]
		public DataColumn PFColumn => columnPF;

		[DebuggerNonUserCode]
		public DataColumn ExciseValuesColumn => columnExciseValues;

		[DebuggerNonUserCode]
		public DataColumn ExciseAmtColumn => columnExciseAmt;

		[DebuggerNonUserCode]
		public DataColumn EDUCessColumn => columnEDUCess;

		[DebuggerNonUserCode]
		public DataColumn EDUValueColumn => columnEDUValue;

		[DebuggerNonUserCode]
		public DataColumn SHECessColumn => columnSHECess;

		[DebuggerNonUserCode]
		public DataColumn SHEValueColumn => columnSHEValue;

		[DebuggerNonUserCode]
		public DataColumn VATCSTTermsColumn => columnVATCSTTerms;

		[DebuggerNonUserCode]
		public DataColumn VATCSTAmtColumn => columnVATCSTAmt;

		[DebuggerNonUserCode]
		public DataColumn FreightAmtColumn => columnFreightAmt;

		[DebuggerNonUserCode]
		public DataColumn TotAmtColumn => columnTotAmt;

		[DebuggerNonUserCode]
		public DataColumn ExciseBasicColumn => columnExciseBasic;

		[DebuggerNonUserCode]
		public DataColumn ExBasicAmtColumn => columnExBasicAmt;

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
		public DataTable2Row AddDataTable2Row(string SysDate, int CompId, string SupplierName, double BasicAmt, string PFTerms, double PF, string ExciseValues, double ExciseAmt, string EDUCess, double EDUValue, string SHECess, double SHEValue, string VATCSTTerms, double VATCSTAmt, double FreightAmt, double TotAmt, string ExciseBasic, double ExBasicAmt)
		{
			DataTable2Row dataTable2Row = (DataTable2Row)NewRow();
			object[] itemArray = new object[18]
			{
				SysDate, CompId, SupplierName, BasicAmt, PFTerms, PF, ExciseValues, ExciseAmt, EDUCess, EDUValue,
				SHECess, SHEValue, VATCSTTerms, VATCSTAmt, FreightAmt, TotAmt, ExciseBasic, ExBasicAmt
			};
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
			columnSysDate = base.Columns["SysDate"];
			columnCompId = base.Columns["CompId"];
			columnSupplierName = base.Columns["SupplierName"];
			columnBasicAmt = base.Columns["BasicAmt"];
			columnPFTerms = base.Columns["PFTerms"];
			columnPF = base.Columns["PF"];
			columnExciseValues = base.Columns["ExciseValues"];
			columnExciseAmt = base.Columns["ExciseAmt"];
			columnEDUCess = base.Columns["EDUCess"];
			columnEDUValue = base.Columns["EDUValue"];
			columnSHECess = base.Columns["SHECess"];
			columnSHEValue = base.Columns["SHEValue"];
			columnVATCSTTerms = base.Columns["VATCSTTerms"];
			columnVATCSTAmt = base.Columns["VATCSTAmt"];
			columnFreightAmt = base.Columns["FreightAmt"];
			columnTotAmt = base.Columns["TotAmt"];
			columnExciseBasic = base.Columns["ExciseBasic"];
			columnExBasicAmt = base.Columns["ExBasicAmt"];
		}

		[DebuggerNonUserCode]
		private void InitClass()
		{
			columnSysDate = new DataColumn("SysDate", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnSysDate);
			columnCompId = new DataColumn("CompId", typeof(int), null, MappingType.Element);
			base.Columns.Add(columnCompId);
			columnSupplierName = new DataColumn("SupplierName", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnSupplierName);
			columnBasicAmt = new DataColumn("BasicAmt", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnBasicAmt);
			columnPFTerms = new DataColumn("PFTerms", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnPFTerms);
			columnPF = new DataColumn("PF", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnPF);
			columnExciseValues = new DataColumn("ExciseValues", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnExciseValues);
			columnExciseAmt = new DataColumn("ExciseAmt", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnExciseAmt);
			columnEDUCess = new DataColumn("EDUCess", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnEDUCess);
			columnEDUValue = new DataColumn("EDUValue", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnEDUValue);
			columnSHECess = new DataColumn("SHECess", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnSHECess);
			columnSHEValue = new DataColumn("SHEValue", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnSHEValue);
			columnVATCSTTerms = new DataColumn("VATCSTTerms", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnVATCSTTerms);
			columnVATCSTAmt = new DataColumn("VATCSTAmt", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnVATCSTAmt);
			columnFreightAmt = new DataColumn("FreightAmt", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnFreightAmt);
			columnTotAmt = new DataColumn("TotAmt", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnTotAmt);
			columnExciseBasic = new DataColumn("ExciseBasic", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnExciseBasic);
			columnExBasicAmt = new DataColumn("ExBasicAmt", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnExBasicAmt);
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
			Vat_Purchase vat_Purchase = new Vat_Purchase();
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
			xmlSchemaAttribute.FixedValue = vat_Purchase.Namespace;
			xmlSchemaComplexType.Attributes.Add(xmlSchemaAttribute);
			XmlSchemaAttribute xmlSchemaAttribute2 = new XmlSchemaAttribute();
			xmlSchemaAttribute2.Name = "tableTypeName";
			xmlSchemaAttribute2.FixedValue = "DataTable2DataTable";
			xmlSchemaComplexType.Attributes.Add(xmlSchemaAttribute2);
			xmlSchemaComplexType.Particle = xmlSchemaSequence;
			XmlSchema schemaSerializable = vat_Purchase.GetSchemaSerializable();
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
		public double BasicAmt
		{
			get
			{
				try
				{
					return (double)base[tableDataTable1.BasicAmtColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'BasicAmt' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.BasicAmtColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string PFTerms
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.PFTermsColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'PFTerms' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.PFTermsColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public double PF
		{
			get
			{
				try
				{
					return (double)base[tableDataTable1.PFColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'PF' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.PFColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string ExciseValues
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.ExciseValuesColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'ExciseValues' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.ExciseValuesColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public double ExciseAmt
		{
			get
			{
				try
				{
					return (double)base[tableDataTable1.ExciseAmtColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'ExciseAmt' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.ExciseAmtColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string EDUCess
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.EDUCessColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'EDUCess' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.EDUCessColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public double EDUValue
		{
			get
			{
				try
				{
					return (double)base[tableDataTable1.EDUValueColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'EDUValue' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.EDUValueColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string SHECess
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.SHECessColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'SHECess' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.SHECessColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public double SHEValue
		{
			get
			{
				try
				{
					return (double)base[tableDataTable1.SHEValueColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'SHEValue' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.SHEValueColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string VATCSTTerms
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.VATCSTTermsColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'VATCSTTerms' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.VATCSTTermsColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public double VATCSTAmt
		{
			get
			{
				try
				{
					return (double)base[tableDataTable1.VATCSTAmtColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'VATCSTAmt' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.VATCSTAmtColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public double FreightAmt
		{
			get
			{
				try
				{
					return (double)base[tableDataTable1.FreightAmtColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'FreightAmt' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.FreightAmtColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public double TotAmt
		{
			get
			{
				try
				{
					return (double)base[tableDataTable1.TotAmtColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'TotAmt' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.TotAmtColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string ExciseBasic
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.ExciseBasicColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'ExciseBasic' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.ExciseBasicColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public double ExBasicAmt
		{
			get
			{
				try
				{
					return (double)base[tableDataTable1.ExBasicAmtColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'ExBasicAmt' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.ExBasicAmtColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		internal DataTable1Row(DataRowBuilder rb)
			: base(rb)
		{
			tableDataTable1 = (DataTable1DataTable)base.Table;
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
		public bool IsBasicAmtNull()
		{
			return IsNull(tableDataTable1.BasicAmtColumn);
		}

		[DebuggerNonUserCode]
		public void SetBasicAmtNull()
		{
			base[tableDataTable1.BasicAmtColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsPFTermsNull()
		{
			return IsNull(tableDataTable1.PFTermsColumn);
		}

		[DebuggerNonUserCode]
		public void SetPFTermsNull()
		{
			base[tableDataTable1.PFTermsColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsPFNull()
		{
			return IsNull(tableDataTable1.PFColumn);
		}

		[DebuggerNonUserCode]
		public void SetPFNull()
		{
			base[tableDataTable1.PFColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsExciseValuesNull()
		{
			return IsNull(tableDataTable1.ExciseValuesColumn);
		}

		[DebuggerNonUserCode]
		public void SetExciseValuesNull()
		{
			base[tableDataTable1.ExciseValuesColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsExciseAmtNull()
		{
			return IsNull(tableDataTable1.ExciseAmtColumn);
		}

		[DebuggerNonUserCode]
		public void SetExciseAmtNull()
		{
			base[tableDataTable1.ExciseAmtColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsEDUCessNull()
		{
			return IsNull(tableDataTable1.EDUCessColumn);
		}

		[DebuggerNonUserCode]
		public void SetEDUCessNull()
		{
			base[tableDataTable1.EDUCessColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsEDUValueNull()
		{
			return IsNull(tableDataTable1.EDUValueColumn);
		}

		[DebuggerNonUserCode]
		public void SetEDUValueNull()
		{
			base[tableDataTable1.EDUValueColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsSHECessNull()
		{
			return IsNull(tableDataTable1.SHECessColumn);
		}

		[DebuggerNonUserCode]
		public void SetSHECessNull()
		{
			base[tableDataTable1.SHECessColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsSHEValueNull()
		{
			return IsNull(tableDataTable1.SHEValueColumn);
		}

		[DebuggerNonUserCode]
		public void SetSHEValueNull()
		{
			base[tableDataTable1.SHEValueColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsVATCSTTermsNull()
		{
			return IsNull(tableDataTable1.VATCSTTermsColumn);
		}

		[DebuggerNonUserCode]
		public void SetVATCSTTermsNull()
		{
			base[tableDataTable1.VATCSTTermsColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsVATCSTAmtNull()
		{
			return IsNull(tableDataTable1.VATCSTAmtColumn);
		}

		[DebuggerNonUserCode]
		public void SetVATCSTAmtNull()
		{
			base[tableDataTable1.VATCSTAmtColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsFreightAmtNull()
		{
			return IsNull(tableDataTable1.FreightAmtColumn);
		}

		[DebuggerNonUserCode]
		public void SetFreightAmtNull()
		{
			base[tableDataTable1.FreightAmtColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsTotAmtNull()
		{
			return IsNull(tableDataTable1.TotAmtColumn);
		}

		[DebuggerNonUserCode]
		public void SetTotAmtNull()
		{
			base[tableDataTable1.TotAmtColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsExciseBasicNull()
		{
			return IsNull(tableDataTable1.ExciseBasicColumn);
		}

		[DebuggerNonUserCode]
		public void SetExciseBasicNull()
		{
			base[tableDataTable1.ExciseBasicColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsExBasicAmtNull()
		{
			return IsNull(tableDataTable1.ExBasicAmtColumn);
		}

		[DebuggerNonUserCode]
		public void SetExBasicAmtNull()
		{
			base[tableDataTable1.ExBasicAmtColumn] = Convert.DBNull;
		}
	}

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
	public class DataTable2Row : DataRow
	{
		private DataTable2DataTable tableDataTable2;

		[DebuggerNonUserCode]
		public string SysDate
		{
			get
			{
				try
				{
					return (string)base[tableDataTable2.SysDateColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'SysDate' in table 'DataTable2' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable2.SysDateColumn] = value;
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
		public string SupplierName
		{
			get
			{
				try
				{
					return (string)base[tableDataTable2.SupplierNameColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'SupplierName' in table 'DataTable2' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable2.SupplierNameColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public double BasicAmt
		{
			get
			{
				try
				{
					return (double)base[tableDataTable2.BasicAmtColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'BasicAmt' in table 'DataTable2' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable2.BasicAmtColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string PFTerms
		{
			get
			{
				try
				{
					return (string)base[tableDataTable2.PFTermsColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'PFTerms' in table 'DataTable2' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable2.PFTermsColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public double PF
		{
			get
			{
				try
				{
					return (double)base[tableDataTable2.PFColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'PF' in table 'DataTable2' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable2.PFColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string ExciseValues
		{
			get
			{
				try
				{
					return (string)base[tableDataTable2.ExciseValuesColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'ExciseValues' in table 'DataTable2' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable2.ExciseValuesColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public double ExciseAmt
		{
			get
			{
				try
				{
					return (double)base[tableDataTable2.ExciseAmtColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'ExciseAmt' in table 'DataTable2' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable2.ExciseAmtColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string EDUCess
		{
			get
			{
				try
				{
					return (string)base[tableDataTable2.EDUCessColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'EDUCess' in table 'DataTable2' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable2.EDUCessColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public double EDUValue
		{
			get
			{
				try
				{
					return (double)base[tableDataTable2.EDUValueColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'EDUValue' in table 'DataTable2' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable2.EDUValueColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string SHECess
		{
			get
			{
				try
				{
					return (string)base[tableDataTable2.SHECessColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'SHECess' in table 'DataTable2' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable2.SHECessColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public double SHEValue
		{
			get
			{
				try
				{
					return (double)base[tableDataTable2.SHEValueColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'SHEValue' in table 'DataTable2' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable2.SHEValueColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string VATCSTTerms
		{
			get
			{
				try
				{
					return (string)base[tableDataTable2.VATCSTTermsColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'VATCSTTerms' in table 'DataTable2' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable2.VATCSTTermsColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public double VATCSTAmt
		{
			get
			{
				try
				{
					return (double)base[tableDataTable2.VATCSTAmtColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'VATCSTAmt' in table 'DataTable2' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable2.VATCSTAmtColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public double FreightAmt
		{
			get
			{
				try
				{
					return (double)base[tableDataTable2.FreightAmtColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'FreightAmt' in table 'DataTable2' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable2.FreightAmtColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public double TotAmt
		{
			get
			{
				try
				{
					return (double)base[tableDataTable2.TotAmtColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'TotAmt' in table 'DataTable2' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable2.TotAmtColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string ExciseBasic
		{
			get
			{
				try
				{
					return (string)base[tableDataTable2.ExciseBasicColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'ExciseBasic' in table 'DataTable2' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable2.ExciseBasicColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public double ExBasicAmt
		{
			get
			{
				try
				{
					return (double)base[tableDataTable2.ExBasicAmtColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'ExBasicAmt' in table 'DataTable2' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable2.ExBasicAmtColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		internal DataTable2Row(DataRowBuilder rb)
			: base(rb)
		{
			tableDataTable2 = (DataTable2DataTable)base.Table;
		}

		[DebuggerNonUserCode]
		public bool IsSysDateNull()
		{
			return IsNull(tableDataTable2.SysDateColumn);
		}

		[DebuggerNonUserCode]
		public void SetSysDateNull()
		{
			base[tableDataTable2.SysDateColumn] = Convert.DBNull;
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

		[DebuggerNonUserCode]
		public bool IsSupplierNameNull()
		{
			return IsNull(tableDataTable2.SupplierNameColumn);
		}

		[DebuggerNonUserCode]
		public void SetSupplierNameNull()
		{
			base[tableDataTable2.SupplierNameColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsBasicAmtNull()
		{
			return IsNull(tableDataTable2.BasicAmtColumn);
		}

		[DebuggerNonUserCode]
		public void SetBasicAmtNull()
		{
			base[tableDataTable2.BasicAmtColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsPFTermsNull()
		{
			return IsNull(tableDataTable2.PFTermsColumn);
		}

		[DebuggerNonUserCode]
		public void SetPFTermsNull()
		{
			base[tableDataTable2.PFTermsColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsPFNull()
		{
			return IsNull(tableDataTable2.PFColumn);
		}

		[DebuggerNonUserCode]
		public void SetPFNull()
		{
			base[tableDataTable2.PFColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsExciseValuesNull()
		{
			return IsNull(tableDataTable2.ExciseValuesColumn);
		}

		[DebuggerNonUserCode]
		public void SetExciseValuesNull()
		{
			base[tableDataTable2.ExciseValuesColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsExciseAmtNull()
		{
			return IsNull(tableDataTable2.ExciseAmtColumn);
		}

		[DebuggerNonUserCode]
		public void SetExciseAmtNull()
		{
			base[tableDataTable2.ExciseAmtColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsEDUCessNull()
		{
			return IsNull(tableDataTable2.EDUCessColumn);
		}

		[DebuggerNonUserCode]
		public void SetEDUCessNull()
		{
			base[tableDataTable2.EDUCessColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsEDUValueNull()
		{
			return IsNull(tableDataTable2.EDUValueColumn);
		}

		[DebuggerNonUserCode]
		public void SetEDUValueNull()
		{
			base[tableDataTable2.EDUValueColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsSHECessNull()
		{
			return IsNull(tableDataTable2.SHECessColumn);
		}

		[DebuggerNonUserCode]
		public void SetSHECessNull()
		{
			base[tableDataTable2.SHECessColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsSHEValueNull()
		{
			return IsNull(tableDataTable2.SHEValueColumn);
		}

		[DebuggerNonUserCode]
		public void SetSHEValueNull()
		{
			base[tableDataTable2.SHEValueColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsVATCSTTermsNull()
		{
			return IsNull(tableDataTable2.VATCSTTermsColumn);
		}

		[DebuggerNonUserCode]
		public void SetVATCSTTermsNull()
		{
			base[tableDataTable2.VATCSTTermsColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsVATCSTAmtNull()
		{
			return IsNull(tableDataTable2.VATCSTAmtColumn);
		}

		[DebuggerNonUserCode]
		public void SetVATCSTAmtNull()
		{
			base[tableDataTable2.VATCSTAmtColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsFreightAmtNull()
		{
			return IsNull(tableDataTable2.FreightAmtColumn);
		}

		[DebuggerNonUserCode]
		public void SetFreightAmtNull()
		{
			base[tableDataTable2.FreightAmtColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsTotAmtNull()
		{
			return IsNull(tableDataTable2.TotAmtColumn);
		}

		[DebuggerNonUserCode]
		public void SetTotAmtNull()
		{
			base[tableDataTable2.TotAmtColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsExciseBasicNull()
		{
			return IsNull(tableDataTable2.ExciseBasicColumn);
		}

		[DebuggerNonUserCode]
		public void SetExciseBasicNull()
		{
			base[tableDataTable2.ExciseBasicColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsExBasicAmtNull()
		{
			return IsNull(tableDataTable2.ExBasicAmtColumn);
		}

		[DebuggerNonUserCode]
		public void SetExBasicAmtNull()
		{
			base[tableDataTable2.ExBasicAmtColumn] = Convert.DBNull;
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

	private SchemaSerializationMode _schemaSerializationMode = SchemaSerializationMode.IncludeSchema;

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	[Browsable(false)]
	[DebuggerNonUserCode]
	public DataTable1DataTable DataTable1 => tableDataTable1;

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	[DebuggerNonUserCode]
	[Browsable(false)]
	public DataTable2DataTable DataTable2 => tableDataTable2;

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

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[DebuggerNonUserCode]
	public new DataRelationCollection Relations => base.Relations;

	[DebuggerNonUserCode]
	public Vat_Purchase()
	{
		BeginInit();
		InitClass();
		CollectionChangeEventHandler value = SchemaChanged;
		base.Tables.CollectionChanged += value;
		base.Relations.CollectionChanged += value;
		EndInit();
	}

	[DebuggerNonUserCode]
	protected Vat_Purchase(SerializationInfo info, StreamingContext context)
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
		Vat_Purchase vat_Purchase = (Vat_Purchase)base.Clone();
		vat_Purchase.InitVars();
		vat_Purchase.SchemaSerializationMode = SchemaSerializationMode;
		return vat_Purchase;
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
	}

	[DebuggerNonUserCode]
	private void InitClass()
	{
		base.DataSetName = "Vat_Purchase";
		base.Prefix = "";
		base.Namespace = "http://tempuri.org/Vat_Purchase.xsd";
		base.EnforceConstraints = true;
		SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
		tableDataTable1 = new DataTable1DataTable();
		base.Tables.Add(tableDataTable1);
		tableDataTable2 = new DataTable2DataTable();
		base.Tables.Add(tableDataTable2);
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
		Vat_Purchase vat_Purchase = new Vat_Purchase();
		XmlSchemaComplexType xmlSchemaComplexType = new XmlSchemaComplexType();
		XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
		XmlSchemaAny xmlSchemaAny = new XmlSchemaAny();
		xmlSchemaAny.Namespace = vat_Purchase.Namespace;
		xmlSchemaSequence.Items.Add(xmlSchemaAny);
		xmlSchemaComplexType.Particle = xmlSchemaSequence;
		XmlSchema schemaSerializable = vat_Purchase.GetSchemaSerializable();
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
