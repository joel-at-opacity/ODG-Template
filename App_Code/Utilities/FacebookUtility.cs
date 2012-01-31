using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Text;
using ODG.Core;
using WebsiteModel;

/// <summary>
/// Summary description for FacebookUtility
/// </summary>
public class FacebookUtility
{
    public static string ReturnURL
    {
        get
        {
            return UrlFunctions.MakeAbsolute("/actions/facebook_processCallBack.ashx");
        }
    }


    public static string ApiKey
    {
        get
        {
            return "111111";
        }
    }

    public static string SecretKey
    {
        get
        {
            return "aaaaaa";
        }
    }

    public static string ApiURL
    {
        get
        {
            return String.Format("https://graph.facebook.com/oauth/authorize?client_id={0}&redirect_uri={1}&scope=publish_stream", FacebookUtility.ApiKey, FacebookUtility.ReturnURL);
        }
    }

    public string Token
    {

        get{

             if((HttpContext.Current.Request.Cookies["FacebookToken"] == null) || (String.IsNullOrEmpty(HttpContext.Current.Request.Cookies["FacebookToken"].Value)))
             {
                return null;
             }
            else
             {
                return HttpContext.Current.Request.Cookies["FacebookToken"].Value;
             }
        }
        set
        {
            HttpContext.Current.Response.Cookies["FacebookToken"].Value = value;
            HttpContext.Current.Request.Cookies["FacebookToken"].Expires = DateTime.Now.AddDays(1);

        }
    }

    public bool HasToken
    {
        get
        {

            return (!String.IsNullOrEmpty(this.Token));
        }
    }


    public void PostToWall(string message)
    {
        if (!HasToken)
        {
            throw new ArgumentException("Facebook Token");
        }
        else
        {
            WebClient wc = new WebClient();
            wc.Encoding = Encoding.UTF8; 
            wc.UploadString("https://graph.facebook.com/me/feed", null, "access_token=" + this.Token + "&message=" + message);
        }

    }
}