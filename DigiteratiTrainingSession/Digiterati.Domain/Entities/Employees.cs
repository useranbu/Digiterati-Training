using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digiterati.Domain.Entities
{
    public class Employees
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [Column("employeeId")]
        public int EmployeeID { get; set; }

        [Column("employeeName")]
        [StringLength(50, MinimumLength = 2)]
        public string EmployeeName { get; set; }

        [Column("status")]
        [StringLength(50)]
        public string Status { get; set; }

        [Column("manager")]
        [StringLength(30)]
        public string? Manager { get; set; }

        [Column("wfmManager")]
        [StringLength(30)]
        public string? WfmManager { get; set; }

        [Column("email")]
        public string? Email { get; set; }

        [Column("lockStatus")]
        [StringLength(30)]
        public string? LockStatus { get; set; }

        [Column("experience")]
        [RegularExpression(@"^\d+(\.\d{1,2})?$")]
        public Double? Experience { get; set; }

        [Column("profileId")]
        public int? ProfileId { get; set; }

    }
}
