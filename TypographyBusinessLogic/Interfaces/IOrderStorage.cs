using System;
using System.Collections.Generic;
using System.Text;
using TypographyBusinessLogic.BindingModels;
using TypographyBusinessLogic.ViewModels;

namespace TypographyBusinessLogic.Interfaces
{
    public interface IOrderStorage
    {
        List<OrderViewModel> GetFullList();
        List<OrderViewModel> GetFilteredList(OrderBindingModel model);
        OrderViewModel GetElement(OrderBindingModel model);
        void Insert(OrderBindingModel model);
        void Update(OrderBindingModel model);
        void Delete(OrderBindingModel model);

    }
}
