<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminPage.aspx.cs" Inherits="smartvoting.AdminPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

    <head runat="server">
    <title>Smart Voting</title>
    <link href="css/bootstrap.css" rel="stylesheet" />
    <script src="scripts/1.11.2.jquery.min.js"></script>
    <script src="scripts/jquery-1.10.2.js"></script>
    <script src="scripts/JavaScript.js"></script>
    <link href="css/MyCss.css" rel="stylesheet" />
    <link  href="http://maxcdn.bootstrapcdn.com/font-awesome/4.3.0/css/font-awesome.min.css" rel="stylesheet" />
    <link rel="shortcut icon" type="image/x-icon" href="http://maxcdn.bootstrapcdn.com/font-awesome/4.3.0/css/font-awesome.min.css" />
        
</head>

<body>
    
   <div class="container" id="cerceve">
       <form id="form3" runat="server">
    <div id="menu1">
      
      <div class="col-md-12" id="menu">
          <div class="col-md-2" id="logo">
               <a  href="Home.aspx"> <img src="img/logo.png" /> </a> 
        </div>
         <ul>
              <li><a href="/Home.aspx">Home</a></li>
              <li><a href="/About.aspx">About</a></li>
              <li><a href="http://smartvotingapplication.blogspot.com.tr/">Blog</a></li>
              <li><a href="/Contacts.aspx">Contacts</a></li>
              <li><a href="/LogOut.aspx">Log Out</a></li>
              
                    
                      </ul>
      </div>
       
      </div> 
      <br /><br /><br /><br /><br />
           <div style="padding-top: 50px;"> <center>
           
               <asp:Button ID="BtnAddUser" runat="server" Text="ADD USER" Width="191px" BackColor="#393838" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" ForeColor="#CCCCCC" Height="30px" OnClick="BtnAddUser_Click" />
           
               &nbsp;&nbsp;&nbsp;
           
               <asp:Button ID="BtnAddPoll" runat="server" Text="ADD POLL" Width="191px" BackColor="#393838" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" ForeColor="#CCCCCC" Height="30px" OnClick="BtnAddPoll_Click" />
           
               &nbsp;&nbsp;&nbsp;
               <asp:Button ID="BtnShowCityOfficial" runat="server" Text="SHOW CITY OFFICIAL" Width="191px" BackColor="#393838" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" ForeColor="#CCCCCC" Height="30px" OnClick="BtnShowCityOfficial_Click" />             
           
               <br /><br />

               <asp:Button ID="BtnDeleteUser" runat="server" Text="DELETE USER" Width="191px" BackColor="#393838" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" ForeColor="#CCCCCC" Height="30px" OnClick="BtnDeleteUser_Click" />            
           &nbsp;&nbsp;&nbsp;
               <asp:Button ID="BtnDeletePoll" runat="server" Text="DELETE POLL" Width="191px" BackColor="#393838" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" ForeColor="#CCCCCC" Height="30px" OnClick="BtnDeletePoll_Click" />
           &nbsp;&nbsp;&nbsp;
               <asp:Button ID="BtnShowGeneralOfficial" runat="server" Text="SHOW GENERAL OFFICIAL" Width="191px" BackColor="#393838" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" ForeColor="#CCCCCC" Height="30px" OnClick="BtnShowGeneralOfficial_Click" />
           
               <br /><br />
           
               <asp:Button ID="BtnUpdateUser" runat="server" Text="UPDATE USER" Width="191px" BackColor="#393838" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" ForeColor="#CCCCCC" Height="30px" OnClick="BtnUpdateUser_Click" />
               &nbsp;&nbsp;&nbsp;
               <asp:Button ID="BtnUpdatePoll" runat="server" Text="UPDATE POLL" Width="191px" BackColor="#393838" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" ForeColor="#CCCCCC" Height="30px" OnClick="BtnUpdatePoll_Click" />
               &nbsp;&nbsp;&nbsp;
               <asp:Button ID="BtnChangeAdminPassword" runat="server" Text="CHANGE PASSWORD" Width="191px" BackColor="#393838" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" ForeColor="#CCCCCC" Height="30px" OnClick="BtnChangeAdminPassword_Click" />
           
           </center>
               
           </div>
           
            <div class="col-xs-12">
           <footer>
                <p>&nbsp;</p>
                <p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
           
           
                </p>
                <p>&nbsp;</p>
                <p>&nbsp;</p>
                <p>&nbsp;</p>
                <p>&copy; <%: DateTime.Now.Year %>- Smart Voting Web Application</p>
            </footer>        
            </div>    	
	                    
                    	   &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                      
       
           
                	
	                    
                    	   </form> 
       </div>
      
</body>
</html>
