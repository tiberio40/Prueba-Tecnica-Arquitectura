using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class UnitsByLocationModel
    {
        public decimal Active { get; set; }
        public decimal Reserve { get; set; }
        public decimal NotStored { get; set; }
    }
}
