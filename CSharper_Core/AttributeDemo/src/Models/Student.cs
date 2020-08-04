using AttributeDemo.Attributes;

namespace AttributeDemo.Models
{
    public class Student
    {
        [Required]
        public string Id { get; set; }
        [Validate(2)]
        public string Name { get; set; }
    }
}