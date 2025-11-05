<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Apprisal_Form.aspx.cs" Inherits="Module_HR_Transactions_Apprisal_Form" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


  <script src="../../../Javascript/loadingNotifier.js" type="text/javascript"></script>
    <link href="../../../Css/yui-datatable.css" rel="stylesheet" type="text/css" />
    <link href="../../../Css/StyleSheet.css" rel="stylesheet" type="text/css" />
    
    <style type="text/css">

td
	{
		border-style: none;
            border-color: inherit;
            border-width: medium;
            padding: 0px;
            color:black;
	        font-size:11.0pt;
	        font-weight:400;
	        font-style:normal;
	        text-decoration:none;
	        font-family:Calibri, sans-serif;
	        text-align:general;
	        vertical-align:bottom;
	        white-space:nowrap;
	}
        .style1 {
            height: 44.25pt;
            width: 730pt;
            color: windowtext;
            font-size: 20.0pt;
            font-weight: 700;
            font-style: italic;
            text-decoration: none;
            font-family: "Times New Roman", serif;
            text-align: center;
            vertical-align: middle;
            white-space: nowrap;
            border-left: .5pt solid windowtext;
            border-right-style: none;
            border-right-color: inherit;
            border-right-width: medium;
            border-top: .5pt solid windowtext;
            border-bottom: .5pt solid windowtext;
            padding: 0px;
        }
        .style2 {
            height: 29.25pt;
            width: 730pt;
            color: windowtext;
            font-size: 18.0pt;
            font-weight: 700;
            font-style: normal;
            text-decoration: none;
            font-family: "Times New Roman", serif;
            text-align: center;
            vertical-align: middle;
            white-space: normal;
            border-left: .5pt solid windowtext;
            border-right-style: none;
            border-right-color: inherit;
            border-right-width: medium;
            border-top: .5pt solid windowtext;
            border-bottom: .5pt solid windowtext;
            padding: 0px;
        }
        .style3 {
            height: 24.75pt;
            width: 113pt;
            color: windowtext;
            font-size: 18.0pt;
            font-weight: 700;
            font-style: normal;
            text-decoration: none;
            font-family: "Times New Roman", serif;
            text-align: center;
            vertical-align: middle;
            white-space: normal;
            border-left: .5pt solid windowtext;
            border-right: .5pt solid windowtext;
            border-top: .5pt solid windowtext;
            border-bottom-style: none;
            border-bottom-color: inherit;
            border-bottom-width: medium;
            padding: 0px;
        }
        .style4 {
            width: 482pt;
            color: windowtext;
            font-size: 16.0pt;
            font-weight: 700;
            font-style: normal;
            text-decoration: none;
            font-family: "Times New Roman", serif;
            text-align: center;
            vertical-align: middle;
            white-space: normal;
            border-left: .5pt solid windowtext;
            border-right-style: none;
            border-right-color: inherit;
            border-right-width: medium;
            border-top: .5pt solid windowtext;
            border-bottom: 1.0pt solid windowtext;
            padding: 0px;
        }
        .style5 {
            color: windowtext;
            font-size: 10.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: "Times New Roman", serif;
            text-align: center;
            vertical-align: bottom;
            white-space: nowrap;
            border-left: .5pt solid windowtext;
            border-right: .5pt solid windowtext;
            border-top: .5pt solid windowtext;
            border-bottom-style: none;
            border-bottom-color: inherit;
            border-bottom-width: medium;
            padding: 0px;
        }
        .style6 {
            height: 20.1pt;
            color: windowtext;
            font-size: 16.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: "Times New Roman", serif;
            text-align: left;
            vertical-align: middle;
            white-space: nowrap;
            border-left: 1.0pt solid windowtext;
            border-right-style: none;
            border-right-color: inherit;
            border-right-width: medium;
            border-top: 1.0pt solid windowtext;
            border-bottom: .5pt solid windowtext;
            padding: 0px;
        }
        .style7 {
            height: 20.1pt;
            color: windowtext;
            font-size: 16.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: "Times New Roman", serif;
            text-align: left;
            vertical-align: middle;
            white-space: nowrap;
            border: .5pt solid windowtext;
            padding: 0px;
        }
        .style8 {
            color: windowtext;
            font-size: 16.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: "Times New Roman", serif;
            text-align: center;
            vertical-align: middle;
            white-space: nowrap;
            border-left-style: none;
            border-left-color: inherit;
            border-left-width: medium;
            border-right-style: none;
            border-right-color: inherit;
            border-right-width: medium;
            border-top: .5pt solid windowtext;
            border-bottom: .5pt solid windowtext;
            padding: 0px;
        }
        .style9 {
            height: 20.1pt;
            width: 730pt;
            color: windowtext;
            font-size: 16.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: "Times New Roman", serif;
            text-align: left;
            vertical-align: middle;
            white-space: normal;
            border-left: 1.0pt solid windowtext;
            border-right-style: none;
            border-right-color: inherit;
            border-right-width: medium;
            border-top: .5pt solid windowtext;
            border-bottom: .5pt solid windowtext;
            padding: 0px;
        }
        .style10 {
            height: 21.0pt;
            width: 730pt;
            color: windowtext;
            font-size: 16.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: "Times New Roman", serif;
            text-align: left;
            vertical-align: middle;
            white-space: normal;
            border-left: 1.0pt solid windowtext;
            border-right-style: none;
            border-right-color: inherit;
            border-right-width: medium;
            border-top: .5pt solid windowtext;
            border-bottom: .5pt solid windowtext;
            padding: 0px;
        }
        .style11 {
            height: 20.1pt;
            color: windowtext;
            font-size: 16.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: "Times New Roman", serif;
            text-align: left;
            vertical-align: middle;
            white-space: nowrap;
            border-left: 1.0pt solid windowtext;
            border-right-style: none;
            border-right-color: inherit;
            border-right-width: medium;
            border-top: .5pt solid windowtext;
            border-bottom: .5pt solid windowtext;
            padding: 0px;
        }
        .style12 {
            height: 24.75pt;
            color: windowtext;
            font-size: 16.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: "Times New Roman", serif;
            text-align: left;
            vertical-align: middle;
            white-space: nowrap;
            border-left: 1.0pt solid windowtext;
            border-right-style: none;
            border-right-color: inherit;
            border-right-width: medium;
            border-top: .5pt solid windowtext;
            border-bottom: 1.0pt solid windowtext;
            padding: 0px;
        }
        .style13 {
            height: 19.5pt;
            color: windowtext;
            font-size: 16.0pt;
            font-weight: 700;
            font-style: normal;
            text-decoration: none;
            font-family: "Times New Roman", serif;
            text-align: center;
            vertical-align: middle;
            white-space: nowrap;
            border-left: .5pt solid windowtext;
            border-right-style: none;
            border-right-color: inherit;
            border-right-width: medium;
            border-top: 1.0pt solid windowtext;
            border-bottom-style: none;
            border-bottom-color: inherit;
            border-bottom-width: medium;
            padding: 0px;
        }
        .style14 {
            height: 33.75pt;
            color: windowtext;
            font-size: 16.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: "Times New Roman", serif;
            text-align: general;
            vertical-align: middle;
            white-space: nowrap;
            border: .5pt solid windowtext;
            padding: 0px;
        }
        .style15 {
            width: 341pt;
            color: windowtext;
            font-size: 16.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: "Times New Roman", serif;
            text-align: left;
            vertical-align: top;
            white-space: normal;
            border-left: .5pt solid windowtext;
            border-right-style: none;
            border-right-color: inherit;
            border-right-width: medium;
            border-top: .5pt solid windowtext;
            border-bottom-style: none;
            border-bottom-color: inherit;
            border-bottom-width: medium;
            padding: 0px;
        }
        .style16 {
            height: 37.5pt;
            color: windowtext;
            font-size: 16.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: "Times New Roman", serif;
            text-align: general;
            vertical-align: middle;
            white-space: nowrap;
            border: .5pt solid windowtext;
            padding: 0px;
        }
        .style17 {
            width: 341pt;
            color: windowtext;
            font-size: 16.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: "Times New Roman", serif;
            text-align: general;
            vertical-align: top;
            white-space: normal;
            border-left: .5pt solid windowtext;
            border-right-style: none;
            border-right-color: inherit;
            border-right-width: medium;
            border-top: .5pt solid windowtext;
            border-bottom-style: none;
            border-bottom-color: inherit;
            border-bottom-width: medium;
            padding: 0px;
        }
        .style18 {
            height: 37.5pt;
            color: windowtext;
            font-size: 16.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: "Times New Roman", serif;
            text-align: left;
            vertical-align: middle;
            white-space: nowrap;
            border-left: .5pt solid windowtext;
            border-right-style: none;
            border-right-color: inherit;
            border-right-width: medium;
            border-top: .5pt solid windowtext;
            border-bottom: .5pt solid windowtext;
            padding: 0px;
        }
        .style19 {
            width: 341pt;
            color: windowtext;
            font-size: 16.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: "Times New Roman", serif;
            text-align: left;
            vertical-align: top;
            white-space: normal;
            border-left: .5pt solid windowtext;
            border-right-style: none;
            border-right-color: inherit;
            border-right-width: medium;
            border-top: .5pt solid windowtext;
            border-bottom: .5pt solid windowtext;
            padding: 0px;
        }
        .style20 {
            height: 53.25pt;
            width: 389pt;
            color: windowtext;
            font-size: 16.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: "Times New Roman", serif;
            text-align: general;
            vertical-align: middle;
            white-space: normal;
            border-left: .5pt solid windowtext;
            border-right-style: none;
            border-right-color: inherit;
            border-right-width: medium;
            border-top: .5pt solid windowtext;
            border-bottom: .5pt solid windowtext;
            padding: 0px;
        }
        .style21 {
            width: 341pt;
            color: windowtext;
            font-size: 16.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: "Times New Roman", serif;
            text-align: general;
            vertical-align: middle;
            white-space: normal;
            border-left: .5pt solid windowtext;
            border-right-style: none;
            border-right-color: inherit;
            border-right-width: medium;
            border-top: .5pt solid windowtext;
            border-bottom: .5pt solid windowtext;
            padding: 0px;
        }
        .style22 {
            height: 32.25pt;
            color: windowtext;
            font-size: 16.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: "Times New Roman", serif;
            text-align: general;
            vertical-align: middle;
            white-space: nowrap;
            border: .5pt solid windowtext;
            padding: 0px;
        }
        .style23 {
            width: 341pt;
            color: windowtext;
            font-size: 16.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: "Times New Roman", serif;
            text-align: general;
            vertical-align: middle;
            white-space: normal;
            border-left: .5pt solid windowtext;
            border-right-style: none;
            border-right-color: inherit;
            border-right-width: medium;
            border-top: .5pt solid windowtext;
            border-bottom-style: none;
            border-bottom-color: inherit;
            border-bottom-width: medium;
            padding: 0px;
        }
        .style24 {
            height: 32.25pt;
            color: windowtext;
            font-size: 16.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: "Times New Roman", serif;
            text-align: left;
            vertical-align: middle;
            white-space: nowrap;
            border-left: .5pt solid windowtext;
            border-right-style: none;
            border-right-color: inherit;
            border-right-width: medium;
            border-top: .5pt solid windowtext;
            border-bottom: .5pt solid windowtext;
            padding: 0px;
        }
        .style25 {
            width: 341pt;
            color: windowtext;
            font-size: 16.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: "Times New Roman", serif;
            text-align: center;
            vertical-align: middle;
            white-space: normal;
            border-left: .5pt solid windowtext;
            border-right-style: none;
            border-right-color: inherit;
            border-right-width: medium;
            border-top: .5pt solid windowtext;
            border-bottom: .5pt solid windowtext;
            padding: 0px;
        }
        .style26 {
            height: 20.25pt;
            color: black;
            font-size: 16.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: "Times New Roman", serif;
            text-align: left;
            vertical-align: bottom;
            white-space: nowrap;
            border: .5pt solid windowtext;
            padding: 0px;
        }
        .style27 {
            color: windowtext;
            font-size: 10.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: "Times New Roman", serif;
            text-align: center;
            vertical-align: bottom;
            white-space: nowrap;
            border: .5pt solid windowtext;
            padding: 0px;
        }
        .style28 {
            height: 20.25pt;
            color: black;
            font-size: 16.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: "Times New Roman", serif;
            text-align: left;
            vertical-align: bottom;
            white-space: nowrap;
            border-left: .5pt solid windowtext;
            border-right-style: none;
            border-right-color: inherit;
            border-right-width: medium;
            border-top: .5pt solid windowtext;
            border-bottom: .5pt solid windowtext;
            padding: 0px;
        }
        .style29 {
            color: windowtext;
            font-size: 10.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: "Times New Roman", serif;
            text-align: left;
            vertical-align: bottom;
            white-space: nowrap;
            border-left: .5pt solid windowtext;
            border-right-style: none;
            border-right-color: inherit;
            border-right-width: medium;
            border-top: .5pt solid windowtext;
            border-bottom: .5pt solid windowtext;
            padding: 0px;
        }
        .style30 {
            height: 20.25pt;
            color: windowtext;
            font-size: 16.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: "Times New Roman", serif;
            text-align: general;
            vertical-align: bottom;
            white-space: nowrap;
            border: .5pt solid windowtext;
            padding: 0px;
        }
        .style31 {
            color: windowtext;
            font-size: 16.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: "Times New Roman", serif;
            text-align: general;
            vertical-align: bottom;
            white-space: nowrap;
            border: .5pt solid windowtext;
            padding: 0px;
        }
        .style32 {
            color: windowtext;
            font-size: 10.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: "Times New Roman", serif;
            text-align: center;
            vertical-align: bottom;
            white-space: nowrap;
            border-left: .5pt solid windowtext;
            border-right-style: none;
            border-right-color: inherit;
            border-right-width: medium;
            border-top: .5pt solid windowtext;
            border-bottom: .5pt solid windowtext;
            padding: 0px;
        }
        .style33 {
            height: 108.0pt;
            width: 161pt;
            color: windowtext;
            font-size: 16.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: "Times New Roman", serif;
            text-align: left;
            vertical-align: top;
            white-space: normal;
            border: .5pt solid windowtext;
            padding: 0px;
        }
        .style34 {
            color: windowtext;
            font-size: 16.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: "Times New Roman", serif;
            text-align: general;
            vertical-align: top;
            white-space: nowrap;
            border: .5pt solid windowtext;
            padding: 0px;
        }
    </style>
    
    



</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cp3" Runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cp1" Runat="Server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cp2" Runat="Server">
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="MainContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">

  <table border="2" cellpadding="0" cellspacing="0" style="border-collapse:
 collapse;width:730pt; border-color:#2196f3;" width="100%" frame="box">
          
            <tr height="59" style="mso-height-source:userset;height:44.25pt">
                <td align="left" colspan="7" height="59" style="border-right:.5pt solid black;
  height:44.25pt;width:730pt" valign="top" width="974">
                 
                    <span style="mso-ignore:vglayout;
  position:absolute;z-index:1;margin-left:232px;margin-top:15px;width:85px;
  height:34px">
                    <img alt="" height="34" 
                        src="images/logo.PNG"  
                        v:shapes="Picture_x0020_2" width="90" /></span><![endif]><span 
                        style="mso-ignore:vglayout2">
                    <table cellpadding="0" cellspacing="0">
                        <tr>
                            <td class="style1" colspan="7" height="59" width="974">
                                <span style="mso-spacerun:yes">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span>Synergytech Automation 
                                Pvt.Ltd., Pune</td>
                        </tr>
                    </table>
                    </span>
                </td>
            </tr>
            <tr height="39" style="mso-height-source:userset;height:29.25pt">
                <td class="style2" colspan="7" height="39" width="974">
                    Survey Performance Appraisal Form - 2018-2019</td>
            </tr>
            <tr height="33" style="mso-height-source:userset;height:24.75pt">
                <td class="style3" height="33" width="151">
                    &nbsp;</td>
                <td class="style4" colspan="5" width="643">
                    Employee<span style="mso-spacerun:yes">&nbsp; </span>Details<span 
                        style="mso-spacerun:yes">&nbsp;</span></td>
                <td class="style5">                
                    &nbsp;</td>
            </tr>
            <tr height="26" style="mso-height-source:userset;height:20.1pt; border: 1px solid #ccc;">
                <td class="style6" colspan="7" height="26">
                    Name:<asp:TextBox ID="txtName" runat="server" Width="90%"></asp:TextBox></td>
            </tr>
            <tr height="26" style="mso-height-source:userset;height:20.1pt">
                <td class="style7" height="26">
                    Department:</td>
                <td class="style8" colspan="6"><asp:TextBox ID="txtdept" runat="server" Width="90%"></asp:TextBox>
                    &nbsp;</td>
            </tr>
            <tr height="26" style="mso-height-source:userset;height:20.1pt">
                <td class="style9" colspan="7" height="26" width="974">
                    Designation:<asp:TextBox ID="txtdesg" runat="server" Width="90%"></asp:TextBox></td>
            </tr>
            <tr height="28" style="mso-height-source:userset;height:21.0pt">
                <td class="style10" colspan="7" height="28" width="974">
                    Appraisal period from date:<asp:TextBox ID="txtapp" runat="server" Width="90%"></asp:TextBox><span style="mso-spacerun:yes">&nbsp;&nbsp;</span></td>
            </tr>
            <tr height="26" style="mso-height-source:userset;height:20.1pt">
                <td class="style11" colspan="7" height="26">
                    Grade :<asp:TextBox ID="txtgrade" runat="server" Width="90%"></asp:TextBox><span style="mso-spacerun:yes">&nbsp;</span></td>
            </tr>
            <tr height="33" style="mso-height-source:userset;height:24.75pt">
                <td class="style12" colspan="7" height="33">
                    Joining Date:-<asp:TextBox ID="txtJDate" runat="server" Width="50%"></asp:TextBox></td>
            </tr>
            <tr height="26" style="mso-height-source:userset;height:19.5pt">
                <td class="style13" colspan="7" height="26">
                    <span style="mso-spacerun:yes">&nbsp;</span>SELF APPRAISAL<span 
                        style="mso-spacerun:yes">&nbsp;</span></td>
            </tr>
            <tr height="45" style="mso-height-source:userset;height:33.75pt">
                <td class="style14" colspan="3" height="45">
                    Present Job responsibilities<asp:TextBox ID="txtjobRes" runat="server" Width="90%"></asp:TextBox></td>
                <td class="style15" colspan="4" width="455">
                    &nbsp;</td>
            </tr>
            <tr height="50" style="mso-height-source:userset;height:37.5pt">
                <td class="style16" colspan="3" height="50">
                    Specific Achievement<asp:TextBox ID="txtspecific" runat="server" Width="90%"></asp:TextBox></td>
                <td class="style17" colspan="4" width="455">
                    &nbsp;</td>
            </tr>
            <tr height="50" style="mso-height-source:userset;height:37.5pt">
                <td class="style18" colspan="3" height="50">
                    Specific loss to the company from your side</td>
                <td class="style19" colspan="4" width="455"><asp:TextBox ID="txtloss" runat="server" Width="90%"></asp:TextBox>
                    &nbsp;</td>
            </tr>
            <tr height="71" style="mso-height-source:userset;height:53.25pt">
                <td class="style20" colspan="3" height="71" width="519">
                    Participation in other dept.other than your own dept in relation of work</td>
                <td class="style21" colspan="4" width="455"><asp:TextBox ID="txtpart" runat="server" Width="90%"></asp:TextBox>
                    &nbsp;</td>
            </tr>
            <tr height="43" style="mso-height-source:userset;height:32.25pt">
                <td class="style22" colspan="3" height="43">
                    Denied for onsite with reason</td>
                <td class="style17" colspan="4" width="455"><asp:TextBox ID="txtonsite" runat="server" Width="90%"></asp:TextBox>
                    &nbsp;</td>
            </tr>
            <tr height="43" style="mso-height-source:userset;height:32.25pt">
                <td class="style22" colspan="3" height="43">
                    Leave without permission</td>
                <td class="style23" colspan="4" width="455"><asp:TextBox ID="txtlevper" runat="server" Width="90%"></asp:TextBox>
                    &nbsp;</td>
            </tr>
            <tr height="43" style="mso-height-source:userset;height:32.25pt">
                <td class="style24" colspan="3" height="43">
                    Strength</td>
                <td class="style25" colspan="4" width="455"><asp:TextBox ID="txtstr" runat="server" Width="90%"></asp:TextBox>
                    &nbsp;</td>
            </tr>
            <tr height="43" style="mso-height-source:userset;height:32.25pt">
                <td class="style24" colspan="3" height="43">
                    Weekness</td>
                <td class="style25" colspan="4" width="455"><asp:TextBox ID="txtweek" runat="server" Width="90%"></asp:TextBox>
                    &nbsp;</td>
            </tr>
            <tr height="45" style="mso-height-source:userset;height:33.75pt">
                <td class="style14" colspan="3" height="45">
                    Training Required</td>
                <td class="style17" colspan="4" width="455"><asp:TextBox ID="txttrnreq" runat="server" Width="90%"></asp:TextBox>
                    &nbsp;</td>
            </tr>
            <tr height="27" style="height:20.25pt">
                <td class="style26" colspan="3" height="27">
                    Current CTC</td>
                <td class="style27" colspan="4"><asp:TextBox ID="txtcrntCTC" runat="server" Width="90%"></asp:TextBox>
                    &nbsp;</td>
            </tr>
            <tr height="27" style="height:20.25pt">
                <td class="style26" colspan="3" height="27">
                    Expected CTC</td>
                <td class="style27" colspan="4"><asp:TextBox ID="tctexpCTC" runat="server" Width="90%"></asp:TextBox>
                    &nbsp;</td>
            </tr>
            <tr height="27" style="height:20.25pt">
                <td class="style26" colspan="3" height="27">
                    Total duty Hrs per day:</td>
                <td class="style27" colspan="4"><asp:TextBox ID="txtHrs" runat="server" Width="90%"></asp:TextBox>
                    &nbsp;</td>
            </tr>
            <tr height="27" style="height:20.25pt">
                <td class="style28" colspan="3" height="27">
                    Total duty Hrs prefered:</td>
                <td class="style29" colspan="4"><asp:TextBox ID="txtdutyHrs" runat="server" Width="90%"></asp:TextBox>
                    &nbsp;</td>
            </tr>
            <tr height="27" style="height:20.25pt">
                <td class="style26" colspan="3" height="27">
                    Last Increment Date:</td>
                <td class="style27" colspan="4"><asp:TextBox ID="txtIncL" runat="server" Width="90%"></asp:TextBox>
                    &nbsp;</td>
            </tr>
            <tr height="27" style="height:20.25pt">
                <td class="style26" colspan="3" height="27">
                    Total Year of experience:</td>
                <td class="style27" colspan="4"><asp:TextBox ID="txtExpyr" runat="server" Width="90%"></asp:TextBox>
                    &nbsp;</td>
            </tr>
            <tr height="27" style="height:20.25pt">
                <td class="style26" colspan="3" height="27">
                    Total year of experience in SAPL:</td>
                <td class="style27" colspan="4"><asp:TextBox ID="txtYrSAPL" runat="server" Width="90%"></asp:TextBox>
                    &nbsp;</td>
            </tr>
            <tr height="27" style="height:20.25pt">
                <td class="style26" colspan="3" height="27">
                    Take Home Salary per month:</td>
                <td class="style27" colspan="4"><asp:TextBox ID="txtHSal" runat="server" Width="90%"></asp:TextBox>
                    &nbsp;</td>
            </tr>
            <tr height="27" style="height:20.25pt">
                <td class="style26" colspan="3" height="27">
                    Highest qualification:</td>
                <td class="style27" colspan="4"><asp:TextBox ID="txthighQ" runat="server" Width="90%"></asp:TextBox>
                    &nbsp;</td>
            </tr>
            <tr height="27" style="height:20.25pt">
                <td class="style26" colspan="3" height="27">
                    Employee Comments:</td>
                <td class="style27" colspan="4"><asp:TextBox ID="txtEmpC" runat="server" Width="90%"></asp:TextBox>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style28" height="27">
                    Notice Peroid on offer letter</td>
                <td colspan="4"class="style31"><asp:TextBox ID="txtNPer" runat="server" Width="90%"></asp:TextBox>
                    &nbsp;</td>
                
            </tr>
            <tr height="27" style="height:20.25pt">
                <td class="style28" colspan="3" height="27">
                    No. of PL Pending</td>
                <td class="style32" colspan="4"><asp:TextBox ID="txtPL" runat="server" Width="90%"></asp:TextBox>
                    &nbsp;</td>
            </tr>
            <tr height="27" style="height:20.25pt">
                <td class="style28" colspan="3" height="27">
                    No. of C-Off Pending</td>
                <td class="style32" colspan="4"><asp:TextBox ID="txtCOFF" runat="server" Width="90%"></asp:TextBox>
                    &nbsp;</td>
            </tr>
            <tr height="27" style="height:20.25pt">
                <td  class="style28" colspan="3" height="27">
                    On Roll or Casual</td>
                <td class="style32" colspan="4"><asp:TextBox ID="txtroll" runat="server" Width="90%"></asp:TextBox>
                    </td>
            </tr>
            <tr height="27" style="height:20.25pt">
                <td class="style30" height="27">
                    Appraisal Time on offer letter</td>
                    <td class="style32" colspan="4"><asp:TextBox ID="txtATime" runat="server" Width="80%"></asp:TextBox></td>
               
                
            </tr>
            <tr height="36" style="mso-height-source:userset;height:27.0pt">
                <td class="style33" colspan="2" height="144" rowspan="5" width="215">
                    Eligible for facilities</td>
                <td colspan="5" class="style34"><asp:CheckBox ID="CheckBox1" runat="server" />
                    Bus</td>
                
            </tr>
            <tr height="27" style="height:20.25pt">
                <td colspan="5" class="style30" height="27">
                   <asp:CheckBox ID="CheckBox2" runat="server" Text="Travel Allowance" /> </td>
               
            </tr>
            <tr height="27" style="height:20.25pt">
                <td colspan="5" class="style30" height="27">
                   <asp:CheckBox ID="CheckBox3" runat="server" Text="Canteen" /> </td>
               
            </tr>
            <tr height="27" style="height:20.25pt">
                <td colspan="5" class="style30" height="27">
                    <asp:CheckBox ID="CheckBox4" runat="server" Text="Punch Card" /></td>
                
            </tr>
            <tr height="27" style="height:20.25pt">
                <td colspan="5" class="style30" height="27">
                  <asp:CheckBox ID="CheckBox5" runat="server" Text="Other" />  </td>
                
            </tr>
        </table>
        <br />
        <br/>
       <asp:Button ID="Button1" runat="server" Text="SUBMIT" Width="40%" 
            BackColor="Red" ForeColor="White" />
    


</asp:Content>
<asp:Content ID="Content9" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

