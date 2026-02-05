using System.Collections.Generic;
using System.Linq;

namespace WebCrud.Models
{
    public static class ItemRepository
    {
        private static List<Item> items = new List<Item>();
        private static int nextId = 1;

        public static List<Item> GetAll() => items;

        public static Item Get(int id) => items.FirstOrDefault(i => i.Id == id);

        public static void Add(Item item)
        {
            item.Id = nextId++;
            items.Add(item);
        }

        public static void Update(Item item)
        {
            var existing = Get(item.Id);
            if (existing != null)
            {
                existing.Name = item.Name;
                existing.Description = item.Description;
            }
        }

        public static void Delete(int id)
        {
            var item = Get(id);
            if (item != null)
                items.Remove(item);
        }
    }
}
