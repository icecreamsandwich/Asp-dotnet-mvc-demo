using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication6.Models
{
    public partial class CustomerModel
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public IEnumerable<customer> customers { get; set; }
    }
}