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
    protected void Page_Load(object sender, EventArgs e)
    {                
        try
        {

            string twitterconsumerKey = "hURSVYMlVMPMYKKOgiBitQ";
            string twxitterCosnumerSecret = "TFaCy4fUUSbparCOF8o1jpFRwzXoQ49Zt9xeaUyBAMQ";
            string twitterAccessToken = "1872531062-9YB2m6RP5AnvwOjrklec6yBzVGNRLabHs5Gq8yc";
            string twitterAccessTokenSecret = "KI4NSeY9gwNlCX49AiyyOTqZxHfM1zpXmZFsnJQVIFUwg";

            var service = new TwitterService(twitterconsumerKey, twxitterCosnumerSecret);
            service.AuthenticateWith(twitterAccessToken, twitterAccessTokenSecret);

            if (Session["TweetURL"] != null)
            {

                string url = Session["TweetURL"].ToString();
                string[] URLContents = url.Split('/');
                
                Int64 status = Convert.ToInt64(URLContents[URLContents.Length-1]);
                string tweetedUser = URLContents[URLContents.Length-3];

                if (URLContents.Length >= 6)
                {

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

                        List<TwitterStatus> Sortedtweets = (List<TwitterStatus>)tweets.OrderByDescending(tw => tw.User.FollowersCount).ToList();

                        // Main Circel Images

                        HtmlImage mainCirleHandle = (HtmlImage)this.FindControl("MainCircle");
                        mainCirleHandle.Attributes["src"] = MainCircleURL;

                        // Child Circle Tweets Profile Images
                        int startCount = 1;
                        foreach (TwitterStatus twt in Sortedtweets)
                        {

                            HtmlImage childCircleHandle = (HtmlImage)this.FindControl(CHILD_CIRLCE_IMGID + startCount);
                            if (childCircleHandle != null)
                            {
                                childCircleHandle.Attributes["src"] = twt.User.ProfileImageUrl.Replace("_normal", "");
                                // childCircleHandle.Attributes["child-circle-"+startCount] = startCount.ToString();

                                HtmlControl childCircleDivHandle = (HtmlControl)this.FindControl(CHILD_CIRLCE_DIVID + startCount);
                                childCircleDivHandle.Attributes["title"] = startCount.ToString();
                                startCount++;
                            }
                        }
                    }
                    else
                    {
                        Response.Write("<script>alert('Failled to get Tweitter Handle, Please try again later');</script>");
                        
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

   

    
    protected void BtnTryAnotherHandle_Click(object sender, EventArgs e)
    {

        Session["TweetURL"] = null;
        Response.Redirect("Default.aspx");
    }
}
