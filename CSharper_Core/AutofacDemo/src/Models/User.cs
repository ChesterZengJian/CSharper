namespace AutofacDemo.Models
{
    public class User
    {
        public string Name { get; set; }

        public override string ToString()
        {
            return $"Name is {Name}";
        }
    }
}
