
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Text;

namespace BasicAuthWS.Controllers
{
    public class BasicAuthentication : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            // Check for Authorization header
            var authHeader = context.HttpContext.Request.Headers.Authorization.ToString();

            if (string.IsNullOrEmpty(authHeader))
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            // Expected format: Basic <base64-credentials>
            var authHeaderParts = authHeader.Split(' ');

            if (authHeaderParts.Length != 2 || authHeaderParts[0] != "Basic")
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            // Decode credentials
            string credentials;

            try
            {
                credentials = Encoding.UTF8.GetString(
                    Convert.FromBase64String(authHeaderParts[1]));
            }
            catch (FormatException)
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            // Expected format: username:password
            var parts = credentials.Split(':');

            if (parts.Length != 2 ||
                !string.Equals(parts[0], "instructor01", StringComparison.OrdinalIgnoreCase) ||
                parts[1] != "Password01")
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            // Credentials valid; continue to controller
            base.OnActionExecuting(context);
        }
    }
}
