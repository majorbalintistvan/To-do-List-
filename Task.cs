using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace To_do_list
{
     public class Task: INotifyPropertyChanged
    {
        private bool _isDone;
        public string Task_text { get; set; }
        public DateTime? Date { get; set; }
        public bool IsDone { 
            get => _isDone; 
            set 
            {
                if (_isDone != value)
                {
                    _isDone = value;
                    OnPropertyChanged(nameof(IsDone));
                }
            } 
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public Task() { }
        public Task(string task, DateTime? date, bool isdone)
        {
            Task_text = task;
            Date = date;
            IsDone = isdone;
        }
    }
}
