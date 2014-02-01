<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Result.aspx.cs" Inherits="Result" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Multnus Puzzle</title>
   <link rel="stylesheet" type="text/css" href="styles/style.css" />
    <script src="scripts/jquery-1.10.2.min.js" type="text/javascript" > </script>
	<script src="scripts/puzzle.js" type="text/javascript" > </script>
	
  </head>

<body background="images/Main-Bgr.png" style="background-size: 100%;overflow : scroll;">
<form runat="server" >
<p align="right">
<asp:Button runat="server" ID="BtnTryAnotherHandle" Text ="TRY ANOTHER HANDLE"
        style=" color:White;font-size:14px; font-weight:normal;margin-right:2%;cursor:pointer; margin-top:0.5%;height:27px;width:250px;background-color:#c70606; border:none" 
        onclick="BtnTryAnotherHandle_Click" />
</p>
</form>
    <div id="main-Container" style="width:1024px;height:680px" >
        
        <div class="main-circle">
		  <img runat="server" id="MainCircle" src="images/Main.png">
		</div>
		<div id="childcircle1" runat="server" class="child-item tooltip" >
			<img id="img1" runat="server" src="images/1.jpeg">
		</div>
		<div id="childcircle2" runat="server" class="child-item tooltip" >
			<img id="img2" runat="server"  src="images/2.png">
		</div>
		<div id="childcircle3" runat="server" class="child-item tooltip" >
			<img id="img3" runat="server" src="images/3.jpeg">
		</div>
		<div id="childcircle4" runat="server" class="child-item tooltip" >
			<img id="img4" runat="server" src="images/4.jpeg">
		</div>
		<div id="childcircle5" runat="server" class="child-item tooltip" >
			<img id="img5" runat="server" src="images/5.jpeg">
		</div>
		<div id="childcircle6" runat="server" class="child-item tooltip" >
			<img id="img6" runat="server" src="images/6.jpeg">
		</div>
		<div id="childcircle7" runat="server" class="child-item tooltip">
			<img id="img7" runat="server" src="images/7.jpg">
		</div>
		<div id="childcircle8" runat="server" class="child-item tooltip" >
			<img id="img8" runat="server" src="images/8.jpeg">
		</div>
		<div id="childcircle9" runat="server" class="child-item tooltip">
			<img id="img9" runat="server" src="images/9.png">
		</div>

    </div>
</body>
</html>
