using System.ComponentModel.DataAnnotations;

namespace TypographyDatabaseImplement.Models
{
    public class PrintedComponent
    {
        public int Id { get; set; }
        public int PrintedId { get; set; }
        public int ComponentId { get; set; }
        [Required]
        public int Count { get; set; }
        public virtual Component Component { get; set; }
        public virtual Printed Printed { get; set; }
    }
}
