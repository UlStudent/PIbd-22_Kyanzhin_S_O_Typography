using System;
using System.Collections.Generic;
using System.Text;
using TypographyBusinessLogic.BindingModels;
using TypographyBusinessLogic.ViewModels;

namespace TypographyBusinessLogic.Interfaces
{
    public interface IPrintedStorage
    {
        List<PrintedViewModel> GetFullList();
        List<PrintedViewModel> GetFilteredList(PrintedBindingModel model);
        PrintedViewModel GetElement(PrintedBindingModel model);
        void Insert(PrintedBindingModel model);
        void Update(PrintedBindingModel model);
        void Delete(PrintedBindingModel model);
    }
}
