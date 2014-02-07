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
        
        <asp:Panel runat="server" ID="TwitterCirclePanel" Width="500" Height="400" >

        </asp:Panel>

    </div>
    <input type="text" name="HidTweetCircleCount" id="HidTweetCircleCount" runat="server" style="display:none" />
</body>
</html>
