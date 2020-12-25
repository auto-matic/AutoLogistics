using System;

namespace AutoLogistics.Models
{
    public class PlaceModel : Model
    {
        public int place_id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public int owner_id { get; set; }
        public DateTime addition { get; set; }
        public DateTime possession { get; set; }

        public override string ToString()
        {
            return $"{place_id}\ue001{name}\ue001{description}\ue001{owner_id}\ue001{addition}\ue001{possession}";
        }
    }
}
