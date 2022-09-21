using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;

namespace Npo.Api
{
    /// <summary>
    /// ControllerConfig
    /// </summary>
    public static class ControllerConfig
    {
        /// <summary>
        /// Add Controllers to builder, setup serialization
        /// </summary>
        /// <param name="builder"></param>
        public static void AddControllers(this WebApplicationBuilder? builder)
        {
            if (builder is null)
            {
                return;
            }

            builder.Services.AddControllers()
            .AddNewtonsoftJson(setupAction =>
            {
                setupAction.SerializerSettings.ContractResolver =
                    new CamelCasePropertyNamesContractResolver();
                setupAction.SerializerSettings.SerializationBinder =
                    new DefaultSerializationBinder();
                setupAction.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            });
        }
    }
}
