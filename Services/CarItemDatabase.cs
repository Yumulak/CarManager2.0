using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace CarManager.Services
{
    public static class CarItemDatabase
    {
        static SQLiteAsyncConnection Database;
        static async Task Init()
        {
            if (Database is not null)
            {
                return;
            }
            Database = new SQLiteAsyncConnection(DBConstants.DatabasePath, DBConstants.Flags);
            var result = await Database.CreateTableAsync<Car>();
        }

        public static async Task<List<Car>> GetAllCarsAsync()
        {
            await Init();
            return await Database.Table<Car>().ToListAsync();
        }
        
        public static async Task<Car> GetCarAsync(int id)
        {
            await Init();
            return await Database.Table<Car>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public static async Task<int> AddCarAsync(Car car)
        {
            await Init();
            if (car.Id != 0)
                return await Database.UpdateAsync(car);
            else
                return await Database.InsertAsync(car);
        }

        public static async Task<int> DeleteItemAsync(Car car)
        {
            await Init();
            return await Database.DeleteAsync(car);
        }
    }
}
