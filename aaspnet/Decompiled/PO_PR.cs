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
[ToolboxItem(true)]
[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
[XmlRoot("PO_PR")]
[DesignerCategory("code")]
[XmlSchemaProvider("GetTypedDataSetSchema")]
public class PO_PR : DataSet
{
	public delegate void DataTable1RowChangeEventHandler(object sender, DataTable1RowChangeEvent e);

	[Serializable]
	[XmlSchemaProvider("GetTypedTableSchema")]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
	public class DataTable1DataTable : TypedTableBase<DataTable1Row>
	{
		private DataColumn columnId;

		private DataColumn columnPONo;

		private DataColumn columnPOQty;

		private DataColumn columnRate;

		private DataColumn columnDiscount;

		private DataColumn columnDelDate;

		private DataColumn columnAmdNo;

		private DataColumn columnRefDesc;

		private DataColumn columnModeOfDispatch;

		private DataColumn columnInspection;

		private DataColumn columnShipTo;

		private DataColumn columnRemarks;

		private DataColumn columnPRNo;

		private DataColumn columnWONo;

		private DataColumn columnCompId;

		private DataColumn columnSuplierName;

		private DataColumn columnContactPerson;

		private DataColumn columnEmail;

		private DataColumn columnContactNo;

		private DataColumn columnItemCode;

		private DataColumn columnmanfDesc;

		private DataColumn columnUOMBasic;

		private DataColumn columnAcHead;

		private DataColumn columnOctriTerm;

		private DataColumn columnOctriValue;

		private DataColumn columnPackagingTerm;

		private DataColumn columnPackagingValue;

		private DataColumn columnPaymentTerm;

		private DataColumn columnExciseTerm;

		private DataColumn columnExciseValue;

		private DataColumn columnVatTerm;

		private DataColumn columnVatValue;

		private DataColumn columnWarranty;

		private DataColumn columnFright;

		private DataColumn columnRefPODesc;

		private DataColumn columnIndentor;

		private DataColumn columnBudgetCode;

		private DataColumn columnSupplierId;

		private DataColumn columnInsurance;

		private DataColumn columnSymbol;

		private DataColumn _columnSuplierName_;

		private DataColumn _columnVenderCode_;

		private DataColumn _columnRefDate_;

		private DataColumn _columnRefDesc_;

		private DataColumn _columnRefPODesc_;

		private DataColumn _columnRate_;

		private DataColumn _columnDiscount_;

		private DataColumn _columnPackagingValue_;

		private DataColumn _columnExciseValue_;

		private DataColumn _columnVatValue_;

		private DataColumn _columnDelDate_;

		private DataColumn _columnPaymentTerm_;

		private DataColumn _columnModeOfDispatch_;

		private DataColumn _columnInspection_;

		private DataColumn _columnOctriValue_;

		private DataColumn _columnWarranty_;

		private DataColumn _columnFright_;

		private DataColumn _columnInsurance_;

		private DataColumn _columnShipTo_;

		private DataColumn _columnRemarks_;

		private DataColumn _columnBudgetCode_;

		private DataColumn columnAddDesc;

		private DataColumn _columnAddDesc_;

		private DataColumn _columnPOQty_;

		private DataColumn _columnTC_;

		[DebuggerNonUserCode]
		public DataColumn IdColumn => columnId;

		[DebuggerNonUserCode]
		public DataColumn PONoColumn => columnPONo;

		[DebuggerNonUserCode]
		public DataColumn POQtyColumn => columnPOQty;

		[DebuggerNonUserCode]
		public DataColumn RateColumn => columnRate;

		[DebuggerNonUserCode]
		public DataColumn DiscountColumn => columnDiscount;

		[DebuggerNonUserCode]
		public DataColumn DelDateColumn => columnDelDate;

		[DebuggerNonUserCode]
		public DataColumn AmdNoColumn => columnAmdNo;

		[DebuggerNonUserCode]
		public DataColumn RefDescColumn => columnRefDesc;

		[DebuggerNonUserCode]
		public DataColumn ModeOfDispatchColumn => columnModeOfDispatch;

		[DebuggerNonUserCode]
		public DataColumn InspectionColumn => columnInspection;

		[DebuggerNonUserCode]
		public DataColumn ShipToColumn => columnShipTo;

		[DebuggerNonUserCode]
		public DataColumn RemarksColumn => columnRemarks;

		[DebuggerNonUserCode]
		public DataColumn PRNoColumn => columnPRNo;

		[DebuggerNonUserCode]
		public DataColumn WONoColumn => columnWONo;

		[DebuggerNonUserCode]
		public DataColumn CompIdColumn => columnCompId;

		[DebuggerNonUserCode]
		public DataColumn SuplierNameColumn => columnSuplierName;

		[DebuggerNonUserCode]
		public DataColumn ContactPersonColumn => columnContactPerson;

		[DebuggerNonUserCode]
		public DataColumn EmailColumn => columnEmail;

		[DebuggerNonUserCode]
		public DataColumn ContactNoColumn => columnContactNo;

		[DebuggerNonUserCode]
		public DataColumn ItemCodeColumn => columnItemCode;

		[DebuggerNonUserCode]
		public DataColumn manfDescColumn => columnmanfDesc;

		[DebuggerNonUserCode]
		public DataColumn UOMBasicColumn => columnUOMBasic;

		[DebuggerNonUserCode]
		public DataColumn AcHeadColumn => columnAcHead;

		[DebuggerNonUserCode]
		public DataColumn OctriTermColumn => columnOctriTerm;

		[DebuggerNonUserCode]
		public DataColumn OctriValueColumn => columnOctriValue;

		[DebuggerNonUserCode]
		public DataColumn PackagingTermColumn => columnPackagingTerm;

		[DebuggerNonUserCode]
		public DataColumn PackagingValueColumn => columnPackagingValue;

		[DebuggerNonUserCode]
		public DataColumn PaymentTermColumn => columnPaymentTerm;

		[DebuggerNonUserCode]
		public DataColumn ExciseTermColumn => columnExciseTerm;

		[DebuggerNonUserCode]
		public DataColumn ExciseValueColumn => columnExciseValue;

		[DebuggerNonUserCode]
		public DataColumn VatTermColumn => columnVatTerm;

		[DebuggerNonUserCode]
		public DataColumn VatValueColumn => columnVatValue;

		[DebuggerNonUserCode]
		public DataColumn WarrantyColumn => columnWarranty;

		[DebuggerNonUserCode]
		public DataColumn FrightColumn => columnFright;

		[DebuggerNonUserCode]
		public DataColumn RefPODescColumn => columnRefPODesc;

		[DebuggerNonUserCode]
		public DataColumn IndentorColumn => columnIndentor;

		[DebuggerNonUserCode]
		public DataColumn BudgetCodeColumn => columnBudgetCode;

		[DebuggerNonUserCode]
		public DataColumn SupplierIdColumn => columnSupplierId;

		[DebuggerNonUserCode]
		public DataColumn InsuranceColumn => columnInsurance;

		[DebuggerNonUserCode]
		public DataColumn SymbolColumn => columnSymbol;

		[DebuggerNonUserCode]
		public DataColumn _SuplierName_Column => _columnSuplierName_;

		[DebuggerNonUserCode]
		public DataColumn _VenderCode_Column => _columnVenderCode_;

		[DebuggerNonUserCode]
		public DataColumn _RefDate_Column => _columnRefDate_;

		[DebuggerNonUserCode]
		public DataColumn _RefDesc_Column => _columnRefDesc_;

		[DebuggerNonUserCode]
		public DataColumn _RefPODesc_Column => _columnRefPODesc_;

		[DebuggerNonUserCode]
		public DataColumn _Rate_Column => _columnRate_;

		[DebuggerNonUserCode]
		public DataColumn _Discount_Column => _columnDiscount_;

		[DebuggerNonUserCode]
		public DataColumn _PackagingValue_Column => _columnPackagingValue_;

		[DebuggerNonUserCode]
		public DataColumn _ExciseValue_Column => _columnExciseValue_;

		[DebuggerNonUserCode]
		public DataColumn _VatValue_Column => _columnVatValue_;

		[DebuggerNonUserCode]
		public DataColumn _DelDate_Column => _columnDelDate_;

		[DebuggerNonUserCode]
		public DataColumn _PaymentTerm_Column => _columnPaymentTerm_;

		[DebuggerNonUserCode]
		public DataColumn _ModeOfDispatch_Column => _columnModeOfDispatch_;

		[DebuggerNonUserCode]
		public DataColumn _Inspection_Column => _columnInspection_;

		[DebuggerNonUserCode]
		public DataColumn _OctriValue_Column => _columnOctriValue_;

		[DebuggerNonUserCode]
		public DataColumn _Warranty_Column => _columnWarranty_;

		[DebuggerNonUserCode]
		public DataColumn _Fright_Column => _columnFright_;

		[DebuggerNonUserCode]
		public DataColumn _Insurance_Column => _columnInsurance_;

		[DebuggerNonUserCode]
		public DataColumn _ShipTo_Column => _columnShipTo_;

		[DebuggerNonUserCode]
		public DataColumn _Remarks_Column => _columnRemarks_;

		[DebuggerNonUserCode]
		public DataColumn _BudgetCode_Column => _columnBudgetCode_;

		[DebuggerNonUserCode]
		public DataColumn AddDescColumn => columnAddDesc;

		[DebuggerNonUserCode]
		public DataColumn _AddDesc_Column => _columnAddDesc_;

		[DebuggerNonUserCode]
		public DataColumn _POQty_Column => _columnPOQty_;

		[DebuggerNonUserCode]
		public DataColumn _TC_Column => _columnTC_;

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
		public DataTable1Row AddDataTable1Row(int Id, string PONo, double POQty, double Rate, double Discount, string DelDate, int AmdNo, string RefDesc, string ModeOfDispatch, string Inspection, string ShipTo, string Remarks, string PRNo, string WONo, int CompId, string SuplierName, string ContactPerson, string Email, string ContactNo, string ItemCode, string manfDesc, string UOMBasic, string AcHead, string OctriTerm, double OctriValue, string PackagingTerm, double PackagingValue, string PaymentTerm, string ExciseTerm, double ExciseValue, string VatTerm, double VatValue, string Warranty, string Fright, string RefPODesc, string Indentor, string BudgetCode, string SupplierId, string Insurance, string Symbol, string _SuplierName_, string _VenderCode_, string _RefDate_, string _RefDesc_, string _RefPODesc_, string _Rate_, string _Discount_, string _PackagingValue_, string _ExciseValue_, string _VatValue_, string _DelDate_, string _PaymentTerm_, string _ModeOfDispatch_, string _Inspection_, string _OctriValue_, string _Warranty_, string _Fright_, string _Insurance_, string _ShipTo_, string _Remarks_, string _BudgetCode_, string AddDesc, string _AddDesc_, string _POQty_, string _TC_)
		{
			DataTable1Row dataTable1Row = (DataTable1Row)NewRow();
			object[] itemArray = new object[65]
			{
				Id, PONo, POQty, Rate, Discount, DelDate, AmdNo, RefDesc, ModeOfDispatch, Inspection,
				ShipTo, Remarks, PRNo, WONo, CompId, SuplierName, ContactPerson, Email, ContactNo, ItemCode,
				manfDesc, UOMBasic, AcHead, OctriTerm, OctriValue, PackagingTerm, PackagingValue, PaymentTerm, ExciseTerm, ExciseValue,
				VatTerm, VatValue, Warranty, Fright, RefPODesc, Indentor, BudgetCode, SupplierId, Insurance, Symbol,
				_SuplierName_, _VenderCode_, _RefDate_, _RefDesc_, _RefPODesc_, _Rate_, _Discount_, _PackagingValue_, _ExciseValue_, _VatValue_,
				_DelDate_, _PaymentTerm_, _ModeOfDispatch_, _Inspection_, _OctriValue_, _Warranty_, _Fright_, _Insurance_, _ShipTo_, _Remarks_,
				_BudgetCode_, AddDesc, _AddDesc_, _POQty_, _TC_
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
			columnPONo = base.Columns["PONo"];
			columnPOQty = base.Columns["POQty"];
			columnRate = base.Columns["Rate"];
			columnDiscount = base.Columns["Discount"];
			columnDelDate = base.Columns["DelDate"];
			columnAmdNo = base.Columns["AmdNo"];
			columnRefDesc = base.Columns["RefDesc"];
			columnModeOfDispatch = base.Columns["ModeOfDispatch"];
			columnInspection = base.Columns["Inspection"];
			columnShipTo = base.Columns["ShipTo"];
			columnRemarks = base.Columns["Remarks"];
			columnPRNo = base.Columns["PRNo"];
			columnWONo = base.Columns["WONo"];
			columnCompId = base.Columns["CompId"];
			columnSuplierName = base.Columns["SuplierName"];
			columnContactPerson = base.Columns["ContactPerson"];
			columnEmail = base.Columns["Email"];
			columnContactNo = base.Columns["ContactNo"];
			columnItemCode = base.Columns["ItemCode"];
			columnmanfDesc = base.Columns["manfDesc"];
			columnUOMBasic = base.Columns["UOMBasic"];
			columnAcHead = base.Columns["AcHead"];
			columnOctriTerm = base.Columns["OctriTerm"];
			columnOctriValue = base.Columns["OctriValue"];
			columnPackagingTerm = base.Columns["PackagingTerm"];
			columnPackagingValue = base.Columns["PackagingValue"];
			columnPaymentTerm = base.Columns["PaymentTerm"];
			columnExciseTerm = base.Columns["ExciseTerm"];
			columnExciseValue = base.Columns["ExciseValue"];
			columnVatTerm = base.Columns["VatTerm"];
			columnVatValue = base.Columns["VatValue"];
			columnWarranty = base.Columns["Warranty"];
			columnFright = base.Columns["Fright"];
			columnRefPODesc = base.Columns["RefPODesc"];
			columnIndentor = base.Columns["Indentor"];
			columnBudgetCode = base.Columns["BudgetCode"];
			columnSupplierId = base.Columns["SupplierId"];
			columnInsurance = base.Columns["Insurance"];
			columnSymbol = base.Columns["Symbol"];
			_columnSuplierName_ = base.Columns["SuplierName*"];
			_columnVenderCode_ = base.Columns["VenderCode*"];
			_columnRefDate_ = base.Columns["RefDate*"];
			_columnRefDesc_ = base.Columns["RefDesc*"];
			_columnRefPODesc_ = base.Columns["RefPODesc*"];
			_columnRate_ = base.Columns["Rate*"];
			_columnDiscount_ = base.Columns["Discount*"];
			_columnPackagingValue_ = base.Columns["PackagingValue*"];
			_columnExciseValue_ = base.Columns["ExciseValue*"];
			_columnVatValue_ = base.Columns["VatValue*"];
			_columnDelDate_ = base.Columns["DelDate*"];
			_columnPaymentTerm_ = base.Columns["PaymentTerm*"];
			_columnModeOfDispatch_ = base.Columns["ModeOfDispatch*"];
			_columnInspection_ = base.Columns["Inspection*"];
			_columnOctriValue_ = base.Columns["OctriValue*"];
			_columnWarranty_ = base.Columns["Warranty*"];
			_columnFright_ = base.Columns["Fright*"];
			_columnInsurance_ = base.Columns["Insurance*"];
			_columnShipTo_ = base.Columns["ShipTo*"];
			_columnRemarks_ = base.Columns["Remarks*"];
			_columnBudgetCode_ = base.Columns["BudgetCode*"];
			columnAddDesc = base.Columns["AddDesc"];
			_columnAddDesc_ = base.Columns["AddDesc*"];
			_columnPOQty_ = base.Columns["POQty*"];
			_columnTC_ = base.Columns["TC*"];
		}

		[DebuggerNonUserCode]
		private void InitClass()
		{
			columnId = new DataColumn("Id", typeof(int), null, MappingType.Element);
			base.Columns.Add(columnId);
			columnPONo = new DataColumn("PONo", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnPONo);
			columnPOQty = new DataColumn("POQty", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnPOQty);
			columnRate = new DataColumn("Rate", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnRate);
			columnDiscount = new DataColumn("Discount", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnDiscount);
			columnDelDate = new DataColumn("DelDate", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnDelDate);
			columnAmdNo = new DataColumn("AmdNo", typeof(int), null, MappingType.Element);
			base.Columns.Add(columnAmdNo);
			columnRefDesc = new DataColumn("RefDesc", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnRefDesc);
			columnModeOfDispatch = new DataColumn("ModeOfDispatch", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnModeOfDispatch);
			columnInspection = new DataColumn("Inspection", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnInspection);
			columnShipTo = new DataColumn("ShipTo", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnShipTo);
			columnRemarks = new DataColumn("Remarks", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnRemarks);
			columnPRNo = new DataColumn("PRNo", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnPRNo);
			columnWONo = new DataColumn("WONo", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnWONo);
			columnCompId = new DataColumn("CompId", typeof(int), null, MappingType.Element);
			base.Columns.Add(columnCompId);
			columnSuplierName = new DataColumn("SuplierName", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnSuplierName);
			columnContactPerson = new DataColumn("ContactPerson", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnContactPerson);
			columnEmail = new DataColumn("Email", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnEmail);
			columnContactNo = new DataColumn("ContactNo", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnContactNo);
			columnItemCode = new DataColumn("ItemCode", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnItemCode);
			columnmanfDesc = new DataColumn("manfDesc", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnmanfDesc);
			columnUOMBasic = new DataColumn("UOMBasic", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnUOMBasic);
			columnAcHead = new DataColumn("AcHead", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnAcHead);
			columnOctriTerm = new DataColumn("OctriTerm", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnOctriTerm);
			columnOctriValue = new DataColumn("OctriValue", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnOctriValue);
			columnPackagingTerm = new DataColumn("PackagingTerm", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnPackagingTerm);
			columnPackagingValue = new DataColumn("PackagingValue", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnPackagingValue);
			columnPaymentTerm = new DataColumn("PaymentTerm", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnPaymentTerm);
			columnExciseTerm = new DataColumn("ExciseTerm", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnExciseTerm);
			columnExciseValue = new DataColumn("ExciseValue", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnExciseValue);
			columnVatTerm = new DataColumn("VatTerm", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnVatTerm);
			columnVatValue = new DataColumn("VatValue", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnVatValue);
			columnWarranty = new DataColumn("Warranty", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnWarranty);
			columnFright = new DataColumn("Fright", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnFright);
			columnRefPODesc = new DataColumn("RefPODesc", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnRefPODesc);
			columnIndentor = new DataColumn("Indentor", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnIndentor);
			columnBudgetCode = new DataColumn("BudgetCode", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnBudgetCode);
			columnSupplierId = new DataColumn("SupplierId", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnSupplierId);
			columnInsurance = new DataColumn("Insurance", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnInsurance);
			columnSymbol = new DataColumn("Symbol", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnSymbol);
			_columnSuplierName_ = new DataColumn("SuplierName*", typeof(string), null, MappingType.Element);
			_columnSuplierName_.ExtendedProperties.Add("Generator_ColumnVarNameInTable", "_columnSuplierName_");
			_columnSuplierName_.ExtendedProperties.Add("Generator_UserColumnName", "SuplierName*");
			base.Columns.Add(_columnSuplierName_);
			_columnVenderCode_ = new DataColumn("VenderCode*", typeof(string), null, MappingType.Element);
			_columnVenderCode_.ExtendedProperties.Add("Generator_ColumnVarNameInTable", "_columnVenderCode_");
			_columnVenderCode_.ExtendedProperties.Add("Generator_UserColumnName", "VenderCode*");
			base.Columns.Add(_columnVenderCode_);
			_columnRefDate_ = new DataColumn("RefDate*", typeof(string), null, MappingType.Element);
			_columnRefDate_.ExtendedProperties.Add("Generator_ColumnVarNameInTable", "_columnRefDate_");
			_columnRefDate_.ExtendedProperties.Add("Generator_UserColumnName", "RefDate*");
			base.Columns.Add(_columnRefDate_);
			_columnRefDesc_ = new DataColumn("RefDesc*", typeof(string), null, MappingType.Element);
			_columnRefDesc_.ExtendedProperties.Add("Generator_ColumnVarNameInTable", "_columnRefDesc_");
			_columnRefDesc_.ExtendedProperties.Add("Generator_UserColumnName", "RefDesc*");
			base.Columns.Add(_columnRefDesc_);
			_columnRefPODesc_ = new DataColumn("RefPODesc*", typeof(string), null, MappingType.Element);
			_columnRefPODesc_.ExtendedProperties.Add("Generator_ColumnVarNameInTable", "_columnRefPODesc_");
			_columnRefPODesc_.ExtendedProperties.Add("Generator_UserColumnName", "RefPODesc*");
			base.Columns.Add(_columnRefPODesc_);
			_columnRate_ = new DataColumn("Rate*", typeof(string), null, MappingType.Element);
			_columnRate_.ExtendedProperties.Add("Generator_ColumnVarNameInTable", "_columnRate_");
			_columnRate_.ExtendedProperties.Add("Generator_UserColumnName", "Rate*");
			base.Columns.Add(_columnRate_);
			_columnDiscount_ = new DataColumn("Discount*", typeof(string), null, MappingType.Element);
			_columnDiscount_.ExtendedProperties.Add("Generator_ColumnVarNameInTable", "_columnDiscount_");
			_columnDiscount_.ExtendedProperties.Add("Generator_UserColumnName", "Discount*");
			base.Columns.Add(_columnDiscount_);
			_columnPackagingValue_ = new DataColumn("PackagingValue*", typeof(string), null, MappingType.Element);
			_columnPackagingValue_.ExtendedProperties.Add("Generator_ColumnVarNameInTable", "_columnPackagingValue_");
			_columnPackagingValue_.ExtendedProperties.Add("Generator_UserColumnName", "PackagingValue*");
			base.Columns.Add(_columnPackagingValue_);
			_columnExciseValue_ = new DataColumn("ExciseValue*", typeof(string), null, MappingType.Element);
			_columnExciseValue_.ExtendedProperties.Add("Generator_ColumnVarNameInTable", "_columnExciseValue_");
			_columnExciseValue_.ExtendedProperties.Add("Generator_UserColumnName", "ExciseValue*");
			base.Columns.Add(_columnExciseValue_);
			_columnVatValue_ = new DataColumn("VatValue*", typeof(string), null, MappingType.Element);
			_columnVatValue_.ExtendedProperties.Add("Generator_ColumnVarNameInTable", "_columnVatValue_");
			_columnVatValue_.ExtendedProperties.Add("Generator_UserColumnName", "VatValue*");
			base.Columns.Add(_columnVatValue_);
			_columnDelDate_ = new DataColumn("DelDate*", typeof(string), null, MappingType.Element);
			_columnDelDate_.ExtendedProperties.Add("Generator_ColumnVarNameInTable", "_columnDelDate_");
			_columnDelDate_.ExtendedProperties.Add("Generator_UserColumnName", "DelDate*");
			base.Columns.Add(_columnDelDate_);
			_columnPaymentTerm_ = new DataColumn("PaymentTerm*", typeof(string), null, MappingType.Element);
			_columnPaymentTerm_.ExtendedProperties.Add("Generator_ColumnVarNameInTable", "_columnPaymentTerm_");
			_columnPaymentTerm_.ExtendedProperties.Add("Generator_UserColumnName", "PaymentTerm*");
			base.Columns.Add(_columnPaymentTerm_);
			_columnModeOfDispatch_ = new DataColumn("ModeOfDispatch*", typeof(string), null, MappingType.Element);
			_columnModeOfDispatch_.ExtendedProperties.Add("Generator_ColumnVarNameInTable", "_columnModeOfDispatch_");
			_columnModeOfDispatch_.ExtendedProperties.Add("Generator_UserColumnName", "ModeOfDispatch*");
			base.Columns.Add(_columnModeOfDispatch_);
			_columnInspection_ = new DataColumn("Inspection*", typeof(string), null, MappingType.Element);
			_columnInspection_.ExtendedProperties.Add("Generator_ColumnVarNameInTable", "_columnInspection_");
			_columnInspection_.ExtendedProperties.Add("Generator_UserColumnName", "Inspection*");
			base.Columns.Add(_columnInspection_);
			_columnOctriValue_ = new DataColumn("OctriValue*", typeof(string), null, MappingType.Element);
			_columnOctriValue_.ExtendedProperties.Add("Generator_ColumnVarNameInTable", "_columnOctriValue_");
			_columnOctriValue_.ExtendedProperties.Add("Generator_UserColumnName", "OctriValue*");
			base.Columns.Add(_columnOctriValue_);
			_columnWarranty_ = new DataColumn("Warranty*", typeof(string), null, MappingType.Element);
			_columnWarranty_.ExtendedProperties.Add("Generator_ColumnVarNameInTable", "_columnWarranty_");
			_columnWarranty_.ExtendedProperties.Add("Generator_UserColumnName", "Warranty*");
			base.Columns.Add(_columnWarranty_);
			_columnFright_ = new DataColumn("Fright*", typeof(string), null, MappingType.Element);
			_columnFright_.ExtendedProperties.Add("Generator_ColumnVarNameInTable", "_columnFright_");
			_columnFright_.ExtendedProperties.Add("Generator_UserColumnName", "Fright*");
			base.Columns.Add(_columnFright_);
			_columnInsurance_ = new DataColumn("Insurance*", typeof(string), null, MappingType.Element);
			_columnInsurance_.ExtendedProperties.Add("Generator_ColumnVarNameInTable", "_columnInsurance_");
			_columnInsurance_.ExtendedProperties.Add("Generator_UserColumnName", "Insurance*");
			base.Columns.Add(_columnInsurance_);
			_columnShipTo_ = new DataColumn("ShipTo*", typeof(string), null, MappingType.Element);
			_columnShipTo_.ExtendedProperties.Add("Generator_ColumnVarNameInTable", "_columnShipTo_");
			_columnShipTo_.ExtendedProperties.Add("Generator_UserColumnName", "ShipTo*");
			base.Columns.Add(_columnShipTo_);
			_columnRemarks_ = new DataColumn("Remarks*", typeof(string), null, MappingType.Element);
			_columnRemarks_.ExtendedProperties.Add("Generator_ColumnVarNameInTable", "_columnRemarks_");
			_columnRemarks_.ExtendedProperties.Add("Generator_UserColumnName", "Remarks*");
			base.Columns.Add(_columnRemarks_);
			_columnBudgetCode_ = new DataColumn("BudgetCode*", typeof(string), null, MappingType.Element);
			_columnBudgetCode_.ExtendedProperties.Add("Generator_ColumnVarNameInTable", "_columnBudgetCode_");
			_columnBudgetCode_.ExtendedProperties.Add("Generator_UserColumnName", "BudgetCode*");
			base.Columns.Add(_columnBudgetCode_);
			columnAddDesc = new DataColumn("AddDesc", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnAddDesc);
			_columnAddDesc_ = new DataColumn("AddDesc*", typeof(string), null, MappingType.Element);
			_columnAddDesc_.ExtendedProperties.Add("Generator_ColumnVarNameInTable", "_columnAddDesc_");
			_columnAddDesc_.ExtendedProperties.Add("Generator_UserColumnName", "AddDesc*");
			base.Columns.Add(_columnAddDesc_);
			_columnPOQty_ = new DataColumn("POQty*", typeof(string), null, MappingType.Element);
			_columnPOQty_.ExtendedProperties.Add("Generator_ColumnVarNameInTable", "_columnPOQty_");
			_columnPOQty_.ExtendedProperties.Add("Generator_UserColumnName", "POQty*");
			base.Columns.Add(_columnPOQty_);
			_columnTC_ = new DataColumn("TC*", typeof(string), null, MappingType.Element);
			_columnTC_.ExtendedProperties.Add("Generator_ColumnVarNameInTable", "_columnTC_");
			_columnTC_.ExtendedProperties.Add("Generator_UserColumnName", "TC*");
			base.Columns.Add(_columnTC_);
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
			PO_PR pO_PR = new PO_PR();
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
			xmlSchemaAttribute.FixedValue = pO_PR.Namespace;
			xmlSchemaComplexType.Attributes.Add(xmlSchemaAttribute);
			XmlSchemaAttribute xmlSchemaAttribute2 = new XmlSchemaAttribute();
			xmlSchemaAttribute2.Name = "tableTypeName";
			xmlSchemaAttribute2.FixedValue = "DataTable1DataTable";
			xmlSchemaComplexType.Attributes.Add(xmlSchemaAttribute2);
			xmlSchemaComplexType.Particle = xmlSchemaSequence;
			XmlSchema schemaSerializable = pO_PR.GetSchemaSerializable();
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
		public string DelDate
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.DelDateColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'DelDate' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.DelDateColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public int AmdNo
		{
			get
			{
				try
				{
					return (int)base[tableDataTable1.AmdNoColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'AmdNo' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.AmdNoColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string RefDesc
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.RefDescColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'RefDesc' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.RefDescColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string ModeOfDispatch
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.ModeOfDispatchColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'ModeOfDispatch' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.ModeOfDispatchColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string Inspection
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.InspectionColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Inspection' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.InspectionColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string ShipTo
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.ShipToColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'ShipTo' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.ShipToColumn] = value;
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
		public string PRNo
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.PRNoColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'PRNo' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.PRNoColumn] = value;
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
		public string SuplierName
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.SuplierNameColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'SuplierName' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.SuplierNameColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string ContactPerson
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.ContactPersonColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'ContactPerson' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.ContactPersonColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string Email
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.EmailColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Email' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.EmailColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string ContactNo
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.ContactNoColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'ContactNo' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.ContactNoColumn] = value;
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
		public string manfDesc
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.manfDescColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'manfDesc' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.manfDescColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string UOMBasic
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.UOMBasicColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'UOMBasic' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.UOMBasicColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string AcHead
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.AcHeadColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'AcHead' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.AcHeadColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string OctriTerm
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.OctriTermColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'OctriTerm' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.OctriTermColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public double OctriValue
		{
			get
			{
				try
				{
					return (double)base[tableDataTable1.OctriValueColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'OctriValue' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.OctriValueColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string PackagingTerm
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.PackagingTermColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'PackagingTerm' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.PackagingTermColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public double PackagingValue
		{
			get
			{
				try
				{
					return (double)base[tableDataTable1.PackagingValueColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'PackagingValue' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.PackagingValueColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string PaymentTerm
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.PaymentTermColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'PaymentTerm' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.PaymentTermColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string ExciseTerm
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.ExciseTermColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'ExciseTerm' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.ExciseTermColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public double ExciseValue
		{
			get
			{
				try
				{
					return (double)base[tableDataTable1.ExciseValueColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'ExciseValue' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.ExciseValueColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string VatTerm
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.VatTermColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'VatTerm' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.VatTermColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public double VatValue
		{
			get
			{
				try
				{
					return (double)base[tableDataTable1.VatValueColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'VatValue' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.VatValueColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string Warranty
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.WarrantyColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Warranty' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.WarrantyColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string Fright
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.FrightColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Fright' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.FrightColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string RefPODesc
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.RefPODescColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'RefPODesc' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.RefPODescColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string Indentor
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.IndentorColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Indentor' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.IndentorColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string BudgetCode
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.BudgetCodeColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'BudgetCode' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.BudgetCodeColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string SupplierId
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.SupplierIdColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'SupplierId' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.SupplierIdColumn] = value;
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
		public string Symbol
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.SymbolColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Symbol' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.SymbolColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string _SuplierName_
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1._SuplierName_Column];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'SuplierName*' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1._SuplierName_Column] = value;
			}
		}

		[DebuggerNonUserCode]
		public string _VenderCode_
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1._VenderCode_Column];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'VenderCode*' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1._VenderCode_Column] = value;
			}
		}

		[DebuggerNonUserCode]
		public string _RefDate_
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1._RefDate_Column];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'RefDate*' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1._RefDate_Column] = value;
			}
		}

		[DebuggerNonUserCode]
		public string _RefDesc_
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1._RefDesc_Column];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'RefDesc*' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1._RefDesc_Column] = value;
			}
		}

		[DebuggerNonUserCode]
		public string _RefPODesc_
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1._RefPODesc_Column];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'RefPODesc*' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1._RefPODesc_Column] = value;
			}
		}

		[DebuggerNonUserCode]
		public string _Rate_
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1._Rate_Column];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Rate*' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1._Rate_Column] = value;
			}
		}

		[DebuggerNonUserCode]
		public string _Discount_
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1._Discount_Column];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Discount*' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1._Discount_Column] = value;
			}
		}

		[DebuggerNonUserCode]
		public string _PackagingValue_
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1._PackagingValue_Column];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'PackagingValue*' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1._PackagingValue_Column] = value;
			}
		}

		[DebuggerNonUserCode]
		public string _ExciseValue_
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1._ExciseValue_Column];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'ExciseValue*' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1._ExciseValue_Column] = value;
			}
		}

		[DebuggerNonUserCode]
		public string _VatValue_
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1._VatValue_Column];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'VatValue*' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1._VatValue_Column] = value;
			}
		}

		[DebuggerNonUserCode]
		public string _DelDate_
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1._DelDate_Column];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'DelDate*' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1._DelDate_Column] = value;
			}
		}

		[DebuggerNonUserCode]
		public string _PaymentTerm_
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1._PaymentTerm_Column];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'PaymentTerm*' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1._PaymentTerm_Column] = value;
			}
		}

		[DebuggerNonUserCode]
		public string _ModeOfDispatch_
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1._ModeOfDispatch_Column];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'ModeOfDispatch*' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1._ModeOfDispatch_Column] = value;
			}
		}

		[DebuggerNonUserCode]
		public string _Inspection_
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1._Inspection_Column];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Inspection*' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1._Inspection_Column] = value;
			}
		}

		[DebuggerNonUserCode]
		public string _OctriValue_
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1._OctriValue_Column];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'OctriValue*' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1._OctriValue_Column] = value;
			}
		}

		[DebuggerNonUserCode]
		public string _Warranty_
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1._Warranty_Column];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Warranty*' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1._Warranty_Column] = value;
			}
		}

		[DebuggerNonUserCode]
		public string _Fright_
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1._Fright_Column];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Fright*' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1._Fright_Column] = value;
			}
		}

		[DebuggerNonUserCode]
		public string _Insurance_
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1._Insurance_Column];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Insurance*' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1._Insurance_Column] = value;
			}
		}

		[DebuggerNonUserCode]
		public string _ShipTo_
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1._ShipTo_Column];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'ShipTo*' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1._ShipTo_Column] = value;
			}
		}

		[DebuggerNonUserCode]
		public string _Remarks_
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1._Remarks_Column];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Remarks*' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1._Remarks_Column] = value;
			}
		}

		[DebuggerNonUserCode]
		public string _BudgetCode_
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1._BudgetCode_Column];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'BudgetCode*' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1._BudgetCode_Column] = value;
			}
		}

		[DebuggerNonUserCode]
		public string AddDesc
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.AddDescColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'AddDesc' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.AddDescColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string _AddDesc_
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1._AddDesc_Column];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'AddDesc*' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1._AddDesc_Column] = value;
			}
		}

		[DebuggerNonUserCode]
		public string _POQty_
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1._POQty_Column];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'POQty*' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1._POQty_Column] = value;
			}
		}

		[DebuggerNonUserCode]
		public string _TC_
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1._TC_Column];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'TC*' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1._TC_Column] = value;
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
		public bool IsDelDateNull()
		{
			return IsNull(tableDataTable1.DelDateColumn);
		}

		[DebuggerNonUserCode]
		public void SetDelDateNull()
		{
			base[tableDataTable1.DelDateColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsAmdNoNull()
		{
			return IsNull(tableDataTable1.AmdNoColumn);
		}

		[DebuggerNonUserCode]
		public void SetAmdNoNull()
		{
			base[tableDataTable1.AmdNoColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsRefDescNull()
		{
			return IsNull(tableDataTable1.RefDescColumn);
		}

		[DebuggerNonUserCode]
		public void SetRefDescNull()
		{
			base[tableDataTable1.RefDescColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsModeOfDispatchNull()
		{
			return IsNull(tableDataTable1.ModeOfDispatchColumn);
		}

		[DebuggerNonUserCode]
		public void SetModeOfDispatchNull()
		{
			base[tableDataTable1.ModeOfDispatchColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsInspectionNull()
		{
			return IsNull(tableDataTable1.InspectionColumn);
		}

		[DebuggerNonUserCode]
		public void SetInspectionNull()
		{
			base[tableDataTable1.InspectionColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsShipToNull()
		{
			return IsNull(tableDataTable1.ShipToColumn);
		}

		[DebuggerNonUserCode]
		public void SetShipToNull()
		{
			base[tableDataTable1.ShipToColumn] = Convert.DBNull;
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
		public bool IsPRNoNull()
		{
			return IsNull(tableDataTable1.PRNoColumn);
		}

		[DebuggerNonUserCode]
		public void SetPRNoNull()
		{
			base[tableDataTable1.PRNoColumn] = Convert.DBNull;
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
		public bool IsSuplierNameNull()
		{
			return IsNull(tableDataTable1.SuplierNameColumn);
		}

		[DebuggerNonUserCode]
		public void SetSuplierNameNull()
		{
			base[tableDataTable1.SuplierNameColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsContactPersonNull()
		{
			return IsNull(tableDataTable1.ContactPersonColumn);
		}

		[DebuggerNonUserCode]
		public void SetContactPersonNull()
		{
			base[tableDataTable1.ContactPersonColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsEmailNull()
		{
			return IsNull(tableDataTable1.EmailColumn);
		}

		[DebuggerNonUserCode]
		public void SetEmailNull()
		{
			base[tableDataTable1.EmailColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsContactNoNull()
		{
			return IsNull(tableDataTable1.ContactNoColumn);
		}

		[DebuggerNonUserCode]
		public void SetContactNoNull()
		{
			base[tableDataTable1.ContactNoColumn] = Convert.DBNull;
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
		public bool IsmanfDescNull()
		{
			return IsNull(tableDataTable1.manfDescColumn);
		}

		[DebuggerNonUserCode]
		public void SetmanfDescNull()
		{
			base[tableDataTable1.manfDescColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsUOMBasicNull()
		{
			return IsNull(tableDataTable1.UOMBasicColumn);
		}

		[DebuggerNonUserCode]
		public void SetUOMBasicNull()
		{
			base[tableDataTable1.UOMBasicColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsAcHeadNull()
		{
			return IsNull(tableDataTable1.AcHeadColumn);
		}

		[DebuggerNonUserCode]
		public void SetAcHeadNull()
		{
			base[tableDataTable1.AcHeadColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsOctriTermNull()
		{
			return IsNull(tableDataTable1.OctriTermColumn);
		}

		[DebuggerNonUserCode]
		public void SetOctriTermNull()
		{
			base[tableDataTable1.OctriTermColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsOctriValueNull()
		{
			return IsNull(tableDataTable1.OctriValueColumn);
		}

		[DebuggerNonUserCode]
		public void SetOctriValueNull()
		{
			base[tableDataTable1.OctriValueColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsPackagingTermNull()
		{
			return IsNull(tableDataTable1.PackagingTermColumn);
		}

		[DebuggerNonUserCode]
		public void SetPackagingTermNull()
		{
			base[tableDataTable1.PackagingTermColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsPackagingValueNull()
		{
			return IsNull(tableDataTable1.PackagingValueColumn);
		}

		[DebuggerNonUserCode]
		public void SetPackagingValueNull()
		{
			base[tableDataTable1.PackagingValueColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsPaymentTermNull()
		{
			return IsNull(tableDataTable1.PaymentTermColumn);
		}

		[DebuggerNonUserCode]
		public void SetPaymentTermNull()
		{
			base[tableDataTable1.PaymentTermColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsExciseTermNull()
		{
			return IsNull(tableDataTable1.ExciseTermColumn);
		}

		[DebuggerNonUserCode]
		public void SetExciseTermNull()
		{
			base[tableDataTable1.ExciseTermColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsExciseValueNull()
		{
			return IsNull(tableDataTable1.ExciseValueColumn);
		}

		[DebuggerNonUserCode]
		public void SetExciseValueNull()
		{
			base[tableDataTable1.ExciseValueColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsVatTermNull()
		{
			return IsNull(tableDataTable1.VatTermColumn);
		}

		[DebuggerNonUserCode]
		public void SetVatTermNull()
		{
			base[tableDataTable1.VatTermColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsVatValueNull()
		{
			return IsNull(tableDataTable1.VatValueColumn);
		}

		[DebuggerNonUserCode]
		public void SetVatValueNull()
		{
			base[tableDataTable1.VatValueColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsWarrantyNull()
		{
			return IsNull(tableDataTable1.WarrantyColumn);
		}

		[DebuggerNonUserCode]
		public void SetWarrantyNull()
		{
			base[tableDataTable1.WarrantyColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsFrightNull()
		{
			return IsNull(tableDataTable1.FrightColumn);
		}

		[DebuggerNonUserCode]
		public void SetFrightNull()
		{
			base[tableDataTable1.FrightColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsRefPODescNull()
		{
			return IsNull(tableDataTable1.RefPODescColumn);
		}

		[DebuggerNonUserCode]
		public void SetRefPODescNull()
		{
			base[tableDataTable1.RefPODescColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsIndentorNull()
		{
			return IsNull(tableDataTable1.IndentorColumn);
		}

		[DebuggerNonUserCode]
		public void SetIndentorNull()
		{
			base[tableDataTable1.IndentorColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsBudgetCodeNull()
		{
			return IsNull(tableDataTable1.BudgetCodeColumn);
		}

		[DebuggerNonUserCode]
		public void SetBudgetCodeNull()
		{
			base[tableDataTable1.BudgetCodeColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsSupplierIdNull()
		{
			return IsNull(tableDataTable1.SupplierIdColumn);
		}

		[DebuggerNonUserCode]
		public void SetSupplierIdNull()
		{
			base[tableDataTable1.SupplierIdColumn] = Convert.DBNull;
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
		public bool IsSymbolNull()
		{
			return IsNull(tableDataTable1.SymbolColumn);
		}

		[DebuggerNonUserCode]
		public void SetSymbolNull()
		{
			base[tableDataTable1.SymbolColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool Is_SuplierName_Null()
		{
			return IsNull(tableDataTable1._SuplierName_Column);
		}

		[DebuggerNonUserCode]
		public void Set_SuplierName_Null()
		{
			base[tableDataTable1._SuplierName_Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool Is_VenderCode_Null()
		{
			return IsNull(tableDataTable1._VenderCode_Column);
		}

		[DebuggerNonUserCode]
		public void Set_VenderCode_Null()
		{
			base[tableDataTable1._VenderCode_Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool Is_RefDate_Null()
		{
			return IsNull(tableDataTable1._RefDate_Column);
		}

		[DebuggerNonUserCode]
		public void Set_RefDate_Null()
		{
			base[tableDataTable1._RefDate_Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool Is_RefDesc_Null()
		{
			return IsNull(tableDataTable1._RefDesc_Column);
		}

		[DebuggerNonUserCode]
		public void Set_RefDesc_Null()
		{
			base[tableDataTable1._RefDesc_Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool Is_RefPODesc_Null()
		{
			return IsNull(tableDataTable1._RefPODesc_Column);
		}

		[DebuggerNonUserCode]
		public void Set_RefPODesc_Null()
		{
			base[tableDataTable1._RefPODesc_Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool Is_Rate_Null()
		{
			return IsNull(tableDataTable1._Rate_Column);
		}

		[DebuggerNonUserCode]
		public void Set_Rate_Null()
		{
			base[tableDataTable1._Rate_Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool Is_Discount_Null()
		{
			return IsNull(tableDataTable1._Discount_Column);
		}

		[DebuggerNonUserCode]
		public void Set_Discount_Null()
		{
			base[tableDataTable1._Discount_Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool Is_PackagingValue_Null()
		{
			return IsNull(tableDataTable1._PackagingValue_Column);
		}

		[DebuggerNonUserCode]
		public void Set_PackagingValue_Null()
		{
			base[tableDataTable1._PackagingValue_Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool Is_ExciseValue_Null()
		{
			return IsNull(tableDataTable1._ExciseValue_Column);
		}

		[DebuggerNonUserCode]
		public void Set_ExciseValue_Null()
		{
			base[tableDataTable1._ExciseValue_Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool Is_VatValue_Null()
		{
			return IsNull(tableDataTable1._VatValue_Column);
		}

		[DebuggerNonUserCode]
		public void Set_VatValue_Null()
		{
			base[tableDataTable1._VatValue_Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool Is_DelDate_Null()
		{
			return IsNull(tableDataTable1._DelDate_Column);
		}

		[DebuggerNonUserCode]
		public void Set_DelDate_Null()
		{
			base[tableDataTable1._DelDate_Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool Is_PaymentTerm_Null()
		{
			return IsNull(tableDataTable1._PaymentTerm_Column);
		}

		[DebuggerNonUserCode]
		public void Set_PaymentTerm_Null()
		{
			base[tableDataTable1._PaymentTerm_Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool Is_ModeOfDispatch_Null()
		{
			return IsNull(tableDataTable1._ModeOfDispatch_Column);
		}

		[DebuggerNonUserCode]
		public void Set_ModeOfDispatch_Null()
		{
			base[tableDataTable1._ModeOfDispatch_Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool Is_Inspection_Null()
		{
			return IsNull(tableDataTable1._Inspection_Column);
		}

		[DebuggerNonUserCode]
		public void Set_Inspection_Null()
		{
			base[tableDataTable1._Inspection_Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool Is_OctriValue_Null()
		{
			return IsNull(tableDataTable1._OctriValue_Column);
		}

		[DebuggerNonUserCode]
		public void Set_OctriValue_Null()
		{
			base[tableDataTable1._OctriValue_Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool Is_Warranty_Null()
		{
			return IsNull(tableDataTable1._Warranty_Column);
		}

		[DebuggerNonUserCode]
		public void Set_Warranty_Null()
		{
			base[tableDataTable1._Warranty_Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool Is_Fright_Null()
		{
			return IsNull(tableDataTable1._Fright_Column);
		}

		[DebuggerNonUserCode]
		public void Set_Fright_Null()
		{
			base[tableDataTable1._Fright_Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool Is_Insurance_Null()
		{
			return IsNull(tableDataTable1._Insurance_Column);
		}

		[DebuggerNonUserCode]
		public void Set_Insurance_Null()
		{
			base[tableDataTable1._Insurance_Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool Is_ShipTo_Null()
		{
			return IsNull(tableDataTable1._ShipTo_Column);
		}

		[DebuggerNonUserCode]
		public void Set_ShipTo_Null()
		{
			base[tableDataTable1._ShipTo_Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool Is_Remarks_Null()
		{
			return IsNull(tableDataTable1._Remarks_Column);
		}

		[DebuggerNonUserCode]
		public void Set_Remarks_Null()
		{
			base[tableDataTable1._Remarks_Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool Is_BudgetCode_Null()
		{
			return IsNull(tableDataTable1._BudgetCode_Column);
		}

		[DebuggerNonUserCode]
		public void Set_BudgetCode_Null()
		{
			base[tableDataTable1._BudgetCode_Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsAddDescNull()
		{
			return IsNull(tableDataTable1.AddDescColumn);
		}

		[DebuggerNonUserCode]
		public void SetAddDescNull()
		{
			base[tableDataTable1.AddDescColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool Is_AddDesc_Null()
		{
			return IsNull(tableDataTable1._AddDesc_Column);
		}

		[DebuggerNonUserCode]
		public void Set_AddDesc_Null()
		{
			base[tableDataTable1._AddDesc_Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool Is_POQty_Null()
		{
			return IsNull(tableDataTable1._POQty_Column);
		}

		[DebuggerNonUserCode]
		public void Set_POQty_Null()
		{
			base[tableDataTable1._POQty_Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool Is_TC_Null()
		{
			return IsNull(tableDataTable1._TC_Column);
		}

		[DebuggerNonUserCode]
		public void Set_TC_Null()
		{
			base[tableDataTable1._TC_Column] = Convert.DBNull;
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
	[Browsable(false)]
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

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[DebuggerNonUserCode]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataRelationCollection Relations => base.Relations;

	[DebuggerNonUserCode]
	public PO_PR()
	{
		BeginInit();
		InitClass();
		CollectionChangeEventHandler value = SchemaChanged;
		base.Tables.CollectionChanged += value;
		base.Relations.CollectionChanged += value;
		EndInit();
	}

	[DebuggerNonUserCode]
	protected PO_PR(SerializationInfo info, StreamingContext context)
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
		PO_PR pO_PR = (PO_PR)base.Clone();
		pO_PR.InitVars();
		pO_PR.SchemaSerializationMode = SchemaSerializationMode;
		return pO_PR;
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
		base.DataSetName = "PO_PR";
		base.Prefix = "";
		base.Namespace = "http://tempuri.org/PO_PR.xsd";
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
		PO_PR pO_PR = new PO_PR();
		XmlSchemaComplexType xmlSchemaComplexType = new XmlSchemaComplexType();
		XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
		XmlSchemaAny xmlSchemaAny = new XmlSchemaAny();
		xmlSchemaAny.Namespace = pO_PR.Namespace;
		xmlSchemaSequence.Items.Add(xmlSchemaAny);
		xmlSchemaComplexType.Particle = xmlSchemaSequence;
		XmlSchema schemaSerializable = pO_PR.GetSchemaSerializable();
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
