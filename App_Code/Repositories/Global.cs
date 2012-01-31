using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ODG.Core.Data.Abstract;

/// <summary>
/// Summary description for Test
/// </summary>
public class Global
{
    public static Repository Repository
    {
        get
        {
            return new Repository(ContextManager.Create<ApplicationDataContext>());
        }
    }
}