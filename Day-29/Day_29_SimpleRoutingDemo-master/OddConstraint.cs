using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Http;
// This class contains constraints for odd numbers
public class OddConstraint : IRouteConstraint
{
   public bool Match(HttpContext httpContext, IRouter route, string routeKey, RouteValueDictionary values, RouteDirection routeDirection)
   {
       if (httpContext == null || route == null || values == null)
       {
           throw new ArgumentNullException(nameof(httpContext));
       }
       
        // By using TryParse we can avoid the need for explicit type checking
       if (int.TryParse(values[routeKey]?.ToString(), out int number))
       {
           return number % 2 != 0;
       }
       return false;
   }
}