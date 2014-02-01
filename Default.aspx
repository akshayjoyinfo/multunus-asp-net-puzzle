<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Multunus Twitter Puzzle </title>
     <link rel="stylesheet" type="text/css" href="styles/style.css" />
    <script src="scripts/jquery-1.10.2.min.js" type="text/javascript" > </script>
    <script language="javascript" type="text/javascript">



        $(document).ready(function () {

            $('#SampleTweetHandle').bind('click', function (event) {
                // alert(event.target.id);
                try {
                    var ImgSrc = event.target.id; // get id of first image
                    $('#txtTwitterHandle').val(ImgSrc);
                    $('#btnGetTweetCircle').trigger('click');

                } catch (err) {
                    alert(err);
                }
            });





        });

        function btnGetTweetClientClik()
        {
            try{

                var URL = $("#txtTwitterHandle").val();
                if (URL == '') {
                    alert("Please enter the URL ");
                    return false;
                }

                var pattern = /(ftp|http|https):\/\/(\w+:{0,1}\w*@)?(\S+)(:[0-9]+)?(\/|\/([\w#!:.?+=&%@!\-\/]))?/;
                if (pattern.test(URL)) {
                    


                    return true;
                }
                alert("Url is not valid!");
                return false;
              
            }
            catch(err) {
                alert(err);
            }

        }

    </script>
</head>
<body background="images/Bg-Screen.jpg" style="background-size: 100%;overflow : scroll;">
    <form id="form1" runat="server">
    <div id="SampleTweetHandle" class="imageTweetHandler">
    
    <img src="https://pbs.twimg.com/profile_images/426158315781881856/sBsvBbjY.png" id="https://twitter.com/github/status/428654444993994752" />
    <img src="https://pbs.twimg.com/profile_images/2284174758/v65oai7fxn47qv9nectx.png" id="https://twitter.com/twitter/status/428602381920514048" />
    <img src="https://pbs.twimg.com/profile_images/79787739/mf-tg-sq.jpg" id="https://twitter.com/martinfowler/status/428547772103421952" />
    <img src="https://pbs.twimg.com/profile_images/424495004/GuidoAvatar.jpg" id="https://twitter.com/gvanrossum/status/424595747397332992" />
    <img src="https://pbs.twimg.com/profile_images/378800000091193257/fcb03c8d0a40048f2537df967239686f.jpeg" id="https://twitter.com/spolsky/status/427937968980889600" />
    <img src="https://pbs.twimg.com/profile_images/378800000324784929/1a4ee3fde80808a96ed268a7fb94682d.png" id="https://twitter.com/firefox/status/429335785393758210" />
    </div>
    
    <div id="main-Container" style="width:1024px;height:100%">
        
        <div id="main-data-query" style="margin-left:38%;margin-top:10%;">
            <asp:Label runat="server" id="lblTwitterHandle" Text="Enter a Valid Tweet Handle" style="color:White;font-size:20px;font-weight:bold;font-family:Arial Black"/>
            <input type="text" runat="server" name="txtTwitterHandle" id="txtTwitterHandle" value="https://twitter.com/firefox/status/429335785393758210" style="color:Navy;font-size:25px;background-color:White;height:35px;width:620px;border-color:Silver"/>
            <asp:Button runat="server" id="btnGetTweetCircle" name="btnGetTweetCircle" 
                Text="Get 9 Pool Tweet Circle" 
                style="color:White;font-size:25px; cursor:pointer; font-weight:bold;margin-left:22%;margin-top:2%;height:45px;width:300px;background-color:#c70606" 
                OnClientClick="return btnGetTweetClientClik()" 
                onclick="btnGetTweetCircle_Click" /> 
        </div>
            
    </div>
    </form>
</body>
</html>
