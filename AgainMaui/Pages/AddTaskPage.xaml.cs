namespace AgainMaui.Pages;
using AgainMaui.Classses;
public partial class AddTaskPage : ContentPage
{
    private readonly LocalDBService _localDBService;

    public AddTaskPage(LocalDBService localDBService)
    {
        InitializeComponent();
        tpCurrTime.Time = DateTime.Now.TimeOfDay;
        dpCurrDate.Date = DateTime.Now.Date;
        _localDBService = localDBService;
    }

    private async void btnAdd_Clicked(object sender, EventArgs e)
    {
        await _localDBService.CreateTask(new Tasks
        {
            Title = TitleEntry.Text,
            DueDate = dpDueDate.Date.ToString(),
            DueTime = tpDueTime.Time.ToString(),
            CreationDate = dpCurrDate.Date.ToString(),
            CreationTime = tpCurrTime.Time.ToString(),
            IsPrioritized = switchPriority.IsToggled
        });
        TasksList.tasksList = await _localDBService.GetTasks();
        await DisplayAlert("Added", "Success", "OK");
        await Navigation.PopModalAsync();
    }
}