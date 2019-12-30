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
    public class StaffTypeDAO
    {
        private static StaffTypeDAO instance;

        public static StaffTypeDAO Instance
        {
            get { if (instance == null) instance = new StaffTypeDAO(); return StaffTypeDAO.instance; }
            private set { StaffTypeDAO.instance = value; }
        }

        public List<StaffTypeDTO> getListStaffTypeAll()
        {
            List<StaffTypeDTO> list = new List<StaffTypeDTO>();
            string query = "EXEC dbo.getListTypeAll";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                StaffTypeDTO type = new StaffTypeDTO(item);
                list.Add(type);
            }
            return list;
        }

        public void InsertType(string name, int wage)
        {
            //try
            //{
                string query = "EXEC dbo.USP_InsertType @NameType , @Wage";
                DataProvider.Instance.ExecuteNonQuery(query, new object[] { name , wage });
                MessageBox.Show("Thêm loại nhân viên thành công");
            //}
            //catch
            //{
            //    MessageBox.Show("Có lỗi khi thêm loại nhân viên");
            //}
        }

        public void UpdateType(int id, string name, int wage)
        {
            try
            {
                string query = "EXEC dbo.USP_UpdatetType @idType , @NameType , @Wage";
                DataProvider.Instance.ExecuteNonQuery(query, new object[] {id , name , wage });
                MessageBox.Show("Sửa loại nhân viên thành công");
            }
            catch
            {
                MessageBox.Show("Có lỗi khi Sửa loại nhân viên");
            }
        }

        public void DeleteType(int id)
        {
            try
            {
                string query = "EXEC USP_DeleteType @idType";
                DataProvider.Instance.ExecuteNonQuery(query, new object[] { id });
                MessageBox.Show("Xóa loại nhân viên thành công");
            }
            catch
            {
                MessageBox.Show("Có lỗi khi Xóa loại nhân viên");
            }
        }
    }
}
