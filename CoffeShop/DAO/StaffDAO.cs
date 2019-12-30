using CoffeShop.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeShop.DAO
{
    public class StaffDAO
    {
        private static StaffDAO instance;

        public static StaffDAO Instance
        {
            get { if (instance == null) instance = new StaffDAO(); return StaffDAO.instance; }
            private set { StaffDAO.instance = value; }
        }

        public List<StaffDTO> GetListStaffAll()
        {
            List<StaffDTO> list = new List<StaffDTO>();

            string query = "SELECT * FROM	 dbo.Staff";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                StaffDTO staff = new StaffDTO(item);
                list.Add(staff);
            }

            return list;
        }

        public StaffDTO getStaffByIdStaff(int id)
        {
            string query = "EXEC dbo.USP_getStaffByIdStaff @idStaff ";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { id });
            if(data.Rows.Count >0)
            {
                StaffDTO staff = new StaffDTO(data.Rows[0]);
                return staff;
            }
            return null;
        }

        public void InsertStaff(string name, string address, string phonenumber, string email, int idtype, DateTime? birthdate = null)
        {
            string query = "EXEC USP_InsertStaff @StaffName ,  @Address , @PhoneNumber ,  @Email , @idType ,  @BirthDate ";
            DataProvider.Instance.ExecuteNonQuery(query, new object[] { name, address,phonenumber,email,idtype,birthdate });
        }

        public void UpdateStaff(int id, string name, string address, string phonenumber, string email, int idtype, DateTime? birthdate = null)
        {
            string query = "EXEC USP_UpdateStaff @id , @StaffName ,  @Address , @PhoneNumber ,  @Email , @idType ,  @BirthDate ";
            DataProvider.Instance.ExecuteNonQuery(query, new object[] { id, name, address, phonenumber, email, idtype, birthdate });
        }

        public void DeleteStaff(int id)
        {
            string query = "EXEC USP_DeleteStaff @id";
            DataProvider.Instance.ExecuteNonQuery(query, new object[] { id });
        }
    }
}
