using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace To_do_list
{
     public class Task
    {
        public string Task_text { get; set; }
        public DateTime? Date { get; set; }
        public bool IsDone { get; set; }
        public Task() { }
        public Task(string task, DateTime? date, bool isdone)
        {
            Task_text = task;
            Date = date;
            IsDone = isdone;
        }
    }
}
