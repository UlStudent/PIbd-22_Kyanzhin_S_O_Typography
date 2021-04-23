using System;
using System.Collections.Generic;
using System.Text;
using TypographyBusinessLogic.BindingModels;
using TypographyBusinessLogic.ViewModels;

namespace TypographyBusinessLogic.Interfaces
{
    public interface IImplementerStorage
    {
        List<ImplementerViewModel> GetFullList();
        List<ImplementerViewModel> GetFilteredList(ImplementerBindingModel model);
        ImplementerViewModel GetElement(ImplementerBindingModel model);
        void Insert(ImplementerBindingModel model);
        void Update(ImplementerBindingModel model);
        void Delete(ImplementerBindingModel model);

    }
}
