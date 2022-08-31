using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digiterati.Domain.Entities
{
    public class Skills
    {
        [Key]
        [Column("skillId")]
        public int SkillId { get; set; }

        [Column("skillName")]
        public string SkillName { get; set; }

        public ICollection<SkillMap> SkillMaps { get; set; }
    }
}
