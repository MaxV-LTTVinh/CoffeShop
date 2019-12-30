using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeShop.DTO
{
    public class StaffDTO
    {
        public StaffDTO(int IDSTAFF,string STAFFNAME,string ADDRESS,string PHONENUMBER,string EMAIL, DateTime? BIRTHDATE, int IDTYPE)
        {
            this.IdStaff = IDSTAFF;
            this.StaffName = STAFFNAME;
            this.Address = ADDRESS;
            this.PhoneNumber = PHONENUMBER;
            this.Email = EMAIL;
            this.Birthdate = BIRTHDATE;
            this.IdType = IDTYPE;
        }

        public StaffDTO(DataRow row)
        {
            this.IdStaff = (int)row["IDSTAFF"];
            this.StaffName = row["STAFFNAME"].ToString();
            this.Address = row["ADDRESS"].ToString();
            this.PhoneNumber = row["PHONENUMBER"].ToString();
            this.Email = row["EMAIL"].ToString();
            this.Birthdate = Convert.ToDateTime(row["BIRTHDATE"]);
            this.IdType = (int)row["IDTYPE"];
        }

        private int idStaff;
        private string staffName;
        private string address;
        private string phoneNumber;
        private string email;
        private DateTime? birthdate;
        private int idType;

        public int IdStaff { get => idStaff; set => idStaff = value; }
        public string StaffName { get => staffName; set => staffName = value; }
        public string Address { get => address; set => address = value; }
        public string PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
        public string Email { get => email; set => email = value; }
        public DateTime? Birthdate { get => birthdate; set => birthdate = value; }
        public int IdType { get => idType; set => idType = value; }
    }
}
