using TypographyBusinessLogic.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace TypographyBusinessLogic.ViewModels
{
    public class ReportOrdersViewModel
    {
        public DateTime DateCreate { get; set; }
        public string PrintedName { get; set; }
        public int Count { get; set; }
        public decimal Sum { get; set; }
        public OrderStatus Status { get; set; }
    }
}
