using CoffeShop.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace CoffeShop.DAO
{
    public class AccountDAO
    {
        private static AccountDAO instance;

        public static AccountDAO Instance
        {
            get { if (instance == null) instance = new AccountDAO(); return AccountDAO.instance; }
            private set { AccountDAO.instance = value; }
        }

        public int Login(string uName,string pWD)
        {
            byte[] temp = ASCIIEncoding.ASCII.GetBytes(pWD);
            byte[] hasData = new MD5CryptoServiceProvider().ComputeHash(temp);

            string hasPass = "";

            foreach (byte item in hasData)
            {
                hasPass += item;
            }

            string query = "EXEC USP_Login @userName , @passWord ";

            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { uName, hasPass /*list*/});

            List<AccountDTO> list = new List<AccountDTO>();
            foreach (DataRow item in data.Rows)
            {
                AccountDTO account = new AccountDTO(item);
                list.Add(account);
            }

            if (list.Count() > 0)
            {
                //MessageBox.Show(list[0].IdRole.ToString());
                return list[0].IdRole;
            }
                

            return -1;
        }
        public List<AccountDTO> getListAccountAll()
        {
            List<AccountDTO> list = new List<AccountDTO>();

            string query = "EXEC dbo.USP_GetListAccountAll";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                AccountDTO account = new AccountDTO(item);
                list.Add(account);
            }

            return list;
        }

        public List<AccountDTO> getAccountByIDStaff(int idStaff)
        {
            List<AccountDTO> list = new List<AccountDTO>();

            string query = "EXEC dbo.USP_GetListAccountByIDStaff @IdStaff";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { idStaff } );
            foreach (DataRow item in data.Rows)
            {
                AccountDTO account = new AccountDTO(item);
                list.Add(account);
            }

            return list;
        }

        public AccountDTO getAccountByUserName(string UserName)
        {
            string query = "EXEC dbo.USP_GetListAccountByUserName @userName";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { UserName });
            if(data.Rows.Count > 0)
            {
                AccountDTO account = new AccountDTO(data.Rows[0]);
                return account;
            }
            return null;
            
        }

        public void InsertAcount(string UserName, int idStaff, int idRole, string PassWord = null, int status = 1)
        {
            string query = "EXEC dbo.USP_Insert_Account @UserName , @idStaff , @idRole , @passWord , @status";
            DataProvider.Instance.ExecuteNonQuery(query, new object[] { UserName, idStaff , idRole , PassWord, status });
        }

        public void UpdateAcount(string UserName, int idStaff, int idRole, string PassWord = null, int status = 1)
        {
            string query = "EXEC dbo.USP_Update_Account @UserName , @passWord , @idStaff , @idRole , @status";
            DataProvider.Instance.ExecuteNonQuery(query, new object[] { UserName , PassWord , idStaff , idRole , status });
        }

        public void DeleteAccount(string UserName)
        {
            string query = "EXEC dbo.USP_Delete_Account @UserName";
            DataProvider.Instance.ExecuteNonQuery(query, new object[] { UserName });
        }

        public void LockAccount(string UserName)
        {
            string query = "EXEC dbo.USP_Lock_Account @UserName";
            DataProvider.Instance.ExecuteNonQuery(query, new object[] { UserName });
        }

        public void UnLockAccount(string UserName)
        {
            string query = "EXEC dbo.USP_UnLock_Account @UserName";
            DataProvider.Instance.ExecuteNonQuery(query, new object[] { UserName });
        }
    }
}
