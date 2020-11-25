using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DodoPlanner.Models
{
    public class ToDoList
    {
        public string Title { get; set; }
        public List<task> tasks;
        public ToDoList()
        {
            Title = "new list";
            tasks = new List<task>();
        }
    }
}
