using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OraCore.Models
{
    public class OracleObject
    {
        public int Id { get; set; }
        public String Owner { get; set; }
        public String ObjectName { get; set; }
    }
}
