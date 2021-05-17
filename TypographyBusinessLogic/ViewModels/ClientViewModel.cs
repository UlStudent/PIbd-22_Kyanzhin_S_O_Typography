﻿using System.ComponentModel;
using System.Runtime.Serialization;
using TypographyBusinessLogic.Attributes;

namespace TypographyBusinessLogic.ViewModels
{
    [DataContract]
    public class ClientViewModel
    {
        [Column(title: "Номер", width: 100)]
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        [Column(title: "Клиент", width: 150)]
        public string FIO { get; set; }
        [DataMember]
        [Column(title: "Логин", width: 100)]
        public string Email { get; set; }
        [DataMember]
        [Column(title: "Пароль", width: 100)]
        public string Password { get; set; }
    }
}