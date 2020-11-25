using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Text.Json;

namespace DodoPlanner.Models
{
    public class task
    {
        public string title { get; set; }
        public DateTime duedate { get; set; }
        public Boolean completed { get; set; }
        public Guid TaskID { get; set; }
        public task()
        {
            title = "new task";
            completed = false;
            TaskID = Guid.NewGuid();
            duedate = DateTime.Now;
        }
    }
}
