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
    public class FoodCategoryDAO
    {
        private static FoodCategoryDAO instance;

        public static FoodCategoryDAO Instance
        {
            get { if (instance == null) instance = new FoodCategoryDAO(); return FoodCategoryDAO.instance; }
            private set { FoodCategoryDAO.instance = value; }
        }

        public List<FoodCategoryDTO> GetListCategory()
        {
            List<FoodCategoryDTO> listCategory = new List<FoodCategoryDTO>();
            string query = "EXEC dbo.USP_GetListFoodCategory";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                FoodCategoryDTO category = new FoodCategoryDTO(item);
                listCategory.Add(category);
            }
            return listCategory;
        }

        public void InsertFoodCategory(string name)
        {
            try
            {
                string query = "EXEC dbo.USP_InsertFoodCategory @CategoryName ";
                DataProvider.Instance.ExecuteNonQuery(query, new object[] { name});
                MessageBox.Show("Thêm danh mục thành công");
            }
            catch
            {
                MessageBox.Show("Có lỗi khi thêm danh mục");
            }
        }

        public void UpdateFoodCategory(int id, string name)
        {
            try
            {
                string query = "EXEC dbo.USP_UpdateFoodCategory @idCategory , @CategoryName ";
                DataProvider.Instance.ExecuteNonQuery(query, new object[] { id, name });
                MessageBox.Show("Sửa danh mục thành công");
            }
            catch
            {
                MessageBox.Show("Có lỗi khi sửa danh mục");
            }
        }

        public void DeleteFoodCategory(int id)
        {
            try
            {
                string query = "EXEC dbo.USP_DeleteFoodCategory @idCategory  ";
                DataProvider.Instance.ExecuteNonQuery(query, new object[] { id });
                MessageBox.Show("Xóa danh mục thành công");
            }
            catch
            {
                MessageBox.Show("Có lỗi khi xóa danh mục");
            }
        }
    }
}
