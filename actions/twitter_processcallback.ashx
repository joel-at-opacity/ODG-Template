<%@ WebHandler Language="C#" Class="processcallback" %>

using System;
using System.Web;
using System.Net;
using System.IO;
using Newtonsoft.Json.Linq;
using Newtonsoft;
using Newtonsoft.Json;
using WebsiteModel;
using System.Linq;
using System.Web.Security;
using ODG.Core;
using Hammock;
using Hammock.Authentication.OAuth;

public class processcallback : IHttpHandler
{




    //THIS PAGE IS CALLED WHEN TWITTER RETURNS AN ANSWER REGARDING REQUESTING APPROVAL
    public void ProcessRequest(HttpContext context)
    {


        string token = context.Request.QueryString["oauth_token"];
        string verifier = context.Request.QueryString["oauth_verifier"];


        var acredentials = new OAuthCredentials
        {

            Type = OAuthType.AccessToken,
            SignatureMethod = OAuthSignatureMethod.HmacSha1,
            ParameterHandling = OAuthParameterHandling.HttpAuthorizationHeader,
            ConsumerKey = TwitterUtility.ConsumerKey,
            ConsumerSecret = TwitterUtility.ConsumerSecret,
            Verifier = verifier.ToString(),
            Token = token,
            TokenSecret = CookieUtility.GetCookieValue("requestSecret")

        };



        // WE HAVE CREDENTIALS, ASK TWITTER FOR ACCESS TOKEN
        var aclient = new RestClient
        {
            Authority = "http://twitter.com/oauth",
            Credentials = acredentials
        };

        var arequest = new RestRequest
        {
            Path = "/access_token"
        };

        RestResponse aresponse = aclient.Request(arequest);

        System.Collections.Specialized.NameValueCollection userBasicsCollection = HttpUtility.ParseQueryString(aresponse.Content);


        string accessToken = userBasicsCollection["oauth_token"];
        string accessSecret = userBasicsCollection["oauth_token_secret"];
        string userName = userBasicsCollection["screen_name"];



        // CODE TO ASK TWITTER FOR SOMETHING
        var nameCredentials = new OAuthCredentials
        {

            Type = OAuthType.AccessToken,
            SignatureMethod = OAuthSignatureMethod.HmacSha1,
            ParameterHandling = OAuthParameterHandling.HttpAuthorizationHeader,
            ConsumerKey = TwitterUtility.ConsumerKey,
            ConsumerSecret = TwitterUtility.ConsumerSecret,
            Token = accessToken,
            TokenSecret = accessSecret


        };

        //ASK FOR USER INFORMATION (NAME)
        var nameClient = new RestClient
        {
            Authority = "http://api.twitter.com",
            VersionPath = "1",
            Credentials = nameCredentials
        };

        var nameRequest = new RestRequest
        {
            Path = String.Format("users/show.json?screen_name={0}", userName)
        };

        RestResponse nameResponse = nameClient.Request(nameRequest);

        JObject o = JObject.Parse(nameResponse.Content);
        string fullName = (string)o.SelectToken("name");



        string TwitterID = accessToken.Split('-')[0];




    }







    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}