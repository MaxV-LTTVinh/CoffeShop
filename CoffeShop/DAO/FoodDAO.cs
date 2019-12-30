using CoffeShop.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoffeShop.DAO
{
    public class FoodDAO
    {
        private static FoodDAO instance;

        public static FoodDAO Instance
        {
            get { if (instance == null) instance = new FoodDAO(); return FoodDAO.instance; }
            private set { FoodDAO.instance = value; }
        }

        public List<FoodDTO> GetListFoodByIDCategory(string idCategory)
        {
            List<FoodDTO> list = new List<FoodDTO>();
            string query = " dbo.USP_GetListFoodByIDCategory " + idCategory;
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                FoodDTO food = new FoodDTO(item);
                list.Add(food);
            }
            return list;
        }

        public List<FoodDTO> GetListAllFood()
        {
            List<FoodDTO> list = new List<FoodDTO>();

            string query = "EXEC dbo.USP_GetListFoodAll";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                FoodDTO food = new FoodDTO(item);
                list.Add(food);
            }

            return list;
        }

        public void InsertFood(string name, int idCategory, int price)
        {
            try
            {
                string query = "EXEC dbo.USP_InsertFood_Food @FoodName , @idCategory , @Price ";
                DataProvider.Instance.ExecuteNonQuery(query, new object[] { name, idCategory, price });
                MessageBox.Show("Thêm món thành công");
            }
            catch
            {
                MessageBox.Show("Có lỗi khi thêm thức ăn");
            }
        }

        public void UpdateFood(int id, string name, int idCategory, int price)
        {
            try
            {
                string query = "EXEC dbo.USP_UpdateFood @id , @FoodName , @idCategory , @Price ";
                DataProvider.Instance.ExecuteNonQuery(query, new object[] { id, name, idCategory, price });
                MessageBox.Show("Sửa món thành công");
            }
            catch
            {
                MessageBox.Show("Có lỗi khi sửa thức ăn");
            }
        }

        public void DeleteFood(int id)
        {
            try
            {
                string query = "EXEC dbo.USP_DeleteFood @id  ";
                DataProvider.Instance.ExecuteNonQuery(query, new object[] { id });
                MessageBox.Show("Xóa món thành công");
            }
            catch
            {
                MessageBox.Show("Có lỗi khi xóa thức ăn");
            }
        }
        public List<FoodDTO> GetListFoodByIDBill(int idBill)
        {
            List<FoodDTO> list = new List<FoodDTO>();
            string query = "EXEC dbo.USP_GetListFoodInBill @idBill";
            DataTable data =  DataProvider.Instance.ExecuteQuery(query, new object[] { idBill });
            foreach (DataRow item in data.Rows)
            {
                FoodDTO food = new FoodDTO(item);
                list.Add(food);
            }
            return list;
        }

        public List<FoodDTO> SearchFoodByFoodName(string name)
        {
            List<FoodDTO> list = new List<FoodDTO>();
            string query = "EXEC dbo.SearchFood @FoodName";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { name });
            foreach (DataRow item in data.Rows)
            {
                FoodDTO food = new FoodDTO(item);
                list.Add(food);
            }
            return list;
        }
    }
}
