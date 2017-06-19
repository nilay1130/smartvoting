<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SuperAdminPage.aspx.cs" Inherits="smartvoting.SuperAdminPage" %>

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
  
           <br /> <br /> <br /> <br /> <br /> <br /> 
           <div style="padding-top: 50px;"  >  
           <center>

               <asp:Button ID="BtnAddCandidate" runat="server" Text="ADD CANDIDATE" Width="220px" BackColor="#393838" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" ForeColor="#CCCCCC" Height="30px" OnClick="BtnAddCandidate_Click" />
               &nbsp;&nbsp;
               <asp:Button ID="BtnDeleteCandidate" runat="server" Text="DELETE CANDIDATE" Width="220px" BackColor="#393838" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" ForeColor="#CCCCCC" Height="30px" OnClick="BtnDeleteCandidate_Click" />
               &nbsp;&nbsp; 
               <asp:Button ID="BtnUpdateCandidate" runat="server" Text="UPDATE CANDIDATE" Width="220px" BackColor="#393838" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" ForeColor="#CCCCCC" Height="30px" OnClick="BtnUpdateCandidate_Click" />
               <br /> <br />


               <asp:Button ID="BtnAddCandidateToElection" runat="server" Text="ADD CANDIDATE TO ELECTION" Width="220px" BackColor="#393838" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" ForeColor="#CCCCCC" Height="30px" OnClick="BtnAddCandidateToElection_Click" />
               &nbsp;&nbsp;
               <asp:Button ID="BtnDeleteCityOfficial" runat="server" Text="DELETE CITY OFFICIAL" Width="220px" BackColor="#393838" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" ForeColor="#CCCCCC" Height="30px" OnClick="BtnDeleteCityOfficial_Click" />
               &nbsp;&nbsp;
               <asp:Button ID="BtnUpdateElection" runat="server" Text="UPDATE ELECTION" Width="220px" BackColor="#393838" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" ForeColor="#CCCCCC" Height="30px" OnClick="BtnUpdateElection_Click" />
               <br /> <br />
               
               <asp:Button ID="BtnAddCityOfficial" runat="server" Text="ADD CITY OFFICIAL" Width="220px" BackColor="#393838" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" ForeColor="#CCCCCC" Height="30px" OnClick="BtnAddCityOfficial_Click" />
               &nbsp;&nbsp;
               <asp:Button ID="BtnDeleteGeneralOfficial" runat="server" Text="DELETE GENERAL OFFICIAL" Width="220px" BackColor="#393838" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" ForeColor="#CCCCCC" Height="30px" OnClick="BtnDeleteGeneralOfficial_Click" />
               &nbsp;&nbsp;
               <asp:Button ID="BtnChangeSuperAdminPassword" runat="server" Text="CHANGE PASSWORD" Width="220px" BackColor="#393838" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" ForeColor="#CCCCCC" Height="30px" OnClick="BtnChangeSuperAdminPassword_Click" />
               <br /> <br />
           
               <asp:Button ID="BtnAddElection" runat="server" Text="ADD ELECTION" Width="220px" BackColor="#393838" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" ForeColor="#CCCCCC" Height="30px" OnClick="BtnAddElection_Click" />
			   &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
               <br /> <br />
               <asp:Button ID="BtnAddGeneralOfficial" runat="server" Text="ADD GENERAL OFFICIAL" Width="220px" BackColor="#393838" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" ForeColor="#CCCCCC" Height="30px" OnClick="BtnAddGeneralOfficial_Click"/>
               &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

               
           </center>

               </div>
            <div class="col-xs-12">
           <footer>
                <p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </p>
                <p>&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
           
       
           
                </p>
                <p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </p>
                <p>&nbsp;</p>
                <p>&nbsp;</p>
                <p>&nbsp;</p>
                <p>&nbsp;</p>
                <p>&copy; <%: DateTime.Now.Year %>- Smart Voting Web Application</p>
            </footer>        
            </div>    	 
                	
	                    
                    	   <br />
           
       
           
                	
	                    
                    	   </form> 
       </div>
      
</body>
</html>

