using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace CarManager.Services
{
    public class CarService
    {
        
        public CarService()
        {
            var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("https://parseapi.back4app.com/classes");
        }

        List<Car> carsList = new List<Car>();
        public async Task<List<Car>> GetCars()
        {
            if(carsList?.Count > 0)
            {
                return carsList;
            }
            var url = "Carmodels_Car_Model_List?limit=10&excludeKeys=Category";
            using(HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("X-Parse-Application-Id", "vaIq60tklaAFDKD70gKIcWQODsc74pStnIxgeehr"); // This is your app's application id
                client.DefaultRequestHeaders.Add("X-Parse-REST-API-Key", "U4ts2cVh8lWffeRlqsEWpO47KeoBBnZaz0ajuj2Z"); // This is your app's REST API key

                var response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    carsList = await response.Content.ReadFromJsonAsync<List<Car>>();
                }                       
            }
            return carsList;
        }
    }
}
