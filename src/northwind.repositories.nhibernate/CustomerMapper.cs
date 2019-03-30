using FluentNHibernate.Mapping;
using northwind.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace northwind.repositories.nhibernate
{
    public class CustomerMapper : ClassMap<Customer>
    {

        public CustomerMapper()
        {
            Table("Customers");
            Id(x => x.CustomerID).GeneratedBy.Assigned();
            Map(x => x.CompanyName);
            Map(x => x.ContactName);
            Map(x => x.ContactTitle);
            Map(x => x.Address);
            Map(x => x.City);
            Map(x => x.Region);
            Map(x => x.PostalCode);
            Map(x => x.Country);
            Map(x => x.Phone);
            Map(x => x.Fax);
        }
    }
}
