using FeatureToggle.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace FeatureToggle.AppSettings
{
    public static class FeatureExtensions
    {
        public static void AddFeatureToggle(this IServiceCollection services)
        {
            services.AddSingleton(typeof(IFeature), typeof(Feature));
        }
    }
}
