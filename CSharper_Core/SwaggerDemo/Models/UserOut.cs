using Newtonsoft.Json;
using System.Diagnostics.CodeAnalysis;

namespace SwaggerDemo.Models
{
    public class UserOut
    {
        public int Id { get; set; }
        public Address Address { get; set; }
    }
}