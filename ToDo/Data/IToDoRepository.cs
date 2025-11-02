using ToDo.Models;

namespace ToDo.Data
{
    public interface IToDoRepository
    {
        IEnumerable<ToDoItem> GetAll();
        ToDoItem GetById(int id);
        void Add(ToDoItem item);
        void Update(ToDoItem item);
        void Delete(int id);
        void Save();
    }

}
