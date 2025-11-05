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
[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
[DesignerCategory("code")]
[ToolboxItem(true)]
[HelpKeyword("vs.data.DataSet")]
[XmlSchemaProvider("GetTypedDataSetSchema")]
[XmlRoot("Salary")]
public class Salary : DataSet
{
	public delegate void DataTable1RowChangeEventHandler(object sender, DataTable1RowChangeEvent e);

	[Serializable]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
	[XmlSchemaProvider("GetTypedTableSchema")]
	public class DataTable1DataTable : TypedTableBase<DataTable1Row>
	{
		private DataColumn columnEmpId;

		private DataColumn columnCompId;

		private DataColumn columnEmployeeName;

		private DataColumn columnMonth;

		private DataColumn columnYear;

		private DataColumn columnDept;

		private DataColumn columnDesignation;

		private DataColumn columnStatus;

		private DataColumn columnGrade;

		private DataColumn columnBasic;

		private DataColumn columnDA;

		private DataColumn columnHRA;

		private DataColumn columnConveyance;

		private DataColumn columnEducation;

		private DataColumn columnMedical;

		private DataColumn columnSundayP;

		private DataColumn columnGrossTotal;

		private DataColumn columnAttendanceBonus;

		private DataColumn columnSpecialAllowance;

		private DataColumn columnExGratia;

		private DataColumn columnTravellingAllowance;

		private DataColumn columnMiscellaneous;

		private DataColumn columnTotal;

		private DataColumn columnNetPay;

		private DataColumn columnWorkingDays;

		private DataColumn columnPreasentDays;

		private DataColumn columnAbsentDays;

		private DataColumn columnSunday;

		private DataColumn columnHoliday;

		private DataColumn columnLateIn;

		private DataColumn columnCoff;

		private DataColumn columnHalfDays;

		private DataColumn columnPL;

		private DataColumn columnLWP;

		private DataColumn columnPFofEmployee;

		private DataColumn columnPTax;

		private DataColumn columnPersonalLoanInstall;

		private DataColumn columnMobileBill;

		private DataColumn columnMiscellaneous2;

		private DataColumn columnTotal2;

		private DataColumn columnEmpACNo;

		private DataColumn columnDate;

		private DataColumn columnBasicCal;

		private DataColumn columnDACal;

		private DataColumn columnHRACal;

		private DataColumn columnConveyanceCal;

		private DataColumn columnEducationCal;

		private DataColumn columnMedicalCal;

		private DataColumn columnGrossTotalCal;

		private DataColumn columnAttBonusType;

		private DataColumn columnAttBonusAmt;

		private DataColumn columnPFNo;

		private DataColumn columnPANNo;

		private DataColumn columnOTHrs1;

		private DataColumn columnOTRate;

		private DataColumn columnPath;

		[DebuggerNonUserCode]
		public DataColumn EmpIdColumn => columnEmpId;

		[DebuggerNonUserCode]
		public DataColumn CompIdColumn => columnCompId;

		[DebuggerNonUserCode]
		public DataColumn EmployeeNameColumn => columnEmployeeName;

		[DebuggerNonUserCode]
		public DataColumn MonthColumn => columnMonth;

		[DebuggerNonUserCode]
		public DataColumn YearColumn => columnYear;

		[DebuggerNonUserCode]
		public DataColumn DeptColumn => columnDept;

		[DebuggerNonUserCode]
		public DataColumn DesignationColumn => columnDesignation;

		[DebuggerNonUserCode]
		public DataColumn StatusColumn => columnStatus;

		[DebuggerNonUserCode]
		public DataColumn GradeColumn => columnGrade;

		[DebuggerNonUserCode]
		public DataColumn BasicColumn => columnBasic;

		[DebuggerNonUserCode]
		public DataColumn DAColumn => columnDA;

		[DebuggerNonUserCode]
		public DataColumn HRAColumn => columnHRA;

		[DebuggerNonUserCode]
		public DataColumn ConveyanceColumn => columnConveyance;

		[DebuggerNonUserCode]
		public DataColumn EducationColumn => columnEducation;

		[DebuggerNonUserCode]
		public DataColumn MedicalColumn => columnMedical;

		[DebuggerNonUserCode]
		public DataColumn SundayPColumn => columnSundayP;

		[DebuggerNonUserCode]
		public DataColumn GrossTotalColumn => columnGrossTotal;

		[DebuggerNonUserCode]
		public DataColumn AttendanceBonusColumn => columnAttendanceBonus;

		[DebuggerNonUserCode]
		public DataColumn SpecialAllowanceColumn => columnSpecialAllowance;

		[DebuggerNonUserCode]
		public DataColumn ExGratiaColumn => columnExGratia;

		[DebuggerNonUserCode]
		public DataColumn TravellingAllowanceColumn => columnTravellingAllowance;

		[DebuggerNonUserCode]
		public DataColumn MiscellaneousColumn => columnMiscellaneous;

		[DebuggerNonUserCode]
		public DataColumn TotalColumn => columnTotal;

		[DebuggerNonUserCode]
		public DataColumn NetPayColumn => columnNetPay;

		[DebuggerNonUserCode]
		public DataColumn WorkingDaysColumn => columnWorkingDays;

		[DebuggerNonUserCode]
		public DataColumn PreasentDaysColumn => columnPreasentDays;

		[DebuggerNonUserCode]
		public DataColumn AbsentDaysColumn => columnAbsentDays;

		[DebuggerNonUserCode]
		public DataColumn SundayColumn => columnSunday;

		[DebuggerNonUserCode]
		public DataColumn HolidayColumn => columnHoliday;

		[DebuggerNonUserCode]
		public DataColumn LateInColumn => columnLateIn;

		[DebuggerNonUserCode]
		public DataColumn CoffColumn => columnCoff;

		[DebuggerNonUserCode]
		public DataColumn HalfDaysColumn => columnHalfDays;

		[DebuggerNonUserCode]
		public DataColumn PLColumn => columnPL;

		[DebuggerNonUserCode]
		public DataColumn LWPColumn => columnLWP;

		[DebuggerNonUserCode]
		public DataColumn PFofEmployeeColumn => columnPFofEmployee;

		[DebuggerNonUserCode]
		public DataColumn PTaxColumn => columnPTax;

		[DebuggerNonUserCode]
		public DataColumn PersonalLoanInstallColumn => columnPersonalLoanInstall;

		[DebuggerNonUserCode]
		public DataColumn MobileBillColumn => columnMobileBill;

		[DebuggerNonUserCode]
		public DataColumn Miscellaneous2Column => columnMiscellaneous2;

		[DebuggerNonUserCode]
		public DataColumn Total2Column => columnTotal2;

		[DebuggerNonUserCode]
		public DataColumn EmpACNoColumn => columnEmpACNo;

		[DebuggerNonUserCode]
		public DataColumn DateColumn => columnDate;

		[DebuggerNonUserCode]
		public DataColumn BasicCalColumn => columnBasicCal;

		[DebuggerNonUserCode]
		public DataColumn DACalColumn => columnDACal;

		[DebuggerNonUserCode]
		public DataColumn HRACalColumn => columnHRACal;

		[DebuggerNonUserCode]
		public DataColumn ConveyanceCalColumn => columnConveyanceCal;

		[DebuggerNonUserCode]
		public DataColumn EducationCalColumn => columnEducationCal;

		[DebuggerNonUserCode]
		public DataColumn MedicalCalColumn => columnMedicalCal;

		[DebuggerNonUserCode]
		public DataColumn GrossTotalCalColumn => columnGrossTotalCal;

		[DebuggerNonUserCode]
		public DataColumn AttBonusTypeColumn => columnAttBonusType;

		[DebuggerNonUserCode]
		public DataColumn AttBonusAmtColumn => columnAttBonusAmt;

		[DebuggerNonUserCode]
		public DataColumn PFNoColumn => columnPFNo;

		[DebuggerNonUserCode]
		public DataColumn PANNoColumn => columnPANNo;

		[DebuggerNonUserCode]
		public DataColumn OTHrs1Column => columnOTHrs1;

		[DebuggerNonUserCode]
		public DataColumn OTRateColumn => columnOTRate;

		[DebuggerNonUserCode]
		public DataColumn PathColumn => columnPath;

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
		public DataTable1Row AddDataTable1Row(string EmpId, int CompId, string EmployeeName, string Month, string Year, string Dept, string Designation, string Status, string Grade, double Basic, double DA, double HRA, double Conveyance, double Education, double Medical, double SundayP, double GrossTotal, double AttendanceBonus, double SpecialAllowance, double ExGratia, double TravellingAllowance, double Miscellaneous, double Total, double NetPay, double WorkingDays, double PreasentDays, double AbsentDays, double Sunday, double Holiday, double LateIn, double Coff, double HalfDays, double PL, double LWP, double PFofEmployee, double PTax, double PersonalLoanInstall, double MobileBill, double Miscellaneous2, double Total2, string EmpACNo, string Date, double BasicCal, double DACal, double HRACal, double ConveyanceCal, double EducationCal, double MedicalCal, double GrossTotalCal, int AttBonusType, double AttBonusAmt, string PFNo, string PANNo, double OTHrs1, double OTRate, string Path)
		{
			DataTable1Row dataTable1Row = (DataTable1Row)NewRow();
			object[] itemArray = new object[56]
			{
				EmpId, CompId, EmployeeName, Month, Year, Dept, Designation, Status, Grade, Basic,
				DA, HRA, Conveyance, Education, Medical, SundayP, GrossTotal, AttendanceBonus, SpecialAllowance, ExGratia,
				TravellingAllowance, Miscellaneous, Total, NetPay, WorkingDays, PreasentDays, AbsentDays, Sunday, Holiday, LateIn,
				Coff, HalfDays, PL, LWP, PFofEmployee, PTax, PersonalLoanInstall, MobileBill, Miscellaneous2, Total2,
				EmpACNo, Date, BasicCal, DACal, HRACal, ConveyanceCal, EducationCal, MedicalCal, GrossTotalCal, AttBonusType,
				AttBonusAmt, PFNo, PANNo, OTHrs1, OTRate, Path
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
			columnEmpId = base.Columns["EmpId"];
			columnCompId = base.Columns["CompId"];
			columnEmployeeName = base.Columns["EmployeeName"];
			columnMonth = base.Columns["Month"];
			columnYear = base.Columns["Year"];
			columnDept = base.Columns["Dept"];
			columnDesignation = base.Columns["Designation"];
			columnStatus = base.Columns["Status"];
			columnGrade = base.Columns["Grade"];
			columnBasic = base.Columns["Basic"];
			columnDA = base.Columns["DA"];
			columnHRA = base.Columns["HRA"];
			columnConveyance = base.Columns["Conveyance"];
			columnEducation = base.Columns["Education"];
			columnMedical = base.Columns["Medical"];
			columnSundayP = base.Columns["SundayP"];
			columnGrossTotal = base.Columns["GrossTotal"];
			columnAttendanceBonus = base.Columns["AttendanceBonus"];
			columnSpecialAllowance = base.Columns["SpecialAllowance"];
			columnExGratia = base.Columns["ExGratia"];
			columnTravellingAllowance = base.Columns["TravellingAllowance"];
			columnMiscellaneous = base.Columns["Miscellaneous"];
			columnTotal = base.Columns["Total"];
			columnNetPay = base.Columns["NetPay"];
			columnWorkingDays = base.Columns["WorkingDays"];
			columnPreasentDays = base.Columns["PreasentDays"];
			columnAbsentDays = base.Columns["AbsentDays"];
			columnSunday = base.Columns["Sunday"];
			columnHoliday = base.Columns["Holiday"];
			columnLateIn = base.Columns["LateIn"];
			columnCoff = base.Columns["Coff"];
			columnHalfDays = base.Columns["HalfDays"];
			columnPL = base.Columns["PL"];
			columnLWP = base.Columns["LWP"];
			columnPFofEmployee = base.Columns["PFofEmployee"];
			columnPTax = base.Columns["PTax"];
			columnPersonalLoanInstall = base.Columns["PersonalLoanInstall"];
			columnMobileBill = base.Columns["MobileBill"];
			columnMiscellaneous2 = base.Columns["Miscellaneous2"];
			columnTotal2 = base.Columns["Total2"];
			columnEmpACNo = base.Columns["EmpACNo"];
			columnDate = base.Columns["Date"];
			columnBasicCal = base.Columns["BasicCal"];
			columnDACal = base.Columns["DACal"];
			columnHRACal = base.Columns["HRACal"];
			columnConveyanceCal = base.Columns["ConveyanceCal"];
			columnEducationCal = base.Columns["EducationCal"];
			columnMedicalCal = base.Columns["MedicalCal"];
			columnGrossTotalCal = base.Columns["GrossTotalCal"];
			columnAttBonusType = base.Columns["AttBonusType"];
			columnAttBonusAmt = base.Columns["AttBonusAmt"];
			columnPFNo = base.Columns["PFNo"];
			columnPANNo = base.Columns["PANNo"];
			columnOTHrs1 = base.Columns["OTHrs1"];
			columnOTRate = base.Columns["OTRate"];
			columnPath = base.Columns["Path"];
		}

		[DebuggerNonUserCode]
		private void InitClass()
		{
			columnEmpId = new DataColumn("EmpId", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnEmpId);
			columnCompId = new DataColumn("CompId", typeof(int), null, MappingType.Element);
			base.Columns.Add(columnCompId);
			columnEmployeeName = new DataColumn("EmployeeName", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnEmployeeName);
			columnMonth = new DataColumn("Month", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnMonth);
			columnYear = new DataColumn("Year", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnYear);
			columnDept = new DataColumn("Dept", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnDept);
			columnDesignation = new DataColumn("Designation", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnDesignation);
			columnStatus = new DataColumn("Status", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnStatus);
			columnGrade = new DataColumn("Grade", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnGrade);
			columnBasic = new DataColumn("Basic", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnBasic);
			columnDA = new DataColumn("DA", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnDA);
			columnHRA = new DataColumn("HRA", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnHRA);
			columnConveyance = new DataColumn("Conveyance", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnConveyance);
			columnEducation = new DataColumn("Education", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnEducation);
			columnMedical = new DataColumn("Medical", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnMedical);
			columnSundayP = new DataColumn("SundayP", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnSundayP);
			columnGrossTotal = new DataColumn("GrossTotal", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnGrossTotal);
			columnAttendanceBonus = new DataColumn("AttendanceBonus", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnAttendanceBonus);
			columnSpecialAllowance = new DataColumn("SpecialAllowance", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnSpecialAllowance);
			columnExGratia = new DataColumn("ExGratia", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnExGratia);
			columnTravellingAllowance = new DataColumn("TravellingAllowance", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnTravellingAllowance);
			columnMiscellaneous = new DataColumn("Miscellaneous", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnMiscellaneous);
			columnTotal = new DataColumn("Total", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnTotal);
			columnNetPay = new DataColumn("NetPay", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnNetPay);
			columnWorkingDays = new DataColumn("WorkingDays", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnWorkingDays);
			columnPreasentDays = new DataColumn("PreasentDays", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnPreasentDays);
			columnAbsentDays = new DataColumn("AbsentDays", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnAbsentDays);
			columnSunday = new DataColumn("Sunday", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnSunday);
			columnHoliday = new DataColumn("Holiday", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnHoliday);
			columnLateIn = new DataColumn("LateIn", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnLateIn);
			columnCoff = new DataColumn("Coff", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnCoff);
			columnHalfDays = new DataColumn("HalfDays", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnHalfDays);
			columnPL = new DataColumn("PL", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnPL);
			columnLWP = new DataColumn("LWP", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnLWP);
			columnPFofEmployee = new DataColumn("PFofEmployee", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnPFofEmployee);
			columnPTax = new DataColumn("PTax", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnPTax);
			columnPersonalLoanInstall = new DataColumn("PersonalLoanInstall", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnPersonalLoanInstall);
			columnMobileBill = new DataColumn("MobileBill", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnMobileBill);
			columnMiscellaneous2 = new DataColumn("Miscellaneous2", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnMiscellaneous2);
			columnTotal2 = new DataColumn("Total2", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnTotal2);
			columnEmpACNo = new DataColumn("EmpACNo", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnEmpACNo);
			columnDate = new DataColumn("Date", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnDate);
			columnBasicCal = new DataColumn("BasicCal", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnBasicCal);
			columnDACal = new DataColumn("DACal", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnDACal);
			columnHRACal = new DataColumn("HRACal", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnHRACal);
			columnConveyanceCal = new DataColumn("ConveyanceCal", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnConveyanceCal);
			columnEducationCal = new DataColumn("EducationCal", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnEducationCal);
			columnMedicalCal = new DataColumn("MedicalCal", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnMedicalCal);
			columnGrossTotalCal = new DataColumn("GrossTotalCal", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnGrossTotalCal);
			columnAttBonusType = new DataColumn("AttBonusType", typeof(int), null, MappingType.Element);
			base.Columns.Add(columnAttBonusType);
			columnAttBonusAmt = new DataColumn("AttBonusAmt", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnAttBonusAmt);
			columnPFNo = new DataColumn("PFNo", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnPFNo);
			columnPANNo = new DataColumn("PANNo", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnPANNo);
			columnOTHrs1 = new DataColumn("OTHrs1", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnOTHrs1);
			columnOTRate = new DataColumn("OTRate", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnOTRate);
			columnPath = new DataColumn("Path", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnPath);
			columnOTHrs1.DefaultValue = 0.0;
			columnOTRate.DefaultValue = 0.0;
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
			Salary salary = new Salary();
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
			xmlSchemaAttribute.FixedValue = salary.Namespace;
			xmlSchemaComplexType.Attributes.Add(xmlSchemaAttribute);
			XmlSchemaAttribute xmlSchemaAttribute2 = new XmlSchemaAttribute();
			xmlSchemaAttribute2.Name = "tableTypeName";
			xmlSchemaAttribute2.FixedValue = "DataTable1DataTable";
			xmlSchemaComplexType.Attributes.Add(xmlSchemaAttribute2);
			xmlSchemaComplexType.Particle = xmlSchemaSequence;
			XmlSchema schemaSerializable = salary.GetSchemaSerializable();
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
		public string EmpId
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.EmpIdColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'EmpId' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.EmpIdColumn] = value;
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
		public string EmployeeName
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.EmployeeNameColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'EmployeeName' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.EmployeeNameColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string Month
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.MonthColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Month' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.MonthColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string Year
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.YearColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Year' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.YearColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string Dept
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.DeptColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Dept' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.DeptColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string Designation
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.DesignationColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Designation' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.DesignationColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string Status
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.StatusColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Status' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.StatusColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string Grade
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.GradeColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Grade' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.GradeColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public double Basic
		{
			get
			{
				try
				{
					return (double)base[tableDataTable1.BasicColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Basic' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.BasicColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public double DA
		{
			get
			{
				try
				{
					return (double)base[tableDataTable1.DAColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'DA' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.DAColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public double HRA
		{
			get
			{
				try
				{
					return (double)base[tableDataTable1.HRAColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'HRA' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.HRAColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public double Conveyance
		{
			get
			{
				try
				{
					return (double)base[tableDataTable1.ConveyanceColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Conveyance' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.ConveyanceColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public double Education
		{
			get
			{
				try
				{
					return (double)base[tableDataTable1.EducationColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Education' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.EducationColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public double Medical
		{
			get
			{
				try
				{
					return (double)base[tableDataTable1.MedicalColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Medical' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.MedicalColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public double SundayP
		{
			get
			{
				try
				{
					return (double)base[tableDataTable1.SundayPColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'SundayP' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.SundayPColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public double GrossTotal
		{
			get
			{
				try
				{
					return (double)base[tableDataTable1.GrossTotalColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'GrossTotal' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.GrossTotalColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public double AttendanceBonus
		{
			get
			{
				try
				{
					return (double)base[tableDataTable1.AttendanceBonusColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'AttendanceBonus' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.AttendanceBonusColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public double SpecialAllowance
		{
			get
			{
				try
				{
					return (double)base[tableDataTable1.SpecialAllowanceColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'SpecialAllowance' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.SpecialAllowanceColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public double ExGratia
		{
			get
			{
				try
				{
					return (double)base[tableDataTable1.ExGratiaColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'ExGratia' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.ExGratiaColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public double TravellingAllowance
		{
			get
			{
				try
				{
					return (double)base[tableDataTable1.TravellingAllowanceColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'TravellingAllowance' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.TravellingAllowanceColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public double Miscellaneous
		{
			get
			{
				try
				{
					return (double)base[tableDataTable1.MiscellaneousColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Miscellaneous' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.MiscellaneousColumn] = value;
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
		public double NetPay
		{
			get
			{
				try
				{
					return (double)base[tableDataTable1.NetPayColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'NetPay' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.NetPayColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public double WorkingDays
		{
			get
			{
				try
				{
					return (double)base[tableDataTable1.WorkingDaysColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'WorkingDays' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.WorkingDaysColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public double PreasentDays
		{
			get
			{
				try
				{
					return (double)base[tableDataTable1.PreasentDaysColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'PreasentDays' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.PreasentDaysColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public double AbsentDays
		{
			get
			{
				try
				{
					return (double)base[tableDataTable1.AbsentDaysColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'AbsentDays' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.AbsentDaysColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public double Sunday
		{
			get
			{
				try
				{
					return (double)base[tableDataTable1.SundayColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Sunday' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.SundayColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public double Holiday
		{
			get
			{
				try
				{
					return (double)base[tableDataTable1.HolidayColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Holiday' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.HolidayColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public double LateIn
		{
			get
			{
				try
				{
					return (double)base[tableDataTable1.LateInColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'LateIn' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.LateInColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public double Coff
		{
			get
			{
				try
				{
					return (double)base[tableDataTable1.CoffColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Coff' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.CoffColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public double HalfDays
		{
			get
			{
				try
				{
					return (double)base[tableDataTable1.HalfDaysColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'HalfDays' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.HalfDaysColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public double PL
		{
			get
			{
				try
				{
					return (double)base[tableDataTable1.PLColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'PL' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.PLColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public double LWP
		{
			get
			{
				try
				{
					return (double)base[tableDataTable1.LWPColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'LWP' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.LWPColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public double PFofEmployee
		{
			get
			{
				try
				{
					return (double)base[tableDataTable1.PFofEmployeeColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'PFofEmployee' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.PFofEmployeeColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public double PTax
		{
			get
			{
				try
				{
					return (double)base[tableDataTable1.PTaxColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'PTax' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.PTaxColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public double PersonalLoanInstall
		{
			get
			{
				try
				{
					return (double)base[tableDataTable1.PersonalLoanInstallColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'PersonalLoanInstall' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.PersonalLoanInstallColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public double MobileBill
		{
			get
			{
				try
				{
					return (double)base[tableDataTable1.MobileBillColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'MobileBill' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.MobileBillColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public double Miscellaneous2
		{
			get
			{
				try
				{
					return (double)base[tableDataTable1.Miscellaneous2Column];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Miscellaneous2' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.Miscellaneous2Column] = value;
			}
		}

		[DebuggerNonUserCode]
		public double Total2
		{
			get
			{
				try
				{
					return (double)base[tableDataTable1.Total2Column];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Total2' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.Total2Column] = value;
			}
		}

		[DebuggerNonUserCode]
		public string EmpACNo
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.EmpACNoColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'EmpACNo' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.EmpACNoColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string Date
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.DateColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Date' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.DateColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public double BasicCal
		{
			get
			{
				try
				{
					return (double)base[tableDataTable1.BasicCalColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'BasicCal' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.BasicCalColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public double DACal
		{
			get
			{
				try
				{
					return (double)base[tableDataTable1.DACalColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'DACal' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.DACalColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public double HRACal
		{
			get
			{
				try
				{
					return (double)base[tableDataTable1.HRACalColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'HRACal' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.HRACalColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public double ConveyanceCal
		{
			get
			{
				try
				{
					return (double)base[tableDataTable1.ConveyanceCalColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'ConveyanceCal' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.ConveyanceCalColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public double EducationCal
		{
			get
			{
				try
				{
					return (double)base[tableDataTable1.EducationCalColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'EducationCal' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.EducationCalColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public double MedicalCal
		{
			get
			{
				try
				{
					return (double)base[tableDataTable1.MedicalCalColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'MedicalCal' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.MedicalCalColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public double GrossTotalCal
		{
			get
			{
				try
				{
					return (double)base[tableDataTable1.GrossTotalCalColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'GrossTotalCal' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.GrossTotalCalColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public int AttBonusType
		{
			get
			{
				try
				{
					return (int)base[tableDataTable1.AttBonusTypeColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'AttBonusType' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.AttBonusTypeColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public double AttBonusAmt
		{
			get
			{
				try
				{
					return (double)base[tableDataTable1.AttBonusAmtColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'AttBonusAmt' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.AttBonusAmtColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string PFNo
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.PFNoColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'PFNo' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.PFNoColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string PANNo
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.PANNoColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'PANNo' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.PANNoColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public double OTHrs1
		{
			get
			{
				try
				{
					return (double)base[tableDataTable1.OTHrs1Column];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'OTHrs1' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.OTHrs1Column] = value;
			}
		}

		[DebuggerNonUserCode]
		public double OTRate
		{
			get
			{
				try
				{
					return (double)base[tableDataTable1.OTRateColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'OTRate' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.OTRateColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string Path
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.PathColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Path' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.PathColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		internal DataTable1Row(DataRowBuilder rb)
			: base(rb)
		{
			tableDataTable1 = (DataTable1DataTable)base.Table;
		}

		[DebuggerNonUserCode]
		public bool IsEmpIdNull()
		{
			return IsNull(tableDataTable1.EmpIdColumn);
		}

		[DebuggerNonUserCode]
		public void SetEmpIdNull()
		{
			base[tableDataTable1.EmpIdColumn] = Convert.DBNull;
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
		public bool IsEmployeeNameNull()
		{
			return IsNull(tableDataTable1.EmployeeNameColumn);
		}

		[DebuggerNonUserCode]
		public void SetEmployeeNameNull()
		{
			base[tableDataTable1.EmployeeNameColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsMonthNull()
		{
			return IsNull(tableDataTable1.MonthColumn);
		}

		[DebuggerNonUserCode]
		public void SetMonthNull()
		{
			base[tableDataTable1.MonthColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsYearNull()
		{
			return IsNull(tableDataTable1.YearColumn);
		}

		[DebuggerNonUserCode]
		public void SetYearNull()
		{
			base[tableDataTable1.YearColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsDeptNull()
		{
			return IsNull(tableDataTable1.DeptColumn);
		}

		[DebuggerNonUserCode]
		public void SetDeptNull()
		{
			base[tableDataTable1.DeptColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsDesignationNull()
		{
			return IsNull(tableDataTable1.DesignationColumn);
		}

		[DebuggerNonUserCode]
		public void SetDesignationNull()
		{
			base[tableDataTable1.DesignationColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsStatusNull()
		{
			return IsNull(tableDataTable1.StatusColumn);
		}

		[DebuggerNonUserCode]
		public void SetStatusNull()
		{
			base[tableDataTable1.StatusColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsGradeNull()
		{
			return IsNull(tableDataTable1.GradeColumn);
		}

		[DebuggerNonUserCode]
		public void SetGradeNull()
		{
			base[tableDataTable1.GradeColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsBasicNull()
		{
			return IsNull(tableDataTable1.BasicColumn);
		}

		[DebuggerNonUserCode]
		public void SetBasicNull()
		{
			base[tableDataTable1.BasicColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsDANull()
		{
			return IsNull(tableDataTable1.DAColumn);
		}

		[DebuggerNonUserCode]
		public void SetDANull()
		{
			base[tableDataTable1.DAColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsHRANull()
		{
			return IsNull(tableDataTable1.HRAColumn);
		}

		[DebuggerNonUserCode]
		public void SetHRANull()
		{
			base[tableDataTable1.HRAColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsConveyanceNull()
		{
			return IsNull(tableDataTable1.ConveyanceColumn);
		}

		[DebuggerNonUserCode]
		public void SetConveyanceNull()
		{
			base[tableDataTable1.ConveyanceColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsEducationNull()
		{
			return IsNull(tableDataTable1.EducationColumn);
		}

		[DebuggerNonUserCode]
		public void SetEducationNull()
		{
			base[tableDataTable1.EducationColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsMedicalNull()
		{
			return IsNull(tableDataTable1.MedicalColumn);
		}

		[DebuggerNonUserCode]
		public void SetMedicalNull()
		{
			base[tableDataTable1.MedicalColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsSundayPNull()
		{
			return IsNull(tableDataTable1.SundayPColumn);
		}

		[DebuggerNonUserCode]
		public void SetSundayPNull()
		{
			base[tableDataTable1.SundayPColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsGrossTotalNull()
		{
			return IsNull(tableDataTable1.GrossTotalColumn);
		}

		[DebuggerNonUserCode]
		public void SetGrossTotalNull()
		{
			base[tableDataTable1.GrossTotalColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsAttendanceBonusNull()
		{
			return IsNull(tableDataTable1.AttendanceBonusColumn);
		}

		[DebuggerNonUserCode]
		public void SetAttendanceBonusNull()
		{
			base[tableDataTable1.AttendanceBonusColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsSpecialAllowanceNull()
		{
			return IsNull(tableDataTable1.SpecialAllowanceColumn);
		}

		[DebuggerNonUserCode]
		public void SetSpecialAllowanceNull()
		{
			base[tableDataTable1.SpecialAllowanceColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsExGratiaNull()
		{
			return IsNull(tableDataTable1.ExGratiaColumn);
		}

		[DebuggerNonUserCode]
		public void SetExGratiaNull()
		{
			base[tableDataTable1.ExGratiaColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsTravellingAllowanceNull()
		{
			return IsNull(tableDataTable1.TravellingAllowanceColumn);
		}

		[DebuggerNonUserCode]
		public void SetTravellingAllowanceNull()
		{
			base[tableDataTable1.TravellingAllowanceColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsMiscellaneousNull()
		{
			return IsNull(tableDataTable1.MiscellaneousColumn);
		}

		[DebuggerNonUserCode]
		public void SetMiscellaneousNull()
		{
			base[tableDataTable1.MiscellaneousColumn] = Convert.DBNull;
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
		public bool IsNetPayNull()
		{
			return IsNull(tableDataTable1.NetPayColumn);
		}

		[DebuggerNonUserCode]
		public void SetNetPayNull()
		{
			base[tableDataTable1.NetPayColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsWorkingDaysNull()
		{
			return IsNull(tableDataTable1.WorkingDaysColumn);
		}

		[DebuggerNonUserCode]
		public void SetWorkingDaysNull()
		{
			base[tableDataTable1.WorkingDaysColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsPreasentDaysNull()
		{
			return IsNull(tableDataTable1.PreasentDaysColumn);
		}

		[DebuggerNonUserCode]
		public void SetPreasentDaysNull()
		{
			base[tableDataTable1.PreasentDaysColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsAbsentDaysNull()
		{
			return IsNull(tableDataTable1.AbsentDaysColumn);
		}

		[DebuggerNonUserCode]
		public void SetAbsentDaysNull()
		{
			base[tableDataTable1.AbsentDaysColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsSundayNull()
		{
			return IsNull(tableDataTable1.SundayColumn);
		}

		[DebuggerNonUserCode]
		public void SetSundayNull()
		{
			base[tableDataTable1.SundayColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsHolidayNull()
		{
			return IsNull(tableDataTable1.HolidayColumn);
		}

		[DebuggerNonUserCode]
		public void SetHolidayNull()
		{
			base[tableDataTable1.HolidayColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsLateInNull()
		{
			return IsNull(tableDataTable1.LateInColumn);
		}

		[DebuggerNonUserCode]
		public void SetLateInNull()
		{
			base[tableDataTable1.LateInColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsCoffNull()
		{
			return IsNull(tableDataTable1.CoffColumn);
		}

		[DebuggerNonUserCode]
		public void SetCoffNull()
		{
			base[tableDataTable1.CoffColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsHalfDaysNull()
		{
			return IsNull(tableDataTable1.HalfDaysColumn);
		}

		[DebuggerNonUserCode]
		public void SetHalfDaysNull()
		{
			base[tableDataTable1.HalfDaysColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsPLNull()
		{
			return IsNull(tableDataTable1.PLColumn);
		}

		[DebuggerNonUserCode]
		public void SetPLNull()
		{
			base[tableDataTable1.PLColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsLWPNull()
		{
			return IsNull(tableDataTable1.LWPColumn);
		}

		[DebuggerNonUserCode]
		public void SetLWPNull()
		{
			base[tableDataTable1.LWPColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsPFofEmployeeNull()
		{
			return IsNull(tableDataTable1.PFofEmployeeColumn);
		}

		[DebuggerNonUserCode]
		public void SetPFofEmployeeNull()
		{
			base[tableDataTable1.PFofEmployeeColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsPTaxNull()
		{
			return IsNull(tableDataTable1.PTaxColumn);
		}

		[DebuggerNonUserCode]
		public void SetPTaxNull()
		{
			base[tableDataTable1.PTaxColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsPersonalLoanInstallNull()
		{
			return IsNull(tableDataTable1.PersonalLoanInstallColumn);
		}

		[DebuggerNonUserCode]
		public void SetPersonalLoanInstallNull()
		{
			base[tableDataTable1.PersonalLoanInstallColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsMobileBillNull()
		{
			return IsNull(tableDataTable1.MobileBillColumn);
		}

		[DebuggerNonUserCode]
		public void SetMobileBillNull()
		{
			base[tableDataTable1.MobileBillColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsMiscellaneous2Null()
		{
			return IsNull(tableDataTable1.Miscellaneous2Column);
		}

		[DebuggerNonUserCode]
		public void SetMiscellaneous2Null()
		{
			base[tableDataTable1.Miscellaneous2Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsTotal2Null()
		{
			return IsNull(tableDataTable1.Total2Column);
		}

		[DebuggerNonUserCode]
		public void SetTotal2Null()
		{
			base[tableDataTable1.Total2Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsEmpACNoNull()
		{
			return IsNull(tableDataTable1.EmpACNoColumn);
		}

		[DebuggerNonUserCode]
		public void SetEmpACNoNull()
		{
			base[tableDataTable1.EmpACNoColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsDateNull()
		{
			return IsNull(tableDataTable1.DateColumn);
		}

		[DebuggerNonUserCode]
		public void SetDateNull()
		{
			base[tableDataTable1.DateColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsBasicCalNull()
		{
			return IsNull(tableDataTable1.BasicCalColumn);
		}

		[DebuggerNonUserCode]
		public void SetBasicCalNull()
		{
			base[tableDataTable1.BasicCalColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsDACalNull()
		{
			return IsNull(tableDataTable1.DACalColumn);
		}

		[DebuggerNonUserCode]
		public void SetDACalNull()
		{
			base[tableDataTable1.DACalColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsHRACalNull()
		{
			return IsNull(tableDataTable1.HRACalColumn);
		}

		[DebuggerNonUserCode]
		public void SetHRACalNull()
		{
			base[tableDataTable1.HRACalColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsConveyanceCalNull()
		{
			return IsNull(tableDataTable1.ConveyanceCalColumn);
		}

		[DebuggerNonUserCode]
		public void SetConveyanceCalNull()
		{
			base[tableDataTable1.ConveyanceCalColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsEducationCalNull()
		{
			return IsNull(tableDataTable1.EducationCalColumn);
		}

		[DebuggerNonUserCode]
		public void SetEducationCalNull()
		{
			base[tableDataTable1.EducationCalColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsMedicalCalNull()
		{
			return IsNull(tableDataTable1.MedicalCalColumn);
		}

		[DebuggerNonUserCode]
		public void SetMedicalCalNull()
		{
			base[tableDataTable1.MedicalCalColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsGrossTotalCalNull()
		{
			return IsNull(tableDataTable1.GrossTotalCalColumn);
		}

		[DebuggerNonUserCode]
		public void SetGrossTotalCalNull()
		{
			base[tableDataTable1.GrossTotalCalColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsAttBonusTypeNull()
		{
			return IsNull(tableDataTable1.AttBonusTypeColumn);
		}

		[DebuggerNonUserCode]
		public void SetAttBonusTypeNull()
		{
			base[tableDataTable1.AttBonusTypeColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsAttBonusAmtNull()
		{
			return IsNull(tableDataTable1.AttBonusAmtColumn);
		}

		[DebuggerNonUserCode]
		public void SetAttBonusAmtNull()
		{
			base[tableDataTable1.AttBonusAmtColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsPFNoNull()
		{
			return IsNull(tableDataTable1.PFNoColumn);
		}

		[DebuggerNonUserCode]
		public void SetPFNoNull()
		{
			base[tableDataTable1.PFNoColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsPANNoNull()
		{
			return IsNull(tableDataTable1.PANNoColumn);
		}

		[DebuggerNonUserCode]
		public void SetPANNoNull()
		{
			base[tableDataTable1.PANNoColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsOTHrs1Null()
		{
			return IsNull(tableDataTable1.OTHrs1Column);
		}

		[DebuggerNonUserCode]
		public void SetOTHrs1Null()
		{
			base[tableDataTable1.OTHrs1Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsOTRateNull()
		{
			return IsNull(tableDataTable1.OTRateColumn);
		}

		[DebuggerNonUserCode]
		public void SetOTRateNull()
		{
			base[tableDataTable1.OTRateColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsPathNull()
		{
			return IsNull(tableDataTable1.PathColumn);
		}

		[DebuggerNonUserCode]
		public void SetPathNull()
		{
			base[tableDataTable1.PathColumn] = Convert.DBNull;
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

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[DebuggerNonUserCode]
	public new DataRelationCollection Relations => base.Relations;

	[DebuggerNonUserCode]
	public Salary()
	{
		BeginInit();
		InitClass();
		CollectionChangeEventHandler value = SchemaChanged;
		base.Tables.CollectionChanged += value;
		base.Relations.CollectionChanged += value;
		EndInit();
	}

	[DebuggerNonUserCode]
	protected Salary(SerializationInfo info, StreamingContext context)
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
		Salary salary = (Salary)base.Clone();
		salary.InitVars();
		salary.SchemaSerializationMode = SchemaSerializationMode;
		return salary;
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
		base.DataSetName = "Salary";
		base.Prefix = "";
		base.Namespace = "http://tempuri.org/Salary.xsd";
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
		Salary salary = new Salary();
		XmlSchemaComplexType xmlSchemaComplexType = new XmlSchemaComplexType();
		XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
		XmlSchemaAny xmlSchemaAny = new XmlSchemaAny();
		xmlSchemaAny.Namespace = salary.Namespace;
		xmlSchemaSequence.Items.Add(xmlSchemaAny);
		xmlSchemaComplexType.Particle = xmlSchemaSequence;
		XmlSchema schemaSerializable = salary.GetSchemaSerializable();
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
