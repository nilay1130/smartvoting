<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="smartvoting.About" %>

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
        <div class="BodyContent" style="padding: 15px; clear: both;">
            <h3>Who are we?</h3>
            <p>We are just students who are concerned to build a secure voting system.</p>
            <p><b>Our Mission</b>:We want to provide a fair election system.</p>
            <p><b>Our Strengths</b>:aaaaa</p>
            <h3>Team Members</h3>
        </div>
        <div class="container" style="padding-top: 20px; clear: both;">
            <div class="row">
                <div class="col-sm-4">
                    <div id="card" style="overflow: hidden; position: relative;border: 1px solid #fff; border-radius: 8px;text-align: center;padding: 0;background-color: #444;color: #fff">
                        <canvas class="header-bg" width="100" height="150" id="header-blur" style="position: absolute;top: 0;left: 0;width:100%;height: 70px;z-index: 1;"></canvas>
                       <div class="content" style="font-weight:bold; text-align:center">
                          <p>Gözde Buse ÖCAL </p>
                            
                    </div>
                </div>
            </div>
                 <div class="col-sm-4">
                    <div id="card" style="overflow: hidden; position: relative;border: 1px solid #fff; border-radius: 8px;text-align: center;padding: 0;background-color: #444;color: #fff">
                        <canvas class="header-bg" width="100" height="150" id="header-blur" style="position: absolute;top: 0;left: 0;width:100%; height: 70px;z-index: 1;"></canvas>
                       <div class="content" style="font-weight:bold;text-align:center">
                          <p>Nesibe Balaban</p>
                          
                    </div>
                </div>
            </div>
                <div class="col-sm-4">
                    <div id="card" style="overflow: hidden; position: relative;border: 1px solid #fff; border-radius: 8px;text-align: center;padding: 0;background-color: #444;color: #fff">
                        <canvas class="header-bg" width="100" height="150" id="header-blur" style="position: absolute;top: 0;left: 0;width:100%; height: 70px;z-index: 1;"></canvas>
                       <div class="content" style="font-weight:bold;text-align:center">
                          <p>Nilay AKYOL</p>
                          
                    </div>
                </div>
            </div> 
        </div>
            </div>
       <div class="col-xs-12">
           <footer>
                <p>&nbsp;</p>
                <p>&copy; <%: DateTime.Now.Year %> - Smart Voting Web Application</p>
                <p>&nbsp;</p>
            </footer>        
            </div>  
      
    </div>
	      
</body>
</html>

