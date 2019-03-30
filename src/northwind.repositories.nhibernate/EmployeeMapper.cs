using FluentNHibernate.Mapping;
using northwind.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace northwind.repositories.nhibernate
{
    public class EmployeeMapper : ClassMap<Employee>
    {
        public EmployeeMapper()
        {
            Table("Employees");
            Id(x => x.EmployeeID).GeneratedBy.Native();
            Map(x => x.LastName);
            Map(x => x.FirstName);
            Map(x => x.Title);
            Map(x => x.TitleOfCourtesy);
            Map(x => x.BirthDate);
            Map(x => x.HireDate);
            Map(x => x.Address);
            Map(x => x.City);
            Map(x => x.Region);
            Map(x => x.PostalCode);
            Map(x => x.Country);
            Map(x => x.HomePhone);
            Map(x => x.Extension);
            Map(x => x.Notes);
            Map(x => x.PhotoPath);
            References(x => x.ReportsTo, "ReportsTo");
        }
    }
}
