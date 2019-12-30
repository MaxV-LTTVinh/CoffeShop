using CoffeShop.DAO;
using CoffeShop.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoffeShop.GUI
{
    public partial class fRevenue : Form
    {
        public CultureInfo culture = new CultureInfo("vi-VN");
        public fRevenue()
        {
            InitializeComponent();
            LoadDateTimePickerBill();
            loadListAccount();
            //LoadListBillRevenue(dtpkFromDate.Value, dtpkToDate.Value);
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
            this.WindowState = FormWindowState.Maximized;
            RoleManager();
        }

        void RoleManager()
        {
            int a = DataProvider.Instance.IdRole;
            switch (DataProvider.Instance.IdRole)
            {
                case 1:
                    LoadListBillRevenue(dtpkFromDate.Value, dtpkToDate.Value);
                    break;
                case 2:
                    cbAccount.Visible = false;
                    dtpkFromDate.Enabled = false;
                    dtpkToDate.Enabled = false;
                    LoadListBillRevenue(dtpkFromDate.Value, dtpkToDate.Value, DataProvider.Instance.UserName);
                    break;
                case 3:
                    LoadListBillRevenue(dtpkFromDate.Value, dtpkToDate.Value);
                    break;
            }
        }

        void LoadListBillRevenue(DateTime DateStart, DateTime DateEnd, string UserName = "%%")
        {
            int FinalTotalPriceRevenue = 0;
            DataTable data = BillDAO.Instance.GetListBillRevenue(DateStart, DateEnd, UserName);
            foreach (DataRow item in data.Rows)
            {
                FinalTotalPriceRevenue += Convert.ToInt32(item["TotalPrice"].ToString());
            }
            if (BillDAO.Instance.GetListBillRevenue(DateStart, DateEnd, UserName).Rows.Count != 0)
            {
                dtgvRevenue.DataSource = BillDAO.Instance.GetListBillRevenue(DateStart, DateEnd, UserName);
                dtgvRevenue.Columns["idBill"].HeaderText = "Mã hóa đơn";
                dtgvRevenue.Columns["TableName"].HeaderText = "TableName";
                dtgvRevenue.Columns["TotalPrice"].HeaderText = "Tổng tiền";
                dtgvRevenue.Columns["discount"].HeaderText = "Giảm giá(%)";
                dtgvRevenue.Columns["DateCheckIn"].HeaderText = "Ngày";
                dtgvRevenue.Columns["TimeCheckOut"].HeaderText = "Thời gian ra";
               
            }
            else
                dtgvRevenue.DataSource = null;
            //MessageBox.Show(FinalTotalPriceRevenue.ToString());
            txtFinalTotalPriceRevenue.Text = FinalTotalPriceRevenue.ToString("c", culture);
        }

        void LoadDateTimePickerBill()
        {
            DateTime today = DateTime.Now;
            
            switch (DataProvider.Instance.IdRole)
            {
                case 1:
                    dtpkFromDate.Value = new DateTime(today.Year, today.Month, 1);
                    dtpkToDate.Value = dtpkFromDate.Value.AddMonths(1).AddDays(-1);
                    break;
                case 2:
                    dtpkFromDate.Value = today;
                    dtpkToDate.Value = today;
                    break;
                case 3:
                    dtpkFromDate.Value = new DateTime(today.Year, today.Month, 1);
                    dtpkToDate.Value = dtpkFromDate.Value.AddMonths(1).AddDays(-1);
                    break;
            }
        }

        void loadListAccount()
        {
            List<AccountDTO> list = AccountDAO.Instance.getListAccountAll();
            cbAccount.DataSource = list;
            cbAccount.DisplayMember = "UserName";
            cbAccount.ValueMember = "UserName";

        }

        private void fRevenue_Load(object sender, EventArgs e)
        {

        }

        private void btnViewBill_Click(object sender, EventArgs e)
        {

            switch (DataProvider.Instance.IdRole)
            {
                case 1:
                    LoadListBillRevenue(dtpkFromDate.Value, dtpkToDate.Value);
                    break;
                case 2:
                    LoadListBillRevenue(dtpkFromDate.Value, dtpkToDate.Value, DataProvider.Instance.UserName);
                    break;
                case 3:
                    LoadListBillRevenue(dtpkFromDate.Value, dtpkToDate.Value);
                    break;
            }
        }

        private void cbAccount_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadListBillRevenue(dtpkFromDate.Value, dtpkToDate.Value, (cbAccount.SelectedItem as AccountDTO).UserName);
        }

        private void dtgvRevenue_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in dtgvRevenue.Rows)
                {
                    if (Convert.ToInt32(row.Cells["STT"].Value) % 2 == 0)
                    {
                        row.DefaultCellStyle.BackColor = Color.FromArgb(244,244,244);
                    }
                }
            }
            catch
            {

            }
            
        }
    }
}
