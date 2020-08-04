using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace SwaggerDemo.Models
{
    /// <summary>
    /// One user
    /// </summary>
    public class User
    {
        public int? Id { get; set; }
        /// <summary>
        /// User name
        /// </summary>
        public string Name { get; set; }
        /// User email
        public string Email { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [AllowNull]
        public Address Address { get; set; }

        public DateTime? CreatedTime { get; set; }
    }
}
