using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;


namespace CarManager.Model
{
    [Table("Car")]
    public class Car
    {
        public Car(string make, string model, string year, string purchaseYear, string purchaseMonth, string price)
        {
            Make = make;
            Model = model;
            ModelYear = Convert.ToInt32(year);
            PurchasedYear = Convert.ToInt32(purchaseYear);
            PurchasedMonth = Convert.ToInt32(purchaseMonth);
            Price = Convert.ToInt32(price);

            //create initial notifications
            Notification.ScheduleNotification(monthlyOilChecked - TimeSpan.FromDays(7));
            Notification.ScheduleNotification(monthlyTiresChecked - TimeSpan.FromDays(7));
            Notification.ScheduleNotification(monthlyLightsChecked - TimeSpan.FromDays(7));
            Notification.ScheduleNotification(monthlyWasherFluidChecked - TimeSpan.FromDays(7));
            Notification.ScheduleNotification(quarterlyBrakeFluidChecked - TimeSpan.FromDays(7));
            Notification.ScheduleNotification(quarterlyTransFluidChecked - TimeSpan.FromDays(7));
            Notification.ScheduleNotification(quarterlySteeringFluidChecked - TimeSpan.FromDays(7));
            Notification.ScheduleNotification(quarterlyHosesBeltsChecked - TimeSpan.FromDays(7));
            Notification.ScheduleNotification(sixMoOilChanged - TimeSpan.FromDays(7));
            Notification.ScheduleNotification(sixMoTiresRotated - TimeSpan.FromDays(7));
            Notification.ScheduleNotification(sixMoBatteryChecked - TimeSpan.FromDays(7));
            Notification.ScheduleNotification(sixMoAirFiltersChecked - TimeSpan.FromDays(7));
            Notification.ScheduleNotification(yearlyAlignmentDone - TimeSpan.FromDays(7));
            Notification.ScheduleNotification(yearlyBrakesChecked - TimeSpan.FromDays(7));
        }
        public Car() { }
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int ModelYear { get; set; }
        public int PurchasedYear { get; set; }
        public int PurchasedMonth { get; set; }
        public int Price { get; set; }
        public string Image { get; set; }

        //short term (monthly)
        // set default value as one month from current date
        //check oil
        public DateTime monthlyOilChecked { get; set; } = (DateTime.Now.AddMonths(1)); 
        //check tire pressure & tread
        public DateTime monthlyTiresChecked { get; set; } = (DateTime.Now.AddMonths(1));
        //check all lights
        public DateTime monthlyLightsChecked { get; set; } = (DateTime.Now.AddMonths(1));
        //wipers & washer fluid
        public DateTime monthlyWasherFluidChecked { get; set; } = (DateTime.Now.AddMonths(1));

        //3 months
        // set default value as three months from current date
        //check brake fluid
        public DateTime quarterlyBrakeFluidChecked { get; set; } = (DateTime.Now.AddMonths(3));
        //check transmission fluid
        public DateTime quarterlyTransFluidChecked { get; set; } = (DateTime.Now.AddMonths(3));
        //check power steering fluid
        public DateTime quarterlySteeringFluidChecked { get; set; } = (DateTime.Now.AddMonths(3));
        //check hoses & belts
        public DateTime quarterlyHosesBeltsChecked { get; set; } = (DateTime.Now.AddMonths(3));

        //mid term(6 months)
        // set default value as six months from current date
        //oil & filter change
        public DateTime sixMoOilChanged { get; set; } = (DateTime.Now.AddMonths(6));
        //rotate tires
        public DateTime sixMoTiresRotated { get; set; } = (DateTime.Now.AddMonths(6));
        //check battery
        public DateTime sixMoBatteryChecked { get; set; } = (DateTime.Now.AddMonths(6));
        //cabin & engine air filters
        public DateTime sixMoAirFiltersChecked { get; set; } = (DateTime.Now.AddMonths(6));

        //long term(yearly)
        // set default value as 1 year from current date
        //alignment
        public DateTime yearlyAlignmentDone { get; set; } = (DateTime.Now.AddYears(1));
        //check/change brakes
        public DateTime yearlyBrakesChecked { get; set; } = (DateTime.Now.AddYears(1));
    }    
}
