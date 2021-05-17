using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using TypographyBusinessLogic.Attributes;

namespace TypographyBusinessLogic.ViewModels
{
    public class ComponentViewModel
    {
        [Column(title: "Номер", width: 100)]
        public int Id { get; set; }
        [Column(title: "Название компонента", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string ComponentName { get; set; }

    }
}
