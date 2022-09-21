namespace Npo.Api
{
    /// <summary>
    /// CorsConfig
    /// </summary>
    public static class CorsConfig
    {
        /// <summary>
        /// Add cors if environment is Development
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="policyName"></param>
        /// <returns></returns>
        public static void AddCors(this WebApplicationBuilder? builder, string policyName)
        {
            if (builder is null || !builder.Environment.IsDevelopment())
            {
                return;
            }

            builder.Services.AddCors(options =>
                options.AddPolicy(
                    policyName,
                    builder =>
                        builder
                            .AllowAnyOrigin()
                            .AllowAnyMethod()
                            .AllowAnyHeader()
                )
            );
        }
    }
}
