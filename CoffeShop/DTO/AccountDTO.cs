using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeShop.DTO
{
    public class AccountDTO
    {
        public AccountDTO(string USERNAME, int IDROLE, int IDSTAFF, int STATUS , string PASSWORD = null )
        {
            this.UserName = USERNAME;
            this.PassWord = PASSWORD;
            this.IdStaff = IDSTAFF;
            this.IdRole = IDROLE;
            this.Status = STATUS;
        }

        public AccountDTO(DataRow rows)
        {
            this.UserName = rows["UserName"].ToString();
            this.PassWord = rows["PASSWORD"].ToString();
            this.IdStaff = (int)rows["IDSTAFF"];
            this.IdRole = (int)rows["IDROLE"];
            this.Status = (int)rows["STATUS"];
        }


        private string userName;
        private string passWord;
        private int idRole;
        private int idStaff;
        private int status;

        public string UserName { get => userName; set => userName = value; }
        public string PassWord { get => passWord; set => passWord = value; }
        public int IdRole { get => idRole; set => idRole = value; }
        public int IdStaff { get => idStaff; set => idStaff = value; }
        public int Status { get => status; set => status = value; }
    }
}
