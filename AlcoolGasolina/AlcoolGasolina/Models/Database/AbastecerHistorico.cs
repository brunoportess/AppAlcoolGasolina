using AlcoolGasolina.Models.Entities;
using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AlcoolGasolina.Models.Database
{
    [Xamarin.Forms.Internals.Preserve(AllMembers = true)]
    public class AbastecerHistorico
    {
        private SQLiteAsyncConnection database;
        public AbastecerHistorico()
        {
            //Task.Run(() => Initialize());
        }

        public async Task Initialize()
        {
            database = new SQLiteAsyncConnection(App.DatabasePath);
            await database.CreateTableAsync<Abastecer>();
        }

        public Task<List<Abastecer>> GetItemsAsync()
        {
            return database.Table<Abastecer>().OrderByDescending(p => p.Id).ToListAsync();
        }

        public Task<Abastecer> GetItemAsync(int id)
        {
            return database.Table<Abastecer>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }


        public async Task<int> SaveItemAsync(Abastecer item)
        {
            return await database.InsertAsync(item);
        }

        public Task<int> DeleteItemAsync(Abastecer item)
        {
            return database.DeleteAsync(item);
        }
    }
}
