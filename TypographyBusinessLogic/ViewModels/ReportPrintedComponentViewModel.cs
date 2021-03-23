using System;
using System.Collections.Generic;
using System.Text;

namespace TypographyBusinessLogic.ViewModels
{
    public class ReportPrintedComponentViewModel
    {
        public string ComponentName { get; set; }
        public int TotalCount { get; set; }
        public List<Tuple<string, int>> Printed { get; set; }
    }
}
