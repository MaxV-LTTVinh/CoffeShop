using CoffeShop.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeShop.DAO
{
    public class MenuBillDetailsDAO
    {
        private static MenuBillDetailsDAO instance;

        public static MenuBillDetailsDAO Instance
        {
            get { if (instance == null) instance = new MenuBillDetailsDAO(); return MenuBillDetailsDAO.instance; }
            private set { MenuBillDetailsDAO.instance = value; }
        }

        public List<MenuBillDetailsDTO> GetListMenuFoodbyTableID(int id)
        {
            List<MenuBillDetailsDTO> list = new List<MenuBillDetailsDTO>();
            string query = "EXEC dbo.USP_GetBillDetailsByTableID " + id;
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach(DataRow item in data.Rows)
            {
                MenuBillDetailsDTO menu = new MenuBillDetailsDTO(item);
                list.Add(menu);
            }
            return list;
        }

        
            
    }
}
