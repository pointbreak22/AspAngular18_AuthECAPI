using Microsoft.AspNetCore.Authorization;

namespace AuthECAPI.Controllers
{
    public static class AuthorizationDemoEndpoints
    {

        public static IEndpointRouteBuilder MapAuthorizationDemoEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapGet("/AdminOnly", AdminOnly);
      
            app.MapGet("/AdminOrTeacher", [Authorize(Roles = "Admin,Teacher")] () => { return "Admin or Teacher"; });

            app.MapGet("/LibraryMemberOnly", [Authorize(Policy ="HasLibraryId")] () => { return "Library members only"; });

            app.MapGet("/ApplyForMaternityLeave", [Authorize(Roles ="Teacher", Policy = "FemalesOnly")] () => { return "Applead for maternity leave."; });

            app.MapGet("/Under10AndFemale", 
               [Authorize(Policy = "Under10")]
               [Authorize(Policy = "FemalesOnly")] () => 
                { return "Under 10 and Female."; });


            return app;
        }

        [Authorize(Roles ="Admin")]
        private static string AdminOnly()
        {
            return "Admin Only";        
        }

    }
}
