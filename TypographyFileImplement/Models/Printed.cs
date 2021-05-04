using System;
using System.Collections.Generic;
using System.Text;

namespace TypographyFileImplement.Models
{
    public class Printed
    {
        public int Id { get; set; }
        public string PrintedName { get; set; }
        public decimal Price { get; set; }
        public Dictionary<int, int> PrintedComponents { get; set; }
    }
}
