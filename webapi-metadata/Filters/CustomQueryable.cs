using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Filters;

namespace webapi_metadata.Filters
{
    public class CustomQueryableAttribute : QueryableAttribute
    {
        protected override IQueryable ApplyResultLimit(HttpActionExecutedContext actionExecutedContext, IQueryable query)
        {
            object responseObject;
            actionExecutedContext.Response.TryGetContentValue(out responseObject);
            var originalquery = responseObject as IQueryable<object>;

            if (originalquery != null)
            {
                var originalSize = new string[] { originalquery.Count().ToString() };
                actionExecutedContext.Response.Headers.Add("originalSize", originalSize as IEnumerable<string>);
            }
            return base.ApplyResultLimit(actionExecutedContext, query);
        }
    }
}