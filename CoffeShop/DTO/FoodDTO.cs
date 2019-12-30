using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeShop.DTO
{
    public class FoodDTO
    {
        public FoodDTO(int ID,string FOODNAME, int IDCATEGORY,int PRICE)
        {
            this.id = ID;
            this.foodName = FOODNAME;
            this.idCategory = IDCATEGORY;
            this.price = PRICE;
        }

        public  FoodDTO(DataRow row)
        {
            this.id = (int)row["idFood"];
            this.foodName = row["FOODNAME"].ToString();
            this.idCategory = (int)row["IDCATEGORY"];
            this.price = Convert.ToInt32(row["PRICE"].ToString());
        }
           
        private int id;
        private string foodName;
        private int idCategory;
        private int price;

        public int Id { get => id; set => id = value; }
        public string FoodName { get => foodName; set => foodName = value; }
        public int IdCategory { get => idCategory; set => idCategory = value; }
        public int Price { get => price; set => price = value; }
    }
}
