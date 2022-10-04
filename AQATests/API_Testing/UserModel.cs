using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AQATests.API_Testing
{
    class UserModel
    {
        public int id { get; set; }
        public string first_name { get; set; }
        public string name { get; set; }
        public string job { get; set; }
        public string last_name { get; set; }
        public string avatar { get; set; }
        public string url { get; set; }
        public string text { get; set; }
        public string email { get; set; }
        public DateTime updateAt { get; set; }
        public string movies { get; set; } 
    }
    class StarWarsObject
    {
        public string films { get; set; }
        public string people { get; set; }
        public string planets { get; set; }
        public string species { get; set; }
        public string starships { get; set; }
        public string vehicles { get; set; }
    }

    class JsonModel
    {
        public int page { get; set; }
        public int per_page { get; set; }
        public int total { get; set; }
        public List<UserModel> data { get; set; }
        public string support { get; set; }
    }
    public class DogModel
    {
        public string message { get; set; }
        public string status { get; set; }
    }
    public class BookingDates
    {
        public DateTime checkin  { get; set; }
        public DateTime checkout { get; set; }
    }
}
