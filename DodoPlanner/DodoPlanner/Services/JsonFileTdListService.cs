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
        private string CategoryJsonFileName
        {
            get { return Path.Combine(WebHostEnvironment.WebRootPath, "data", "categories.json"); }
        }

        public void ToggleCompleted(Guid ListId, Guid TaskId)
        {
            var tdlist = GetList(ListId);
            var task = tdlist.tasks[tdlist.tasks.FindIndex(x => x.TaskID == TaskId)];
            task.completed = !task.completed;
            writeJson(tdlist);
        }

        public void RemoveTask(Guid taskId, Guid ListId)
        {
            var tdlist = GetList(ListId);
            tdlist.tasks.Remove(tdlist.tasks.First(x => x.TaskID == taskId));
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
        public List<task> GetAllTasks()
        {
            List<task> tasks = new List<task>();
            var tdlists = GetTdLists();
            foreach(var tdlist in tdlists)
            {
                foreach(var task in tdlist.tasks)
                {
                    tasks.Add(task);
                }
            }
            return tasks;
        }
        public IEnumerable<Category> GetCategories()
        {
            var categories = new List<Category>();
            using (StreamReader file = new StreamReader(CategoryJsonFileName))
            {
                JsonSerializer serializer = new JsonSerializer();
                categories = (List<Category>)serializer.Deserialize(file, typeof(IEnumerable<Category>));

            }
            return categories;
        }

        public void AddCategory(string name, string color)
        {
            var categories = GetCategories().ToList();
            categories.Add(new Category { Name = name, Color = color});
            CategoryWriteJson(categories);
        }
        public void RemoveCategory(Guid catid)
        {
            var categories = GetCategories().ToList();
            var tdlists = GetTdLists().Where(x => x.CategoryId == catid);
            foreach(var list in tdlists)
            {
                RemoveTdList(list.ListID);
            }
            categories.Remove(categories.First(x => x.Id == catid));
            CategoryWriteJson(categories);
        }
        public void CategoryWriteJson(IEnumerable<Category> categories)
        {
            File.WriteAllText(CategoryJsonFileName, "");
            using (var outputStream = File.OpenWrite(CategoryJsonFileName))
            {
                using (var sw = new StreamWriter(outputStream))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    serializer.Serialize(sw, categories);
                }
            }
        }
        public void CategoryWriteJson(Category category)
        {
            var categories = GetCategories().ToList();
            categories[categories.FindIndex(x => x.Id == category.Id)] = category;
            CategoryWriteJson(categories);
        }

        public List<task> GetTasksOnDate(DateTime date)
        {
            List<task> datetasks = new List<task>();
            return GetAllTasks().Where(x => x.duedate.Date == date.Date).ToList();
        }
        public void AddTdList(string title, Guid catid)
        {
            var tdlists = GetTdLists().ToList();
            tdlists.Add(new ToDoList { Title = title, CategoryId = catid});
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
        public void writeJson(task task, Guid ListId)
        {
            var tdlists = GetTdLists().ToList();
            var tdlist = tdlists.First(x => x.ListID == ListId);
            tdlist.tasks[tdlist.tasks.FindIndex(x => x.TaskID == task.TaskID)] = task;
            writeJson(tdlist);
        }


    }
}
