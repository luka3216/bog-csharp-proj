using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace LuxStore7.Models
{
    public class Product
    {
        public virtual int Id { get; set; }
        public virtual int CompanyId { get; set; }
        public virtual Company Company { get; set; }
        public virtual string Name { get; set; }
        [DisplayName("Preparation time")]
        public virtual int PrepTime { get; set; }
        [DisplayName("Product Category")]
        public virtual int ProductCategoryId { get; set; }
        public virtual ProductCategory ProductCategory { get; set; }
        [DisplayName("Meal Category")]
        public virtual int MealCategoryId { get; set; }
        public virtual MealCategory MealCategory { get; set; }
        public virtual float Price { get; set; }
    }
}