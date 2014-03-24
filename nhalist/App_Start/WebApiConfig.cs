using System.Web.Http;
using System.Web.Http.OData.Builder;
using NhaList.Models;

namespace NhaList
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            //var builder = new ODataConventionModelBuilder();
            //builder.EntitySet<Post>("PostBack");
            //config.Routes.MapODataRoute("odata", "odata", builder.GetEdmModel());

            config.Routes.MapHttpRoute("DefaultApi", "api/{controller}/{data}",
                new {data = RouteParameter.Optional}
                );

            // Uncomment the following line of code to enable query support for actions with an IQueryable or IQueryable<T> return type.
            // To avoid processing unexpected or malicious queries, use the validation settings on QueryableAttribute to validate incoming queries.
            // For more information, visit http://go.microsoft.com/fwlink/?LinkId=279712.
            //config.EnableQuerySupport();
        }
    }
}