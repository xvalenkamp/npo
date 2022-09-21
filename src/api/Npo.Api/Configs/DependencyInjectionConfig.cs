namespace Npo.Api
{
    /// <summary>
    /// DependencyInjectionConfig
    /// </summary>
    public static class DependencyInjectionConfig
    {
        /// <summary>
        /// Add Dependency Injection
        /// </summary>
        /// <param name="builder"></param>
        public static void AddDependencyInjection(this WebApplicationBuilder? builder)
        {
            if (builder is null)
            {
                return;
            }

            // v1 Services
            builder.Services.AddScoped<Services.v1.ICameraService, Services.v1.CameraService>();

            // v1 Repositories
            builder.Services.AddScoped< Data.Repositories.v1.ICameraRepository, Data.Repositories.v1.CameraRepository>();
        }
    }
}
