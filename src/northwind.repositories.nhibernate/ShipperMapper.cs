using FluentNHibernate.Mapping;
using northwind.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace northwind.repositories.nhibernate
{
    public class ShipperMapper : ClassMap<Shipper>
    {
        public ShipperMapper()
        {
            Table("Shippers");
            Id(x => x.ShipperID).GeneratedBy.Increment();
            Map(x => x.CompanyName);
            Map(x => x.Phone);
        }
    }
}
