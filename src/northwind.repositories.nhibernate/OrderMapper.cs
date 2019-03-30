using FluentNHibernate.Mapping;
using northwind.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace northwind.repositories.nhibernate
{
    public class OrderMapper : ClassMap<Order>
    {

        public OrderMapper()
        {
            Table("Orders");
            Id(x => x.OrderID).GeneratedBy.Increment();
            References(x => x.Customer, "CustomerID");
            References(x => x.Employee, "EmployeeID");
            Map(x => x.OrderDate);
            Map(x => x.RequiredDate);
            Map(x => x.ShippedDate);
            References(x => x.ShipVia, "ShipVia");
            Map(x => x.Freight);
            Map(x => x.ShipName);
            Map(x => x.ShipAddress);
            Map(x => x.ShipCity);
            Map(x => x.ShipRegion);
            Map(x => x.ShipPostalCode);
            Map(x => x.ShipCountry);
        }
    }
}
