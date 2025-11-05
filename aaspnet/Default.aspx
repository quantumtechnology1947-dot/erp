
<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" Title="ERP" Theme="Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

     <script src="Javascript/loadingNotifier.js" type="text/javascript"></script>
     
      <meta name="viewport" content="width=device-width, initial-scale=1"/>
    
    <link href="Link_files/bootstrap.css" rel="stylesheet" />

    <meta charset="utf-8">
  <meta name="viewport" content="width=device-width, initial-scale=1">
 
  <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
  <script type="text/javascript" src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
  

    <link href="Css/styles.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
     
        .style3
        {
            text-align: justify;
        }
        .style4
        {
            text-align: center;
        }
        .style6
        {
            text-align: center;
            color: #000099;
        }
        .style7
        {
            height: 25px;
        }
        .style8
        {
            height: 25px;
            width: 135px;
        }
        .style9
        {
            height: 9px;
            width: 135px;
        }
        .style10s
        {
            height: 9px;
        }
    </style>
 
 
 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cp3" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cp1" Runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cp2" Runat="Server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="MainContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server"> 
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server"> 

    
 <table align="left" cellpadding="2" cellspacing="2" width="60%">
        <tr>
            <td class="style9">
                </td>
            <td class="style10">
                </td>
        </tr>
        <tr>
            <td class="style8">
                &nbsp;
                <asp:Label ID="lblSalary" runat="server" Text="Monthly Salary Slip :"></asp:Label>
                </td>
            <td class="style7">
                <asp:Label ID="Label3" runat="server" Text="Select Month "></asp:Label>
                <asp:DropDownList ID="ddlMonth" runat="server" 
                    CssClass="box3" onselectedindexchanged="ddlMonth_SelectedIndexChanged">
                </asp:DropDownList>
                &nbsp;<asp:Button ID="btnProceed" runat="server" Text="Proceed" 
                    CssClass="redbox" onclick="btnProceed_Click" />
                </td>
        </tr>
       
        <tr>
            <td class="style3" colspan="2">
                &nbsp;</td>
        </tr>
       
        <tr>
            <td colspan="2">
                <asp:Label ID="Label2" runat="server" Text="Label" Visible="False"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style6" colspan="2">
                <asp:TextBox ID="TextBox1" runat="server" TextMode="MultiLine" Visible="False"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style4" colspan="2">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style4" colspan="2">
    
    
    <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Button" 
                    Visible="false" />
 
            </td>
           
        </tr>
        
    </table>
    <br /><br /> <br /><br />

<asp:Table runat="server" class="card" ID="tt1" Width="100%" Height="80%" HorizontalAlign="Center"    BorderStyle="Solid" CaptionAlign="Top"   BorderWidth="10px"   BorderColor="#F5F5F5"   BackColor="#BDBDBD">

<asp:TableRow>

<asp:TableCell HorizontalAlign="Center" Width="25%"  BorderStyle="Solid"   BorderWidth="10px"   BorderColor="white">       
      <div class="card"> 
      
      <asp:Image img src="images/Acc_png.png"  ID="Button4" BackColor="#BDBDBD" runat="server"  width="100px"  Height="80px"  class="btn btn-info btn-lg" data-toggle="modal" data-target="#myModal"/>
    <br />
       <asp:Label runat="server" Text="Accounts" Font-Bold="true" Font-Size="Larger"></asp:Label>
      
                  </div>
                  
      </asp:TableCell>
     
 

<asp:TableCell HorizontalAlign="Center" Width="25%" BorderStyle="Solid"   BorderWidth="10px"   BorderColor="white">       
      <div class="card"> 
      
      <asp:Image img src="images/chat_png.png" BackColor="#BDBDBD" ID="Image1" runat="server"  width="100px" Height="80px"  class="btn btn-info btn-lg" data-toggle="modal" data-target="#myModal1"/>
        <br />
       <asp:Label ID="Label39" runat="server" Text="ChatRoom" Font-Bold="true" Font-Size="Larger"></asp:Label>
      
     
    
     
                  </div>
                  
      </asp:TableCell>
      

<asp:TableCell HorizontalAlign="Center" Width="25%" BorderStyle="Solid"   BorderWidth="10px"   BorderColor="white">
     
      <div class="card"> 
      
      <asp:Image img src="images/des_png.png" BackColor="#BDBDBD" ID="Image3" runat="server"  width="100px" Height="80px"  class="btn btn-info btn-lg" data-toggle="modal" data-target="#myModal2"/>
         <br />
         <asp:Label ID="Label40" runat="server" Text="Design" Font-Bold="true" Font-Size="Larger"></asp:Label>
      
       
      
                  </div>
                  
      </asp:TableCell>
     
<asp:TableCell HorizontalAlign="center" Width="25%" BorderStyle="Solid"   BorderWidth="10px"   BorderColor="white">       
      <div class="card"> 
     
      <asp:Image img src="images/hr_png.png"  BackColor="#BDBDBD" ID="hrrr" runat="server"  width="100px" Height="80px"  class="btn btn-info btn-lg" data-toggle="modal" data-target="#myModal3"/>
    <br />
       <asp:Label ID="Label9" runat="server" Text="HR" Font-Bold="true" Font-Size="Larger"></asp:Label>
      
                  </div>
      </asp:TableCell>
      </asp:TableRow>
     
<asp:TableRow></asp:TableRow>
<asp:TableRow>

<asp:TableCell HorizontalAlign="center" Width="25%" BorderStyle="Solid"   BorderWidth="10px"   BorderColor="white">

      <div class="card"> 
      
      <asp:Image img src="images/gat_png.png"  BackColor="#BDBDBD" ID="Image4" runat="server"  width="100px" Height="80px"  class="btn btn-info btn-lg" data-toggle="modal" data-target="#myModal4"/>
     <br />
     
        <asp:Label ID="Label10" runat="server" Text="GatePass" Font-Bold="true" Font-Size="Larger"></asp:Label>
       
       
                  </div>
                  
      </asp:TableCell>
    
 
       
 
<asp:TableCell HorizontalAlign="center" Width="25%" BorderStyle="Solid"   BorderWidth="10px"   BorderColor="white">       
      <div class="card"> 
      
      <asp:Image img src="images/inv_png.png" ID="Image5" BackColor="#BDBDBD" runat="server"  width="100px" Height="80px"  class="btn btn-info btn-lg" data-toggle="modal" data-target="#myModal5"/>
        <br />
        <asp:Label ID="Label13" runat="server" Text="Inventory" Font-Bold="true" Font-Size="Larger"></asp:Label>
      
      
                  </div>
                  
      </asp:TableCell>
     
 
 <asp:TableCell runat="server" HorizontalAlign="center" Width="25%" BorderStyle="Solid"   BorderWidth="10px"   BorderColor="white">
  
      <div class="card"> 
      
      <asp:Image img src="images/iou_png.png" BackColor="#BDBDBD" ID="Image6" runat="server"  width="100px" Height="80px"  class="btn btn-info btn-lg" data-toggle="modal" data-target="#myModal6"/>
      <br />
       <asp:Label ID="Label15" runat="server" Text="IOU" Font-Bold="true" Font-Size="Larger"></asp:Label>
      
                  </div>
                  
      </asp:TableCell>
     

<asp:TableCell HorizontalAlign="Center" Width="25%" BorderStyle="Solid"   BorderWidth="10px"   BorderColor="white">       
      <div class="card"> 
          
      <asp:Image img src="images/material%20management_png.png" BackColor="#BDBDBD"  ID="Image7" runat="server"  width="100px" Height="80px"  class="btn btn-info btn-lg" data-toggle="modal" data-target="#myModal7"/>
       <br />
        <asp:Label ID="Label19" runat="server" Text="Material" Font-Bold="true" Font-Size="Larger"></asp:Label>
      
                  </div>
                  
      </asp:TableCell>
      </asp:TableRow>
<asp:TableRow></asp:TableRow>
<asp:TableRow></asp:TableRow>
 <asp:TableRow>
<asp:TableCell HorizontalAlign="center" Width="25%" BorderStyle="Solid"   BorderWidth="10px"   BorderColor="white">
    
      <div class="card"> 
       
      <asp:Image img src="images/mis.png"  BackColor="#BDBDBD" ID="Image8" runat="server"  width="100px" Height="80px"  class="btn btn-info btn-lg" data-toggle="modal" data-target="#myModal8"/>
       <br />
        <asp:Label ID="Label20" runat="server" Text="MIS" Font-Bold="true" Font-Size="Larger"></asp:Label>
     
                  </div>  
      </asp:TableCell>
   
 
 <asp:TableCell HorizontalAlign="center" Width="25%" BorderStyle="Solid"   BorderWidth="10px"   BorderColor="white">

      <div class="card"> 
<div style="text-align:center">
      <asp:Image img src="images/MR_icon.png"  BackColor="#BDBDBD" ID="Image9" runat="server"  width="100px" Height="80px"  class="btn btn-info btn-lg" data-toggle="modal" data-target="#myModal9"/>
       </div>
        <br />
        <div style="text-align:center">
         <asp:Label ID="Label22" runat="server" Text="MR" Font-Bold="true" Font-Size="Larger"></asp:Label>
    
                  </div>
      </asp:TableCell>
      
 
 
        
<asp:TableCell HorizontalAlign="center" Width="25%" BorderStyle="Solid"   BorderWidth="10px"   BorderColor="white">
    
      <div class="card"> 
      &nbsp  &nbsp  &nbsp
      <asp:Image img src="images/myscheduler.png" BackColor="#BDBDBD" ID="Image15" runat="server"  width="100px" Height="80px"  class="btn btn-info btn-lg" data-toggle="modal" data-target="#myModal22"/>
          <br />
          <asp:Label ID="Label23" runat="server" Text="MyScheduler" Font-Bold="true" Font-Size="Larger"></asp:Label>
     
    
                  </div>
                  
      </asp:TableCell>
      
 

<asp:TableCell HorizontalAlign="center" Width="25%" BorderStyle="Solid"   BorderWidth="10px"   BorderColor="white">
     
      <div class="card"> 
      
      <asp:Image img src="images/project%20management.png"  BackColor="#BDBDBD" ID="Image11" runat="server"  width="100px" Height="80px"  class="btn btn-info btn-lg" data-toggle="modal" data-target="#myModal11"/>
     <br />
       <asp:Label ID="Label24" runat="server" Text="Project" Font-Bold="true" Font-Size="Larger"></asp:Label>
      
                  </div>
      </asp:TableCell>
      </asp:TableRow>

 
 
<asp:TableRow>
 
<asp:TableCell HorizontalAlign="Center" BorderStyle="Solid"   BorderWidth="10px"   BorderColor="white">       
      <div class="card"> 
   
      <asp:Image img src="images/project%20planning.png" BackColor="#BDBDBD" ID="Image12" runat="server"  width="100px" Height="80px"  class="btn btn-info btn-lg" data-toggle="modal" data-target="#myModal12"/>
       <br />
        <asp:Label ID="Label27" runat="server" Text="Planning" Font-Bold="true" Font-Size="Larger"></asp:Label>
       
                  </div>
      </asp:TableCell>
     

<asp:TableCell HorizontalAlign="center" Width="25%" BorderStyle="Solid"   BorderWidth="10px"   BorderColor="white">
    
      <div class="card"> 

      <div style="text-align:center"></div>
      <asp:Image img src="images/QCq.png"  ID="Image13" runat="server"   BackColor="#BDBDBD" width="100px" Height="80px"  class="btn btn-info btn-lg" data-toggle="modal" data-target="#myModal13"/>
      <br />
      <div style="text-align:center">
       <asp:Label ID="Label29" runat="server" Text="QC" Font-Bold="true" Font-Size="Larger" ></asp:Label>
     
                  </div>
                  </div>
                  
      </asp:TableCell>
     
     
<asp:TableCell HorizontalAlign="Center" Width="25%" BorderStyle="Solid"   BorderWidth="10px"   BorderColor="white">       
      <div class="card"> 
      
      <asp:Image img src="images/saleses.png" ID="Image14" runat="server" BackColor="#BDBDBD" width="100px" Height="80px"  class="btn btn-info btn-lg" data-toggle="modal" data-target="#myModal15"/>
        <br />
        <asp:Label ID="Label35" runat="server" Text="Sales" Font-Bold="true" Font-Size="Larger"></asp:Label>
       
     
                  </div>
      </asp:TableCell>
   
      
      <asp:TableCell HorizontalAlign="Center" Width="25%" BorderStyle="Solid"   BorderWidth="10px"   BorderColor="white">       
      <div class="card"> 
      
      <asp:Image img src="images/project%20planning.png" ID="Image2" runat="server" BackColor="#BDBDBD" width="100px" Height="80px"  class="btn btn-info btn-lg" data-toggle="modal" data-target="#myModal16"/>
        <br />
        <asp:Label ID="Label14" runat="server" Text="Meeting" Font-Bold="true" Font-Size="Larger"></asp:Label>
       
      
                  </div>
      </asp:TableCell>
    </asp:TableRow>
   </asp:Table>
   </asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
   
    
   
</asp:Content>

