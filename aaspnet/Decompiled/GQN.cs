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
[ToolboxItem(true)]
[XmlSchemaProvider("GetTypedDataSetSchema")]
[XmlRoot("GQN")]
[DesignerCategory("code")]
[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
[HelpKeyword("vs.data.DataSet")]
public class GQN : DataSet
{
	public delegate void DataTable1RowChangeEventHandler(object sender, DataTable1RowChangeEvent e);

	[Serializable]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
	[XmlSchemaProvider("GetTypedTableSchema")]
	public class DataTable1DataTable : TypedTableBase<DataTable1Row>
	{
		private DataColumn columnId;

		private DataColumn columnItemCode;

		private DataColumn columnDescription;

		private DataColumn columnUOM;

		private DataColumn columnPOQty;

		private DataColumn columnInvQty;

		private DataColumn columnRecedQty;

		private DataColumn columnAcceptedQty;

		private DataColumn columnRejReason;

		private DataColumn columnRemarks;

		private DataColumn columnCompId;

		private DataColumn columnGQNDate;

		private DataColumn columnGRRDate;

		private DataColumn columnGINDate;

		private DataColumn columnPODate;

		private DataColumn columnPONo;

		private DataColumn columnModVatApp;

		private DataColumn columnModVatInv;

		private DataColumn columnInspectedBy;

		private DataColumn columnSN;

		private DataColumn columnPN;

		[DebuggerNonUserCode]
		public DataColumn IdColumn => columnId;

		[DebuggerNonUserCode]
		public DataColumn ItemCodeColumn => columnItemCode;

		[DebuggerNonUserCode]
		public DataColumn DescriptionColumn => columnDescription;

		[DebuggerNonUserCode]
		public DataColumn UOMColumn => columnUOM;

		[DebuggerNonUserCode]
		public DataColumn POQtyColumn => columnPOQty;

		[DebuggerNonUserCode]
		public DataColumn InvQtyColumn => columnInvQty;

		[DebuggerNonUserCode]
		public DataColumn RecedQtyColumn => columnRecedQty;

		[DebuggerNonUserCode]
		public DataColumn AcceptedQtyColumn => columnAcceptedQty;

		[DebuggerNonUserCode]
		public DataColumn RejReasonColumn => columnRejReason;

		[DebuggerNonUserCode]
		public DataColumn RemarksColumn => columnRemarks;

		[DebuggerNonUserCode]
		public DataColumn CompIdColumn => columnCompId;

		[DebuggerNonUserCode]
		public DataColumn GQNDateColumn => columnGQNDate;

		[DebuggerNonUserCode]
		public DataColumn GRRDateColumn => columnGRRDate;

		[DebuggerNonUserCode]
		public DataColumn GINDateColumn => columnGINDate;

		[DebuggerNonUserCode]
		public DataColumn PODateColumn => columnPODate;

		[DebuggerNonUserCode]
		public DataColumn PONoColumn => columnPONo;

		[DebuggerNonUserCode]
		public DataColumn ModVatAppColumn => columnModVatApp;

		[DebuggerNonUserCode]
		public DataColumn ModVatInvColumn => columnModVatInv;

		[DebuggerNonUserCode]
		public DataColumn InspectedByColumn => columnInspectedBy;

		[DebuggerNonUserCode]
		public DataColumn SNColumn => columnSN;

		[DebuggerNonUserCode]
		public DataColumn PNColumn => columnPN;

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
		public DataTable1Row AddDataTable1Row(int Id, string ItemCode, string Description, string UOM, double POQty, double InvQty, double RecedQty, double AcceptedQty, string RejReason, string Remarks, int CompId, string GQNDate, string GRRDate, string GINDate, string PODate, string PONo, string ModVatApp, string ModVatInv, string InspectedBy, string SN, string PN)
		{
			DataTable1Row dataTable1Row = (DataTable1Row)NewRow();
			object[] itemArray = new object[21]
			{
				Id, ItemCode, Description, UOM, POQty, InvQty, RecedQty, AcceptedQty, RejReason, Remarks,
				CompId, GQNDate, GRRDate, GINDate, PODate, PONo, ModVatApp, ModVatInv, InspectedBy, SN,
				PN
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
			columnItemCode = base.Columns["ItemCode"];
			columnDescription = base.Columns["Description"];
			columnUOM = base.Columns["UOM"];
			columnPOQty = base.Columns["POQty"];
			columnInvQty = base.Columns["InvQty"];
			columnRecedQty = base.Columns["RecedQty"];
			columnAcceptedQty = base.Columns["AcceptedQty"];
			columnRejReason = base.Columns["RejReason"];
			columnRemarks = base.Columns["Remarks"];
			columnCompId = base.Columns["CompId"];
			columnGQNDate = base.Columns["GQNDate"];
			columnGRRDate = base.Columns["GRRDate"];
			columnGINDate = base.Columns["GINDate"];
			columnPODate = base.Columns["PODate"];
			columnPONo = base.Columns["PONo"];
			columnModVatApp = base.Columns["ModVatApp"];
			columnModVatInv = base.Columns["ModVatInv"];
			columnInspectedBy = base.Columns["InspectedBy"];
			columnSN = base.Columns["SN"];
			columnPN = base.Columns["PN"];
		}

		[DebuggerNonUserCode]
		private void InitClass()
		{
			columnId = new DataColumn("Id", typeof(int), null, MappingType.Element);
			base.Columns.Add(columnId);
			columnItemCode = new DataColumn("ItemCode", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnItemCode);
			columnDescription = new DataColumn("Description", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnDescription);
			columnUOM = new DataColumn("UOM", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnUOM);
			columnPOQty = new DataColumn("POQty", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnPOQty);
			columnInvQty = new DataColumn("InvQty", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnInvQty);
			columnRecedQty = new DataColumn("RecedQty", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnRecedQty);
			columnAcceptedQty = new DataColumn("AcceptedQty", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnAcceptedQty);
			columnRejReason = new DataColumn("RejReason", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnRejReason);
			columnRemarks = new DataColumn("Remarks", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnRemarks);
			columnCompId = new DataColumn("CompId", typeof(int), null, MappingType.Element);
			base.Columns.Add(columnCompId);
			columnGQNDate = new DataColumn("GQNDate", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnGQNDate);
			columnGRRDate = new DataColumn("GRRDate", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnGRRDate);
			columnGINDate = new DataColumn("GINDate", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnGINDate);
			columnPODate = new DataColumn("PODate", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnPODate);
			columnPONo = new DataColumn("PONo", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnPONo);
			columnModVatApp = new DataColumn("ModVatApp", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnModVatApp);
			columnModVatInv = new DataColumn("ModVatInv", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnModVatInv);
			columnInspectedBy = new DataColumn("InspectedBy", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnInspectedBy);
			columnSN = new DataColumn("SN", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnSN);
			columnPN = new DataColumn("PN", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnPN);
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
			GQN gQN = new GQN();
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
			xmlSchemaAttribute.FixedValue = gQN.Namespace;
			xmlSchemaComplexType.Attributes.Add(xmlSchemaAttribute);
			XmlSchemaAttribute xmlSchemaAttribute2 = new XmlSchemaAttribute();
			xmlSchemaAttribute2.Name = "tableTypeName";
			xmlSchemaAttribute2.FixedValue = "DataTable1DataTable";
			xmlSchemaComplexType.Attributes.Add(xmlSchemaAttribute2);
			xmlSchemaComplexType.Particle = xmlSchemaSequence;
			XmlSchema schemaSerializable = gQN.GetSchemaSerializable();
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
		public double POQty
		{
			get
			{
				try
				{
					return (double)base[tableDataTable1.POQtyColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'POQty' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.POQtyColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public double InvQty
		{
			get
			{
				try
				{
					return (double)base[tableDataTable1.InvQtyColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'InvQty' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.InvQtyColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public double RecedQty
		{
			get
			{
				try
				{
					return (double)base[tableDataTable1.RecedQtyColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'RecedQty' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.RecedQtyColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public double AcceptedQty
		{
			get
			{
				try
				{
					return (double)base[tableDataTable1.AcceptedQtyColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'AcceptedQty' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.AcceptedQtyColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string RejReason
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.RejReasonColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'RejReason' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.RejReasonColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string Remarks
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.RemarksColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Remarks' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.RemarksColumn] = value;
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
		public string GQNDate
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.GQNDateColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'GQNDate' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.GQNDateColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string GRRDate
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.GRRDateColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'GRRDate' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.GRRDateColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string GINDate
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.GINDateColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'GINDate' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.GINDateColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string PODate
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.PODateColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'PODate' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.PODateColumn] = value;
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
		public string ModVatApp
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.ModVatAppColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'ModVatApp' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.ModVatAppColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string ModVatInv
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.ModVatInvColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'ModVatInv' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.ModVatInvColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string InspectedBy
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.InspectedByColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'InspectedBy' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.InspectedByColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string SN
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.SNColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'SN' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.SNColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string PN
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.PNColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'PN' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.PNColumn] = value;
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
		public bool IsPOQtyNull()
		{
			return IsNull(tableDataTable1.POQtyColumn);
		}

		[DebuggerNonUserCode]
		public void SetPOQtyNull()
		{
			base[tableDataTable1.POQtyColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsInvQtyNull()
		{
			return IsNull(tableDataTable1.InvQtyColumn);
		}

		[DebuggerNonUserCode]
		public void SetInvQtyNull()
		{
			base[tableDataTable1.InvQtyColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsRecedQtyNull()
		{
			return IsNull(tableDataTable1.RecedQtyColumn);
		}

		[DebuggerNonUserCode]
		public void SetRecedQtyNull()
		{
			base[tableDataTable1.RecedQtyColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsAcceptedQtyNull()
		{
			return IsNull(tableDataTable1.AcceptedQtyColumn);
		}

		[DebuggerNonUserCode]
		public void SetAcceptedQtyNull()
		{
			base[tableDataTable1.AcceptedQtyColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsRejReasonNull()
		{
			return IsNull(tableDataTable1.RejReasonColumn);
		}

		[DebuggerNonUserCode]
		public void SetRejReasonNull()
		{
			base[tableDataTable1.RejReasonColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsRemarksNull()
		{
			return IsNull(tableDataTable1.RemarksColumn);
		}

		[DebuggerNonUserCode]
		public void SetRemarksNull()
		{
			base[tableDataTable1.RemarksColumn] = Convert.DBNull;
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
		public bool IsGQNDateNull()
		{
			return IsNull(tableDataTable1.GQNDateColumn);
		}

		[DebuggerNonUserCode]
		public void SetGQNDateNull()
		{
			base[tableDataTable1.GQNDateColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsGRRDateNull()
		{
			return IsNull(tableDataTable1.GRRDateColumn);
		}

		[DebuggerNonUserCode]
		public void SetGRRDateNull()
		{
			base[tableDataTable1.GRRDateColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsGINDateNull()
		{
			return IsNull(tableDataTable1.GINDateColumn);
		}

		[DebuggerNonUserCode]
		public void SetGINDateNull()
		{
			base[tableDataTable1.GINDateColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsPODateNull()
		{
			return IsNull(tableDataTable1.PODateColumn);
		}

		[DebuggerNonUserCode]
		public void SetPODateNull()
		{
			base[tableDataTable1.PODateColumn] = Convert.DBNull;
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
		public bool IsModVatAppNull()
		{
			return IsNull(tableDataTable1.ModVatAppColumn);
		}

		[DebuggerNonUserCode]
		public void SetModVatAppNull()
		{
			base[tableDataTable1.ModVatAppColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsModVatInvNull()
		{
			return IsNull(tableDataTable1.ModVatInvColumn);
		}

		[DebuggerNonUserCode]
		public void SetModVatInvNull()
		{
			base[tableDataTable1.ModVatInvColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsInspectedByNull()
		{
			return IsNull(tableDataTable1.InspectedByColumn);
		}

		[DebuggerNonUserCode]
		public void SetInspectedByNull()
		{
			base[tableDataTable1.InspectedByColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsSNNull()
		{
			return IsNull(tableDataTable1.SNColumn);
		}

		[DebuggerNonUserCode]
		public void SetSNNull()
		{
			base[tableDataTable1.SNColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsPNNull()
		{
			return IsNull(tableDataTable1.PNColumn);
		}

		[DebuggerNonUserCode]
		public void SetPNNull()
		{
			base[tableDataTable1.PNColumn] = Convert.DBNull;
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

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	[DebuggerNonUserCode]
	public DataTable1DataTable DataTable1 => tableDataTable1;

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
	public GQN()
	{
		BeginInit();
		InitClass();
		CollectionChangeEventHandler value = SchemaChanged;
		base.Tables.CollectionChanged += value;
		base.Relations.CollectionChanged += value;
		EndInit();
	}

	[DebuggerNonUserCode]
	protected GQN(SerializationInfo info, StreamingContext context)
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
		GQN gQN = (GQN)base.Clone();
		gQN.InitVars();
		gQN.SchemaSerializationMode = SchemaSerializationMode;
		return gQN;
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
		base.DataSetName = "GQN";
		base.Prefix = "";
		base.Namespace = "http://tempuri.org/GQN.xsd";
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
		GQN gQN = new GQN();
		XmlSchemaComplexType xmlSchemaComplexType = new XmlSchemaComplexType();
		XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
		XmlSchemaAny xmlSchemaAny = new XmlSchemaAny();
		xmlSchemaAny.Namespace = gQN.Namespace;
		xmlSchemaSequence.Items.Add(xmlSchemaAny);
		xmlSchemaComplexType.Particle = xmlSchemaSequence;
		XmlSchema schemaSerializable = gQN.GetSchemaSerializable();
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
