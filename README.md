# Dependency Injection Extensions 

The project helps simplify working with dependency injection in ASP.NET Core.

## Install package

You can install `Calzolari.DependencyInjection.Extensions` from NuGet. You can install it from the NuGet Package Manager UI in Visual Studio or by running one of the following commands.

### .NET CLI

```bash
dotnet add package Calzolari.DependencyInjection.Extensions
```

### Package Manager

```bash
Install-Package Calzolari.DependencyInjection.Extensions
```

## Usage

Use the service extensions in your `Startup.cs`'s `ConfigureServices` method, as you do with your other services. 

The [supported extensions](https://github.com/AnthonyGiretti/calzolari-dependencyinjection-extensions/blob/main/Calzolari.DependencyInjection.Extensions/IServiceCollectionExtensions.cs) are below.

### Unregister

Use this to unregister services from its concrete implementation or its interface.

```csharp
public void ConfigureServices(IServiceCollection services)
{
	services.Unregister<MyService>();
	services.Unregister<IMyService>();
}
```

### Replace

Use `Replace` to replace a service with a new implementation for a specified scope.

```csharp
public void ConfigureServices(IServiceCollection services)
{
	services.Replace<IMyService, MyService>(ServiceLifetime.Scoped);
}
```

### ReplaceTransient

Use `ReplaceTransient` to replace a service with a new implementation with a transient scope.

```csharp
public void ConfigureServices(IServiceCollection services)
{
	services.ReplaceTransient<IMyService, MyService>();
}
```

### ReplaceScoped

Use `ReplaceScoped` to replace a service with a new implementation with a scope of `Scoped`.

```csharp
public void ConfigureServices(IServiceCollection services)
{
	services.ReplaceScoped<IMyService, MyService>();
}
```

### ReplaceSingleton

Use `ReplaceSingleton` to replace a service with a new implementation with a scope of `Singleton`.

```csharp
public void ConfigureServices(IServiceCollection services)
{
	services.ReplaceSingleton<IMyService, MyService>();
}
```

### RegisterOptions

Use `RegisterOptions` to either register options as a `MyOptions` singleton (the `appsettings.json` section name must match the `MyOptions` name), or register options as a `MyOptions` singleton from a given `appsettings.json` section name.

```csharp
public void ConfigureServices(IServiceCollection services)
{
	services.RegisterOptions<MyOptions>(Configuration);
	services.RegisterOptions<MyOptions>(Configuration, "SectionName");
}
```