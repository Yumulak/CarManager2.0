using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace CarManager.Model
{
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
        //check oil
        public DateTime monthlyOilChecked { get; set; } = DateTime.Now;
        //check tire pressure & tread
        public DateTime monthlyTiresChecked { get; set; } = DateTime.Now;
        //check all lights
        public DateTime monthlyLightsChecked { get; set; } = DateTime.Now;
        //wipers & washer fluid
        public DateTime monthlyWasherFluidChecked { get; set; } = DateTime.Now;

        //3 months
        //check brake fluid
        public DateTime quarterlyBrakeFluidChecked { get; set; } = DateTime.Now;
        //check transmission fluid
        public DateTime quarterlyTransFluidChecked { get; set; } = DateTime.Now;
        //check power steering fluid
        public DateTime quarterlySteeringFluidChecked { get; set; } = DateTime.Now;
        //check hoses & belts
        public DateTime quarterlyHosesBeltsChecked { get; set; } = DateTime.Now;

        //mid term(6 months)
        //oil & filter change
        public DateTime sixMoOilChanged { get; set; } = DateTime.Now;
        //rotate tires
        public DateTime sixMoTiresRotated { get; set; } = DateTime.Now;
        //check battery
        public DateTime sixMoBatteryChecked { get; set; } = DateTime.Now;
        //cabin & engine air filters
        public DateTime sixMoAirFiltersChecked { get; set; } = DateTime.Now;

        //long term(yearly)
        //alignment
        public DateTime yearlyAlignmentDone { get; set; } = DateTime.Now;
        //check/change brakes
        public DateTime yearlyBrakesChecked { get; set; } = DateTime.Now;
    }
}
