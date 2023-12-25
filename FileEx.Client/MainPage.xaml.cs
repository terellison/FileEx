namespace FileEx.Client;

public partial class MainPage : ContentPage
{
    private readonly IFileService fileService;

    public MainPage(IFileService fileService)
	{
		InitializeComponent();
        this.fileService = fileService;
    }

    private async void Test_Clicked(object sender, EventArgs e)
    {
        var result = await fileService.HealthCheck();
    }
}
