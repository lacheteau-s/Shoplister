using Shoplister.Models;

namespace Shoplister.Stores
{
    public class ItemStore
    {
        private readonly List<Item> _items;

        public ItemStore()
        {
            _items = new()
            {
                new () { Id = 1, Name = "Item 1", Quantity = 1, Checked = false },
                new () { Id = 2, Name = "Item 2", Quantity = 1, Checked = false },
                new () { Id = 3, Name = "Item 3", Quantity = 1, Checked = false }
            };
        }

        public Item? GetItem(int id)
        {
            var item = _items.Find(x => x.Id == id);

            return new Item
            {
                Id = item.Id,
                Name = item.Name,
                Checked = item.Checked,
                Quantity = item.Quantity
            };
        }

        public IEnumerable<Item> GetItems()
        {
            return _items.ToList();
        }

        public void AddItem(Item item)
        {
            var id = _items.Any() ? _items.Max(x => x.Id) : 0;

            item.Id = id + 1;

            _items.Add(item);
        }

        public void UpdateItem(Item item)
        {
            var model = _items.Find(x => x.Id == item.Id);

            model.Name = item.Name;
            model.Quantity = item.Quantity;
            model.Checked = item.Checked;
        }

        public void DeleteItem(Item item)
        {
            _items.Remove(item);
        }

        public void DeleteItems()
        {
            _items.Clear();
        }
    }
}
