namespace AgainMaui.Pages;
using AgainMaui.Classses;
public partial class SuccessfullLoginPage : ContentPage
{
    private readonly LocalDBService _localDBService;

    public SuccessfullLoginPage(LocalDBService localDBService)
	{
		InitializeComponent();
        _localDBService = localDBService;
	}
    private async void btnAddTask_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new AddTaskPage(_localDBService));
    }

    private async void btnViewTasks_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new ViewTaskPage(_localDBService));
    }

    private void FacebookSwipeItem_Invoked(object sender, EventArgs e)
    {
        DisplayAlert("Facebook", "Awais Yousaf", "OK");
    }

    private void InstaSwipeItem_Invoked(object sender, EventArgs e)
    {
        DisplayAlert("Instagram", "75_Awais", "OK");
    }

    private async  void btnViewUsers_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new ViewUsersPage());
    }
}