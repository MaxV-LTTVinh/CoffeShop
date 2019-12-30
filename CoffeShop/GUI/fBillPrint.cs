using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoffeShop.GUI
{
    public partial class fBillPrint : Form
    {
        private static int id;
        private static int discount;

        public fBillPrint()
        {
            InitializeComponent();
        }

        public static int Id { get => id; set => id = value; }
        public static int Discount { get => discount; set => discount = value; }

        private void fBillPrint_Load(object sender, EventArgs e)
        {
        }

        private void fBillPrint_Load_1(object sender, EventArgs e)
        {
            this.uSP_GetPrintBillWithCustomerTableAdapter.Fill(this.coffeShopDataSet.USP_GetPrintBillWithCustomer, Id, Discount);
            this.reportViewer1.RefreshReport();
        }
    }
}
