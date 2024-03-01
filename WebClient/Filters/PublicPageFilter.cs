using WebClient.Helpers;
using WebClient.Models;
using Core.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebClient.Filters
{
    public class PublicPageFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {

            //Console.WriteLine("run here");
            ISession session = context.HttpContext.Session;

            UserInfo userInfo = SessionHelper.GetObject<UserInfo>(session, "UserInfo");
            if (userInfo != null)
            {
                if (userInfo.RoleNumber != (int)Role.Student)
                {
                    context.Result = new RedirectToActionResult("Error403", "Error", null);
                }
            }
            base.OnActionExecuting(context);
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
        }
    }
}
