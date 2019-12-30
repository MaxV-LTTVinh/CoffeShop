using CoffeShop.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeShop.DAO
{
    public class RoleDAO
    {
        private static RoleDAO instance;

        public static RoleDAO Instance
        {
            get { if (instance == null) instance = new RoleDAO(); return RoleDAO.instance; }
            private set { RoleDAO.instance = value; }
        }

        public List<RoleDTO> getListRoleAll()
        {
            List<RoleDTO> list = new List<RoleDTO>();

            string query = "EXEC USP_getListRole";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach(DataRow item in data.Rows)
            {
                RoleDTO role = new RoleDTO(item);
                list.Add(role);
            }

            return list;
        }

        public void InsertRole(string name)
        {
            string query = "EXEC dbo.insert_Role @Role";
            DataProvider.Instance.ExecuteNonQuery(query, new object[] { name });
        }
        public void UpdateRole(int id, string name)
        {
            string query = "EXEC dbo.USP_Update_Role @id , @Role ";
            DataProvider.Instance.ExecuteNonQuery(query, new object[] { id, name });
        }

        public void DeleteRole(int id)
        {
            string query = "EXEC dbo.USP_Delete_Role @id";
            DataProvider.Instance.ExecuteNonQuery(query, new object[] { id});
        }
    }
}
