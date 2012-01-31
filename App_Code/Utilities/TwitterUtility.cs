using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Text;
using ODG.Core;
using Hammock;
using Hammock.Authentication.OAuth;
using WebsiteModel;

/// <summary>
/// Summary description for FacebookUtility
/// </summary>
public class TwitterUtility
{


    public TwitterUtility(string Token,string TokenSecret)
    {
        this.AccessToken = Token;
        this.AccessTokenSecret = TokenSecret;
    }

    public string AccessToken { get; set; }
    public string AccessTokenSecret { get; set; }

    public static string ApiKey
    {
        get
        {
            return "11111";
        }
    }

    public static string ConsumerKey
    {
        get
        {
            return "aaaa";
        }
    }


    public static string ConsumerSecret
    {
        get
        {
            return "aaaa";
        }
    }
    public static string SigninUsingTwitterUrl
    {
        get
        {
            string callbackUrl = UrlFunctions.MakeAbsolute("/actions/twitter_processcallback.ashx");

            var credentials = new OAuthCredentials
            {
                Type = OAuthType.RequestToken,
                SignatureMethod = OAuthSignatureMethod.HmacSha1,
                ParameterHandling = OAuthParameterHandling.HttpAuthorizationHeader,
                ConsumerKey = TwitterUtility.ConsumerKey,
                ConsumerSecret = TwitterUtility.ConsumerSecret,
                CallbackUrl = callbackUrl
            };

            var client = new RestClient
            {
                Authority = "http://twitter.com/oauth",
                Credentials = credentials
            };

            var request = new RestRequest
            {
                Path = "/request_token"
            };

            RestResponse response = client.Request(request);

            var collection = HttpUtility.ParseQueryString(response.Content);
            CookieUtility.SetCookie("requestSecret", collection[1],DateTime.Now.AddMinutes(5));

            return "http://twitter.com/oauth/authorize?oauth_token=" + collection[0];




        }
    }






    public void PostToFeed(string message)
    {
            //OAuthTokens currentToken = new OAuthTokens();
            //currentToken.AccessToken = this.AccessToken;
            //currentToken.AccessTokenSecret = this.AccessTokenSecret;
            //currentToken.ConsumerKey = TwitterUtility.ConsumerKey;
            //currentToken.ConsumerSecret = TwitterUtility.ConsumerSecret;

            //TwitterResponse<TwitterStatus> tweetResponse = TwitterStatus.Update(currentToken, message);
            //if (tweetResponse.Result == RequestResult.Success)
            //{
            //    //lblMessage.Text = "Twitter status successfully posted.";
            //}
            //else
            //{
            //   // lblMessage.Text = string.Format("Twitter status update failed with Error: '{0}'", tweetResponse.ErrorMessage);
            //}


    }


}