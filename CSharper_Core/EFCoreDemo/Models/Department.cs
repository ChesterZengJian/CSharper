using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreDemo.Models
{
    [Table("Department")]
    public class Department
    {
        public int Id { get; set; }
    }
}