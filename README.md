# FeatureToggle.AppSettings

FeatureToggle.AppSettings is a simple way of introducing the feature-toggling into your application.

# Quick start guide

## Installing the package

### nuget command

    Install-Package FeatureToggle.AppSettings -Version 1.0.2

###  .net cli

    dotnet add package FeatureToggle.AppSettings --version 1.0.2
    
### packet cli

    paket add FeatureToggle.AppSettings --version 1.0.2

## Implementation

 1, Register the settings with **startup.cs** file

           // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddFeatureToggle();
            services.AddMvc();
            /// Your outher code...
        }

2, Add features into your *appsettings.json*file

    {
      /*your other configuration*/,
      "Features": {
        "console-output": "false"
      }
    }

3, Code to access the configuration


    using FeatureToggle.Interface;
    
    namespace SampleApp
    {
        public class UserSettings
        {
	        public UserSettings(IFeature feature)
            {
                if (Feature.IsFeatureEnabled("console-output"))
                {
                    Console.WriteLine($"{DateTime.UtcNow.ToString("yyyy MM dd")} requested");
                }
            }
       }
    }




# Dependencies
The package depends on [FeatureToggle.Interface](https://www.nuget.org/packages/FeatureToggle.Interface/)  nuget package, in order to provide the ability to override the implementation for implement your own, if this solution is not the right fit.

The source repository for this package is [github FeatureToggle.Interface ](https://github.com/cpoDesign/FeatureToggle.Interface)

