using System;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ASP;

public class Flowchart_ShowPage : Page, IRequiresSessionState
{
	protected Image Image1;

	protected HtmlForm form1;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		switch (base.Request.QueryString["Id"].ToString())
		{
		case "00":
			Image1.ImageUrl = "~/images/ERP-0.jpg";
			break;
		case "01":
			Image1.ImageUrl = "~/images/ERP-0.jpg";
			break;
		case "02":
			Image1.ImageUrl = "~/images/ERP-0.jpg";
			break;
		case "03":
			Image1.ImageUrl = "~/images/ERP-0.jpg";
			break;
		case "04":
			Image1.ImageUrl = "~/images/ERP-0.jpg";
			break;
		case "05":
			Image1.ImageUrl = "~/images/ERP-0.jpg";
			break;
		case "06":
			Image1.ImageUrl = "~/images/ERP-0.jpg";
			break;
		case "07":
			Image1.ImageUrl = "~/images/ERP-0.jpg";
			break;
		case "08":
			Image1.ImageUrl = "~/images/ERP-0.jpg";
			break;
		case "1":
			Image1.ImageUrl = "~/images/ERP-1.jpg";
			break;
		case "2":
			Image1.ImageUrl = "~/images/ERP-2.jpg";
			break;
		case "3":
			Image1.ImageUrl = "~/images/ERP-3.jpg";
			break;
		case "4":
			Image1.ImageUrl = "~/images/ERP-4.jpg";
			break;
		case "5":
			Image1.ImageUrl = "~/images/ERP-5.jpg";
			break;
		case "6":
			Image1.ImageUrl = "~/images/ERP-6.jpg";
			break;
		case "7":
			Image1.ImageUrl = "~/images/ERP-7.jpg";
			break;
		case "8":
			Image1.ImageUrl = "~/images/ERP-7.1.jpg";
			break;
		case "9":
			Image1.ImageUrl = "~/images/ERP-7.2.jpg";
			break;
		case "10":
			Image1.ImageUrl = "~/images/ERP-8.jpg";
			break;
		case "11":
			Image1.ImageUrl = "~/images/ERP-9.jpg";
			break;
		case "12":
			Image1.ImageUrl = "~/images/ERP-10.jpg";
			break;
		case "13":
			Image1.ImageUrl = "~/images/ERP-13.jpg";
			break;
		case "14":
			Image1.ImageUrl = "~/images/ERP-14.jpg";
			break;
		case "15":
			Image1.ImageUrl = "~/images/ERP-15.jpg";
			break;
		case "16":
			Image1.ImageUrl = "~/images/ERP-11.jpg";
			break;
		}
	}
}
