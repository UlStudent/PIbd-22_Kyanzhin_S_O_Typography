﻿using System.Collections.Generic;
using TypographyBusinessLogic.ViewModels;

namespace TypographyBusinessLogic.HelperModels
{
    class WordInfo
    {
        public string FileName { get; set; }
        public string Title { get; set; }
        public List<PrintedViewModel> Printeds { get; set; }
    }
}
