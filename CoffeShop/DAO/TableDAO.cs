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
    class TableDAO
    {
        private static TableDAO instance;

        public static TableDAO Instance
        {
            get { if (instance == null) instance = new TableDAO(); return TableDAO.instance; }
            private set { TableDAO.instance = value; }
        }

        public static int Width = 90;
        public static int Height = 90;

        public List<TableDTO> TableLoadList()
        {
            List<TableDTO> tableList = new List<TableDTO>();
            string query = "getListTableFood";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                TableDTO table = new TableDTO(item);
                tableList.Add(table);
            }
            return tableList;
        }

        public void SwitchTable(int tbFrom, int tbTo)
        {
            DataProvider.Instance.ExecuteQuery("EXEC dbo.USP_SwitchTable @idTableFrom = " + tbFrom + " , @idTableTO = " + tbTo);
        }

        public TableDTO GetTableByTableID(int id)
        {
            List<TableDTO> tableList = new List<TableDTO>();

            string query = "SELECT * FROM dbo.TableFood WHERE	 idTable = " + id;
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                TableDTO table = new TableDTO(item);
                tableList.Add(table);
            }

            return tableList[0];
        }

        public void InsertTable(string name)
        {
            try
            {
                string query = "EXEC dbo.USP_InsertTableFood @name ";
                DataProvider.Instance.ExecuteNonQuery(query, new object[] { name });
                MessageBox.Show("Thêm bàn thành công");
            }
            catch
            {
                MessageBox.Show("Có lỗi khi thêm bàn");
            }
        }

        public void UpdateTable(int id, string name)
        {
            try
            {
                string query = "EXEC dbo.USP_UpdateTableFood @idCategory , @CategoryName ";
                DataProvider.Instance.ExecuteNonQuery(query, new object[] { id, name });
                MessageBox.Show("Sửa bàn thành công");
            }
            catch
            {
                MessageBox.Show("Có lỗi khi sửa bàn");
            }
        }

        public void DeleteTable(int id)
        {
            try
            {
                string query = "EXEC dbo.USP_DeleteTableFood @idCategory  ";
                DataProvider.Instance.ExecuteNonQuery(query, new object[] { id });
                MessageBox.Show("Xóa bàn thành công");
            }
            catch
            {
                MessageBox.Show("Có lỗi khi xóa bàn");
            }
        }
    }
}
