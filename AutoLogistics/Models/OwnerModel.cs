using System;
using System.Collections.Generic;
using System.Text;

namespace AutoLogistics.Models
{
    public class OwnerModel
    {
        public int owner_id { get; set; }
        public string name { get; set; }
        public DateTime addition { get; set; }
        public DateTime possession { get; set; }
}
}
