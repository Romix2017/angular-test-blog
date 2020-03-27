using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.Services
{
    public class SingletonService : ISingletonService
    {
        private static List<Todo> todoList = new List<Todo>();
        public SingletonService()
        {
            Todo first = new Todo();
            first.id = 1;
            first.title = "Power of God";
            first.completed = true;
            Todo second = new Todo();
            second.id = 2;
            second.title = "Power of Holy Spirit";
            second.completed = false;
            todoList.Add(first);
            todoList.Add(second);
        }
        public List<Todo> GetAll() => todoList;
        public Todo GetItem(int id)
        {
            return todoList.Where(x => x.id == id).SingleOrDefault();
        }
        public List<Todo> AddItem(Todo item)
        {
            todoList.Add(item);
            return todoList;
        }
        public List<Todo> RemoveItem(int id)
        {
            Todo item = todoList.Where(x => x.id == id).SingleOrDefault();
            if (item != null)
            {
                todoList.Remove(item);
            }
            return todoList;
        }
        public Todo UpdateItem(Todo item)
        {
            var dict = todoList.ToDictionary(x => x.id);
            Todo foundItem;
            if (dict.TryGetValue(item.id, out foundItem))
            {
                foundItem.completed = item.completed;
            }
            return foundItem;
        }
    }
}
