using CoffeShop.DAO;
using CoffeShop.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoffeShop.GUI
{
    public partial class fAdmin : Form
    {
        public fAdmin()
        {
            InitializeComponent();
            loadListFood();
            LoadGategoryinCategory();
            LoadTableFood();
            LoadStaff();
            LoadStaffType();
            loadListRole();
            loadListAccount();
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
            this.WindowState = FormWindowState.Maximized;
            RowsColorInGird();
        }

        void loadALL()
        {
            try
            {
                loadListFood();
                LoadGategoryinCategory();
                LoadTableFood();
                LoadStaff();
                LoadStaffType();
                loadListRole();
                loadListAccount();
            }
            catch
            {
                MessageBox.Show("Lỗi. Vui lòng liên hệ kỹ thuật viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tpFood_Click(object sender, EventArgs e)
        {

        }

        void RowsColorInGird()
        {
            for (int i = 0; i < dtgvFood.Rows.Count; i++)
            {
                dtgvFood.Rows[i].DefaultCellStyle.BackColor = Color.Black;
                Color a = dtgvFood.Rows[i].DefaultCellStyle.BackColor;
            }
        }

        #region Load

        void loadListAccount()
        {
            List<AccountDTO> list = AccountDAO.Instance.getListAccountAll();
            dtgvAccount.DataSource = list;
            dtgvAccount.Columns["UserName"].HeaderText = "Tên tài khoản";
            dtgvAccount.Columns["PassWord"].HeaderText = "Mật khẩu";
            dtgvAccount.Columns["IdStaff"].HeaderText = "Mã nhân viên";
            dtgvAccount.Columns["IdRole"].HeaderText = "Mã loại TK";
            dtgvAccount.Columns["Status"].HeaderText = "Trạng thái";
        }

        void loadListRole()
        {
            List<RoleDTO> list = RoleDAO.Instance.getListRoleAll();
            dtgvRole.DataSource = list;
            dtgvRole.Columns["IdRole"].HeaderText = "Mã loại";
            dtgvRole.Columns["NameRole"].HeaderText = "Tên loại";
            cbRoleInAccount.DataSource = list;
            cbRoleInAccount.ValueMember = "IdRole";
            cbRoleInAccount.DisplayMember = "NameRole";
        }

        void loadListFood()
        {
            List<FoodDTO> listFood = FoodDAO.Instance.GetListAllFood();
            dtgvFood.DataSource = listFood;
            dtgvFood.Columns["id"].HeaderText = "Mã món ăn";
            dtgvFood.Columns["FoodName"].HeaderText = "Tên món ăn";
            dtgvFood.Columns["IdCategory"].HeaderText = "Loại món ăn";
            dtgvFood.Columns["Price"].HeaderText = "Đơn giá";

            List<FoodCategoryDTO> listCategory = FoodCategoryDAO.Instance.GetListCategory();
            cbFoodCategoryInFood.DataSource = listCategory;
            cbFoodCategoryInFood.ValueMember = "IDCATEGORY";
            cbFoodCategoryInFood.DisplayMember = "CategoryName";

            //dtgvFood.data
        }

        void LoadGategoryinCategory()
        {
            List<FoodCategoryDTO> listCategory = FoodCategoryDAO.Instance.GetListCategory();
            dtgvCategoryinCategory.DataSource = listCategory;
            dtgvCategoryinCategory.Columns["IdCategory"].HeaderText = "Mã Loại Món Ăn";
            dtgvCategoryinCategory.Columns["CategoryName"].HeaderText = "Tên Loại Món Ăn";
        }

        void LoadTableFood()
        {
            List<TableDTO> list = TableDAO.Instance.TableLoadList();
            dtgvTableFood.DataSource = list;
            dtgvTableFood.Columns["Id"].HeaderText = "Mã bàn";
            dtgvTableFood.Columns["Name"].HeaderText = "Tên bàn";
            dtgvTableFood.Columns["Status"].HeaderText = "Trạng thái";
        }

        void LoadStaff()
        {
            List<StaffDTO> list = StaffDAO.Instance.GetListStaffAll();
            dtgvStaffInStaff.DataSource = list;
            dtgvStaffInStaff.Columns["IdStaff"].HeaderText = "Mã nhân viên";
            dtgvStaffInStaff.Columns["staffName"].HeaderText = "Tên nhân viên";
            dtgvStaffInStaff.Columns["Address"].HeaderText = "Địa chỉ";
            dtgvStaffInStaff.Columns["PhoneNumber"].HeaderText = "Số điện thoại";
            dtgvStaffInStaff.Columns["Email"].HeaderText = "Email";
            dtgvStaffInStaff.Columns["Birthdate"].HeaderText = "Ngày sinh";
            dtgvStaffInStaff.Columns["IdType"].HeaderText = "Loại nhân viên";

            cbStaffInAccount.DataSource = list;
            cbStaffInAccount.ValueMember = "IdStaff";
            cbStaffInAccount.DisplayMember = "StaffName";
            //cbStaffInAccount.select
        }

        void LoadStaffType()
        {
            List<StaffTypeDTO> list = StaffTypeDAO.Instance.getListStaffTypeAll();
            dtgvStaffType.DataSource = list;
            dtgvStaffType.Columns["IdType"].HeaderText = "Mã loại";
            dtgvStaffType.Columns["NameType"].HeaderText = "Tên loại";
            dtgvStaffType.Columns["Wage"].HeaderText = "Tiền công";
            cbStaffTypeInStaff.DataSource = list;
            cbStaffTypeInStaff.ValueMember = "IdType";
            cbStaffTypeInStaff.DisplayMember = "NameType";
        }

        #endregion 

        #region Food


        private void btnAddFood_Click(object sender, EventArgs e)
        {
            try
            {
                string name = txbFoodNameinFood.Text;
                int categoryID = (cbFoodCategoryInFood.SelectedItem as FoodCategoryDTO).IdCategory;
                int price = (int)nmFoodPriceinFood.Value;

                FoodDAO.Instance.InsertFood(name, categoryID, price);
                loadALL();
            }
            catch
            {
                MessageBox.Show("Lỗi! Vui lòng kiểm tra lại.", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        private void btnDeleteFood_Click(object sender, EventArgs e)
        {
            try
            {
                int idFood = Convert.ToInt32(txbFoodIDinFood.Text);
                FoodDAO.Instance.DeleteFood(idFood);
                loadALL();
            }
            catch
            {
                MessageBox.Show("Lỗi. Vui lòng liên hệ kỹ thuật viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEditFood_Click(object sender, EventArgs e)
        {
            try
            {
                int idFood = Convert.ToInt32(txbFoodIDinFood.Text);
                string name = txbFoodNameinFood.Text;
                int categoryID = (cbFoodCategoryInFood.SelectedItem as FoodCategoryDTO).IdCategory;
                int price = (int)nmFoodPriceinFood.Value;
                FoodDAO.Instance.UpdateFood(idFood, name, categoryID, price);
                loadALL();
            }
            catch
            {
                MessageBox.Show("Lỗi. Vui lòng liên hệ kỹ thuật viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnShowFood_Click(object sender, EventArgs e)
        {
            loadListFood();
        }

        private void dtgvFood_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    txbFoodNameinFood.Text = dtgvFood.Rows[e.RowIndex].Cells[1].Value.ToString();
                    txbFoodIDinFood.Text = dtgvFood.Rows[e.RowIndex].Cells[0].Value.ToString();
                    cbFoodCategoryInFood.SelectedValue = Convert.ToInt32(dtgvFood.Rows[e.RowIndex].Cells[2].Value.ToString());
                    nmFoodPriceinFood.Value = Convert.ToInt32(dtgvFood.Rows[e.RowIndex].Cells[3].Value.ToString());
                }
            }
            catch
            {
                MessageBox.Show("Lỗi. Vui lòng liên hệ kỹ thuật viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void tbFoodCategory_Click(object sender, EventArgs e)
        {

        }

        private void btnSearchFood_Click(object sender, EventArgs e)
        {
            string FoodName = txbSearchFoodName.Text;
            dtgvFood.DataSource = FoodDAO.Instance.SearchFoodByFoodName(FoodName);
        }
        #endregion

        #region Category

        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            try
            {
                string name = txbCategoryNameInCategory.Text;
                FoodCategoryDAO.Instance.InsertFoodCategory(name);
                loadALL();
            }
            catch
            {
                MessageBox.Show("Lỗi. Vui lòng liên hệ kỹ thuật viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDeleteCategory_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(txbCategoryIDinCategory.Text);
                FoodCategoryDAO.Instance.DeleteFoodCategory(id);
                loadALL();
            }
            catch
            {
                MessageBox.Show("Lỗi. Vui lòng liên hệ kỹ thuật viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEditCategory_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(txbCategoryIDinCategory.Text);
                string name = txbCategoryNameInCategory.Text;
                FoodCategoryDAO.Instance.UpdateFoodCategory(id, name);
                loadALL();
            }
            catch
            {
                MessageBox.Show("Lỗi. Vui lòng liên hệ kỹ thuật viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dtgvCategoryinCategory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    txbCategoryIDinCategory.Text = dtgvCategoryinCategory.Rows[e.RowIndex].Cells[0].Value.ToString();
                    txbCategoryNameInCategory.Text = dtgvCategoryinCategory.Rows[e.RowIndex].Cells[1].Value.ToString();
                }
            }
            catch
            {
                MessageBox.Show("Lỗi. Vui lòng liên hệ kỹ thuật viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnShowCategory_Click(object sender, EventArgs e)
        {
            LoadGategoryinCategory();
        }
        #endregion

        #region TableFood

        private void btnAddTableinTableFood_Click(object sender, EventArgs e)
        {
            try
            {
                string name = txbTableNameinTableFood.Text;
                TableDAO.Instance.InsertTable(name);
                loadALL();
            }
            catch
            {
                MessageBox.Show("Lỗi. Vui lòng liên hệ kỹ thuật viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDeleteTableinTableFood_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(txtIDTableinTableFood.Text);
                TableDAO.Instance.DeleteTable(id);
                loadALL();
            }
            catch
            {
                MessageBox.Show("Lỗi. Vui lòng liên hệ kỹ thuật viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEditTableinTableFood_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(txtIDTableinTableFood.Text);
                string name = txbTableNameinTableFood.Text;
                TableDAO.Instance.UpdateTable(id, name);
                loadALL();
            }
            catch
            {
                MessageBox.Show("Lỗi. Vui lòng liên hệ kỹ thuật viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnShowTableinTableFood_Click(object sender, EventArgs e)
        {
            LoadTableFood();
        }

        private void dtgvTableFood_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtIDTableinTableFood.Text = dtgvTableFood.Rows[e.RowIndex].Cells[1].Value.ToString();
                txbTableNameinTableFood.Text = dtgvTableFood.Rows[e.RowIndex].Cells[2].Value.ToString();
            }
        }
        #endregion

        #region Staff

        private void btnAddStaffinStaff_Click(object sender, EventArgs e)
        {
            try
            {
                string name = txtNameStaffInStaff.Text;
                string address = txtAddressInStaff.Text;
                string phonenumber = txtPhoneNumberInStaff.Text;
                string email = txtEmailInStaff.Text;
                int type = Convert.ToInt32(cbStaffTypeInStaff.SelectedValue.ToString());
                DateTime birthdate = Convert.ToDateTime(txtBirthdateInStaff.Text);
                StaffDAO.Instance.InsertStaff(name, address, phonenumber, email, type, birthdate);
                loadALL();
            }
            catch
            {
                MessageBox.Show("Lỗi. Vui lòng liên hệ kỹ thuật viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDeleteStaffinStaff_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(txbIDStaffInStaff.Text);
                StaffDAO.Instance.DeleteStaff(id);
                loadALL();
            }
            catch
            {
                MessageBox.Show("Lỗi. Vui lòng liên hệ kỹ thuật viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEditStaffinStaff_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txbIDStaffInStaff.Text);
            string name = txtNameStaffInStaff.Text;
            string address = txtAddressInStaff.Text;
            string phonenumber = txtPhoneNumberInStaff.Text;
            string email = txtEmailInStaff.Text;
            int type = Convert.ToInt32(cbStaffTypeInStaff.SelectedValue.ToString());
            try
            {
                DateTime birthdate = Convert.ToDateTime(txtBirthdateInStaff.Text);
                StaffDAO.Instance.UpdateStaff(id, name, address, phonenumber, email, type, birthdate);
                LoadStaff();
            }
            catch
            {
                MessageBox.Show("Vui lòng kiểm tra lại ngày sinh", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            loadALL();
        }

        private void btnShowStaffinStaff_Click(object sender, EventArgs e)
        {
            LoadStaff();
        }

        private void btnAccountInStaff_Click(object sender, EventArgs e)
        {

        }

        private void dtgvStaffInStaff_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txbIDStaffInStaff.Text = dtgvStaffInStaff.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtNameStaffInStaff.Text = dtgvStaffInStaff.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtAddressInStaff.Text = dtgvStaffInStaff.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtPhoneNumberInStaff.Text = dtgvStaffInStaff.Rows[e.RowIndex].Cells[3].Value.ToString();
                txtEmailInStaff.Text = dtgvStaffInStaff.Rows[e.RowIndex].Cells[4].Value.ToString();
                cbStaffTypeInStaff.SelectedValue = dtgvStaffInStaff.Rows[e.RowIndex].Cells[6].Value;
                txtBirthdateInStaff.Text = dtgvStaffInStaff.Rows[e.RowIndex].Cells[5].Value.ToString().Substring(0, 10);
            }
        }
        #endregion

        #region StaffType
        private void btnAddInStaffType_Click(object sender, EventArgs e)
        {
            try
            {
                string name = txbNameStaffTypeInStaffType.Text;
                int wage;
                if (txbWage.Text is null)
                    wage = 0;
                else
                    wage = Convert.ToInt32(txbWage.Text);
                StaffTypeDAO.Instance.InsertType(name, wage);
                loadALL();
            }
            catch
            {
                MessageBox.Show("Lỗi. Vui lòng liên hệ kỹ thuật viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDeleteInStaffType_Click(object sender, EventArgs e)
        {
            try
            {

                int id = Convert.ToInt32(txbIDStaffTypeInStafType.Text);
                StaffTypeDAO.Instance.DeleteType(id);
                loadALL();
            }
            catch
            {
                MessageBox.Show("Lỗi. Vui lòng liên hệ kỹ thuật viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEditInStaffType_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(txbIDStaffTypeInStafType.Text);
                string name = txbNameStaffTypeInStaffType.Text;
                int wage;
                if (txbWage.Text is null)
                    wage = 0;
                else
                    wage = Convert.ToInt32(txbWage.Text);
                StaffTypeDAO.Instance.UpdateType(id, name, wage);
                loadALL();
            }
            catch
            {
                MessageBox.Show("Lỗi. Vui lòng liên hệ kỹ thuật viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnShowInStaffType_Click(object sender, EventArgs e)
        {
            LoadStaffType();
        }

        private void dtgvStaffType_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txbIDStaffTypeInStafType.Text = dtgvStaffType.Rows[e.RowIndex].Cells[0].Value.ToString();
                txbNameStaffTypeInStaffType.Text = dtgvStaffType.Rows[e.RowIndex].Cells[1].Value.ToString();
                txbWage.Text = dtgvStaffType.Rows[e.RowIndex].Cells[2].Value.ToString();
            }
        }
        #endregion

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        #region Role
        private void btnAddRole_Click(object sender, EventArgs e)
        {

            try
            {
                string name = txbRoleName.Text;
                RoleDAO.Instance.InsertRole(name);
                loadALL();
            }
            catch
            {
                MessageBox.Show("Lỗi vui lòng kiểm tra lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        private void btnDeleteRole_Click(object sender, EventArgs e)
        {

            try
            {
                int id = Convert.ToInt32(txbIDRole.Text);
                RoleDAO.Instance.DeleteRole(id);
                loadALL();
            }
            catch
            {
                MessageBox.Show("Lỗi vui lòng kiểm tra lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnEditRole_Click(object sender, EventArgs e)
        {

            try
            {
                int id = Convert.ToInt32(txbIDRole.Text);
                string name = txbRoleName.Text;
                RoleDAO.Instance.UpdateRole(id, name);
                loadALL();
            }
            catch
            {
                MessageBox.Show("Lỗi vui lòng kiểm tra lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnShowRole_Click(object sender, EventArgs e)
        {
            loadListRole();
        }

        private void dtgvRole_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txbIDRole.Text = dtgvRole.Rows[e.RowIndex].Cells[0].Value.ToString();
                txbRoleName.Text = dtgvRole.Rows[e.RowIndex].Cells[1].Value.ToString();
            }

        }
        #endregion

        #region Account

        private void btnAddAccount_Click(object sender, EventArgs e)
        {
            try
            {
                string UserName = txbUserName.Text;
                string PassWord = txbPassWord.Text;
                byte[] temp = ASCIIEncoding.ASCII.GetBytes(PassWord);
                byte[] hasData = new MD5CryptoServiceProvider().ComputeHash(temp);

                string hasPass = "";

                foreach (byte item in hasData)
                {
                    hasPass += item;
                }
                //int idRole;
                if (cbRoleInAccount.SelectedItem != null)
                {
                    int idRole = (cbRoleInAccount.SelectedItem as RoleDTO).IdRole;
                    int idStaff = (cbStaffInAccount.SelectedItem as StaffDTO).IdStaff;
                    if (PassWord != "")
                    {
                        int a = AccountDAO.Instance.getAccountByIDStaff(idStaff).Count;
                        if (AccountDAO.Instance.getAccountByIDStaff(idStaff).Count == 0)
                        {

                            //int b = AccountDAO.Instance.getAccountByUserName(UserName);
                            if (AccountDAO.Instance.getAccountByUserName(UserName) == null)
                                AccountDAO.Instance.InsertAcount(UserName, idStaff, idRole, hasPass);
                            else
                                MessageBox.Show("Tài khoản đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                        }
                        else
                        {
                            MessageBox.Show("Nhân viên đã có tài khoản", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Vui lòng điền mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    MessageBox.Show("Vui Lòng chọn loại tài khoản", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                loadALL();
            }
            catch
            {
                MessageBox.Show("Lỗi. Vui lòng liên hệ kỹ thuật viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDeleteAccount_Click(object sender, EventArgs e)
        {
            try
            {
                string UserName = txbUserName.Text;
                if(UserName != DataProvider.Instance.UserName && ( UserName != "Admin" || UserName != "admin" ))
                {
                    AccountDAO.Instance.DeleteAccount(UserName);
                    loadALL();
                }
                else
                {
                    MessageBox.Show("Không được xóa tài khoản này", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch
            {
                MessageBox.Show("Lỗi. Vui lòng liên hệ kỹ thuật viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEditAccount_Click(object sender, EventArgs e)
        {
            try
            {
                string UserName = txbUserName.Text;
                string PassWord = txbPassWord.Text;
                if (txbRePassWord.Text == txbPassWord.Text)
                {
                    byte[] temp = ASCIIEncoding.ASCII.GetBytes(PassWord);
                    byte[] hasData = new MD5CryptoServiceProvider().ComputeHash(temp);

                    string hasPass = "";

                    foreach (byte item in hasData)
                    {
                        hasPass += item;
                    }
                    int idRole = Convert.ToInt32(cbRoleInAccount.SelectedValue.ToString());
                    int idStaff = Convert.ToInt32(cbStaffInAccount.SelectedValue.ToString());
                    AccountDAO.Instance.UpdateAcount(UserName, idStaff, idRole, hasPass);
                    loadALL();
                }
                else
                {
                    MessageBox.Show("Mật không trùng nhau!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch
            {
                MessageBox.Show("Lỗi. Vui lòng liên hệ kỹ thuật viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnShowAccount_Click(object sender, EventArgs e)
        {
            loadListAccount();
        }

        private void btnLockAccount_Click(object sender, EventArgs e)
        {
            string UserName = txbUserName.Text;
            AccountDAO.Instance.LockAccount(UserName);
            loadListAccount();
        }

        private void btnUnLockAccount_Click(object sender, EventArgs e)
        {
            string UserName = txbUserName.Text;
            AccountDAO.Instance.UnLockAccount(UserName);
            loadListAccount();
        }

        private void cbStaffInAccount_SelectedValueChanged(object sender, EventArgs e)
        {
            int idStaff = (cbStaffInAccount.SelectedItem as StaffDTO).IdStaff;
            List<AccountDTO> account = AccountDAO.Instance.getAccountByIDStaff(idStaff);
            if (account.Count > 0)
            {
                txbUserName.Text = account[0].UserName;
                cbRoleInAccount.SelectedValue = account[0].IdRole;
            }
            else
            {
                txbUserName.Text = "";
                cbRoleInAccount.SelectedValue = "";
            }

        }

        private void panel44_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dtgvAccount_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel37_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cbRoleInAccount_SelectedValueChanged(object sender, EventArgs e)
        {

        }

        private void dtgvAccount_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txbUserName.Text = dtgvAccount.Rows[e.RowIndex].Cells[0].Value.ToString();
                cbRoleInAccount.SelectedValue = Convert.ToInt32(dtgvAccount.Rows[e.RowIndex].Cells[2].Value.ToString());
                cbStaffInAccount.SelectedValue = Convert.ToInt32(dtgvAccount.Rows[e.RowIndex].Cells[3].Value.ToString());
            }

        }

        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //private void dtgvCategoryinCategory_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        //{
        //    try
        //    {
        //        foreach (DataGridViewRow row in dtgvCategoryinCategory.Rows)
        //        {
        //            if (Convert.ToInt32(row.Cells["STT"].Value) % 2 == 0)
        //            {
        //                row.DefaultCellStyle.BackColor = Color.FromArgb(244, 244, 244);
        //            }
        //        }
        //    }
        //    catch
        //    {

        //    }
        //}

        //private void dtgvFood_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        //{
        //    try
        //    {
        //        foreach (DataGridViewRow row in dtgvFood.Rows)
        //        {
        //            if (Convert.ToInt32(row.Cells["STT"].Value) % 2 == 0)
        //            {
        //                row.DefaultCellStyle.BackColor = Color.FromArgb(244, 244, 244);
        //            }
        //        }
        //    }
        //    catch
        //    {

        //    }
        //}

        //private void dtgvTableFood_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        //{
        //    try
        //    {
        //        foreach (DataGridViewRow row in dtgvTableFood.Rows)
        //        {
        //            if (Convert.ToInt32(row.Cells["STT"].Value) % 2 == 0)
        //            {
        //                row.DefaultCellStyle.BackColor = Color.FromArgb(244, 244, 244);
        //            }
        //        }
        //    }
        //    catch
        //    {

        //    }

        //}

        //private void dtgvStaffInStaff_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        //{
        //    try
        //    {
        //        foreach (DataGridViewRow row in dtgvStaffInStaff.Rows)
        //        {
        //            if (Convert.ToInt32(row.Cells["STT"].Value) % 2 == 0)
        //            {
        //                row.DefaultCellStyle.BackColor = Color.FromArgb(244, 244, 244);
        //            }
        //        }
        //    }
        //    catch
        //    {

        //    }
        //}

        //private void dtgvStaffType_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        //{
        //    try
        //    {
        //        foreach (DataGridViewRow row in dtgvStaffType.Rows)
        //        {
        //            if (Convert.ToInt32(row.Cells["STT"].Value) % 2 == 0)
        //            {
        //                row.DefaultCellStyle.BackColor = Color.FromArgb(244, 244, 244);
        //            }
        //        }
        //    }
        //    catch
        //    {

        //    }
        //}

        //private void dtgvRole_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        //{
        //    try
        //    {
        //        foreach (DataGridViewRow row in dtgvRole.Rows)
        //        {
        //            if (Convert.ToInt32(row.Cells["STT"].Value) % 2 == 0)
        //            {
        //                row.DefaultCellStyle.BackColor = Color.FromArgb(244, 244, 244);
        //            }
        //        }
        //    }
        //    catch
        //    {

        //    }

        //}

        //private void dtgvAccount_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        //{
        //    try
        //    {
        //        foreach (DataGridViewRow row in dtgvAccount.Rows)
        //        {
        //            if (Convert.ToInt32(row.Cells["STT"].Value) % 2 == 0)
        //            {
        //                row.DefaultCellStyle.BackColor = Color.FromArgb(244, 244, 244);
        //            }
        //        }
        //    }
        //    catch
        //    {

        //    }
        //}
    }
}
