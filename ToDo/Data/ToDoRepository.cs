using Microsoft.EntityFrameworkCore;
using ToDo.Models;

namespace ToDo.Data
{
    public class ToDoRepository : IToDoRepository
    {
        private readonly ToDoContext _context;

        public ToDoRepository(ToDoContext context)
        {
            _context = context;
        }

        public IEnumerable<ToDoItem> GetAll() => _context.ToDoItems.ToList();
        public ToDoItem GetById(int id)
        {
            var item = _context.ToDoItems.Find(id);
            if (item == null)
                throw new InvalidOperationException($"ToDoItem with id {id} not found.");
            return item;
        }
        public void Add(ToDoItem item) => _context.ToDoItems.Add(item);
        public void Update(ToDoItem item) => _context.ToDoItems.Update(item);
        public void Delete(int id)
        {
            var item = GetById(id);
            if (item != null) _context.ToDoItems.Remove(item);
        }
        public void Save() => _context.SaveChanges();
    }
}

