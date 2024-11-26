using Microsoft.VisualBasic;
using AgainMaui.Classses;
namespace AgainMaui.Pages;

public partial class EditTaskPage : ContentPage
{
    private readonly LocalDBService _localDBService;
    public Tasks task;
    public EditTaskPage(LocalDBService localDBService,Tasks t)
	{
		InitializeComponent();
        task = t;
        TitleEntry.Text = task.Title;
        _localDBService = localDBService;
    }
    /*private async void btnAdd_Clicked(object sender, EventArgs e)
    {
        *//*await _localDBService.CreateTask(new Tasks
        {
            Title = TitleEntry.Text,
            DueDate = dpDueDate.Date.ToString(),
            DueTime = tpDueTime.Time.ToString(),
            CreationDate = dpCurrDate.Date.ToString(),
            CreationTime = tpCurrTime.Time.ToString(),
            IsPrioritized = switchPriority.IsToggled
        });
        await DisplayAlert("Added", "Success", "OK");
        await Navigation.PopModalAsync();*//*
    }*/

    private async void btnUpdate_Clicked(object sender, EventArgs e)
    {
        task.Title = TitleEntry.Text;
        await _localDBService.UpdateTask(task);
        /* await _localDBService.UpdateTask(new Tasks
         {

             //Title = TitleEntry.Text
         });*/
        //TasksList.tasksList = await _localDBService.GetTasks();
        await Navigation.PopModalAsync();
    }
}