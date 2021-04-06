using TypographyBusinessLogic.BindingModels;
using TypographyBusinessLogic.HelperModels;
using TypographyBusinessLogic.Interfaces;
using TypographyBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TypographyBusinessLogic.BusinessLogics
{
    public class ReportLogic
    {
        private readonly IComponentStorage _componentStorage;
        private readonly IPrintedStorage _printedStorage;
        private readonly IOrderStorage _orderStorage;
        public ReportLogic(IPrintedStorage printedStorage, IComponentStorage
       componentStorage, IOrderStorage orderStorage)
        {
            _printedStorage = printedStorage;
            _componentStorage = componentStorage;
            _orderStorage = orderStorage;
        }
        /// <summary>
        /// Получение списка компонент с указанием, в каких изделиях используются
        /// </summary>
        /// <returns></returns>104
        public List<ReportPrintedComponentViewModel> GetPrintedComponent()
        {
            var components = _componentStorage.GetFullList();
            var printeds = _printedStorage.GetFullList();
            var list = new List<ReportPrintedComponentViewModel>();
            foreach (var printed in printeds)
            {
                var record = new ReportPrintedComponentViewModel
                {
                    PrintedComponents = new List<Tuple<string, int>>(),
                    TotalCount = 0,
                    PrintedName = printed.PrintedName
                };
                foreach (var component in components)
                {
                    if (printed.PrintedComponents.ContainsKey(component.Id))
                    {
                        record.PrintedComponents.Add(new Tuple<string, int>(component.ComponentName, printed.PrintedComponents[component.Id].Item2));
                        record.TotalCount += printed.PrintedComponents[component.Id].Item2;
                    }
                }
                list.Add(record);
            }
            return list;
        }
        /// <summary>
        /// Получение списка заказов за определенный период
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<ReportOrdersViewModel> GetOrders(ReportBindingModel model)
        {
            return _orderStorage.GetFilteredList(new OrderBindingModel
            {
                DateFrom =
           model.DateFrom,
                DateTo = model.DateTo
            })
            .Select(x => new ReportOrdersViewModel
            {
                DateCreate = x.DateCreate,
                PrintedName = x.PrintedName,
                Count = x.Count,
                Sum = x.Sum,
                Status = x.Status
            })
           .ToList();
        }
        /// <summary>
        /// Сохранение компонент в файл-Word
        /// </summary>
        /// <param name="model"></param>
        public void SavePrintedsToWordFile(ReportBindingModel model)
        {
            SaveToWord.CreateDoc(new WordInfo
            {
                FileName = model.FileName,
                Title = "Список изделий",
                Printeds = _printedStorage.GetFullList()
            });
        }
        /// <summary>
        /// Сохранение компонент с указаеним продуктов в файл-Excel
        /// </summary>
        /// <param name="model"></param>
        public void SavePrintedComponentToExcelFile(ReportBindingModel model)
        {
            SaveToExcel.CreateDoc(new ExcelInfo
            {
                FileName = model.FileName,
                Title = "Список изделий",
                PrintedComponents = GetPrintedComponent()
            });
        }
        /// <summary>
        /// Сохранение заказов в файл-Pdf
        /// </summary>
        /// <param name="model"></param>
        public void SaveOrdersToPdfFile(ReportBindingModel model)
        {
            SaveToPdf.CreateDoc(new PdfInfo
            {
                FileName = model.FileName,
                Title = "Список заказов",
                DateFrom = model.DateFrom.Value,
                DateTo = model.DateTo.Value,
                Orders = GetOrders(model)
            });
        }

    }
}
