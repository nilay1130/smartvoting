<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserPage.aspx.cs" Inherits="smartvoting.UserPage" %>

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
       <form id="form2" runat="server">
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
           <br /> <br /> <br /> <br /> <br />
           <div style="padding-top: 50px;"  > <center>
               <br />
               <asp:Button ID="BtnSeePoll" runat="server" Text="SEE POLL" Width="215px" BackColor="#393838" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" ForeColor="#CCCCCC" Height="30px" OnClick="BtnSeePoll_Click"  />
               <br />
               <br />
               <asp:Button ID="BtnVote" runat="server" Text="VOTE" Width="215px" BackColor="#393838" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" ForeColor="#CCCCCC" Height="30px" OnClick="BtnVote_Click" />
               <br />
               <br />
           <asp:Button ID="BtnResult" runat="server" Text="SEE ELECTION RESULTS" Width="215px" BackColor="#393838" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" ForeColor="#CCCCCC" Height="30px" OnClick="BtnResult_Click" />
               <br />
               <br />
               <asp:Button ID="BtnVerification" runat="server" Text="VERIFY YOUR VOTE" Width="215px" BackColor="#393838" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" ForeColor="#CCCCCC" Height="30px" OnClick="BtnVerification_Click"   />
           <br /> <br /> 
               <asp:Button ID="BtnChangePassword" runat="server" Text="CHANGE PASSWORD" Width="215px" BackColor="#393838" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" ForeColor="#CCCCCC" Height="30px" OnClick="BtnChangePassword_Click" />
            <br /><br /> 
            </center></div>

            <div class="col-xs-12">
           <footer>
                <p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;</p>
                <p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
                      
       
           
                </p>
                <p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
           
       
           
                </p>
                <p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;</p>
                <p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
           
       
           
                    &nbsp;</p>
                <p>&nbsp;</p>
                <p>&nbsp;</p>
                <p>&nbsp;</p>
                <p>&nbsp;</p>
                <p>&copy; <%: DateTime.Now.Year %> - Smart Voting Web Application</p>
            </footer>        
            </div>    	
	                    
                    	   <br />
           <br />
	                    
                    	   </form> 
       </div>
      
</body>
</html>

