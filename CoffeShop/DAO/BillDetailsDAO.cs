using CoffeShop.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeShop.DAO
{
    public class BillDetailsDAO
    {
        private static BillDetailsDAO instance;

        public static BillDetailsDAO Instance
        {
            get { if (instance == null) instance = new BillDetailsDAO(); return BillDetailsDAO.instance; }
            private set { BillDetailsDAO.instance = value; }
        }

        public void InsertBillDetails(int idBill, int idFood, int count)
        {
            string query = "EXEC USP_InsertBillDetails " + idBill + ", " + idFood + ", " + count + " ";
            DataProvider.Instance.ExecuteNonQuery(query);
        }

        public List<BillDetailsDTO> GetListBillDetailsByBillID(int id)
        {
            List<BillDetailsDTO> list = new List<BillDetailsDTO>();
            string query = "EXEC dbo.USP_GetListBillDetailsByBillID @idBill = " + id;
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach(DataRow item in data.Rows)
            {
                BillDetailsDTO bill = new BillDetailsDTO(item);
                list.Add(bill);
            }
            return list;
        }

    }
}
