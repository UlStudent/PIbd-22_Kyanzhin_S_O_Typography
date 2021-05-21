using System;
using System.Collections.Generic;
using TypographyBusinessLogic.ViewModels;

namespace TypographyBusinessLogic.HelperModels
{
    class ExcelInfo
    {
        public string FileName { get; set; }
        public string Title { get; set; }
        public List<ReportPrintedComponentViewModel> PrintedComponents { get; set; }

    }
}
