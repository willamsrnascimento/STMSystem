using Microsoft.AspNetCore.Diagnostics;
using Microsoft.Data.SqlClient;

namespace STMApi.Errors
{
    public static class ErrorsConfigure
    {
        public static void UseErrorsConfigure(this WebApplication app)
        {
            app.UseExceptionHandler("/error");
            app.Map("/error", (HttpContext http) =>
            {
                var error = http.Features?.Get<IExceptionHandlerFeature>()?.Error;

                if (error != null)
                {
                    if (error is SqlException)
                        return Results.Problem(title: "Database out", statusCode: 500);
                    else if (error is BadHttpRequestException)
                        return Results.Problem(title: "Error to convert data to other type. See all the information sent", statusCode: 500);
                }

                return Results.Problem(title: "An error ocurred", statusCode: 500);
            });

        }
    }
}
