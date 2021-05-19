using System.Collections.Generic;
using TypographyBusinessLogic.BindingModels;
using TypographyBusinessLogic.ViewModels;

namespace TypographyBusinessLogic.Interfaces
{
    public interface IMessageInfoStorage
    {
        List<MessageInfoViewModel> GetFullList();
        List<MessageInfoViewModel> GetFilteredList(MessageInfoBindingModel model);
        void Insert(MessageInfoBindingModel model);
    }
}
