using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TweetSharp;
using System.Web.UI.HtmlControls;

public partial class Result : System.Web.UI.Page
{
    public static int NUMBER_OF_RETWEETS=10; // If the Count is 10, then TweetSharp will retrive the top 9 retweets through the API
    public static string CHILD_CIRLCE_IMGID = "img";
    public static string CHILD_CIRLCE_DIVID = "childcircle";
    public static string TWITTER_TOKEN_SEPERATOR = "@#$%^&*";
    protected void Page_Load(object sender, EventArgs e)
    {                
        try
        {

            string twitterconsumerKey = "hURSVYMlVMPMYKKOgiBitQ";
            string twxitterCosnumerSecret = "TFaCy4fUUSbparCOF8o1jpFRwzXoQ49Zt9xeaUyBAMQ";
            string twitterAccessToken = "1872531062-9YB2m6RP5AnvwOjrklec6yBzVGNRLabHs5Gq8yc";
            string twitterAccessTokenSecret = "KI4NSeY9gwNlCX49AiyyOTqZxHfM1zpXmZFsnJQVIFUwg";
            string TwitterTokenKey = string.Empty;
            bool handleExist = false;
            
            if (Session["TweetURL"] != null)
            {

                string url = Session["TweetURL"].ToString();
                string[] URLContents = url.Split('/');
                
                Int64 status = Convert.ToInt64(URLContents[URLContents.Length-1]);
                string tweetedUser = URLContents[URLContents.Length-3];

                if (URLContents.Length >= 6)
                {
                    TwitterTokenKey = tweetedUser + TWITTER_TOKEN_SEPERATOR + status;

                    handleExist = TwitterSharedLib.IsTwitterHandleExist(TwitterTokenKey);

                    if (handleExist == false)
                    {

                        var service = new TwitterService(twitterconsumerKey, twxitterCosnumerSecret);
                        service.AuthenticateWith(twitterAccessToken, twitterAccessTokenSecret);

                        RetweetsOptions tweetOptions = new RetweetsOptions();
                        tweetOptions.Id = status;
                        tweetOptions.Count = NUMBER_OF_RETWEETS;

                        //Twitteru
                        GetTweetOptions tweetUser = new GetTweetOptions();
                        //tweetUser.IncludeEntities=true;
                        tweetUser.Id = status;

                        TwitterStatus tweetOwner = service.GetTweet(tweetUser);
                        string MainCircleURL = tweetOwner.Author.ProfileImageUrl.Replace("_normal", "");

                        List<TwitterStatus> tweets = (List<TwitterStatus>)service.Retweets(tweetOptions);

                        if (tweets != null)
                        {
                            int tweetCount = 9;

                            if (tweets.Count >= NUMBER_OF_RETWEETS)
                            {
                                tweetCount = 10;
                            }
                            else
                            {
                                tweetCount = tweets.Count;
                            }


                            List<TwitterStatus> Sortedtweets = (List<TwitterStatus>)tweets.OrderByDescending(tw => tw.User.FollowersCount).ToList().GetRange(0, tweetCount);

                            SetTweetImages(MainCircleURL, Sortedtweets);
                           
                            bool success = TwitterSharedLib.StoreTwitterHandle(MainCircleURL, Sortedtweets, TwitterTokenKey, DateTime.Now);

                        }
                        else
                        {
                            Response.Write("<script>alert('Failled to get Tweitter Handle, Please try again later');</script>");
                        }
                    }
                    else
                    {
                        TwitterSessionState twitterSession = TwitterSharedLib.GetTwitterHandle(TwitterTokenKey);
                        if (twitterSession != null)
                        {
                            SetTweetImages(twitterSession.ProfileImageUrl, twitterSession.RetweetedStatusInformation);
                        }
                        else
                        {
                            Response.Write("<script>alert('Error Occured Try again');</script>");
                            Session["TweetURL"] = null;
                            
                        }
                    }
                }
                else
                {
                    Response.Write("<script>alert('Please check the Tweet URL, Tweet id is missing');</script>");
                    Response.Redirect("Default.aspx");
                }
            }
            else
            {
                Response.Write("<script>alert('Please Enter the URL !  And try again');</script>");
                Response.Redirect("Default.aspx");
            }
            
        }
        catch (Exception exp)
        {
            Response.Write("<script>alert('Unknown error occured "+exp.Message +"');</script>");
        }
    }


    protected void SetTweetImages(string mainCircleURL, List<TwitterStatus> sortedRetweets)
    {
        try
        {
            // Main Circel Images
            HtmlGenericControl mainCirleHandle = new HtmlGenericControl("div");
            mainCirleHandle.Attributes.Add("class", "main-circle");

            string mainCircleinnerHtml = "<img runat=\"server\" id=\"MainCircle\" src=\" "+ mainCircleURL +"\"/>";

            mainCirleHandle.InnerHtml = mainCircleinnerHtml;

            TwitterCirclePanel.Controls.Add(mainCirleHandle);

            int startCount = 1;

            HidTweetCircleCount.Value = sortedRetweets.Count.ToString();
            foreach (TwitterStatus twt in sortedRetweets)
            {

                HtmlGenericControl divChildCircle = new HtmlGenericControl("div");
                divChildCircle.Attributes.Add("class", "child-item tooltip");
                divChildCircle.Attributes.Add("id", CHILD_CIRLCE_DIVID + startCount);
                divChildCircle.Attributes.Add("runat", "server");
                divChildCircle.Attributes.Add("style", "width: 75px; height:75px; position:absolute; border-radius:50%; background-size: cover; display: block;");

                string childCircleImg = "<img runat=\"server\" id=\"img" + startCount + "\" src=\"" + twt.User.ProfileImageUrl.Replace("_normal", "") + "\" />";
                divChildCircle.InnerHtml = childCircleImg;
                divChildCircle.Attributes["title"] = startCount.ToString();
                TwitterCirclePanel.Controls.Add(divChildCircle);
                startCount++;
            }
        }
        catch (Exception exp)
        {

        }
    }

    
    protected void BtnTryAnotherHandle_Click(object sender, EventArgs e)
    {

        Session["TweetURL"] = null;
        Response.Redirect("Default.aspx");
    }
}
