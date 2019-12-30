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
    public partial class AccountProfile : Form
    {
        public AccountProfile()
        {
            InitializeComponent();
            AccountDTO account = AccountDAO.Instance.getAccountByUserName(DataProvider.Instance.UserName);
            txbUserName.Text = account.UserName;
        }

        string HassPass(string pass)
        {
            string hasPass = "";
            byte[] temp = ASCIIEncoding.ASCII.GetBytes(pass);
            byte[] hasData = new MD5CryptoServiceProvider().ComputeHash(temp);

            foreach (byte item in hasData)
            {
                hasPass += item;
            }

            return hasPass;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                AccountDTO account = AccountDAO.Instance.getAccountByUserName(DataProvider.Instance.UserName);
                if (account.PassWord == HassPass(txbPassWord.Text) && txbNewPass.Text == txbReEnterPass.Text)
                {
                    try
                    {
                        AccountDAO.Instance.UpdateAcount(txbUserName.Text, account.IdStaff, account.IdRole, HassPass(txbNewPass.Text));
                        txbNewPass.Text = "";
                        txbPassWord.Text = "";
                        txbReEnterPass.Text = "";
                        if (MessageBox.Show("Đổi mật khẩu thành công!\n Vui lòng đăng nhập lại", "Thành công", MessageBoxButtons.OK) == System.Windows.Forms.DialogResult.OK)
                        {
                            DataProvider.Instance.UserName = null;
                            this.Close();
                        }

                    }
                    catch
                    {
                        MessageBox.Show("Đổi mật khẩu thất bại. Vui lòng kiểm tra lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }


                }
                else
                {
                    MessageBox.Show("Đổi mật khẩu thất bại. Vui lòng kiểm tra lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch
            {
                MessageBox.Show("Lỗi. Vui lòng liên hệ kỹ thuật viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }

        private void txbPassWord_TextChanged(object sender, EventArgs e)
        {



        }
    }
}
