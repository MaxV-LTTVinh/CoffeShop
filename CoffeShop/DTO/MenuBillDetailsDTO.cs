using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeShop.DTO
{
    public  class MenuBillDetailsDTO
    {
        public  MenuBillDetailsDTO(int IDFOOD, string NAME,int COUNT, int PRICE,int TOTALPRICE)
        {
            this.IdFood = IDFOOD;
            this.NameFood = NAME;
            this.Count = count;
            this.Price = PRICE;
            this.TotalPrice = TOTALPRICE;
        }

        public  MenuBillDetailsDTO(DataRow row)
        {
            this.IdFood = (int)row["idFood"];
            this.NameFood = row["FoodName"].ToString();
            this.Count = (int)row["Count"];
            this.Price = (int)row["Price"];
            this.TotalPrice = (int)row["TTprice"];
        }

        private int idFood;
        private string nameFood;
        private int count;
        private int price;
        private int totalPrice;

        public string NameFood { get => nameFood; set => nameFood = value; }
        public int Count { get => count; set => count = value; }
        public int Price { get => price; set => price = value; }
        public int TotalPrice { get => totalPrice; set => totalPrice = value; }
        public int IdFood { get => idFood; set => idFood = value; }
    }
}
