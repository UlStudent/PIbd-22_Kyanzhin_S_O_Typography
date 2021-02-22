using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace TypographyBusinessLogic.ViewModels
{
    public class PrintedViewModel
    {
        public int Id { get; set; }
        [DisplayName("Название изделия")]
        public string ProductName { get; set; }
        [DisplayName("Цена")]
        public decimal Price { get; set; }
        public Dictionary<int, (string, int)> ProductComponents { get; set; }

    }
}
