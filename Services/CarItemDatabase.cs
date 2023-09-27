using System;
using System.Collections.Generic;
using System.Data;
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
        //1 month
        public static void ResetOilCheckById(int id)
        {
            using var db = new SQLiteConnection(DBConstants.DatabasePath, DBConstants.Flags);
            var car = db.Table<Car>().FirstOrDefault(p => p.Id == id);
            car.monthlyOilChecked = DateTime.Now.AddMonths(1);            
            db.Update(car);
            Notification.ScheduleNotification(car.monthlyOilChecked - TimeSpan.FromDays(7));
        }
        internal static void ResetTireCheckById(int id)
        {
            using var db = new SQLiteConnection(DBConstants.DatabasePath, DBConstants.Flags);
            var car = db.Table<Car>().FirstOrDefault(p => p.Id == id);
            car.monthlyTiresChecked = DateTime.Now.AddMonths(1);
            db.Update(car);
            Notification.ScheduleNotification(car.monthlyTiresChecked - TimeSpan.FromDays(7));
        }
        internal static void ResetLightsCheckById(int id)
        {
            using var db = new SQLiteConnection(DBConstants.DatabasePath, DBConstants.Flags);
            var car = db.Table<Car>().FirstOrDefault(p => p.Id == id);
            car.monthlyLightsChecked = DateTime.Now.AddMonths(1);
            db.Update(car);
            Notification.ScheduleNotification(car.monthlyLightsChecked - TimeSpan.FromDays(7));
        }
        internal static void ResetWashFluidById(int id)
        {
            using var db = new SQLiteConnection(DBConstants.DatabasePath, DBConstants.Flags);
            var car = db.Table<Car>().FirstOrDefault(p => p.Id == id);
            car.monthlyWasherFluidChecked = DateTime.Now.AddMonths(1);
            db.Update(car);
            Notification.ScheduleNotification(car.monthlyWasherFluidChecked - TimeSpan.FromDays(7));
        }
        //3 month
        internal static void ResetBrakeFluidCheckById(int id)
        {
            using var db = new SQLiteConnection(DBConstants.DatabasePath, DBConstants.Flags);
            var car = db.Table<Car>().FirstOrDefault(p => p.Id == id);
            car.quarterlyBrakeFluidChecked = DateTime.Now.AddMonths(3);
            db.Update(car);
            Notification.ScheduleNotification(car.quarterlyBrakeFluidChecked - TimeSpan.FromDays(7));
        }
        internal static void ResetTransCheckById(int id)
        {
            using var db = new SQLiteConnection(DBConstants.DatabasePath, DBConstants.Flags);
            var car = db.Table<Car>().FirstOrDefault(p => p.Id == id);
            car.quarterlyTransFluidChecked = DateTime.Now.AddMonths(3);
            db.Update(car);
            Notification.ScheduleNotification(car.quarterlyTransFluidChecked - TimeSpan.FromDays(7));
        }
        internal static void ResetSteeringCheckById(int id)
        {
            using var db = new SQLiteConnection(DBConstants.DatabasePath, DBConstants.Flags);
            var car = db.Table<Car>().FirstOrDefault(p => p.Id == id);
            car.quarterlySteeringFluidChecked = DateTime.Now.AddMonths(3);
            db.Update(car);
            Notification.ScheduleNotification(car.quarterlySteeringFluidChecked - TimeSpan.FromDays(7));
        }
        internal static void ResetHosesBeltsById(int id)
        {
            using var db = new SQLiteConnection(DBConstants.DatabasePath, DBConstants.Flags);
            var car = db.Table<Car>().FirstOrDefault(p => p.Id == id);
            car.quarterlyHosesBeltsChecked = DateTime.Now.AddMonths(3);
            db.Update(car);
            Notification.ScheduleNotification(car.quarterlyHosesBeltsChecked - TimeSpan.FromDays(7));
        }
        //6 month
        internal static void ResetOilChangedById(int id)
        {
            using var db = new SQLiteConnection(DBConstants.DatabasePath, DBConstants.Flags);
            var car = db.Table<Car>().FirstOrDefault(p => p.Id == id);
            car.sixMoOilChanged = DateTime.Now.AddMonths(6);
            db.Update(car);
            Notification.ScheduleNotification(car.sixMoOilChanged - TimeSpan.FromDays(7));
        }
        internal static void ResetTiresRotatedById(int id)
        {
            using var db = new SQLiteConnection(DBConstants.DatabasePath, DBConstants.Flags);
            var car = db.Table<Car>().FirstOrDefault(p => p.Id == id);
            car.sixMoTiresRotated = DateTime.Now.AddMonths(6);
            db.Update(car);
            Notification.ScheduleNotification(car.sixMoTiresRotated - TimeSpan.FromDays(7));
        }
        internal static void ResetBatteryCheckedById(int id)
        {
            using var db = new SQLiteConnection(DBConstants.DatabasePath, DBConstants.Flags);
            var car = db.Table<Car>().FirstOrDefault(p => p.Id == id);
            car.sixMoBatteryChecked = DateTime.Now.AddMonths(6);
            db.Update(car);
            Notification.ScheduleNotification(car.sixMoBatteryChecked - TimeSpan.FromDays(7));
        }
        internal static void ResetAirFiltersCheckedById(int id)
        {
            using var db = new SQLiteConnection(DBConstants.DatabasePath, DBConstants.Flags);
            var car = db.Table<Car>().FirstOrDefault(p => p.Id == id);
            car.sixMoAirFiltersChecked = DateTime.Now.AddMonths(6);
            db.Update(car);
            Notification.ScheduleNotification(car.sixMoAirFiltersChecked - TimeSpan.FromDays(7));
        }
        //1 year
        internal static void ResetAlignmentById(int id)
        {
            using var db = new SQLiteConnection(DBConstants.DatabasePath, DBConstants.Flags);
            var car = db.Table<Car>().FirstOrDefault(p => p.Id == id);
            car.yearlyAlignmentDone = DateTime.Now.AddYears(1);
            db.Update(car);
            Notification.ScheduleNotification(car.yearlyAlignmentDone - TimeSpan.FromDays(7));
        }
        internal static void ResetBrakesCheckedById(int id)
        {
            using var db = new SQLiteConnection(DBConstants.DatabasePath, DBConstants.Flags);
            var car = db.Table<Car>().FirstOrDefault(p => p.Id == id);
            car.yearlyBrakesChecked = DateTime.Now.AddYears(1);
            db.Update(car);
            Notification.ScheduleNotification(car.yearlyBrakesChecked - TimeSpan.FromDays(7));
        }
    }
}
