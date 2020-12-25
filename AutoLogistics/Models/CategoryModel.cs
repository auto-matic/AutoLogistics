using System;

namespace AutoLogistics.Models
{
    public class CategoryModel : Model
    {
        public int category_id { get; set; }
        public string name { get; set; }
        public DateTime addition { get; set; }

        public override string ToString()
        {
            return $"{category_id}\ue001{name}\ue001{addition}";
        }
    }
}

