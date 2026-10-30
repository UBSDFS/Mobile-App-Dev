
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Text;

namespace PerformanceAPI.Controllers;

public class BasicAuthentication : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        string header = context.HttpContext.Request.Headers.Authorization.ToString();

        if (!header.StartsWith("Basic ", StringComparison.OrdinalIgnoreCase))
        {
            context.Result = new UnauthorizedResult();
            return;
        }

        try
        {
            string token = header.Substring(6);
            string credentials = Encoding.UTF8.GetString(
                Convert.FromBase64String(token));

            if (credentials != "Burden01:Password1")
            {
                context.Result = new UnauthorizedResult();
            }
        }
        catch (FormatException)
        {
            context.Result = new UnauthorizedResult();
        }
    }
}
