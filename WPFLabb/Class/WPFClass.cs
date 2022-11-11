using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFLabb.Class
{
    internal class WPFClass
    {
        public class Restaurant
        {
            public string Date { get; set; }
            public string Time { get; set; }
            public string Name { get; set; }
            public string Table { get; set; }

            public Restaurant(DateTime date, string time, string name, string table)
            {
                Date = date.ToString("yyyy/MM/dd");
                Time = time;
                Name = name;
                Table = table;
            }
        }
    }
}
