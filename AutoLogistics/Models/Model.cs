using System;

namespace AutoLogistics.Models
{
    public interface Model
    {
        public string name { get; set; }
        public DateTime addition { get; set; }

        public string ToString();
    }
}