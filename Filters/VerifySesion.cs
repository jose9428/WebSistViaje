using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SisWebViaje.Models;
using SisWebViaje.Controllers;

namespace SisWebViaje.Filters
{
    public class VerifySesion : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var user = HttpContext.Current.Session["usuario"];

            if (user == null)
            {
                if (filterContext.Controller is HomeController == false)
                {
                    filterContext.HttpContext.Response.Redirect("~/Home/Index");
                }
            }
            else 
            {
                if (filterContext.Controller is HomeController == true)
                {
                    filterContext.HttpContext.Response.Redirect("~/Reporte/Index");
                }
            }

            base.OnActionExecuting(filterContext);
        }
    }
}