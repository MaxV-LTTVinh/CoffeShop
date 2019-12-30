using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeShop.DTO
{
    public class BillDetailsDTO
    {
        public BillDetailsDTO(int IDBILLDETAIL,int IDBILL,int IDFOOD,int COUNT)
        {
            this.IdBill = IDBILL;
            this.IdBillDetail = IDBILLDETAIL;
            this.IdFood = IDFOOD;
            this.Count = COUNT;
        }

        public BillDetailsDTO(DataRow row)
        {
            this.IdBill = (int)row["IDBILL"];
            this.IdBillDetail = (int)row["IDBILLDETAIL"];
            this.IdFood = (int)row["IDFOOD"];
            this.Count = (int)row["COUNT"];
        }

        private int idBillDetail;
        private int idBill;
        private int idFood;
        private int count;


        public int IdBillDetail { get => idBillDetail; set => idBillDetail = value; }
        public int IdBill { get => idBill; set => idBill = value; }
        public int IdFood { get => idFood; set => idFood = value; }
        public int Count { get => count; set => count = value; }
    }
}
