using System;
using System.Collections.Generic;
using System.Text;

namespace TypographyBusinessLogic.BindingModels
{
    public class CreateOrderBindingModel
    {
        public int PrintedId { get; set; }
        public int Count { get; set; }
        public decimal Sum { get; set; }
    }
}
