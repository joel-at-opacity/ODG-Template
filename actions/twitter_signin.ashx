<%@ WebHandler Language="C#" Class="signin" %>

using System;
using System.Web;

public class signin : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.Redirect(TwitterUtility.SigninUsingTwitterUrl);
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}