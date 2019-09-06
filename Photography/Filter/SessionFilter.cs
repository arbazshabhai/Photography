using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Photography.Filter
{
    public class SessionFilter
    {
        public static string UserName
        {
            get
            {
                if (HttpContext.Current.Session["UserName"] != null)
                {
                    return HttpContext.Current.Session["UserName"].ToString();
                }
                else
                {
                    return null;
                }
            }
            set
            {
                HttpContext.Current.Session["UserName"] = value;
            }
        }
        public class AuthorizationPrivilegeFilter : ActionFilterAttribute
        {
            public override void OnActionExecuting(ActionExecutingContext filterContext)
            {
                if (SessionFilter.UserName == null)
                {
                    filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary { { "controller", "Login" }, { "action", "LogOut" } });
                }
                else
                {
                    base.OnActionExecuting(filterContext);
                }
            }
        }

    }
}