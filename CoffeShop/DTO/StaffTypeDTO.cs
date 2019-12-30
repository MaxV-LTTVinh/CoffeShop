using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeShop.DTO
{
    public class StaffTypeDTO
    {
        public StaffTypeDTO(int IDTYPE, string NAMETYPE, int WAGE)
        {
            this.IdType = IDTYPE;
            this.NameType = NAMETYPE;
            this.Wage = WAGE;
        }

        public StaffTypeDTO(DataRow row)
        {
            this.IdType = (int)row["IDTYPE"];
            this.NameType = row["NAMETYPE"].ToString();
            this.Wage = (int)row["WAGE"];
        }

        private int idType;
        private string nameType;
        private int wage;

        public int IdType { get => idType; set => idType = value; }
        public string NameType { get => nameType; set => nameType = value; }
        public int Wage { get => wage; set => wage = value; }
    }
}
