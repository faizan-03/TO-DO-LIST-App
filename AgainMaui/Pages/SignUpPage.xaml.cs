namespace AgainMaui.Pages;
using AgainMaui.Classses;
public partial class SignUpPage : ContentPage
{
    private readonly LocalDBService _localDBService;
	public SignUpPage(LocalDBService localDBService)
	{
		InitializeComponent();
        _localDBService = localDBService;
	}
    private async void btnSignUp_Clicked(object sender, EventArgs e)
    {
        await _localDBService.Create(new Users
        {
            UserName = nameTxt.Text,
            Pass = Int32.Parse(passTxt.Text)
        });
        nameTxt.Text = string.Empty;
        passTxt.Text = string.Empty;
        await DisplayAlert("Success", "User signed up successfully!", "OK");

        await Navigation.PopModalAsync();
    }
}