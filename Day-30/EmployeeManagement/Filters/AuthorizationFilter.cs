using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace EmployeeManagement.Filters
{
    public class AuthorizationFilter : IAuthorizationFilter
    {

        private readonly string _role;

        public AuthorizationFilter(string role)
        {
            _role = role;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var roleFromHeader = context.HttpContext.Request.Headers["Role"].ToString();
            if (string.IsNullOrEmpty(roleFromHeader) || roleFromHeader != _role)
            {
                context.Result = new ContentResult()
                {
                    Content = "Access Denied only manager can view it..",
                    StatusCode = 403 //forbidden
                };
            }
        }

    }
    
    public class AuthorizeRoleAttribute : TypeFilterAttribute
    {
        public AuthorizeRoleAttribute(string role) : base(typeof(AuthorizationFilter))
        {
            Arguments = new object[] { role };
        }
    }
}
