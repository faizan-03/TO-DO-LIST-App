using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgainMaui.ViewModel
{
    class TasksDetailViewModel:INotifyPropertyChanged
    {
        private string title;
        public string Title
        {
            get { return title; }
            set
            {
                title = value;
                NotifyPropertyChanged(nameof(Title));
            }
        }

        public string DueDate { get; set; }
        public string DueTime { get; set; }

        public string CreationDate { get; set; }
        public string CreationTime { get; set; }
        public bool IsPrioritized { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
