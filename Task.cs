using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace To_do_list
{
    class Task
    {
        public string Task_text { get; set; }
        public DateTime Date { get; set; }
        public bool IsCompleted { get; set; }
        public Task() { }
        public Task(string task, DateTime date, bool isCompleted)
        {
            Task_text = task;
            Date = date;
            IsCompleted = isCompleted;
        }
    }
}
