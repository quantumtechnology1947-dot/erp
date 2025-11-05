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
[XmlRoot("SalesInvoice")]
[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
[DesignerCategory("code")]
[ToolboxItem(true)]
[XmlSchemaProvider("GetTypedDataSetSchema")]
public class SalesInvoice : DataSet
{
	public delegate void DataTable1RowChangeEventHandler(object sender, DataTable1RowChangeEvent e);

	[Serializable]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
	[XmlSchemaProvider("GetTypedTableSchema")]
	public class DataTable1DataTable : TypedTableBase<DataTable1Row>
	{
		private DataColumn columnId;

		private DataColumn columnSysDate;

		private DataColumn columnCompId;

		private DataColumn columnInvoiceNo;

		private DataColumn columnPONo;

		private DataColumn columnWONo;

		private DataColumn columnInvoiceMode;

		private DataColumn columnDateOfIssueInvoice;

		private DataColumn columnTimeOfIssueInvoice;

		private DataColumn columnTimeOfRemoval;

		private DataColumn columnNatureOfRemoval;

		private DataColumn columnCommodity;

		private DataColumn columnTariffHeading;

		private DataColumn columnModeOfTransport;

		private DataColumn columnRRGCNo;

		private DataColumn columnVehiRegNo;

		private DataColumn columnDutyRate;

		private DataColumn columnCustomerCode;

		private DataColumn columnCustomerCategory;

		private DataColumn columnBuyer_name;

		private DataColumn columnBuyer_cotper;

		private DataColumn columnBuyer_ph;

		private DataColumn columnBuyer_email;

		private DataColumn columnBuyer_ecc;

		private DataColumn columnBuyer_tin;

		private DataColumn columnBuyer_mob;

		private DataColumn columnBuyer_fax;

		private DataColumn columnBuyer_vat;

		private DataColumn columnCong_name;

		private DataColumn columnCong_cotper;

		private DataColumn columnCong_ph;

		private DataColumn columnCong_email;

		private DataColumn columnCong_ecc;

		private DataColumn columnCong_tin;

		private DataColumn columnCong_mob;

		private DataColumn columnCong_fax;

		private DataColumn columnCong_vat;

		private DataColumn columnAddType;

		private DataColumn columnAddAmt;

		private DataColumn columnDeductionType;

		private DataColumn columnDeduction;

		private DataColumn columnPFType;

		private DataColumn columnPF;

		private DataColumn columnCENVAT;

		private DataColumn columnSED;

		private DataColumn columnAED;

		private DataColumn columnVAT;

		private DataColumn columnSelectedCST;

		private DataColumn columnCST;

		private DataColumn columnFreightType;

		private DataColumn columnFreight;

		private DataColumn columnInsuranceType;

		private DataColumn columnInsurance;

		private DataColumn columnPODate;

		private DataColumn columnAEDType;

		private DataColumn columnSEDType;

		private DataColumn columnDateOfRemoval;

		private DataColumn columnPOId;

		private DataColumn columnOtherAmt;

		[DebuggerNonUserCode]
		public DataColumn IdColumn => columnId;

		[DebuggerNonUserCode]
		public DataColumn SysDateColumn => columnSysDate;

		[DebuggerNonUserCode]
		public DataColumn CompIdColumn => columnCompId;

		[DebuggerNonUserCode]
		public DataColumn InvoiceNoColumn => columnInvoiceNo;

		[DebuggerNonUserCode]
		public DataColumn PONoColumn => columnPONo;

		[DebuggerNonUserCode]
		public DataColumn WONoColumn => columnWONo;

		[DebuggerNonUserCode]
		public DataColumn InvoiceModeColumn => columnInvoiceMode;

		[DebuggerNonUserCode]
		public DataColumn DateOfIssueInvoiceColumn => columnDateOfIssueInvoice;

		[DebuggerNonUserCode]
		public DataColumn TimeOfIssueInvoiceColumn => columnTimeOfIssueInvoice;

		[DebuggerNonUserCode]
		public DataColumn TimeOfRemovalColumn => columnTimeOfRemoval;

		[DebuggerNonUserCode]
		public DataColumn NatureOfRemovalColumn => columnNatureOfRemoval;

		[DebuggerNonUserCode]
		public DataColumn CommodityColumn => columnCommodity;

		[DebuggerNonUserCode]
		public DataColumn TariffHeadingColumn => columnTariffHeading;

		[DebuggerNonUserCode]
		public DataColumn ModeOfTransportColumn => columnModeOfTransport;

		[DebuggerNonUserCode]
		public DataColumn RRGCNoColumn => columnRRGCNo;

		[DebuggerNonUserCode]
		public DataColumn VehiRegNoColumn => columnVehiRegNo;

		[DebuggerNonUserCode]
		public DataColumn DutyRateColumn => columnDutyRate;

		[DebuggerNonUserCode]
		public DataColumn CustomerCodeColumn => columnCustomerCode;

		[DebuggerNonUserCode]
		public DataColumn CustomerCategoryColumn => columnCustomerCategory;

		[DebuggerNonUserCode]
		public DataColumn Buyer_nameColumn => columnBuyer_name;

		[DebuggerNonUserCode]
		public DataColumn Buyer_cotperColumn => columnBuyer_cotper;

		[DebuggerNonUserCode]
		public DataColumn Buyer_phColumn => columnBuyer_ph;

		[DebuggerNonUserCode]
		public DataColumn Buyer_emailColumn => columnBuyer_email;

		[DebuggerNonUserCode]
		public DataColumn Buyer_eccColumn => columnBuyer_ecc;

		[DebuggerNonUserCode]
		public DataColumn Buyer_tinColumn => columnBuyer_tin;

		[DebuggerNonUserCode]
		public DataColumn Buyer_mobColumn => columnBuyer_mob;

		[DebuggerNonUserCode]
		public DataColumn Buyer_faxColumn => columnBuyer_fax;

		[DebuggerNonUserCode]
		public DataColumn Buyer_vatColumn => columnBuyer_vat;

		[DebuggerNonUserCode]
		public DataColumn Cong_nameColumn => columnCong_name;

		[DebuggerNonUserCode]
		public DataColumn Cong_cotperColumn => columnCong_cotper;

		[DebuggerNonUserCode]
		public DataColumn Cong_phColumn => columnCong_ph;

		[DebuggerNonUserCode]
		public DataColumn Cong_emailColumn => columnCong_email;

		[DebuggerNonUserCode]
		public DataColumn Cong_eccColumn => columnCong_ecc;

		[DebuggerNonUserCode]
		public DataColumn Cong_tinColumn => columnCong_tin;

		[DebuggerNonUserCode]
		public DataColumn Cong_mobColumn => columnCong_mob;

		[DebuggerNonUserCode]
		public DataColumn Cong_faxColumn => columnCong_fax;

		[DebuggerNonUserCode]
		public DataColumn Cong_vatColumn => columnCong_vat;

		[DebuggerNonUserCode]
		public DataColumn AddTypeColumn => columnAddType;

		[DebuggerNonUserCode]
		public DataColumn AddAmtColumn => columnAddAmt;

		[DebuggerNonUserCode]
		public DataColumn DeductionTypeColumn => columnDeductionType;

		[DebuggerNonUserCode]
		public DataColumn DeductionColumn => columnDeduction;

		[DebuggerNonUserCode]
		public DataColumn PFTypeColumn => columnPFType;

		[DebuggerNonUserCode]
		public DataColumn PFColumn => columnPF;

		[DebuggerNonUserCode]
		public DataColumn CENVATColumn => columnCENVAT;

		[DebuggerNonUserCode]
		public DataColumn SEDColumn => columnSED;

		[DebuggerNonUserCode]
		public DataColumn AEDColumn => columnAED;

		[DebuggerNonUserCode]
		public DataColumn VATColumn => columnVAT;

		[DebuggerNonUserCode]
		public DataColumn SelectedCSTColumn => columnSelectedCST;

		[DebuggerNonUserCode]
		public DataColumn CSTColumn => columnCST;

		[DebuggerNonUserCode]
		public DataColumn FreightTypeColumn => columnFreightType;

		[DebuggerNonUserCode]
		public DataColumn FreightColumn => columnFreight;

		[DebuggerNonUserCode]
		public DataColumn InsuranceTypeColumn => columnInsuranceType;

		[DebuggerNonUserCode]
		public DataColumn InsuranceColumn => columnInsurance;

		[DebuggerNonUserCode]
		public DataColumn PODateColumn => columnPODate;

		[DebuggerNonUserCode]
		public DataColumn AEDTypeColumn => columnAEDType;

		[DebuggerNonUserCode]
		public DataColumn SEDTypeColumn => columnSEDType;

		[DebuggerNonUserCode]
		public DataColumn DateOfRemovalColumn => columnDateOfRemoval;

		[DebuggerNonUserCode]
		public DataColumn POIdColumn => columnPOId;

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
		public DataTable1Row AddDataTable1Row(int Id, string SysDate, int CompId, string InvoiceNo, string PONo, string WONo, string InvoiceMode, string DateOfIssueInvoice, string TimeOfIssueInvoice, string TimeOfRemoval, string NatureOfRemoval, string Commodity, string TariffHeading, string ModeOfTransport, string RRGCNo, string VehiRegNo, string DutyRate, string CustomerCode, string CustomerCategory, string Buyer_name, string Buyer_cotper, string Buyer_ph, string Buyer_email, string Buyer_ecc, string Buyer_tin, string Buyer_mob, string Buyer_fax, string Buyer_vat, string Cong_name, string Cong_cotper, string Cong_ph, string Cong_email, string Cong_ecc, string Cong_tin, string Cong_mob, string Cong_fax, string Cong_vat, int AddType, double AddAmt, int DeductionType, double Deduction, int PFType, double PF, int CENVAT, double SED, double AED, int VAT, int SelectedCST, double CST, int FreightType, double Freight, int InsuranceType, double Insurance, string PODate, int AEDType, int SEDType, string DateOfRemoval, int POId, double OtherAmt)
		{
			DataTable1Row dataTable1Row = (DataTable1Row)NewRow();
			object[] itemArray = new object[59]
			{
				Id, SysDate, CompId, InvoiceNo, PONo, WONo, InvoiceMode, DateOfIssueInvoice, TimeOfIssueInvoice, TimeOfRemoval,
				NatureOfRemoval, Commodity, TariffHeading, ModeOfTransport, RRGCNo, VehiRegNo, DutyRate, CustomerCode, CustomerCategory, Buyer_name,
				Buyer_cotper, Buyer_ph, Buyer_email, Buyer_ecc, Buyer_tin, Buyer_mob, Buyer_fax, Buyer_vat, Cong_name, Cong_cotper,
				Cong_ph, Cong_email, Cong_ecc, Cong_tin, Cong_mob, Cong_fax, Cong_vat, AddType, AddAmt, DeductionType,
				Deduction, PFType, PF, CENVAT, SED, AED, VAT, SelectedCST, CST, FreightType,
				Freight, InsuranceType, Insurance, PODate, AEDType, SEDType, DateOfRemoval, POId, OtherAmt
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
			columnPONo = base.Columns["PONo"];
			columnWONo = base.Columns["WONo"];
			columnInvoiceMode = base.Columns["InvoiceMode"];
			columnDateOfIssueInvoice = base.Columns["DateOfIssueInvoice"];
			columnTimeOfIssueInvoice = base.Columns["TimeOfIssueInvoice"];
			columnTimeOfRemoval = base.Columns["TimeOfRemoval"];
			columnNatureOfRemoval = base.Columns["NatureOfRemoval"];
			columnCommodity = base.Columns["Commodity"];
			columnTariffHeading = base.Columns["TariffHeading"];
			columnModeOfTransport = base.Columns["ModeOfTransport"];
			columnRRGCNo = base.Columns["RRGCNo"];
			columnVehiRegNo = base.Columns["VehiRegNo"];
			columnDutyRate = base.Columns["DutyRate"];
			columnCustomerCode = base.Columns["CustomerCode"];
			columnCustomerCategory = base.Columns["CustomerCategory"];
			columnBuyer_name = base.Columns["Buyer_name"];
			columnBuyer_cotper = base.Columns["Buyer_cotper"];
			columnBuyer_ph = base.Columns["Buyer_ph"];
			columnBuyer_email = base.Columns["Buyer_email"];
			columnBuyer_ecc = base.Columns["Buyer_ecc"];
			columnBuyer_tin = base.Columns["Buyer_tin"];
			columnBuyer_mob = base.Columns["Buyer_mob"];
			columnBuyer_fax = base.Columns["Buyer_fax"];
			columnBuyer_vat = base.Columns["Buyer_vat"];
			columnCong_name = base.Columns["Cong_name"];
			columnCong_cotper = base.Columns["Cong_cotper"];
			columnCong_ph = base.Columns["Cong_ph"];
			columnCong_email = base.Columns["Cong_email"];
			columnCong_ecc = base.Columns["Cong_ecc"];
			columnCong_tin = base.Columns["Cong_tin"];
			columnCong_mob = base.Columns["Cong_mob"];
			columnCong_fax = base.Columns["Cong_fax"];
			columnCong_vat = base.Columns["Cong_vat"];
			columnAddType = base.Columns["AddType"];
			columnAddAmt = base.Columns["AddAmt"];
			columnDeductionType = base.Columns["DeductionType"];
			columnDeduction = base.Columns["Deduction"];
			columnPFType = base.Columns["PFType"];
			columnPF = base.Columns["PF"];
			columnCENVAT = base.Columns["CENVAT"];
			columnSED = base.Columns["SED"];
			columnAED = base.Columns["AED"];
			columnVAT = base.Columns["VAT"];
			columnSelectedCST = base.Columns["SelectedCST"];
			columnCST = base.Columns["CST"];
			columnFreightType = base.Columns["FreightType"];
			columnFreight = base.Columns["Freight"];
			columnInsuranceType = base.Columns["InsuranceType"];
			columnInsurance = base.Columns["Insurance"];
			columnPODate = base.Columns["PODate"];
			columnAEDType = base.Columns["AEDType"];
			columnSEDType = base.Columns["SEDType"];
			columnDateOfRemoval = base.Columns["DateOfRemoval"];
			columnPOId = base.Columns["POId"];
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
			columnInvoiceNo = new DataColumn("InvoiceNo", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnInvoiceNo);
			columnPONo = new DataColumn("PONo", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnPONo);
			columnWONo = new DataColumn("WONo", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnWONo);
			columnInvoiceMode = new DataColumn("InvoiceMode", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnInvoiceMode);
			columnDateOfIssueInvoice = new DataColumn("DateOfIssueInvoice", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnDateOfIssueInvoice);
			columnTimeOfIssueInvoice = new DataColumn("TimeOfIssueInvoice", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnTimeOfIssueInvoice);
			columnTimeOfRemoval = new DataColumn("TimeOfRemoval", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnTimeOfRemoval);
			columnNatureOfRemoval = new DataColumn("NatureOfRemoval", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnNatureOfRemoval);
			columnCommodity = new DataColumn("Commodity", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnCommodity);
			columnTariffHeading = new DataColumn("TariffHeading", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnTariffHeading);
			columnModeOfTransport = new DataColumn("ModeOfTransport", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnModeOfTransport);
			columnRRGCNo = new DataColumn("RRGCNo", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnRRGCNo);
			columnVehiRegNo = new DataColumn("VehiRegNo", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnVehiRegNo);
			columnDutyRate = new DataColumn("DutyRate", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnDutyRate);
			columnCustomerCode = new DataColumn("CustomerCode", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnCustomerCode);
			columnCustomerCategory = new DataColumn("CustomerCategory", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnCustomerCategory);
			columnBuyer_name = new DataColumn("Buyer_name", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnBuyer_name);
			columnBuyer_cotper = new DataColumn("Buyer_cotper", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnBuyer_cotper);
			columnBuyer_ph = new DataColumn("Buyer_ph", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnBuyer_ph);
			columnBuyer_email = new DataColumn("Buyer_email", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnBuyer_email);
			columnBuyer_ecc = new DataColumn("Buyer_ecc", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnBuyer_ecc);
			columnBuyer_tin = new DataColumn("Buyer_tin", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnBuyer_tin);
			columnBuyer_mob = new DataColumn("Buyer_mob", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnBuyer_mob);
			columnBuyer_fax = new DataColumn("Buyer_fax", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnBuyer_fax);
			columnBuyer_vat = new DataColumn("Buyer_vat", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnBuyer_vat);
			columnCong_name = new DataColumn("Cong_name", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnCong_name);
			columnCong_cotper = new DataColumn("Cong_cotper", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnCong_cotper);
			columnCong_ph = new DataColumn("Cong_ph", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnCong_ph);
			columnCong_email = new DataColumn("Cong_email", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnCong_email);
			columnCong_ecc = new DataColumn("Cong_ecc", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnCong_ecc);
			columnCong_tin = new DataColumn("Cong_tin", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnCong_tin);
			columnCong_mob = new DataColumn("Cong_mob", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnCong_mob);
			columnCong_fax = new DataColumn("Cong_fax", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnCong_fax);
			columnCong_vat = new DataColumn("Cong_vat", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnCong_vat);
			columnAddType = new DataColumn("AddType", typeof(int), null, MappingType.Element);
			base.Columns.Add(columnAddType);
			columnAddAmt = new DataColumn("AddAmt", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnAddAmt);
			columnDeductionType = new DataColumn("DeductionType", typeof(int), null, MappingType.Element);
			base.Columns.Add(columnDeductionType);
			columnDeduction = new DataColumn("Deduction", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnDeduction);
			columnPFType = new DataColumn("PFType", typeof(int), null, MappingType.Element);
			base.Columns.Add(columnPFType);
			columnPF = new DataColumn("PF", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnPF);
			columnCENVAT = new DataColumn("CENVAT", typeof(int), null, MappingType.Element);
			base.Columns.Add(columnCENVAT);
			columnSED = new DataColumn("SED", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnSED);
			columnAED = new DataColumn("AED", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnAED);
			columnVAT = new DataColumn("VAT", typeof(int), null, MappingType.Element);
			base.Columns.Add(columnVAT);
			columnSelectedCST = new DataColumn("SelectedCST", typeof(int), null, MappingType.Element);
			base.Columns.Add(columnSelectedCST);
			columnCST = new DataColumn("CST", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnCST);
			columnFreightType = new DataColumn("FreightType", typeof(int), null, MappingType.Element);
			base.Columns.Add(columnFreightType);
			columnFreight = new DataColumn("Freight", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnFreight);
			columnInsuranceType = new DataColumn("InsuranceType", typeof(int), null, MappingType.Element);
			base.Columns.Add(columnInsuranceType);
			columnInsurance = new DataColumn("Insurance", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnInsurance);
			columnPODate = new DataColumn("PODate", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnPODate);
			columnAEDType = new DataColumn("AEDType", typeof(int), null, MappingType.Element);
			base.Columns.Add(columnAEDType);
			columnSEDType = new DataColumn("SEDType", typeof(int), null, MappingType.Element);
			base.Columns.Add(columnSEDType);
			columnDateOfRemoval = new DataColumn("DateOfRemoval", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnDateOfRemoval);
			columnPOId = new DataColumn("POId", typeof(int), null, MappingType.Element);
			base.Columns.Add(columnPOId);
			columnOtherAmt = new DataColumn("OtherAmt", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnOtherAmt);
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
			SalesInvoice salesInvoice = new SalesInvoice();
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
			xmlSchemaAttribute.FixedValue = salesInvoice.Namespace;
			xmlSchemaComplexType.Attributes.Add(xmlSchemaAttribute);
			XmlSchemaAttribute xmlSchemaAttribute2 = new XmlSchemaAttribute();
			xmlSchemaAttribute2.Name = "tableTypeName";
			xmlSchemaAttribute2.FixedValue = "DataTable1DataTable";
			xmlSchemaComplexType.Attributes.Add(xmlSchemaAttribute2);
			xmlSchemaComplexType.Particle = xmlSchemaSequence;
			XmlSchema schemaSerializable = salesInvoice.GetSchemaSerializable();
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
		public string InvoiceMode
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.InvoiceModeColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'InvoiceMode' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.InvoiceModeColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string DateOfIssueInvoice
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.DateOfIssueInvoiceColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'DateOfIssueInvoice' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.DateOfIssueInvoiceColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string TimeOfIssueInvoice
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.TimeOfIssueInvoiceColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'TimeOfIssueInvoice' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.TimeOfIssueInvoiceColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string TimeOfRemoval
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.TimeOfRemovalColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'TimeOfRemoval' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.TimeOfRemovalColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string NatureOfRemoval
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.NatureOfRemovalColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'NatureOfRemoval' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.NatureOfRemovalColumn] = value;
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
		public string TariffHeading
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.TariffHeadingColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'TariffHeading' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.TariffHeadingColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string ModeOfTransport
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.ModeOfTransportColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'ModeOfTransport' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.ModeOfTransportColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string RRGCNo
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.RRGCNoColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'RRGCNo' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.RRGCNoColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string VehiRegNo
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.VehiRegNoColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'VehiRegNo' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.VehiRegNoColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string DutyRate
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.DutyRateColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'DutyRate' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.DutyRateColumn] = value;
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
		public string CustomerCategory
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.CustomerCategoryColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'CustomerCategory' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.CustomerCategoryColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string Buyer_name
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.Buyer_nameColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Buyer_name' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.Buyer_nameColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string Buyer_cotper
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.Buyer_cotperColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Buyer_cotper' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.Buyer_cotperColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string Buyer_ph
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.Buyer_phColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Buyer_ph' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.Buyer_phColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string Buyer_email
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.Buyer_emailColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Buyer_email' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.Buyer_emailColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string Buyer_ecc
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.Buyer_eccColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Buyer_ecc' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.Buyer_eccColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string Buyer_tin
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.Buyer_tinColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Buyer_tin' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.Buyer_tinColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string Buyer_mob
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.Buyer_mobColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Buyer_mob' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.Buyer_mobColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string Buyer_fax
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.Buyer_faxColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Buyer_fax' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.Buyer_faxColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string Buyer_vat
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.Buyer_vatColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Buyer_vat' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.Buyer_vatColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string Cong_name
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.Cong_nameColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Cong_name' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.Cong_nameColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string Cong_cotper
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.Cong_cotperColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Cong_cotper' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.Cong_cotperColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string Cong_ph
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.Cong_phColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Cong_ph' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.Cong_phColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string Cong_email
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.Cong_emailColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Cong_email' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.Cong_emailColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string Cong_ecc
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.Cong_eccColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Cong_ecc' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.Cong_eccColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string Cong_tin
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.Cong_tinColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Cong_tin' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.Cong_tinColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string Cong_mob
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.Cong_mobColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Cong_mob' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.Cong_mobColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string Cong_fax
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.Cong_faxColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Cong_fax' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.Cong_faxColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string Cong_vat
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.Cong_vatColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Cong_vat' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.Cong_vatColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public int AddType
		{
			get
			{
				try
				{
					return (int)base[tableDataTable1.AddTypeColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'AddType' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.AddTypeColumn] = value;
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
		public int DeductionType
		{
			get
			{
				try
				{
					return (int)base[tableDataTable1.DeductionTypeColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'DeductionType' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.DeductionTypeColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public double Deduction
		{
			get
			{
				try
				{
					return (double)base[tableDataTable1.DeductionColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Deduction' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.DeductionColumn] = value;
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
		public int CENVAT
		{
			get
			{
				try
				{
					return (int)base[tableDataTable1.CENVATColumn];
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
		public double SED
		{
			get
			{
				try
				{
					return (double)base[tableDataTable1.SEDColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'SED' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.SEDColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public double AED
		{
			get
			{
				try
				{
					return (double)base[tableDataTable1.AEDColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'AED' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.AEDColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public int VAT
		{
			get
			{
				try
				{
					return (int)base[tableDataTable1.VATColumn];
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
		public int SelectedCST
		{
			get
			{
				try
				{
					return (int)base[tableDataTable1.SelectedCSTColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'SelectedCST' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.SelectedCSTColumn] = value;
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
		public int InsuranceType
		{
			get
			{
				try
				{
					return (int)base[tableDataTable1.InsuranceTypeColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'InsuranceType' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.InsuranceTypeColumn] = value;
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
		public int AEDType
		{
			get
			{
				try
				{
					return (int)base[tableDataTable1.AEDTypeColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'AEDType' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.AEDTypeColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public int SEDType
		{
			get
			{
				try
				{
					return (int)base[tableDataTable1.SEDTypeColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'SEDType' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.SEDTypeColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string DateOfRemoval
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.DateOfRemovalColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'DateOfRemoval' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.DateOfRemovalColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public int POId
		{
			get
			{
				try
				{
					return (int)base[tableDataTable1.POIdColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'POId' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.POIdColumn] = value;
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
		public bool IsInvoiceModeNull()
		{
			return IsNull(tableDataTable1.InvoiceModeColumn);
		}

		[DebuggerNonUserCode]
		public void SetInvoiceModeNull()
		{
			base[tableDataTable1.InvoiceModeColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsDateOfIssueInvoiceNull()
		{
			return IsNull(tableDataTable1.DateOfIssueInvoiceColumn);
		}

		[DebuggerNonUserCode]
		public void SetDateOfIssueInvoiceNull()
		{
			base[tableDataTable1.DateOfIssueInvoiceColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsTimeOfIssueInvoiceNull()
		{
			return IsNull(tableDataTable1.TimeOfIssueInvoiceColumn);
		}

		[DebuggerNonUserCode]
		public void SetTimeOfIssueInvoiceNull()
		{
			base[tableDataTable1.TimeOfIssueInvoiceColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsTimeOfRemovalNull()
		{
			return IsNull(tableDataTable1.TimeOfRemovalColumn);
		}

		[DebuggerNonUserCode]
		public void SetTimeOfRemovalNull()
		{
			base[tableDataTable1.TimeOfRemovalColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsNatureOfRemovalNull()
		{
			return IsNull(tableDataTable1.NatureOfRemovalColumn);
		}

		[DebuggerNonUserCode]
		public void SetNatureOfRemovalNull()
		{
			base[tableDataTable1.NatureOfRemovalColumn] = Convert.DBNull;
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
		public bool IsTariffHeadingNull()
		{
			return IsNull(tableDataTable1.TariffHeadingColumn);
		}

		[DebuggerNonUserCode]
		public void SetTariffHeadingNull()
		{
			base[tableDataTable1.TariffHeadingColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsModeOfTransportNull()
		{
			return IsNull(tableDataTable1.ModeOfTransportColumn);
		}

		[DebuggerNonUserCode]
		public void SetModeOfTransportNull()
		{
			base[tableDataTable1.ModeOfTransportColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsRRGCNoNull()
		{
			return IsNull(tableDataTable1.RRGCNoColumn);
		}

		[DebuggerNonUserCode]
		public void SetRRGCNoNull()
		{
			base[tableDataTable1.RRGCNoColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsVehiRegNoNull()
		{
			return IsNull(tableDataTable1.VehiRegNoColumn);
		}

		[DebuggerNonUserCode]
		public void SetVehiRegNoNull()
		{
			base[tableDataTable1.VehiRegNoColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsDutyRateNull()
		{
			return IsNull(tableDataTable1.DutyRateColumn);
		}

		[DebuggerNonUserCode]
		public void SetDutyRateNull()
		{
			base[tableDataTable1.DutyRateColumn] = Convert.DBNull;
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
		public bool IsCustomerCategoryNull()
		{
			return IsNull(tableDataTable1.CustomerCategoryColumn);
		}

		[DebuggerNonUserCode]
		public void SetCustomerCategoryNull()
		{
			base[tableDataTable1.CustomerCategoryColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsBuyer_nameNull()
		{
			return IsNull(tableDataTable1.Buyer_nameColumn);
		}

		[DebuggerNonUserCode]
		public void SetBuyer_nameNull()
		{
			base[tableDataTable1.Buyer_nameColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsBuyer_cotperNull()
		{
			return IsNull(tableDataTable1.Buyer_cotperColumn);
		}

		[DebuggerNonUserCode]
		public void SetBuyer_cotperNull()
		{
			base[tableDataTable1.Buyer_cotperColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsBuyer_phNull()
		{
			return IsNull(tableDataTable1.Buyer_phColumn);
		}

		[DebuggerNonUserCode]
		public void SetBuyer_phNull()
		{
			base[tableDataTable1.Buyer_phColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsBuyer_emailNull()
		{
			return IsNull(tableDataTable1.Buyer_emailColumn);
		}

		[DebuggerNonUserCode]
		public void SetBuyer_emailNull()
		{
			base[tableDataTable1.Buyer_emailColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsBuyer_eccNull()
		{
			return IsNull(tableDataTable1.Buyer_eccColumn);
		}

		[DebuggerNonUserCode]
		public void SetBuyer_eccNull()
		{
			base[tableDataTable1.Buyer_eccColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsBuyer_tinNull()
		{
			return IsNull(tableDataTable1.Buyer_tinColumn);
		}

		[DebuggerNonUserCode]
		public void SetBuyer_tinNull()
		{
			base[tableDataTable1.Buyer_tinColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsBuyer_mobNull()
		{
			return IsNull(tableDataTable1.Buyer_mobColumn);
		}

		[DebuggerNonUserCode]
		public void SetBuyer_mobNull()
		{
			base[tableDataTable1.Buyer_mobColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsBuyer_faxNull()
		{
			return IsNull(tableDataTable1.Buyer_faxColumn);
		}

		[DebuggerNonUserCode]
		public void SetBuyer_faxNull()
		{
			base[tableDataTable1.Buyer_faxColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsBuyer_vatNull()
		{
			return IsNull(tableDataTable1.Buyer_vatColumn);
		}

		[DebuggerNonUserCode]
		public void SetBuyer_vatNull()
		{
			base[tableDataTable1.Buyer_vatColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsCong_nameNull()
		{
			return IsNull(tableDataTable1.Cong_nameColumn);
		}

		[DebuggerNonUserCode]
		public void SetCong_nameNull()
		{
			base[tableDataTable1.Cong_nameColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsCong_cotperNull()
		{
			return IsNull(tableDataTable1.Cong_cotperColumn);
		}

		[DebuggerNonUserCode]
		public void SetCong_cotperNull()
		{
			base[tableDataTable1.Cong_cotperColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsCong_phNull()
		{
			return IsNull(tableDataTable1.Cong_phColumn);
		}

		[DebuggerNonUserCode]
		public void SetCong_phNull()
		{
			base[tableDataTable1.Cong_phColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsCong_emailNull()
		{
			return IsNull(tableDataTable1.Cong_emailColumn);
		}

		[DebuggerNonUserCode]
		public void SetCong_emailNull()
		{
			base[tableDataTable1.Cong_emailColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsCong_eccNull()
		{
			return IsNull(tableDataTable1.Cong_eccColumn);
		}

		[DebuggerNonUserCode]
		public void SetCong_eccNull()
		{
			base[tableDataTable1.Cong_eccColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsCong_tinNull()
		{
			return IsNull(tableDataTable1.Cong_tinColumn);
		}

		[DebuggerNonUserCode]
		public void SetCong_tinNull()
		{
			base[tableDataTable1.Cong_tinColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsCong_mobNull()
		{
			return IsNull(tableDataTable1.Cong_mobColumn);
		}

		[DebuggerNonUserCode]
		public void SetCong_mobNull()
		{
			base[tableDataTable1.Cong_mobColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsCong_faxNull()
		{
			return IsNull(tableDataTable1.Cong_faxColumn);
		}

		[DebuggerNonUserCode]
		public void SetCong_faxNull()
		{
			base[tableDataTable1.Cong_faxColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsCong_vatNull()
		{
			return IsNull(tableDataTable1.Cong_vatColumn);
		}

		[DebuggerNonUserCode]
		public void SetCong_vatNull()
		{
			base[tableDataTable1.Cong_vatColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsAddTypeNull()
		{
			return IsNull(tableDataTable1.AddTypeColumn);
		}

		[DebuggerNonUserCode]
		public void SetAddTypeNull()
		{
			base[tableDataTable1.AddTypeColumn] = Convert.DBNull;
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

		[DebuggerNonUserCode]
		public bool IsDeductionTypeNull()
		{
			return IsNull(tableDataTable1.DeductionTypeColumn);
		}

		[DebuggerNonUserCode]
		public void SetDeductionTypeNull()
		{
			base[tableDataTable1.DeductionTypeColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsDeductionNull()
		{
			return IsNull(tableDataTable1.DeductionColumn);
		}

		[DebuggerNonUserCode]
		public void SetDeductionNull()
		{
			base[tableDataTable1.DeductionColumn] = Convert.DBNull;
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
		public bool IsSEDNull()
		{
			return IsNull(tableDataTable1.SEDColumn);
		}

		[DebuggerNonUserCode]
		public void SetSEDNull()
		{
			base[tableDataTable1.SEDColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsAEDNull()
		{
			return IsNull(tableDataTable1.AEDColumn);
		}

		[DebuggerNonUserCode]
		public void SetAEDNull()
		{
			base[tableDataTable1.AEDColumn] = Convert.DBNull;
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
		public bool IsSelectedCSTNull()
		{
			return IsNull(tableDataTable1.SelectedCSTColumn);
		}

		[DebuggerNonUserCode]
		public void SetSelectedCSTNull()
		{
			base[tableDataTable1.SelectedCSTColumn] = Convert.DBNull;
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
		public bool IsInsuranceTypeNull()
		{
			return IsNull(tableDataTable1.InsuranceTypeColumn);
		}

		[DebuggerNonUserCode]
		public void SetInsuranceTypeNull()
		{
			base[tableDataTable1.InsuranceTypeColumn] = Convert.DBNull;
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
		public bool IsAEDTypeNull()
		{
			return IsNull(tableDataTable1.AEDTypeColumn);
		}

		[DebuggerNonUserCode]
		public void SetAEDTypeNull()
		{
			base[tableDataTable1.AEDTypeColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsSEDTypeNull()
		{
			return IsNull(tableDataTable1.SEDTypeColumn);
		}

		[DebuggerNonUserCode]
		public void SetSEDTypeNull()
		{
			base[tableDataTable1.SEDTypeColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsDateOfRemovalNull()
		{
			return IsNull(tableDataTable1.DateOfRemovalColumn);
		}

		[DebuggerNonUserCode]
		public void SetDateOfRemovalNull()
		{
			base[tableDataTable1.DateOfRemovalColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsPOIdNull()
		{
			return IsNull(tableDataTable1.POIdColumn);
		}

		[DebuggerNonUserCode]
		public void SetPOIdNull()
		{
			base[tableDataTable1.POIdColumn] = Convert.DBNull;
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

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[DebuggerNonUserCode]
	public new DataRelationCollection Relations => base.Relations;

	[DebuggerNonUserCode]
	public SalesInvoice()
	{
		BeginInit();
		InitClass();
		CollectionChangeEventHandler value = SchemaChanged;
		base.Tables.CollectionChanged += value;
		base.Relations.CollectionChanged += value;
		EndInit();
	}

	[DebuggerNonUserCode]
	protected SalesInvoice(SerializationInfo info, StreamingContext context)
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
		SalesInvoice salesInvoice = (SalesInvoice)base.Clone();
		salesInvoice.InitVars();
		salesInvoice.SchemaSerializationMode = SchemaSerializationMode;
		return salesInvoice;
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
		base.DataSetName = "SalesInvoice";
		base.Prefix = "";
		base.Namespace = "http://tempuri.org/SalesInvoice.xsd";
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
		SalesInvoice salesInvoice = new SalesInvoice();
		XmlSchemaComplexType xmlSchemaComplexType = new XmlSchemaComplexType();
		XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
		XmlSchemaAny xmlSchemaAny = new XmlSchemaAny();
		xmlSchemaAny.Namespace = salesInvoice.Namespace;
		xmlSchemaSequence.Items.Add(xmlSchemaAny);
		xmlSchemaComplexType.Particle = xmlSchemaSequence;
		XmlSchema schemaSerializable = salesInvoice.GetSchemaSerializable();
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
