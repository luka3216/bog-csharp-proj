using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace LuxStore7.Models
{
    public class LuxStore7DB8 : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public LuxStore7DB8() : base("name=LuxStore7DB8")
        {
            Database.SetInitializer(new DBInitalizer());
        }

        public System.Data.Entity.DbSet<LuxStore7.Models.Company> Companies { get; set; }

        public System.Data.Entity.DbSet<LuxStore7.Models.CompanyType> CompanyTypes { get; set; }

        public System.Data.Entity.DbSet<LuxStore7.Models.Comment> Comments { get; set; }

        public System.Data.Entity.DbSet<LuxStore7.Models.Product> Products { get; set; }

        public System.Data.Entity.DbSet<LuxStore7.Models.MealCategory> MealCategories { get; set; }

        public System.Data.Entity.DbSet<LuxStore7.Models.ProductCategory> ProductCategories { get; set; }
    }
}
