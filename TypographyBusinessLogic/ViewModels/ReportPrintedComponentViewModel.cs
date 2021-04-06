using System;
using System.Collections.Generic;
using System.Text;

namespace TypographyBusinessLogic.ViewModels
{
    public class ReportPrintedComponentViewModel
    {
        public string PrintedName { get; set; }
        public int TotalCount { get; set; }
        public List<Tuple<string, int>> PrintedComponents { get; set; }
    }
}
