using DodoPlanner.Models;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace DodoPlanner.Services
{
    public class JsonFileTdListService
    {
        public JsonFileTdListService(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }

        public IWebHostEnvironment WebHostEnvironment { get; }

        private string JsonFileName
        {
            get { return Path.Combine(WebHostEnvironment.WebRootPath, "data", "tdlists.json"); }
        }

        public void ToggleCompleted(Guid ListId, string TaskName)
        {
            var tdlist = GetList(ListId);
            var task = tdlist.tasks[tdlist.tasks.FindIndex(x => x.title == TaskName)];
            task.completed = !task.completed;
            writeJson(tdlist);
        }

        public IEnumerable<ToDoList> GetTdLists()
        {
            var tdlists = new List<ToDoList>();
            using (StreamReader file = new StreamReader(JsonFileName))
            {
                JsonSerializer serializer = new JsonSerializer();
                tdlists = (List<ToDoList>)serializer.Deserialize(file, typeof(IEnumerable<ToDoList>));
                
            }
            return tdlists;
        }
        

        public void AddTdList(string title)
        {
            var tdlists = GetTdLists().ToList();
            tdlists.Add(new ToDoList { Title = title });
            writeJson(tdlists);
        }
        public void RemoveTdList(Guid ListId)
        {
            var tdlists = GetTdLists().ToList();
            tdlists.Remove(tdlists.First(x => x.ListID == ListId));
            writeJson(tdlists);
        }

        public ToDoList GetList(Guid ListId)
        {
            var tdlists = GetTdLists();
            return tdlists.First(x => x.ListID == ListId);
        }

        public void AddTask(task newtask, Guid ListId)
        {
            var tdlists = GetTdLists().ToList();
            tdlists[tdlists.FindIndex(x => x.ListID == ListId)].tasks.Add(newtask);
            
            writeJson(tdlists);
        }

        public void writeJson(IEnumerable<ToDoList> toDoLists)
        {
            File.WriteAllText(JsonFileName, "");
            using (var outputStream = File.OpenWrite(JsonFileName))
            {
                using (var sw = new StreamWriter(outputStream))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    serializer.Serialize(sw, toDoLists);
                }
            }
        }

        public void writeJson(ToDoList toDoList)
        {
            var tdlists = GetTdLists().ToList();
            tdlists[tdlists.FindIndex(x => x.ListID == toDoList.ListID)] = toDoList;
            writeJson(tdlists);
        }

    }
}
