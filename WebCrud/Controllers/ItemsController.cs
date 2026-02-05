using Microsoft.AspNetCore.Mvc;
using WebCrud.Models;

namespace WebCrud.Controllers
{
    public class ItemsController : Controller
    {
        public IActionResult Index()
        {
            var items = ItemRepository.GetAll();
            return View(items);
        }

        public IActionResult Create() => View();

        [HttpPost]
        public IActionResult Create(Item item)
        {
            if (ModelState.IsValid)
            {
                ItemRepository.Add(item);
                return RedirectToAction(nameof(Index));
            }
            return View(item);
        }

        public IActionResult Edit(int id)
        {
            var item = ItemRepository.Get(id);
            if (item == null) return NotFound();
            return View(item);
        }

        [HttpPost]
        public IActionResult Edit(Item item)
        {
            if (ModelState.IsValid)
            {
                ItemRepository.Update(item);
                return RedirectToAction(nameof(Index));
            }
            return View(item);
        }

        public IActionResult Delete(int id)
        {
            var item = ItemRepository.Get(id);
            if (item == null) return NotFound();
            return View(item);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            ItemRepository.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
