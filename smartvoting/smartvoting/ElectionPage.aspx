<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ElectionPage.aspx.cs" Inherits="smartvoting.ElectionPage" %>

<%@ PreviousPageType VirtualPath="~/VotePage.aspx" %>

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
        <form id="form6" runat="server">
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
            
            <div style="padding-top: 50px;"  >  
                <center> <asp:Label ID="Label1" runat="server" Text="Serial Number for this vote:" Font-Bold="True" Font-Size="Large"></asp:Label>  
                &nbsp;  
                <asp:Label ID="Label2" runat="server" Font-Size="Large"></asp:Label> 
                    <br />
 <br />
                    <asp:Label ID="Label3" runat="server" Font-Size="Large" ForeColor="Red" Text="Please select one!" Visible="False"></asp:Label>
                <br />
 <asp:RadioButtonList ID="RadioButtonList1" runat="server" width ="300px" Font-Size="Large" > 
                </asp:RadioButtonList>
                <br />
                 <br /> 
                 <asp:Button ID="Button1" runat="server" Text="VOTE" BackColor="#393838" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" ForeColor="#CCCCCC" Height="40px" OnClick="Button1_Click" Font-Size="Large" Width="105px"/>  
                &nbsp;  
                    <br />
                    <br />
                    <asp:Label ID="LabelResult" runat="server" Font-Size="Large"></asp:Label> </center>
                <br /> 
                 
                </div>
                
             <div class="col-xs-12">
           <footer>
                <p>&nbsp;</p>
                <p>&nbsp;</p>
                <p>&nbsp;</p>
                <p>&nbsp;</p>
                <p>&nbsp;</p>
                <p>&nbsp;</p>
                <p>&copy; <%: DateTime.Now.Year %>- Smart Voting Web Application</p>
            </footer>        
            </div>  
      
      </form>
	     </div>
        
      
      
</body>

</html>
