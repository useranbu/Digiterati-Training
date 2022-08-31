using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digiterati.Domain.Entities
{
    public class SkillMap
    {
        [Key]
        [Column("employeeId")]
        public int EmployeeID { get; set; }
        public Employees? Employees { get; set; }
        [Column("skillId")]
        public int SkillId { get; set; }
        public Skills? Skills { get; set; }

    }
}
