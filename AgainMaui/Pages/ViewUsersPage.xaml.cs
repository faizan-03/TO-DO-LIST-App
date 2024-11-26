using AgainMaui.Classses;
namespace AgainMaui.Pages;

public partial class ViewUsersPage : ContentPage
{
	public ViewUsersPage()
	{
		InitializeComponent();

		UsersListView.ItemsSource = UsersList.userList;
	}
}