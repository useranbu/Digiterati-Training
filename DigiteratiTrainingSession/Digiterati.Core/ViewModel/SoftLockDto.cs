using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.ViewModel
{
    public class SoftLockDto
    {
        public int LockId { get; set; }
        public int Employee_id { get; set; }
        public string Manager { get; set; }
        public DateTime ReqDate { get; set; }
        public string Status { get; set; }
        public DateTime Lastupdated { get; set; }
        public string ReqMessage { get; set; }
        public string WfmRemark { get; set; }
        public string ManagerStatus { get; set; }
        public string MgrStatusComment { get; set; }
        public DateTime MgrLastUpdate { get; set; }


    }
}
