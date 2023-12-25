using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
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
		#if DEBUG
						.AddJsonFile("appsettings.json")
		#else
						.AddJsonFile(Path.Combine(FileSystem.AppDataDirectory, "appsettings.json"))
		#endif
						.Build();

		builder.Configuration.AddConfiguration(config);

		builder.Services.AddSingleton<IFileService, FileService>();

		builder.Services.AddMauiBlazorWebView();
		builder.Services.AddHttpClient();
		
		

#if DEBUG
		builder.Services.AddBlazorWebViewDeveloperTools();
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
