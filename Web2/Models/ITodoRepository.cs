using System.Collections.Generic;

namespace Web2.Models
{
    public interface ITodoRepository
    {
        void Add(Todo item);
        void Update(Todo item);
        Todo FindItem(string Key);
        Todo RemoveItem(string Key);
        IEnumerable<Todo> GetAll();


    }
}
