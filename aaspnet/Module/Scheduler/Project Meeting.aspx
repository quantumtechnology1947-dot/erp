<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Project Meeting.aspx.cs" Inherits="Module_Project_Meeting_Project_Meeting" Title="Project Meeting" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
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


<asp:Table runat="server" ID="table" Width="100%" Height="10%" GridLines="Both">
                  <asp:TableRow>
                  <asp:TableCell Text="WONO">
                 </asp:TableCell>
                  <asp:TableCell Text="DATE"></asp:TableCell>
                  <asp:TableCell Text="ACTIVITY"></asp:TableCell>
                  <asp:TableCell Text="EQUIPMENT/ PROJECT"></asp:TableCell>
                  <asp:TableCell Text="QTY"></asp:TableCell>
                  <asp:TableCell Text="DESCRIPTION"></asp:TableCell>
                  <asp:TableCell Text="RESPONSIBLE DEPARTMENT"></asp:TableCell>
                   <asp:TableCell Text="RESPONSIBLE PERSON"></asp:TableCell>
                   <asp:TableCell Text="Targate Date"></asp:TableCell>
                  <asp:TableCell Text="Remark"></asp:TableCell>
                      
                      
                  <asp:TableCell Text="DESCRIPTION"></asp:TableCell>
                  <asp:TableCell Text="RESPONSIBLE DEPARTMENT"></asp:TableCell>
                  <asp:TableCell Text="RESPONSIBLE PERSON"></asp:TableCell>
                  <asp:TableCell Text="Targate Date"></asp:TableCell>
                  <asp:TableCell Text="Remark"></asp:TableCell>


                  <asp:TableCell Text="DESCRIPTION"></asp:TableCell>
                  <asp:TableCell Text="RESPONSIBLE DEPARTMENT"></asp:TableCell>
                  <asp:TableCell Text="RESPONSIBLE PERSON"></asp:TableCell>
                  <asp:TableCell Text="Targate Date"></asp:TableCell>
                      <asp:TableCell Text="Remark"></asp:TableCell>

                      <asp:TableCell Text="DESCRIPTION"></asp:TableCell>
                     <asp:TableCell Text="RESPONSIBLE DEPARTMENT"></asp:TableCell>
                     <asp:TableCell Text="RESPONSIBLE PERSON"></asp:TableCell>
                    <asp:TableCell Text="Targate Date"></asp:TableCell>
                    <asp:TableCell Text="Remark"></asp:TableCell>
             </asp:TableRow>

           <asp:TableRow>
                  <asp:TableCell>
                       <asp:TextBox ID="TextBox21" runat="server"></asp:TextBox>
                 
                  </asp:TableCell>
                  <asp:TableCell>
                                  <asp:TextBox ID="TextBox22" runat="server"></asp:TextBox>
                  </asp:TableCell>
                     <asp:TableCell>

               <asp:DropDownList ID="DropDownList4" runat="server" >
                   <asp:ListItem Text="FIXTURE" ></asp:ListItem>
                     <asp:ListItem Text="MATERIAL HANDLING"></asp:ListItem>
                      <asp:ListItem Text="FABRICATION"></asp:ListItem>
                       <asp:ListItem Text="INSTALLATION"></asp:ListItem>
                          <asp:ListItem Text="MAINTENANCE"></asp:ListItem>
                          <asp:ListItem Text="DEVELOPMENT"></asp:ListItem>
                          <asp:ListItem Text="OTHER ACTIVITIES"></asp:ListItem>
               </asp:DropDownList>
                 </asp:TableCell>
                  <asp:TableCell >
                      <asp:TextBox ID="TextBox18" runat="server"></asp:TextBox>
               </asp:TableCell>
<asp:TableCell>
   <asp:TextBox ID="TextBox19" runat="server"></asp:TextBox>
</asp:TableCell>
<asp:TableCell>
   <asp:TextBox ID="TextBox20" runat="server"></asp:TextBox>
</asp:TableCell>
<asp:TableCell>
 <asp:DropDownList ID="DropDownList1" runat="server" >
               <asp:ListItem Text="MARKETING" ></asp:ListItem>
                <asp:ListItem Text="DESIGN"></asp:ListItem>
                  <asp:ListItem Text="PURCHASE"></asp:ListItem>
                     <asp:ListItem Text="MANUFACTURING"></asp:ListItem>
                     <asp:ListItem Text="AUTOMATION"></asp:ListItem>
                     <asp:ListItem Text="HR"></asp:ListItem>
                     <asp:ListItem Text="ADMIN"></asp:ListItem>
                        <asp:ListItem Text="FINANCE"></asp:ListItem>
             </asp:DropDownList>
</asp:TableCell>
<asp:TableCell>

   <asp:DropDownList ID="DropDownList2" runat="server" >
               <asp:ListItem Text="QUALITY ASSURANCE" ></asp:ListItem>
                <asp:ListItem Text="INFORMATION TECHNOLOGY"></asp:ListItem>
                  <asp:ListItem Text="EDP"></asp:ListItem>
                     <asp:ListItem Text="MAINTAINENACE"></asp:ListItem>
                     <asp:ListItem Text="STORES"></asp:ListItem>
                     <asp:ListItem Text="PROJECTS"></asp:ListItem>
                    
             </asp:DropDownList>

             </asp:TableCell>
                   <asp:TableCell>
                       <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                   </asp:TableCell>
               
               <asp:TableCell>
                         <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
               </asp:TableCell>

                <asp:TableCell>
                            <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                </asp:TableCell>
            
              <asp:TableCell>
                           <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
              </asp:TableCell>
              
              <asp:TableCell>
                          <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
              </asp:TableCell>
              
              <asp:TableCell>
                          <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
              </asp:TableCell>
             
             <asp:TableCell>
                         <asp:TextBox ID="TextBox7" runat="server"></asp:TextBox>
             </asp:TableCell>

              <asp:TableCell>
                          <asp:TextBox ID="TextBox8" runat="server"></asp:TextBox>
              </asp:TableCell>
            
               <asp:TableCell>
                           <asp:TextBox ID="TextBox9" runat="server"></asp:TextBox>
               </asp:TableCell>
               
                <asp:TableCell>
                            <asp:TextBox ID="TextBox10" runat="server"></asp:TextBox>
                </asp:TableCell>
               
                <asp:TableCell>
                            <asp:TextBox ID="TextBox11" runat="server"></asp:TextBox>
                </asp:TableCell>
             
              <asp:TableCell>
                         <asp:TextBox ID="TextBox12" runat="server"></asp:TextBox>
              </asp:TableCell>

                <asp:TableCell>
                             <asp:TextBox ID="TextBox13" runat="server"></asp:TextBox>
                </asp:TableCell>
              
              <asp:TableCell>
                         <asp:TextBox ID="TextBox14" runat="server"></asp:TextBox>
              </asp:TableCell>
              
               <asp:TableCell>
                         <asp:TextBox ID="TextBox15" runat="server"></asp:TextBox>
               </asp:TableCell>
               
               <asp:TableCell>
                           <asp:TextBox ID="TextBox16" runat="server"></asp:TextBox>
               </asp:TableCell>
            
              <asp:TableCell>
                          <asp:TextBox ID="TextBox17" runat="server"></asp:TextBox>
              </asp:TableCell>
       </asp:TableRow>
       
       <asp:TableRow>
       
       <asp:TableCell>
           <asp:Button ID="Button1" runat="server" Text="Submit"  BackColor="Red"/>
       </asp:TableCell>
       </asp:TableRow>
       
       
       
       
</asp:Table>



</asp:Content>
<asp:Content ID="Content9" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

