namespace FileEx.Client;

public partial class App : Application
{
	public App(IFileService fileService)
	{
		InitializeComponent();

		MainPage = new MainPage(fileService);
	}
}
