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
[XmlRoot("GatePassPrint")]
[HelpKeyword("vs.data.DataSet")]
[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
[DesignerCategory("code")]
[ToolboxItem(true)]
[XmlSchemaProvider("GetTypedDataSetSchema")]
public class GatePassPrint : DataSet
{
	public delegate void DataTable1RowChangeEventHandler(object sender, DataTable1RowChangeEvent e);

	[Serializable]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
	[XmlSchemaProvider("GetTypedTableSchema")]
	public class DataTable1DataTable : TypedTableBase<DataTable1Row>
	{
		private DataColumn columnId;

		private DataColumn columnFinYear;

		private DataColumn columnGPNo;

		private DataColumn columnFromDate;

		private DataColumn columnFromTime;

		private DataColumn columnToTime;

		private DataColumn columnType;

		private DataColumn columnTypeFor;

		private DataColumn columnReason;

		private DataColumn columnAuthorizedBy;

		private DataColumn columnAuthorizeDate;

		private DataColumn columnAuthorizeTime;

		private DataColumn columnFeedback;

		private DataColumn columnDId;

		private DataColumn columnSelfEId;

		private DataColumn columnAuthorize;

		private DataColumn columnPlace;

		private DataColumn columnContactPerson;

		private DataColumn columnContactNo;

		private DataColumn columnEmpother;

		private DataColumn columnCompId;

		private DataColumn columnToDate;

		private DataColumn columnEmpType;

		[DebuggerNonUserCode]
		public DataColumn IdColumn => columnId;

		[DebuggerNonUserCode]
		public DataColumn FinYearColumn => columnFinYear;

		[DebuggerNonUserCode]
		public DataColumn GPNoColumn => columnGPNo;

		[DebuggerNonUserCode]
		public DataColumn FromDateColumn => columnFromDate;

		[DebuggerNonUserCode]
		public DataColumn FromTimeColumn => columnFromTime;

		[DebuggerNonUserCode]
		public DataColumn ToTimeColumn => columnToTime;

		[DebuggerNonUserCode]
		public DataColumn TypeColumn => columnType;

		[DebuggerNonUserCode]
		public DataColumn TypeForColumn => columnTypeFor;

		[DebuggerNonUserCode]
		public DataColumn ReasonColumn => columnReason;

		[DebuggerNonUserCode]
		public DataColumn AuthorizedByColumn => columnAuthorizedBy;

		[DebuggerNonUserCode]
		public DataColumn AuthorizeDateColumn => columnAuthorizeDate;

		[DebuggerNonUserCode]
		public DataColumn AuthorizeTimeColumn => columnAuthorizeTime;

		[DebuggerNonUserCode]
		public DataColumn FeedbackColumn => columnFeedback;

		[DebuggerNonUserCode]
		public DataColumn DIdColumn => columnDId;

		[DebuggerNonUserCode]
		public DataColumn SelfEIdColumn => columnSelfEId;

		[DebuggerNonUserCode]
		public DataColumn AuthorizeColumn => columnAuthorize;

		[DebuggerNonUserCode]
		public DataColumn PlaceColumn => columnPlace;

		[DebuggerNonUserCode]
		public DataColumn ContactPersonColumn => columnContactPerson;

		[DebuggerNonUserCode]
		public DataColumn ContactNoColumn => columnContactNo;

		[DebuggerNonUserCode]
		public DataColumn EmpotherColumn => columnEmpother;

		[DebuggerNonUserCode]
		public DataColumn CompIdColumn => columnCompId;

		[DebuggerNonUserCode]
		public DataColumn ToDateColumn => columnToDate;

		[DebuggerNonUserCode]
		public DataColumn EmpTypeColumn => columnEmpType;

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
		public DataTable1Row AddDataTable1Row(int Id, string FinYear, string GPNo, string FromDate, string FromTime, string ToTime, string Type, string TypeFor, string Reason, string AuthorizedBy, string AuthorizeDate, string AuthorizeTime, string Feedback, int DId, string SelfEId, int Authorize, string Place, string ContactPerson, string ContactNo, string Empother, int CompId, string ToDate, string EmpType)
		{
			DataTable1Row dataTable1Row = (DataTable1Row)NewRow();
			object[] itemArray = new object[23]
			{
				Id, FinYear, GPNo, FromDate, FromTime, ToTime, Type, TypeFor, Reason, AuthorizedBy,
				AuthorizeDate, AuthorizeTime, Feedback, DId, SelfEId, Authorize, Place, ContactPerson, ContactNo, Empother,
				CompId, ToDate, EmpType
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
			columnFinYear = base.Columns["FinYear"];
			columnGPNo = base.Columns["GPNo"];
			columnFromDate = base.Columns["FromDate"];
			columnFromTime = base.Columns["FromTime"];
			columnToTime = base.Columns["ToTime"];
			columnType = base.Columns["Type"];
			columnTypeFor = base.Columns["TypeFor"];
			columnReason = base.Columns["Reason"];
			columnAuthorizedBy = base.Columns["AuthorizedBy"];
			columnAuthorizeDate = base.Columns["AuthorizeDate"];
			columnAuthorizeTime = base.Columns["AuthorizeTime"];
			columnFeedback = base.Columns["Feedback"];
			columnDId = base.Columns["DId"];
			columnSelfEId = base.Columns["SelfEId"];
			columnAuthorize = base.Columns["Authorize"];
			columnPlace = base.Columns["Place"];
			columnContactPerson = base.Columns["ContactPerson"];
			columnContactNo = base.Columns["ContactNo"];
			columnEmpother = base.Columns["Empother"];
			columnCompId = base.Columns["CompId"];
			columnToDate = base.Columns["ToDate"];
			columnEmpType = base.Columns["EmpType"];
		}

		[DebuggerNonUserCode]
		private void InitClass()
		{
			columnId = new DataColumn("Id", typeof(int), null, MappingType.Element);
			base.Columns.Add(columnId);
			columnFinYear = new DataColumn("FinYear", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnFinYear);
			columnGPNo = new DataColumn("GPNo", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnGPNo);
			columnFromDate = new DataColumn("FromDate", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnFromDate);
			columnFromTime = new DataColumn("FromTime", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnFromTime);
			columnToTime = new DataColumn("ToTime", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnToTime);
			columnType = new DataColumn("Type", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnType);
			columnTypeFor = new DataColumn("TypeFor", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnTypeFor);
			columnReason = new DataColumn("Reason", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnReason);
			columnAuthorizedBy = new DataColumn("AuthorizedBy", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnAuthorizedBy);
			columnAuthorizeDate = new DataColumn("AuthorizeDate", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnAuthorizeDate);
			columnAuthorizeTime = new DataColumn("AuthorizeTime", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnAuthorizeTime);
			columnFeedback = new DataColumn("Feedback", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnFeedback);
			columnDId = new DataColumn("DId", typeof(int), null, MappingType.Element);
			base.Columns.Add(columnDId);
			columnSelfEId = new DataColumn("SelfEId", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnSelfEId);
			columnAuthorize = new DataColumn("Authorize", typeof(int), null, MappingType.Element);
			base.Columns.Add(columnAuthorize);
			columnPlace = new DataColumn("Place", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnPlace);
			columnContactPerson = new DataColumn("ContactPerson", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnContactPerson);
			columnContactNo = new DataColumn("ContactNo", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnContactNo);
			columnEmpother = new DataColumn("Empother", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnEmpother);
			columnCompId = new DataColumn("CompId", typeof(int), null, MappingType.Element);
			base.Columns.Add(columnCompId);
			columnToDate = new DataColumn("ToDate", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnToDate);
			columnEmpType = new DataColumn("EmpType", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnEmpType);
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
			GatePassPrint gatePassPrint = new GatePassPrint();
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
			xmlSchemaAttribute.FixedValue = gatePassPrint.Namespace;
			xmlSchemaComplexType.Attributes.Add(xmlSchemaAttribute);
			XmlSchemaAttribute xmlSchemaAttribute2 = new XmlSchemaAttribute();
			xmlSchemaAttribute2.Name = "tableTypeName";
			xmlSchemaAttribute2.FixedValue = "DataTable1DataTable";
			xmlSchemaComplexType.Attributes.Add(xmlSchemaAttribute2);
			xmlSchemaComplexType.Particle = xmlSchemaSequence;
			XmlSchema schemaSerializable = gatePassPrint.GetSchemaSerializable();
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
		public string GPNo
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.GPNoColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'GPNo' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.GPNoColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string FromDate
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.FromDateColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'FromDate' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.FromDateColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string FromTime
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.FromTimeColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'FromTime' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.FromTimeColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string ToTime
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.ToTimeColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'ToTime' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.ToTimeColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string Type
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.TypeColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Type' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.TypeColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string TypeFor
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.TypeForColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'TypeFor' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.TypeForColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string Reason
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.ReasonColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Reason' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.ReasonColumn] = value;
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
		public string AuthorizeDate
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.AuthorizeDateColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'AuthorizeDate' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.AuthorizeDateColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string AuthorizeTime
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.AuthorizeTimeColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'AuthorizeTime' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.AuthorizeTimeColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string Feedback
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.FeedbackColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Feedback' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.FeedbackColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public int DId
		{
			get
			{
				try
				{
					return (int)base[tableDataTable1.DIdColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'DId' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.DIdColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string SelfEId
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.SelfEIdColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'SelfEId' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.SelfEIdColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public int Authorize
		{
			get
			{
				try
				{
					return (int)base[tableDataTable1.AuthorizeColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Authorize' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.AuthorizeColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string Place
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.PlaceColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Place' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.PlaceColumn] = value;
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
		public string Empother
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.EmpotherColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Empother' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.EmpotherColumn] = value;
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
		public string ToDate
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.ToDateColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'ToDate' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.ToDateColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string EmpType
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.EmpTypeColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'EmpType' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.EmpTypeColumn] = value;
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
		public bool IsGPNoNull()
		{
			return IsNull(tableDataTable1.GPNoColumn);
		}

		[DebuggerNonUserCode]
		public void SetGPNoNull()
		{
			base[tableDataTable1.GPNoColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsFromDateNull()
		{
			return IsNull(tableDataTable1.FromDateColumn);
		}

		[DebuggerNonUserCode]
		public void SetFromDateNull()
		{
			base[tableDataTable1.FromDateColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsFromTimeNull()
		{
			return IsNull(tableDataTable1.FromTimeColumn);
		}

		[DebuggerNonUserCode]
		public void SetFromTimeNull()
		{
			base[tableDataTable1.FromTimeColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsToTimeNull()
		{
			return IsNull(tableDataTable1.ToTimeColumn);
		}

		[DebuggerNonUserCode]
		public void SetToTimeNull()
		{
			base[tableDataTable1.ToTimeColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsTypeNull()
		{
			return IsNull(tableDataTable1.TypeColumn);
		}

		[DebuggerNonUserCode]
		public void SetTypeNull()
		{
			base[tableDataTable1.TypeColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsTypeForNull()
		{
			return IsNull(tableDataTable1.TypeForColumn);
		}

		[DebuggerNonUserCode]
		public void SetTypeForNull()
		{
			base[tableDataTable1.TypeForColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsReasonNull()
		{
			return IsNull(tableDataTable1.ReasonColumn);
		}

		[DebuggerNonUserCode]
		public void SetReasonNull()
		{
			base[tableDataTable1.ReasonColumn] = Convert.DBNull;
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
		public bool IsAuthorizeDateNull()
		{
			return IsNull(tableDataTable1.AuthorizeDateColumn);
		}

		[DebuggerNonUserCode]
		public void SetAuthorizeDateNull()
		{
			base[tableDataTable1.AuthorizeDateColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsAuthorizeTimeNull()
		{
			return IsNull(tableDataTable1.AuthorizeTimeColumn);
		}

		[DebuggerNonUserCode]
		public void SetAuthorizeTimeNull()
		{
			base[tableDataTable1.AuthorizeTimeColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsFeedbackNull()
		{
			return IsNull(tableDataTable1.FeedbackColumn);
		}

		[DebuggerNonUserCode]
		public void SetFeedbackNull()
		{
			base[tableDataTable1.FeedbackColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsDIdNull()
		{
			return IsNull(tableDataTable1.DIdColumn);
		}

		[DebuggerNonUserCode]
		public void SetDIdNull()
		{
			base[tableDataTable1.DIdColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsSelfEIdNull()
		{
			return IsNull(tableDataTable1.SelfEIdColumn);
		}

		[DebuggerNonUserCode]
		public void SetSelfEIdNull()
		{
			base[tableDataTable1.SelfEIdColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsAuthorizeNull()
		{
			return IsNull(tableDataTable1.AuthorizeColumn);
		}

		[DebuggerNonUserCode]
		public void SetAuthorizeNull()
		{
			base[tableDataTable1.AuthorizeColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsPlaceNull()
		{
			return IsNull(tableDataTable1.PlaceColumn);
		}

		[DebuggerNonUserCode]
		public void SetPlaceNull()
		{
			base[tableDataTable1.PlaceColumn] = Convert.DBNull;
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
		public bool IsEmpotherNull()
		{
			return IsNull(tableDataTable1.EmpotherColumn);
		}

		[DebuggerNonUserCode]
		public void SetEmpotherNull()
		{
			base[tableDataTable1.EmpotherColumn] = Convert.DBNull;
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
		public bool IsToDateNull()
		{
			return IsNull(tableDataTable1.ToDateColumn);
		}

		[DebuggerNonUserCode]
		public void SetToDateNull()
		{
			base[tableDataTable1.ToDateColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsEmpTypeNull()
		{
			return IsNull(tableDataTable1.EmpTypeColumn);
		}

		[DebuggerNonUserCode]
		public void SetEmpTypeNull()
		{
			base[tableDataTable1.EmpTypeColumn] = Convert.DBNull;
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

	[Browsable(true)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
	[DebuggerNonUserCode]
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
	public GatePassPrint()
	{
		BeginInit();
		InitClass();
		CollectionChangeEventHandler value = SchemaChanged;
		base.Tables.CollectionChanged += value;
		base.Relations.CollectionChanged += value;
		EndInit();
	}

	[DebuggerNonUserCode]
	protected GatePassPrint(SerializationInfo info, StreamingContext context)
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
		GatePassPrint gatePassPrint = (GatePassPrint)base.Clone();
		gatePassPrint.InitVars();
		gatePassPrint.SchemaSerializationMode = SchemaSerializationMode;
		return gatePassPrint;
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
		base.DataSetName = "GatePassPrint";
		base.Prefix = "";
		base.Namespace = "http://tempuri.org/GatePassPrint.xsd";
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
		GatePassPrint gatePassPrint = new GatePassPrint();
		XmlSchemaComplexType xmlSchemaComplexType = new XmlSchemaComplexType();
		XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
		XmlSchemaAny xmlSchemaAny = new XmlSchemaAny();
		xmlSchemaAny.Namespace = gatePassPrint.Namespace;
		xmlSchemaSequence.Items.Add(xmlSchemaAny);
		xmlSchemaComplexType.Particle = xmlSchemaSequence;
		XmlSchema schemaSerializable = gatePassPrint.GetSchemaSerializable();
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
