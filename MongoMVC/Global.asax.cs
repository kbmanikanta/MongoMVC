using MongoDB.Bson;
using MongoMVC.Models;
using System.Web.Mvc;
using System.Web.Routing;

namespace MongoMVC
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            ModelBinders.Binders.Add(typeof(ObjectId), new ObjectIdBinder());
        }
    }
}
