using AgainMaui.Classses;
using AgainMaui.Pages;
namespace AgainMaui
{
    public partial class MainPage : ContentPage
    {
        private readonly LocalDBService _localDBService;
        public MainPage(LocalDBService localDBService)
        {
            InitializeComponent();
            _localDBService = localDBService;
        }

        private async void OnLogInClick(object sender, EventArgs e)
        {
            TasksList.tasksList = await _localDBService.GetTasks();
            Users user = new Users();
            bool userFound = false;
            //UserList.ulist = Database.GetUsers();
            UsersList.userList = await _localDBService.GetUsers();
            user.UserName = nameTxt.Text;
            user.Pass = Int32.Parse(passTxt.Text);
            foreach (Users u in UsersList.userList)
            {
                if (u.UserName == user.UserName && u.Pass == user.Pass)
                {
                    userFound = true;
                    await Navigation.PushModalAsync(new SuccessfullLoginPage(_localDBService));
                    break;
                }
            }
            if (!userFound)
            {
                await DisplayAlert("", "Login Failed", "OK!");
            }
            nameTxt.Text = string.Empty;
            passTxt.Text = string.Empty;
        }

        private async void OnSignUpClick(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new SignUpPage(_localDBService)); //on signup page
        }
    }

}
