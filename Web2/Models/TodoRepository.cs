using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace Web2.Models
{
    public class TodoRepository : ITodoRepository
    {
        private static ConcurrentDictionary<string, Todo> _todo = new ConcurrentDictionary<string, Todo>();

        public TodoRepository()
        {
            //Add(new Todo { Name = "item1" });
            Add(new Todo { Name = "new task", IsComplete = true });
        }

        public void Add(Todo item)
        {
            item.Key = Guid.NewGuid().ToString();
            _todo[item.Key] = item;

        }

        public void Update(Todo item)
        {
            _todo[item.Key] = item;
        }

        public Todo FindItem(string Key)
        {
            Todo item;
            _todo.TryGetValue(Key, out item);
            return item;
        }
        public Todo RemoveItem(string Key)
        {
            Todo item;
            _todo.TryRemove(Key, out item);
            return item;
        }

        public IEnumerable<Todo> GetAll()
        {
            return _todo.Values;
        }

    }
}
