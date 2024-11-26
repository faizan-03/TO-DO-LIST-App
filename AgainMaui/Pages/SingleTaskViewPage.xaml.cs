using AgainMaui.ViewModel;
namespace AgainMaui.Pages;
using AgainMaui.Classses;
using Microsoft.VisualBasic;

public partial class SingleTaskViewPage : ContentPage
{
    private readonly LocalDBService _localDBService;
    public SingleTaskViewPage(LocalDBService localDBService,Tasks t)
	{
		InitializeComponent();
		_localDBService = localDBService;
		Tasks task = t;
		var taskDetailViewModel = new TasksDetailViewModel
		{
			Title = task.Title,
			CreationDate = task.CreationDate,
			CreationTime = task.CreationTime,
			DueDate = task.DueDate,
			DueTime = task.DueTime,
			IsPrioritized = task.IsPrioritized
		};
		BindingContext = taskDetailViewModel;
	}
}