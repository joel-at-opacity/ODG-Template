using System;
using System.Collections.Generic;
using System.Data.Objects.DataClasses;
using System.Linq;
using System.Data.Objects;
using System.Linq.Expressions;
using ODG.Core.Data.Abstract;
using System.Web.UI.WebControls;
using ODG.Core;
using WebsiteModel;

/// <summary>
/// The Repository Class inherits from EFRepository, our own internal
/// generic repository class which provides method like insert, update, delete,
/// which all repositories need to contain.
/// </summary>
/// 

public class Repository : EFRepository
{
    //Constructor
    public Repository(ApplicationDataContext context)
    {
        if (context == null)
        {
            throw new ArgumentNullException("context");
        }

        base._context = context;
    }





    ////-----------------------------------------------------------
    ////Example of an IQueryable 
    ////-----------------------------------------------------------
    //public IQueryable<Visitor> Visitors_All()
    //{
    //    return (from v in GetAll<Visitor>()
    //            select v);
    //}



    ////-----------------------------------------------------------
    ////Example of pulling a set of data from a stored procedure
    ////-----------------------------------------------------------

    //public IQueryable<StoredProcedureResultTypeGoesHere> ExampleSP()
    //{
    //    List<ObjectParameter> myParams = new List<ObjectParameter>();

    //    myParams.Add(new ObjectParameter("Param1Name", paramValue));
    //    myParams.Add(new ObjectParameter("Param2Name", paramValue));
    //    ObjectParameter[] finalParams = myParams.ToArray();

    //    var getStoredProcedureResult = this._context.ExecuteFunction<StoredProcedureResultTypeGoesHere>("NameOfStoredProcedureGoesHere", finalParams);
    //    List<StoredProcedureResultTypeGoesHere> myResultList = (from e in getStoredProcedureResult select e).ToList();
    //}





    ////-----------------------------------------------------------
    ////Example of submitting data to a stored procedure, no results
    ////-----------------------------------------------------------
    //public void ExampleSPWithNoResults()
    //{
    //    List<ObjectParameter> myParams = new List<ObjectParameter>();
    //    myParams.Add(new ObjectParameter("ExampleParameter", exampleParameterValue));
    //    myParams.Add(new ObjectParameter("ExampleParameter2", exampleParameterValue));
    //    ObjectParameter[] finalParams = myParams.ToArray();

    //    base._context.ExecuteFunction("UpdateVisitorSP", finalParams);
    //}



}


