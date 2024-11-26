namespace AgainMaui.Pages;
using AgainMaui.Classses;
using System.ComponentModel;

public partial class ViewTaskPage : ContentPage
{
    private readonly LocalDBService _localDBService;

    public ViewTaskPage(LocalDBService localDBService)
	{
        InitializeComponent();
        _localDBService = localDBService;
        TasksListView.ItemsSource = TasksList.tasksList;
    }
    private void SearchTasksViewBar_SearchButtonPressed(object sender, EventArgs e)
    {
        bool found = false;
        foreach (Tasks item in TasksList.tasksList)
        {
            if(item.Title== SearchTasksViewBar.Text)
            {
                found = true;
                DisplayAlert("Searched", $"You searched for {SearchTasksViewBar.Text}", "OK");
            }
        }
        if (!found)
        {
            DisplayAlert("Not founnd","Item not found", "OK");
        }

        }

    private async void btnBack_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopModalAsync();
    }

    private async void TasksListView_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        TasksList.tasksList = await _localDBService.GetTasks();
        var tasks = (Tasks)e.Item;
        var action = await DisplayActionSheet("Action","Cancel",null,"Edit", "Delete","View");
        switch (action)
        {
            case "View":
                await Navigation.PushModalAsync(new SingleTaskViewPage(_localDBService, tasks));
                break;
            case "Delete":
                await _localDBService.DeleteTask(tasks);
                TasksListView.ItemsSource = await _localDBService.GetTasks();
                break;
            case "Edit":
                await Navigation.PushModalAsync(new SingleTaskViewPage(_localDBService, tasks));
                entEdit.Text = tasks.Title;
                //await Navigation.PushModalAsync(new EditPageAdd(_localDBService, tasks));
                //await Navigation.PushModalAsync(new EditTaskPage(_localDBService,tasks));
                //TasksListView.ItemsSource = await _localDBService.GetTasks();
                break;


        }

    }

    private async void btnEdit_Clicked(object sender, EventArgs e)
    {
        //await Navigation.PushModalAsync(new SingleTaskViewPage(_localDBService, tasks));
        await _localDBService.UpdateTask(new Tasks
        {
            Title = entEdit.Text
        });
        TasksListView.ItemsSource = await _localDBService.GetTasks();
    }
}