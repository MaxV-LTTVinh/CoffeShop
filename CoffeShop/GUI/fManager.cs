using CoffeShop.DAO;
using CoffeShop.DTO;
using CoffeShop.GUI;
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
    public partial class fManager : Form
    {
        public CultureInfo culture = new CultureInfo("vi-VN");

        int timeLoadTable = 0;
        public fManager()
        {
            InitializeComponent();
            loadUserLogin();
            RoleManager();
            LoadTableFood();
            LoadListCategory();
            LoadcbTableSwitch();
            timer1.Start();
            //BackColor = Color.FromArgb(18, 132, 162);
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
        }

        void LoadAll()
        {
            //loadUserLogin();
            //RoleManager();
            LoadTableFood();
            LoadListCategory();
            LoadcbTableSwitch();
            timer1.Start();
        }

        void RoleManager()
        {
            int a = DataProvider.Instance.IdRole;
            switch (DataProvider.Instance.IdRole)
            {
                case 1:
                    MessageBox.Show("Bạn đăng nhập với quyền admin");
                    break;
                case 2:
                    MessageBox.Show("Bạn đăng nhập với quyền thu ngân");
                    btnAdmin.Visible = false;
                    break;
                case 3:
                    MessageBox.Show("Bạn đăng nhập với quyền quản lý");
                    btnAdmin.Visible = false;
                    break;
            }

        }

        void loadCbFoodByIDBill(int idBill)
        {
            cbFoodofIdBill.DataSource = null;
            List<FoodDTO> list = FoodDAO.Instance.GetListFoodByIDBill(idBill);
            cbFoodofIdBill.DataSource = list;
            cbFoodofIdBill.DisplayMember = "FoodName";
            cbFoodofIdBill.ValueMember = "Id";
        }

        void loadUserLogin()
        {
            int idStaff = AccountDAO.Instance.getAccountByUserName(DataProvider.Instance.UserName).IdStaff;
            StaffDTO staff = StaffDAO.Instance.getStaffByIdStaff(idStaff);
            if (staff == null)
            {
                lblStaffName.Text = "";
            }
            else
            {
                lblStaffName.Text = "Xin chào " + staff.StaffName;
            }
        }

        void LoadTableFood()
        {
            flpTable.Controls.Clear();
            cbFoodofIdBill.DataSource = null;
            List<TableDTO> tableList = TableDAO.Instance.TableLoadList();
            foreach (TableDTO item in tableList)
            {
                Button btn = new Button() { Width = TableDAO.Width, Height = TableDAO.Height };
                btn.BackColor = Color.White;
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 1;
                btn.FlatAppearance.BorderColor = Color.DarkBlue;
                btn.ForeColor = Color.Maroon;
                btn.Image = Image.FromFile(".\\icon\\people-coffe-offline.png");
                btn.Text = item.Name;
                //btn.fo
                btn.TextAlign = ContentAlignment.BottomCenter;
                btn.Font = new Font(btn.Font.FontFamily, 12, FontStyle.Bold);
                btn.ImageAlign = ContentAlignment.TopCenter;
                switch (item.Status)
                {
                    case 1:
                        //status = "\nChưa thanh toán";
                        btn.Image = Image.FromFile(".\\icon\\people-coffe-online.png");
                        btn.TextAlign = ContentAlignment.BottomCenter;
                        btn.BackColor = Color.Blue;
                        btn.ForeColor = Color.Aqua;
                        break;
                    case 2:
                        //status = "\nCó khách";
                        btn.BackColor = Color.DarkBlue;
                        break;

                }
                btn.Click += btn_Click;
                btn.Tag = item;
                flpTable.Controls.Add(btn);
            }
        }

        void LoadcbTableSwitch()
        {
            //cbTableSwitch.Items.Clear();
            List<TableDTO> list = TableDAO.Instance.TableLoadList();
            cbTableSwitch.DataSource = list;
            cbTableSwitch.DisplayMember = "NAME";
            cbTableSwitch.ValueMember = "ID";
        }

        void LoadListCategory()
        {
            //cbCategory.Items.Clear();
            List<FoodCategoryDTO> categorylist = FoodCategoryDAO.Instance.GetListCategory();
            cbCategory.DataSource = categorylist;
            cbCategory.DisplayMember = "CategoryName";
            cbCategory.ValueMember = "IdCategory";
        }

        void LoadListFoodByIDCategory(string idCategory)
        {
            //cbFood.Items.Clear();
            List<FoodDTO> list = FoodDAO.Instance.GetListFoodByIDCategory(idCategory);
            cbFood.DataSource = list;
            cbFood.DisplayMember = "FoodName";
            cbFood.ValueMember = "Id";
        }

        void ShowBill(int id)
        {
            lvBill.Items.Clear();

            int TotalPrice = 0;
            List<MenuBillDetailsDTO> list = MenuBillDetailsDAO.Instance.GetListMenuFoodbyTableID(id);

            foreach (MenuBillDetailsDTO item in list)
            {
                ListViewItem lvitem = new ListViewItem(item.NameFood.ToString());
                lvitem.SubItems.Add(item.Count.ToString());
                lvitem.SubItems.Add(item.Price.ToString());
                lvitem.SubItems.Add(item.TotalPrice.ToString());
                TotalPrice += item.TotalPrice;
                lvBill.Items.Add(lvitem);
            }
            //public CultureInfo culture = new CultureInfo("vi-VN");
            //Thread.CurrentThread.CurrentCulture = culture;

            txtsumTotalPrice.Text = TotalPrice.ToString("c", culture);
        }

        void ShowListBillByTableID(int id)
        {
            cbBill.DataSource = null;
            List<BillDTO> listBill = BillDAO.Instance.GetListUncheckBillIDByTableID(id);
            cbBill.DataSource = listBill;
            cbBill.ValueMember = "IDBILL";
            cbBill.DisplayMember = "IDBILL";
        }

        private void btn_Click(object sender, EventArgs e)
        {
            //LoadTableFood();
            cbFoodofIdBill.DataSource = null;
            numFoodSplitBill.Value = 0;
            Button btn = sender as Button;
            foreach (Button item in flpTable.Controls)
            {

                if (item == btn)
                {
                    item.Font = new Font(btn.Font.FontFamily, 8, FontStyle.Bold);
                    item.FlatAppearance.BorderSize = 5;
                    item.FlatAppearance.BorderColor = Color.Red;
                }
                else
                {
                    item.Font = new Font(btn.Font.FontFamily, 12, FontStyle.Bold);
                    item.FlatAppearance.BorderSize = 1;
                    item.FlatAppearance.BorderColor = Color.DarkBlue;
                }
            }

            int tableID = ((sender as Button).Tag as TableDTO).Id;
            int numBillinTable = BillDAO.Instance.GetListUncheckBillIDByTableID(tableID).Count();
            lbTableNumber.Text = "Bàn " + ((sender as Button).Tag as TableDTO).Name + " có: " + numBillinTable + " Hóa Đơn";
            ShowBill(tableID);
            ShowListBillByTableID(tableID);
            lvBill.Tag = (sender as Button).Tag;
            if (BillDAO.Instance.GetListUncheckBillIDByTableID(tableID).Count != 0)
            {
                loadCbFoodByIDBill(BillDAO.Instance.GetListUncheckBillIDByTableID(tableID)[0].IdBill);
                nmSale.Value = BillDAO.Instance.GetListUncheckBillIDByTableID(tableID)[0].Discount;
            }

        }

        private void cbCategory_SelectedValueChanged(object sender, EventArgs e)
        {
            ComboBox cb = sender as ComboBox;

            if (cb.SelectedItem == null)
                return;

            FoodCategoryDTO selected = cb.SelectedItem as FoodCategoryDTO;


            LoadListFoodByIDCategory(selected.IdCategory.ToString());
        }

        private void btnAddFood_Click(object sender, EventArgs e)
        {
            try
            {
                TableDTO table = lvBill.Tag as TableDTO;

                if (table == null)
                {
                    MessageBox.Show("Hãy chọn bàn");
                    return;
                }

                List<BillDTO> listBill = BillDAO.Instance.GetListUncheckBillIDByTableID(table.Id);

                int foodID = (cbFood.SelectedItem as FoodDTO).Id;
                int count = (int)nmFoodUpCount.Value;

                //string a = cbBill.SelectedIndex.ToString();
                if (listBill.Count() == 0)
                {
                    if (count >= 0)
                    {
                        BillDAO.Instance.InsertBill(table.Id, DataProvider.Instance.UserName);
                        BillDetailsDAO.Instance.InsertBillDetails(BillDAO.Instance.GetMaxIDBill(), foodID, count);
                    }
                    else
                        MessageBox.Show("Vui lòng kiểm tra lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                    BillDetailsDAO.Instance.InsertBillDetails(listBill[0].IdBill, foodID, count);

                ShowBill(table.Id);
                LoadTableFood();
            }
            catch
            {
                MessageBox.Show("Lỗi. Vui lòng liên hệ kỹ thuật viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnMoveTo_Click(object sender, EventArgs e)
        {
            try
            {
                if (lvBill.Tag != null)
                {
                    int TableFromID = (lvBill.Tag as TableDTO).Id;
                    if(BillDAO.Instance.GetListUncheckBillIDByTableID(TableFromID).Count >0)
                    {
                        int TableToID = (cbTableSwitch.SelectedItem as TableDTO).Id;
                        TableDTO tableTo = TableDAO.Instance.GetTableByTableID(TableToID);
                        if (MessageBox.Show("Bạn có chắc muốn chuyển từ bàn " + (lvBill.Tag as TableDTO).Name + " đến bàn " + tableTo.Name + "", "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                        {
                            TableDAO.Instance.SwitchTable(TableFromID, TableToID);
                            List<BillDTO> listBill = BillDAO.Instance.GetListUncheckBillIDByTableID(TableToID);
                            if (listBill.Count() > 1)
                            {
                                for (int i = 1; i < listBill.Count(); i++)
                                {
                                    List<BillDetailsDTO> list = BillDetailsDAO.Instance.GetListBillDetailsByBillID(listBill[i].IdBill);
                                    foreach (BillDetailsDTO item in list)
                                        BillDetailsDAO.Instance.InsertBillDetails(listBill[0].IdBill, item.IdFood, item.Count);
                                    BillDAO.Instance.UpdateStatusBill(listBill[i].IdBill, 3);
                                }
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Vui lòng chọn đúng bàn cần chuyển", "Thông báo", MessageBoxButtons.OK);
                    }
                    
                }
                else MessageBox.Show("Vui lòng chọn bàn cần chuyển", "Thông báo", MessageBoxButtons.OK);
                LoadTableFood();
            }
            catch
            {
                MessageBox.Show("Lỗi. Vui lòng liên hệ kỹ thuật viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timeLoadTable++;
            if (timeLoadTable == 1200)
            {
                LoadTableFood();
                timeLoadTable = 0;
            }
        }

        private void lvBill_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvBill.SelectedItems.Count > 0)
            {
                cbFoodofIdBill.Text = lvBill.SelectedItems[0].SubItems[0].Text;
                numFoodSplitBill.Text = lvBill.SelectedItems[0].SubItems[1].Text;
                numFoodSplitBill.Maximum = Convert.ToInt32(lvBill.SelectedItems[0].SubItems[1].Text);
            }
        }

        private void btnSplitBill_Click(object sender, EventArgs e)
        {
            if (lvBill.Tag != null)
            {
                if (numFoodSplitBill.Value <= 0)
                {
                    MessageBox.Show("Vui lòng chọn món và số lượng cần chuyển", "Thông báo", MessageBoxButtons.OK);
                }
                else
                {
                    string name = (cbTableSwitch.SelectedItem as TableDTO).Name;
                    string foodname = cbFoodofIdBill.SelectedValue.ToString();
                    string n = numFoodSplitBill.Value.ToString();
                    if (MessageBox.Show("Bạn có chắc muốn chuyển " + numFoodSplitBill.Value + " " + (cbFoodofIdBill.SelectedItem as FoodDTO).FoodName + " đến bàn " + (cbTableSwitch.SelectedItem as TableDTO).Name, "Chuyển bàn", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                    {
                        MessageBox.Show("OK");
                        List<BillDTO> list = BillDAO.Instance.GetListUncheckBillIDByTableID((cbTableSwitch.SelectedItem as TableDTO).Id);
                        int idFood = (cbFoodofIdBill.SelectedItem as FoodDTO).Id;
                        int count = Convert.ToInt32(numFoodSplitBill.Value.ToString());
                        if (list.Count == 0)
                        {

                            BillDAO.Instance.InsertBill((cbTableSwitch.SelectedItem as TableDTO).Id);
                            BillDetailsDAO.Instance.InsertBillDetails(BillDAO.Instance.GetMaxIDBill(), idFood, count);

                        }
                        else
                        {
                            int idBillFrom = list[0].IdBill;
                            BillDetailsDAO.Instance.InsertBillDetails(idBillFrom, idFood, count);
                        }
                        BillDetailsDAO.Instance.InsertBillDetails(BillDAO.Instance.GetListUncheckBillIDByTableID((lvBill.Tag as TableDTO).Id)[0].IdBill, idFood, -count);
                    }
                }
                ShowBill((lvBill.Tag as TableDTO).Id);
                LoadTableFood();
            }
            else
                MessageBox.Show("Vui lòng chọn bàn", "Thông báo", MessageBoxButtons.OK);
        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            fAdmin f = new fAdmin();
            this.Hide();
            f.ShowDialog();
            this.Show();
            LoadAll();

        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAccount_Click(object sender, EventArgs e)
        {
            AccountProfile f = new AccountProfile();
            f.ShowDialog();
            if (DataProvider.Instance.UserName == null)
            {
                this.Close();
            }
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            try
            {
                TableDTO table = lvBill.Tag as TableDTO;

                if (table != null)
                {
                    BillDTO bill = BillDAO.Instance.GetUncheckBillIDByTableID(table.Id);
                    int discount = (int)nmSale.Value;
                    //string a = txtsumTotalPrice.Text;
                    //string b = a.Split(',')[0];
                    //double d = Convert.ToDouble(b);
                    //decimal i = decimal.Parse(b, culture);


                    int totalPrice = (int)decimal.Parse((txtsumTotalPrice.Text.Split(',')[0]), culture);
                    int finalTotalPrice = totalPrice - (totalPrice / 100) * discount;
                    if (bill != null)
                    {
                        if (MessageBox.Show("Tông tiền bàn " + table.Name + " là: " + finalTotalPrice + "\nBạn có chắc chắn muốn thanh toán?", "Thanh toán", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                        {
                            BillDAO.Instance.CheckOut(bill.IdBill, discount, finalTotalPrice, DataProvider.Instance.UserName);
                            LoadTableFood();
                        }
                    }
                }
                else
                    MessageBox.Show("Vui Lòng chọn bàn cần thanh toán", "Thông báo");
                nmSale.Value = 0;
                lvBill.Tag = null;
            }
            catch
            {
                MessageBox.Show("Lỗi. Vui lòng liên hệ kỹ thuật viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPrintBill_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbBill.SelectedItem != null)
                {
                    fBillPrint.Id = (cbBill.SelectedItem as BillDTO).IdBill;
                    fBillPrint.Discount = (int)nmSale.Value;
                    fBillPrint f = new fBillPrint();
                    f.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn bàn cần in bill", "Thông báo", MessageBoxButtons.OK);
                }
            }
            catch
            {
                MessageBox.Show("Lỗi. Vui lòng liên hệ kỹ thuật viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbTableSwitch_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnRevenue_Click(object sender, EventArgs e)
        {
            fRevenue f = new fRevenue();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void fManager_Load(object sender, EventArgs e)
        {

        }

        private void btnSale_Click(object sender, EventArgs e)
        {
            try
            {
                TableDTO table = lvBill.Tag as TableDTO;
                BillDAO.Instance.SaleBill(BillDAO.Instance.GetUncheckBillIDByTableID(table.Id).IdBill, (int)nmSale.Value);
            }
            catch
            {
                MessageBox.Show("Lỗi. Vui lòng liên hệ kỹ thuật viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
