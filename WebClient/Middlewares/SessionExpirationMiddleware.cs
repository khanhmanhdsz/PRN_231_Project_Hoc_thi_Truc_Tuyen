using WebClient.Helpers;
using WebClient.Models;

namespace WebClient.Middlewares
{
    public class SessionExpirationMiddleware
    {
        private readonly RequestDelegate _next;

        public SessionExpirationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            //Console.WriteLine("go to the session middleware");
            if (ShouldUseSessionMiddleware(context))
            {
                var area = context.GetRouteData().Values["area"] as string;
                var controller = context.GetRouteData().Values["controller"] as string;

                UserInfo userInfo = SessionHelper.GetObject<UserInfo>(context.Session, "UserInfo");

                if (userInfo == null)
                {
                    SessionHelper.Remove(context.Session, "AccessToken");
                    // Session has expired, redirect to the home screen

                    if (!String.IsNullOrEmpty(area))
                    {
                        //Console.WriteLine("redirect to signin");
                        context.Response.Redirect("/SignIn?sessionExpiration=true");
                    }
                    else
                    {
                        //Console.WriteLine("redirect to homepage");
                        context.Response.Redirect("/Home/Index");
                    }

                    return;
                }
            }

            await _next(context);
        }

        private bool ShouldUseSessionMiddleware(HttpContext context)
        {
            var area = context.GetRouteData().Values["area"] as string;

            //Console.WriteLine(context.Request.Path);
            if (context.Request.Path.StartsWithSegments(new PathString("/Home"))
                || context.Request.Path.StartsWithSegments(new PathString("/SignIn")))
            {
                return false;
            }

            if (!String.IsNullOrEmpty(area))
            {
                // Apply session check logic specific to private area
                return true;
            }

            //Console.WriteLine("True: " + context.Request.Path);
            return true;
        }
    }

}
