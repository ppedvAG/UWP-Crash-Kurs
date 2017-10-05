using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App1
{
    
    public class Rootobject
    {
        public List<Customer> Customers { get; set; }
        public Responsestatus ResponseStatus { get; set; }
    }

    public class Responsestatus
    {
    }

    public class Customer
    {
        public string Id { get; set; }
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string ContactTitle { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string Region { get; set; }
    }

}
