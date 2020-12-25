using System;

namespace AutoLogistics.Models
{
    public class ItemModel : Model
    { 
        public int item_id { get; set; }
        public string name { get; set; }
        public int category_id { get; set; }
        public int place_id { get; set; }
        public string description { get; set; }
        public int owner_id { get; set; }
        public int amount { get; set; }
        public string unit { get; set; }
        public DateTime addition { get; set; }
        public DateTime possession { get; set; }

        public override string ToString()
        {
            return $"{item_id}\ue001{name}\ue001{category_id}\ue001{place_id}\ue001{description}\ue001{owner_id}\ue001{amount}\ue001{unit}\ue001{addition}\ue001{possession}";
        }
    }
}
