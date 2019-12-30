using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeShop.DTO
{
    public class FoodCategoryDTO
    {
        public FoodCategoryDTO(int IDCATEGORY,string CATEGORYNAME)
        {
            this.IdCategory = IDCATEGORY;
            this.CategoryName = CATEGORYNAME;
        }

        public FoodCategoryDTO(DataRow row)
        {
            this.IdCategory = (int)row["IDCATEGORY"];
            this.CategoryName = row["CategoryName"].ToString();
        }
        private int idCategory;
        private string categoryName;

        public int IdCategory { get => idCategory; set => idCategory = value; }
        public string CategoryName { get => categoryName; set => categoryName = value; }
    }
}
