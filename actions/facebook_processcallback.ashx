<%@ WebHandler Language="C#" Class="processcallback" %>

using System;
using System.Web;
using System.Net;
using System.IO;
using Newtonsoft.Json.Linq;
using WebsiteModel;
using System.Linq;
using System.Web.Security;

public class processcallback : IHttpHandler
{

    public string requestFBData(string action)
    {
        HttpWebRequest req = (HttpWebRequest)WebRequest.Create(action);
        HttpWebResponse resp = (HttpWebResponse)req.GetResponse();

        StreamReader sr = new StreamReader(resp.GetResponseStream());
        string results = sr.ReadToEnd();
        sr.Close();

        return results;
    }
    
    
    public void ProcessRequest(HttpContext context)
    {
        
        
        //Facebook returns a response to this page.
        
        
        //if error in URL, email us via elmah, but dont give user an error.
        if (!String.IsNullOrEmpty(context.Request.QueryString["error"] ))
        {
            Exception e = new Exception(String.Format("Facebook Error: {0}", context.Request.QueryString["error"]));
            Elmah.ErrorSignal.FromCurrentContext().Raise(e);
            context.Response.Redirect("/account");
        }
        
        
            string token = GetAuthCodeFromResponse(context);

            string url = "https://graph.facebook.com/me?fields=id,first_name,last_name&access_token=" + token;

            FacebookUtility fb = new FacebookUtility();
            fb.Token = token;

            JObject myProfile = JObject.Parse(requestFBData(url));
            string ID = myProfile["id"].ToString().Replace("\"", "");
            string firstName = myProfile["first_name"].ToString().Replace("\"", "");
            string lastName = myProfile["last_name"].ToString().Replace("\"", "");
           
        
            // we have their token, their ID, and their name -- process this info here.     


    }

    public string GetAuthCodeFromResponse(HttpContext context)
    {
        string code = context.Request.QueryString["code"]; //Facebooks sends the user back to our domain with the code parameter

        string clientId = FacebookUtility.ApiKey;
        string redUrl = FacebookUtility.ReturnURL; //this needs to be the same as the redirect_uri above

        string clientSecret = FacebookUtility.SecretKey;
        string url = "https://graph.facebook.com/oauth/access_token?"; //The authorization url

        string fullUrl = url + "client_id=" + clientId + "&redirect_uri=" + redUrl + "&client_secret=" + clientSecret + "&code=" + code;
        System.Net.WebClient wc = new System.Net.WebClient();
        string result = "";
        try
        {

            result = wc.DownloadString(fullUrl);
        }
        catch (System.Net.WebException ex)
        {

            System.IO.StreamReader readStream = new System.IO.StreamReader(ex.Response.GetResponseStream());
            context.Response.Write(readStream.ReadToEnd()); //This way we can see the error message from facebook
            return null;
        }
            result = result.Replace("access_token=", "");
            string accessToken = result.Substring(0, result.IndexOf("&"));
            
            return accessToken;

 
    }
    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}