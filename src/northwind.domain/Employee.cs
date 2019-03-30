using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace northwind.domain
{
    public class Employee
    {
        public virtual int EmployeeID { get; set; }
        public virtual string LastName { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string Title { get; set; }
        public virtual string TitleOfCourtesy { get; set; }
        public virtual DateTime BirthDate { get; set; } = DateTime.Now;
        public virtual DateTime HireDate { get; set; } = DateTime.Now;
        public virtual string Address { get; set; }
        public virtual string City { get; set; }
        public virtual string Region { get; set; }
        public virtual string PostalCode { get; set; }
        public virtual string Country { get; set; }
        public virtual string HomePhone { get; set; }
        public virtual string Extension { get; set; }
        public virtual string Photo { get; set; }
        public virtual string Notes { get; set; }
        public virtual Employee ReportsTo { get; set; }
        public virtual string PhotoPath { get; set; }
    }
}
