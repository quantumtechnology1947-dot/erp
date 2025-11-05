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
[HelpKeyword("vs.data.DataSet")]
[DesignerCategory("code")]
[ToolboxItem(true)]
[XmlSchemaProvider("GetTypedDataSetSchema")]
[XmlRoot("IncrementLetter")]
public class IncrementLetter : DataSet
{
	public delegate void DataTable1RowChangeEventHandler(object sender, DataTable1RowChangeEvent e);

	public delegate void DataTable2RowChangeEventHandler(object sender, DataTable2RowChangeEvent e);

	[Serializable]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
	[XmlSchemaProvider("GetTypedTableSchema")]
	public class DataTable1DataTable : TypedTableBase<DataTable1Row>
	{
		private DataColumn columnOfferId;

		private DataColumn columnCompId;

		private DataColumn columnEmployeeName;

		private DataColumn columnStaffType;

		private DataColumn columnTypeOf;

		private DataColumn columnsalary;

		private DataColumn columnDutyHrs;

		private DataColumn columnOTHrs;

		private DataColumn columnOverTime;

		private DataColumn columnInterviewedBy;

		private DataColumn columnAuthorizedBy;

		private DataColumn columnReferenceBy;

		private DataColumn columnDesignation;

		private DataColumn columnExGratia;

		private DataColumn columnVehicleAllowance;

		private DataColumn columnLTA;

		private DataColumn columnLoyalty;

		private DataColumn columnPaidLeaves;

		private DataColumn columnRemarks;

		private DataColumn columnHeaderText;

		private DataColumn columnFooterText;

		private DataColumn columnSysDate;

		private DataColumn columnPerMonth;

		private DataColumn columnPerMonthA;

		private DataColumn columnBasic;

		private DataColumn columnBasicA;

		private DataColumn columnDA;

		private DataColumn columnDAA;

		private DataColumn columnHRA;

		private DataColumn columnHRAA;

		private DataColumn columnConveyance;

		private DataColumn columnConveyanceA;

		private DataColumn columnEducation;

		private DataColumn columnEducationA;

		private DataColumn columnMedicalAllowance;

		private DataColumn columnMedicalAllowanceA;

		private DataColumn columnAttendanceBonus;

		private DataColumn columnAttendanceBonusA;

		private DataColumn columnExGratiaA;

		private DataColumn columnTakeHomeINR;

		private DataColumn columnTakeHomeWithAttend1;

		private DataColumn columnTakeHomeWithAttend2;

		private DataColumn columnLoyaltyBenefitA;

		private DataColumn columnLTAA;

		private DataColumn columnPFE;

		private DataColumn columnPFEA;

		private DataColumn columnPFC;

		private DataColumn columnPFCA;

		private DataColumn columnBonus;

		private DataColumn columnBonusA;

		private DataColumn columnGratuity;

		private DataColumn columnGratuityA;

		private DataColumn columnVehicleAllowanceA;

		private DataColumn columnCTCinINR;

		private DataColumn columnCTCinINRA;

		private DataColumn columnCTCinINRwithAttendBonus1;

		private DataColumn columnCTCinINRwithAttendBonus1A;

		private DataColumn columnCTCinINRwithAttendBonus2;

		private DataColumn columnCTCinINRwithAttendBonus2A;

		private DataColumn columnAttBonPer;

		private DataColumn columnAttBonPer2;

		private DataColumn columnAttendanceBonus2;

		private DataColumn columnAttendanceBonusB;

		private DataColumn columnPFEmployee;

		private DataColumn columnPFCompany;

		private DataColumn columnIncrementForTheYear;

		private DataColumn columnEffectFrom;

		private DataColumn _columnOFYear_;

		private DataColumn _columnGrade_;

		private DataColumn _columnGradeI_;

		private DataColumn _columnDesignation_;

		private DataColumn _columnExGratia_;

		private DataColumn _columnVehicleAllowance_;

		private DataColumn _columnLTA_;

		private DataColumn _columnLoyalty_;

		private DataColumn _columnPerMonth_;

		private DataColumn _columnBasic_;

		private DataColumn _columnDA_;

		private DataColumn _columnHRA_;

		private DataColumn _columnConveyance_;

		private DataColumn _columnEducation_;

		private DataColumn _columnMedicalAllowance_;

		private DataColumn _columnAttendanceBonus_;

		private DataColumn _columnAttendanceBonus2_;

		private DataColumn _columnTakeHomeINR_;

		private DataColumn _columnTakeHomeWithAttend1_;

		private DataColumn _columnTakeHomeWithAttend2_;

		private DataColumn _columnPFE_;

		private DataColumn _columnPFC_;

		private DataColumn _columnBonus_;

		private DataColumn _columnGratuity_;

		private DataColumn _columnCTCinINR_;

		private DataColumn _columnCTCinINRwithAttendBonus1_;

		private DataColumn _columnCTCinINRwithAttendBonus2_;

		private DataColumn columnId;

		[DebuggerNonUserCode]
		public DataColumn OfferIdColumn => columnOfferId;

		[DebuggerNonUserCode]
		public DataColumn CompIdColumn => columnCompId;

		[DebuggerNonUserCode]
		public DataColumn EmployeeNameColumn => columnEmployeeName;

		[DebuggerNonUserCode]
		public DataColumn StaffTypeColumn => columnStaffType;

		[DebuggerNonUserCode]
		public DataColumn TypeOfColumn => columnTypeOf;

		[DebuggerNonUserCode]
		public DataColumn salaryColumn => columnsalary;

		[DebuggerNonUserCode]
		public DataColumn DutyHrsColumn => columnDutyHrs;

		[DebuggerNonUserCode]
		public DataColumn OTHrsColumn => columnOTHrs;

		[DebuggerNonUserCode]
		public DataColumn OverTimeColumn => columnOverTime;

		[DebuggerNonUserCode]
		public DataColumn InterviewedByColumn => columnInterviewedBy;

		[DebuggerNonUserCode]
		public DataColumn AuthorizedByColumn => columnAuthorizedBy;

		[DebuggerNonUserCode]
		public DataColumn ReferenceByColumn => columnReferenceBy;

		[DebuggerNonUserCode]
		public DataColumn DesignationColumn => columnDesignation;

		[DebuggerNonUserCode]
		public DataColumn ExGratiaColumn => columnExGratia;

		[DebuggerNonUserCode]
		public DataColumn VehicleAllowanceColumn => columnVehicleAllowance;

		[DebuggerNonUserCode]
		public DataColumn LTAColumn => columnLTA;

		[DebuggerNonUserCode]
		public DataColumn LoyaltyColumn => columnLoyalty;

		[DebuggerNonUserCode]
		public DataColumn PaidLeavesColumn => columnPaidLeaves;

		[DebuggerNonUserCode]
		public DataColumn RemarksColumn => columnRemarks;

		[DebuggerNonUserCode]
		public DataColumn HeaderTextColumn => columnHeaderText;

		[DebuggerNonUserCode]
		public DataColumn FooterTextColumn => columnFooterText;

		[DebuggerNonUserCode]
		public DataColumn SysDateColumn => columnSysDate;

		[DebuggerNonUserCode]
		public DataColumn PerMonthColumn => columnPerMonth;

		[DebuggerNonUserCode]
		public DataColumn PerMonthAColumn => columnPerMonthA;

		[DebuggerNonUserCode]
		public DataColumn BasicColumn => columnBasic;

		[DebuggerNonUserCode]
		public DataColumn BasicAColumn => columnBasicA;

		[DebuggerNonUserCode]
		public DataColumn DAColumn => columnDA;

		[DebuggerNonUserCode]
		public DataColumn DAAColumn => columnDAA;

		[DebuggerNonUserCode]
		public DataColumn HRAColumn => columnHRA;

		[DebuggerNonUserCode]
		public DataColumn HRAAColumn => columnHRAA;

		[DebuggerNonUserCode]
		public DataColumn ConveyanceColumn => columnConveyance;

		[DebuggerNonUserCode]
		public DataColumn ConveyanceAColumn => columnConveyanceA;

		[DebuggerNonUserCode]
		public DataColumn EducationColumn => columnEducation;

		[DebuggerNonUserCode]
		public DataColumn EducationAColumn => columnEducationA;

		[DebuggerNonUserCode]
		public DataColumn MedicalAllowanceColumn => columnMedicalAllowance;

		[DebuggerNonUserCode]
		public DataColumn MedicalAllowanceAColumn => columnMedicalAllowanceA;

		[DebuggerNonUserCode]
		public DataColumn AttendanceBonusColumn => columnAttendanceBonus;

		[DebuggerNonUserCode]
		public DataColumn AttendanceBonusAColumn => columnAttendanceBonusA;

		[DebuggerNonUserCode]
		public DataColumn ExGratiaAColumn => columnExGratiaA;

		[DebuggerNonUserCode]
		public DataColumn TakeHomeINRColumn => columnTakeHomeINR;

		[DebuggerNonUserCode]
		public DataColumn TakeHomeWithAttend1Column => columnTakeHomeWithAttend1;

		[DebuggerNonUserCode]
		public DataColumn TakeHomeWithAttend2Column => columnTakeHomeWithAttend2;

		[DebuggerNonUserCode]
		public DataColumn LoyaltyBenefitAColumn => columnLoyaltyBenefitA;

		[DebuggerNonUserCode]
		public DataColumn LTAAColumn => columnLTAA;

		[DebuggerNonUserCode]
		public DataColumn PFEColumn => columnPFE;

		[DebuggerNonUserCode]
		public DataColumn PFEAColumn => columnPFEA;

		[DebuggerNonUserCode]
		public DataColumn PFCColumn => columnPFC;

		[DebuggerNonUserCode]
		public DataColumn PFCAColumn => columnPFCA;

		[DebuggerNonUserCode]
		public DataColumn BonusColumn => columnBonus;

		[DebuggerNonUserCode]
		public DataColumn BonusAColumn => columnBonusA;

		[DebuggerNonUserCode]
		public DataColumn GratuityColumn => columnGratuity;

		[DebuggerNonUserCode]
		public DataColumn GratuityAColumn => columnGratuityA;

		[DebuggerNonUserCode]
		public DataColumn VehicleAllowanceAColumn => columnVehicleAllowanceA;

		[DebuggerNonUserCode]
		public DataColumn CTCinINRColumn => columnCTCinINR;

		[DebuggerNonUserCode]
		public DataColumn CTCinINRAColumn => columnCTCinINRA;

		[DebuggerNonUserCode]
		public DataColumn CTCinINRwithAttendBonus1Column => columnCTCinINRwithAttendBonus1;

		[DebuggerNonUserCode]
		public DataColumn CTCinINRwithAttendBonus1AColumn => columnCTCinINRwithAttendBonus1A;

		[DebuggerNonUserCode]
		public DataColumn CTCinINRwithAttendBonus2Column => columnCTCinINRwithAttendBonus2;

		[DebuggerNonUserCode]
		public DataColumn CTCinINRwithAttendBonus2AColumn => columnCTCinINRwithAttendBonus2A;

		[DebuggerNonUserCode]
		public DataColumn AttBonPerColumn => columnAttBonPer;

		[DebuggerNonUserCode]
		public DataColumn AttBonPer2Column => columnAttBonPer2;

		[DebuggerNonUserCode]
		public DataColumn AttendanceBonus2Column => columnAttendanceBonus2;

		[DebuggerNonUserCode]
		public DataColumn AttendanceBonusBColumn => columnAttendanceBonusB;

		[DebuggerNonUserCode]
		public DataColumn PFEmployeeColumn => columnPFEmployee;

		[DebuggerNonUserCode]
		public DataColumn PFCompanyColumn => columnPFCompany;

		[DebuggerNonUserCode]
		public DataColumn IncrementForTheYearColumn => columnIncrementForTheYear;

		[DebuggerNonUserCode]
		public DataColumn EffectFromColumn => columnEffectFrom;

		[DebuggerNonUserCode]
		public DataColumn _OFYear_Column => _columnOFYear_;

		[DebuggerNonUserCode]
		public DataColumn _Grade_Column => _columnGrade_;

		[DebuggerNonUserCode]
		public DataColumn _GradeI_Column => _columnGradeI_;

		[DebuggerNonUserCode]
		public DataColumn _Designation_Column => _columnDesignation_;

		[DebuggerNonUserCode]
		public DataColumn _ExGratia_Column => _columnExGratia_;

		[DebuggerNonUserCode]
		public DataColumn _VehicleAllowance_Column => _columnVehicleAllowance_;

		[DebuggerNonUserCode]
		public DataColumn _LTA_Column => _columnLTA_;

		[DebuggerNonUserCode]
		public DataColumn _Loyalty_Column => _columnLoyalty_;

		[DebuggerNonUserCode]
		public DataColumn _PerMonth_Column => _columnPerMonth_;

		[DebuggerNonUserCode]
		public DataColumn _Basic_Column => _columnBasic_;

		[DebuggerNonUserCode]
		public DataColumn _DA_Column => _columnDA_;

		[DebuggerNonUserCode]
		public DataColumn _HRA_Column => _columnHRA_;

		[DebuggerNonUserCode]
		public DataColumn _Conveyance_Column => _columnConveyance_;

		[DebuggerNonUserCode]
		public DataColumn _Education_Column => _columnEducation_;

		[DebuggerNonUserCode]
		public DataColumn _MedicalAllowance_Column => _columnMedicalAllowance_;

		[DebuggerNonUserCode]
		public DataColumn _AttendanceBonus_Column => _columnAttendanceBonus_;

		[DebuggerNonUserCode]
		public DataColumn _AttendanceBonus2_Column => _columnAttendanceBonus2_;

		[DebuggerNonUserCode]
		public DataColumn _TakeHomeINR_Column => _columnTakeHomeINR_;

		[DebuggerNonUserCode]
		public DataColumn _TakeHomeWithAttend1_Column => _columnTakeHomeWithAttend1_;

		[DebuggerNonUserCode]
		public DataColumn _TakeHomeWithAttend2_Column => _columnTakeHomeWithAttend2_;

		[DebuggerNonUserCode]
		public DataColumn _PFE_Column => _columnPFE_;

		[DebuggerNonUserCode]
		public DataColumn _PFC_Column => _columnPFC_;

		[DebuggerNonUserCode]
		public DataColumn _Bonus_Column => _columnBonus_;

		[DebuggerNonUserCode]
		public DataColumn _Gratuity_Column => _columnGratuity_;

		[DebuggerNonUserCode]
		public DataColumn _CTCinINR_Column => _columnCTCinINR_;

		[DebuggerNonUserCode]
		public DataColumn _CTCinINRwithAttendBonus1_Column => _columnCTCinINRwithAttendBonus1_;

		[DebuggerNonUserCode]
		public DataColumn _CTCinINRwithAttendBonus2_Column => _columnCTCinINRwithAttendBonus2_;

		[DebuggerNonUserCode]
		public DataColumn IdColumn => columnId;

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
		public DataTable1Row AddDataTable1Row(int OfferId, int CompId, string EmployeeName, string StaffType, int TypeOf, double salary, string DutyHrs, string OTHrs, string OverTime, string InterviewedBy, string AuthorizedBy, string ReferenceBy, string Designation, double ExGratia, double VehicleAllowance, double LTA, double Loyalty, double PaidLeaves, string Remarks, string HeaderText, string FooterText, string SysDate, double PerMonth, double PerMonthA, double Basic, double BasicA, double DA, double DAA, double HRA, double HRAA, double Conveyance, double ConveyanceA, double Education, double EducationA, double MedicalAllowance, double MedicalAllowanceA, double AttendanceBonus, double AttendanceBonusA, double ExGratiaA, double TakeHomeINR, double TakeHomeWithAttend1, double TakeHomeWithAttend2, double LoyaltyBenefitA, double LTAA, double PFE, double PFEA, double PFC, double PFCA, double Bonus, double BonusA, double Gratuity, double GratuityA, double VehicleAllowanceA, double CTCinINR, double CTCinINRA, double CTCinINRwithAttendBonus1, double CTCinINRwithAttendBonus1A, double CTCinINRwithAttendBonus2, double CTCinINRwithAttendBonus2A, string AttBonPer, string AttBonPer2, double AttendanceBonus2, double AttendanceBonusB, string PFEmployee, string PFCompany, string IncrementForTheYear, string EffectFrom, string _OFYear_, string _Grade_, string _GradeI_, string _Designation_, double _ExGratia_, double _VehicleAllowance_, double _LTA_, double _Loyalty_, double _PerMonth_, double _Basic_, double _DA_, double _HRA_, double _Conveyance_, double _Education_, double _MedicalAllowance_, double _AttendanceBonus_, double _AttendanceBonus2_, double _TakeHomeINR_, double _TakeHomeWithAttend1_, double _TakeHomeWithAttend2_, double _PFE_, double _PFC_, double _Bonus_, double _Gratuity_, double _CTCinINR_, double _CTCinINRwithAttendBonus1_, double _CTCinINRwithAttendBonus2_, int Id)
		{
			DataTable1Row dataTable1Row = (DataTable1Row)NewRow();
			object[] itemArray = new object[95]
			{
				OfferId, CompId, EmployeeName, StaffType, TypeOf, salary, DutyHrs, OTHrs, OverTime, InterviewedBy,
				AuthorizedBy, ReferenceBy, Designation, ExGratia, VehicleAllowance, LTA, Loyalty, PaidLeaves, Remarks, HeaderText,
				FooterText, SysDate, PerMonth, PerMonthA, Basic, BasicA, DA, DAA, HRA, HRAA,
				Conveyance, ConveyanceA, Education, EducationA, MedicalAllowance, MedicalAllowanceA, AttendanceBonus, AttendanceBonusA, ExGratiaA, TakeHomeINR,
				TakeHomeWithAttend1, TakeHomeWithAttend2, LoyaltyBenefitA, LTAA, PFE, PFEA, PFC, PFCA, Bonus, BonusA,
				Gratuity, GratuityA, VehicleAllowanceA, CTCinINR, CTCinINRA, CTCinINRwithAttendBonus1, CTCinINRwithAttendBonus1A, CTCinINRwithAttendBonus2, CTCinINRwithAttendBonus2A, AttBonPer,
				AttBonPer2, AttendanceBonus2, AttendanceBonusB, PFEmployee, PFCompany, IncrementForTheYear, EffectFrom, _OFYear_, _Grade_, _GradeI_,
				_Designation_, _ExGratia_, _VehicleAllowance_, _LTA_, _Loyalty_, _PerMonth_, _Basic_, _DA_, _HRA_, _Conveyance_,
				_Education_, _MedicalAllowance_, _AttendanceBonus_, _AttendanceBonus2_, _TakeHomeINR_, _TakeHomeWithAttend1_, _TakeHomeWithAttend2_, _PFE_, _PFC_, _Bonus_,
				_Gratuity_, _CTCinINR_, _CTCinINRwithAttendBonus1_, _CTCinINRwithAttendBonus2_, Id
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
			columnOfferId = base.Columns["OfferId"];
			columnCompId = base.Columns["CompId"];
			columnEmployeeName = base.Columns["EmployeeName"];
			columnStaffType = base.Columns["StaffType"];
			columnTypeOf = base.Columns["TypeOf"];
			columnsalary = base.Columns["salary"];
			columnDutyHrs = base.Columns["DutyHrs"];
			columnOTHrs = base.Columns["OTHrs"];
			columnOverTime = base.Columns["OverTime"];
			columnInterviewedBy = base.Columns["InterviewedBy"];
			columnAuthorizedBy = base.Columns["AuthorizedBy"];
			columnReferenceBy = base.Columns["ReferenceBy"];
			columnDesignation = base.Columns["Designation"];
			columnExGratia = base.Columns["ExGratia"];
			columnVehicleAllowance = base.Columns["VehicleAllowance"];
			columnLTA = base.Columns["LTA"];
			columnLoyalty = base.Columns["Loyalty"];
			columnPaidLeaves = base.Columns["PaidLeaves"];
			columnRemarks = base.Columns["Remarks"];
			columnHeaderText = base.Columns["HeaderText"];
			columnFooterText = base.Columns["FooterText"];
			columnSysDate = base.Columns["SysDate"];
			columnPerMonth = base.Columns["PerMonth"];
			columnPerMonthA = base.Columns["PerMonthA"];
			columnBasic = base.Columns["Basic"];
			columnBasicA = base.Columns["BasicA"];
			columnDA = base.Columns["DA"];
			columnDAA = base.Columns["DAA"];
			columnHRA = base.Columns["HRA"];
			columnHRAA = base.Columns["HRAA"];
			columnConveyance = base.Columns["Conveyance"];
			columnConveyanceA = base.Columns["ConveyanceA"];
			columnEducation = base.Columns["Education"];
			columnEducationA = base.Columns["EducationA"];
			columnMedicalAllowance = base.Columns["MedicalAllowance"];
			columnMedicalAllowanceA = base.Columns["MedicalAllowanceA"];
			columnAttendanceBonus = base.Columns["AttendanceBonus"];
			columnAttendanceBonusA = base.Columns["AttendanceBonusA"];
			columnExGratiaA = base.Columns["ExGratiaA"];
			columnTakeHomeINR = base.Columns["TakeHomeINR"];
			columnTakeHomeWithAttend1 = base.Columns["TakeHomeWithAttend1"];
			columnTakeHomeWithAttend2 = base.Columns["TakeHomeWithAttend2"];
			columnLoyaltyBenefitA = base.Columns["LoyaltyBenefitA"];
			columnLTAA = base.Columns["LTAA"];
			columnPFE = base.Columns["PFE"];
			columnPFEA = base.Columns["PFEA"];
			columnPFC = base.Columns["PFC"];
			columnPFCA = base.Columns["PFCA"];
			columnBonus = base.Columns["Bonus"];
			columnBonusA = base.Columns["BonusA"];
			columnGratuity = base.Columns["Gratuity"];
			columnGratuityA = base.Columns["GratuityA"];
			columnVehicleAllowanceA = base.Columns["VehicleAllowanceA"];
			columnCTCinINR = base.Columns["CTCinINR"];
			columnCTCinINRA = base.Columns["CTCinINRA"];
			columnCTCinINRwithAttendBonus1 = base.Columns["CTCinINRwithAttendBonus1"];
			columnCTCinINRwithAttendBonus1A = base.Columns["CTCinINRwithAttendBonus1A"];
			columnCTCinINRwithAttendBonus2 = base.Columns["CTCinINRwithAttendBonus2"];
			columnCTCinINRwithAttendBonus2A = base.Columns["CTCinINRwithAttendBonus2A"];
			columnAttBonPer = base.Columns["AttBonPer"];
			columnAttBonPer2 = base.Columns["AttBonPer2"];
			columnAttendanceBonus2 = base.Columns["AttendanceBonus2"];
			columnAttendanceBonusB = base.Columns["AttendanceBonusB"];
			columnPFEmployee = base.Columns["PFEmployee"];
			columnPFCompany = base.Columns["PFCompany"];
			columnIncrementForTheYear = base.Columns["IncrementForTheYear"];
			columnEffectFrom = base.Columns["EffectFrom"];
			_columnOFYear_ = base.Columns["OFYear*"];
			_columnGrade_ = base.Columns["Grade*"];
			_columnGradeI_ = base.Columns["GradeI*"];
			_columnDesignation_ = base.Columns["Designation*"];
			_columnExGratia_ = base.Columns["ExGratia*"];
			_columnVehicleAllowance_ = base.Columns["VehicleAllowance*"];
			_columnLTA_ = base.Columns["LTA*"];
			_columnLoyalty_ = base.Columns["Loyalty*"];
			_columnPerMonth_ = base.Columns["PerMonth*"];
			_columnBasic_ = base.Columns["Basic*"];
			_columnDA_ = base.Columns["DA*"];
			_columnHRA_ = base.Columns["HRA*"];
			_columnConveyance_ = base.Columns["Conveyance*"];
			_columnEducation_ = base.Columns["Education*"];
			_columnMedicalAllowance_ = base.Columns["MedicalAllowance*"];
			_columnAttendanceBonus_ = base.Columns["AttendanceBonus*"];
			_columnAttendanceBonus2_ = base.Columns["AttendanceBonus2*"];
			_columnTakeHomeINR_ = base.Columns["TakeHomeINR*"];
			_columnTakeHomeWithAttend1_ = base.Columns["TakeHomeWithAttend1*"];
			_columnTakeHomeWithAttend2_ = base.Columns["TakeHomeWithAttend2*"];
			_columnPFE_ = base.Columns["PFE*"];
			_columnPFC_ = base.Columns["PFC*"];
			_columnBonus_ = base.Columns["Bonus*"];
			_columnGratuity_ = base.Columns["Gratuity*"];
			_columnCTCinINR_ = base.Columns["CTCinINR*"];
			_columnCTCinINRwithAttendBonus1_ = base.Columns["CTCinINRwithAttendBonus1*"];
			_columnCTCinINRwithAttendBonus2_ = base.Columns["CTCinINRwithAttendBonus2*"];
			columnId = base.Columns["Id"];
		}

		[DebuggerNonUserCode]
		private void InitClass()
		{
			columnOfferId = new DataColumn("OfferId", typeof(int), null, MappingType.Element);
			base.Columns.Add(columnOfferId);
			columnCompId = new DataColumn("CompId", typeof(int), null, MappingType.Element);
			base.Columns.Add(columnCompId);
			columnEmployeeName = new DataColumn("EmployeeName", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnEmployeeName);
			columnStaffType = new DataColumn("StaffType", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnStaffType);
			columnTypeOf = new DataColumn("TypeOf", typeof(int), null, MappingType.Element);
			base.Columns.Add(columnTypeOf);
			columnsalary = new DataColumn("salary", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnsalary);
			columnDutyHrs = new DataColumn("DutyHrs", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnDutyHrs);
			columnOTHrs = new DataColumn("OTHrs", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnOTHrs);
			columnOverTime = new DataColumn("OverTime", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnOverTime);
			columnInterviewedBy = new DataColumn("InterviewedBy", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnInterviewedBy);
			columnAuthorizedBy = new DataColumn("AuthorizedBy", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnAuthorizedBy);
			columnReferenceBy = new DataColumn("ReferenceBy", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnReferenceBy);
			columnDesignation = new DataColumn("Designation", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnDesignation);
			columnExGratia = new DataColumn("ExGratia", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnExGratia);
			columnVehicleAllowance = new DataColumn("VehicleAllowance", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnVehicleAllowance);
			columnLTA = new DataColumn("LTA", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnLTA);
			columnLoyalty = new DataColumn("Loyalty", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnLoyalty);
			columnPaidLeaves = new DataColumn("PaidLeaves", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnPaidLeaves);
			columnRemarks = new DataColumn("Remarks", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnRemarks);
			columnHeaderText = new DataColumn("HeaderText", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnHeaderText);
			columnFooterText = new DataColumn("FooterText", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnFooterText);
			columnSysDate = new DataColumn("SysDate", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnSysDate);
			columnPerMonth = new DataColumn("PerMonth", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnPerMonth);
			columnPerMonthA = new DataColumn("PerMonthA", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnPerMonthA);
			columnBasic = new DataColumn("Basic", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnBasic);
			columnBasicA = new DataColumn("BasicA", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnBasicA);
			columnDA = new DataColumn("DA", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnDA);
			columnDAA = new DataColumn("DAA", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnDAA);
			columnHRA = new DataColumn("HRA", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnHRA);
			columnHRAA = new DataColumn("HRAA", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnHRAA);
			columnConveyance = new DataColumn("Conveyance", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnConveyance);
			columnConveyanceA = new DataColumn("ConveyanceA", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnConveyanceA);
			columnEducation = new DataColumn("Education", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnEducation);
			columnEducationA = new DataColumn("EducationA", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnEducationA);
			columnMedicalAllowance = new DataColumn("MedicalAllowance", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnMedicalAllowance);
			columnMedicalAllowanceA = new DataColumn("MedicalAllowanceA", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnMedicalAllowanceA);
			columnAttendanceBonus = new DataColumn("AttendanceBonus", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnAttendanceBonus);
			columnAttendanceBonusA = new DataColumn("AttendanceBonusA", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnAttendanceBonusA);
			columnExGratiaA = new DataColumn("ExGratiaA", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnExGratiaA);
			columnTakeHomeINR = new DataColumn("TakeHomeINR", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnTakeHomeINR);
			columnTakeHomeWithAttend1 = new DataColumn("TakeHomeWithAttend1", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnTakeHomeWithAttend1);
			columnTakeHomeWithAttend2 = new DataColumn("TakeHomeWithAttend2", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnTakeHomeWithAttend2);
			columnLoyaltyBenefitA = new DataColumn("LoyaltyBenefitA", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnLoyaltyBenefitA);
			columnLTAA = new DataColumn("LTAA", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnLTAA);
			columnPFE = new DataColumn("PFE", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnPFE);
			columnPFEA = new DataColumn("PFEA", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnPFEA);
			columnPFC = new DataColumn("PFC", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnPFC);
			columnPFCA = new DataColumn("PFCA", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnPFCA);
			columnBonus = new DataColumn("Bonus", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnBonus);
			columnBonusA = new DataColumn("BonusA", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnBonusA);
			columnGratuity = new DataColumn("Gratuity", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnGratuity);
			columnGratuityA = new DataColumn("GratuityA", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnGratuityA);
			columnVehicleAllowanceA = new DataColumn("VehicleAllowanceA", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnVehicleAllowanceA);
			columnCTCinINR = new DataColumn("CTCinINR", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnCTCinINR);
			columnCTCinINRA = new DataColumn("CTCinINRA", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnCTCinINRA);
			columnCTCinINRwithAttendBonus1 = new DataColumn("CTCinINRwithAttendBonus1", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnCTCinINRwithAttendBonus1);
			columnCTCinINRwithAttendBonus1A = new DataColumn("CTCinINRwithAttendBonus1A", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnCTCinINRwithAttendBonus1A);
			columnCTCinINRwithAttendBonus2 = new DataColumn("CTCinINRwithAttendBonus2", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnCTCinINRwithAttendBonus2);
			columnCTCinINRwithAttendBonus2A = new DataColumn("CTCinINRwithAttendBonus2A", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnCTCinINRwithAttendBonus2A);
			columnAttBonPer = new DataColumn("AttBonPer", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnAttBonPer);
			columnAttBonPer2 = new DataColumn("AttBonPer2", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnAttBonPer2);
			columnAttendanceBonus2 = new DataColumn("AttendanceBonus2", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnAttendanceBonus2);
			columnAttendanceBonusB = new DataColumn("AttendanceBonusB", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnAttendanceBonusB);
			columnPFEmployee = new DataColumn("PFEmployee", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnPFEmployee);
			columnPFCompany = new DataColumn("PFCompany", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnPFCompany);
			columnIncrementForTheYear = new DataColumn("IncrementForTheYear", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnIncrementForTheYear);
			columnEffectFrom = new DataColumn("EffectFrom", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnEffectFrom);
			_columnOFYear_ = new DataColumn("OFYear*", typeof(string), null, MappingType.Element);
			_columnOFYear_.ExtendedProperties.Add("Generator_ColumnVarNameInTable", "_columnOFYear_");
			_columnOFYear_.ExtendedProperties.Add("Generator_UserColumnName", "OFYear*");
			base.Columns.Add(_columnOFYear_);
			_columnGrade_ = new DataColumn("Grade*", typeof(string), null, MappingType.Element);
			_columnGrade_.ExtendedProperties.Add("Generator_ColumnVarNameInTable", "_columnGrade_");
			_columnGrade_.ExtendedProperties.Add("Generator_UserColumnName", "Grade*");
			base.Columns.Add(_columnGrade_);
			_columnGradeI_ = new DataColumn("GradeI*", typeof(string), null, MappingType.Element);
			_columnGradeI_.ExtendedProperties.Add("Generator_ColumnVarNameInTable", "_columnGradeI_");
			_columnGradeI_.ExtendedProperties.Add("Generator_UserColumnName", "GradeI*");
			base.Columns.Add(_columnGradeI_);
			_columnDesignation_ = new DataColumn("Designation*", typeof(string), null, MappingType.Element);
			_columnDesignation_.ExtendedProperties.Add("Generator_ColumnVarNameInTable", "_columnDesignation_");
			_columnDesignation_.ExtendedProperties.Add("Generator_UserColumnName", "Designation*");
			base.Columns.Add(_columnDesignation_);
			_columnExGratia_ = new DataColumn("ExGratia*", typeof(double), null, MappingType.Element);
			_columnExGratia_.ExtendedProperties.Add("Generator_ColumnVarNameInTable", "_columnExGratia_");
			_columnExGratia_.ExtendedProperties.Add("Generator_UserColumnName", "ExGratia*");
			base.Columns.Add(_columnExGratia_);
			_columnVehicleAllowance_ = new DataColumn("VehicleAllowance*", typeof(double), null, MappingType.Element);
			_columnVehicleAllowance_.ExtendedProperties.Add("Generator_ColumnVarNameInTable", "_columnVehicleAllowance_");
			_columnVehicleAllowance_.ExtendedProperties.Add("Generator_UserColumnName", "VehicleAllowance*");
			base.Columns.Add(_columnVehicleAllowance_);
			_columnLTA_ = new DataColumn("LTA*", typeof(double), null, MappingType.Element);
			_columnLTA_.ExtendedProperties.Add("Generator_ColumnVarNameInTable", "_columnLTA_");
			_columnLTA_.ExtendedProperties.Add("Generator_UserColumnName", "LTA*");
			base.Columns.Add(_columnLTA_);
			_columnLoyalty_ = new DataColumn("Loyalty*", typeof(double), null, MappingType.Element);
			_columnLoyalty_.ExtendedProperties.Add("Generator_ColumnVarNameInTable", "_columnLoyalty_");
			_columnLoyalty_.ExtendedProperties.Add("Generator_UserColumnName", "Loyalty*");
			base.Columns.Add(_columnLoyalty_);
			_columnPerMonth_ = new DataColumn("PerMonth*", typeof(double), null, MappingType.Element);
			_columnPerMonth_.ExtendedProperties.Add("Generator_ColumnVarNameInTable", "_columnPerMonth_");
			_columnPerMonth_.ExtendedProperties.Add("Generator_UserColumnName", "PerMonth*");
			base.Columns.Add(_columnPerMonth_);
			_columnBasic_ = new DataColumn("Basic*", typeof(double), null, MappingType.Element);
			_columnBasic_.ExtendedProperties.Add("Generator_ColumnVarNameInTable", "_columnBasic_");
			_columnBasic_.ExtendedProperties.Add("Generator_UserColumnName", "Basic*");
			base.Columns.Add(_columnBasic_);
			_columnDA_ = new DataColumn("DA*", typeof(double), null, MappingType.Element);
			_columnDA_.ExtendedProperties.Add("Generator_ColumnVarNameInTable", "_columnDA_");
			_columnDA_.ExtendedProperties.Add("Generator_UserColumnName", "DA*");
			base.Columns.Add(_columnDA_);
			_columnHRA_ = new DataColumn("HRA*", typeof(double), null, MappingType.Element);
			_columnHRA_.ExtendedProperties.Add("Generator_ColumnVarNameInTable", "_columnHRA_");
			_columnHRA_.ExtendedProperties.Add("Generator_UserColumnName", "HRA*");
			base.Columns.Add(_columnHRA_);
			_columnConveyance_ = new DataColumn("Conveyance*", typeof(double), null, MappingType.Element);
			_columnConveyance_.ExtendedProperties.Add("Generator_ColumnVarNameInTable", "_columnConveyance_");
			_columnConveyance_.ExtendedProperties.Add("Generator_UserColumnName", "Conveyance*");
			base.Columns.Add(_columnConveyance_);
			_columnEducation_ = new DataColumn("Education*", typeof(double), null, MappingType.Element);
			_columnEducation_.ExtendedProperties.Add("Generator_ColumnVarNameInTable", "_columnEducation_");
			_columnEducation_.ExtendedProperties.Add("Generator_UserColumnName", "Education*");
			base.Columns.Add(_columnEducation_);
			_columnMedicalAllowance_ = new DataColumn("MedicalAllowance*", typeof(double), null, MappingType.Element);
			_columnMedicalAllowance_.ExtendedProperties.Add("Generator_ColumnVarNameInTable", "_columnMedicalAllowance_");
			_columnMedicalAllowance_.ExtendedProperties.Add("Generator_UserColumnName", "MedicalAllowance*");
			base.Columns.Add(_columnMedicalAllowance_);
			_columnAttendanceBonus_ = new DataColumn("AttendanceBonus*", typeof(double), null, MappingType.Element);
			_columnAttendanceBonus_.ExtendedProperties.Add("Generator_ColumnVarNameInTable", "_columnAttendanceBonus_");
			_columnAttendanceBonus_.ExtendedProperties.Add("Generator_UserColumnName", "AttendanceBonus*");
			base.Columns.Add(_columnAttendanceBonus_);
			_columnAttendanceBonus2_ = new DataColumn("AttendanceBonus2*", typeof(double), null, MappingType.Element);
			_columnAttendanceBonus2_.ExtendedProperties.Add("Generator_ColumnVarNameInTable", "_columnAttendanceBonus2_");
			_columnAttendanceBonus2_.ExtendedProperties.Add("Generator_UserColumnName", "AttendanceBonus2*");
			base.Columns.Add(_columnAttendanceBonus2_);
			_columnTakeHomeINR_ = new DataColumn("TakeHomeINR*", typeof(double), null, MappingType.Element);
			_columnTakeHomeINR_.ExtendedProperties.Add("Generator_ColumnVarNameInTable", "_columnTakeHomeINR_");
			_columnTakeHomeINR_.ExtendedProperties.Add("Generator_UserColumnName", "TakeHomeINR*");
			base.Columns.Add(_columnTakeHomeINR_);
			_columnTakeHomeWithAttend1_ = new DataColumn("TakeHomeWithAttend1*", typeof(double), null, MappingType.Element);
			_columnTakeHomeWithAttend1_.ExtendedProperties.Add("Generator_ColumnVarNameInTable", "_columnTakeHomeWithAttend1_");
			_columnTakeHomeWithAttend1_.ExtendedProperties.Add("Generator_UserColumnName", "TakeHomeWithAttend1*");
			base.Columns.Add(_columnTakeHomeWithAttend1_);
			_columnTakeHomeWithAttend2_ = new DataColumn("TakeHomeWithAttend2*", typeof(double), null, MappingType.Element);
			_columnTakeHomeWithAttend2_.ExtendedProperties.Add("Generator_ColumnVarNameInTable", "_columnTakeHomeWithAttend2_");
			_columnTakeHomeWithAttend2_.ExtendedProperties.Add("Generator_UserColumnName", "TakeHomeWithAttend2*");
			base.Columns.Add(_columnTakeHomeWithAttend2_);
			_columnPFE_ = new DataColumn("PFE*", typeof(double), null, MappingType.Element);
			_columnPFE_.ExtendedProperties.Add("Generator_ColumnVarNameInTable", "_columnPFE_");
			_columnPFE_.ExtendedProperties.Add("Generator_UserColumnName", "PFE*");
			base.Columns.Add(_columnPFE_);
			_columnPFC_ = new DataColumn("PFC*", typeof(double), null, MappingType.Element);
			_columnPFC_.ExtendedProperties.Add("Generator_ColumnVarNameInTable", "_columnPFC_");
			_columnPFC_.ExtendedProperties.Add("Generator_UserColumnName", "PFC*");
			base.Columns.Add(_columnPFC_);
			_columnBonus_ = new DataColumn("Bonus*", typeof(double), null, MappingType.Element);
			_columnBonus_.ExtendedProperties.Add("Generator_ColumnVarNameInTable", "_columnBonus_");
			_columnBonus_.ExtendedProperties.Add("Generator_UserColumnName", "Bonus*");
			base.Columns.Add(_columnBonus_);
			_columnGratuity_ = new DataColumn("Gratuity*", typeof(double), null, MappingType.Element);
			_columnGratuity_.ExtendedProperties.Add("Generator_ColumnVarNameInTable", "_columnGratuity_");
			_columnGratuity_.ExtendedProperties.Add("Generator_UserColumnName", "Gratuity*");
			base.Columns.Add(_columnGratuity_);
			_columnCTCinINR_ = new DataColumn("CTCinINR*", typeof(double), null, MappingType.Element);
			_columnCTCinINR_.ExtendedProperties.Add("Generator_ColumnVarNameInTable", "_columnCTCinINR_");
			_columnCTCinINR_.ExtendedProperties.Add("Generator_UserColumnName", "CTCinINR*");
			base.Columns.Add(_columnCTCinINR_);
			_columnCTCinINRwithAttendBonus1_ = new DataColumn("CTCinINRwithAttendBonus1*", typeof(double), null, MappingType.Element);
			_columnCTCinINRwithAttendBonus1_.ExtendedProperties.Add("Generator_ColumnVarNameInTable", "_columnCTCinINRwithAttendBonus1_");
			_columnCTCinINRwithAttendBonus1_.ExtendedProperties.Add("Generator_UserColumnName", "CTCinINRwithAttendBonus1*");
			base.Columns.Add(_columnCTCinINRwithAttendBonus1_);
			_columnCTCinINRwithAttendBonus2_ = new DataColumn("CTCinINRwithAttendBonus2*", typeof(double), null, MappingType.Element);
			_columnCTCinINRwithAttendBonus2_.ExtendedProperties.Add("Generator_ColumnVarNameInTable", "_columnCTCinINRwithAttendBonus2_");
			_columnCTCinINRwithAttendBonus2_.ExtendedProperties.Add("Generator_UserColumnName", "CTCinINRwithAttendBonus2*");
			base.Columns.Add(_columnCTCinINRwithAttendBonus2_);
			columnId = new DataColumn("Id", typeof(int), null, MappingType.Element);
			base.Columns.Add(columnId);
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
			IncrementLetter incrementLetter = new IncrementLetter();
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
			xmlSchemaAttribute.FixedValue = incrementLetter.Namespace;
			xmlSchemaComplexType.Attributes.Add(xmlSchemaAttribute);
			XmlSchemaAttribute xmlSchemaAttribute2 = new XmlSchemaAttribute();
			xmlSchemaAttribute2.Name = "tableTypeName";
			xmlSchemaAttribute2.FixedValue = "DataTable1DataTable";
			xmlSchemaComplexType.Attributes.Add(xmlSchemaAttribute2);
			xmlSchemaComplexType.Particle = xmlSchemaSequence;
			XmlSchema schemaSerializable = incrementLetter.GetSchemaSerializable();
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
	public class DataTable2DataTable : TypedTableBase<DataTable2Row>
	{
		private DataColumn columnAccess_Perticulars;

		private DataColumn columnAccess_Amount;

		[DebuggerNonUserCode]
		public DataColumn Access_PerticularsColumn => columnAccess_Perticulars;

		[DebuggerNonUserCode]
		public DataColumn Access_AmountColumn => columnAccess_Amount;

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
		public DataTable2Row AddDataTable2Row(string Access_Perticulars, double Access_Amount)
		{
			DataTable2Row dataTable2Row = (DataTable2Row)NewRow();
			object[] itemArray = new object[2] { Access_Perticulars, Access_Amount };
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
			columnAccess_Perticulars = base.Columns["Access_Perticulars"];
			columnAccess_Amount = base.Columns["Access_Amount"];
		}

		[DebuggerNonUserCode]
		private void InitClass()
		{
			columnAccess_Perticulars = new DataColumn("Access_Perticulars", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnAccess_Perticulars);
			columnAccess_Amount = new DataColumn("Access_Amount", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnAccess_Amount);
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
			IncrementLetter incrementLetter = new IncrementLetter();
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
			xmlSchemaAttribute.FixedValue = incrementLetter.Namespace;
			xmlSchemaComplexType.Attributes.Add(xmlSchemaAttribute);
			XmlSchemaAttribute xmlSchemaAttribute2 = new XmlSchemaAttribute();
			xmlSchemaAttribute2.Name = "tableTypeName";
			xmlSchemaAttribute2.FixedValue = "DataTable2DataTable";
			xmlSchemaComplexType.Attributes.Add(xmlSchemaAttribute2);
			xmlSchemaComplexType.Particle = xmlSchemaSequence;
			XmlSchema schemaSerializable = incrementLetter.GetSchemaSerializable();
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
		public int OfferId
		{
			get
			{
				try
				{
					return (int)base[tableDataTable1.OfferIdColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'OfferId' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.OfferIdColumn] = value;
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
		public string StaffType
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.StaffTypeColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'StaffType' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.StaffTypeColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public int TypeOf
		{
			get
			{
				try
				{
					return (int)base[tableDataTable1.TypeOfColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'TypeOf' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.TypeOfColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public double salary
		{
			get
			{
				try
				{
					return (double)base[tableDataTable1.salaryColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'salary' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.salaryColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string DutyHrs
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.DutyHrsColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'DutyHrs' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.DutyHrsColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string OTHrs
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.OTHrsColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'OTHrs' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.OTHrsColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string OverTime
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.OverTimeColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'OverTime' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.OverTimeColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string InterviewedBy
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.InterviewedByColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'InterviewedBy' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.InterviewedByColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string AuthorizedBy
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.AuthorizedByColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'AuthorizedBy' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.AuthorizedByColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string ReferenceBy
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.ReferenceByColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'ReferenceBy' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.ReferenceByColumn] = value;
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
		public double VehicleAllowance
		{
			get
			{
				try
				{
					return (double)base[tableDataTable1.VehicleAllowanceColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'VehicleAllowance' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.VehicleAllowanceColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public double LTA
		{
			get
			{
				try
				{
					return (double)base[tableDataTable1.LTAColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'LTA' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.LTAColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public double Loyalty
		{
			get
			{
				try
				{
					return (double)base[tableDataTable1.LoyaltyColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Loyalty' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.LoyaltyColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public double PaidLeaves
		{
			get
			{
				try
				{
					return (double)base[tableDataTable1.PaidLeavesColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'PaidLeaves' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.PaidLeavesColumn] = value;
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
		public string HeaderText
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.HeaderTextColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'HeaderText' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.HeaderTextColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string FooterText
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.FooterTextColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'FooterText' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.FooterTextColumn] = value;
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
		public double PerMonth
		{
			get
			{
				try
				{
					return (double)base[tableDataTable1.PerMonthColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'PerMonth' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.PerMonthColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public double PerMonthA
		{
			get
			{
				try
				{
					return (double)base[tableDataTable1.PerMonthAColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'PerMonthA' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.PerMonthAColumn] = value;
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
		public double BasicA
		{
			get
			{
				try
				{
					return (double)base[tableDataTable1.BasicAColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'BasicA' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.BasicAColumn] = value;
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
		public double DAA
		{
			get
			{
				try
				{
					return (double)base[tableDataTable1.DAAColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'DAA' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.DAAColumn] = value;
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
		public double HRAA
		{
			get
			{
				try
				{
					return (double)base[tableDataTable1.HRAAColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'HRAA' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.HRAAColumn] = value;
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
		public double ConveyanceA
		{
			get
			{
				try
				{
					return (double)base[tableDataTable1.ConveyanceAColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'ConveyanceA' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.ConveyanceAColumn] = value;
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
		public double EducationA
		{
			get
			{
				try
				{
					return (double)base[tableDataTable1.EducationAColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'EducationA' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.EducationAColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public double MedicalAllowance
		{
			get
			{
				try
				{
					return (double)base[tableDataTable1.MedicalAllowanceColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'MedicalAllowance' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.MedicalAllowanceColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public double MedicalAllowanceA
		{
			get
			{
				try
				{
					return (double)base[tableDataTable1.MedicalAllowanceAColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'MedicalAllowanceA' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.MedicalAllowanceAColumn] = value;
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
		public double AttendanceBonusA
		{
			get
			{
				try
				{
					return (double)base[tableDataTable1.AttendanceBonusAColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'AttendanceBonusA' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.AttendanceBonusAColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public double ExGratiaA
		{
			get
			{
				try
				{
					return (double)base[tableDataTable1.ExGratiaAColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'ExGratiaA' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.ExGratiaAColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public double TakeHomeINR
		{
			get
			{
				try
				{
					return (double)base[tableDataTable1.TakeHomeINRColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'TakeHomeINR' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.TakeHomeINRColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public double TakeHomeWithAttend1
		{
			get
			{
				try
				{
					return (double)base[tableDataTable1.TakeHomeWithAttend1Column];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'TakeHomeWithAttend1' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.TakeHomeWithAttend1Column] = value;
			}
		}

		[DebuggerNonUserCode]
		public double TakeHomeWithAttend2
		{
			get
			{
				try
				{
					return (double)base[tableDataTable1.TakeHomeWithAttend2Column];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'TakeHomeWithAttend2' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.TakeHomeWithAttend2Column] = value;
			}
		}

		[DebuggerNonUserCode]
		public double LoyaltyBenefitA
		{
			get
			{
				try
				{
					return (double)base[tableDataTable1.LoyaltyBenefitAColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'LoyaltyBenefitA' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.LoyaltyBenefitAColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public double LTAA
		{
			get
			{
				try
				{
					return (double)base[tableDataTable1.LTAAColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'LTAA' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.LTAAColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public double PFE
		{
			get
			{
				try
				{
					return (double)base[tableDataTable1.PFEColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'PFE' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.PFEColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public double PFEA
		{
			get
			{
				try
				{
					return (double)base[tableDataTable1.PFEAColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'PFEA' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.PFEAColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public double PFC
		{
			get
			{
				try
				{
					return (double)base[tableDataTable1.PFCColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'PFC' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.PFCColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public double PFCA
		{
			get
			{
				try
				{
					return (double)base[tableDataTable1.PFCAColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'PFCA' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.PFCAColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public double Bonus
		{
			get
			{
				try
				{
					return (double)base[tableDataTable1.BonusColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Bonus' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.BonusColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public double BonusA
		{
			get
			{
				try
				{
					return (double)base[tableDataTable1.BonusAColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'BonusA' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.BonusAColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public double Gratuity
		{
			get
			{
				try
				{
					return (double)base[tableDataTable1.GratuityColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Gratuity' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.GratuityColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public double GratuityA
		{
			get
			{
				try
				{
					return (double)base[tableDataTable1.GratuityAColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'GratuityA' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.GratuityAColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public double VehicleAllowanceA
		{
			get
			{
				try
				{
					return (double)base[tableDataTable1.VehicleAllowanceAColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'VehicleAllowanceA' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.VehicleAllowanceAColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public double CTCinINR
		{
			get
			{
				try
				{
					return (double)base[tableDataTable1.CTCinINRColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'CTCinINR' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.CTCinINRColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public double CTCinINRA
		{
			get
			{
				try
				{
					return (double)base[tableDataTable1.CTCinINRAColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'CTCinINRA' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.CTCinINRAColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public double CTCinINRwithAttendBonus1
		{
			get
			{
				try
				{
					return (double)base[tableDataTable1.CTCinINRwithAttendBonus1Column];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'CTCinINRwithAttendBonus1' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.CTCinINRwithAttendBonus1Column] = value;
			}
		}

		[DebuggerNonUserCode]
		public double CTCinINRwithAttendBonus1A
		{
			get
			{
				try
				{
					return (double)base[tableDataTable1.CTCinINRwithAttendBonus1AColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'CTCinINRwithAttendBonus1A' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.CTCinINRwithAttendBonus1AColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public double CTCinINRwithAttendBonus2
		{
			get
			{
				try
				{
					return (double)base[tableDataTable1.CTCinINRwithAttendBonus2Column];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'CTCinINRwithAttendBonus2' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.CTCinINRwithAttendBonus2Column] = value;
			}
		}

		[DebuggerNonUserCode]
		public double CTCinINRwithAttendBonus2A
		{
			get
			{
				try
				{
					return (double)base[tableDataTable1.CTCinINRwithAttendBonus2AColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'CTCinINRwithAttendBonus2A' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.CTCinINRwithAttendBonus2AColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string AttBonPer
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.AttBonPerColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'AttBonPer' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.AttBonPerColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string AttBonPer2
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.AttBonPer2Column];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'AttBonPer2' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.AttBonPer2Column] = value;
			}
		}

		[DebuggerNonUserCode]
		public double AttendanceBonus2
		{
			get
			{
				try
				{
					return (double)base[tableDataTable1.AttendanceBonus2Column];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'AttendanceBonus2' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.AttendanceBonus2Column] = value;
			}
		}

		[DebuggerNonUserCode]
		public double AttendanceBonusB
		{
			get
			{
				try
				{
					return (double)base[tableDataTable1.AttendanceBonusBColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'AttendanceBonusB' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.AttendanceBonusBColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string PFEmployee
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.PFEmployeeColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'PFEmployee' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.PFEmployeeColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string PFCompany
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.PFCompanyColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'PFCompany' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.PFCompanyColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string IncrementForTheYear
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.IncrementForTheYearColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'IncrementForTheYear' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.IncrementForTheYearColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string EffectFrom
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.EffectFromColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'EffectFrom' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.EffectFromColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string _OFYear_
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1._OFYear_Column];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'OFYear*' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1._OFYear_Column] = value;
			}
		}

		[DebuggerNonUserCode]
		public string _Grade_
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1._Grade_Column];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Grade*' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1._Grade_Column] = value;
			}
		}

		[DebuggerNonUserCode]
		public string _GradeI_
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1._GradeI_Column];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'GradeI*' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1._GradeI_Column] = value;
			}
		}

		[DebuggerNonUserCode]
		public string _Designation_
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1._Designation_Column];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Designation*' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1._Designation_Column] = value;
			}
		}

		[DebuggerNonUserCode]
		public double _ExGratia_
		{
			get
			{
				try
				{
					return (double)base[tableDataTable1._ExGratia_Column];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'ExGratia*' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1._ExGratia_Column] = value;
			}
		}

		[DebuggerNonUserCode]
		public double _VehicleAllowance_
		{
			get
			{
				try
				{
					return (double)base[tableDataTable1._VehicleAllowance_Column];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'VehicleAllowance*' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1._VehicleAllowance_Column] = value;
			}
		}

		[DebuggerNonUserCode]
		public double _LTA_
		{
			get
			{
				try
				{
					return (double)base[tableDataTable1._LTA_Column];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'LTA*' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1._LTA_Column] = value;
			}
		}

		[DebuggerNonUserCode]
		public double _Loyalty_
		{
			get
			{
				try
				{
					return (double)base[tableDataTable1._Loyalty_Column];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Loyalty*' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1._Loyalty_Column] = value;
			}
		}

		[DebuggerNonUserCode]
		public double _PerMonth_
		{
			get
			{
				try
				{
					return (double)base[tableDataTable1._PerMonth_Column];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'PerMonth*' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1._PerMonth_Column] = value;
			}
		}

		[DebuggerNonUserCode]
		public double _Basic_
		{
			get
			{
				try
				{
					return (double)base[tableDataTable1._Basic_Column];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Basic*' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1._Basic_Column] = value;
			}
		}

		[DebuggerNonUserCode]
		public double _DA_
		{
			get
			{
				try
				{
					return (double)base[tableDataTable1._DA_Column];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'DA*' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1._DA_Column] = value;
			}
		}

		[DebuggerNonUserCode]
		public double _HRA_
		{
			get
			{
				try
				{
					return (double)base[tableDataTable1._HRA_Column];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'HRA*' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1._HRA_Column] = value;
			}
		}

		[DebuggerNonUserCode]
		public double _Conveyance_
		{
			get
			{
				try
				{
					return (double)base[tableDataTable1._Conveyance_Column];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Conveyance*' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1._Conveyance_Column] = value;
			}
		}

		[DebuggerNonUserCode]
		public double _Education_
		{
			get
			{
				try
				{
					return (double)base[tableDataTable1._Education_Column];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Education*' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1._Education_Column] = value;
			}
		}

		[DebuggerNonUserCode]
		public double _MedicalAllowance_
		{
			get
			{
				try
				{
					return (double)base[tableDataTable1._MedicalAllowance_Column];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'MedicalAllowance*' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1._MedicalAllowance_Column] = value;
			}
		}

		[DebuggerNonUserCode]
		public double _AttendanceBonus_
		{
			get
			{
				try
				{
					return (double)base[tableDataTable1._AttendanceBonus_Column];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'AttendanceBonus*' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1._AttendanceBonus_Column] = value;
			}
		}

		[DebuggerNonUserCode]
		public double _AttendanceBonus2_
		{
			get
			{
				try
				{
					return (double)base[tableDataTable1._AttendanceBonus2_Column];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'AttendanceBonus2*' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1._AttendanceBonus2_Column] = value;
			}
		}

		[DebuggerNonUserCode]
		public double _TakeHomeINR_
		{
			get
			{
				try
				{
					return (double)base[tableDataTable1._TakeHomeINR_Column];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'TakeHomeINR*' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1._TakeHomeINR_Column] = value;
			}
		}

		[DebuggerNonUserCode]
		public double _TakeHomeWithAttend1_
		{
			get
			{
				try
				{
					return (double)base[tableDataTable1._TakeHomeWithAttend1_Column];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'TakeHomeWithAttend1*' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1._TakeHomeWithAttend1_Column] = value;
			}
		}

		[DebuggerNonUserCode]
		public double _TakeHomeWithAttend2_
		{
			get
			{
				try
				{
					return (double)base[tableDataTable1._TakeHomeWithAttend2_Column];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'TakeHomeWithAttend2*' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1._TakeHomeWithAttend2_Column] = value;
			}
		}

		[DebuggerNonUserCode]
		public double _PFE_
		{
			get
			{
				try
				{
					return (double)base[tableDataTable1._PFE_Column];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'PFE*' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1._PFE_Column] = value;
			}
		}

		[DebuggerNonUserCode]
		public double _PFC_
		{
			get
			{
				try
				{
					return (double)base[tableDataTable1._PFC_Column];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'PFC*' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1._PFC_Column] = value;
			}
		}

		[DebuggerNonUserCode]
		public double _Bonus_
		{
			get
			{
				try
				{
					return (double)base[tableDataTable1._Bonus_Column];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Bonus*' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1._Bonus_Column] = value;
			}
		}

		[DebuggerNonUserCode]
		public double _Gratuity_
		{
			get
			{
				try
				{
					return (double)base[tableDataTable1._Gratuity_Column];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Gratuity*' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1._Gratuity_Column] = value;
			}
		}

		[DebuggerNonUserCode]
		public double _CTCinINR_
		{
			get
			{
				try
				{
					return (double)base[tableDataTable1._CTCinINR_Column];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'CTCinINR*' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1._CTCinINR_Column] = value;
			}
		}

		[DebuggerNonUserCode]
		public double _CTCinINRwithAttendBonus1_
		{
			get
			{
				try
				{
					return (double)base[tableDataTable1._CTCinINRwithAttendBonus1_Column];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'CTCinINRwithAttendBonus1*' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1._CTCinINRwithAttendBonus1_Column] = value;
			}
		}

		[DebuggerNonUserCode]
		public double _CTCinINRwithAttendBonus2_
		{
			get
			{
				try
				{
					return (double)base[tableDataTable1._CTCinINRwithAttendBonus2_Column];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'CTCinINRwithAttendBonus2*' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1._CTCinINRwithAttendBonus2_Column] = value;
			}
		}

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
		internal DataTable1Row(DataRowBuilder rb)
			: base(rb)
		{
			tableDataTable1 = (DataTable1DataTable)base.Table;
		}

		[DebuggerNonUserCode]
		public bool IsOfferIdNull()
		{
			return IsNull(tableDataTable1.OfferIdColumn);
		}

		[DebuggerNonUserCode]
		public void SetOfferIdNull()
		{
			base[tableDataTable1.OfferIdColumn] = Convert.DBNull;
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
		public bool IsStaffTypeNull()
		{
			return IsNull(tableDataTable1.StaffTypeColumn);
		}

		[DebuggerNonUserCode]
		public void SetStaffTypeNull()
		{
			base[tableDataTable1.StaffTypeColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsTypeOfNull()
		{
			return IsNull(tableDataTable1.TypeOfColumn);
		}

		[DebuggerNonUserCode]
		public void SetTypeOfNull()
		{
			base[tableDataTable1.TypeOfColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IssalaryNull()
		{
			return IsNull(tableDataTable1.salaryColumn);
		}

		[DebuggerNonUserCode]
		public void SetsalaryNull()
		{
			base[tableDataTable1.salaryColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsDutyHrsNull()
		{
			return IsNull(tableDataTable1.DutyHrsColumn);
		}

		[DebuggerNonUserCode]
		public void SetDutyHrsNull()
		{
			base[tableDataTable1.DutyHrsColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsOTHrsNull()
		{
			return IsNull(tableDataTable1.OTHrsColumn);
		}

		[DebuggerNonUserCode]
		public void SetOTHrsNull()
		{
			base[tableDataTable1.OTHrsColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsOverTimeNull()
		{
			return IsNull(tableDataTable1.OverTimeColumn);
		}

		[DebuggerNonUserCode]
		public void SetOverTimeNull()
		{
			base[tableDataTable1.OverTimeColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsInterviewedByNull()
		{
			return IsNull(tableDataTable1.InterviewedByColumn);
		}

		[DebuggerNonUserCode]
		public void SetInterviewedByNull()
		{
			base[tableDataTable1.InterviewedByColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsAuthorizedByNull()
		{
			return IsNull(tableDataTable1.AuthorizedByColumn);
		}

		[DebuggerNonUserCode]
		public void SetAuthorizedByNull()
		{
			base[tableDataTable1.AuthorizedByColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsReferenceByNull()
		{
			return IsNull(tableDataTable1.ReferenceByColumn);
		}

		[DebuggerNonUserCode]
		public void SetReferenceByNull()
		{
			base[tableDataTable1.ReferenceByColumn] = Convert.DBNull;
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
		public bool IsVehicleAllowanceNull()
		{
			return IsNull(tableDataTable1.VehicleAllowanceColumn);
		}

		[DebuggerNonUserCode]
		public void SetVehicleAllowanceNull()
		{
			base[tableDataTable1.VehicleAllowanceColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsLTANull()
		{
			return IsNull(tableDataTable1.LTAColumn);
		}

		[DebuggerNonUserCode]
		public void SetLTANull()
		{
			base[tableDataTable1.LTAColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsLoyaltyNull()
		{
			return IsNull(tableDataTable1.LoyaltyColumn);
		}

		[DebuggerNonUserCode]
		public void SetLoyaltyNull()
		{
			base[tableDataTable1.LoyaltyColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsPaidLeavesNull()
		{
			return IsNull(tableDataTable1.PaidLeavesColumn);
		}

		[DebuggerNonUserCode]
		public void SetPaidLeavesNull()
		{
			base[tableDataTable1.PaidLeavesColumn] = Convert.DBNull;
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
		public bool IsHeaderTextNull()
		{
			return IsNull(tableDataTable1.HeaderTextColumn);
		}

		[DebuggerNonUserCode]
		public void SetHeaderTextNull()
		{
			base[tableDataTable1.HeaderTextColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsFooterTextNull()
		{
			return IsNull(tableDataTable1.FooterTextColumn);
		}

		[DebuggerNonUserCode]
		public void SetFooterTextNull()
		{
			base[tableDataTable1.FooterTextColumn] = Convert.DBNull;
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
		public bool IsPerMonthNull()
		{
			return IsNull(tableDataTable1.PerMonthColumn);
		}

		[DebuggerNonUserCode]
		public void SetPerMonthNull()
		{
			base[tableDataTable1.PerMonthColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsPerMonthANull()
		{
			return IsNull(tableDataTable1.PerMonthAColumn);
		}

		[DebuggerNonUserCode]
		public void SetPerMonthANull()
		{
			base[tableDataTable1.PerMonthAColumn] = Convert.DBNull;
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
		public bool IsBasicANull()
		{
			return IsNull(tableDataTable1.BasicAColumn);
		}

		[DebuggerNonUserCode]
		public void SetBasicANull()
		{
			base[tableDataTable1.BasicAColumn] = Convert.DBNull;
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
		public bool IsDAANull()
		{
			return IsNull(tableDataTable1.DAAColumn);
		}

		[DebuggerNonUserCode]
		public void SetDAANull()
		{
			base[tableDataTable1.DAAColumn] = Convert.DBNull;
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
		public bool IsHRAANull()
		{
			return IsNull(tableDataTable1.HRAAColumn);
		}

		[DebuggerNonUserCode]
		public void SetHRAANull()
		{
			base[tableDataTable1.HRAAColumn] = Convert.DBNull;
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
		public bool IsConveyanceANull()
		{
			return IsNull(tableDataTable1.ConveyanceAColumn);
		}

		[DebuggerNonUserCode]
		public void SetConveyanceANull()
		{
			base[tableDataTable1.ConveyanceAColumn] = Convert.DBNull;
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
		public bool IsEducationANull()
		{
			return IsNull(tableDataTable1.EducationAColumn);
		}

		[DebuggerNonUserCode]
		public void SetEducationANull()
		{
			base[tableDataTable1.EducationAColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsMedicalAllowanceNull()
		{
			return IsNull(tableDataTable1.MedicalAllowanceColumn);
		}

		[DebuggerNonUserCode]
		public void SetMedicalAllowanceNull()
		{
			base[tableDataTable1.MedicalAllowanceColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsMedicalAllowanceANull()
		{
			return IsNull(tableDataTable1.MedicalAllowanceAColumn);
		}

		[DebuggerNonUserCode]
		public void SetMedicalAllowanceANull()
		{
			base[tableDataTable1.MedicalAllowanceAColumn] = Convert.DBNull;
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
		public bool IsAttendanceBonusANull()
		{
			return IsNull(tableDataTable1.AttendanceBonusAColumn);
		}

		[DebuggerNonUserCode]
		public void SetAttendanceBonusANull()
		{
			base[tableDataTable1.AttendanceBonusAColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsExGratiaANull()
		{
			return IsNull(tableDataTable1.ExGratiaAColumn);
		}

		[DebuggerNonUserCode]
		public void SetExGratiaANull()
		{
			base[tableDataTable1.ExGratiaAColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsTakeHomeINRNull()
		{
			return IsNull(tableDataTable1.TakeHomeINRColumn);
		}

		[DebuggerNonUserCode]
		public void SetTakeHomeINRNull()
		{
			base[tableDataTable1.TakeHomeINRColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsTakeHomeWithAttend1Null()
		{
			return IsNull(tableDataTable1.TakeHomeWithAttend1Column);
		}

		[DebuggerNonUserCode]
		public void SetTakeHomeWithAttend1Null()
		{
			base[tableDataTable1.TakeHomeWithAttend1Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsTakeHomeWithAttend2Null()
		{
			return IsNull(tableDataTable1.TakeHomeWithAttend2Column);
		}

		[DebuggerNonUserCode]
		public void SetTakeHomeWithAttend2Null()
		{
			base[tableDataTable1.TakeHomeWithAttend2Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsLoyaltyBenefitANull()
		{
			return IsNull(tableDataTable1.LoyaltyBenefitAColumn);
		}

		[DebuggerNonUserCode]
		public void SetLoyaltyBenefitANull()
		{
			base[tableDataTable1.LoyaltyBenefitAColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsLTAANull()
		{
			return IsNull(tableDataTable1.LTAAColumn);
		}

		[DebuggerNonUserCode]
		public void SetLTAANull()
		{
			base[tableDataTable1.LTAAColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsPFENull()
		{
			return IsNull(tableDataTable1.PFEColumn);
		}

		[DebuggerNonUserCode]
		public void SetPFENull()
		{
			base[tableDataTable1.PFEColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsPFEANull()
		{
			return IsNull(tableDataTable1.PFEAColumn);
		}

		[DebuggerNonUserCode]
		public void SetPFEANull()
		{
			base[tableDataTable1.PFEAColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsPFCNull()
		{
			return IsNull(tableDataTable1.PFCColumn);
		}

		[DebuggerNonUserCode]
		public void SetPFCNull()
		{
			base[tableDataTable1.PFCColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsPFCANull()
		{
			return IsNull(tableDataTable1.PFCAColumn);
		}

		[DebuggerNonUserCode]
		public void SetPFCANull()
		{
			base[tableDataTable1.PFCAColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsBonusNull()
		{
			return IsNull(tableDataTable1.BonusColumn);
		}

		[DebuggerNonUserCode]
		public void SetBonusNull()
		{
			base[tableDataTable1.BonusColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsBonusANull()
		{
			return IsNull(tableDataTable1.BonusAColumn);
		}

		[DebuggerNonUserCode]
		public void SetBonusANull()
		{
			base[tableDataTable1.BonusAColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsGratuityNull()
		{
			return IsNull(tableDataTable1.GratuityColumn);
		}

		[DebuggerNonUserCode]
		public void SetGratuityNull()
		{
			base[tableDataTable1.GratuityColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsGratuityANull()
		{
			return IsNull(tableDataTable1.GratuityAColumn);
		}

		[DebuggerNonUserCode]
		public void SetGratuityANull()
		{
			base[tableDataTable1.GratuityAColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsVehicleAllowanceANull()
		{
			return IsNull(tableDataTable1.VehicleAllowanceAColumn);
		}

		[DebuggerNonUserCode]
		public void SetVehicleAllowanceANull()
		{
			base[tableDataTable1.VehicleAllowanceAColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsCTCinINRNull()
		{
			return IsNull(tableDataTable1.CTCinINRColumn);
		}

		[DebuggerNonUserCode]
		public void SetCTCinINRNull()
		{
			base[tableDataTable1.CTCinINRColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsCTCinINRANull()
		{
			return IsNull(tableDataTable1.CTCinINRAColumn);
		}

		[DebuggerNonUserCode]
		public void SetCTCinINRANull()
		{
			base[tableDataTable1.CTCinINRAColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsCTCinINRwithAttendBonus1Null()
		{
			return IsNull(tableDataTable1.CTCinINRwithAttendBonus1Column);
		}

		[DebuggerNonUserCode]
		public void SetCTCinINRwithAttendBonus1Null()
		{
			base[tableDataTable1.CTCinINRwithAttendBonus1Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsCTCinINRwithAttendBonus1ANull()
		{
			return IsNull(tableDataTable1.CTCinINRwithAttendBonus1AColumn);
		}

		[DebuggerNonUserCode]
		public void SetCTCinINRwithAttendBonus1ANull()
		{
			base[tableDataTable1.CTCinINRwithAttendBonus1AColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsCTCinINRwithAttendBonus2Null()
		{
			return IsNull(tableDataTable1.CTCinINRwithAttendBonus2Column);
		}

		[DebuggerNonUserCode]
		public void SetCTCinINRwithAttendBonus2Null()
		{
			base[tableDataTable1.CTCinINRwithAttendBonus2Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsCTCinINRwithAttendBonus2ANull()
		{
			return IsNull(tableDataTable1.CTCinINRwithAttendBonus2AColumn);
		}

		[DebuggerNonUserCode]
		public void SetCTCinINRwithAttendBonus2ANull()
		{
			base[tableDataTable1.CTCinINRwithAttendBonus2AColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsAttBonPerNull()
		{
			return IsNull(tableDataTable1.AttBonPerColumn);
		}

		[DebuggerNonUserCode]
		public void SetAttBonPerNull()
		{
			base[tableDataTable1.AttBonPerColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsAttBonPer2Null()
		{
			return IsNull(tableDataTable1.AttBonPer2Column);
		}

		[DebuggerNonUserCode]
		public void SetAttBonPer2Null()
		{
			base[tableDataTable1.AttBonPer2Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsAttendanceBonus2Null()
		{
			return IsNull(tableDataTable1.AttendanceBonus2Column);
		}

		[DebuggerNonUserCode]
		public void SetAttendanceBonus2Null()
		{
			base[tableDataTable1.AttendanceBonus2Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsAttendanceBonusBNull()
		{
			return IsNull(tableDataTable1.AttendanceBonusBColumn);
		}

		[DebuggerNonUserCode]
		public void SetAttendanceBonusBNull()
		{
			base[tableDataTable1.AttendanceBonusBColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsPFEmployeeNull()
		{
			return IsNull(tableDataTable1.PFEmployeeColumn);
		}

		[DebuggerNonUserCode]
		public void SetPFEmployeeNull()
		{
			base[tableDataTable1.PFEmployeeColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsPFCompanyNull()
		{
			return IsNull(tableDataTable1.PFCompanyColumn);
		}

		[DebuggerNonUserCode]
		public void SetPFCompanyNull()
		{
			base[tableDataTable1.PFCompanyColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsIncrementForTheYearNull()
		{
			return IsNull(tableDataTable1.IncrementForTheYearColumn);
		}

		[DebuggerNonUserCode]
		public void SetIncrementForTheYearNull()
		{
			base[tableDataTable1.IncrementForTheYearColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsEffectFromNull()
		{
			return IsNull(tableDataTable1.EffectFromColumn);
		}

		[DebuggerNonUserCode]
		public void SetEffectFromNull()
		{
			base[tableDataTable1.EffectFromColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool Is_OFYear_Null()
		{
			return IsNull(tableDataTable1._OFYear_Column);
		}

		[DebuggerNonUserCode]
		public void Set_OFYear_Null()
		{
			base[tableDataTable1._OFYear_Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool Is_Grade_Null()
		{
			return IsNull(tableDataTable1._Grade_Column);
		}

		[DebuggerNonUserCode]
		public void Set_Grade_Null()
		{
			base[tableDataTable1._Grade_Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool Is_GradeI_Null()
		{
			return IsNull(tableDataTable1._GradeI_Column);
		}

		[DebuggerNonUserCode]
		public void Set_GradeI_Null()
		{
			base[tableDataTable1._GradeI_Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool Is_Designation_Null()
		{
			return IsNull(tableDataTable1._Designation_Column);
		}

		[DebuggerNonUserCode]
		public void Set_Designation_Null()
		{
			base[tableDataTable1._Designation_Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool Is_ExGratia_Null()
		{
			return IsNull(tableDataTable1._ExGratia_Column);
		}

		[DebuggerNonUserCode]
		public void Set_ExGratia_Null()
		{
			base[tableDataTable1._ExGratia_Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool Is_VehicleAllowance_Null()
		{
			return IsNull(tableDataTable1._VehicleAllowance_Column);
		}

		[DebuggerNonUserCode]
		public void Set_VehicleAllowance_Null()
		{
			base[tableDataTable1._VehicleAllowance_Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool Is_LTA_Null()
		{
			return IsNull(tableDataTable1._LTA_Column);
		}

		[DebuggerNonUserCode]
		public void Set_LTA_Null()
		{
			base[tableDataTable1._LTA_Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool Is_Loyalty_Null()
		{
			return IsNull(tableDataTable1._Loyalty_Column);
		}

		[DebuggerNonUserCode]
		public void Set_Loyalty_Null()
		{
			base[tableDataTable1._Loyalty_Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool Is_PerMonth_Null()
		{
			return IsNull(tableDataTable1._PerMonth_Column);
		}

		[DebuggerNonUserCode]
		public void Set_PerMonth_Null()
		{
			base[tableDataTable1._PerMonth_Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool Is_Basic_Null()
		{
			return IsNull(tableDataTable1._Basic_Column);
		}

		[DebuggerNonUserCode]
		public void Set_Basic_Null()
		{
			base[tableDataTable1._Basic_Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool Is_DA_Null()
		{
			return IsNull(tableDataTable1._DA_Column);
		}

		[DebuggerNonUserCode]
		public void Set_DA_Null()
		{
			base[tableDataTable1._DA_Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool Is_HRA_Null()
		{
			return IsNull(tableDataTable1._HRA_Column);
		}

		[DebuggerNonUserCode]
		public void Set_HRA_Null()
		{
			base[tableDataTable1._HRA_Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool Is_Conveyance_Null()
		{
			return IsNull(tableDataTable1._Conveyance_Column);
		}

		[DebuggerNonUserCode]
		public void Set_Conveyance_Null()
		{
			base[tableDataTable1._Conveyance_Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool Is_Education_Null()
		{
			return IsNull(tableDataTable1._Education_Column);
		}

		[DebuggerNonUserCode]
		public void Set_Education_Null()
		{
			base[tableDataTable1._Education_Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool Is_MedicalAllowance_Null()
		{
			return IsNull(tableDataTable1._MedicalAllowance_Column);
		}

		[DebuggerNonUserCode]
		public void Set_MedicalAllowance_Null()
		{
			base[tableDataTable1._MedicalAllowance_Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool Is_AttendanceBonus_Null()
		{
			return IsNull(tableDataTable1._AttendanceBonus_Column);
		}

		[DebuggerNonUserCode]
		public void Set_AttendanceBonus_Null()
		{
			base[tableDataTable1._AttendanceBonus_Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool Is_AttendanceBonus2_Null()
		{
			return IsNull(tableDataTable1._AttendanceBonus2_Column);
		}

		[DebuggerNonUserCode]
		public void Set_AttendanceBonus2_Null()
		{
			base[tableDataTable1._AttendanceBonus2_Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool Is_TakeHomeINR_Null()
		{
			return IsNull(tableDataTable1._TakeHomeINR_Column);
		}

		[DebuggerNonUserCode]
		public void Set_TakeHomeINR_Null()
		{
			base[tableDataTable1._TakeHomeINR_Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool Is_TakeHomeWithAttend1_Null()
		{
			return IsNull(tableDataTable1._TakeHomeWithAttend1_Column);
		}

		[DebuggerNonUserCode]
		public void Set_TakeHomeWithAttend1_Null()
		{
			base[tableDataTable1._TakeHomeWithAttend1_Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool Is_TakeHomeWithAttend2_Null()
		{
			return IsNull(tableDataTable1._TakeHomeWithAttend2_Column);
		}

		[DebuggerNonUserCode]
		public void Set_TakeHomeWithAttend2_Null()
		{
			base[tableDataTable1._TakeHomeWithAttend2_Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool Is_PFE_Null()
		{
			return IsNull(tableDataTable1._PFE_Column);
		}

		[DebuggerNonUserCode]
		public void Set_PFE_Null()
		{
			base[tableDataTable1._PFE_Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool Is_PFC_Null()
		{
			return IsNull(tableDataTable1._PFC_Column);
		}

		[DebuggerNonUserCode]
		public void Set_PFC_Null()
		{
			base[tableDataTable1._PFC_Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool Is_Bonus_Null()
		{
			return IsNull(tableDataTable1._Bonus_Column);
		}

		[DebuggerNonUserCode]
		public void Set_Bonus_Null()
		{
			base[tableDataTable1._Bonus_Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool Is_Gratuity_Null()
		{
			return IsNull(tableDataTable1._Gratuity_Column);
		}

		[DebuggerNonUserCode]
		public void Set_Gratuity_Null()
		{
			base[tableDataTable1._Gratuity_Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool Is_CTCinINR_Null()
		{
			return IsNull(tableDataTable1._CTCinINR_Column);
		}

		[DebuggerNonUserCode]
		public void Set_CTCinINR_Null()
		{
			base[tableDataTable1._CTCinINR_Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool Is_CTCinINRwithAttendBonus1_Null()
		{
			return IsNull(tableDataTable1._CTCinINRwithAttendBonus1_Column);
		}

		[DebuggerNonUserCode]
		public void Set_CTCinINRwithAttendBonus1_Null()
		{
			base[tableDataTable1._CTCinINRwithAttendBonus1_Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool Is_CTCinINRwithAttendBonus2_Null()
		{
			return IsNull(tableDataTable1._CTCinINRwithAttendBonus2_Column);
		}

		[DebuggerNonUserCode]
		public void Set_CTCinINRwithAttendBonus2_Null()
		{
			base[tableDataTable1._CTCinINRwithAttendBonus2_Column] = Convert.DBNull;
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
	}

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
	public class DataTable2Row : DataRow
	{
		private DataTable2DataTable tableDataTable2;

		[DebuggerNonUserCode]
		public string Access_Perticulars
		{
			get
			{
				try
				{
					return (string)base[tableDataTable2.Access_PerticularsColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Access_Perticulars' in table 'DataTable2' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable2.Access_PerticularsColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public double Access_Amount
		{
			get
			{
				try
				{
					return (double)base[tableDataTable2.Access_AmountColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Access_Amount' in table 'DataTable2' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable2.Access_AmountColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		internal DataTable2Row(DataRowBuilder rb)
			: base(rb)
		{
			tableDataTable2 = (DataTable2DataTable)base.Table;
		}

		[DebuggerNonUserCode]
		public bool IsAccess_PerticularsNull()
		{
			return IsNull(tableDataTable2.Access_PerticularsColumn);
		}

		[DebuggerNonUserCode]
		public void SetAccess_PerticularsNull()
		{
			base[tableDataTable2.Access_PerticularsColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsAccess_AmountNull()
		{
			return IsNull(tableDataTable2.Access_AmountColumn);
		}

		[DebuggerNonUserCode]
		public void SetAccess_AmountNull()
		{
			base[tableDataTable2.Access_AmountColumn] = Convert.DBNull;
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
	public IncrementLetter()
	{
		BeginInit();
		InitClass();
		CollectionChangeEventHandler value = SchemaChanged;
		base.Tables.CollectionChanged += value;
		base.Relations.CollectionChanged += value;
		EndInit();
	}

	[DebuggerNonUserCode]
	protected IncrementLetter(SerializationInfo info, StreamingContext context)
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
		IncrementLetter incrementLetter = (IncrementLetter)base.Clone();
		incrementLetter.InitVars();
		incrementLetter.SchemaSerializationMode = SchemaSerializationMode;
		return incrementLetter;
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
		base.DataSetName = "IncrementLetter";
		base.Prefix = "";
		base.Namespace = "http://tempuri.org/IncrementLetter.xsd";
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
		IncrementLetter incrementLetter = new IncrementLetter();
		XmlSchemaComplexType xmlSchemaComplexType = new XmlSchemaComplexType();
		XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
		XmlSchemaAny xmlSchemaAny = new XmlSchemaAny();
		xmlSchemaAny.Namespace = incrementLetter.Namespace;
		xmlSchemaSequence.Items.Add(xmlSchemaAny);
		xmlSchemaComplexType.Particle = xmlSchemaSequence;
		XmlSchema schemaSerializable = incrementLetter.GetSchemaSerializable();
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
