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
[XmlRoot("BillBooking")]
[HelpKeyword("vs.data.DataSet")]
[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
[DesignerCategory("code")]
[ToolboxItem(true)]
[XmlSchemaProvider("GetTypedDataSetSchema")]
public class BillBooking : DataSet
{
	public delegate void DataTable1RowChangeEventHandler(object sender, DataTable1RowChangeEvent e);

	public delegate void DataTable2RowChangeEventHandler(object sender, DataTable2RowChangeEvent e);

	[Serializable]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
	[XmlSchemaProvider("GetTypedTableSchema")]
	public class DataTable1DataTable : TypedTableBase<DataTable1Row>
	{
		private DataColumn columnId;

		private DataColumn columnGQNNo;

		private DataColumn columnGSNNo;

		private DataColumn columnItemCode;

		private DataColumn columnDescr;

		private DataColumn columnUOM;

		private DataColumn columnAmt;

		private DataColumn columnPFAmt;

		private DataColumn columnExStBasicInPer;

		private DataColumn columnExStEducessInPer;

		private DataColumn columnExStShecessInPer;

		private DataColumn columnExStBasic;

		private DataColumn columnExStEducess;

		private DataColumn columnExStShecess;

		private DataColumn columnCustomDuty;

		private DataColumn columnVAT;

		private DataColumn columnCST;

		private DataColumn columnFreight;

		private DataColumn columnTarrifNo;

		private DataColumn columnFinYear;

		private DataColumn columnPVEVNo;

		private DataColumn columnSysDate;

		private DataColumn columnPONo;

		private DataColumn columnPODate;

		private DataColumn columnSupplierName;

		private DataColumn columnCompId;

		private DataColumn columnSupplierId;

		private DataColumn columnOtherCharges;

		private DataColumn columnOtherChaDesc;

		private DataColumn columnNarration;

		private DataColumn columnDebitAmt;

		private DataColumn columnDiscountType;

		private DataColumn columnDiscount;

		private DataColumn columnBillNo;

		private DataColumn columnBillDate;

		private DataColumn columnCENVATEntryNo;

		private DataColumn columnCENVATEntryDate;

		private DataColumn columnAccHead;

		private DataColumn columnWODept;

		private DataColumn columnPOQty;

		private DataColumn columnPORate;

		private DataColumn columnDisc;

		private DataColumn columnAccQty;

		private DataColumn columnExciseTerm;

		private DataColumn columnPFTerm;

		private DataColumn columnVATTerm;

		private DataColumn columnIsVATCST;

		private DataColumn columnDebitType;

		private DataColumn columnDebitValue;

		private DataColumn columnBasicAmt;

		private DataColumn columnPFid;

		private DataColumn columnExciseId;

		private DataColumn columnVATCSTid;

		private DataColumn columnBCDOpt;

		private DataColumn columnBCD;

		private DataColumn columnBCDValue;

		private DataColumn columnValueForCVD;

		private DataColumn columnValueForEdCessCD;

		private DataColumn columnEdCessOnCDOpt;

		private DataColumn columnEdCessOnCD;

		private DataColumn columnEdCessOnCDValue;

		private DataColumn columnSHEDCessOpt;

		private DataColumn columnSHEDCess;

		private DataColumn columnSHEDCessValue;

		private DataColumn columnTotDuty;

		private DataColumn columnTotDutyEDSHED;

		private DataColumn columnInsurance;

		private DataColumn columnValueWithDuty;

		private DataColumn columnSectionNo;

		private DataColumn columnTDSPerCentage;

		private DataColumn columnPaymentRange;

		private DataColumn columnTDSCode;

		private DataColumn columnBookedBillTotal;

		[DebuggerNonUserCode]
		public DataColumn IdColumn => columnId;

		[DebuggerNonUserCode]
		public DataColumn GQNNoColumn => columnGQNNo;

		[DebuggerNonUserCode]
		public DataColumn GSNNoColumn => columnGSNNo;

		[DebuggerNonUserCode]
		public DataColumn ItemCodeColumn => columnItemCode;

		[DebuggerNonUserCode]
		public DataColumn DescrColumn => columnDescr;

		[DebuggerNonUserCode]
		public DataColumn UOMColumn => columnUOM;

		[DebuggerNonUserCode]
		public DataColumn AmtColumn => columnAmt;

		[DebuggerNonUserCode]
		public DataColumn PFAmtColumn => columnPFAmt;

		[DebuggerNonUserCode]
		public DataColumn ExStBasicInPerColumn => columnExStBasicInPer;

		[DebuggerNonUserCode]
		public DataColumn ExStEducessInPerColumn => columnExStEducessInPer;

		[DebuggerNonUserCode]
		public DataColumn ExStShecessInPerColumn => columnExStShecessInPer;

		[DebuggerNonUserCode]
		public DataColumn ExStBasicColumn => columnExStBasic;

		[DebuggerNonUserCode]
		public DataColumn ExStEducessColumn => columnExStEducess;

		[DebuggerNonUserCode]
		public DataColumn ExStShecessColumn => columnExStShecess;

		[DebuggerNonUserCode]
		public DataColumn CustomDutyColumn => columnCustomDuty;

		[DebuggerNonUserCode]
		public DataColumn VATColumn => columnVAT;

		[DebuggerNonUserCode]
		public DataColumn CSTColumn => columnCST;

		[DebuggerNonUserCode]
		public DataColumn FreightColumn => columnFreight;

		[DebuggerNonUserCode]
		public DataColumn TarrifNoColumn => columnTarrifNo;

		[DebuggerNonUserCode]
		public DataColumn FinYearColumn => columnFinYear;

		[DebuggerNonUserCode]
		public DataColumn PVEVNoColumn => columnPVEVNo;

		[DebuggerNonUserCode]
		public DataColumn SysDateColumn => columnSysDate;

		[DebuggerNonUserCode]
		public DataColumn PONoColumn => columnPONo;

		[DebuggerNonUserCode]
		public DataColumn PODateColumn => columnPODate;

		[DebuggerNonUserCode]
		public DataColumn SupplierNameColumn => columnSupplierName;

		[DebuggerNonUserCode]
		public DataColumn CompIdColumn => columnCompId;

		[DebuggerNonUserCode]
		public DataColumn SupplierIdColumn => columnSupplierId;

		[DebuggerNonUserCode]
		public DataColumn OtherChargesColumn => columnOtherCharges;

		[DebuggerNonUserCode]
		public DataColumn OtherChaDescColumn => columnOtherChaDesc;

		[DebuggerNonUserCode]
		public DataColumn NarrationColumn => columnNarration;

		[DebuggerNonUserCode]
		public DataColumn DebitAmtColumn => columnDebitAmt;

		[DebuggerNonUserCode]
		public DataColumn DiscountTypeColumn => columnDiscountType;

		[DebuggerNonUserCode]
		public DataColumn DiscountColumn => columnDiscount;

		[DebuggerNonUserCode]
		public DataColumn BillNoColumn => columnBillNo;

		[DebuggerNonUserCode]
		public DataColumn BillDateColumn => columnBillDate;

		[DebuggerNonUserCode]
		public DataColumn CENVATEntryNoColumn => columnCENVATEntryNo;

		[DebuggerNonUserCode]
		public DataColumn CENVATEntryDateColumn => columnCENVATEntryDate;

		[DebuggerNonUserCode]
		public DataColumn AccHeadColumn => columnAccHead;

		[DebuggerNonUserCode]
		public DataColumn WODeptColumn => columnWODept;

		[DebuggerNonUserCode]
		public DataColumn POQtyColumn => columnPOQty;

		[DebuggerNonUserCode]
		public DataColumn PORateColumn => columnPORate;

		[DebuggerNonUserCode]
		public DataColumn DiscColumn => columnDisc;

		[DebuggerNonUserCode]
		public DataColumn AccQtyColumn => columnAccQty;

		[DebuggerNonUserCode]
		public DataColumn ExciseTermColumn => columnExciseTerm;

		[DebuggerNonUserCode]
		public DataColumn PFTermColumn => columnPFTerm;

		[DebuggerNonUserCode]
		public DataColumn VATTermColumn => columnVATTerm;

		[DebuggerNonUserCode]
		public DataColumn IsVATCSTColumn => columnIsVATCST;

		[DebuggerNonUserCode]
		public DataColumn DebitTypeColumn => columnDebitType;

		[DebuggerNonUserCode]
		public DataColumn DebitValueColumn => columnDebitValue;

		[DebuggerNonUserCode]
		public DataColumn BasicAmtColumn => columnBasicAmt;

		[DebuggerNonUserCode]
		public DataColumn PFidColumn => columnPFid;

		[DebuggerNonUserCode]
		public DataColumn ExciseIdColumn => columnExciseId;

		[DebuggerNonUserCode]
		public DataColumn VATCSTidColumn => columnVATCSTid;

		[DebuggerNonUserCode]
		public DataColumn BCDOptColumn => columnBCDOpt;

		[DebuggerNonUserCode]
		public DataColumn BCDColumn => columnBCD;

		[DebuggerNonUserCode]
		public DataColumn BCDValueColumn => columnBCDValue;

		[DebuggerNonUserCode]
		public DataColumn ValueForCVDColumn => columnValueForCVD;

		[DebuggerNonUserCode]
		public DataColumn ValueForEdCessCDColumn => columnValueForEdCessCD;

		[DebuggerNonUserCode]
		public DataColumn EdCessOnCDOptColumn => columnEdCessOnCDOpt;

		[DebuggerNonUserCode]
		public DataColumn EdCessOnCDColumn => columnEdCessOnCD;

		[DebuggerNonUserCode]
		public DataColumn EdCessOnCDValueColumn => columnEdCessOnCDValue;

		[DebuggerNonUserCode]
		public DataColumn SHEDCessOptColumn => columnSHEDCessOpt;

		[DebuggerNonUserCode]
		public DataColumn SHEDCessColumn => columnSHEDCess;

		[DebuggerNonUserCode]
		public DataColumn SHEDCessValueColumn => columnSHEDCessValue;

		[DebuggerNonUserCode]
		public DataColumn TotDutyColumn => columnTotDuty;

		[DebuggerNonUserCode]
		public DataColumn TotDutyEDSHEDColumn => columnTotDutyEDSHED;

		[DebuggerNonUserCode]
		public DataColumn InsuranceColumn => columnInsurance;

		[DebuggerNonUserCode]
		public DataColumn ValueWithDutyColumn => columnValueWithDuty;

		[DebuggerNonUserCode]
		public DataColumn SectionNoColumn => columnSectionNo;

		[DebuggerNonUserCode]
		public DataColumn TDSPerCentageColumn => columnTDSPerCentage;

		[DebuggerNonUserCode]
		public DataColumn PaymentRangeColumn => columnPaymentRange;

		[DebuggerNonUserCode]
		public DataColumn TDSCodeColumn => columnTDSCode;

		[DebuggerNonUserCode]
		public DataColumn BookedBillTotalColumn => columnBookedBillTotal;

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
		public DataTable1Row AddDataTable1Row(int Id, string GQNNo, string GSNNo, string ItemCode, string Descr, string UOM, double Amt, double PFAmt, string ExStBasicInPer, string ExStEducessInPer, string ExStShecessInPer, double ExStBasic, double ExStEducess, double ExStShecess, double CustomDuty, double VAT, double CST, double Freight, string TarrifNo, string FinYear, string PVEVNo, string SysDate, string PONo, string PODate, string SupplierName, int CompId, string SupplierId, double OtherCharges, string OtherChaDesc, string Narration, double DebitAmt, int DiscountType, double Discount, string BillNo, string BillDate, string CENVATEntryNo, string CENVATEntryDate, string AccHead, string WODept, double POQty, double PORate, double Disc, double AccQty, string ExciseTerm, string PFTerm, string VATTerm, string IsVATCST, int DebitType, double DebitValue, double BasicAmt, int PFid, int ExciseId, int VATCSTid, string BCDOpt, double BCD, double BCDValue, double ValueForCVD, double ValueForEdCessCD, string EdCessOnCDOpt, double EdCessOnCD, double EdCessOnCDValue, string SHEDCessOpt, double SHEDCess, double SHEDCessValue, double TotDuty, double TotDutyEDSHED, double Insurance, double ValueWithDuty, string SectionNo, double TDSPerCentage, double PaymentRange, int TDSCode, double BookedBillTotal)
		{
			DataTable1Row dataTable1Row = (DataTable1Row)NewRow();
			object[] itemArray = new object[73]
			{
				Id, GQNNo, GSNNo, ItemCode, Descr, UOM, Amt, PFAmt, ExStBasicInPer, ExStEducessInPer,
				ExStShecessInPer, ExStBasic, ExStEducess, ExStShecess, CustomDuty, VAT, CST, Freight, TarrifNo, FinYear,
				PVEVNo, SysDate, PONo, PODate, SupplierName, CompId, SupplierId, OtherCharges, OtherChaDesc, Narration,
				DebitAmt, DiscountType, Discount, BillNo, BillDate, CENVATEntryNo, CENVATEntryDate, AccHead, WODept, POQty,
				PORate, Disc, AccQty, ExciseTerm, PFTerm, VATTerm, IsVATCST, DebitType, DebitValue, BasicAmt,
				PFid, ExciseId, VATCSTid, BCDOpt, BCD, BCDValue, ValueForCVD, ValueForEdCessCD, EdCessOnCDOpt, EdCessOnCD,
				EdCessOnCDValue, SHEDCessOpt, SHEDCess, SHEDCessValue, TotDuty, TotDutyEDSHED, Insurance, ValueWithDuty, SectionNo, TDSPerCentage,
				PaymentRange, TDSCode, BookedBillTotal
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
			columnGQNNo = base.Columns["GQNNo"];
			columnGSNNo = base.Columns["GSNNo"];
			columnItemCode = base.Columns["ItemCode"];
			columnDescr = base.Columns["Descr"];
			columnUOM = base.Columns["UOM"];
			columnAmt = base.Columns["Amt"];
			columnPFAmt = base.Columns["PFAmt"];
			columnExStBasicInPer = base.Columns["ExStBasicInPer"];
			columnExStEducessInPer = base.Columns["ExStEducessInPer"];
			columnExStShecessInPer = base.Columns["ExStShecessInPer"];
			columnExStBasic = base.Columns["ExStBasic"];
			columnExStEducess = base.Columns["ExStEducess"];
			columnExStShecess = base.Columns["ExStShecess"];
			columnCustomDuty = base.Columns["CustomDuty"];
			columnVAT = base.Columns["VAT"];
			columnCST = base.Columns["CST"];
			columnFreight = base.Columns["Freight"];
			columnTarrifNo = base.Columns["TarrifNo"];
			columnFinYear = base.Columns["FinYear"];
			columnPVEVNo = base.Columns["PVEVNo"];
			columnSysDate = base.Columns["SysDate"];
			columnPONo = base.Columns["PONo"];
			columnPODate = base.Columns["PODate"];
			columnSupplierName = base.Columns["SupplierName"];
			columnCompId = base.Columns["CompId"];
			columnSupplierId = base.Columns["SupplierId"];
			columnOtherCharges = base.Columns["OtherCharges"];
			columnOtherChaDesc = base.Columns["OtherChaDesc"];
			columnNarration = base.Columns["Narration"];
			columnDebitAmt = base.Columns["DebitAmt"];
			columnDiscountType = base.Columns["DiscountType"];
			columnDiscount = base.Columns["Discount"];
			columnBillNo = base.Columns["BillNo"];
			columnBillDate = base.Columns["BillDate"];
			columnCENVATEntryNo = base.Columns["CENVATEntryNo"];
			columnCENVATEntryDate = base.Columns["CENVATEntryDate"];
			columnAccHead = base.Columns["AccHead"];
			columnWODept = base.Columns["WODept"];
			columnPOQty = base.Columns["POQty"];
			columnPORate = base.Columns["PORate"];
			columnDisc = base.Columns["Disc"];
			columnAccQty = base.Columns["AccQty"];
			columnExciseTerm = base.Columns["ExciseTerm"];
			columnPFTerm = base.Columns["PFTerm"];
			columnVATTerm = base.Columns["VATTerm"];
			columnIsVATCST = base.Columns["IsVATCST"];
			columnDebitType = base.Columns["DebitType"];
			columnDebitValue = base.Columns["DebitValue"];
			columnBasicAmt = base.Columns["BasicAmt"];
			columnPFid = base.Columns["PFid"];
			columnExciseId = base.Columns["ExciseId"];
			columnVATCSTid = base.Columns["VATCSTid"];
			columnBCDOpt = base.Columns["BCDOpt"];
			columnBCD = base.Columns["BCD"];
			columnBCDValue = base.Columns["BCDValue"];
			columnValueForCVD = base.Columns["ValueForCVD"];
			columnValueForEdCessCD = base.Columns["ValueForEdCessCD"];
			columnEdCessOnCDOpt = base.Columns["EdCessOnCDOpt"];
			columnEdCessOnCD = base.Columns["EdCessOnCD"];
			columnEdCessOnCDValue = base.Columns["EdCessOnCDValue"];
			columnSHEDCessOpt = base.Columns["SHEDCessOpt"];
			columnSHEDCess = base.Columns["SHEDCess"];
			columnSHEDCessValue = base.Columns["SHEDCessValue"];
			columnTotDuty = base.Columns["TotDuty"];
			columnTotDutyEDSHED = base.Columns["TotDutyEDSHED"];
			columnInsurance = base.Columns["Insurance"];
			columnValueWithDuty = base.Columns["ValueWithDuty"];
			columnSectionNo = base.Columns["SectionNo"];
			columnTDSPerCentage = base.Columns["TDSPerCentage"];
			columnPaymentRange = base.Columns["PaymentRange"];
			columnTDSCode = base.Columns["TDSCode"];
			columnBookedBillTotal = base.Columns["BookedBillTotal"];
		}

		[DebuggerNonUserCode]
		private void InitClass()
		{
			columnId = new DataColumn("Id", typeof(int), null, MappingType.Element);
			base.Columns.Add(columnId);
			columnGQNNo = new DataColumn("GQNNo", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnGQNNo);
			columnGSNNo = new DataColumn("GSNNo", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnGSNNo);
			columnItemCode = new DataColumn("ItemCode", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnItemCode);
			columnDescr = new DataColumn("Descr", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnDescr);
			columnUOM = new DataColumn("UOM", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnUOM);
			columnAmt = new DataColumn("Amt", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnAmt);
			columnPFAmt = new DataColumn("PFAmt", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnPFAmt);
			columnExStBasicInPer = new DataColumn("ExStBasicInPer", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnExStBasicInPer);
			columnExStEducessInPer = new DataColumn("ExStEducessInPer", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnExStEducessInPer);
			columnExStShecessInPer = new DataColumn("ExStShecessInPer", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnExStShecessInPer);
			columnExStBasic = new DataColumn("ExStBasic", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnExStBasic);
			columnExStEducess = new DataColumn("ExStEducess", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnExStEducess);
			columnExStShecess = new DataColumn("ExStShecess", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnExStShecess);
			columnCustomDuty = new DataColumn("CustomDuty", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnCustomDuty);
			columnVAT = new DataColumn("VAT", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnVAT);
			columnCST = new DataColumn("CST", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnCST);
			columnFreight = new DataColumn("Freight", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnFreight);
			columnTarrifNo = new DataColumn("TarrifNo", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnTarrifNo);
			columnFinYear = new DataColumn("FinYear", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnFinYear);
			columnPVEVNo = new DataColumn("PVEVNo", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnPVEVNo);
			columnSysDate = new DataColumn("SysDate", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnSysDate);
			columnPONo = new DataColumn("PONo", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnPONo);
			columnPODate = new DataColumn("PODate", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnPODate);
			columnSupplierName = new DataColumn("SupplierName", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnSupplierName);
			columnCompId = new DataColumn("CompId", typeof(int), null, MappingType.Element);
			base.Columns.Add(columnCompId);
			columnSupplierId = new DataColumn("SupplierId", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnSupplierId);
			columnOtherCharges = new DataColumn("OtherCharges", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnOtherCharges);
			columnOtherChaDesc = new DataColumn("OtherChaDesc", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnOtherChaDesc);
			columnNarration = new DataColumn("Narration", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnNarration);
			columnDebitAmt = new DataColumn("DebitAmt", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnDebitAmt);
			columnDiscountType = new DataColumn("DiscountType", typeof(int), null, MappingType.Element);
			base.Columns.Add(columnDiscountType);
			columnDiscount = new DataColumn("Discount", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnDiscount);
			columnBillNo = new DataColumn("BillNo", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnBillNo);
			columnBillDate = new DataColumn("BillDate", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnBillDate);
			columnCENVATEntryNo = new DataColumn("CENVATEntryNo", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnCENVATEntryNo);
			columnCENVATEntryDate = new DataColumn("CENVATEntryDate", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnCENVATEntryDate);
			columnAccHead = new DataColumn("AccHead", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnAccHead);
			columnWODept = new DataColumn("WODept", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnWODept);
			columnPOQty = new DataColumn("POQty", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnPOQty);
			columnPORate = new DataColumn("PORate", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnPORate);
			columnDisc = new DataColumn("Disc", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnDisc);
			columnAccQty = new DataColumn("AccQty", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnAccQty);
			columnExciseTerm = new DataColumn("ExciseTerm", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnExciseTerm);
			columnPFTerm = new DataColumn("PFTerm", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnPFTerm);
			columnVATTerm = new DataColumn("VATTerm", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnVATTerm);
			columnIsVATCST = new DataColumn("IsVATCST", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnIsVATCST);
			columnDebitType = new DataColumn("DebitType", typeof(int), null, MappingType.Element);
			base.Columns.Add(columnDebitType);
			columnDebitValue = new DataColumn("DebitValue", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnDebitValue);
			columnBasicAmt = new DataColumn("BasicAmt", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnBasicAmt);
			columnPFid = new DataColumn("PFid", typeof(int), null, MappingType.Element);
			base.Columns.Add(columnPFid);
			columnExciseId = new DataColumn("ExciseId", typeof(int), null, MappingType.Element);
			base.Columns.Add(columnExciseId);
			columnVATCSTid = new DataColumn("VATCSTid", typeof(int), null, MappingType.Element);
			base.Columns.Add(columnVATCSTid);
			columnBCDOpt = new DataColumn("BCDOpt", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnBCDOpt);
			columnBCD = new DataColumn("BCD", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnBCD);
			columnBCDValue = new DataColumn("BCDValue", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnBCDValue);
			columnValueForCVD = new DataColumn("ValueForCVD", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnValueForCVD);
			columnValueForEdCessCD = new DataColumn("ValueForEdCessCD", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnValueForEdCessCD);
			columnEdCessOnCDOpt = new DataColumn("EdCessOnCDOpt", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnEdCessOnCDOpt);
			columnEdCessOnCD = new DataColumn("EdCessOnCD", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnEdCessOnCD);
			columnEdCessOnCDValue = new DataColumn("EdCessOnCDValue", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnEdCessOnCDValue);
			columnSHEDCessOpt = new DataColumn("SHEDCessOpt", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnSHEDCessOpt);
			columnSHEDCess = new DataColumn("SHEDCess", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnSHEDCess);
			columnSHEDCessValue = new DataColumn("SHEDCessValue", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnSHEDCessValue);
			columnTotDuty = new DataColumn("TotDuty", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnTotDuty);
			columnTotDutyEDSHED = new DataColumn("TotDutyEDSHED", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnTotDutyEDSHED);
			columnInsurance = new DataColumn("Insurance", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnInsurance);
			columnValueWithDuty = new DataColumn("ValueWithDuty", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnValueWithDuty);
			columnSectionNo = new DataColumn("SectionNo", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnSectionNo);
			columnTDSPerCentage = new DataColumn("TDSPerCentage", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnTDSPerCentage);
			columnPaymentRange = new DataColumn("PaymentRange", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnPaymentRange);
			columnTDSCode = new DataColumn("TDSCode", typeof(int), null, MappingType.Element);
			base.Columns.Add(columnTDSCode);
			columnBookedBillTotal = new DataColumn("BookedBillTotal", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnBookedBillTotal);
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
			BillBooking billBooking = new BillBooking();
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
			xmlSchemaAttribute.FixedValue = billBooking.Namespace;
			xmlSchemaComplexType.Attributes.Add(xmlSchemaAttribute);
			XmlSchemaAttribute xmlSchemaAttribute2 = new XmlSchemaAttribute();
			xmlSchemaAttribute2.Name = "tableTypeName";
			xmlSchemaAttribute2.FixedValue = "DataTable1DataTable";
			xmlSchemaComplexType.Attributes.Add(xmlSchemaAttribute2);
			xmlSchemaComplexType.Particle = xmlSchemaSequence;
			XmlSchema schemaSerializable = billBooking.GetSchemaSerializable();
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
		private DataColumn columnBasic;

		private DataColumn columnPF;

		private DataColumn columnPFAmt;

		private DataColumn columnExSerTax;

		private DataColumn columnExSerAmt;

		private DataColumn columnEDU;

		private DataColumn columnSHE;

		private DataColumn columnVATCST;

		private DataColumn columnVATCSTAmt;

		private DataColumn columnFreight;

		private DataColumn columnTotal;

		[DebuggerNonUserCode]
		public DataColumn BasicColumn => columnBasic;

		[DebuggerNonUserCode]
		public DataColumn PFColumn => columnPF;

		[DebuggerNonUserCode]
		public DataColumn PFAmtColumn => columnPFAmt;

		[DebuggerNonUserCode]
		public DataColumn ExSerTaxColumn => columnExSerTax;

		[DebuggerNonUserCode]
		public DataColumn ExSerAmtColumn => columnExSerAmt;

		[DebuggerNonUserCode]
		public DataColumn EDUColumn => columnEDU;

		[DebuggerNonUserCode]
		public DataColumn SHEColumn => columnSHE;

		[DebuggerNonUserCode]
		public DataColumn VATCSTColumn => columnVATCST;

		[DebuggerNonUserCode]
		public DataColumn VATCSTAmtColumn => columnVATCSTAmt;

		[DebuggerNonUserCode]
		public DataColumn FreightColumn => columnFreight;

		[DebuggerNonUserCode]
		public DataColumn TotalColumn => columnTotal;

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
		public DataTable2Row AddDataTable2Row(double Basic, string PF, double PFAmt, string ExSerTax, double ExSerAmt, double EDU, double SHE, string VATCST, double VATCSTAmt, double Freight, double Total)
		{
			DataTable2Row dataTable2Row = (DataTable2Row)NewRow();
			object[] itemArray = new object[11]
			{
				Basic, PF, PFAmt, ExSerTax, ExSerAmt, EDU, SHE, VATCST, VATCSTAmt, Freight,
				Total
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
			columnBasic = base.Columns["Basic"];
			columnPF = base.Columns["PF"];
			columnPFAmt = base.Columns["PFAmt"];
			columnExSerTax = base.Columns["ExSerTax"];
			columnExSerAmt = base.Columns["ExSerAmt"];
			columnEDU = base.Columns["EDU"];
			columnSHE = base.Columns["SHE"];
			columnVATCST = base.Columns["VATCST"];
			columnVATCSTAmt = base.Columns["VATCSTAmt"];
			columnFreight = base.Columns["Freight"];
			columnTotal = base.Columns["Total"];
		}

		[DebuggerNonUserCode]
		private void InitClass()
		{
			columnBasic = new DataColumn("Basic", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnBasic);
			columnPF = new DataColumn("PF", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnPF);
			columnPFAmt = new DataColumn("PFAmt", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnPFAmt);
			columnExSerTax = new DataColumn("ExSerTax", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnExSerTax);
			columnExSerAmt = new DataColumn("ExSerAmt", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnExSerAmt);
			columnEDU = new DataColumn("EDU", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnEDU);
			columnSHE = new DataColumn("SHE", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnSHE);
			columnVATCST = new DataColumn("VATCST", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnVATCST);
			columnVATCSTAmt = new DataColumn("VATCSTAmt", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnVATCSTAmt);
			columnFreight = new DataColumn("Freight", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnFreight);
			columnTotal = new DataColumn("Total", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnTotal);
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
			BillBooking billBooking = new BillBooking();
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
			xmlSchemaAttribute.FixedValue = billBooking.Namespace;
			xmlSchemaComplexType.Attributes.Add(xmlSchemaAttribute);
			XmlSchemaAttribute xmlSchemaAttribute2 = new XmlSchemaAttribute();
			xmlSchemaAttribute2.Name = "tableTypeName";
			xmlSchemaAttribute2.FixedValue = "DataTable2DataTable";
			xmlSchemaComplexType.Attributes.Add(xmlSchemaAttribute2);
			xmlSchemaComplexType.Particle = xmlSchemaSequence;
			XmlSchema schemaSerializable = billBooking.GetSchemaSerializable();
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
		public string GQNNo
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.GQNNoColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'GQNNo' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.GQNNoColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string GSNNo
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.GSNNoColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'GSNNo' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.GSNNoColumn] = value;
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
		public string Descr
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.DescrColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Descr' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.DescrColumn] = value;
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
		public double Amt
		{
			get
			{
				try
				{
					return (double)base[tableDataTable1.AmtColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Amt' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.AmtColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public double PFAmt
		{
			get
			{
				try
				{
					return (double)base[tableDataTable1.PFAmtColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'PFAmt' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.PFAmtColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string ExStBasicInPer
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.ExStBasicInPerColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'ExStBasicInPer' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.ExStBasicInPerColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string ExStEducessInPer
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.ExStEducessInPerColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'ExStEducessInPer' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.ExStEducessInPerColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string ExStShecessInPer
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.ExStShecessInPerColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'ExStShecessInPer' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.ExStShecessInPerColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public double ExStBasic
		{
			get
			{
				try
				{
					return (double)base[tableDataTable1.ExStBasicColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'ExStBasic' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.ExStBasicColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public double ExStEducess
		{
			get
			{
				try
				{
					return (double)base[tableDataTable1.ExStEducessColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'ExStEducess' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.ExStEducessColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public double ExStShecess
		{
			get
			{
				try
				{
					return (double)base[tableDataTable1.ExStShecessColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'ExStShecess' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.ExStShecessColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public double CustomDuty
		{
			get
			{
				try
				{
					return (double)base[tableDataTable1.CustomDutyColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'CustomDuty' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.CustomDutyColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public double VAT
		{
			get
			{
				try
				{
					return (double)base[tableDataTable1.VATColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'VAT' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.VATColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public double CST
		{
			get
			{
				try
				{
					return (double)base[tableDataTable1.CSTColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'CST' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.CSTColumn] = value;
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
		public string FinYear
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.FinYearColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'FinYear' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.FinYearColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string PVEVNo
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.PVEVNoColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'PVEVNo' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.PVEVNoColumn] = value;
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
		public double OtherCharges
		{
			get
			{
				try
				{
					return (double)base[tableDataTable1.OtherChargesColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'OtherCharges' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.OtherChargesColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string OtherChaDesc
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.OtherChaDescColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'OtherChaDesc' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.OtherChaDescColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string Narration
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.NarrationColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Narration' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.NarrationColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public double DebitAmt
		{
			get
			{
				try
				{
					return (double)base[tableDataTable1.DebitAmtColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'DebitAmt' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.DebitAmtColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public int DiscountType
		{
			get
			{
				try
				{
					return (int)base[tableDataTable1.DiscountTypeColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'DiscountType' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.DiscountTypeColumn] = value;
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
		public string BillDate
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.BillDateColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'BillDate' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.BillDateColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string CENVATEntryNo
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.CENVATEntryNoColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'CENVATEntryNo' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.CENVATEntryNoColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string CENVATEntryDate
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.CENVATEntryDateColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'CENVATEntryDate' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.CENVATEntryDateColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string AccHead
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.AccHeadColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'AccHead' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.AccHeadColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string WODept
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.WODeptColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'WODept' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.WODeptColumn] = value;
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
		public double PORate
		{
			get
			{
				try
				{
					return (double)base[tableDataTable1.PORateColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'PORate' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.PORateColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public double Disc
		{
			get
			{
				try
				{
					return (double)base[tableDataTable1.DiscColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Disc' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.DiscColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public double AccQty
		{
			get
			{
				try
				{
					return (double)base[tableDataTable1.AccQtyColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'AccQty' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.AccQtyColumn] = value;
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
		public string PFTerm
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.PFTermColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'PFTerm' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.PFTermColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string VATTerm
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.VATTermColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'VATTerm' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.VATTermColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string IsVATCST
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.IsVATCSTColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'IsVATCST' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.IsVATCSTColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public int DebitType
		{
			get
			{
				try
				{
					return (int)base[tableDataTable1.DebitTypeColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'DebitType' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.DebitTypeColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public double DebitValue
		{
			get
			{
				try
				{
					return (double)base[tableDataTable1.DebitValueColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'DebitValue' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.DebitValueColumn] = value;
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
		public int PFid
		{
			get
			{
				try
				{
					return (int)base[tableDataTable1.PFidColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'PFid' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.PFidColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public int ExciseId
		{
			get
			{
				try
				{
					return (int)base[tableDataTable1.ExciseIdColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'ExciseId' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.ExciseIdColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public int VATCSTid
		{
			get
			{
				try
				{
					return (int)base[tableDataTable1.VATCSTidColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'VATCSTid' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.VATCSTidColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string BCDOpt
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.BCDOptColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'BCDOpt' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.BCDOptColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public double BCD
		{
			get
			{
				try
				{
					return (double)base[tableDataTable1.BCDColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'BCD' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.BCDColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public double BCDValue
		{
			get
			{
				try
				{
					return (double)base[tableDataTable1.BCDValueColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'BCDValue' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.BCDValueColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public double ValueForCVD
		{
			get
			{
				try
				{
					return (double)base[tableDataTable1.ValueForCVDColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'ValueForCVD' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.ValueForCVDColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public double ValueForEdCessCD
		{
			get
			{
				try
				{
					return (double)base[tableDataTable1.ValueForEdCessCDColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'ValueForEdCessCD' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.ValueForEdCessCDColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string EdCessOnCDOpt
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.EdCessOnCDOptColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'EdCessOnCDOpt' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.EdCessOnCDOptColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public double EdCessOnCD
		{
			get
			{
				try
				{
					return (double)base[tableDataTable1.EdCessOnCDColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'EdCessOnCD' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.EdCessOnCDColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public double EdCessOnCDValue
		{
			get
			{
				try
				{
					return (double)base[tableDataTable1.EdCessOnCDValueColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'EdCessOnCDValue' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.EdCessOnCDValueColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string SHEDCessOpt
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.SHEDCessOptColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'SHEDCessOpt' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.SHEDCessOptColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public double SHEDCess
		{
			get
			{
				try
				{
					return (double)base[tableDataTable1.SHEDCessColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'SHEDCess' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.SHEDCessColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public double SHEDCessValue
		{
			get
			{
				try
				{
					return (double)base[tableDataTable1.SHEDCessValueColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'SHEDCessValue' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.SHEDCessValueColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public double TotDuty
		{
			get
			{
				try
				{
					return (double)base[tableDataTable1.TotDutyColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'TotDuty' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.TotDutyColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public double TotDutyEDSHED
		{
			get
			{
				try
				{
					return (double)base[tableDataTable1.TotDutyEDSHEDColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'TotDutyEDSHED' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.TotDutyEDSHEDColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public double Insurance
		{
			get
			{
				try
				{
					return (double)base[tableDataTable1.InsuranceColumn];
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
		public double ValueWithDuty
		{
			get
			{
				try
				{
					return (double)base[tableDataTable1.ValueWithDutyColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'ValueWithDuty' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.ValueWithDutyColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string SectionNo
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.SectionNoColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'SectionNo' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.SectionNoColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public double TDSPerCentage
		{
			get
			{
				try
				{
					return (double)base[tableDataTable1.TDSPerCentageColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'TDSPerCentage' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.TDSPerCentageColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public double PaymentRange
		{
			get
			{
				try
				{
					return (double)base[tableDataTable1.PaymentRangeColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'PaymentRange' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.PaymentRangeColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public int TDSCode
		{
			get
			{
				try
				{
					return (int)base[tableDataTable1.TDSCodeColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'TDSCode' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.TDSCodeColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public double BookedBillTotal
		{
			get
			{
				try
				{
					return (double)base[tableDataTable1.BookedBillTotalColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'BookedBillTotal' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.BookedBillTotalColumn] = value;
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
		public bool IsGQNNoNull()
		{
			return IsNull(tableDataTable1.GQNNoColumn);
		}

		[DebuggerNonUserCode]
		public void SetGQNNoNull()
		{
			base[tableDataTable1.GQNNoColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsGSNNoNull()
		{
			return IsNull(tableDataTable1.GSNNoColumn);
		}

		[DebuggerNonUserCode]
		public void SetGSNNoNull()
		{
			base[tableDataTable1.GSNNoColumn] = Convert.DBNull;
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
		public bool IsDescrNull()
		{
			return IsNull(tableDataTable1.DescrColumn);
		}

		[DebuggerNonUserCode]
		public void SetDescrNull()
		{
			base[tableDataTable1.DescrColumn] = Convert.DBNull;
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
		public bool IsAmtNull()
		{
			return IsNull(tableDataTable1.AmtColumn);
		}

		[DebuggerNonUserCode]
		public void SetAmtNull()
		{
			base[tableDataTable1.AmtColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsPFAmtNull()
		{
			return IsNull(tableDataTable1.PFAmtColumn);
		}

		[DebuggerNonUserCode]
		public void SetPFAmtNull()
		{
			base[tableDataTable1.PFAmtColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsExStBasicInPerNull()
		{
			return IsNull(tableDataTable1.ExStBasicInPerColumn);
		}

		[DebuggerNonUserCode]
		public void SetExStBasicInPerNull()
		{
			base[tableDataTable1.ExStBasicInPerColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsExStEducessInPerNull()
		{
			return IsNull(tableDataTable1.ExStEducessInPerColumn);
		}

		[DebuggerNonUserCode]
		public void SetExStEducessInPerNull()
		{
			base[tableDataTable1.ExStEducessInPerColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsExStShecessInPerNull()
		{
			return IsNull(tableDataTable1.ExStShecessInPerColumn);
		}

		[DebuggerNonUserCode]
		public void SetExStShecessInPerNull()
		{
			base[tableDataTable1.ExStShecessInPerColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsExStBasicNull()
		{
			return IsNull(tableDataTable1.ExStBasicColumn);
		}

		[DebuggerNonUserCode]
		public void SetExStBasicNull()
		{
			base[tableDataTable1.ExStBasicColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsExStEducessNull()
		{
			return IsNull(tableDataTable1.ExStEducessColumn);
		}

		[DebuggerNonUserCode]
		public void SetExStEducessNull()
		{
			base[tableDataTable1.ExStEducessColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsExStShecessNull()
		{
			return IsNull(tableDataTable1.ExStShecessColumn);
		}

		[DebuggerNonUserCode]
		public void SetExStShecessNull()
		{
			base[tableDataTable1.ExStShecessColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsCustomDutyNull()
		{
			return IsNull(tableDataTable1.CustomDutyColumn);
		}

		[DebuggerNonUserCode]
		public void SetCustomDutyNull()
		{
			base[tableDataTable1.CustomDutyColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsVATNull()
		{
			return IsNull(tableDataTable1.VATColumn);
		}

		[DebuggerNonUserCode]
		public void SetVATNull()
		{
			base[tableDataTable1.VATColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsCSTNull()
		{
			return IsNull(tableDataTable1.CSTColumn);
		}

		[DebuggerNonUserCode]
		public void SetCSTNull()
		{
			base[tableDataTable1.CSTColumn] = Convert.DBNull;
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
		public bool IsFinYearNull()
		{
			return IsNull(tableDataTable1.FinYearColumn);
		}

		[DebuggerNonUserCode]
		public void SetFinYearNull()
		{
			base[tableDataTable1.FinYearColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsPVEVNoNull()
		{
			return IsNull(tableDataTable1.PVEVNoColumn);
		}

		[DebuggerNonUserCode]
		public void SetPVEVNoNull()
		{
			base[tableDataTable1.PVEVNoColumn] = Convert.DBNull;
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
		public bool IsOtherChargesNull()
		{
			return IsNull(tableDataTable1.OtherChargesColumn);
		}

		[DebuggerNonUserCode]
		public void SetOtherChargesNull()
		{
			base[tableDataTable1.OtherChargesColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsOtherChaDescNull()
		{
			return IsNull(tableDataTable1.OtherChaDescColumn);
		}

		[DebuggerNonUserCode]
		public void SetOtherChaDescNull()
		{
			base[tableDataTable1.OtherChaDescColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsNarrationNull()
		{
			return IsNull(tableDataTable1.NarrationColumn);
		}

		[DebuggerNonUserCode]
		public void SetNarrationNull()
		{
			base[tableDataTable1.NarrationColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsDebitAmtNull()
		{
			return IsNull(tableDataTable1.DebitAmtColumn);
		}

		[DebuggerNonUserCode]
		public void SetDebitAmtNull()
		{
			base[tableDataTable1.DebitAmtColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsDiscountTypeNull()
		{
			return IsNull(tableDataTable1.DiscountTypeColumn);
		}

		[DebuggerNonUserCode]
		public void SetDiscountTypeNull()
		{
			base[tableDataTable1.DiscountTypeColumn] = Convert.DBNull;
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
		public bool IsBillDateNull()
		{
			return IsNull(tableDataTable1.BillDateColumn);
		}

		[DebuggerNonUserCode]
		public void SetBillDateNull()
		{
			base[tableDataTable1.BillDateColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsCENVATEntryNoNull()
		{
			return IsNull(tableDataTable1.CENVATEntryNoColumn);
		}

		[DebuggerNonUserCode]
		public void SetCENVATEntryNoNull()
		{
			base[tableDataTable1.CENVATEntryNoColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsCENVATEntryDateNull()
		{
			return IsNull(tableDataTable1.CENVATEntryDateColumn);
		}

		[DebuggerNonUserCode]
		public void SetCENVATEntryDateNull()
		{
			base[tableDataTable1.CENVATEntryDateColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsAccHeadNull()
		{
			return IsNull(tableDataTable1.AccHeadColumn);
		}

		[DebuggerNonUserCode]
		public void SetAccHeadNull()
		{
			base[tableDataTable1.AccHeadColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsWODeptNull()
		{
			return IsNull(tableDataTable1.WODeptColumn);
		}

		[DebuggerNonUserCode]
		public void SetWODeptNull()
		{
			base[tableDataTable1.WODeptColumn] = Convert.DBNull;
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
		public bool IsPORateNull()
		{
			return IsNull(tableDataTable1.PORateColumn);
		}

		[DebuggerNonUserCode]
		public void SetPORateNull()
		{
			base[tableDataTable1.PORateColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsDiscNull()
		{
			return IsNull(tableDataTable1.DiscColumn);
		}

		[DebuggerNonUserCode]
		public void SetDiscNull()
		{
			base[tableDataTable1.DiscColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsAccQtyNull()
		{
			return IsNull(tableDataTable1.AccQtyColumn);
		}

		[DebuggerNonUserCode]
		public void SetAccQtyNull()
		{
			base[tableDataTable1.AccQtyColumn] = Convert.DBNull;
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
		public bool IsPFTermNull()
		{
			return IsNull(tableDataTable1.PFTermColumn);
		}

		[DebuggerNonUserCode]
		public void SetPFTermNull()
		{
			base[tableDataTable1.PFTermColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsVATTermNull()
		{
			return IsNull(tableDataTable1.VATTermColumn);
		}

		[DebuggerNonUserCode]
		public void SetVATTermNull()
		{
			base[tableDataTable1.VATTermColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsIsVATCSTNull()
		{
			return IsNull(tableDataTable1.IsVATCSTColumn);
		}

		[DebuggerNonUserCode]
		public void SetIsVATCSTNull()
		{
			base[tableDataTable1.IsVATCSTColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsDebitTypeNull()
		{
			return IsNull(tableDataTable1.DebitTypeColumn);
		}

		[DebuggerNonUserCode]
		public void SetDebitTypeNull()
		{
			base[tableDataTable1.DebitTypeColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsDebitValueNull()
		{
			return IsNull(tableDataTable1.DebitValueColumn);
		}

		[DebuggerNonUserCode]
		public void SetDebitValueNull()
		{
			base[tableDataTable1.DebitValueColumn] = Convert.DBNull;
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
		public bool IsPFidNull()
		{
			return IsNull(tableDataTable1.PFidColumn);
		}

		[DebuggerNonUserCode]
		public void SetPFidNull()
		{
			base[tableDataTable1.PFidColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsExciseIdNull()
		{
			return IsNull(tableDataTable1.ExciseIdColumn);
		}

		[DebuggerNonUserCode]
		public void SetExciseIdNull()
		{
			base[tableDataTable1.ExciseIdColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsVATCSTidNull()
		{
			return IsNull(tableDataTable1.VATCSTidColumn);
		}

		[DebuggerNonUserCode]
		public void SetVATCSTidNull()
		{
			base[tableDataTable1.VATCSTidColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsBCDOptNull()
		{
			return IsNull(tableDataTable1.BCDOptColumn);
		}

		[DebuggerNonUserCode]
		public void SetBCDOptNull()
		{
			base[tableDataTable1.BCDOptColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsBCDNull()
		{
			return IsNull(tableDataTable1.BCDColumn);
		}

		[DebuggerNonUserCode]
		public void SetBCDNull()
		{
			base[tableDataTable1.BCDColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsBCDValueNull()
		{
			return IsNull(tableDataTable1.BCDValueColumn);
		}

		[DebuggerNonUserCode]
		public void SetBCDValueNull()
		{
			base[tableDataTable1.BCDValueColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsValueForCVDNull()
		{
			return IsNull(tableDataTable1.ValueForCVDColumn);
		}

		[DebuggerNonUserCode]
		public void SetValueForCVDNull()
		{
			base[tableDataTable1.ValueForCVDColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsValueForEdCessCDNull()
		{
			return IsNull(tableDataTable1.ValueForEdCessCDColumn);
		}

		[DebuggerNonUserCode]
		public void SetValueForEdCessCDNull()
		{
			base[tableDataTable1.ValueForEdCessCDColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsEdCessOnCDOptNull()
		{
			return IsNull(tableDataTable1.EdCessOnCDOptColumn);
		}

		[DebuggerNonUserCode]
		public void SetEdCessOnCDOptNull()
		{
			base[tableDataTable1.EdCessOnCDOptColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsEdCessOnCDNull()
		{
			return IsNull(tableDataTable1.EdCessOnCDColumn);
		}

		[DebuggerNonUserCode]
		public void SetEdCessOnCDNull()
		{
			base[tableDataTable1.EdCessOnCDColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsEdCessOnCDValueNull()
		{
			return IsNull(tableDataTable1.EdCessOnCDValueColumn);
		}

		[DebuggerNonUserCode]
		public void SetEdCessOnCDValueNull()
		{
			base[tableDataTable1.EdCessOnCDValueColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsSHEDCessOptNull()
		{
			return IsNull(tableDataTable1.SHEDCessOptColumn);
		}

		[DebuggerNonUserCode]
		public void SetSHEDCessOptNull()
		{
			base[tableDataTable1.SHEDCessOptColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsSHEDCessNull()
		{
			return IsNull(tableDataTable1.SHEDCessColumn);
		}

		[DebuggerNonUserCode]
		public void SetSHEDCessNull()
		{
			base[tableDataTable1.SHEDCessColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsSHEDCessValueNull()
		{
			return IsNull(tableDataTable1.SHEDCessValueColumn);
		}

		[DebuggerNonUserCode]
		public void SetSHEDCessValueNull()
		{
			base[tableDataTable1.SHEDCessValueColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsTotDutyNull()
		{
			return IsNull(tableDataTable1.TotDutyColumn);
		}

		[DebuggerNonUserCode]
		public void SetTotDutyNull()
		{
			base[tableDataTable1.TotDutyColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsTotDutyEDSHEDNull()
		{
			return IsNull(tableDataTable1.TotDutyEDSHEDColumn);
		}

		[DebuggerNonUserCode]
		public void SetTotDutyEDSHEDNull()
		{
			base[tableDataTable1.TotDutyEDSHEDColumn] = Convert.DBNull;
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
		public bool IsValueWithDutyNull()
		{
			return IsNull(tableDataTable1.ValueWithDutyColumn);
		}

		[DebuggerNonUserCode]
		public void SetValueWithDutyNull()
		{
			base[tableDataTable1.ValueWithDutyColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsSectionNoNull()
		{
			return IsNull(tableDataTable1.SectionNoColumn);
		}

		[DebuggerNonUserCode]
		public void SetSectionNoNull()
		{
			base[tableDataTable1.SectionNoColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsTDSPerCentageNull()
		{
			return IsNull(tableDataTable1.TDSPerCentageColumn);
		}

		[DebuggerNonUserCode]
		public void SetTDSPerCentageNull()
		{
			base[tableDataTable1.TDSPerCentageColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsPaymentRangeNull()
		{
			return IsNull(tableDataTable1.PaymentRangeColumn);
		}

		[DebuggerNonUserCode]
		public void SetPaymentRangeNull()
		{
			base[tableDataTable1.PaymentRangeColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsTDSCodeNull()
		{
			return IsNull(tableDataTable1.TDSCodeColumn);
		}

		[DebuggerNonUserCode]
		public void SetTDSCodeNull()
		{
			base[tableDataTable1.TDSCodeColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsBookedBillTotalNull()
		{
			return IsNull(tableDataTable1.BookedBillTotalColumn);
		}

		[DebuggerNonUserCode]
		public void SetBookedBillTotalNull()
		{
			base[tableDataTable1.BookedBillTotalColumn] = Convert.DBNull;
		}
	}

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
	public class DataTable2Row : DataRow
	{
		private DataTable2DataTable tableDataTable2;

		[DebuggerNonUserCode]
		public double Basic
		{
			get
			{
				try
				{
					return (double)base[tableDataTable2.BasicColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Basic' in table 'DataTable2' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable2.BasicColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string PF
		{
			get
			{
				try
				{
					return (string)base[tableDataTable2.PFColumn];
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
		public double PFAmt
		{
			get
			{
				try
				{
					return (double)base[tableDataTable2.PFAmtColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'PFAmt' in table 'DataTable2' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable2.PFAmtColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string ExSerTax
		{
			get
			{
				try
				{
					return (string)base[tableDataTable2.ExSerTaxColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'ExSerTax' in table 'DataTable2' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable2.ExSerTaxColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public double ExSerAmt
		{
			get
			{
				try
				{
					return (double)base[tableDataTable2.ExSerAmtColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'ExSerAmt' in table 'DataTable2' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable2.ExSerAmtColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public double EDU
		{
			get
			{
				try
				{
					return (double)base[tableDataTable2.EDUColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'EDU' in table 'DataTable2' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable2.EDUColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public double SHE
		{
			get
			{
				try
				{
					return (double)base[tableDataTable2.SHEColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'SHE' in table 'DataTable2' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable2.SHEColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string VATCST
		{
			get
			{
				try
				{
					return (string)base[tableDataTable2.VATCSTColumn];
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
		internal DataTable2Row(DataRowBuilder rb)
			: base(rb)
		{
			tableDataTable2 = (DataTable2DataTable)base.Table;
		}

		[DebuggerNonUserCode]
		public bool IsBasicNull()
		{
			return IsNull(tableDataTable2.BasicColumn);
		}

		[DebuggerNonUserCode]
		public void SetBasicNull()
		{
			base[tableDataTable2.BasicColumn] = Convert.DBNull;
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
		public bool IsPFAmtNull()
		{
			return IsNull(tableDataTable2.PFAmtColumn);
		}

		[DebuggerNonUserCode]
		public void SetPFAmtNull()
		{
			base[tableDataTable2.PFAmtColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsExSerTaxNull()
		{
			return IsNull(tableDataTable2.ExSerTaxColumn);
		}

		[DebuggerNonUserCode]
		public void SetExSerTaxNull()
		{
			base[tableDataTable2.ExSerTaxColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsExSerAmtNull()
		{
			return IsNull(tableDataTable2.ExSerAmtColumn);
		}

		[DebuggerNonUserCode]
		public void SetExSerAmtNull()
		{
			base[tableDataTable2.ExSerAmtColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsEDUNull()
		{
			return IsNull(tableDataTable2.EDUColumn);
		}

		[DebuggerNonUserCode]
		public void SetEDUNull()
		{
			base[tableDataTable2.EDUColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsSHENull()
		{
			return IsNull(tableDataTable2.SHEColumn);
		}

		[DebuggerNonUserCode]
		public void SetSHENull()
		{
			base[tableDataTable2.SHEColumn] = Convert.DBNull;
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
		public bool IsTotalNull()
		{
			return IsNull(tableDataTable2.TotalColumn);
		}

		[DebuggerNonUserCode]
		public void SetTotalNull()
		{
			base[tableDataTable2.TotalColumn] = Convert.DBNull;
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

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	[DebuggerNonUserCode]
	public DataTable1DataTable DataTable1 => tableDataTable1;

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	[Browsable(false)]
	[DebuggerNonUserCode]
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

	[DebuggerNonUserCode]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[DebuggerNonUserCode]
	public new DataRelationCollection Relations => base.Relations;

	[DebuggerNonUserCode]
	public BillBooking()
	{
		BeginInit();
		InitClass();
		CollectionChangeEventHandler value = SchemaChanged;
		base.Tables.CollectionChanged += value;
		base.Relations.CollectionChanged += value;
		EndInit();
	}

	[DebuggerNonUserCode]
	protected BillBooking(SerializationInfo info, StreamingContext context)
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
		BillBooking billBooking = (BillBooking)base.Clone();
		billBooking.InitVars();
		billBooking.SchemaSerializationMode = SchemaSerializationMode;
		return billBooking;
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
		base.DataSetName = "BillBooking";
		base.Prefix = "";
		base.Namespace = "http://tempuri.org/BillBooking.xsd";
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
		BillBooking billBooking = new BillBooking();
		XmlSchemaComplexType xmlSchemaComplexType = new XmlSchemaComplexType();
		XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
		XmlSchemaAny xmlSchemaAny = new XmlSchemaAny();
		xmlSchemaAny.Namespace = billBooking.Namespace;
		xmlSchemaSequence.Items.Add(xmlSchemaAny);
		xmlSchemaComplexType.Particle = xmlSchemaSequence;
		XmlSchema schemaSerializable = billBooking.GetSchemaSerializable();
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
