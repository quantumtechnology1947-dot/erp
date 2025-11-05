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
[XmlRoot("SalesExcise")]
[DesignerCategory("code")]
[XmlSchemaProvider("GetTypedDataSetSchema")]
[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
[ToolboxItem(true)]
public class SalesExcise : DataSet
{
	public delegate void DataTable1RowChangeEventHandler(object sender, DataTable1RowChangeEvent e);

	public delegate void DataTable2RowChangeEventHandler(object sender, DataTable2RowChangeEvent e);

	[Serializable]
	[XmlSchemaProvider("GetTypedTableSchema")]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
	public class DataTable1DataTable : TypedTableBase<DataTable1Row>
	{
		private DataColumn columnId;

		private DataColumn columnSysDate;

		private DataColumn columnCompId;

		private DataColumn columnCommodity;

		private DataColumn columnInvoiceNo;

		private DataColumn columnTarrifNo;

		private DataColumn columnUOM;

		private DataColumn columnMFG;

		private DataColumn columnCLR;

		private DataColumn columnCLO;

		private DataColumn columnAssValue;

		private DataColumn columnPF;

		private DataColumn columnCENVAT;

		private DataColumn columnFreight;

		private DataColumn columnSn;

		private DataColumn columnEdu;

		private DataColumn columnExcise;

		private DataColumn columnShe;

		private DataColumn columnVATCST;

		private DataColumn columnTotal;

		private DataColumn columnOtherAmt;

		[DebuggerNonUserCode]
		public DataColumn IdColumn => columnId;

		[DebuggerNonUserCode]
		public DataColumn SysDateColumn => columnSysDate;

		[DebuggerNonUserCode]
		public DataColumn CompIdColumn => columnCompId;

		[DebuggerNonUserCode]
		public DataColumn CommodityColumn => columnCommodity;

		[DebuggerNonUserCode]
		public DataColumn InvoiceNoColumn => columnInvoiceNo;

		[DebuggerNonUserCode]
		public DataColumn TarrifNoColumn => columnTarrifNo;

		[DebuggerNonUserCode]
		public DataColumn UOMColumn => columnUOM;

		[DebuggerNonUserCode]
		public DataColumn MFGColumn => columnMFG;

		[DebuggerNonUserCode]
		public DataColumn CLRColumn => columnCLR;

		[DebuggerNonUserCode]
		public DataColumn CLOColumn => columnCLO;

		[DebuggerNonUserCode]
		public DataColumn AssValueColumn => columnAssValue;

		[DebuggerNonUserCode]
		public DataColumn PFColumn => columnPF;

		[DebuggerNonUserCode]
		public DataColumn CENVATColumn => columnCENVAT;

		[DebuggerNonUserCode]
		public DataColumn FreightColumn => columnFreight;

		[DebuggerNonUserCode]
		public DataColumn SnColumn => columnSn;

		[DebuggerNonUserCode]
		public DataColumn EduColumn => columnEdu;

		[DebuggerNonUserCode]
		public DataColumn ExciseColumn => columnExcise;

		[DebuggerNonUserCode]
		public DataColumn SheColumn => columnShe;

		[DebuggerNonUserCode]
		public DataColumn VATCSTColumn => columnVATCST;

		[DebuggerNonUserCode]
		public DataColumn TotalColumn => columnTotal;

		[DebuggerNonUserCode]
		public DataColumn OtherAmtColumn => columnOtherAmt;

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
		public DataTable1Row AddDataTable1Row(int Id, string SysDate, int CompId, string Commodity, string InvoiceNo, string TarrifNo, string UOM, double MFG, double CLR, double CLO, double AssValue, double PF, double CENVAT, double Freight, int Sn, double Edu, double Excise, double She, double VATCST, double Total, double OtherAmt)
		{
			DataTable1Row dataTable1Row = (DataTable1Row)NewRow();
			object[] itemArray = new object[21]
			{
				Id, SysDate, CompId, Commodity, InvoiceNo, TarrifNo, UOM, MFG, CLR, CLO,
				AssValue, PF, CENVAT, Freight, Sn, Edu, Excise, She, VATCST, Total,
				OtherAmt
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
			columnCommodity = base.Columns["Commodity"];
			columnInvoiceNo = base.Columns["InvoiceNo"];
			columnTarrifNo = base.Columns["TarrifNo"];
			columnUOM = base.Columns["UOM"];
			columnMFG = base.Columns["MFG"];
			columnCLR = base.Columns["CLR"];
			columnCLO = base.Columns["CLO"];
			columnAssValue = base.Columns["AssValue"];
			columnPF = base.Columns["PF"];
			columnCENVAT = base.Columns["CENVAT"];
			columnFreight = base.Columns["Freight"];
			columnSn = base.Columns["Sn"];
			columnEdu = base.Columns["Edu"];
			columnExcise = base.Columns["Excise"];
			columnShe = base.Columns["She"];
			columnVATCST = base.Columns["VATCST"];
			columnTotal = base.Columns["Total"];
			columnOtherAmt = base.Columns["OtherAmt"];
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
			columnCommodity = new DataColumn("Commodity", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnCommodity);
			columnInvoiceNo = new DataColumn("InvoiceNo", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnInvoiceNo);
			columnTarrifNo = new DataColumn("TarrifNo", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnTarrifNo);
			columnUOM = new DataColumn("UOM", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnUOM);
			columnMFG = new DataColumn("MFG", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnMFG);
			columnCLR = new DataColumn("CLR", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnCLR);
			columnCLO = new DataColumn("CLO", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnCLO);
			columnAssValue = new DataColumn("AssValue", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnAssValue);
			columnPF = new DataColumn("PF", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnPF);
			columnCENVAT = new DataColumn("CENVAT", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnCENVAT);
			columnFreight = new DataColumn("Freight", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnFreight);
			columnSn = new DataColumn("Sn", typeof(int), null, MappingType.Element);
			base.Columns.Add(columnSn);
			columnEdu = new DataColumn("Edu", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnEdu);
			columnExcise = new DataColumn("Excise", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnExcise);
			columnShe = new DataColumn("She", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnShe);
			columnVATCST = new DataColumn("VATCST", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnVATCST);
			columnTotal = new DataColumn("Total", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnTotal);
			columnOtherAmt = new DataColumn("OtherAmt", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnOtherAmt);
			columnId.AllowDBNull = false;
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
			SalesExcise salesExcise = new SalesExcise();
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
			xmlSchemaAttribute.FixedValue = salesExcise.Namespace;
			xmlSchemaComplexType.Attributes.Add(xmlSchemaAttribute);
			XmlSchemaAttribute xmlSchemaAttribute2 = new XmlSchemaAttribute();
			xmlSchemaAttribute2.Name = "tableTypeName";
			xmlSchemaAttribute2.FixedValue = "DataTable1DataTable";
			xmlSchemaComplexType.Attributes.Add(xmlSchemaAttribute2);
			xmlSchemaComplexType.Particle = xmlSchemaSequence;
			XmlSchema schemaSerializable = salesExcise.GetSchemaSerializable();
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
		private DataColumn columnCompId;

		private DataColumn columnCommodity;

		private DataColumn columnCETSHNo;

		private DataColumn columnUOM;

		private DataColumn columnMFG;

		private DataColumn columnCLR;

		private DataColumn columnCLO;

		private DataColumn columnAssValue;

		private DataColumn columnPF;

		private DataColumn columnBasicAmt;

		private DataColumn columnCENVAT;

		private DataColumn columnFreight;

		private DataColumn columnSn;

		private DataColumn columnEdu;

		private DataColumn columnExcise;

		private DataColumn columnShe;

		private DataColumn columnVATCST;

		private DataColumn columnTotal;

		private DataColumn columns;

		[DebuggerNonUserCode]
		public DataColumn CompIdColumn => columnCompId;

		[DebuggerNonUserCode]
		public DataColumn CommodityColumn => columnCommodity;

		[DebuggerNonUserCode]
		public DataColumn CETSHNoColumn => columnCETSHNo;

		[DebuggerNonUserCode]
		public DataColumn UOMColumn => columnUOM;

		[DebuggerNonUserCode]
		public DataColumn MFGColumn => columnMFG;

		[DebuggerNonUserCode]
		public DataColumn CLRColumn => columnCLR;

		[DebuggerNonUserCode]
		public DataColumn CLOColumn => columnCLO;

		[DebuggerNonUserCode]
		public DataColumn AssValueColumn => columnAssValue;

		[DebuggerNonUserCode]
		public DataColumn PFColumn => columnPF;

		[DebuggerNonUserCode]
		public DataColumn BasicAmtColumn => columnBasicAmt;

		[DebuggerNonUserCode]
		public DataColumn CENVATColumn => columnCENVAT;

		[DebuggerNonUserCode]
		public DataColumn FreightColumn => columnFreight;

		[DebuggerNonUserCode]
		public DataColumn SnColumn => columnSn;

		[DebuggerNonUserCode]
		public DataColumn EduColumn => columnEdu;

		[DebuggerNonUserCode]
		public DataColumn ExciseColumn => columnExcise;

		[DebuggerNonUserCode]
		public DataColumn SheColumn => columnShe;

		[DebuggerNonUserCode]
		public DataColumn VATCSTColumn => columnVATCST;

		[DebuggerNonUserCode]
		public DataColumn TotalColumn => columnTotal;

		[DebuggerNonUserCode]
		public DataColumn sColumn => columns;

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
		public DataTable2Row AddDataTable2Row(int CompId, string Commodity, string CETSHNo, string UOM, double MFG, double CLR, double CLO, double AssValue, double PF, double BasicAmt, double CENVAT, double Freight, int Sn, double Edu, double Excise, double She, double VATCST, double Total, double s)
		{
			DataTable2Row dataTable2Row = (DataTable2Row)NewRow();
			object[] itemArray = new object[19]
			{
				CompId, Commodity, CETSHNo, UOM, MFG, CLR, CLO, AssValue, PF, BasicAmt,
				CENVAT, Freight, Sn, Edu, Excise, She, VATCST, Total, s
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
			columnCompId = base.Columns["CompId"];
			columnCommodity = base.Columns["Commodity"];
			columnCETSHNo = base.Columns["CETSHNo"];
			columnUOM = base.Columns["UOM"];
			columnMFG = base.Columns["MFG"];
			columnCLR = base.Columns["CLR"];
			columnCLO = base.Columns["CLO"];
			columnAssValue = base.Columns["AssValue"];
			columnPF = base.Columns["PF"];
			columnBasicAmt = base.Columns["BasicAmt"];
			columnCENVAT = base.Columns["CENVAT"];
			columnFreight = base.Columns["Freight"];
			columnSn = base.Columns["Sn"];
			columnEdu = base.Columns["Edu"];
			columnExcise = base.Columns["Excise"];
			columnShe = base.Columns["She"];
			columnVATCST = base.Columns["VATCST"];
			columnTotal = base.Columns["Total"];
			columns = base.Columns["s"];
		}

		[DebuggerNonUserCode]
		private void InitClass()
		{
			columnCompId = new DataColumn("CompId", typeof(int), null, MappingType.Element);
			base.Columns.Add(columnCompId);
			columnCommodity = new DataColumn("Commodity", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnCommodity);
			columnCETSHNo = new DataColumn("CETSHNo", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnCETSHNo);
			columnUOM = new DataColumn("UOM", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnUOM);
			columnMFG = new DataColumn("MFG", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnMFG);
			columnCLR = new DataColumn("CLR", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnCLR);
			columnCLO = new DataColumn("CLO", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnCLO);
			columnAssValue = new DataColumn("AssValue", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnAssValue);
			columnPF = new DataColumn("PF", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnPF);
			columnBasicAmt = new DataColumn("BasicAmt", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnBasicAmt);
			columnCENVAT = new DataColumn("CENVAT", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnCENVAT);
			columnFreight = new DataColumn("Freight", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnFreight);
			columnSn = new DataColumn("Sn", typeof(int), null, MappingType.Element);
			base.Columns.Add(columnSn);
			columnEdu = new DataColumn("Edu", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnEdu);
			columnExcise = new DataColumn("Excise", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnExcise);
			columnShe = new DataColumn("She", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnShe);
			columnVATCST = new DataColumn("VATCST", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnVATCST);
			columnTotal = new DataColumn("Total", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnTotal);
			columns = new DataColumn("s", typeof(double), null, MappingType.Element);
			base.Columns.Add(columns);
			columnCETSHNo.Caption = "TarrifNo";
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
			SalesExcise salesExcise = new SalesExcise();
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
			xmlSchemaAttribute.FixedValue = salesExcise.Namespace;
			xmlSchemaComplexType.Attributes.Add(xmlSchemaAttribute);
			XmlSchemaAttribute xmlSchemaAttribute2 = new XmlSchemaAttribute();
			xmlSchemaAttribute2.Name = "tableTypeName";
			xmlSchemaAttribute2.FixedValue = "DataTable2DataTable";
			xmlSchemaComplexType.Attributes.Add(xmlSchemaAttribute2);
			xmlSchemaComplexType.Particle = xmlSchemaSequence;
			XmlSchema schemaSerializable = salesExcise.GetSchemaSerializable();
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
				return (int)base[tableDataTable1.IdColumn];
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
		public string Commodity
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.CommodityColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Commodity' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.CommodityColumn] = value;
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
		public string TarrifNo
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.TarrifNoColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'TarrifNo' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.TarrifNoColumn] = value;
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
		public double MFG
		{
			get
			{
				try
				{
					return (double)base[tableDataTable1.MFGColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'MFG' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.MFGColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public double CLR
		{
			get
			{
				try
				{
					return (double)base[tableDataTable1.CLRColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'CLR' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.CLRColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public double CLO
		{
			get
			{
				try
				{
					return (double)base[tableDataTable1.CLOColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'CLO' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.CLOColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public double AssValue
		{
			get
			{
				try
				{
					return (double)base[tableDataTable1.AssValueColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'AssValue' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.AssValueColumn] = value;
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
		public double CENVAT
		{
			get
			{
				try
				{
					return (double)base[tableDataTable1.CENVATColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'CENVAT' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.CENVATColumn] = value;
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
		public int Sn
		{
			get
			{
				try
				{
					return (int)base[tableDataTable1.SnColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Sn' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.SnColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public double Edu
		{
			get
			{
				try
				{
					return (double)base[tableDataTable1.EduColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Edu' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.EduColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public double Excise
		{
			get
			{
				try
				{
					return (double)base[tableDataTable1.ExciseColumn];
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
		public double She
		{
			get
			{
				try
				{
					return (double)base[tableDataTable1.SheColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'She' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.SheColumn] = value;
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
		public double OtherAmt
		{
			get
			{
				try
				{
					return (double)base[tableDataTable1.OtherAmtColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'OtherAmt' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.OtherAmtColumn] = value;
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
		public bool IsCommodityNull()
		{
			return IsNull(tableDataTable1.CommodityColumn);
		}

		[DebuggerNonUserCode]
		public void SetCommodityNull()
		{
			base[tableDataTable1.CommodityColumn] = Convert.DBNull;
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
		public bool IsTarrifNoNull()
		{
			return IsNull(tableDataTable1.TarrifNoColumn);
		}

		[DebuggerNonUserCode]
		public void SetTarrifNoNull()
		{
			base[tableDataTable1.TarrifNoColumn] = Convert.DBNull;
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
		public bool IsMFGNull()
		{
			return IsNull(tableDataTable1.MFGColumn);
		}

		[DebuggerNonUserCode]
		public void SetMFGNull()
		{
			base[tableDataTable1.MFGColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsCLRNull()
		{
			return IsNull(tableDataTable1.CLRColumn);
		}

		[DebuggerNonUserCode]
		public void SetCLRNull()
		{
			base[tableDataTable1.CLRColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsCLONull()
		{
			return IsNull(tableDataTable1.CLOColumn);
		}

		[DebuggerNonUserCode]
		public void SetCLONull()
		{
			base[tableDataTable1.CLOColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsAssValueNull()
		{
			return IsNull(tableDataTable1.AssValueColumn);
		}

		[DebuggerNonUserCode]
		public void SetAssValueNull()
		{
			base[tableDataTable1.AssValueColumn] = Convert.DBNull;
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
		public bool IsCENVATNull()
		{
			return IsNull(tableDataTable1.CENVATColumn);
		}

		[DebuggerNonUserCode]
		public void SetCENVATNull()
		{
			base[tableDataTable1.CENVATColumn] = Convert.DBNull;
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
		public bool IsSnNull()
		{
			return IsNull(tableDataTable1.SnColumn);
		}

		[DebuggerNonUserCode]
		public void SetSnNull()
		{
			base[tableDataTable1.SnColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsEduNull()
		{
			return IsNull(tableDataTable1.EduColumn);
		}

		[DebuggerNonUserCode]
		public void SetEduNull()
		{
			base[tableDataTable1.EduColumn] = Convert.DBNull;
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
		public bool IsSheNull()
		{
			return IsNull(tableDataTable1.SheColumn);
		}

		[DebuggerNonUserCode]
		public void SetSheNull()
		{
			base[tableDataTable1.SheColumn] = Convert.DBNull;
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
		public bool IsOtherAmtNull()
		{
			return IsNull(tableDataTable1.OtherAmtColumn);
		}

		[DebuggerNonUserCode]
		public void SetOtherAmtNull()
		{
			base[tableDataTable1.OtherAmtColumn] = Convert.DBNull;
		}
	}

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
	public class DataTable2Row : DataRow
	{
		private DataTable2DataTable tableDataTable2;

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
		public string Commodity
		{
			get
			{
				try
				{
					return (string)base[tableDataTable2.CommodityColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Commodity' in table 'DataTable2' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable2.CommodityColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string CETSHNo
		{
			get
			{
				try
				{
					return (string)base[tableDataTable2.CETSHNoColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'CETSHNo' in table 'DataTable2' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable2.CETSHNoColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string UOM
		{
			get
			{
				try
				{
					return (string)base[tableDataTable2.UOMColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'UOM' in table 'DataTable2' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable2.UOMColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public double MFG
		{
			get
			{
				try
				{
					return (double)base[tableDataTable2.MFGColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'MFG' in table 'DataTable2' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable2.MFGColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public double CLR
		{
			get
			{
				try
				{
					return (double)base[tableDataTable2.CLRColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'CLR' in table 'DataTable2' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable2.CLRColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public double CLO
		{
			get
			{
				try
				{
					return (double)base[tableDataTable2.CLOColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'CLO' in table 'DataTable2' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable2.CLOColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public double AssValue
		{
			get
			{
				try
				{
					return (double)base[tableDataTable2.AssValueColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'AssValue' in table 'DataTable2' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable2.AssValueColumn] = value;
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
		public double CENVAT
		{
			get
			{
				try
				{
					return (double)base[tableDataTable2.CENVATColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'CENVAT' in table 'DataTable2' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable2.CENVATColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public double Freight
		{
			get
			{
				try
				{
					return (double)base[tableDataTable2.FreightColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Freight' in table 'DataTable2' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable2.FreightColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public int Sn
		{
			get
			{
				try
				{
					return (int)base[tableDataTable2.SnColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Sn' in table 'DataTable2' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable2.SnColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public double Edu
		{
			get
			{
				try
				{
					return (double)base[tableDataTable2.EduColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Edu' in table 'DataTable2' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable2.EduColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public double Excise
		{
			get
			{
				try
				{
					return (double)base[tableDataTable2.ExciseColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Excise' in table 'DataTable2' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable2.ExciseColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public double She
		{
			get
			{
				try
				{
					return (double)base[tableDataTable2.SheColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'She' in table 'DataTable2' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable2.SheColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public double VATCST
		{
			get
			{
				try
				{
					return (double)base[tableDataTable2.VATCSTColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'VATCST' in table 'DataTable2' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable2.VATCSTColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public double Total
		{
			get
			{
				try
				{
					return (double)base[tableDataTable2.TotalColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Total' in table 'DataTable2' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable2.TotalColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public double s
		{
			get
			{
				try
				{
					return (double)base[tableDataTable2.sColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 's' in table 'DataTable2' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable2.sColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		internal DataTable2Row(DataRowBuilder rb)
			: base(rb)
		{
			tableDataTable2 = (DataTable2DataTable)base.Table;
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
		public bool IsCommodityNull()
		{
			return IsNull(tableDataTable2.CommodityColumn);
		}

		[DebuggerNonUserCode]
		public void SetCommodityNull()
		{
			base[tableDataTable2.CommodityColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsCETSHNoNull()
		{
			return IsNull(tableDataTable2.CETSHNoColumn);
		}

		[DebuggerNonUserCode]
		public void SetCETSHNoNull()
		{
			base[tableDataTable2.CETSHNoColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsUOMNull()
		{
			return IsNull(tableDataTable2.UOMColumn);
		}

		[DebuggerNonUserCode]
		public void SetUOMNull()
		{
			base[tableDataTable2.UOMColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsMFGNull()
		{
			return IsNull(tableDataTable2.MFGColumn);
		}

		[DebuggerNonUserCode]
		public void SetMFGNull()
		{
			base[tableDataTable2.MFGColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsCLRNull()
		{
			return IsNull(tableDataTable2.CLRColumn);
		}

		[DebuggerNonUserCode]
		public void SetCLRNull()
		{
			base[tableDataTable2.CLRColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsCLONull()
		{
			return IsNull(tableDataTable2.CLOColumn);
		}

		[DebuggerNonUserCode]
		public void SetCLONull()
		{
			base[tableDataTable2.CLOColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsAssValueNull()
		{
			return IsNull(tableDataTable2.AssValueColumn);
		}

		[DebuggerNonUserCode]
		public void SetAssValueNull()
		{
			base[tableDataTable2.AssValueColumn] = Convert.DBNull;
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
		public bool IsCENVATNull()
		{
			return IsNull(tableDataTable2.CENVATColumn);
		}

		[DebuggerNonUserCode]
		public void SetCENVATNull()
		{
			base[tableDataTable2.CENVATColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsFreightNull()
		{
			return IsNull(tableDataTable2.FreightColumn);
		}

		[DebuggerNonUserCode]
		public void SetFreightNull()
		{
			base[tableDataTable2.FreightColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsSnNull()
		{
			return IsNull(tableDataTable2.SnColumn);
		}

		[DebuggerNonUserCode]
		public void SetSnNull()
		{
			base[tableDataTable2.SnColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsEduNull()
		{
			return IsNull(tableDataTable2.EduColumn);
		}

		[DebuggerNonUserCode]
		public void SetEduNull()
		{
			base[tableDataTable2.EduColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsExciseNull()
		{
			return IsNull(tableDataTable2.ExciseColumn);
		}

		[DebuggerNonUserCode]
		public void SetExciseNull()
		{
			base[tableDataTable2.ExciseColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsSheNull()
		{
			return IsNull(tableDataTable2.SheColumn);
		}

		[DebuggerNonUserCode]
		public void SetSheNull()
		{
			base[tableDataTable2.SheColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsVATCSTNull()
		{
			return IsNull(tableDataTable2.VATCSTColumn);
		}

		[DebuggerNonUserCode]
		public void SetVATCSTNull()
		{
			base[tableDataTable2.VATCSTColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsTotalNull()
		{
			return IsNull(tableDataTable2.TotalColumn);
		}

		[DebuggerNonUserCode]
		public void SetTotalNull()
		{
			base[tableDataTable2.TotalColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IssNull()
		{
			return IsNull(tableDataTable2.sColumn);
		}

		[DebuggerNonUserCode]
		public void SetsNull()
		{
			base[tableDataTable2.sColumn] = Convert.DBNull;
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

	[DebuggerNonUserCode]
	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public DataTable1DataTable DataTable1 => tableDataTable1;

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	[DebuggerNonUserCode]
	[Browsable(false)]
	public DataTable2DataTable DataTable2 => tableDataTable2;

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

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[DebuggerNonUserCode]
	public new DataTableCollection Tables => base.Tables;

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[DebuggerNonUserCode]
	public new DataRelationCollection Relations => base.Relations;

	[DebuggerNonUserCode]
	public SalesExcise()
	{
		BeginInit();
		InitClass();
		CollectionChangeEventHandler value = SchemaChanged;
		base.Tables.CollectionChanged += value;
		base.Relations.CollectionChanged += value;
		EndInit();
	}

	[DebuggerNonUserCode]
	protected SalesExcise(SerializationInfo info, StreamingContext context)
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
		SalesExcise salesExcise = (SalesExcise)base.Clone();
		salesExcise.InitVars();
		salesExcise.SchemaSerializationMode = SchemaSerializationMode;
		return salesExcise;
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
		base.DataSetName = "SalesExcise";
		base.Prefix = "";
		base.Namespace = "http://tempuri.org/SalesExcise.xsd";
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
		SalesExcise salesExcise = new SalesExcise();
		XmlSchemaComplexType xmlSchemaComplexType = new XmlSchemaComplexType();
		XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
		XmlSchemaAny xmlSchemaAny = new XmlSchemaAny();
		xmlSchemaAny.Namespace = salesExcise.Namespace;
		xmlSchemaSequence.Items.Add(xmlSchemaAny);
		xmlSchemaComplexType.Particle = xmlSchemaSequence;
		XmlSchema schemaSerializable = salesExcise.GetSchemaSerializable();
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
