<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Contacts.aspx.cs" Inherits="smartvoting.Contacts" %>

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
       <form id="form1" runat="server">
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
                    
                      </ul>
      </div>
       
        </div>
      
                	
	                    
                    	
<div class="container">
<div class="col-sm-5">
    <div class="form-area">  
        
        <br style="clear:both">
                    <h3 style="margin-bottom: 25px; text-align: center;">Contact Form</h3>
    				<div class="form-group">
						<input  runat="server" type="text" class="form-control" id="name"  placeholder="Name" required="required"/>
					</div>
					<div class="form-group">
						<input  runat="server" type="text" class="form-control" id="email"  placeholder="Email" required="required"/>
					</div>
					<div class="form-group">
						<input runat="server" type="text" class="form-control" id="mobile"  placeholder="Phone" required="required"/>
					</div>
					<div class="form-group">
						<input runat="server" type="text" class="form-control" id="subject"  placeholder="Topic" required="required"/>
					</div>
                    <div class="form-group">
                    <textarea class="form-control"  runat="server" type="textarea" id="message" placeholder="Message" maxlength="140" rows="7"></textarea>
                                          
                    </div>
        <asp:Label runat="server" ID="lblFormResult" style="float:right;width:380px;"></asp:Label>
       <asp:Button ID="Button1" runat="server" Text="Submit" OnClick="Button1_Click" class="btn btn-primary pull-right"/>
        

 
    

                        	
                        </div>
                    </div>
      <div class="container">
           <div class="col-sm-5">
               
	                        <div style="margin-top: 40px; padding-bottom: 10px; padding-left: 80px;">
	                            <div><b>Get In Touch</b></div>
                                <div style="border-bottom: 1px solid #2e2e2e; padding-bottom:20px;">Please call us now or submit the form to the left and one of our representatives will contact you shortly. We welcome all of your comments and queries!</div>
	                        </div>
               <div style="margin-top: 40px; padding-bottom: 10px; padding-left: 80px;">
	                            <div><b>Phone Numbers</b></div>
                                <div style="border-bottom: 1px solid #2e2e2e; padding-bottom:20px;">11111</div>
	                        </div>
               
               <div style="margin-top: 40px; padding-bottom: 10px; padding-left: 80px;">
	                            <div><b>Adress</b></div>
                                <div style="border-bottom: 1px solid #2e2e2e; padding-bottom:20px;">aaaaaaaa</div>
	                        </div>
	                    </div>
	                    </div>
           
        
        
      
                </div>
       <div class="col-xs-12">
           <footer>
                <p>&copy; <%: DateTime.Now.Year %> - Smart Voting Web Application</p>
            </footer>        
            </div>  
              </form> 
       </div>
      
     
    
       
      
    
        
	 
</body>
</html>
