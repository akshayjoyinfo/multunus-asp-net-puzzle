using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Session["TweetURL"] = null;
    }
    protected void btnGetTweetCircle_Click(object sender, EventArgs e)
    {
        try
        {
            string URL = txtTwitterHandle.Value.ToString();

            Uri uri = new Uri(URL);
            HttpWebRequest request = (HttpWebRequest) HttpWebRequest.Create(uri);
            request.Timeout = 3000;
            HttpWebResponse response;
            response = (HttpWebResponse)request.GetResponse();
            if (response.StatusCode ==  HttpStatusCode.OK)
            {
                Session["TweetURL"] = URL;
                Response.Redirect("Result.aspx");
            }
            else
            {
                txtTwitterHandle.Value = "";
                Response.Write("<script>alert('Twitter Handle not Exist ! Please try again');</script>");
            }


        }
        catch (Exception exp)
        {
            txtTwitterHandle.Value = "";
            Response.Write("<script>alert('Twitter Handle not Exist ! Please try again');</script>");
        }
    }
}
