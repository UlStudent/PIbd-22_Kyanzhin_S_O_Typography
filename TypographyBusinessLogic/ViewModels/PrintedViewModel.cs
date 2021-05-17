using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using TypographyBusinessLogic.Attributes;

namespace TypographyBusinessLogic.ViewModels
{
    public class PrintedViewModel
    {
        public int Id { get; set; }
        [Column(title: "Название изделия", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string PrintedName { get; set; }
        [Column(title: "Цена", width: 50)]
        public decimal Price { get; set; }
        public Dictionary<int, (string, int)> PrintedComponents { get; set; }

    }
}
