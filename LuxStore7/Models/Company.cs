using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace LuxStore7.Models
{
    public class Company
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual string logo { get; set; }

        [DisplayName("Company Tyoe")]
        public virtual int CompanyTypeId { get; set; }
        public virtual CompanyType CompanyType { get; set; }
        public virtual string Cost { get; set; }
        public virtual List<Comment> Comments { get; set; }
        public virtual List<Product> Products { get; set; }
    }
}