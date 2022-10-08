using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digiterati.Domain.Entities
{
    public class Users
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("userName")]
        public string UserName { get; set; }

        [Column("password")]
        public string Password { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("role")]
        public string Role { get; set; }

        [Column("email")]
        public string? Email { get; set; }
    }
}
