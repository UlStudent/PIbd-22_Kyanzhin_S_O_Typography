using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TypographyDatabaseImplement.Models
{
    /// <summary>
    /// Самолеты, изготавливаемые на заводе
    /// </summary>
    public class Printed
    {
        public int Id { get; set; }
        [Required]
        public string PrintedName { get; set; }
        [Required]
        public decimal Price { get; set; }
        [ForeignKey("PrintedId")]
        public virtual List<PrintedComponent> PrintedComponents { get; set; }
        [ForeignKey("PrintedId")]
        public virtual List<Order> Orders { get; set; }
    }
}
