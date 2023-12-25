using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using System.Reflection;
namespace FileEx.Client;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
			});

		var config = new ConfigurationBuilder()
						.GetConfigurationFile("appsettings.json")
						.Build();

		builder.Services.Configure<Settings>(config.GetRequiredSection(nameof(Settings)));

		builder.Services.AddSingleton<IFileService, FileService>();

		builder.Services.AddMauiBlazorWebView();
		builder.Services.AddHttpClient();
		
		

#if DEBUG
		builder.Services.AddBlazorWebViewDeveloperTools();
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}

	public static IConfigurationBuilder GetConfigurationFile(this IConfigurationBuilder builder, string fileName)
	{
		if(OperatingSystem.IsMacCatalyst() || OperatingSystem.IsIOS())
		{
			var a = Assembly.GetExecutingAssembly();
			var resourceName = a.GetManifestResourceNames()
				.Single(name => name.EndsWith(fileName));
			
			var stream = a.GetManifestResourceStream(resourceName) ?? 
				throw new NullReferenceException($"Loading {fileName} failed");
			
			
            builder.AddJsonStream(stream);
		}
		else
		{
			builder.AddJsonFile(fileName);
		}

		return builder;
	}
}
