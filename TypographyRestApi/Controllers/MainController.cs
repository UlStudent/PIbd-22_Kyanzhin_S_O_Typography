using TypographyBusinessLogic.BindingModels;
using TypographyBusinessLogic.BusinessLogics;
using TypographyBusinessLogic.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;


namespace TypographyRestApi
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MainController : ControllerBase
    {
        private readonly OrderLogic _order;
        private readonly PrintedLogic _Printed;
        private readonly OrderLogic _main;
        public MainController(OrderLogic order, PrintedLogic printed, OrderLogic main)
        {
            _order = order;
            _Printed = printed;
            _main = main;
        }
        [HttpGet]
        public List<PrintedViewModel> GetPrintedList() => _Printed.Read(null)?.ToList();
        [HttpGet]
        public PrintedViewModel GetPrinted(int PrintedId) => _Printed.Read(new PrintedBindingModel { Id = PrintedId })?[0];
        [HttpGet]
        public List<OrderViewModel> GetOrders(int clientId) => _order.Read(new OrderBindingModel { ClientId = clientId });
        [HttpPost]
        public void CreateOrder(CreateOrderBindingModel model) => _main.CreateOrder(model);
    }

}
