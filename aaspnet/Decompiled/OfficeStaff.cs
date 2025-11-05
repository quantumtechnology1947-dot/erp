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
[XmlSchemaProvider("GetTypedDataSetSchema")]
[HelpKeyword("vs.data.DataSet")]
[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
[XmlRoot("OfficeStaff")]
public class OfficeStaff : DataSet
{
	public delegate void DataTable1RowChangeEventHandler(object sender, DataTable1RowChangeEvent e);

	[Serializable]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
	[XmlSchemaProvider("GetTypedTableSchema")]
	public class DataTable1DataTable : TypedTableBase<DataTable1Row>
	{
		private DataColumn columnCompanyName;

		private DataColumn columnPhotoData;

		private DataColumn columnAddress;

		private DataColumn columnCardNo;

		private DataColumn columnEmpName;

		private DataColumn columnDepartment;

		private DataColumn columnBussinessGroup;

		private DataColumn columnDeptDirector;

		private DataColumn columnDeptHead;

		private DataColumn columnGroupLeader;

		private DataColumn columnDesignation;

		private DataColumn columnGrade;

		private DataColumn columnMobileNo;

		private DataColumn columnextNo;

		private DataColumn columnjoindate;

		private DataColumn columnbirthdate;

		private DataColumn columnresigndate;

		private DataColumn columnmartialstatus;

		private DataColumn columnphysicalstatus;

		private DataColumn columnpadd;

		private DataColumn columncadd;

		private DataColumn columnemail;

		private DataColumn columngender;

		private DataColumn columnbgp;

		private DataColumn columnheight;

		private DataColumn columnweight;

		private DataColumn columnreligion;

		private DataColumn columncast;

		private DataColumn columnedu;

		private DataColumn columnadq;

		private DataColumn columnlc;

		private DataColumn columnwd;

		private DataColumn columnte;

		private DataColumn columnctc;

		private DataColumn columnba;

		private DataColumn columnpf;

		private DataColumn columnpa;

		private DataColumn columnps;

		private DataColumn columnex;

		private DataColumn columninf;

		private DataColumn columnLogoImage;

		[DebuggerNonUserCode]
		public DataColumn CompanyNameColumn => columnCompanyName;

		[DebuggerNonUserCode]
		public DataColumn PhotoDataColumn => columnPhotoData;

		[DebuggerNonUserCode]
		public DataColumn AddressColumn => columnAddress;

		[DebuggerNonUserCode]
		public DataColumn CardNoColumn => columnCardNo;

		[DebuggerNonUserCode]
		public DataColumn EmpNameColumn => columnEmpName;

		[DebuggerNonUserCode]
		public DataColumn DepartmentColumn => columnDepartment;

		[DebuggerNonUserCode]
		public DataColumn BussinessGroupColumn => columnBussinessGroup;

		[DebuggerNonUserCode]
		public DataColumn DeptDirectorColumn => columnDeptDirector;

		[DebuggerNonUserCode]
		public DataColumn DeptHeadColumn => columnDeptHead;

		[DebuggerNonUserCode]
		public DataColumn GroupLeaderColumn => columnGroupLeader;

		[DebuggerNonUserCode]
		public DataColumn DesignationColumn => columnDesignation;

		[DebuggerNonUserCode]
		public DataColumn GradeColumn => columnGrade;

		[DebuggerNonUserCode]
		public DataColumn MobileNoColumn => columnMobileNo;

		[DebuggerNonUserCode]
		public DataColumn extNoColumn => columnextNo;

		[DebuggerNonUserCode]
		public DataColumn joindateColumn => columnjoindate;

		[DebuggerNonUserCode]
		public DataColumn birthdateColumn => columnbirthdate;

		[DebuggerNonUserCode]
		public DataColumn resigndateColumn => columnresigndate;

		[DebuggerNonUserCode]
		public DataColumn martialstatusColumn => columnmartialstatus;

		[DebuggerNonUserCode]
		public DataColumn physicalstatusColumn => columnphysicalstatus;

		[DebuggerNonUserCode]
		public DataColumn paddColumn => columnpadd;

		[DebuggerNonUserCode]
		public DataColumn caddColumn => columncadd;

		[DebuggerNonUserCode]
		public DataColumn emailColumn => columnemail;

		[DebuggerNonUserCode]
		public DataColumn genderColumn => columngender;

		[DebuggerNonUserCode]
		public DataColumn bgpColumn => columnbgp;

		[DebuggerNonUserCode]
		public DataColumn heightColumn => columnheight;

		[DebuggerNonUserCode]
		public DataColumn weightColumn => columnweight;

		[DebuggerNonUserCode]
		public DataColumn religionColumn => columnreligion;

		[DebuggerNonUserCode]
		public DataColumn castColumn => columncast;

		[DebuggerNonUserCode]
		public DataColumn eduColumn => columnedu;

		[DebuggerNonUserCode]
		public DataColumn adqColumn => columnadq;

		[DebuggerNonUserCode]
		public DataColumn lcColumn => columnlc;

		[DebuggerNonUserCode]
		public DataColumn wdColumn => columnwd;

		[DebuggerNonUserCode]
		public DataColumn teColumn => columnte;

		[DebuggerNonUserCode]
		public DataColumn ctcColumn => columnctc;

		[DebuggerNonUserCode]
		public DataColumn baColumn => columnba;

		[DebuggerNonUserCode]
		public DataColumn pfColumn => columnpf;

		[DebuggerNonUserCode]
		public DataColumn paColumn => columnpa;

		[DebuggerNonUserCode]
		public DataColumn psColumn => columnps;

		[DebuggerNonUserCode]
		public DataColumn exColumn => columnex;

		[DebuggerNonUserCode]
		public DataColumn infColumn => columninf;

		[DebuggerNonUserCode]
		public DataColumn LogoImageColumn => columnLogoImage;

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
		public DataTable1Row AddDataTable1Row(string CompanyName, byte[] PhotoData, string Address, string CardNo, string EmpName, string Department, string BussinessGroup, string DeptDirector, string DeptHead, string GroupLeader, string Designation, string Grade, string MobileNo, string extNo, string joindate, string birthdate, string resigndate, string martialstatus, string physicalstatus, string padd, string cadd, string email, string gender, string bgp, string height, string weight, string religion, string cast, string edu, string adq, string lc, string wd, string te, string ctc, string ba, string pf, string pa, string ps, string ex, string inf, byte[] LogoImage)
		{
			DataTable1Row dataTable1Row = (DataTable1Row)NewRow();
			object[] itemArray = new object[41]
			{
				CompanyName, PhotoData, Address, CardNo, EmpName, Department, BussinessGroup, DeptDirector, DeptHead, GroupLeader,
				Designation, Grade, MobileNo, extNo, joindate, birthdate, resigndate, martialstatus, physicalstatus, padd,
				cadd, email, gender, bgp, height, weight, religion, cast, edu, adq,
				lc, wd, te, ctc, ba, pf, pa, ps, ex, inf,
				LogoImage
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
			columnCompanyName = base.Columns["CompanyName"];
			columnPhotoData = base.Columns["PhotoData"];
			columnAddress = base.Columns["Address"];
			columnCardNo = base.Columns["CardNo"];
			columnEmpName = base.Columns["EmpName"];
			columnDepartment = base.Columns["Department"];
			columnBussinessGroup = base.Columns["BussinessGroup"];
			columnDeptDirector = base.Columns["DeptDirector"];
			columnDeptHead = base.Columns["DeptHead"];
			columnGroupLeader = base.Columns["GroupLeader"];
			columnDesignation = base.Columns["Designation"];
			columnGrade = base.Columns["Grade"];
			columnMobileNo = base.Columns["MobileNo"];
			columnextNo = base.Columns["extNo"];
			columnjoindate = base.Columns["joindate"];
			columnbirthdate = base.Columns["birthdate"];
			columnresigndate = base.Columns["resigndate"];
			columnmartialstatus = base.Columns["martialstatus"];
			columnphysicalstatus = base.Columns["physicalstatus"];
			columnpadd = base.Columns["padd"];
			columncadd = base.Columns["cadd"];
			columnemail = base.Columns["email"];
			columngender = base.Columns["gender"];
			columnbgp = base.Columns["bgp"];
			columnheight = base.Columns["height"];
			columnweight = base.Columns["weight"];
			columnreligion = base.Columns["religion"];
			columncast = base.Columns["cast"];
			columnedu = base.Columns["edu"];
			columnadq = base.Columns["adq"];
			columnlc = base.Columns["lc"];
			columnwd = base.Columns["wd"];
			columnte = base.Columns["te"];
			columnctc = base.Columns["ctc"];
			columnba = base.Columns["ba"];
			columnpf = base.Columns["pf"];
			columnpa = base.Columns["pa"];
			columnps = base.Columns["ps"];
			columnex = base.Columns["ex"];
			columninf = base.Columns["inf"];
			columnLogoImage = base.Columns["LogoImage"];
		}

		[DebuggerNonUserCode]
		private void InitClass()
		{
			columnCompanyName = new DataColumn("CompanyName", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnCompanyName);
			columnPhotoData = new DataColumn("PhotoData", typeof(byte[]), null, MappingType.Element);
			base.Columns.Add(columnPhotoData);
			columnAddress = new DataColumn("Address", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnAddress);
			columnCardNo = new DataColumn("CardNo", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnCardNo);
			columnEmpName = new DataColumn("EmpName", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnEmpName);
			columnDepartment = new DataColumn("Department", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnDepartment);
			columnBussinessGroup = new DataColumn("BussinessGroup", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnBussinessGroup);
			columnDeptDirector = new DataColumn("DeptDirector", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnDeptDirector);
			columnDeptHead = new DataColumn("DeptHead", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnDeptHead);
			columnGroupLeader = new DataColumn("GroupLeader", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnGroupLeader);
			columnDesignation = new DataColumn("Designation", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnDesignation);
			columnGrade = new DataColumn("Grade", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnGrade);
			columnMobileNo = new DataColumn("MobileNo", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnMobileNo);
			columnextNo = new DataColumn("extNo", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnextNo);
			columnjoindate = new DataColumn("joindate", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnjoindate);
			columnbirthdate = new DataColumn("birthdate", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnbirthdate);
			columnresigndate = new DataColumn("resigndate", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnresigndate);
			columnmartialstatus = new DataColumn("martialstatus", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnmartialstatus);
			columnphysicalstatus = new DataColumn("physicalstatus", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnphysicalstatus);
			columnpadd = new DataColumn("padd", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnpadd);
			columncadd = new DataColumn("cadd", typeof(string), null, MappingType.Element);
			base.Columns.Add(columncadd);
			columnemail = new DataColumn("email", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnemail);
			columngender = new DataColumn("gender", typeof(string), null, MappingType.Element);
			base.Columns.Add(columngender);
			columnbgp = new DataColumn("bgp", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnbgp);
			columnheight = new DataColumn("height", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnheight);
			columnweight = new DataColumn("weight", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnweight);
			columnreligion = new DataColumn("religion", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnreligion);
			columncast = new DataColumn("cast", typeof(string), null, MappingType.Element);
			base.Columns.Add(columncast);
			columnedu = new DataColumn("edu", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnedu);
			columnadq = new DataColumn("adq", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnadq);
			columnlc = new DataColumn("lc", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnlc);
			columnwd = new DataColumn("wd", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnwd);
			columnte = new DataColumn("te", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnte);
			columnctc = new DataColumn("ctc", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnctc);
			columnba = new DataColumn("ba", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnba);
			columnpf = new DataColumn("pf", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnpf);
			columnpa = new DataColumn("pa", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnpa);
			columnps = new DataColumn("ps", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnps);
			columnex = new DataColumn("ex", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnex);
			columninf = new DataColumn("inf", typeof(string), null, MappingType.Element);
			base.Columns.Add(columninf);
			columnLogoImage = new DataColumn("LogoImage", typeof(byte[]), null, MappingType.Element);
			base.Columns.Add(columnLogoImage);
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
			OfficeStaff officeStaff = new OfficeStaff();
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
			xmlSchemaAttribute.FixedValue = officeStaff.Namespace;
			xmlSchemaComplexType.Attributes.Add(xmlSchemaAttribute);
			XmlSchemaAttribute xmlSchemaAttribute2 = new XmlSchemaAttribute();
			xmlSchemaAttribute2.Name = "tableTypeName";
			xmlSchemaAttribute2.FixedValue = "DataTable1DataTable";
			xmlSchemaComplexType.Attributes.Add(xmlSchemaAttribute2);
			xmlSchemaComplexType.Particle = xmlSchemaSequence;
			XmlSchema schemaSerializable = officeStaff.GetSchemaSerializable();
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
		public string CompanyName
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.CompanyNameColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'CompanyName' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.CompanyNameColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public byte[] PhotoData
		{
			get
			{
				try
				{
					return (byte[])base[tableDataTable1.PhotoDataColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'PhotoData' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.PhotoDataColumn] = value;
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
		public string CardNo
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.CardNoColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'CardNo' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.CardNoColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string EmpName
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.EmpNameColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'EmpName' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.EmpNameColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string Department
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.DepartmentColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Department' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.DepartmentColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string BussinessGroup
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.BussinessGroupColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'BussinessGroup' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.BussinessGroupColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string DeptDirector
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.DeptDirectorColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'DeptDirector' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.DeptDirectorColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string DeptHead
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.DeptHeadColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'DeptHead' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.DeptHeadColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string GroupLeader
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.GroupLeaderColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'GroupLeader' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.GroupLeaderColumn] = value;
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
		public string MobileNo
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.MobileNoColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'MobileNo' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.MobileNoColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string extNo
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.extNoColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'extNo' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.extNoColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string joindate
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.joindateColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'joindate' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.joindateColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string birthdate
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.birthdateColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'birthdate' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.birthdateColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string resigndate
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.resigndateColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'resigndate' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.resigndateColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string martialstatus
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.martialstatusColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'martialstatus' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.martialstatusColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string physicalstatus
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.physicalstatusColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'physicalstatus' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.physicalstatusColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string padd
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.paddColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'padd' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.paddColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string cadd
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.caddColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'cadd' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.caddColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string email
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.emailColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'email' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.emailColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string gender
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.genderColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'gender' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.genderColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string bgp
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.bgpColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'bgp' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.bgpColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string height
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.heightColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'height' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.heightColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string weight
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.weightColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'weight' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.weightColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string religion
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.religionColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'religion' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.religionColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string cast
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.castColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'cast' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.castColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string edu
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.eduColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'edu' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.eduColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string adq
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.adqColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'adq' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.adqColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string lc
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.lcColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'lc' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.lcColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string wd
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.wdColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'wd' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.wdColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string te
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.teColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'te' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.teColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string ctc
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.ctcColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'ctc' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.ctcColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string ba
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.baColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'ba' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.baColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string pf
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.pfColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'pf' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.pfColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string pa
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.paColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'pa' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.paColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string ps
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.psColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'ps' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.psColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string ex
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.exColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'ex' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.exColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string inf
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.infColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'inf' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.infColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public byte[] LogoImage
		{
			get
			{
				try
				{
					return (byte[])base[tableDataTable1.LogoImageColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'LogoImage' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.LogoImageColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		internal DataTable1Row(DataRowBuilder rb)
			: base(rb)
		{
			tableDataTable1 = (DataTable1DataTable)base.Table;
		}

		[DebuggerNonUserCode]
		public bool IsCompanyNameNull()
		{
			return IsNull(tableDataTable1.CompanyNameColumn);
		}

		[DebuggerNonUserCode]
		public void SetCompanyNameNull()
		{
			base[tableDataTable1.CompanyNameColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsPhotoDataNull()
		{
			return IsNull(tableDataTable1.PhotoDataColumn);
		}

		[DebuggerNonUserCode]
		public void SetPhotoDataNull()
		{
			base[tableDataTable1.PhotoDataColumn] = Convert.DBNull;
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
		public bool IsCardNoNull()
		{
			return IsNull(tableDataTable1.CardNoColumn);
		}

		[DebuggerNonUserCode]
		public void SetCardNoNull()
		{
			base[tableDataTable1.CardNoColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsEmpNameNull()
		{
			return IsNull(tableDataTable1.EmpNameColumn);
		}

		[DebuggerNonUserCode]
		public void SetEmpNameNull()
		{
			base[tableDataTable1.EmpNameColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsDepartmentNull()
		{
			return IsNull(tableDataTable1.DepartmentColumn);
		}

		[DebuggerNonUserCode]
		public void SetDepartmentNull()
		{
			base[tableDataTable1.DepartmentColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsBussinessGroupNull()
		{
			return IsNull(tableDataTable1.BussinessGroupColumn);
		}

		[DebuggerNonUserCode]
		public void SetBussinessGroupNull()
		{
			base[tableDataTable1.BussinessGroupColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsDeptDirectorNull()
		{
			return IsNull(tableDataTable1.DeptDirectorColumn);
		}

		[DebuggerNonUserCode]
		public void SetDeptDirectorNull()
		{
			base[tableDataTable1.DeptDirectorColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsDeptHeadNull()
		{
			return IsNull(tableDataTable1.DeptHeadColumn);
		}

		[DebuggerNonUserCode]
		public void SetDeptHeadNull()
		{
			base[tableDataTable1.DeptHeadColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsGroupLeaderNull()
		{
			return IsNull(tableDataTable1.GroupLeaderColumn);
		}

		[DebuggerNonUserCode]
		public void SetGroupLeaderNull()
		{
			base[tableDataTable1.GroupLeaderColumn] = Convert.DBNull;
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
		public bool IsMobileNoNull()
		{
			return IsNull(tableDataTable1.MobileNoColumn);
		}

		[DebuggerNonUserCode]
		public void SetMobileNoNull()
		{
			base[tableDataTable1.MobileNoColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsextNoNull()
		{
			return IsNull(tableDataTable1.extNoColumn);
		}

		[DebuggerNonUserCode]
		public void SetextNoNull()
		{
			base[tableDataTable1.extNoColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsjoindateNull()
		{
			return IsNull(tableDataTable1.joindateColumn);
		}

		[DebuggerNonUserCode]
		public void SetjoindateNull()
		{
			base[tableDataTable1.joindateColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsbirthdateNull()
		{
			return IsNull(tableDataTable1.birthdateColumn);
		}

		[DebuggerNonUserCode]
		public void SetbirthdateNull()
		{
			base[tableDataTable1.birthdateColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsresigndateNull()
		{
			return IsNull(tableDataTable1.resigndateColumn);
		}

		[DebuggerNonUserCode]
		public void SetresigndateNull()
		{
			base[tableDataTable1.resigndateColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsmartialstatusNull()
		{
			return IsNull(tableDataTable1.martialstatusColumn);
		}

		[DebuggerNonUserCode]
		public void SetmartialstatusNull()
		{
			base[tableDataTable1.martialstatusColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsphysicalstatusNull()
		{
			return IsNull(tableDataTable1.physicalstatusColumn);
		}

		[DebuggerNonUserCode]
		public void SetphysicalstatusNull()
		{
			base[tableDataTable1.physicalstatusColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IspaddNull()
		{
			return IsNull(tableDataTable1.paddColumn);
		}

		[DebuggerNonUserCode]
		public void SetpaddNull()
		{
			base[tableDataTable1.paddColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IscaddNull()
		{
			return IsNull(tableDataTable1.caddColumn);
		}

		[DebuggerNonUserCode]
		public void SetcaddNull()
		{
			base[tableDataTable1.caddColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsemailNull()
		{
			return IsNull(tableDataTable1.emailColumn);
		}

		[DebuggerNonUserCode]
		public void SetemailNull()
		{
			base[tableDataTable1.emailColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsgenderNull()
		{
			return IsNull(tableDataTable1.genderColumn);
		}

		[DebuggerNonUserCode]
		public void SetgenderNull()
		{
			base[tableDataTable1.genderColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsbgpNull()
		{
			return IsNull(tableDataTable1.bgpColumn);
		}

		[DebuggerNonUserCode]
		public void SetbgpNull()
		{
			base[tableDataTable1.bgpColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsheightNull()
		{
			return IsNull(tableDataTable1.heightColumn);
		}

		[DebuggerNonUserCode]
		public void SetheightNull()
		{
			base[tableDataTable1.heightColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsweightNull()
		{
			return IsNull(tableDataTable1.weightColumn);
		}

		[DebuggerNonUserCode]
		public void SetweightNull()
		{
			base[tableDataTable1.weightColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsreligionNull()
		{
			return IsNull(tableDataTable1.religionColumn);
		}

		[DebuggerNonUserCode]
		public void SetreligionNull()
		{
			base[tableDataTable1.religionColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IscastNull()
		{
			return IsNull(tableDataTable1.castColumn);
		}

		[DebuggerNonUserCode]
		public void SetcastNull()
		{
			base[tableDataTable1.castColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IseduNull()
		{
			return IsNull(tableDataTable1.eduColumn);
		}

		[DebuggerNonUserCode]
		public void SeteduNull()
		{
			base[tableDataTable1.eduColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsadqNull()
		{
			return IsNull(tableDataTable1.adqColumn);
		}

		[DebuggerNonUserCode]
		public void SetadqNull()
		{
			base[tableDataTable1.adqColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IslcNull()
		{
			return IsNull(tableDataTable1.lcColumn);
		}

		[DebuggerNonUserCode]
		public void SetlcNull()
		{
			base[tableDataTable1.lcColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IswdNull()
		{
			return IsNull(tableDataTable1.wdColumn);
		}

		[DebuggerNonUserCode]
		public void SetwdNull()
		{
			base[tableDataTable1.wdColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsteNull()
		{
			return IsNull(tableDataTable1.teColumn);
		}

		[DebuggerNonUserCode]
		public void SetteNull()
		{
			base[tableDataTable1.teColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsctcNull()
		{
			return IsNull(tableDataTable1.ctcColumn);
		}

		[DebuggerNonUserCode]
		public void SetctcNull()
		{
			base[tableDataTable1.ctcColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsbaNull()
		{
			return IsNull(tableDataTable1.baColumn);
		}

		[DebuggerNonUserCode]
		public void SetbaNull()
		{
			base[tableDataTable1.baColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IspfNull()
		{
			return IsNull(tableDataTable1.pfColumn);
		}

		[DebuggerNonUserCode]
		public void SetpfNull()
		{
			base[tableDataTable1.pfColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IspaNull()
		{
			return IsNull(tableDataTable1.paColumn);
		}

		[DebuggerNonUserCode]
		public void SetpaNull()
		{
			base[tableDataTable1.paColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IspsNull()
		{
			return IsNull(tableDataTable1.psColumn);
		}

		[DebuggerNonUserCode]
		public void SetpsNull()
		{
			base[tableDataTable1.psColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsexNull()
		{
			return IsNull(tableDataTable1.exColumn);
		}

		[DebuggerNonUserCode]
		public void SetexNull()
		{
			base[tableDataTable1.exColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsinfNull()
		{
			return IsNull(tableDataTable1.infColumn);
		}

		[DebuggerNonUserCode]
		public void SetinfNull()
		{
			base[tableDataTable1.infColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsLogoImageNull()
		{
			return IsNull(tableDataTable1.LogoImageColumn);
		}

		[DebuggerNonUserCode]
		public void SetLogoImageNull()
		{
			base[tableDataTable1.LogoImageColumn] = Convert.DBNull;
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
	public OfficeStaff()
	{
		BeginInit();
		InitClass();
		CollectionChangeEventHandler value = SchemaChanged;
		base.Tables.CollectionChanged += value;
		base.Relations.CollectionChanged += value;
		EndInit();
	}

	[DebuggerNonUserCode]
	protected OfficeStaff(SerializationInfo info, StreamingContext context)
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
		OfficeStaff officeStaff = (OfficeStaff)base.Clone();
		officeStaff.InitVars();
		officeStaff.SchemaSerializationMode = SchemaSerializationMode;
		return officeStaff;
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
		base.DataSetName = "OfficeStaff";
		base.Prefix = "";
		base.Namespace = "http://tempuri.org/OfficeStaff.xsd";
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
		OfficeStaff officeStaff = new OfficeStaff();
		XmlSchemaComplexType xmlSchemaComplexType = new XmlSchemaComplexType();
		XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
		XmlSchemaAny xmlSchemaAny = new XmlSchemaAny();
		xmlSchemaAny.Namespace = officeStaff.Namespace;
		xmlSchemaSequence.Items.Add(xmlSchemaAny);
		xmlSchemaComplexType.Particle = xmlSchemaSequence;
		XmlSchema schemaSerializable = officeStaff.GetSchemaSerializable();
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
