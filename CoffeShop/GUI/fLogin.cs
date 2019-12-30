using CoffeShop.DAO;
using CoffeShop.GUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoffeShop
{
    public partial class fLogin : Form
    {
        public fLogin()
        {
            InitializeComponent();
        }


        private void btnLogin_Click(object sender, EventArgs e)
        {
            //txtUserName.Text = "admin";
            //txtPassWord.Text = "admin";
            string userName = txtUserName.Text;
            string passWord = txtPassWord.Text;
            DataProvider.Instance.IdRole = Login(userName, passWord);
            if (DataProvider.Instance.IdRole != -1)
            {
                DataProvider.Instance.UserName = userName;
                fManager f = new fManager();
                txtPassWord.Text = "";
                this.Hide();
                f.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("Vui Lòng kiểm tra tài khoản hoặc mật khẩu", "Thông Báo!!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        int Login(string userName, string passWord)
        {
            return AccountDAO.Instance.Login(userName, passWord);
        }

        private void btnLogin_Click_1(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Bạn có chắc chắn đăng xuất không ?","Đăng xuất",MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                this.Close();
            }
        }

        private void txtUserName_Enter(object sender, EventArgs e)
        {
            if(txtUserName.Text == "Tên đăng nhập")
            {
                txtUserName.Text = "";
                txtUserName.ForeColor = Color.White;
                
            }
            txtPassWord.Text = "Mật khẩu";
            txtPassWord.ForeColor = Color.Peru;
            txtPassWord.UseSystemPasswordChar = false;
        }

        private void txtUserName_Leave(object sender, EventArgs e)
        {
            if (txtUserName.Text == "")
            {
                txtUserName.Text = "Tên đăng nhập";
                txtUserName.ForeColor = Color.Peru;
            }
        }

        private void txtPassWord_Enter(object sender, EventArgs e)
        {
            if (txtPassWord.Text == "Mật khẩu")
            {
                txtPassWord.Text = "";
                txtPassWord.ForeColor = Color.White;
                txtPassWord.UseSystemPasswordChar = true;
            }
        }

        private void txtPassWord_Leave(object sender, EventArgs e)
        {
        }
    }
}
