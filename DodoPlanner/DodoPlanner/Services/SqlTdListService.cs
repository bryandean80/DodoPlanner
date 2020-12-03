using DodoPlanner.Models;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Microsoft.Data.Sqlite;

namespace DodoPlanner.Services
{
    public class SqlTdListService
    {
        public IWebHostEnvironment WebHostEnvironment { get; }
        private SqliteConnection Connection { get; }

        public SqlTdListService(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
            Connection = new SqliteConnection("Data Source=" + Path.Combine(WebHostEnvironment.WebRootPath, "data", "tdlists.db"));
            Connection.Open();
        }

        public void ToggleCompleted(Guid ListId, Guid TaskId)
        {
            var command = Connection.CreateCommand();
            command.CommandText =
            @"
                UPDATE Items
                SET completed = ((completed | 1) - (completed & 1))
                WHERE itemId = $id;
            ";
            command.Parameters.AddWithValue("$id", TaskId.ToString());
            command.ExecuteReader();
        }

        public void RemoveTask(Guid taskId, Guid listId)
        {
            var command = Connection.CreateCommand();
            command.CommandText =
            @"
                DELETE FROM Items
                WHERE itemId = $id;";
            command.Parameters.AddWithValue("$id", taskId.ToString());
            command.ExecuteNonQuery();
        }
        public IEnumerable<ToDoList> GetTdLists() { 
            var tdlists = new List<ToDoList>();
            var command = Connection.CreateCommand();
            command.CommandText =
            @"
                SELECT * FROM Lists;";
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    var list = new ToDoList();
                    var listId = reader.GetString(0);
                    list.Title = reader.GetString(1);
                    // Tasks already initiated
                    list.ListID = Guid.Parse(listId);
                    list.CategoryId = Guid.Parse(reader.GetString(2));
                    tdlists.Add(list);
                }
            }
            foreach(var list in tdlists)
            {
                command = Connection.CreateCommand();
                command.CommandText = "SELECT * FROM Items WHERE listID=$id;";
                command.Parameters.AddWithValue("$id", list.ListID);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var task = new task();
                        task.TaskID = Guid.Parse(reader.GetString(0));
                        task.title = reader.GetString(1);
                        task.duedate = DateTime.Parse(reader.GetString(2)).Date;
                        task.completed = reader.GetString(3) == "0" ? false : true;
                        task.ListId = Guid.Parse(reader.GetString(4));
                        list.tasks.Add(task);
                    }
                }
            }
                return tdlists;
        }
        public List<task> GetAllTasks()
        {
            List<task> tasks = new List<task>();
            var command = Connection.CreateCommand();
            command.CommandText =
            @"
                SELECT * FROM Items;";
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    var itemId = reader.GetString(0);
                    var title = reader.GetString(1);
                    var dueDate = reader.GetString(2);
                    bool completed = reader.GetString(3) == "0" ? false : true;
                    var listId = reader.GetString(4);
                    var task = new task();
                    task.title = title;
                    task.completed = completed;
                    task.TaskID = Guid.Parse(itemId);
                    task.duedate = DateTime.Parse(dueDate).Date;
                    task.ListId = Guid.Parse(listId);
                    tasks.Add(task);
                }
            }
                return tasks;
        }

        public IEnumerable<Category> GetCategories()
        {
            var categories = new List<Category>();
            var command = Connection.CreateCommand();
            command.CommandText =
            @"
                SELECT * FROM Categories;";
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    var category = new Category();
                    var catID = reader.GetString(0);
                    var catName = reader.GetString(1);
                    var color = reader.GetString(2);
                    category.Id = Guid.Parse(catID);
                    category.Name = catName;
                    category.Color = color;

                    categories.Add(category);
                }
            }
                return categories;
        }

        public void AddCategory(string name, string color, string username)
        {
            var category = new Category();
            category.Name = name;
            category.Color = color;
            var command = Connection.CreateCommand();
            command.CommandText =
            @"
                INSERT INTO Categories VALUES(
                $catID,
                $catName,
                $color
                );
                INSERT INTO Can_View VALUES(
                $username,
                $catID
                );";
            command.Parameters.AddWithValue("$catID", category.Id.ToString());
            command.Parameters.AddWithValue("$catName", category.Name);
            if(category.Color == null)
            {
                category.Color = "#FFFFFF";
            }
            command.Parameters.AddWithValue("$color", category.Color);
            command.Parameters.AddWithValue("$username", username);
            command.ExecuteNonQuery();
        }

        public void RemoveCategory(Guid catID)
        {
            var command = Connection.CreateCommand();
            command.CommandText =
            @"
            SELECT ListId FROM Lists WHERE catId = $id;";
            command.Parameters.AddWithValue("$id", catID.ToString());
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    var listId = reader.GetString(0);
                    var command2 = Connection.CreateCommand();
                    command2.CommandText =
                    @"
                        DELETE FROM Items WHERE listId = $id;";
                    command2.Parameters.AddWithValue("$id", listId);
                    command2.ExecuteNonQuery();
                }
            }
            command = Connection.CreateCommand();
            command.CommandText =
            @"
                DELETE FROM Lists WHERE catID = $id;
                DELETE FROM Categories WHERE CatID = $id;";
            command.Parameters.AddWithValue("$id", catID.ToString());
            command.ExecuteNonQuery();
        }
        public List<task> GetTasksOnDate(DateTime date)
        {
            List<task> tasks = new List<task>();
            var command = Connection.CreateCommand();
            command.CommandText =
            @"
                SELECT * FROM Items WHERE dueDate = $date;";
            command.Parameters.AddWithValue("$date", date.Date.ToString());
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    var task = new task();
                    task.TaskID = Guid.Parse(reader.GetString(0));
                    task.title = reader.GetString(1);
                    task.duedate = DateTime.Parse(reader.GetString(2)).Date;
                    task.completed = reader.GetString(3) == "0" ? false : true;
                    task.ListId = Guid.Parse(reader.GetString(4));
                    tasks.Add(task);
                }
            }
                return tasks;
        }

        public void AddTdList(string title, Guid catID)
        {
            var command = Connection.CreateCommand();
            command.CommandText = "INSERT INTO Lists VALUES($listID, $listName, $catID);";
            command.Parameters.AddWithValue("$listID", Guid.NewGuid().ToString());
            command.Parameters.AddWithValue("$listName", title);
            command.Parameters.AddWithValue("$catID", catID.ToString());
            command.ExecuteNonQuery();
        }

        public void RemoveTdList(Guid ListId)
        {
            var command = Connection.CreateCommand();
            command.CommandText =
            @"
                DELETE FROM Items WHERE listID = $id;
                DELETE FROM Lists WHERE listID = $id;";
            command.Parameters.AddWithValue("$id", ListId.ToString());
            command.ExecuteNonQuery();
        }

        public ToDoList GetList(Guid ListId)
        {
            var list = new ToDoList();
            var command = Connection.CreateCommand();
            command.CommandText = "SELECT * FROM Lists WHERE listID=$id;";
            command.Parameters.AddWithValue("$id", ListId.ToString());
            using (var reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    list.ListID = Guid.Parse(reader.GetString(0));
                    list.Title = reader.GetString(1);
                    list.CategoryId = Guid.Parse(reader.GetString(2));
                }
                else
                {
                    return null;
                }
            }
            command = Connection.CreateCommand();
            command.CommandText = "SELECT * FROM Items WHERE ListID=$id;";
            command.Parameters.AddWithValue("$id", ListId.ToString());
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    var task = new task();
                    task.TaskID = Guid.Parse(reader.GetString(0));
                    task.title = reader.GetString(1);
                    task.duedate = DateTime.Parse(reader.GetString(2)).Date;
                    task.completed = reader.GetString(3) == "0" ? false : true;
                    task.ListId = Guid.Parse(reader.GetString(4));
                    list.tasks.Add(task);
                }
            }

                return list;
        }

        public void AddTask(task newtask, Guid ListId)
        {
            var command = Connection.CreateCommand();
            command.CommandText =
            @"INSERT INTO Items VALUES(
                $itemId,
                $title,
                $dueDate,
                0,
                $listId
            );";
            command.Parameters.AddWithValue("$itemId", newtask.TaskID.ToString());
            command.Parameters.AddWithValue("$title", newtask.title);
            command.Parameters.AddWithValue("$dueDate", newtask.duedate.Date.ToString());
            command.Parameters.AddWithValue("$listId", newtask.ListId.ToString());
            command.ExecuteNonQuery();
        }

        public void editCategory(Category newCat)
        {
            var command = Connection.CreateCommand();
            command.CommandText =
            @"UPDATE Categories
            SET catName = $name,
                color = $color
            WHERE catID = $id;";
            command.Parameters.AddWithValue("$name", newCat.Name);
            command.Parameters.AddWithValue("$color", newCat.Color);
            command.Parameters.AddWithValue("$id", newCat.Id.ToString());
            command.ExecuteNonQuery();
        }
        public void editList(ToDoList newList)
        {
            var command = Connection.CreateCommand();
            command.CommandText =
            @"UPDATE Lists
            SET listName = $name,
                catID = $catID
            WHERE listID = $id;";
            command.Parameters.AddWithValue("$name", newList.Title);
            command.Parameters.AddWithValue("$catID", newList.CategoryId.ToString());
            command.Parameters.AddWithValue("$id", newList.ListID.ToString());
            command.ExecuteNonQuery();
        }
        public void editTask(task newTask)
        {
            var command = Connection.CreateCommand();
            command.CommandText =
            @"UPDATE Items
            SET title=$title,
                dueDate=$date,
                listID=$listID
            WHERE itemID=$id;";
            command.Parameters.AddWithValue("$title", newTask.title);
            command.Parameters.AddWithValue("$date", newTask.duedate.Date.ToString());
            command.Parameters.AddWithValue("$listID", newTask.ListId.ToString());
            command.Parameters.AddWithValue("$id", newTask.TaskID.ToString());
            command.ExecuteNonQuery();
        }

        public bool createAccount(string username, string password)
        {
            var command = Connection.CreateCommand();
            command.CommandText = "SELECT username FROM Users WHERE username=$user;";
            command.Parameters.AddWithValue("$user", username);
            using (var reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    return false;
                }
            }
            command = Connection.CreateCommand();
            command.CommandText = "INSERT INTO Users VALUES($user, $pw);";
            command.Parameters.AddWithValue("$user", username);
            command.Parameters.AddWithValue("$pw", password);
            command.ExecuteNonQuery();
            return true;
        }

        public bool login(string username, string password)
        {
            var command = Connection.CreateCommand();
            command.CommandText = "SELECT password FROM Users WHERE username=$user;";
            command.Parameters.AddWithValue("$user", username);
            using (var reader = command.ExecuteReader())
            {
                if (!reader.Read())
                {
                    return false;
                }
                else
                {
                    if(reader.GetString(0) == password)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }

        public void add_view_permissions(string username, Guid catID)
        {
            var command = Connection.CreateCommand();
            command.CommandText = "INSERT INTO Can_View VALUES ($username, $catID);";
            command.Parameters.AddWithValue("$username", username);
            command.Parameters.AddWithValue("$catID", catID);
            command.ExecuteNonQuery();
        }

        public List<Category> get_user_categories(string username)
        {
            List<Category> catList = new List<Category>();
            var command = Connection.CreateCommand();
            command.CommandText = "SELECT * FROM Can_View WHERE username=$username";
            command.Parameters.AddWithValue("$username", username);
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    var cat = new Category();
                    cat.Id = Guid.Parse(reader.GetString(0));
                    cat.Name = reader.GetString(1);
                    cat.Color = reader.GetString(2);
                    catList.Add(cat);
                }
            }
            return catList;
        }

        public List<task> get_user_tasks_on_date(string username, DateTime dueDate)
        {
            List<task> tasks = new List<task>();
            var command = Connection.CreateCommand();
            command.CommandText =
                @"
                SELECT Items.*
                FROM Items
                INNER JOIN Lists ON Items.listID = Lists.listID
                INNER JOIN Categories ON Lists.catID = Categories.catID
                INNER JOIN Can_View ON Categories.catID = Can_View.catID
                WHERE Can_View.username=$username AND dueDate=$dueDate;";
            command.Parameters.AddWithValue("$username", username);
            command.Parameters.AddWithValue("$dueDate", dueDate.ToString());
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    var task = new task();
                    task.TaskID = Guid.Parse(reader.GetString(0));
                    task.title = reader.GetString(1);
                    task.duedate = DateTime.Parse(reader.GetString(2));
                    task.completed = reader.GetString(3) == "1";
                    task.ListId = Guid.Parse(reader.GetString(4));
                    tasks.Add(task);
                }
            }
                return tasks;
        }
    }
}
