using FeatureToggle.Interface;
using Microsoft.Extensions.Configuration;
using System;

namespace FeatureToggle.AppSettings
{
    public class Feature : IFeature
    {
        private readonly IConfiguration _configuration;

        public Feature(IConfiguration configuration)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        public bool IsFeatureEnabled(string feature)
        {
            if (string.IsNullOrWhiteSpace(feature)) throw new ArgumentException("Please provide feature name", nameof(feature));

            var featureValue = _configuration[$"Features:{feature}"];

            if (string.IsNullOrWhiteSpace(featureValue))
            {
                throw new FeatureNotFoundException(feature);
            }

            return bool.Parse(featureValue);
        }
    }
}
