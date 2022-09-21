using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Reflection;

namespace Npo.Api
{
    /// <summary>
    /// SwaggerConfig
    /// </summary>
    public static class SwaggerConfig
    {
        /// <summary>
        /// Add swagger configuration to builder services
        /// </summary>
        /// <param name="builder"></param>
        public static void AddSwagger(this WebApplicationBuilder? builder)
        {
            if (builder is null)
            {
                return;
            }

            builder.Services.AddSwaggerGen(SwaggerServiceOptions());
        }

        /// <summary>
        /// Create swaggerGenOptions
        /// </summary>
        /// <returns></returns>
        public static Action<SwaggerGenOptions> SwaggerServiceOptions()
        {

            return c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "NPO V1",
                    Description = "NPO Everybody Codes V1",
                });
                c.SwaggerDoc("v2", new OpenApiInfo
                {
                    Version = "v2",
                    Title = "NPO Everybody Codes V2",
                    Description = "NPO Everybody Codes V2",
                });
                c.EnableAnnotations();

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
                c.AddSecurityDefinition("jwt_auth", new OpenApiSecurityScheme()
                {
                    Name = "Bearer",
                    BearerFormat = "JWT",
                    Scheme = "bearer",
                    Description = "Specify the authorization token.",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                    {
                        {
                            new OpenApiSecurityScheme()
                            {
                                Reference = new OpenApiReference()
                                {
                                    Id = "jwt_auth",
                                    Type = ReferenceType.SecurityScheme
                                }
                            }, new string[] { }
                        }
                    });
            };
        }

        /// <summary>
        /// Configure Swagger UI Options
        /// </summary>
        /// <returns></returns>
        public static Action<Swashbuckle.AspNetCore.SwaggerUI.SwaggerUIOptions> SwaggerUIOptions()
        {
            return c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "NPO Everybody Codes V1");
                c.SwaggerEndpoint("/swagger/v2/swagger.json", "NPO Everybody Codes V2");
            };
        }
    }
}
