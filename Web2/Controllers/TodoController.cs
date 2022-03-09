using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Web2.Models;

namespace Web2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : Controller
    {
        public TodoController(ITodoRepository todoItems)
        {
            ITodoItems = todoItems;
        }
        public ITodoRepository ITodoItems { get; set; }

        [HttpGet()]
        public IEnumerable<Todo> GetAll()
        {
            return ITodoItems.GetAll();
        }


        [HttpGet("{id}", Name = "GetTodo")]
        public ActionResult GetById(string Id)
        {
            var item = ITodoItems.FindItem(Id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }
        [HttpPost]
        public IActionResult Create([FromBody] Todo item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            ITodoItems.Add(item);
            return CreatedAtRoute("GetTodo", new { id = item.Key }, item);
        }
        [HttpPut("{id}")]
        public IActionResult Update(string id, [FromBody] Todo item)
        {
            if (item == null && item.Key == id)
            {
                return BadRequest();
            }
            ITodoItems.Update(item);
            return new NoContentResult();
        }
        [HttpPatch("{id}")]
        public IActionResult UpdateData(string Id, [FromBody] Todo item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            var todo = ITodoItems.FindItem(Id);
            if (todo == null)
            {
                return NotFound();
            }
            item.Key = todo.Key;

            ITodoItems.Update(item);
            return new NoContentResult();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(string Id)
        {
            var todo = ITodoItems.FindItem(Id);
            if (todo == null)
            {
                return NotFound();
            }
            ITodoItems.RemoveItem(Id);
            return new NoContentResult();
        }

    }
}
