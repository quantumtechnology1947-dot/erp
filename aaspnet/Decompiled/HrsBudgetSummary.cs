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
[XmlRoot("HrsBudgetSummary")]
[HelpKeyword("vs.data.DataSet")]
[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
[DesignerCategory("code")]
[ToolboxItem(true)]
[XmlSchemaProvider("GetTypedDataSetSchema")]
public class HrsBudgetSummary : DataSet
{
	public delegate void DataTable1RowChangeEventHandler(object sender, DataTable1RowChangeEvent e);

	[Serializable]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
	[XmlSchemaProvider("GetTypedTableSchema")]
	public class DataTable1DataTable : TypedTableBase<DataTable1Row>
	{
		private DataColumn columnWONo;

		private DataColumn columnCompId;

		private DataColumn columnProjectTitle;

		private DataColumn columnMDesign;

		private DataColumn columnMAssly;

		private DataColumn columnMCert;

		private DataColumn columnMTrials;

		private DataColumn columnMDisp;

		private DataColumn columnMIC;

		private DataColumn columnMTryOut;

		private DataColumn columnDDesign;

		private DataColumn columnDAssly;

		private DataColumn columnDCert;

		private DataColumn columnDTrials;

		private DataColumn columnDDisp;

		private DataColumn columnDIC;

		private DataColumn columnDTryOut;

		private DataColumn columnHyrLink;

		[DebuggerNonUserCode]
		public DataColumn WONoColumn => columnWONo;

		[DebuggerNonUserCode]
		public DataColumn CompIdColumn => columnCompId;

		[DebuggerNonUserCode]
		public DataColumn ProjectTitleColumn => columnProjectTitle;

		[DebuggerNonUserCode]
		public DataColumn MDesignColumn => columnMDesign;

		[DebuggerNonUserCode]
		public DataColumn MAsslyColumn => columnMAssly;

		[DebuggerNonUserCode]
		public DataColumn MCertColumn => columnMCert;

		[DebuggerNonUserCode]
		public DataColumn MTrialsColumn => columnMTrials;

		[DebuggerNonUserCode]
		public DataColumn MDispColumn => columnMDisp;

		[DebuggerNonUserCode]
		public DataColumn MICColumn => columnMIC;

		[DebuggerNonUserCode]
		public DataColumn MTryOutColumn => columnMTryOut;

		[DebuggerNonUserCode]
		public DataColumn DDesignColumn => columnDDesign;

		[DebuggerNonUserCode]
		public DataColumn DAsslyColumn => columnDAssly;

		[DebuggerNonUserCode]
		public DataColumn DCertColumn => columnDCert;

		[DebuggerNonUserCode]
		public DataColumn DTrialsColumn => columnDTrials;

		[DebuggerNonUserCode]
		public DataColumn DDispColumn => columnDDisp;

		[DebuggerNonUserCode]
		public DataColumn DICColumn => columnDIC;

		[DebuggerNonUserCode]
		public DataColumn DTryOutColumn => columnDTryOut;

		[DebuggerNonUserCode]
		public DataColumn HyrLinkColumn => columnHyrLink;

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
		public DataTable1Row AddDataTable1Row(string WONo, int CompId, string ProjectTitle, double MDesign, double MAssly, double MCert, double MTrials, double MDisp, double MIC, double MTryOut, double DDesign, double DAssly, double DCert, double DTrials, double DDisp, double DIC, double DTryOut, string HyrLink)
		{
			DataTable1Row dataTable1Row = (DataTable1Row)NewRow();
			object[] itemArray = new object[18]
			{
				WONo, CompId, ProjectTitle, MDesign, MAssly, MCert, MTrials, MDisp, MIC, MTryOut,
				DDesign, DAssly, DCert, DTrials, DDisp, DIC, DTryOut, HyrLink
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
			columnWONo = base.Columns["WONo"];
			columnCompId = base.Columns["CompId"];
			columnProjectTitle = base.Columns["ProjectTitle"];
			columnMDesign = base.Columns["MDesign"];
			columnMAssly = base.Columns["MAssly"];
			columnMCert = base.Columns["MCert"];
			columnMTrials = base.Columns["MTrials"];
			columnMDisp = base.Columns["MDisp"];
			columnMIC = base.Columns["MIC"];
			columnMTryOut = base.Columns["MTryOut"];
			columnDDesign = base.Columns["DDesign"];
			columnDAssly = base.Columns["DAssly"];
			columnDCert = base.Columns["DCert"];
			columnDTrials = base.Columns["DTrials"];
			columnDDisp = base.Columns["DDisp"];
			columnDIC = base.Columns["DIC"];
			columnDTryOut = base.Columns["DTryOut"];
			columnHyrLink = base.Columns["HyrLink"];
		}

		[DebuggerNonUserCode]
		private void InitClass()
		{
			columnWONo = new DataColumn("WONo", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnWONo);
			columnCompId = new DataColumn("CompId", typeof(int), null, MappingType.Element);
			base.Columns.Add(columnCompId);
			columnProjectTitle = new DataColumn("ProjectTitle", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnProjectTitle);
			columnMDesign = new DataColumn("MDesign", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnMDesign);
			columnMAssly = new DataColumn("MAssly", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnMAssly);
			columnMCert = new DataColumn("MCert", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnMCert);
			columnMTrials = new DataColumn("MTrials", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnMTrials);
			columnMDisp = new DataColumn("MDisp", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnMDisp);
			columnMIC = new DataColumn("MIC", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnMIC);
			columnMTryOut = new DataColumn("MTryOut", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnMTryOut);
			columnDDesign = new DataColumn("DDesign", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnDDesign);
			columnDAssly = new DataColumn("DAssly", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnDAssly);
			columnDCert = new DataColumn("DCert", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnDCert);
			columnDTrials = new DataColumn("DTrials", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnDTrials);
			columnDDisp = new DataColumn("DDisp", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnDDisp);
			columnDIC = new DataColumn("DIC", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnDIC);
			columnDTryOut = new DataColumn("DTryOut", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnDTryOut);
			columnHyrLink = new DataColumn("HyrLink", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnHyrLink);
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
			HrsBudgetSummary hrsBudgetSummary = new HrsBudgetSummary();
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
			xmlSchemaAttribute.FixedValue = hrsBudgetSummary.Namespace;
			xmlSchemaComplexType.Attributes.Add(xmlSchemaAttribute);
			XmlSchemaAttribute xmlSchemaAttribute2 = new XmlSchemaAttribute();
			xmlSchemaAttribute2.Name = "tableTypeName";
			xmlSchemaAttribute2.FixedValue = "DataTable1DataTable";
			xmlSchemaComplexType.Attributes.Add(xmlSchemaAttribute2);
			xmlSchemaComplexType.Particle = xmlSchemaSequence;
			XmlSchema schemaSerializable = hrsBudgetSummary.GetSchemaSerializable();
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
		public string ProjectTitle
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.ProjectTitleColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'ProjectTitle' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.ProjectTitleColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public double MDesign
		{
			get
			{
				try
				{
					return (double)base[tableDataTable1.MDesignColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'MDesign' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.MDesignColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public double MAssly
		{
			get
			{
				try
				{
					return (double)base[tableDataTable1.MAsslyColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'MAssly' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.MAsslyColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public double MCert
		{
			get
			{
				try
				{
					return (double)base[tableDataTable1.MCertColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'MCert' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.MCertColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public double MTrials
		{
			get
			{
				try
				{
					return (double)base[tableDataTable1.MTrialsColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'MTrials' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.MTrialsColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public double MDisp
		{
			get
			{
				try
				{
					return (double)base[tableDataTable1.MDispColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'MDisp' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.MDispColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public double MIC
		{
			get
			{
				try
				{
					return (double)base[tableDataTable1.MICColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'MIC' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.MICColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public double MTryOut
		{
			get
			{
				try
				{
					return (double)base[tableDataTable1.MTryOutColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'MTryOut' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.MTryOutColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public double DDesign
		{
			get
			{
				try
				{
					return (double)base[tableDataTable1.DDesignColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'DDesign' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.DDesignColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public double DAssly
		{
			get
			{
				try
				{
					return (double)base[tableDataTable1.DAsslyColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'DAssly' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.DAsslyColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public double DCert
		{
			get
			{
				try
				{
					return (double)base[tableDataTable1.DCertColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'DCert' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.DCertColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public double DTrials
		{
			get
			{
				try
				{
					return (double)base[tableDataTable1.DTrialsColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'DTrials' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.DTrialsColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public double DDisp
		{
			get
			{
				try
				{
					return (double)base[tableDataTable1.DDispColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'DDisp' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.DDispColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public double DIC
		{
			get
			{
				try
				{
					return (double)base[tableDataTable1.DICColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'DIC' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.DICColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public double DTryOut
		{
			get
			{
				try
				{
					return (double)base[tableDataTable1.DTryOutColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'DTryOut' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.DTryOutColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		public string HyrLink
		{
			get
			{
				try
				{
					return (string)base[tableDataTable1.HyrLinkColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'HyrLink' in table 'DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDataTable1.HyrLinkColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		internal DataTable1Row(DataRowBuilder rb)
			: base(rb)
		{
			tableDataTable1 = (DataTable1DataTable)base.Table;
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
		public bool IsProjectTitleNull()
		{
			return IsNull(tableDataTable1.ProjectTitleColumn);
		}

		[DebuggerNonUserCode]
		public void SetProjectTitleNull()
		{
			base[tableDataTable1.ProjectTitleColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsMDesignNull()
		{
			return IsNull(tableDataTable1.MDesignColumn);
		}

		[DebuggerNonUserCode]
		public void SetMDesignNull()
		{
			base[tableDataTable1.MDesignColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsMAsslyNull()
		{
			return IsNull(tableDataTable1.MAsslyColumn);
		}

		[DebuggerNonUserCode]
		public void SetMAsslyNull()
		{
			base[tableDataTable1.MAsslyColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsMCertNull()
		{
			return IsNull(tableDataTable1.MCertColumn);
		}

		[DebuggerNonUserCode]
		public void SetMCertNull()
		{
			base[tableDataTable1.MCertColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsMTrialsNull()
		{
			return IsNull(tableDataTable1.MTrialsColumn);
		}

		[DebuggerNonUserCode]
		public void SetMTrialsNull()
		{
			base[tableDataTable1.MTrialsColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsMDispNull()
		{
			return IsNull(tableDataTable1.MDispColumn);
		}

		[DebuggerNonUserCode]
		public void SetMDispNull()
		{
			base[tableDataTable1.MDispColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsMICNull()
		{
			return IsNull(tableDataTable1.MICColumn);
		}

		[DebuggerNonUserCode]
		public void SetMICNull()
		{
			base[tableDataTable1.MICColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsMTryOutNull()
		{
			return IsNull(tableDataTable1.MTryOutColumn);
		}

		[DebuggerNonUserCode]
		public void SetMTryOutNull()
		{
			base[tableDataTable1.MTryOutColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsDDesignNull()
		{
			return IsNull(tableDataTable1.DDesignColumn);
		}

		[DebuggerNonUserCode]
		public void SetDDesignNull()
		{
			base[tableDataTable1.DDesignColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsDAsslyNull()
		{
			return IsNull(tableDataTable1.DAsslyColumn);
		}

		[DebuggerNonUserCode]
		public void SetDAsslyNull()
		{
			base[tableDataTable1.DAsslyColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsDCertNull()
		{
			return IsNull(tableDataTable1.DCertColumn);
		}

		[DebuggerNonUserCode]
		public void SetDCertNull()
		{
			base[tableDataTable1.DCertColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsDTrialsNull()
		{
			return IsNull(tableDataTable1.DTrialsColumn);
		}

		[DebuggerNonUserCode]
		public void SetDTrialsNull()
		{
			base[tableDataTable1.DTrialsColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsDDispNull()
		{
			return IsNull(tableDataTable1.DDispColumn);
		}

		[DebuggerNonUserCode]
		public void SetDDispNull()
		{
			base[tableDataTable1.DDispColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsDICNull()
		{
			return IsNull(tableDataTable1.DICColumn);
		}

		[DebuggerNonUserCode]
		public void SetDICNull()
		{
			base[tableDataTable1.DICColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsDTryOutNull()
		{
			return IsNull(tableDataTable1.DTryOutColumn);
		}

		[DebuggerNonUserCode]
		public void SetDTryOutNull()
		{
			base[tableDataTable1.DTryOutColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		public bool IsHyrLinkNull()
		{
			return IsNull(tableDataTable1.HyrLinkColumn);
		}

		[DebuggerNonUserCode]
		public void SetHyrLinkNull()
		{
			base[tableDataTable1.HyrLinkColumn] = Convert.DBNull;
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

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[DebuggerNonUserCode]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataRelationCollection Relations => base.Relations;

	[DebuggerNonUserCode]
	public HrsBudgetSummary()
	{
		BeginInit();
		InitClass();
		CollectionChangeEventHandler value = SchemaChanged;
		base.Tables.CollectionChanged += value;
		base.Relations.CollectionChanged += value;
		EndInit();
	}

	[DebuggerNonUserCode]
	protected HrsBudgetSummary(SerializationInfo info, StreamingContext context)
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
		HrsBudgetSummary hrsBudgetSummary = (HrsBudgetSummary)base.Clone();
		hrsBudgetSummary.InitVars();
		hrsBudgetSummary.SchemaSerializationMode = SchemaSerializationMode;
		return hrsBudgetSummary;
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
		base.DataSetName = "HrsBudgetSummary";
		base.Prefix = "";
		base.Namespace = "http://tempuri.org/HrsBudgetSummary.xsd";
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
		HrsBudgetSummary hrsBudgetSummary = new HrsBudgetSummary();
		XmlSchemaComplexType xmlSchemaComplexType = new XmlSchemaComplexType();
		XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
		XmlSchemaAny xmlSchemaAny = new XmlSchemaAny();
		xmlSchemaAny.Namespace = hrsBudgetSummary.Namespace;
		xmlSchemaSequence.Items.Add(xmlSchemaAny);
		xmlSchemaComplexType.Particle = xmlSchemaSequence;
		XmlSchema schemaSerializable = hrsBudgetSummary.GetSchemaSerializable();
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
