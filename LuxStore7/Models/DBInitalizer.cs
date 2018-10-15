using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace LuxStore7.Models
{
    public class DBInitalizer : CreateDatabaseIfNotExists<LuxStore7DB8>
    {
        protected override void Seed(LuxStore7DB8 context)
        {
            IList<CompanyType> defaultStandards = new List<CompanyType>();

            defaultStandards.Add(new CompanyType() { Name = "Fast Food" });
            defaultStandards.Add(new CompanyType() { Name = "Georgian" });
            defaultStandards.Add(new CompanyType() { Name = "European" });
            context.CompanyTypes.AddRange(defaultStandards);

            IList<MealCategory> MealCategorys = new List<MealCategory>();

            MealCategorys.Add(new MealCategory() { Name = "Doughs" });
            MealCategorys.Add(new MealCategory() { Name = "Sauce" });
            MealCategorys.Add(new MealCategory() { Name = "Hot Meal" });
            context.MealCategories.AddRange(MealCategorys);

            IList<ProductCategory> pr = new List<ProductCategory>();

            pr.Add(new ProductCategory() { Name = "Khachapuri" });
            pr.Add(new ProductCategory() { Name = "Khinkali" });
            pr.Add(new ProductCategory() { Name = "Pizza" });
            context.ProductCategories.AddRange(pr);
            base.Seed(context);
        }
    }
}