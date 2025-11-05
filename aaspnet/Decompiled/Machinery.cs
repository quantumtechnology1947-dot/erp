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
[XmlRoot("Machinery")]
[HelpKeyword("vs.data.DataSet")]
[ToolboxItem(true)]
[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
[DesignerCategory("code")]
public class Machinery : DataSet
{
	public delegate void DataTable1RowChangeEventHandler(object sender, DataTable1RowChangeEvent e);

	[Serializable]
	[XmlSchemaProvider("GetTypedTableSchema")]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
	public class DataTable1DataTable : TypedTableBase<DataTable1Row>
	{
		private DataColumn columnId;

		private DataColumn columnSysDate;

		private DataColumn columnCompId;

		private DataColumn columnItemCode;

		private DataColumn columnUOM;

		private DataColumn columnName;

		private DataColumn columnMake;

		private DataColumn columnModel;

		private DataColumn columnCapacity;

		private DataColumn columnPurchaseDate;

		private DataColumn columnSupplierName;

		private DataColumn columnCost;

		private DataColumn columnWarrantyExpiryDate;

		private DataColumn columnLifeDate;

		private DataColumn columnReceivedDate;

		private DataColumn columnInsurance;

		private DataColumn columnInsuranceExpiryDate;

		private DataColumn columnPuttouse;

		private DataColumn columnIncharge;

		private DataColumn columnLocation;

		private DataColumn columnPMDays;

		[DebuggerNonUserCode]
		public DataColumn IdColumn => columnId;

		[DebuggerNonUserCode]
		public DataColumn SysDateColumn => columnSysDate;

		[DebuggerNonUserCode]
		public DataColumn CompIdColumn => columnCompId;

		[DebuggerNonUserCode]
		public DataColumn ItemCodeColumn => columnItemCode;

		[DebuggerNonUserCode]
		public DataColumn UOMColumn => columnUOM;

		[DebuggerNonUserCode]
		public DataColumn NameColumn => columnName;

		[DebuggerNonUserCode]
		public DataColumn MakeColumn => columnMake;

		[DebuggerNonUserCode]
		public DataColumn ModelColumn => columnModel;

		[DebuggerNonUserCode]
		public DataColumn CapacityColumn => columnCapacity;

		[DebuggerNonUserCode]
		public DataColumn PurchaseDateColumn => columnPurchaseDate;

		[DebuggerNonUserCode]
		public DataColumn SupplierNameColumn => columnSupplierName;

		[DebuggerNonUserCode]
		public DataColumn CostColumn => columnCost;

		[DebuggerNonUserCode]
		public DataColumn WarrantyExpiryDateColumn => columnWarrantyExpiryDate;

		[DebuggerNonUserCode]
		public DataColumn LifeDateColumn => columnLifeDate;

		[DebuggerNonUserCode]
		public DataColumn ReceivedDateColumn => columnReceivedDate;

		[DebuggerNonUserCode]
		public DataColumn InsuranceColumn => columnInsurance;

		[DebuggerNonUserCode]
		public DataColumn InsuranceExpiryDateColumn => columnInsuranceExpiryDate;

		[DebuggerNonUserCode]
		public DataColumn PuttouseColumn => columnPuttouse;

		[DebuggerNonUserCode]
		public DataColumn InchargeColumn => columnIncharge;

		[DebuggerNonUserCode]
		public DataColumn LocationColumn => columnLocation;

		[DebuggerNonUserCode]
		public DataColumn PMDaysColumn => columnPMDays;

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
		public DataTable1Row AddDataTable1Row(int Id, string SysDate, int CompId, string ItemCode, string UOM, string Name, string Make, string Model, string Capacity, string PurchaseDate, string SupplierName, double Cost, string WarrantyExpiryDate, string LifeDate, string ReceivedDate, string Insurance, string InsuranceExpiryDate, string Puttouse, string Incharge, string Location, string PMDays)
		{
			DataTable1Row dataTable1Row = (DataTable1Row)NewRow();
			object[] itemArray = new object[21]
			{
				Id, SysDate, CompId, ItemCode, UOM, Name, Make, Model, Capacity, PurchaseDate,
				SupplierName, Cost, WarrantyExpiryDate, LifeDate, ReceivedDate, Insurance, InsuranceExpiryDate, Puttouse, Incharge, Location,
				PMDays
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
			columnItemCode = base.Columns["ItemCode"];
			columnUOM = base.Columns["UOM"];
			columnName = base.Columns["Name"];
			columnMake = base.Columns["Make"];
			columnModel = base.Columns["Model"];
			columnCapacity = base.Columns["Capacity"];
			columnPurchaseDate = base.Columns["PurchaseDate"];
			columnSupplierName = base.Columns["SupplierName"];
			columnCost = base.Columns["Cost"];
			columnWarrantyExpiryDate = base.Columns["WarrantyExpiryDate"];
			columnLifeDate = base.Columns["LifeDate"];
			columnReceivedDate = base.Columns["ReceivedDate"];
			columnInsurance = base.Columns["Insurance"];
			columnInsuranceExpiryDate = base.Columns["InsuranceExpiryDate"];
			columnPuttouse = base.Columns["Puttouse"];
			columnIncharge = base.Columns["Incharge"];
			columnLocation = base.Columns["Location"];
			columnPMDays = base.Columns["PMDays"];
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
			columnItemCode = new DataColumn("ItemCode", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnItemCode);
			columnUOM = new DataColumn("UOM", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnUOM);
			columnName = new DataColumn("Name", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnName);
			columnMake = new DataColumn("Make", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnMake);
			columnModel = new DataColumn("Model", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnModel);
			columnCapacity = new DataColumn("Capacity", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnCapacity);
			columnPurchaseDate = new DataColumn("PurchaseDate", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnPurchaseDate);
			columnSupplierName = new DataColumn("SupplierName", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnSupplierName);
			columnCost = new DataColumn("Cost", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnCost);
			columnWarrantyExpiryDate = new DataColumn("WarrantyExpiryDate", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnWarrantyExpiryDate);
			columnLifeDate = new DataColumn("LifeDate", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnLifeDate);
			columnReceivedDate = new DataColumn("ReceivedDate", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnReceivedDate);
			columnInsurance = new DataColumn("Insurance", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnInsurance);
			columnInsuranceExpiryDate = new DataColumn("InsuranceExpiryDate", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnInsuranceExpiryDate);
			columnPuttouse = new DataColumn("Puttouse", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnPuttouse);
			columnIncharge = new DataColumn("Incharge", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnIncharge);
			columnLocation = new DataColumn("Location", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnLocation);
			columnPMDays = new DataColumn("PMDays", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnPMDays);
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
			Machinery machinery = new Machinery();
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
			xmlSchemaAttribute.FixedValue = machinery.Namespace;
			xmlSchemaComplexType.Attributes.Add(xmlSchemaAttribute);
			XmlSchemaAttribute xmlSchemaAttribute2 = new XmlSchemaAttribute();
			xmlSchemaAttribute2.Name = "tableTypeName";
			xmlSchemaAttribute2.FixedValue = "DataTable1DataTable";
			xmlSchemaComplexType.Attributes.Add(xmlSchemaAttribute2);
			xmlSchemaComplexType.Particle = xmlSchemaSequence;
			XmlSchema schemaSerializable = machinery.GetSchemaSerializable();
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
		public string Name
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.NameColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Name' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.NameColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string Make
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.MakeColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Make' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.MakeColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string Model
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.ModelColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Model' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.ModelColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string Capacity
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.CapacityColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Capacity' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.CapacityColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string PurchaseDate
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.PurchaseDateColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'PurchaseDate' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.PurchaseDateColumn] = value;
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
		public double Cost
		{
			get
			{
				try
				{
					return (double)base[tableDataTable1.CostColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Cost' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.CostColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string WarrantyExpiryDate
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.WarrantyExpiryDateColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'WarrantyExpiryDate' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.WarrantyExpiryDateColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string LifeDate
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.LifeDateColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'LifeDate' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.LifeDateColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string ReceivedDate
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.ReceivedDateColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'ReceivedDate' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.ReceivedDateColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string Insurance
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.InsuranceColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Insurance' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.InsuranceColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string InsuranceExpiryDate
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.InsuranceExpiryDateColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'InsuranceExpiryDate' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.InsuranceExpiryDateColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string Puttouse
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.PuttouseColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Puttouse' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.PuttouseColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string Incharge
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.InchargeColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Incharge' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.InchargeColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string Location
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.LocationColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Location' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.LocationColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string PMDays
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.PMDaysColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'PMDays' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.PMDaysColumn] = value;
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
		public bool IsNameNull()
		{
			return IsNull(tableDataTable1.NameColumn);
		}

		[DebuggerNonUserCode]
		public void SetNameNull()
		{
			base[tableDataTable1.NameColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsMakeNull()
		{
			return IsNull(tableDataTable1.MakeColumn);
		}

		[DebuggerNonUserCode]
		public void SetMakeNull()
		{
			base[tableDataTable1.MakeColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsModelNull()
		{
			return IsNull(tableDataTable1.ModelColumn);
		}

		[DebuggerNonUserCode]
		public void SetModelNull()
		{
			base[tableDataTable1.ModelColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsCapacityNull()
		{
			return IsNull(tableDataTable1.CapacityColumn);
		}

		[DebuggerNonUserCode]
		public void SetCapacityNull()
		{
			base[tableDataTable1.CapacityColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsPurchaseDateNull()
		{
			return IsNull(tableDataTable1.PurchaseDateColumn);
		}

		[DebuggerNonUserCode]
		public void SetPurchaseDateNull()
		{
			base[tableDataTable1.PurchaseDateColumn] = Convert.DBNull;
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
		public bool IsCostNull()
		{
			return IsNull(tableDataTable1.CostColumn);
		}

		[DebuggerNonUserCode]
		public void SetCostNull()
		{
			base[tableDataTable1.CostColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsWarrantyExpiryDateNull()
		{
			return IsNull(tableDataTable1.WarrantyExpiryDateColumn);
		}

		[DebuggerNonUserCode]
		public void SetWarrantyExpiryDateNull()
		{
			base[tableDataTable1.WarrantyExpiryDateColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsLifeDateNull()
		{
			return IsNull(tableDataTable1.LifeDateColumn);
		}

		[DebuggerNonUserCode]
		public void SetLifeDateNull()
		{
			base[tableDataTable1.LifeDateColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsReceivedDateNull()
		{
			return IsNull(tableDataTable1.ReceivedDateColumn);
		}

		[DebuggerNonUserCode]
		public void SetReceivedDateNull()
		{
			base[tableDataTable1.ReceivedDateColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsInsuranceNull()
		{
			return IsNull(tableDataTable1.InsuranceColumn);
		}

		[DebuggerNonUserCode]
		public void SetInsuranceNull()
		{
			base[tableDataTable1.InsuranceColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsInsuranceExpiryDateNull()
		{
			return IsNull(tableDataTable1.InsuranceExpiryDateColumn);
		}

		[DebuggerNonUserCode]
		public void SetInsuranceExpiryDateNull()
		{
			base[tableDataTable1.InsuranceExpiryDateColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsPuttouseNull()
		{
			return IsNull(tableDataTable1.PuttouseColumn);
		}

		[DebuggerNonUserCode]
		public void SetPuttouseNull()
		{
			base[tableDataTable1.PuttouseColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsInchargeNull()
		{
			return IsNull(tableDataTable1.InchargeColumn);
		}

		[DebuggerNonUserCode]
		public void SetInchargeNull()
		{
			base[tableDataTable1.InchargeColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsLocationNull()
		{
			return IsNull(tableDataTable1.LocationColumn);
		}

		[DebuggerNonUserCode]
		public void SetLocationNull()
		{
			base[tableDataTable1.LocationColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsPMDaysNull()
		{
			return IsNull(tableDataTable1.PMDaysColumn);
		}

		[DebuggerNonUserCode]
		public void SetPMDaysNull()
		{
			base[tableDataTable1.PMDaysColumn] = Convert.DBNull;
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

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[DebuggerNonUserCode]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataRelationCollection Relations => base.Relations;

	[DebuggerNonUserCode]
	public Machinery()
	{
		BeginInit();
		InitClass();
		CollectionChangeEventHandler value = SchemaChanged;
		base.Tables.CollectionChanged += value;
		base.Relations.CollectionChanged += value;
		EndInit();
	}

	[DebuggerNonUserCode]
	protected Machinery(SerializationInfo info, StreamingContext context)
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
		Machinery machinery = (Machinery)base.Clone();
		machinery.InitVars();
		machinery.SchemaSerializationMode = SchemaSerializationMode;
		return machinery;
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
		base.DataSetName = "Machinery";
		base.Prefix = "";
		base.Namespace = "http://tempuri.org/Machinery.xsd";
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
		Machinery machinery = new Machinery();
		XmlSchemaComplexType xmlSchemaComplexType = new XmlSchemaComplexType();
		XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
		XmlSchemaAny xmlSchemaAny = new XmlSchemaAny();
		xmlSchemaAny.Namespace = machinery.Namespace;
		xmlSchemaSequence.Items.Add(xmlSchemaAny);
		xmlSchemaComplexType.Particle = xmlSchemaSequence;
		XmlSchema schemaSerializable = machinery.GetSchemaSerializable();
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
