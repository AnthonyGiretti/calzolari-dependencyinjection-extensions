# calzolari-dependencyinjection-extensions
Extensions for ASP.NET Core dependency injection

```csharp
public void ConfigureServices(IServiceCollection services)
{

	services.Unregister<MyService>(); // Unregister service from concrete Implementation
	
	services.Unregister<IMyService>(); // Unregister service from its Interface

	services.Replace<IMyService, MyService>(ServiceLifetime.Scoped); // Replace a service with a new implementation for a specified scope

	services.ReplaceTransient<IMyService, MyService>(); // Replace a service with a new implementation with Transient scope

	services.ReplaceScoped<IMyService, MyService>(); // Replace a service with a new implementation with Scoped scope

	services.ReplaceSingleton<IMyService, MyService>(); // Replace a service with a new implementation with Singleton scope

	services.RegisterOptions<MyOptions>(Configuration); // Register options as Singleton (MyOptions), Appsettings section name must match MyOptions name

	services.RegisterOptions<MyOptions>(Configuration, "SectionName");// Register options as Singleton (MyOptions) from a given Section  name in Appsettings
}
```