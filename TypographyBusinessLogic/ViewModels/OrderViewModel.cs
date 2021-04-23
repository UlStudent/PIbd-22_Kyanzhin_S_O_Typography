using System;
using System.ComponentModel;
using TypographyBusinessLogic.Enums;
using System.Runtime.Serialization;

namespace TypographyBusinessLogic.ViewModels
{
    [DataContract]
    public class OrderViewModel
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int ClientId { get; set; }
        [DataMember]
        [DisplayName("Клиент")]
        public string ClientFIO { get; set; }
        [DataMember]
        public int PrintedId { get; set; }
        [DataMember]
        [DisplayName("Изделие")]
        public string PrintedName { get; set; }
        [DataMember]
        [DisplayName("Количество")]
        public int Count { get; set; }
        [DataMember]
        [DisplayName("Сумма")]
        public decimal Sum { get; set; }
        [DataMember]
        [DisplayName("Статус")]
        public OrderStatus Status { get; set; }
        [DataMember]
        [DisplayName("Дата создания")]
        public DateTime DateCreate { get; set; }
        [DataMember]
        [DisplayName("Дата выполнения")]
        public DateTime? DateImplement { get; set; }
        [DataMember]
        public int? ImplementerId { get; set; }
        [DataMember]
        [DisplayName("Исполнитель")]
        public string ImplementerFIO { get; set; }
    }
}