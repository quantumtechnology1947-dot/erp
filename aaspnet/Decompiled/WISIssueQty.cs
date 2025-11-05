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
[ToolboxItem(true)]
[HelpKeyword("vs.data.DataSet")]
[XmlRoot("WISIssueQty")]
[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
[XmlSchemaProvider("GetTypedDataSetSchema")]
public class WISIssueQty : DataSet
{
	public delegate void DataTable2RowChangeEventHandler(object sender, DataTable2RowChangeEvent e);

	[Serializable]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
	[XmlSchemaProvider("GetTypedTableSchema")]
	public class DataTable2DataTable : TypedTableBase<DataTable2Row>
	{
		private DataColumn columnItemCode;

		private DataColumn columnManfDesc;

		private DataColumn columnUOMBasic;

		private DataColumn columnWISNo;

		private DataColumn columnBOMQty;

		private DataColumn columnIssuedQty;

		private DataColumn columnGenBy;

		private DataColumn columnCompId;

		private DataColumn columnTaskTargetTryOut_FDate;

		private DataColumn columnTaskTargetTryOut_TDate;

		private DataColumn columnTaskTargetDespach_FDate;

		private DataColumn columnTaskTargetDespach_TDate;

		private DataColumn columnTaskProjectTitle;

		private DataColumn columnTaskProjectLeader;

		private DataColumn columnSysDate;

		private DataColumn columnWONo;

		private DataColumn columnStockQty;

		private DataColumn columnRate;

		[DebuggerNonUserCode]
		public DataColumn ItemCodeColumn => columnItemCode;

		[DebuggerNonUserCode]
		public DataColumn ManfDescColumn => columnManfDesc;

		[DebuggerNonUserCode]
		public DataColumn UOMBasicColumn => columnUOMBasic;

		[DebuggerNonUserCode]
		public DataColumn WISNoColumn => columnWISNo;

		[DebuggerNonUserCode]
		public DataColumn BOMQtyColumn => columnBOMQty;

		[DebuggerNonUserCode]
		public DataColumn IssuedQtyColumn => columnIssuedQty;

		[DebuggerNonUserCode]
		public DataColumn GenByColumn => columnGenBy;

		[DebuggerNonUserCode]
		public DataColumn CompIdColumn => columnCompId;

		[DebuggerNonUserCode]
		public DataColumn TaskTargetTryOut_FDateColumn => columnTaskTargetTryOut_FDate;

		[DebuggerNonUserCode]
		public DataColumn TaskTargetTryOut_TDateColumn => columnTaskTargetTryOut_TDate;

		[DebuggerNonUserCode]
		public DataColumn TaskTargetDespach_FDateColumn => columnTaskTargetDespach_FDate;

		[DebuggerNonUserCode]
		public DataColumn TaskTargetDespach_TDateColumn => columnTaskTargetDespach_TDate;

		[DebuggerNonUserCode]
		public DataColumn TaskProjectTitleColumn => columnTaskProjectTitle;

		[DebuggerNonUserCode]
		public DataColumn TaskProjectLeaderColumn => columnTaskProjectLeader;

		[DebuggerNonUserCode]
		public DataColumn SysDateColumn => columnSysDate;

		[DebuggerNonUserCode]
		public DataColumn WONoColumn => columnWONo;

		[DebuggerNonUserCode]
		public DataColumn StockQtyColumn => columnStockQty;

		[DebuggerNonUserCode]
		public DataColumn RateColumn => columnRate;

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
		public DataTable2Row AddDataTable2Row(string ItemCode, string ManfDesc, string UOMBasic, string WISNo, double BOMQty, double IssuedQty, string GenBy, int CompId, string TaskTargetTryOut_FDate, string TaskTargetTryOut_TDate, string TaskTargetDespach_FDate, string TaskTargetDespach_TDate, string TaskProjectTitle, string TaskProjectLeader, string SysDate, string WONo, double StockQty, double Rate)
		{
			DataTable2Row dataTable2Row = (DataTable2Row)NewRow();
			object[] itemArray = new object[18]
			{
				ItemCode, ManfDesc, UOMBasic, WISNo, BOMQty, IssuedQty, GenBy, CompId, TaskTargetTryOut_FDate, TaskTargetTryOut_TDate,
				TaskTargetDespach_FDate, TaskTargetDespach_TDate, TaskProjectTitle, TaskProjectLeader, SysDate, WONo, StockQty, Rate
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
			columnItemCode = base.Columns["ItemCode"];
			columnManfDesc = base.Columns["ManfDesc"];
			columnUOMBasic = base.Columns["UOMBasic"];
			columnWISNo = base.Columns["WISNo"];
			columnBOMQty = base.Columns["BOMQty"];
			columnIssuedQty = base.Columns["IssuedQty"];
			columnGenBy = base.Columns["GenBy"];
			columnCompId = base.Columns["CompId"];
			columnTaskTargetTryOut_FDate = base.Columns["TaskTargetTryOut_FDate"];
			columnTaskTargetTryOut_TDate = base.Columns["TaskTargetTryOut_TDate"];
			columnTaskTargetDespach_FDate = base.Columns["TaskTargetDespach_FDate"];
			columnTaskTargetDespach_TDate = base.Columns["TaskTargetDespach_TDate"];
			columnTaskProjectTitle = base.Columns["TaskProjectTitle"];
			columnTaskProjectLeader = base.Columns["TaskProjectLeader"];
			columnSysDate = base.Columns["SysDate"];
			columnWONo = base.Columns["WONo"];
			columnStockQty = base.Columns["StockQty"];
			columnRate = base.Columns["Rate"];
		}

		[DebuggerNonUserCode]
		private void InitClass()
		{
			columnItemCode = new DataColumn("ItemCode", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnItemCode);
			columnManfDesc = new DataColumn("ManfDesc", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnManfDesc);
			columnUOMBasic = new DataColumn("UOMBasic", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnUOMBasic);
			columnWISNo = new DataColumn("WISNo", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnWISNo);
			columnBOMQty = new DataColumn("BOMQty", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnBOMQty);
			columnIssuedQty = new DataColumn("IssuedQty", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnIssuedQty);
			columnGenBy = new DataColumn("GenBy", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnGenBy);
			columnCompId = new DataColumn("CompId", typeof(int), null, MappingType.Element);
			base.Columns.Add(columnCompId);
			columnTaskTargetTryOut_FDate = new DataColumn("TaskTargetTryOut_FDate", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnTaskTargetTryOut_FDate);
			columnTaskTargetTryOut_TDate = new DataColumn("TaskTargetTryOut_TDate", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnTaskTargetTryOut_TDate);
			columnTaskTargetDespach_FDate = new DataColumn("TaskTargetDespach_FDate", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnTaskTargetDespach_FDate);
			columnTaskTargetDespach_TDate = new DataColumn("TaskTargetDespach_TDate", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnTaskTargetDespach_TDate);
			columnTaskProjectTitle = new DataColumn("TaskProjectTitle", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnTaskProjectTitle);
			columnTaskProjectLeader = new DataColumn("TaskProjectLeader", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnTaskProjectLeader);
			columnSysDate = new DataColumn("SysDate", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnSysDate);
			columnWONo = new DataColumn("WONo", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnWONo);
			columnStockQty = new DataColumn("StockQty", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnStockQty);
			columnRate = new DataColumn("Rate", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnRate);
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
			WISIssueQty wISIssueQty = new WISIssueQty();
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
			xmlSchemaAttribute.FixedValue = wISIssueQty.Namespace;
			xmlSchemaComplexType.Attributes.Add(xmlSchemaAttribute);
			XmlSchemaAttribute xmlSchemaAttribute2 = new XmlSchemaAttribute();
			xmlSchemaAttribute2.Name = "tableTypeName";
			xmlSchemaAttribute2.FixedValue = "DataTable2DataTable";
			xmlSchemaComplexType.Attributes.Add(xmlSchemaAttribute2);
			xmlSchemaComplexType.Particle = xmlSchemaSequence;
			XmlSchema schemaSerializable = wISIssueQty.GetSchemaSerializable();
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
	public class DataTable2Row : DataRow
	{
		private DataTable2DataTable tableDataTable2;

		[DebuggerNonUserCode]
		public string ItemCode
		{
			get
			{
				try
				{
					return (string)base[tableDataTable2.ItemCodeColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'ItemCode' in table 'DataTable2' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable2.ItemCodeColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string ManfDesc
		{
			get
			{
				try
				{
					return (string)base[tableDataTable2.ManfDescColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'ManfDesc' in table 'DataTable2' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable2.ManfDescColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string UOMBasic
		{
			get
			{
				try
				{
					return (string)base[tableDataTable2.UOMBasicColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'UOMBasic' in table 'DataTable2' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable2.UOMBasicColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string WISNo
		{
			get
			{
				try
				{
					return (string)base[tableDataTable2.WISNoColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'WISNo' in table 'DataTable2' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable2.WISNoColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public double BOMQty
		{
			get
			{
				try
				{
					return (double)base[tableDataTable2.BOMQtyColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'BOMQty' in table 'DataTable2' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable2.BOMQtyColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public double IssuedQty
		{
			get
			{
				try
				{
					return (double)base[tableDataTable2.IssuedQtyColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'IssuedQty' in table 'DataTable2' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable2.IssuedQtyColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string GenBy
		{
			get
			{
				try
				{
					return (string)base[tableDataTable2.GenByColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'GenBy' in table 'DataTable2' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable2.GenByColumn] = value;
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
		public string TaskTargetTryOut_FDate
		{
			get
			{
				try
				{
					return (string)base[tableDataTable2.TaskTargetTryOut_FDateColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'TaskTargetTryOut_FDate' in table 'DataTable2' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable2.TaskTargetTryOut_FDateColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string TaskTargetTryOut_TDate
		{
			get
			{
				try
				{
					return (string)base[tableDataTable2.TaskTargetTryOut_TDateColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'TaskTargetTryOut_TDate' in table 'DataTable2' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable2.TaskTargetTryOut_TDateColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string TaskTargetDespach_FDate
		{
			get
			{
				try
				{
					return (string)base[tableDataTable2.TaskTargetDespach_FDateColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'TaskTargetDespach_FDate' in table 'DataTable2' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable2.TaskTargetDespach_FDateColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string TaskTargetDespach_TDate
		{
			get
			{
				try
				{
					return (string)base[tableDataTable2.TaskTargetDespach_TDateColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'TaskTargetDespach_TDate' in table 'DataTable2' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable2.TaskTargetDespach_TDateColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string TaskProjectTitle
		{
			get
			{
				try
				{
					return (string)base[tableDataTable2.TaskProjectTitleColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'TaskProjectTitle' in table 'DataTable2' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable2.TaskProjectTitleColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string TaskProjectLeader
		{
			get
			{
				try
				{
					return (string)base[tableDataTable2.TaskProjectLeaderColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'TaskProjectLeader' in table 'DataTable2' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable2.TaskProjectLeaderColumn] = value;
			}
		}

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
		public double StockQty
		{
			get
			{
				try
				{
					return (double)base[tableDataTable2.StockQtyColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'StockQty' in table 'DataTable2' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable2.StockQtyColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public double Rate
		{
			get
			{
				try
				{
					return (double)base[tableDataTable2.RateColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Rate' in table 'DataTable2' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable2.RateColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		internal DataTable2Row(DataRowBuilder rb)
			: base(rb)
		{
			tableDataTable2 = (DataTable2DataTable)base.Table;
		}

		[DebuggerNonUserCode]
		public bool IsItemCodeNull()
		{
			return IsNull(tableDataTable2.ItemCodeColumn);
		}

		[DebuggerNonUserCode]
		public void SetItemCodeNull()
		{
			base[tableDataTable2.ItemCodeColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsManfDescNull()
		{
			return IsNull(tableDataTable2.ManfDescColumn);
		}

		[DebuggerNonUserCode]
		public void SetManfDescNull()
		{
			base[tableDataTable2.ManfDescColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsUOMBasicNull()
		{
			return IsNull(tableDataTable2.UOMBasicColumn);
		}

		[DebuggerNonUserCode]
		public void SetUOMBasicNull()
		{
			base[tableDataTable2.UOMBasicColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsWISNoNull()
		{
			return IsNull(tableDataTable2.WISNoColumn);
		}

		[DebuggerNonUserCode]
		public void SetWISNoNull()
		{
			base[tableDataTable2.WISNoColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsBOMQtyNull()
		{
			return IsNull(tableDataTable2.BOMQtyColumn);
		}

		[DebuggerNonUserCode]
		public void SetBOMQtyNull()
		{
			base[tableDataTable2.BOMQtyColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsIssuedQtyNull()
		{
			return IsNull(tableDataTable2.IssuedQtyColumn);
		}

		[DebuggerNonUserCode]
		public void SetIssuedQtyNull()
		{
			base[tableDataTable2.IssuedQtyColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsGenByNull()
		{
			return IsNull(tableDataTable2.GenByColumn);
		}

		[DebuggerNonUserCode]
		public void SetGenByNull()
		{
			base[tableDataTable2.GenByColumn] = Convert.DBNull;
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
		public bool IsTaskTargetTryOut_FDateNull()
		{
			return IsNull(tableDataTable2.TaskTargetTryOut_FDateColumn);
		}

		[DebuggerNonUserCode]
		public void SetTaskTargetTryOut_FDateNull()
		{
			base[tableDataTable2.TaskTargetTryOut_FDateColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsTaskTargetTryOut_TDateNull()
		{
			return IsNull(tableDataTable2.TaskTargetTryOut_TDateColumn);
		}

		[DebuggerNonUserCode]
		public void SetTaskTargetTryOut_TDateNull()
		{
			base[tableDataTable2.TaskTargetTryOut_TDateColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsTaskTargetDespach_FDateNull()
		{
			return IsNull(tableDataTable2.TaskTargetDespach_FDateColumn);
		}

		[DebuggerNonUserCode]
		public void SetTaskTargetDespach_FDateNull()
		{
			base[tableDataTable2.TaskTargetDespach_FDateColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsTaskTargetDespach_TDateNull()
		{
			return IsNull(tableDataTable2.TaskTargetDespach_TDateColumn);
		}

		[DebuggerNonUserCode]
		public void SetTaskTargetDespach_TDateNull()
		{
			base[tableDataTable2.TaskTargetDespach_TDateColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsTaskProjectTitleNull()
		{
			return IsNull(tableDataTable2.TaskProjectTitleColumn);
		}

		[DebuggerNonUserCode]
		public void SetTaskProjectTitleNull()
		{
			base[tableDataTable2.TaskProjectTitleColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsTaskProjectLeaderNull()
		{
			return IsNull(tableDataTable2.TaskProjectLeaderColumn);
		}

		[DebuggerNonUserCode]
		public void SetTaskProjectLeaderNull()
		{
			base[tableDataTable2.TaskProjectLeaderColumn] = Convert.DBNull;
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
		public bool IsStockQtyNull()
		{
			return IsNull(tableDataTable2.StockQtyColumn);
		}

		[DebuggerNonUserCode]
		public void SetStockQtyNull()
		{
			base[tableDataTable2.StockQtyColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsRateNull()
		{
			return IsNull(tableDataTable2.RateColumn);
		}

		[DebuggerNonUserCode]
		public void SetRateNull()
		{
			base[tableDataTable2.RateColumn] = Convert.DBNull;
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

	private DataTable2DataTable tableDataTable2;

	private SchemaSerializationMode _schemaSerializationMode = SchemaSerializationMode.IncludeSchema;

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	[DebuggerNonUserCode]
	public DataTable2DataTable DataTable2 => tableDataTable2;

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
	public WISIssueQty()
	{
		BeginInit();
		InitClass();
		CollectionChangeEventHandler value = SchemaChanged;
		base.Tables.CollectionChanged += value;
		base.Relations.CollectionChanged += value;
		EndInit();
	}

	[DebuggerNonUserCode]
	protected WISIssueQty(SerializationInfo info, StreamingContext context)
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
		WISIssueQty wISIssueQty = (WISIssueQty)base.Clone();
		wISIssueQty.InitVars();
		wISIssueQty.SchemaSerializationMode = SchemaSerializationMode;
		return wISIssueQty;
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
		tableDataTable2 = (DataTable2DataTable)base.Tables["DataTable2"];
		if (initTable && tableDataTable2 != null)
		{
			tableDataTable2.InitVars();
		}
	}

	[DebuggerNonUserCode]
	private void InitClass()
	{
		base.DataSetName = "WISIssueQty";
		base.Prefix = "";
		base.Namespace = "http://tempuri.org/WISIssueQty.xsd";
		base.EnforceConstraints = true;
		SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
		tableDataTable2 = new DataTable2DataTable();
		base.Tables.Add(tableDataTable2);
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
		WISIssueQty wISIssueQty = new WISIssueQty();
		XmlSchemaComplexType xmlSchemaComplexType = new XmlSchemaComplexType();
		XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
		XmlSchemaAny xmlSchemaAny = new XmlSchemaAny();
		xmlSchemaAny.Namespace = wISIssueQty.Namespace;
		xmlSchemaSequence.Items.Add(xmlSchemaAny);
		xmlSchemaComplexType.Particle = xmlSchemaSequence;
		XmlSchema schemaSerializable = wISIssueQty.GetSchemaSerializable();
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
