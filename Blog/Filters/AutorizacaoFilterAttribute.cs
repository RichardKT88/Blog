using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Blog.Filters
{
    public class AutorizacaoFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string usuario = filterContext.HttpContext.Session.GetString("usuario");
            if(usuario == null) 
            {
                filterContext.Result = new RedirectToRouteResult(
                    new RouteValueDictionary(
                        new {
                            area = "",
                            controller = "Usuario",
                            action = "Login",
                        } ));
            }
            
        }
    }
}
