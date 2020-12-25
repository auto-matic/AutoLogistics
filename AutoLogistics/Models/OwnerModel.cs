using System;
using System.Collections.Generic;
using System.Text;

namespace AutoLogistics.Models
{
    public class OwnerModel : Model
    {
        public int owner_id { get; set; }
        public string name { get; set; }
        public DateTime addition { get; set; }
        
        public override string ToString()
        {
            return $"{owner_id}\ue001{name}\ue001{addition}";
        }
    }
}
