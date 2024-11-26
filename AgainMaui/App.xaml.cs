
using AgainMaui.Pages;
namespace AgainMaui
{
    public partial class App : Application
    {
        public App(MainPage mainpage)
        {
            InitializeComponent();
            MainPage = mainpage;
            //MainPage = new SingleTaskViewPage();
            //MainPage = new LoginPage();
            //MainPage = new ViewUsersPage();
            //MainPage = new SuccessfullLoginPage();
            //MainPage = new AddTaskPage();
            //MainPage = new LoginPage(); 
           //MainPage = new AppShell();
        }
    }
}
