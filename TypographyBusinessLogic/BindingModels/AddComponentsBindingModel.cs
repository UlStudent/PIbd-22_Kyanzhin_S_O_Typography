using System;
using System.Collections.Generic;
using System.Text;

namespace TypographyBusinessLogic.BindingModels
{
    public class AddComponentsBindingModel
    {
        public int WarehouseId { get; set; }

        public int ComponentId { get; set; }

        public int Count { get; set; }
    }
}
