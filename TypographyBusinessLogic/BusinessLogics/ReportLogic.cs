using TypographyBusinessLogic.BindingModels;
using TypographyBusinessLogic.HelperModels;
using TypographyBusinessLogic.Interfaces;
using TypographyBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TypographyBusinessLogic.BusinessLogics
{
    public class ReportLogic
    {
        private readonly IPrintedStorage _printedStorage;
        private readonly IOrderStorage _orderStorage;
        private readonly IComponentStorage _componentStorage;
        private readonly IWarehouseStorage _warehouseStorage;
        public ReportLogic(IPrintedStorage printedStorage, IOrderStorage orderStorage, IComponentStorage componentStorage, IWarehouseStorage warehouseStorage)
        {
            _printedStorage = printedStorage;
            _orderStorage = orderStorage;
            _componentStorage = componentStorage;
            _warehouseStorage = warehouseStorage;
        }
        /// <summary>
        /// Получение списка компонент с указанием, в каких изделиях используются
        /// </summary>
        /// <returns></returns>
        public List<ReportPrintedComponentViewModel> GetPrintedComponent()
        {
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
                foreach (var component in printed.PrintedComponents)
                {
                    record.PrintedComponents.Add(new Tuple<string, int>(component.Value.Item1, component.Value.Item2));
                    record.TotalCount += component.Value.Item2;
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
                DateFrom = model.DateFrom,
                DateTo = model.DateTo
            }).Select(x => new ReportOrdersViewModel
            {
                DateCreate = x.DateCreate,
                PrintedName = x.PrintedName,
                Count = x.Count,
                Sum = x.Sum,
                Status = x.Status
            }).ToList();
        }

        public List<ReportWarehouseComponentViewModel> GetWarehouseComponent()
        {
            var warehouses = _warehouseStorage.GetFullList();
            var list = new List<ReportWarehouseComponentViewModel>();
            foreach (var warehouse in warehouses)
            {
                var record = new ReportWarehouseComponentViewModel
                {
                    WarehouseName = warehouse.WarehouseName,
                    Components = new List<Tuple<string, int>>(),
                    TotalCount = 0
                };
                foreach (var component in warehouse.WarehouseComponents)
                {
                    record.Components.Add(new Tuple<string, int>(component.Value.Item1, component.Value.Item2));
                    record.TotalCount += component.Value.Item2;
                }
                list.Add(record);
            }
            return list;
        }
        public List<ReportOrdersAllDatesViewModel> GetOrdersForAllDates()
        {
            return _orderStorage.GetFullList()
                .GroupBy(order => order.DateCreate.ToShortDateString())
                .Select(rec => new ReportOrdersAllDatesViewModel
                {
                    Date = Convert.ToDateTime(rec.Key),
                    Count = rec.Count(),
                    Sum = rec.Sum(order => order.Sum)
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
        public void SavePrintedToExcelFile(ReportBindingModel model)
        {
            SaveToExcel.CreateDoc(new ExcelInfo
            {
                FileName = model.FileName,
                Title = "Список изделий по компонентами",
                PrintedComponents = GetPrintedComponent()
            });
        }

        /// <summary>
        /// Сохранение заказов в файл-Pdf
        /// </summary>
        /// <param name="model"></param>
        [Obsolete]
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
        public void SaveWarehousesToWordFile(ReportBindingModel model)
        {
            SaveToWord.CreateDocWarehouse(new WordInfoWarehouse
            {
                FileName = model.FileName,
                Title = "Список складов",
                Warehouses = _warehouseStorage.GetFullList()
            });
        }
        public void SaveWarehousesComponentsToExcelFile(ReportBindingModel model)
        {
            SaveToExcel.CreateDocWarehouse(new ExcelInfoWarehouse
            {
                FileName = model.FileName,
                Title = "Список складов",
                WarehouseComponents = GetWarehouseComponent()
            });
        }

        [Obsolete]
        public void SaveOrdersAllDatesToPdfFile(ReportBindingModel model)
        {
            SaveToPdf.CreateDocOrdersAllDates(new PdfInfoOrdersAllDates
            {
                FileName = model.FileName,
                Title = "Список заказов",
                Orders = GetOrdersForAllDates()
            });
        }
    }
}
