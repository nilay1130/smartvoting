<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="smartvoting.Home" EnableEventValidation='false'%>

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
        <form id="form5" runat="server">
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
        
       <div class="col-sm-4" >
        
        <section id="login"  >
           
       <p>Login to Your Account</p>
              
                <form role="form" action="javascript:;" method="post" id="login-form" autocomplete="off">
                    <div class="form-group" >
                        <input runat="server" id="username"  type="text" placeholder="Username" class="form-control input-md" required="required"/>
                    </div>
                    <div class="form-group">
                         <input runat="server" id="password"  type="password" placeholder="Password" class="form-control input-md" required="required"/>
                    </div>
                    
                    <asp:Button ID="btnLogin" runat="server" Text="Log in" OnClick="btnlogin_Click" class="btn btn-custom btn-lg btn-block"/>
                      <br />
&nbsp;
                    <asp:Label runat="server" ID="lblFormResult" style="text-align:center;width:380px;" ForeColor="#CC0000"></asp:Label>
                    </form> 
               
                <a href="javascript:;" class="forget" data-toggle="modal" data-target=".forget-modal">Forgot Your Password?</a>
                <hr/>   
                             	   
    		
          
    	</section>
   
          </div> 
         

<div class="modal fade forget-modal" tabindex="-1" role="dialog" aria-labelledby="myForgetModalLabel" aria-hidden="true">
	<div class="modal-dialog modal-md">
		<div class="modal-content">
			<div class="modal-header">
				<button type="button" class="close" data-dismiss="modal">
					<span aria-hidden="true">×</span>
					<span class="sr-only">Close</span>
				</button>
				<h4 class="modal-title">Recovery password</h4>
			</div>
			<div class="modal-body">
				<p>Type your email account</p>
				<input type="email" name="recovery-email" id="recovery-email" class="form-control" autocomplete="off"/>
			</div>
			<div class="modal-footer">
				<button type="button" class="btn btn-default" data-dismiss="modal">Cancel</button>
				<button type="button" class="btn btn-custom">Recovery</button>
			</div>
		</div> <!-- /.modal-content -->
	</div> <!-- /.modal-dialog -->
</div> <!-- /.modal -->

          
          	
     
   
       <div class="col-xs-12">
           <footer>
                <p>&copy; <%: DateTime.Now.Year %> - Smart Voting Web Application</p>
                <img src="img/comodo.png" />
            </footer>        
            </div>  
      
      </form>
	     </div>
        
      
      
</body>

</html>

