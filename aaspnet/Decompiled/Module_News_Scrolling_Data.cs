using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ASP;

public class Module_News_Scrolling_Data : Page, IRequiresSessionState
{
	protected Table Table1;

	protected HtmlForm form1;

	protected HtmlGenericControl Html1;

	private clsFunctions fun = new clsFunctions();

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		string connectionString = fun.Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		sqlConnection.Open();
		try
		{
			string cmdText = fun.select("*", "tblHR_News_Notices", "Flag=0");
			SqlCommand selectCommand = new SqlCommand(cmdText, sqlConnection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			DateTime now = DateTime.Now;
			string value = Convert.ToDateTime(now).ToString("yyyy-MM-dd");
			for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
			{
				string value2 = dataSet.Tables[0].Rows[i]["ToDate"].ToString();
				if (Convert.ToDateTime(value) > Convert.ToDateTime(value2))
				{
					SqlCommand sqlCommand = new SqlCommand(fun.update("tblHR_News_Notices", "Flag='1'", "Id='" + dataSet.Tables[0].Rows[i]["Id"].ToString() + "'"), sqlConnection);
					sqlCommand.ExecuteNonQuery();
				}
			}
			loadData();
		}
		catch (Exception)
		{
		}
		sqlConnection.Close();
	}

	public void loadData()
	{
		string connectionString = fun.Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		sqlConnection.Open();
		try
		{
			string cmdText = fun.select("*", "tblHR_News_Notices", "Flag=0");
			SqlCommand selectCommand = new SqlCommand(cmdText, sqlConnection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			Table1.Controls.Clear();
			for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
			{
				for (int j = 0; j < 2; j++)
				{
					TableRow tableRow = new TableRow();
					Table1.Controls.Add(tableRow);
					if (j % 2 == 0)
					{
						TableCell tableCell = new TableCell();
						tableCell.Width = 100;
						tableCell.VerticalAlign = VerticalAlign.Top;
						HyperLink hyperLink = new HyperLink();
						hyperLink.Text = dataSet.Tables[0].Rows[i]["Title"].ToString();
						hyperLink.Target = "_blank";
						hyperLink.Attributes.Add("onclick", string.Concat("javascript:window.open('PopUpNews.aspx?Id=", dataSet.Tables[0].Rows[i]["Id"], "','','width=700, height=340, left=340,top=180'); return false;"));
						hyperLink.Font.Size = 9;
						hyperLink.ForeColor = Color.DarkBlue;
						hyperLink.Font.Bold = true;
						hyperLink.Font.Underline = true;
						tableCell.Controls.Add(hyperLink);
						tableRow.Controls.Add(tableCell);
						TableCell tableCell2 = new TableCell();
						tableCell2.Width = 2;
						if (dataSet.Tables[0].Rows[i]["FileName"].ToString() != null && dataSet.Tables[0].Rows[i]["FileName"].ToString() != "")
						{
							tableCell2.VerticalAlign = VerticalAlign.Top;
							HyperLink hyperLink2 = new HyperLink();
							hyperLink2.ImageUrl = "~/images/attachment.png";
							hyperLink2.NavigateUrl = string.Concat("~/Controls/DownloadFile.aspx?Id=", dataSet.Tables[0].Rows[i]["Id"], "&tbl=tblHR_News_Notices&qfd=FileData&qfn=FileName&qct=ContentType");
							tableCell2.Controls.Add(hyperLink2);
						}
						tableRow.Controls.Add(tableCell2);
					}
					else
					{
						TableCell tableCell3 = new TableCell();
						tableCell3.VerticalAlign = VerticalAlign.Top;
						Label label = new Label();
						label.Font.Italic = true;
						string text = "";
						text = ((dataSet.Tables[0].Rows[i]["InDetails"].ToString().Length <= 100) ? dataSet.Tables[0].Rows[i]["InDetails"].ToString() : (dataSet.Tables[0].Rows[i]["InDetails"].ToString().Substring(0, 400) + "...."));
						label.Text = text;
						tableCell3.Controls.Add(label);
						tableRow.Controls.Add(tableCell3);
						TableCell tableCell4 = new TableCell();
						tableCell4.Height = 30;
						tableRow.Controls.Add(tableCell4);
					}
				}
			}
		}
		catch (Exception)
		{
		}
		sqlConnection.Close();
	}
}
