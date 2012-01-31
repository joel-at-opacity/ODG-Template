using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Objects;
using System.Configuration;
using System.Collections;
using ODG.Core.Data.Abstract;

/// <summary>
/// Summary description for ContextManager
/// </summary>
public static class ContextManager 
{
    private const string ObjectContextKey = "CTX-ObjectContext";

    public static T Create<T>() where T : ApplicationDataContext, new()
    {

        HttpContext httpContext = HttpContext.Current;

        if (httpContext != null)
        {
            
            string contextTypeKey = ObjectContextKey + typeof(T).Name;

            if (httpContext.Items[contextTypeKey] == null)
            {

                httpContext.Items.Add(contextTypeKey, new T());
                

            }

            return httpContext.Items[contextTypeKey] as T;

        }

        throw new ApplicationException("There is no Http Context available");

    }

    public static void Dispose()
    {
        //dispose of contexts
        HttpContext context = HttpContext.Current;
        ApplicationDataContext ctx;

        foreach (DictionaryEntry item in context.Items)
        {
            if ((item.Key.ToString() ?? string.Empty).StartsWith("CTX-"))
            {
                ctx = item.Value as ApplicationDataContext;
                if (ctx != null)
                {
                    ctx.Dispose();
                }
            }
        }
    }

  
}
