using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace LuxStore7.Models
{
    public class MealCategory
    {
        public virtual int  Id { get; set; }

        [DisplayName("Meal Category")]
        public virtual string  Name { get; set; }
        public virtual List<Product> Products { get; set; }
    }
}