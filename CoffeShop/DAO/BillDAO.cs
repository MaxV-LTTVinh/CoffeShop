using CoffeShop.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeShop.DAO
{
    public class BillDAO
    {
        private static BillDAO instance;

        public static BillDAO Instance
        {
            get { if (instance == null) instance = new BillDAO(); return BillDAO.instance; }
            private set { BillDAO.instance = value; }
        }

        public List<BillDTO> GetListUncheckBillIDByTableID(int id)
        {
            string query = "USP_GetUnCheckBillIdByTableID " + id;
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            
            List <BillDTO> list = new List<BillDTO>();
            
            foreach(DataRow item in data.Rows)
            {
                BillDTO bill = new BillDTO(item);
                list.Add(bill);
            }
            //int a = list[0].IdBill;
            return list;
        }

        public BillDTO GetUncheckBillIDByTableID(int id)
        {
            string query = "USP_GetUnCheckBillIdByTableID " + id;
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            if(data.Rows.Count >0)
            {
                BillDTO bill = new BillDTO(data.Rows[0]);
                return bill;
            }
                
            return null;
        }

        public void InsertBill(int id, string UserName = "admin")
        {
            string query = "EXEC dbo.USP_InsertBill @idTable , @userName ";
            DataProvider.Instance.ExecuteQuery(query, new object[] { id , UserName });
        }

        public int GetMaxIDBill()
        {
            try
            {
                return (int)DataProvider.Instance.ExecuteScalar("SELECT MAX(idBill) FROM dbo.Bill");
            }
            catch
            {
                return 1;
            }
        }
        public void UpdateStatusBill(int id, int status)
        {
            string query = "EXEC dbo.UpdateStatusBill @idBill = "+id+", @status = " + status;
            DataProvider.Instance.ExecuteNonQuery(query);
        }

        public void CheckOut(int id, int discount, int totalPrice, string userName)
        {
            string query = "EXEC dbo.USP_CheckOut @idBill , @discount , @TotalPrice , @UserName ";
            DataProvider.Instance.ExecuteNonQuery(query, new object[] { id, discount, totalPrice , userName });
        }

        public DataTable GetListBillRevenue(DateTime DateStart, DateTime DateEnd, string UserName)
        {
            string query = "EXEC dbo.USP_GetListBillRevenue @DateStart , @DateEnd , @UserName ";
            DataTable data =  DataProvider.Instance.ExecuteQuery(query, new object[] { DateStart, DateEnd, UserName });
            return data;
        }
        public void SaleBill(int id, int discount)
        {
            string query = "EXEC dbo.USP_SaleBill @idBill , @discount ";
            DataProvider.Instance.ExecuteNonQuery(query, new object[] { id, discount });
        }
    }
}
