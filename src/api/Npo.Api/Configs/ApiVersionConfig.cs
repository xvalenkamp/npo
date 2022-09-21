using Microsoft.AspNetCore.Mvc;

namespace Npo.Api
{
    /// <summary>
    /// ApiVersionConfig
    /// </summary>
    public static class ApiVersionConfig
    {
        /// <summary>
        /// Add versioning to builder services
        /// </summary>
        /// <param name="builder"></param>
        public static void AddVersioning(this WebApplicationBuilder? builder)
        {
            if (builder is null)
            {
                return;
            }

            builder.Services.AddApiVersioning(setup =>
            {
                setup.DefaultApiVersion = new ApiVersion(1, 0);
                setup.AssumeDefaultVersionWhenUnspecified = true;
                setup.ReportApiVersions = true;
            });

            builder.Services.AddVersionedApiExplorer(setup =>
            {
                setup.GroupNameFormat = "'v'VVV";
                setup.SubstituteApiVersionInUrl = true;
            });
        }
    }
}
