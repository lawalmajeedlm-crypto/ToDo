using Microsoft.AspNetCore.Mvc;
using ToDo.Data;
using ToDo.Models;

namespace ToDo.Controllers
{
    public class ToDoController : Controller
    {
        private readonly IToDoRepository _repository;

        public ToDoController(IToDoRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public IActionResult Index()
        {
            var items = _repository.GetAll();
            return View(items);
        }

        public IActionResult Details(int id)
        {
            var item = _repository.GetById(id);
            if (item == null)
            {
                return NotFound();
            }
            return View(item);
        }

        public IActionResult Create() => View();


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ToDoItem Item)
        {
            if (ModelState.IsValid)
            {
                _repository.Add(Item);
                _repository.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(Item);
        }

        public IActionResult Edit(int id)
        {
            var item = _repository.GetById(id);
            if (item == null)
            {
                return NotFound();
            }
            return View(item);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, ToDoItem Item)
        {
            if (id != Item.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                _repository.Update(Item);
                _repository.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(Item);
        }

        public IActionResult Delete(int id)
        {
            var item = _repository.GetById(id);
            if (item == null)
            {
                return NotFound();
            }
            return View(item);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _repository.Delete(id);
            _repository.Save();
            return RedirectToAction(nameof(Index));
        }
    }
}
