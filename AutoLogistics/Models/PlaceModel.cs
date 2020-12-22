using System;

namespace AutoLogistics.Models
{
    public class PlaceModel
    {
        public int place_id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public int owner_id { get; set; }
        public DateTime addition { get; set; }
        public DateTime possession { get; set; }
    }
}
