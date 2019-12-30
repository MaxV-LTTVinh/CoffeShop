using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeShop.DTO
{
    public class RoleDTO
    {
        public RoleDTO(int IDROLE,string ROLE)
        {
            this.IdRole = IDROLE;
            this.NameRole = ROLE;
        }

        public RoleDTO(DataRow row)
        {
            this.IdRole = (int)row["IDROLE"];
            this.NameRole = row["ROLE"].ToString();
        }

        private int idRole;
        private string nameRole;

        public int IdRole { get => idRole; set => idRole = value; }
        public string NameRole { get => nameRole; set => nameRole = value; }
    }
}
