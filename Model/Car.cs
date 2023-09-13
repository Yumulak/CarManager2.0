using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarManager.Model
{
    public class Car
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public int ModelYear { get; set; }
        public int PurchasedYear { get; set; }
        public int PurchasedMonth { get; set; }
        public int Price { get; set; }
        public string Image { get; set; }
    }
}
