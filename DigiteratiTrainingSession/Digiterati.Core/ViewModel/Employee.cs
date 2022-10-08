using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.ViewModel
{
    public class Employee
    {
        [Key]
        public int Employee_Id { get; set; }
        public string Name { get; set; }
        public string status { get; set; }
        public string Manager { get;set; }
        public string wfm_manager { get; set; }
        public string Email { get; set; }
        public string lockstatus { get; set; }
        [Column(TypeName = "decimal(18, 6)")]
        public int Experience { get; set; }

        [NotMapped]
        public List<string> Skills { get; set; }

        public int profile_Id { get; set; }
    }
}
