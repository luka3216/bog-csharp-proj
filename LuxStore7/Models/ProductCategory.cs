using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace LuxStore7.Models
{
    public class ProductCategory
    {
        public virtual int Id { get; set; }

        [DisplayName("Product Category")]
        public virtual string Name { get; set; }
    }
}