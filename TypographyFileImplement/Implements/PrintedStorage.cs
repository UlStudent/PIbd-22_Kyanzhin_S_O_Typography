using TypographyBusinessLogic.BindingModels;
using TypographyBusinessLogic.Interfaces;
using TypographyBusinessLogic.ViewModels;
using TypographyFileImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TypographyFileImplement.Implements
{
    public class PrintedStorage : IPrintedStorage
    {
        private readonly FileDataListSingleton source;
        public PrintedStorage()
        {
            source = FileDataListSingleton.GetInstance();
        }
        public List<PrintedViewModel> GetFullList()
        {
            return source.Printeds.Select(CreateModel).ToList();
        }
        public List<PrintedViewModel> GetFilteredList(PrintedBindingModel model)
        {
            if (model == null) return null;

            return source.Printeds.Where(rec => rec.PrintedName.Contains(model.PrintedName))
            .Select(CreateModel)
            .ToList();
        }
        public PrintedViewModel GetElement(PrintedBindingModel model)
        {
            if (model == null) return null;

            var printed = source.Printeds
            .FirstOrDefault(rec => rec.PrintedName == model.PrintedName || rec.Id == model.Id);
            return printed != null ? CreateModel(printed) : null;
        }
        public void Insert(PrintedBindingModel model)
        {
            int maxId = source.Printeds.Count > 0 ? source.Components.Max(rec => rec.Id) : 0;
            var element = new Printed
            {
                Id = maxId + 1,
                PrintedComponents = new Dictionary<int, int>()
            };
            source.Printeds.Add(CreateModel(model, element));
        }
        public void Update(PrintedBindingModel model)
        {
            var element = source.Printeds.FirstOrDefault(rec => rec.Id == model.Id);

            if (element == null) throw new Exception("Элемент не найден");
            
            CreateModel(model, element);
        }
        public void Delete(PrintedBindingModel model)
        {
            Printed element = source.Printeds.FirstOrDefault(rec => rec.Id == model.Id);
            if (element != null)
            {
                source.Printeds.Remove(element);
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }
        private Printed CreateModel(PrintedBindingModel model, Printed printed)
        {
            printed.PrintedName = model.PrintedName;
            printed.Price = model.Price;
            // удаляем убранные
            foreach (var key in printed.PrintedComponents.Keys.ToList())
            {
                if (!model.PrintedComponents.ContainsKey(key))
                {
                    printed.PrintedComponents.Remove(key);
                }
            }
            // обновляем существуюущие и добавляем новые
            foreach (var component in model.PrintedComponents)
            {
                if (printed.PrintedComponents.ContainsKey(component.Key))
                {
                    printed.PrintedComponents[component.Key] = model.PrintedComponents[component.Key].Item2;
                }
                else
                {
                    printed.PrintedComponents.Add(component.Key,model.PrintedComponents[component.Key].Item2);
                }
            }
            return printed;
        }
        private PrintedViewModel CreateModel(Printed printed)
        {
            return new PrintedViewModel
            {
                Id = printed.Id,
                PrintedName = printed.PrintedName,
                Price = printed.Price,
                PrintedComponents = printed.PrintedComponents
                .ToDictionary(recPC => recPC.Key, recPC =>
                (source.Components.FirstOrDefault(recC => recC.Id == recPC.Key)?.ComponentName, recPC.Value))
            };
        }
    }

}
