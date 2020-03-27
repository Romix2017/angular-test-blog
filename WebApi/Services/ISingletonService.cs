using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.Services
{
    public interface ISingletonService
    {
        List<Todo> GetAll();
        Todo GetItem(int id);
        List<Todo> AddItem(Todo item);
        List<Todo> RemoveItem(int id);
        Todo UpdateItem(Todo item);
    }
}
