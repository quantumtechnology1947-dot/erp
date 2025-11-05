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
[XmlRoot("Vat_Sales")]
[XmlSchemaProvider("GetTypedDataSetSchema")]
[HelpKeyword("vs.data.DataSet")]
[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
[DesignerCategory("code")]
[ToolboxItem(true)]
public class Vat_Sales : DataSet
{
	public delegate void DataTable1RowChangeEventHandler(object sender, DataTable1RowChangeEvent e);

	public delegate void DataTable11RowChangeEventHandler(object sender, DataTable11RowChangeEvent e);

	[Serializable]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
	[XmlSchemaProvider("GetTypedTableSchema")]
	public class DataTable1DataTable : TypedTableBase<DataTable1Row>
	{
		private DataColumn columnId;

		private DataColumn columnSysDate;

		private DataColumn columnCompId;

		private DataColumn columnInvoiceNo;

		private DataColumn columnCustomerCode;

		private DataColumn columnCustomerName;

		private DataColumn columnTotal;

		private DataColumn columnExciseTerms;

		private DataColumn columnExciseValues;

		private DataColumn columnPFType;

		private DataColumn columnPF;

		private DataColumn columnAccessableValue;

		private DataColumn columnEDUCess;

		private DataColumn columnSHECess;

		private DataColumn columnFreightType;

		private DataColumn columnFreight;

		private DataColumn columnVATCSTTerms;

		private DataColumn columnVATCST;

		private DataColumn columnTotAmt;

		[DebuggerNonUserCode]
		public DataColumn IdColumn => columnId;

		[DebuggerNonUserCode]
		public DataColumn SysDateColumn => columnSysDate;

		[DebuggerNonUserCode]
		public DataColumn CompIdColumn => columnCompId;

		[DebuggerNonUserCode]
		public DataColumn InvoiceNoColumn => columnInvoiceNo;

		[DebuggerNonUserCode]
		public DataColumn CustomerCodeColumn => columnCustomerCode;

		[DebuggerNonUserCode]
		public DataColumn CustomerNameColumn => columnCustomerName;

		[DebuggerNonUserCode]
		public DataColumn TotalColumn => columnTotal;

		[DebuggerNonUserCode]
		public DataColumn ExciseTermsColumn => columnExciseTerms;

		[DebuggerNonUserCode]
		public DataColumn ExciseValuesColumn => columnExciseValues;

		[DebuggerNonUserCode]
		public DataColumn PFTypeColumn => columnPFType;

		[DebuggerNonUserCode]
		public DataColumn PFColumn => columnPF;

		[DebuggerNonUserCode]
		public DataColumn AccessableValueColumn => columnAccessableValue;

		[DebuggerNonUserCode]
		public DataColumn EDUCessColumn => columnEDUCess;

		[DebuggerNonUserCode]
		public DataColumn SHECessColumn => columnSHECess;

		[DebuggerNonUserCode]
		public DataColumn FreightTypeColumn => columnFreightType;

		[DebuggerNonUserCode]
		public DataColumn FreightColumn => columnFreight;

		[DebuggerNonUserCode]
		public DataColumn VATCSTTermsColumn => columnVATCSTTerms;

		[DebuggerNonUserCode]
		public DataColumn VATCSTColumn => columnVATCST;

		[DebuggerNonUserCode]
		public DataColumn TotAmtColumn => columnTotAmt;

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
		public DataTable1Row AddDataTable1Row(int Id, string SysDate, int CompId, string InvoiceNo, string CustomerCode, string CustomerName, double Total, string ExciseTerms, double ExciseValues, int PFType, double PF, double AccessableValue, double EDUCess, double SHECess, int FreightType, double Freight, string VATCSTTerms, double VATCST, double TotAmt)
		{
			DataTable1Row dataTable1Row = (DataTable1Row)NewRow();
			object[] itemArray = new object[19]
			{
				Id, SysDate, CompId, InvoiceNo, CustomerCode, CustomerName, Total, ExciseTerms, ExciseValues, PFType,
				PF, AccessableValue, EDUCess, SHECess, FreightType, Freight, VATCSTTerms, VATCST, TotAmt
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
			columnId = base.Columns["Id"];
			columnSysDate = base.Columns["SysDate"];
			columnCompId = base.Columns["CompId"];
			columnInvoiceNo = base.Columns["InvoiceNo"];
			columnCustomerCode = base.Columns["CustomerCode"];
			columnCustomerName = base.Columns["CustomerName"];
			columnTotal = base.Columns["Total"];
			columnExciseTerms = base.Columns["ExciseTerms"];
			columnExciseValues = base.Columns["ExciseValues"];
			columnPFType = base.Columns["PFType"];
			columnPF = base.Columns["PF"];
			columnAccessableValue = base.Columns["AccessableValue"];
			columnEDUCess = base.Columns["EDUCess"];
			columnSHECess = base.Columns["SHECess"];
			columnFreightType = base.Columns["FreightType"];
			columnFreight = base.Columns["Freight"];
			columnVATCSTTerms = base.Columns["VATCSTTerms"];
			columnVATCST = base.Columns["VATCST"];
			columnTotAmt = base.Columns["TotAmt"];
		}

		[DebuggerNonUserCode]
		private void InitClass()
		{
			columnId = new DataColumn("Id", typeof(int), null, MappingType.Element);
			base.Columns.Add(columnId);
			columnSysDate = new DataColumn("SysDate", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnSysDate);
			columnCompId = new DataColumn("CompId", typeof(int), null, MappingType.Element);
			base.Columns.Add(columnCompId);
			columnInvoiceNo = new DataColumn("InvoiceNo", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnInvoiceNo);
			columnCustomerCode = new DataColumn("CustomerCode", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnCustomerCode);
			columnCustomerName = new DataColumn("CustomerName", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnCustomerName);
			columnTotal = new DataColumn("Total", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnTotal);
			columnExciseTerms = new DataColumn("ExciseTerms", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnExciseTerms);
			columnExciseValues = new DataColumn("ExciseValues", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnExciseValues);
			columnPFType = new DataColumn("PFType", typeof(int), null, MappingType.Element);
			base.Columns.Add(columnPFType);
			columnPF = new DataColumn("PF", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnPF);
			columnAccessableValue = new DataColumn("AccessableValue", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnAccessableValue);
			columnEDUCess = new DataColumn("EDUCess", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnEDUCess);
			columnSHECess = new DataColumn("SHECess", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnSHECess);
			columnFreightType = new DataColumn("FreightType", typeof(int), null, MappingType.Element);
			base.Columns.Add(columnFreightType);
			columnFreight = new DataColumn("Freight", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnFreight);
			columnVATCSTTerms = new DataColumn("VATCSTTerms", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnVATCSTTerms);
			columnVATCST = new DataColumn("VATCST", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnVATCST);
			columnTotAmt = new DataColumn("TotAmt", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnTotAmt);
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
			Vat_Sales vat_Sales = new Vat_Sales();
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
			xmlSchemaAttribute.FixedValue = vat_Sales.Namespace;
			xmlSchemaComplexType.Attributes.Add(xmlSchemaAttribute);
			XmlSchemaAttribute xmlSchemaAttribute2 = new XmlSchemaAttribute();
			xmlSchemaAttribute2.Name = "tableTypeName";
			xmlSchemaAttribute2.FixedValue = "DataTable1DataTable";
			xmlSchemaComplexType.Attributes.Add(xmlSchemaAttribute2);
			xmlSchemaComplexType.Particle = xmlSchemaSequence;
			XmlSchema schemaSerializable = vat_Sales.GetSchemaSerializable();
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
	public class DataTable11DataTable : TypedTableBase<DataTable11Row>
	{
		private DataColumn columnId;

		private DataColumn columnSysDate;

		private DataColumn columnCompId;

		private DataColumn columnInvoiceNo;

		private DataColumn columnCustomerCode;

		private DataColumn columnCustomerName;

		private DataColumn columnTotal;

		private DataColumn columnExciseTerms;

		private DataColumn columnExciseValues;

		private DataColumn columnPFType;

		private DataColumn columnPF;

		private DataColumn columnAccessableValue;

		private DataColumn columnEDUCess;

		private DataColumn columnSHECess;

		private DataColumn columnFreightType;

		private DataColumn columnFreight;

		private DataColumn columnVATCSTTerms;

		private DataColumn columnVATCST;

		private DataColumn columnTotAmt;

		[DebuggerNonUserCode]
		public DataColumn IdColumn => columnId;

		[DebuggerNonUserCode]
		public DataColumn SysDateColumn => columnSysDate;

		[DebuggerNonUserCode]
		public DataColumn CompIdColumn => columnCompId;

		[DebuggerNonUserCode]
		public DataColumn InvoiceNoColumn => columnInvoiceNo;

		[DebuggerNonUserCode]
		public DataColumn CustomerCodeColumn => columnCustomerCode;

		[DebuggerNonUserCode]
		public DataColumn CustomerNameColumn => columnCustomerName;

		[DebuggerNonUserCode]
		public DataColumn TotalColumn => columnTotal;

		[DebuggerNonUserCode]
		public DataColumn ExciseTermsColumn => columnExciseTerms;

		[DebuggerNonUserCode]
		public DataColumn ExciseValuesColumn => columnExciseValues;

		[DebuggerNonUserCode]
		public DataColumn PFTypeColumn => columnPFType;

		[DebuggerNonUserCode]
		public DataColumn PFColumn => columnPF;

		[DebuggerNonUserCode]
		public DataColumn AccessableValueColumn => columnAccessableValue;

		[DebuggerNonUserCode]
		public DataColumn EDUCessColumn => columnEDUCess;

		[DebuggerNonUserCode]
		public DataColumn SHECessColumn => columnSHECess;

		[DebuggerNonUserCode]
		public DataColumn FreightTypeColumn => columnFreightType;

		[DebuggerNonUserCode]
		public DataColumn FreightColumn => columnFreight;

		[DebuggerNonUserCode]
		public DataColumn VATCSTTermsColumn => columnVATCSTTerms;

		[DebuggerNonUserCode]
		public DataColumn VATCSTColumn => columnVATCST;

		[DebuggerNonUserCode]
		public DataColumn TotAmtColumn => columnTotAmt;

		[Browsable(false)]
		[DebuggerNonUserCode]
		public int Count => base.Rows.Count;

		[DebuggerNonUserCode]
		public DataTable11Row this[int index] => (DataTable11Row)base.Rows[index];

		public event DataTable11RowChangeEventHandler DataTable11RowChanging;

		public event DataTable11RowChangeEventHandler DataTable11RowChanged;

		public event DataTable11RowChangeEventHandler DataTable11RowDeleting;

		public event DataTable11RowChangeEventHandler DataTable11RowDeleted;

		[DebuggerNonUserCode]
		public DataTable11DataTable()
		{
			base.TableName = "DataTable11";
			BeginInit();
			InitClass();
			EndInit();
		}

		[DebuggerNonUserCode]
		internal DataTable11DataTable(DataTable table)
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
		protected DataTable11DataTable(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
			InitVars();
		}

		[DebuggerNonUserCode]
		public void AddDataTable11Row(DataTable11Row row)
		{
			base.Rows.Add(row);
		}

		[DebuggerNonUserCode]
		public DataTable11Row AddDataTable11Row(int Id, string SysDate, int CompId, string InvoiceNo, string CustomerCode, string CustomerName, double Total, string ExciseTerms, double ExciseValues, int PFType, double PF, double AccessableValue, double EDUCess, double SHECess, int FreightType, double Freight, string VATCSTTerms, double VATCST, double TotAmt)
		{
			DataTable11Row dataTable11Row = (DataTable11Row)NewRow();
			object[] itemArray = new object[19]
			{
				Id, SysDate, CompId, InvoiceNo, CustomerCode, CustomerName, Total, ExciseTerms, ExciseValues, PFType,
				PF, AccessableValue, EDUCess, SHECess, FreightType, Freight, VATCSTTerms, VATCST, TotAmt
			};
			dataTable11Row.ItemArray = itemArray;
			base.Rows.Add(dataTable11Row);
			return dataTable11Row;
		}

		[DebuggerNonUserCode]
		public override DataTable Clone()
		{
			DataTable11DataTable dataTable11DataTable = (DataTable11DataTable)base.Clone();
			dataTable11DataTable.InitVars();
			return dataTable11DataTable;
		}

		[DebuggerNonUserCode]
		protected override DataTable CreateInstance()
		{
			return new DataTable11DataTable();
		}

		[DebuggerNonUserCode]
		internal void InitVars()
		{
			columnId = base.Columns["Id"];
			columnSysDate = base.Columns["SysDate"];
			columnCompId = base.Columns["CompId"];
			columnInvoiceNo = base.Columns["InvoiceNo"];
			columnCustomerCode = base.Columns["CustomerCode"];
			columnCustomerName = base.Columns["CustomerName"];
			columnTotal = base.Columns["Total"];
			columnExciseTerms = base.Columns["ExciseTerms"];
			columnExciseValues = base.Columns["ExciseValues"];
			columnPFType = base.Columns["PFType"];
			columnPF = base.Columns["PF"];
			columnAccessableValue = base.Columns["AccessableValue"];
			columnEDUCess = base.Columns["EDUCess"];
			columnSHECess = base.Columns["SHECess"];
			columnFreightType = base.Columns["FreightType"];
			columnFreight = base.Columns["Freight"];
			columnVATCSTTerms = base.Columns["VATCSTTerms"];
			columnVATCST = base.Columns["VATCST"];
			columnTotAmt = base.Columns["TotAmt"];
		}

		[DebuggerNonUserCode]
		private void InitClass()
		{
			columnId = new DataColumn("Id", typeof(int), null, MappingType.Element);
			base.Columns.Add(columnId);
			columnSysDate = new DataColumn("SysDate", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnSysDate);
			columnCompId = new DataColumn("CompId", typeof(int), null, MappingType.Element);
			base.Columns.Add(columnCompId);
			columnInvoiceNo = new DataColumn("InvoiceNo", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnInvoiceNo);
			columnCustomerCode = new DataColumn("CustomerCode", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnCustomerCode);
			columnCustomerName = new DataColumn("CustomerName", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnCustomerName);
			columnTotal = new DataColumn("Total", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnTotal);
			columnExciseTerms = new DataColumn("ExciseTerms", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnExciseTerms);
			columnExciseValues = new DataColumn("ExciseValues", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnExciseValues);
			columnPFType = new DataColumn("PFType", typeof(int), null, MappingType.Element);
			base.Columns.Add(columnPFType);
			columnPF = new DataColumn("PF", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnPF);
			columnAccessableValue = new DataColumn("AccessableValue", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnAccessableValue);
			columnEDUCess = new DataColumn("EDUCess", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnEDUCess);
			columnSHECess = new DataColumn("SHECess", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnSHECess);
			columnFreightType = new DataColumn("FreightType", typeof(int), null, MappingType.Element);
			base.Columns.Add(columnFreightType);
			columnFreight = new DataColumn("Freight", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnFreight);
			columnVATCSTTerms = new DataColumn("VATCSTTerms", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnVATCSTTerms);
			columnVATCST = new DataColumn("VATCST", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnVATCST);
			columnTotAmt = new DataColumn("TotAmt", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnTotAmt);
		}

		[DebuggerNonUserCode]
		public DataTable11Row NewDataTable11Row()
		{
			return (DataTable11Row)NewRow();
		}

		[DebuggerNonUserCode]
		protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
		{
			return new DataTable11Row(builder);
		}

		[DebuggerNonUserCode]
		protected override Type GetRowType()
		{
			return typeof(DataTable11Row);
		}

		[DebuggerNonUserCode]
		protected override void OnRowChanged(DataRowChangeEventArgs e)
		{
			base.OnRowChanged(e);
			if (this.DataTable11RowChanged != null)
			{
				this.DataTable11RowChanged(this, new DataTable11RowChangeEvent((DataTable11Row)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		protected override void OnRowChanging(DataRowChangeEventArgs e)
		{
			base.OnRowChanging(e);
			if (this.DataTable11RowChanging != null)
			{
				this.DataTable11RowChanging(this, new DataTable11RowChangeEvent((DataTable11Row)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		protected override void OnRowDeleted(DataRowChangeEventArgs e)
		{
			base.OnRowDeleted(e);
			if (this.DataTable11RowDeleted != null)
			{
				this.DataTable11RowDeleted(this, new DataTable11RowChangeEvent((DataTable11Row)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		protected override void OnRowDeleting(DataRowChangeEventArgs e)
		{
			base.OnRowDeleting(e);
			if (this.DataTable11RowDeleting != null)
			{
				this.DataTable11RowDeleting(this, new DataTable11RowChangeEvent((DataTable11Row)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		public void RemoveDataTable11Row(DataTable11Row row)
		{
			base.Rows.Remove(row);
		}

		[DebuggerNonUserCode]
		public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
		{
			XmlSchemaComplexType xmlSchemaComplexType = new XmlSchemaComplexType();
			XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
			Vat_Sales vat_Sales = new Vat_Sales();
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
			xmlSchemaAttribute.FixedValue = vat_Sales.Namespace;
			xmlSchemaComplexType.Attributes.Add(xmlSchemaAttribute);
			XmlSchemaAttribute xmlSchemaAttribute2 = new XmlSchemaAttribute();
			xmlSchemaAttribute2.Name = "tableTypeName";
			xmlSchemaAttribute2.FixedValue = "DataTable11DataTable";
			xmlSchemaComplexType.Attributes.Add(xmlSchemaAttribute2);
			xmlSchemaComplexType.Particle = xmlSchemaSequence;
			XmlSchema schemaSerializable = vat_Sales.GetSchemaSerializable();
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
		public string InvoiceNo
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.InvoiceNoColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'InvoiceNo' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.InvoiceNoColumn] = value;
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
		public string CustomerName
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.CustomerNameColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'CustomerName' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.CustomerNameColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public double Total
		{
			get
			{
				try
				{
					return (double)base[tableDataTable1.TotalColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Total' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.TotalColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string ExciseTerms
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.ExciseTermsColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'ExciseTerms' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.ExciseTermsColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public double ExciseValues
		{
			get
			{
				try
				{
					return (double)base[tableDataTable1.ExciseValuesColumn];
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
		public int PFType
		{
			get
			{
				try
				{
					return (int)base[tableDataTable1.PFTypeColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'PFType' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.PFTypeColumn] = value;
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
		public double AccessableValue
		{
			get
			{
				try
				{
					return (double)base[tableDataTable1.AccessableValueColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'AccessableValue' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.AccessableValueColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public double EDUCess
		{
			get
			{
				try
				{
					return (double)base[tableDataTable1.EDUCessColumn];
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
		public double SHECess
		{
			get
			{
				try
				{
					return (double)base[tableDataTable1.SHECessColumn];
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
		public int FreightType
		{
			get
			{
				try
				{
					return (int)base[tableDataTable1.FreightTypeColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'FreightType' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.FreightTypeColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public double Freight
		{
			get
			{
				try
				{
					return (double)base[tableDataTable1.FreightColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Freight' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.FreightColumn] = value;
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
		public double VATCST
		{
			get
			{
				try
				{
					return (double)base[tableDataTable1.VATCSTColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'VATCST' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.VATCSTColumn] = value;
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
		internal DataTable1Row(DataRowBuilder rb)
			: base(rb)
		{
			tableDataTable1 = (DataTable1DataTable)base.Table;
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
		public bool IsInvoiceNoNull()
		{
			return IsNull(tableDataTable1.InvoiceNoColumn);
		}

		[DebuggerNonUserCode]
		public void SetInvoiceNoNull()
		{
			base[tableDataTable1.InvoiceNoColumn] = Convert.DBNull;
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
		public bool IsCustomerNameNull()
		{
			return IsNull(tableDataTable1.CustomerNameColumn);
		}

		[DebuggerNonUserCode]
		public void SetCustomerNameNull()
		{
			base[tableDataTable1.CustomerNameColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsTotalNull()
		{
			return IsNull(tableDataTable1.TotalColumn);
		}

		[DebuggerNonUserCode]
		public void SetTotalNull()
		{
			base[tableDataTable1.TotalColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsExciseTermsNull()
		{
			return IsNull(tableDataTable1.ExciseTermsColumn);
		}

		[DebuggerNonUserCode]
		public void SetExciseTermsNull()
		{
			base[tableDataTable1.ExciseTermsColumn] = Convert.DBNull;
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
		public bool IsPFTypeNull()
		{
			return IsNull(tableDataTable1.PFTypeColumn);
		}

		[DebuggerNonUserCode]
		public void SetPFTypeNull()
		{
			base[tableDataTable1.PFTypeColumn] = Convert.DBNull;
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
		public bool IsAccessableValueNull()
		{
			return IsNull(tableDataTable1.AccessableValueColumn);
		}

		[DebuggerNonUserCode]
		public void SetAccessableValueNull()
		{
			base[tableDataTable1.AccessableValueColumn] = Convert.DBNull;
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
		public bool IsFreightTypeNull()
		{
			return IsNull(tableDataTable1.FreightTypeColumn);
		}

		[DebuggerNonUserCode]
		public void SetFreightTypeNull()
		{
			base[tableDataTable1.FreightTypeColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsFreightNull()
		{
			return IsNull(tableDataTable1.FreightColumn);
		}

		[DebuggerNonUserCode]
		public void SetFreightNull()
		{
			base[tableDataTable1.FreightColumn] = Convert.DBNull;
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
		public bool IsVATCSTNull()
		{
			return IsNull(tableDataTable1.VATCSTColumn);
		}

		[DebuggerNonUserCode]
		public void SetVATCSTNull()
		{
			base[tableDataTable1.VATCSTColumn] = Convert.DBNull;
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
	}

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
	public class DataTable11Row : DataRow
	{
		private DataTable11DataTable tableDataTable11;

		[DebuggerNonUserCode]
		public int Id
		{
			get
			{
				try
				{
					return (int)base[tableDataTable11.IdColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Id' in table 'DataTable11' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable11.IdColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string SysDate
		{
			get
			{
				try
				{
					return (string)base[tableDataTable11.SysDateColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'SysDate' in table 'DataTable11' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable11.SysDateColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public int CompId
		{
			get
			{
				try
				{
					return (int)base[tableDataTable11.CompIdColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'CompId' in table 'DataTable11' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable11.CompIdColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string InvoiceNo
		{
			get
			{
				try
				{
					return (string)base[tableDataTable11.InvoiceNoColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'InvoiceNo' in table 'DataTable11' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable11.InvoiceNoColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string CustomerCode
		{
			get
			{
				try
				{
					return (string)base[tableDataTable11.CustomerCodeColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'CustomerCode' in table 'DataTable11' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable11.CustomerCodeColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string CustomerName
		{
			get
			{
				try
				{
					return (string)base[tableDataTable11.CustomerNameColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'CustomerName' in table 'DataTable11' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable11.CustomerNameColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public double Total
		{
			get
			{
				try
				{
					return (double)base[tableDataTable11.TotalColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Total' in table 'DataTable11' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable11.TotalColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string ExciseTerms
		{
			get
			{
				try
				{
					return (string)base[tableDataTable11.ExciseTermsColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'ExciseTerms' in table 'DataTable11' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable11.ExciseTermsColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public double ExciseValues
		{
			get
			{
				try
				{
					return (double)base[tableDataTable11.ExciseValuesColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'ExciseValues' in table 'DataTable11' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable11.ExciseValuesColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public int PFType
		{
			get
			{
				try
				{
					return (int)base[tableDataTable11.PFTypeColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'PFType' in table 'DataTable11' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable11.PFTypeColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public double PF
		{
			get
			{
				try
				{
					return (double)base[tableDataTable11.PFColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'PF' in table 'DataTable11' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable11.PFColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public double AccessableValue
		{
			get
			{
				try
				{
					return (double)base[tableDataTable11.AccessableValueColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'AccessableValue' in table 'DataTable11' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable11.AccessableValueColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public double EDUCess
		{
			get
			{
				try
				{
					return (double)base[tableDataTable11.EDUCessColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'EDUCess' in table 'DataTable11' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable11.EDUCessColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public double SHECess
		{
			get
			{
				try
				{
					return (double)base[tableDataTable11.SHECessColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'SHECess' in table 'DataTable11' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable11.SHECessColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public int FreightType
		{
			get
			{
				try
				{
					return (int)base[tableDataTable11.FreightTypeColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'FreightType' in table 'DataTable11' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable11.FreightTypeColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public double Freight
		{
			get
			{
				try
				{
					return (double)base[tableDataTable11.FreightColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Freight' in table 'DataTable11' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable11.FreightColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string VATCSTTerms
		{
			get
			{
				try
				{
					return (string)base[tableDataTable11.VATCSTTermsColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'VATCSTTerms' in table 'DataTable11' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable11.VATCSTTermsColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public double VATCST
		{
			get
			{
				try
				{
					return (double)base[tableDataTable11.VATCSTColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'VATCST' in table 'DataTable11' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable11.VATCSTColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public double TotAmt
		{
			get
			{
				try
				{
					return (double)base[tableDataTable11.TotAmtColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'TotAmt' in table 'DataTable11' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable11.TotAmtColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		internal DataTable11Row(DataRowBuilder rb)
			: base(rb)
		{
			tableDataTable11 = (DataTable11DataTable)base.Table;
		}

		[DebuggerNonUserCode]
		public bool IsIdNull()
		{
			return IsNull(tableDataTable11.IdColumn);
		}

		[DebuggerNonUserCode]
		public void SetIdNull()
		{
			base[tableDataTable11.IdColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsSysDateNull()
		{
			return IsNull(tableDataTable11.SysDateColumn);
		}

		[DebuggerNonUserCode]
		public void SetSysDateNull()
		{
			base[tableDataTable11.SysDateColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsCompIdNull()
		{
			return IsNull(tableDataTable11.CompIdColumn);
		}

		[DebuggerNonUserCode]
		public void SetCompIdNull()
		{
			base[tableDataTable11.CompIdColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsInvoiceNoNull()
		{
			return IsNull(tableDataTable11.InvoiceNoColumn);
		}

		[DebuggerNonUserCode]
		public void SetInvoiceNoNull()
		{
			base[tableDataTable11.InvoiceNoColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsCustomerCodeNull()
		{
			return IsNull(tableDataTable11.CustomerCodeColumn);
		}

		[DebuggerNonUserCode]
		public void SetCustomerCodeNull()
		{
			base[tableDataTable11.CustomerCodeColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsCustomerNameNull()
		{
			return IsNull(tableDataTable11.CustomerNameColumn);
		}

		[DebuggerNonUserCode]
		public void SetCustomerNameNull()
		{
			base[tableDataTable11.CustomerNameColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsTotalNull()
		{
			return IsNull(tableDataTable11.TotalColumn);
		}

		[DebuggerNonUserCode]
		public void SetTotalNull()
		{
			base[tableDataTable11.TotalColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsExciseTermsNull()
		{
			return IsNull(tableDataTable11.ExciseTermsColumn);
		}

		[DebuggerNonUserCode]
		public void SetExciseTermsNull()
		{
			base[tableDataTable11.ExciseTermsColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsExciseValuesNull()
		{
			return IsNull(tableDataTable11.ExciseValuesColumn);
		}

		[DebuggerNonUserCode]
		public void SetExciseValuesNull()
		{
			base[tableDataTable11.ExciseValuesColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsPFTypeNull()
		{
			return IsNull(tableDataTable11.PFTypeColumn);
		}

		[DebuggerNonUserCode]
		public void SetPFTypeNull()
		{
			base[tableDataTable11.PFTypeColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsPFNull()
		{
			return IsNull(tableDataTable11.PFColumn);
		}

		[DebuggerNonUserCode]
		public void SetPFNull()
		{
			base[tableDataTable11.PFColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsAccessableValueNull()
		{
			return IsNull(tableDataTable11.AccessableValueColumn);
		}

		[DebuggerNonUserCode]
		public void SetAccessableValueNull()
		{
			base[tableDataTable11.AccessableValueColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsEDUCessNull()
		{
			return IsNull(tableDataTable11.EDUCessColumn);
		}

		[DebuggerNonUserCode]
		public void SetEDUCessNull()
		{
			base[tableDataTable11.EDUCessColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsSHECessNull()
		{
			return IsNull(tableDataTable11.SHECessColumn);
		}

		[DebuggerNonUserCode]
		public void SetSHECessNull()
		{
			base[tableDataTable11.SHECessColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsFreightTypeNull()
		{
			return IsNull(tableDataTable11.FreightTypeColumn);
		}

		[DebuggerNonUserCode]
		public void SetFreightTypeNull()
		{
			base[tableDataTable11.FreightTypeColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsFreightNull()
		{
			return IsNull(tableDataTable11.FreightColumn);
		}

		[DebuggerNonUserCode]
		public void SetFreightNull()
		{
			base[tableDataTable11.FreightColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsVATCSTTermsNull()
		{
			return IsNull(tableDataTable11.VATCSTTermsColumn);
		}

		[DebuggerNonUserCode]
		public void SetVATCSTTermsNull()
		{
			base[tableDataTable11.VATCSTTermsColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsVATCSTNull()
		{
			return IsNull(tableDataTable11.VATCSTColumn);
		}

		[DebuggerNonUserCode]
		public void SetVATCSTNull()
		{
			base[tableDataTable11.VATCSTColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsTotAmtNull()
		{
			return IsNull(tableDataTable11.TotAmtColumn);
		}

		[DebuggerNonUserCode]
		public void SetTotAmtNull()
		{
			base[tableDataTable11.TotAmtColumn] = Convert.DBNull;
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
	public class DataTable11RowChangeEvent : EventArgs
	{
		private DataTable11Row eventRow;

		private DataRowAction eventAction;

		[DebuggerNonUserCode]
		public DataTable11Row Row => eventRow;

		[DebuggerNonUserCode]
		public DataRowAction Action => eventAction;

		[DebuggerNonUserCode]
		public DataTable11RowChangeEvent(DataTable11Row row, DataRowAction action)
		{
			eventRow = row;
			eventAction = action;
		}
	}

	private DataTable1DataTable tableDataTable1;

	private DataTable11DataTable tableDataTable11;

	private SchemaSerializationMode _schemaSerializationMode = SchemaSerializationMode.IncludeSchema;

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	[DebuggerNonUserCode]
	[Browsable(false)]
	public DataTable1DataTable DataTable1 => tableDataTable1;

	[DebuggerNonUserCode]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	[Browsable(false)]
	public DataTable11DataTable DataTable11 => tableDataTable11;

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
	public Vat_Sales()
	{
		BeginInit();
		InitClass();
		CollectionChangeEventHandler value = SchemaChanged;
		base.Tables.CollectionChanged += value;
		base.Relations.CollectionChanged += value;
		EndInit();
	}

	[DebuggerNonUserCode]
	protected Vat_Sales(SerializationInfo info, StreamingContext context)
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
			if (dataSet.Tables["DataTable11"] != null)
			{
				base.Tables.Add(new DataTable11DataTable(dataSet.Tables["DataTable11"]));
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
		Vat_Sales vat_Sales = (Vat_Sales)base.Clone();
		vat_Sales.InitVars();
		vat_Sales.SchemaSerializationMode = SchemaSerializationMode;
		return vat_Sales;
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
			if (dataSet.Tables["DataTable11"] != null)
			{
				base.Tables.Add(new DataTable11DataTable(dataSet.Tables["DataTable11"]));
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
		tableDataTable11 = (DataTable11DataTable)base.Tables["DataTable11"];
		if (initTable && tableDataTable11 != null)
		{
			tableDataTable11.InitVars();
		}
	}

	[DebuggerNonUserCode]
	private void InitClass()
	{
		base.DataSetName = "Vat_Sales";
		base.Prefix = "";
		base.Namespace = "http://tempuri.org/Vat_Sales.xsd";
		base.EnforceConstraints = true;
		SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
		tableDataTable1 = new DataTable1DataTable();
		base.Tables.Add(tableDataTable1);
		tableDataTable11 = new DataTable11DataTable();
		base.Tables.Add(tableDataTable11);
	}

	[DebuggerNonUserCode]
	private bool ShouldSerializeDataTable1()
	{
		return false;
	}

	[DebuggerNonUserCode]
	private bool ShouldSerializeDataTable11()
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
		Vat_Sales vat_Sales = new Vat_Sales();
		XmlSchemaComplexType xmlSchemaComplexType = new XmlSchemaComplexType();
		XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
		XmlSchemaAny xmlSchemaAny = new XmlSchemaAny();
		xmlSchemaAny.Namespace = vat_Sales.Namespace;
		xmlSchemaSequence.Items.Add(xmlSchemaAny);
		xmlSchemaComplexType.Particle = xmlSchemaSequence;
		XmlSchema schemaSerializable = vat_Sales.GetSchemaSerializable();
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
