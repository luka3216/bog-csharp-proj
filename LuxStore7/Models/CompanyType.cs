using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace LuxStore7.Models
{
    public class CompanyType
    {
        public virtual int Id { get; set; }
        [DisplayName("Company Type")]
        public virtual string Name { get; set; }
        public virtual List<Company> Companies { get; set; }
    }
}