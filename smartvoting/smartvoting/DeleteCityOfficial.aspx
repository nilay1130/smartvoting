<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DeleteCityOfficial.aspx.cs" Inherits="smartvoting.DeleteCityOfficial" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Smart Voting</title>
    <link href="css/bootstrap.css" rel="stylesheet" />
    <script src="scripts/1.11.2.jquery.min.js"></script>
    <script src="scripts/jquery-1.10.2.js"></script>
    <script src="scripts/myJs.js"></script>
    <link href="css/MyCss.css" rel="stylesheet" />
    <link  href="http://maxcdn.bootstrapcdn.com/font-awesome/4.3.0/css/font-awesome.min.css" rel="stylesheet" />
    <link rel="shortcut icon" type="image/x-icon" href="http://maxcdn.bootstrapcdn.com/font-awesome/4.3.0/css/font-awesome.min.css" />
</head>
<body>
   
   <div class="container" id="cerceve">
        <form id="form7" runat="server">
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
       
        <br />
        <br />
        <br />
       
        <br />
       
        </div>
            
            <div style="padding-top: 50px;" >
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="LabelTc" runat="server" Text="TC Identity Number" style="font-weight:bold" ></asp:Label>
                &nbsp;&nbsp;:&nbsp;&nbsp;
                
                <asp:TextBox ID="TextBoxTc" runat="server" Width="200px"  ></asp:TextBox><br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="BtnDeleteCityOfficial" runat="server" Text="DELETE" Width="70px" BackColor="#393838" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" ForeColor="#CCCCCC" Height="30px" OnClick="BtnDeleteCityOfficial_Click"  />
                &nbsp;&nbsp;
                &nbsp;<asp:Label ID="LabelResult" runat="server" Text=""></asp:Label>
                <br />
                <br />
                <br />

                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

                </div>
                
             <div class="col-xs-12">
           <footer>
                <p>&nbsp;</p>
                <p>&nbsp;</p>
                <p>&nbsp;</p>
                <p>&nbsp;</p>
                <p>&nbsp;</p>
                <p>&nbsp;</p>
                <p>&copy; <%: DateTime.Now.Year %> - Smart Voting Web Application</p>
            </footer>        
            </div>  
      
      </form>
	     </div>
        
      
      
</body>

</html>


