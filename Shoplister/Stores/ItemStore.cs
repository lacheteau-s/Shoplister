using Shoplister.Models;
using SQLite;

namespace Shoplister.Stores
{
    public class ItemStore
    {
        private readonly SQLiteAsyncConnection _connection;

        private readonly Task _initializer;

        public ItemStore(SQLiteAsyncConnection connection)
        {
            _connection = connection;

            _initializer = InitializeAsync();
        }

        private async Task InitializeAsync()
        {
            if (_initializer?.IsCompleted ?? false) return;

            await _connection.CreateTableAsync<Item>();
        }

        public async Task<Item?> GetItem(int id)
        {
            await _initializer;

            return await _connection.FindAsync<Item>(id);
        }

        public async Task<IEnumerable<Item>> GetItems()
        {
            await _initializer;

            return await _connection.Table<Item>().ToListAsync();
        }

        public async Task<int> AddItem(Item item)
        {
            await _initializer;

            return await _connection.InsertAsync(item);
        }

        public async Task<int> UpdateItem(Item item)
        {
            await _initializer;

            return await _connection.UpdateAsync(item);
        }

        public async Task<int> UpdateItems(IEnumerable<Item> items)
        {
            await _initializer;

            return await _connection.UpdateAllAsync(items);
        }

        public async Task<int> DeleteItem(Item item)
        {
            await _initializer;

            return await _connection.DeleteAsync(item);
        }

        public async Task<int> DeleteItems()
        {
            await _initializer;

            return await _connection.DeleteAllAsync<Item>();
        }
    }
}
