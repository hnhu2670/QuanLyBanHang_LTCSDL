using DTO;
using NghiepVu;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GiaDien_GUI_
{

    public partial class fmDangNhap : Form
    {
        #region
        public bool s;
        #endregion

        DangNhap_BUS dangNhap = new DangNhap_BUS();
        Load_BUS bus = new Load_BUS();
        public fmDangNhap()
        {
            InitializeComponent();
        }
        string tk = "Admin";
        string mk = "123";
        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            try
            {
                string tk = txtTaiKhoan.Text.Trim();
                string mk = txtPass.Text.Trim();
                DataTable dn = dangNhap.BUS_Login(tk, mk);
                if (tk != "" && mk != "")
                {
                    if (dn.Rows.Count > 0)
                    {
                        foreach(DataRow dr in dn.Rows)
                        {
                            bool s = bool.Parse(dr[2].ToString());
                            if (s == true)
                            {
                                MessageBox.Show("Đăng nhập thành công");

                               // this.Hide();
                                fmForm_App form_App = new fmForm_App();
                                form_App.ShowDialog();
                                
                                Application.Exit();

                            }
                            else MessageBox.Show("Tài khoản nhân viên");
                        }    
                        
                    }

                    else
                    {
                        MessageBox.Show("Đăng nhập không thành công");
                    }
                }
                else
                {
                    if (tk == "" && mk == "")
                    {
                        MessageBox.Show("Chưa có thông tin đăng nhập");
                    }
                    else
                    {
                        if (tk == "")
                        {
                            MessageBox.Show("Chưa có thông tin tài khoản");
                        }
                        if (mk == "")
                        {
                            MessageBox.Show("Chưa có thông tin mật khẩu");
                        }
                    }
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult dg = MessageBox.Show("Bạn có muốn thoát ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dg == DialogResult.Yes)
                Application.Exit();
        }

       
        private void ckbShowPass_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbShowPass.Checked)
            {
                txtPass.PasswordChar = (char)0;
            }
            else
            {
                txtPass.PasswordChar = '*';
            }
        }

    }
}

