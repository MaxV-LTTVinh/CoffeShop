using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeShop.DTO
{
    public class BillDTO
    {
        public BillDTO(int IDBILL, DateTime? dateCheckIn, string timeCheckIn, string timeCheckOut, int status, int totalPrice, int idTable, string userName, int DISCOUNT)
        {
            this.IdBill = IDBILL;
            this.DateCheckIn = dateCheckIn;
            this.TimeCheckIn = timeCheckIn;
            this.TimeCheckOut = timeCheckOut;
            this.Status = status;
            this.TotalPrice = totalPrice;
            this.IdTable = idTable;
            this.UserName = userName;
            this.Discount = DISCOUNT;
        }

        public BillDTO(DataRow rows)
        {
            this.IdBill = (int)rows["IDBILL"];
            this.DateCheckIn = (DateTime?)rows["DateCheckIn"];

            var timeCheckInTemp = rows["timeCheckIn"].ToString();
            if (timeCheckInTemp.ToString() != "")
                this.TimeCheckIn = timeCheckInTemp;

            var timeCheckOutTemp = rows["timeCheckOut"].ToString();
            if (timeCheckOutTemp.ToString() != "")
                this.TimeCheckOut = timeCheckOutTemp;

            this.Status = (int)rows["status"];
            this.TotalPrice = (int)rows["totalPrice"];
            this.IdTable = (int)rows["idTable"];
            this.UserName = rows["userName"].ToString();
            this.Discount = (int)rows["DISCOUNT"];
        }

        private int idBill;
        private DateTime? dateCheckIn;
        private string timeCheckIn;
        private string timeCheckOut;
        private int status;
        private int totalPrice;
        private int idTable;
        private string userName;
        private int discount;

        public int IdBill { get => idBill; set => idBill = value; }
        public int Status { get => status; set => status = value; }
        public DateTime? DateCheckIn { get => dateCheckIn; set => dateCheckIn = value; }
        public string TimeCheckIn { get => timeCheckIn; set => timeCheckIn = value; }
        public string TimeCheckOut { get => timeCheckOut; set => timeCheckOut = value; }
        public int TotalPrice { get => totalPrice; set => totalPrice = value; }
        public int IdTable { get => idTable; set => idTable = value; }
        public string UserName { get => userName; set => userName = value; }
        public int Discount { get => discount; set => discount = value; }
    }
}
