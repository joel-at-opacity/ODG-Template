<%@ Application Language="C#" %>
<%@ Import Namespace="System.Web.Routing" %>
<%@ Import Namespace="ODG.Core" %>
<script RunAt="server">

  
    protected void Application_AuthenticateRequest(object sender, EventArgs e)
    {

        //Needed for forms authentication with roles
        if (HttpContext.Current.User != null)
        {
            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
               if (HttpContext.Current.User.Identity is FormsIdentity)
                {
                    FormsIdentity identity = (FormsIdentity)HttpContext.Current.User.Identity;
                    FormsAuthenticationTicket ticket = identity.Ticket;
                    string[] roles = ticket.UserData.Split(',');
                    HttpContext.Current.User = new System.Security.Principal.GenericPrincipal(identity, roles);
                }
            }
        }
    } 
    
    
    void Application_Start(object sender, EventArgs e)
    {
       
        RegisterRoutes(RouteTable.Routes);

        try
        {
            string[] filePaths = System.IO.Directory.GetFiles(HttpContext.Current.Server.MapPath("/uploads/temp"));
            foreach (string filePath in filePaths)
                System.IO.File.Delete(filePath);
        }
        catch
        {
        }




    }

    void Application_End(object sender, EventArgs e)
    {
       

    }

    void Application_Error(object sender, EventArgs e)
    {
      

    }

    protected void Application_EndRequest(object sender, EventArgs e)
    {
        //REQUIRED for our repository system.
        ContextManager.Dispose();
    }

    protected void Application_StartRequest(object sender, EventArgs e)
    {
        Session_Start(sender, e);
        
    }

    void Session_Start(object sender, EventArgs e)
    {

    }

    void Session_End(object sender, EventArgs e)
    {

    }

    private void RegisterRoutes(RouteCollection routes)
    {

        routes.Ignore("{pagename}.aspx");
        routes.Ignore("{pagename}.svc");
        routes.Ignore("{pagename}.pdf");
        routes.Ignore("{pagename}.xml");
        routes.Ignore("{pagename}.sitemap");
        routes.Ignore("{pagename}.config");
        routes.Ignore("favicon.ico");
        routes.Ignore("{resource}.axd");
        routes.Ignore("{resource}.axd/{*pathInfo}");



        //        routes.MapPageRoute(
        //"exampleRoute",
        //"example/{ID}",
        //"~/example.aspx"
        //);



    }

      
</script>
