using WebClient;
using WebClient.Filters;
using WebClient.Helpers;
using WebClient.Middlewares;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Caching.Memory;
using System;

namespace WebClient.Filters
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class RequestRateFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            try
            {
                ISession session = context.HttpContext.Session;
                var requestInfo = SessionHelper.GetObject<RequestInfo>(session, "RequestInfo") ?? new RequestInfo();

                TimeSpan timeCount = DateTime.UtcNow - requestInfo.StartRequestTime;

                // Check if the the request restriction time has expired
                if (timeCount > TimeSpan.FromMinutes(1))
                {
                    // Reset the request time if expired
                    requestInfo = new RequestInfo();
                    requestInfo.StartRequestTime = DateTime.UtcNow;
                }

                // Update the request count and timestamp
                requestInfo.RequestCount++;
                TimeSpan timeLeft = TimeSpan.FromMinutes(1) - timeCount;
                requestInfo.TimeLeft = timeLeft.TotalSeconds;
                requestInfo.CurrentUrl = context.HttpContext.Request.GetEncodedUrl();

                SessionHelper.SetObject<RequestInfo>(session, "RequestInfo", requestInfo);

                if (requestInfo.RequestCount > 20)
                {
                    // Too many requests, throw a custom exception indicating rate limit exceeded
                    context.Result = new RedirectToActionResult("Error429", "Error", null);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {

                base.OnActionExecuting(context);
            }
        }
    }
}

public class RequestInfo
{
    public int RequestCount { get; set; } = 1;
    public DateTime StartRequestTime { get; set; } = DateTime.UtcNow;
    public double TimeLeft { get; set; } = 0f;
    public string CurrentUrl { get; set; }
}
