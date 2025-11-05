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
[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
[DesignerCategory("code")]
[ToolboxItem(true)]
[XmlSchemaProvider("GetTypedDataSetSchema")]
[XmlRoot("BankVoucher")]
public class BankVoucher : DataSet
{
	public delegate void DataTable1RowChangeEventHandler(object sender, DataTable1RowChangeEvent e);

	[Serializable]
	[XmlSchemaProvider("GetTypedTableSchema")]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
	public class DataTable1DataTable : TypedTableBase<DataTable1Row>
	{
		private DataColumn columnPaidTo;

		private DataColumn columnCompId;

		private DataColumn columnChequeDate;

		private DataColumn columnAmount;

		private DataColumn columnAddress;

		private DataColumn columnBVPNo;

		private DataColumn columnChequeNo;

		private DataColumn columnSysDate;

		private DataColumn columnBillNo;

		private DataColumn columnTypeECS;

		private DataColumn columnECS;

		private DataColumn columnInvoiceNo;

		private DataColumn columnParticular;

		private DataColumn columnInvDate;

		private DataColumn columnD1;

		private DataColumn columnD2;

		private DataColumn columnM1;

		private DataColumn columnM2;

		private DataColumn columnY1;

		private DataColumn columnY2;

		private DataColumn columnY3;

		private DataColumn columnY4;

		private DataColumn columnPayAmt;

		private DataColumn columnAddAmt;

		[DebuggerNonUserCode]
		public DataColumn PaidToColumn => columnPaidTo;

		[DebuggerNonUserCode]
		public DataColumn CompIdColumn => columnCompId;

		[DebuggerNonUserCode]
		public DataColumn ChequeDateColumn => columnChequeDate;

		[DebuggerNonUserCode]
		public DataColumn AmountColumn => columnAmount;

		[DebuggerNonUserCode]
		public DataColumn AddressColumn => columnAddress;

		[DebuggerNonUserCode]
		public DataColumn BVPNoColumn => columnBVPNo;

		[DebuggerNonUserCode]
		public DataColumn ChequeNoColumn => columnChequeNo;

		[DebuggerNonUserCode]
		public DataColumn SysDateColumn => columnSysDate;

		[DebuggerNonUserCode]
		public DataColumn BillNoColumn => columnBillNo;

		[DebuggerNonUserCode]
		public DataColumn TypeECSColumn => columnTypeECS;

		[DebuggerNonUserCode]
		public DataColumn ECSColumn => columnECS;

		[DebuggerNonUserCode]
		public DataColumn InvoiceNoColumn => columnInvoiceNo;

		[DebuggerNonUserCode]
		public DataColumn ParticularColumn => columnParticular;

		[DebuggerNonUserCode]
		public DataColumn InvDateColumn => columnInvDate;

		[DebuggerNonUserCode]
		public DataColumn D1Column => columnD1;

		[DebuggerNonUserCode]
		public DataColumn D2Column => columnD2;

		[DebuggerNonUserCode]
		public DataColumn M1Column => columnM1;

		[DebuggerNonUserCode]
		public DataColumn M2Column => columnM2;

		[DebuggerNonUserCode]
		public DataColumn Y1Column => columnY1;

		[DebuggerNonUserCode]
		public DataColumn Y2Column => columnY2;

		[DebuggerNonUserCode]
		public DataColumn Y3Column => columnY3;

		[DebuggerNonUserCode]
		public DataColumn Y4Column => columnY4;

		[DebuggerNonUserCode]
		public DataColumn PayAmtColumn => columnPayAmt;

		[DebuggerNonUserCode]
		public DataColumn AddAmtColumn => columnAddAmt;

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
		public DataTable1Row AddDataTable1Row(string PaidTo, int CompId, string ChequeDate, double Amount, string Address, string BVPNo, string ChequeNo, string SysDate, string BillNo, string TypeECS, string ECS, string InvoiceNo, string Particular, string InvDate, string D1, string D2, string M1, string M2, string Y1, string Y2, string Y3, string Y4, double PayAmt, double AddAmt)
		{
			DataTable1Row dataTable1Row = (DataTable1Row)NewRow();
			object[] itemArray = new object[24]
			{
				PaidTo, CompId, ChequeDate, Amount, Address, BVPNo, ChequeNo, SysDate, BillNo, TypeECS,
				ECS, InvoiceNo, Particular, InvDate, D1, D2, M1, M2, Y1, Y2,
				Y3, Y4, PayAmt, AddAmt
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
			columnPaidTo = base.Columns["PaidTo"];
			columnCompId = base.Columns["CompId"];
			columnChequeDate = base.Columns["ChequeDate"];
			columnAmount = base.Columns["Amount"];
			columnAddress = base.Columns["Address"];
			columnBVPNo = base.Columns["BVPNo"];
			columnChequeNo = base.Columns["ChequeNo"];
			columnSysDate = base.Columns["SysDate"];
			columnBillNo = base.Columns["BillNo"];
			columnTypeECS = base.Columns["TypeECS"];
			columnECS = base.Columns["ECS"];
			columnInvoiceNo = base.Columns["InvoiceNo"];
			columnParticular = base.Columns["Particular"];
			columnInvDate = base.Columns["InvDate"];
			columnD1 = base.Columns["D1"];
			columnD2 = base.Columns["D2"];
			columnM1 = base.Columns["M1"];
			columnM2 = base.Columns["M2"];
			columnY1 = base.Columns["Y1"];
			columnY2 = base.Columns["Y2"];
			columnY3 = base.Columns["Y3"];
			columnY4 = base.Columns["Y4"];
			columnPayAmt = base.Columns["PayAmt"];
			columnAddAmt = base.Columns["AddAmt"];
		}

		[DebuggerNonUserCode]
		private void InitClass()
		{
			columnPaidTo = new DataColumn("PaidTo", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnPaidTo);
			columnCompId = new DataColumn("CompId", typeof(int), null, MappingType.Element);
			base.Columns.Add(columnCompId);
			columnChequeDate = new DataColumn("ChequeDate", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnChequeDate);
			columnAmount = new DataColumn("Amount", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnAmount);
			columnAddress = new DataColumn("Address", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnAddress);
			columnBVPNo = new DataColumn("BVPNo", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnBVPNo);
			columnChequeNo = new DataColumn("ChequeNo", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnChequeNo);
			columnSysDate = new DataColumn("SysDate", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnSysDate);
			columnBillNo = new DataColumn("BillNo", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnBillNo);
			columnTypeECS = new DataColumn("TypeECS", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnTypeECS);
			columnECS = new DataColumn("ECS", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnECS);
			columnInvoiceNo = new DataColumn("InvoiceNo", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnInvoiceNo);
			columnParticular = new DataColumn("Particular", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnParticular);
			columnInvDate = new DataColumn("InvDate", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnInvDate);
			columnD1 = new DataColumn("D1", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnD1);
			columnD2 = new DataColumn("D2", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnD2);
			columnM1 = new DataColumn("M1", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnM1);
			columnM2 = new DataColumn("M2", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnM2);
			columnY1 = new DataColumn("Y1", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnY1);
			columnY2 = new DataColumn("Y2", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnY2);
			columnY3 = new DataColumn("Y3", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnY3);
			columnY4 = new DataColumn("Y4", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnY4);
			columnPayAmt = new DataColumn("PayAmt", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnPayAmt);
			columnAddAmt = new DataColumn("AddAmt", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnAddAmt);
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
			BankVoucher bankVoucher = new BankVoucher();
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
			xmlSchemaAttribute.FixedValue = bankVoucher.Namespace;
			xmlSchemaComplexType.Attributes.Add(xmlSchemaAttribute);
			XmlSchemaAttribute xmlSchemaAttribute2 = new XmlSchemaAttribute();
			xmlSchemaAttribute2.Name = "tableTypeName";
			xmlSchemaAttribute2.FixedValue = "DataTable1DataTable";
			xmlSchemaComplexType.Attributes.Add(xmlSchemaAttribute2);
			xmlSchemaComplexType.Particle = xmlSchemaSequence;
			XmlSchema schemaSerializable = bankVoucher.GetSchemaSerializable();
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
		public string PaidTo
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.PaidToColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'PaidTo' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.PaidToColumn] = value;
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
		public string ChequeDate
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.ChequeDateColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'ChequeDate' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.ChequeDateColumn] = value;
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
		public string Address
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.AddressColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Address' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.AddressColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string BVPNo
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.BVPNoColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'BVPNo' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.BVPNoColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string ChequeNo
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.ChequeNoColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'ChequeNo' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.ChequeNoColumn] = value;
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
		public string TypeECS
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.TypeECSColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'TypeECS' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.TypeECSColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string ECS
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.ECSColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'ECS' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.ECSColumn] = value;
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
		public string Particular
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.ParticularColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Particular' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.ParticularColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string InvDate
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.InvDateColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'InvDate' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.InvDateColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string D1
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.D1Column];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'D1' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.D1Column] = value;
			}
		}

		[DebuggerNonUserCode]
		public string D2
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.D2Column];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'D2' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.D2Column] = value;
			}
		}

		[DebuggerNonUserCode]
		public string M1
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.M1Column];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'M1' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.M1Column] = value;
			}
		}

		[DebuggerNonUserCode]
		public string M2
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.M2Column];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'M2' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.M2Column] = value;
			}
		}

		[DebuggerNonUserCode]
		public string Y1
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.Y1Column];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Y1' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.Y1Column] = value;
			}
		}

		[DebuggerNonUserCode]
		public string Y2
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.Y2Column];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Y2' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.Y2Column] = value;
			}
		}

		[DebuggerNonUserCode]
		public string Y3
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.Y3Column];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Y3' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.Y3Column] = value;
			}
		}

		[DebuggerNonUserCode]
		public string Y4
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.Y4Column];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Y4' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.Y4Column] = value;
			}
		}

		[DebuggerNonUserCode]
		public double PayAmt
		{
			get
			{
				try
				{
					return (double)base[tableDataTable1.PayAmtColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'PayAmt' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.PayAmtColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public double AddAmt
		{
			get
			{
				try
				{
					return (double)base[tableDataTable1.AddAmtColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'AddAmt' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.AddAmtColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		internal DataTable1Row(DataRowBuilder rb)
			: base(rb)
		{
			tableDataTable1 = (DataTable1DataTable)base.Table;
		}

		[DebuggerNonUserCode]
		public bool IsPaidToNull()
		{
			return IsNull(tableDataTable1.PaidToColumn);
		}

		[DebuggerNonUserCode]
		public void SetPaidToNull()
		{
			base[tableDataTable1.PaidToColumn] = Convert.DBNull;
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
		public bool IsChequeDateNull()
		{
			return IsNull(tableDataTable1.ChequeDateColumn);
		}

		[DebuggerNonUserCode]
		public void SetChequeDateNull()
		{
			base[tableDataTable1.ChequeDateColumn] = Convert.DBNull;
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
		public bool IsAddressNull()
		{
			return IsNull(tableDataTable1.AddressColumn);
		}

		[DebuggerNonUserCode]
		public void SetAddressNull()
		{
			base[tableDataTable1.AddressColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsBVPNoNull()
		{
			return IsNull(tableDataTable1.BVPNoColumn);
		}

		[DebuggerNonUserCode]
		public void SetBVPNoNull()
		{
			base[tableDataTable1.BVPNoColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsChequeNoNull()
		{
			return IsNull(tableDataTable1.ChequeNoColumn);
		}

		[DebuggerNonUserCode]
		public void SetChequeNoNull()
		{
			base[tableDataTable1.ChequeNoColumn] = Convert.DBNull;
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
		public bool IsTypeECSNull()
		{
			return IsNull(tableDataTable1.TypeECSColumn);
		}

		[DebuggerNonUserCode]
		public void SetTypeECSNull()
		{
			base[tableDataTable1.TypeECSColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsECSNull()
		{
			return IsNull(tableDataTable1.ECSColumn);
		}

		[DebuggerNonUserCode]
		public void SetECSNull()
		{
			base[tableDataTable1.ECSColumn] = Convert.DBNull;
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
		public bool IsParticularNull()
		{
			return IsNull(tableDataTable1.ParticularColumn);
		}

		[DebuggerNonUserCode]
		public void SetParticularNull()
		{
			base[tableDataTable1.ParticularColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsInvDateNull()
		{
			return IsNull(tableDataTable1.InvDateColumn);
		}

		[DebuggerNonUserCode]
		public void SetInvDateNull()
		{
			base[tableDataTable1.InvDateColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsD1Null()
		{
			return IsNull(tableDataTable1.D1Column);
		}

		[DebuggerNonUserCode]
		public void SetD1Null()
		{
			base[tableDataTable1.D1Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsD2Null()
		{
			return IsNull(tableDataTable1.D2Column);
		}

		[DebuggerNonUserCode]
		public void SetD2Null()
		{
			base[tableDataTable1.D2Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsM1Null()
		{
			return IsNull(tableDataTable1.M1Column);
		}

		[DebuggerNonUserCode]
		public void SetM1Null()
		{
			base[tableDataTable1.M1Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsM2Null()
		{
			return IsNull(tableDataTable1.M2Column);
		}

		[DebuggerNonUserCode]
		public void SetM2Null()
		{
			base[tableDataTable1.M2Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsY1Null()
		{
			return IsNull(tableDataTable1.Y1Column);
		}

		[DebuggerNonUserCode]
		public void SetY1Null()
		{
			base[tableDataTable1.Y1Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsY2Null()
		{
			return IsNull(tableDataTable1.Y2Column);
		}

		[DebuggerNonUserCode]
		public void SetY2Null()
		{
			base[tableDataTable1.Y2Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsY3Null()
		{
			return IsNull(tableDataTable1.Y3Column);
		}

		[DebuggerNonUserCode]
		public void SetY3Null()
		{
			base[tableDataTable1.Y3Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsY4Null()
		{
			return IsNull(tableDataTable1.Y4Column);
		}

		[DebuggerNonUserCode]
		public void SetY4Null()
		{
			base[tableDataTable1.Y4Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsPayAmtNull()
		{
			return IsNull(tableDataTable1.PayAmtColumn);
		}

		[DebuggerNonUserCode]
		public void SetPayAmtNull()
		{
			base[tableDataTable1.PayAmtColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsAddAmtNull()
		{
			return IsNull(tableDataTable1.AddAmtColumn);
		}

		[DebuggerNonUserCode]
		public void SetAddAmtNull()
		{
			base[tableDataTable1.AddAmtColumn] = Convert.DBNull;
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

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	[DebuggerNonUserCode]
	[Browsable(false)]
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

	[DebuggerNonUserCode]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataRelationCollection Relations => base.Relations;

	[DebuggerNonUserCode]
	public BankVoucher()
	{
		BeginInit();
		InitClass();
		CollectionChangeEventHandler value = SchemaChanged;
		base.Tables.CollectionChanged += value;
		base.Relations.CollectionChanged += value;
		EndInit();
	}

	[DebuggerNonUserCode]
	protected BankVoucher(SerializationInfo info, StreamingContext context)
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
		BankVoucher bankVoucher = (BankVoucher)base.Clone();
		bankVoucher.InitVars();
		bankVoucher.SchemaSerializationMode = SchemaSerializationMode;
		return bankVoucher;
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
		base.DataSetName = "BankVoucher";
		base.Prefix = "";
		base.Namespace = "http://tempuri.org/BankVoucher.xsd";
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
		BankVoucher bankVoucher = new BankVoucher();
		XmlSchemaComplexType xmlSchemaComplexType = new XmlSchemaComplexType();
		XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
		XmlSchemaAny xmlSchemaAny = new XmlSchemaAny();
		xmlSchemaAny.Namespace = bankVoucher.Namespace;
		xmlSchemaSequence.Items.Add(xmlSchemaAny);
		xmlSchemaComplexType.Particle = xmlSchemaSequence;
		XmlSchema schemaSerializable = bankVoucher.GetSchemaSerializable();
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
