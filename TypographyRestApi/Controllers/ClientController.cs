﻿using TypographyBusinessLogic.BindingModels;
using TypographyBusinessLogic.BusinessLogics;
using TypographyBusinessLogic.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace TypographyRestApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ClientController : ControllerBase
    {

        private readonly ClientLogic _logic;
        public ClientController(ClientLogic logic)
        {
            _logic = logic;
        }
        [HttpGet]
        public ClientViewModel Login(string login, string password)
        {
            var client = _logic.Read(new ClientBindingModel
            {
                Email = login,
                Password = password
            });
            return (client != null && client.Count > 0) ? client[0] : null;
        }
        [HttpPost]
        public void Register(ClientBindingModel model) => _logic.CreateOrUpdate(model);
        [HttpPost]
        public void UpdateData(ClientBindingModel model) => _logic.CreateOrUpdate(model);
    }
}
