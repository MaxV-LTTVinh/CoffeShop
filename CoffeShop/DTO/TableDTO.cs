using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeShop.DTO
{
    public class TableDTO
    {
        public TableDTO(int ID, string NAME,int STATUS)
        {
            this.id = ID;
            this.name = NAME;
            this.status = STATUS;
        }

        public TableDTO(DataRow row)
        {
            this.id = (int)row["idTable"];
            this.name = row["TableName"].ToString();
            this.status = (int)row["Status"];
        }

        private int id;
        private string name;
        private int status;
        public int Status { get => status; set => status = value; }
        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
    }
}
