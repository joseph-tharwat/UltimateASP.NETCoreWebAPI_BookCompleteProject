using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DTOs
{
    public record CompanyDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string FullAddress {  get; set; }
        public override string ToString()
        {
            return Id.ToString() + "," + Name + "," + FullAddress;
        }
    }

    public record CompanyForCreationDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }
        public IEnumerable<EmployeeDto> Employees { get; set; }

        public override string ToString()
        {
            return Id.ToString() + "," + Name+ ","+ Address+","+Country;
        }
    }
}
