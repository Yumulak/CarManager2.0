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
        [PrimaryKey, AutoIncrement]
        private int ID { get; set; }
        private string make;
        private string model;
        private string year;
        private string purchasedYear;
        private string purchasedMonth;
        private string price;

        public Car(string make, string model, string year, string purchaseYear, string purchaseMonth, string price)
        {
            this.ID = ID;
            Make = make;
            Model = model;
            ModelYear = Convert.ToInt32(year);
            PurchasedYear = Convert.ToInt32(purchaseYear);
            PurchasedMonth = Convert.ToInt32(purchaseMonth);
            Price = Convert.ToInt32(price);
        }
        public Car() { }
        public int Id { get { return ID; } }
        public string Make { get; set; }
        public string Model { get; set; }
        public int ModelYear { get; set; }
        public int PurchasedYear { get; set; }
        public int PurchasedMonth { get; set; }
        public int Price { get; set; }
        public string Image { get; set; }
    }
}
