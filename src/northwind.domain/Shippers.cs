using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace northwind.domain
{
    public class Shippers
    {
        public virtual int ShipperID { get; set; }
        public virtual string CompanyName { get; set; }
        public virtual string Phone { get; set; }
    }
}
