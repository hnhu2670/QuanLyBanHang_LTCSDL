using DTO;
using NghiepVu;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GiaDien_GUI_
{
    public partial class fmKhachHang : Form
    {
        Load_BUS bus = new Load_BUS();
        ChucNang_BUS ch = new ChucNang_BUS();
        public fmKhachHang()
        {
            InitializeComponent();
        }
        private void background_Form()
        {
            label1.ForeColor = label2.ForeColor =
            label3.ForeColor = label4.ForeColor =
            label5.ForeColor =label7.ForeColor = Color.White;
            rdbTimMa.ForeColor = rdbTimTen.ForeColor = Color.White;
            groupBox1.ForeColor = groupBox2.ForeColor = Color.White;


            dgvThongTin.ForeColor = Color.Black;
            dateNS.CalendarForeColor = txtMaKH.ForeColor = txtTenKH.ForeColor = txtDiaChi.ForeColor = txtDienThoai.ForeColor = Color.DarkBlue;


        }
        private void KhachHang_Load(object sender, EventArgs e)
        {
            background_Form();
            dgvThongTin.DataSource = bus.BUS_LoadKhachHang();
            btnLuu.BackColor = Color.FromArgb(226, 228, 233);
            txtTimMa.Enabled = false;
            txtTimTen.Enabled = false;
            btnLuu.Enabled = false;
            btnTim.BackColor = btnLoad.BackColor = btnThem.BackColor = btnSua.BackColor = btnXoa.BackColor = Color.FromArgb(116, 139, 184);
        }

        private void dgvThongTin_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int i;
            i = dgvThongTin.CurrentRow.Index;
            txtMaKH.Text = dgvThongTin.Rows[i].Cells[0].Value.ToString();
            txtTenKH.Text = dgvThongTin.Rows[i].Cells[1].Value.ToString();
            txtDiaChi.Text = dgvThongTin.Rows[i].Cells[2].Value.ToString();
            txtDienThoai.Text = dgvThongTin.Rows[i].Cells[3].Value.ToString();
            dateNS.Text= dgvThongTin.Rows[i].Cells[4].Value.ToString();
            txtMaKH.Enabled = false;
        }
        void TextBox_Load()
        {
            txtMaKH.Clear();
            txtTenKH.Clear();
            txtDienThoai.Clear();
            txtDiaChi.Clear();
            txtTimTen.Clear();
            txtTimMa.Clear();
            dateNS.Value = DateTime.Now;
            btnLuu.Enabled = false;
            btnLuu.BackColor = Color.FromArgb(226, 228, 233);
            btnThem.Enabled = true;
            btnSua.Enabled = btnXoa.Enabled = true;
            btnTim.BackColor = btnLoad.BackColor = btnThem.BackColor = btnSua.BackColor = btnXoa.BackColor = Color.FromArgb(116, 139, 184);

        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            txtMaKH.Clear();
            txtTenKH.Clear();
            txtDienThoai.Clear();
            txtDiaChi.Clear();
            txtMaKH.Enabled = true;
            btnLuu.Enabled = true;
            btnLuu.BackColor = Color.FromArgb(116, 139, 184);
            btnThem.Enabled = false;
            dateNS.Value= DateTime.Now;

            btnSua.Enabled = btnXoa.Enabled = false;
            btnSua.BackColor = btnXoa.BackColor = btnThem.BackColor = Color.FromArgb(226, 228, 233);
            txtMaKH.Focus();
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
           // bool id = false;
            try
            {
                
                if (txtMaKH.Text.Trim() == string.Empty)
                {
                    MessageBox.Show ("Chưa nhập mã khách hàng");
                }
                else
                {
                    string str = txtMaKH.Text.Trim();
                    //MessageBox.Show(str.Length.ToString());
                    if (str.Length >= 4 && str.Contains("KH"))
                    {
                        if(txtDiaChi.Text.Trim() == string.Empty || txtDienThoai.Text.Trim()==string.Empty || txtTenKH.Text.Trim() == string.Empty)
                        {
                            MessageBox.Show("Nhập chưa đủ thông tin !!!!!!!!!!!!!!!!!!");
                        }
                        else
                        {
                            KhachHang_DTO k = new KhachHang_DTO(txtMaKH.Text.Trim(), txtTenKH.Text.Trim(), txtDiaChi.Text.Trim(), txtDienThoai.Text.Trim(), DateTime.Parse(dateNS.Text));
                            ch.ThemKH(k);
                            dgvThongTin.DataSource = bus.BUS_LoadKhachHang();
                            MessageBox.Show("Thêm khách thành công");
                            TextBox_Load();
                        }    
                    }
                    else MessageBox.Show("Mã khách hàng chưa đúng định dạng");
                }
            }
            catch (SqlException)
            {
                MessageBox.Show("Mã khách hàng đã tồn tại");
            }

            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
                MessageBox.Show("Thông tin khách hàng chưa đúng kiểu dữ liệu");
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMaKH.Text.Trim() != String.Empty)
                {
                    if (txtTenKH.Text.Trim() == string.Empty || txtDiaChi.Text.Trim() == string.Empty ||  txtDienThoai.Text.Trim() == string.Empty)
                    {
                        MessageBox.Show("Chưa đủ thông tin khách hàng !!!!!!!!!!!!!!!!!!!!");
                    }  
                    else
                    {
                        KhachHang_DTO k = new KhachHang_DTO(txtMaKH.Text.Trim(), txtTenKH.Text.Trim(), txtDiaChi.Text.Trim(), txtDienThoai.Text.Trim(), DateTime.Parse(dateNS.Text));
                        ch.SuaKH(k);
                        dgvThongTin.DataSource = bus.BUS_LoadKhachHang();
                        MessageBox.Show("Sửa thông tin khách hàng thành công");
                    }    
                }
                else MessageBox.Show("Chọn hàng cần sửa");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {

                if (txtMaKH.Text != String.Empty)
                {
                    KhachHang_DTO k = new KhachHang_DTO(txtMaKH.Text, txtTenKH.Text, txtDiaChi.Text, txtDienThoai.Text, DateTime.Parse(dateNS.Text));
                    ch.XoaKH(k);
                    dgvThongTin.DataSource = bus.BUS_LoadKhachHang();
                    MessageBox.Show("Xóa thành công");
                    TextBox_Load();
                }
                else MessageBox.Show("Chọn hàng cần xóa");
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể xóa khách hàng này");
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            dgvThongTin.DataSource = bus.BUS_LoadKhachHang();
            TextBox_Load();
        }
        private void rdbTimMa_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbTimMa.Checked == true)
            {
                txtTimMa.Enabled = true;
                txtTimTen.Clear();
            }
            else txtTimMa.Enabled = false;
        }

        private void rdbTimTen_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbTimTen.Checked == true)
            {
                    txtTimTen.Enabled = true;
                    txtTimMa.Clear();
            }
            else txtTimTen.Enabled = false;
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            try
            {
                if (rdbTimMa.Checked == true)
                {
                    if (txtTimMa.Text.Trim() != string.Empty)
                    {
                        dgvThongTin.DataSource = bus.BUS_TimMaKhachHang(txtTimMa.Text.Trim());

                    }
                    else
                        MessageBox.Show("Nhập mã khách hàng cần tìm kiếm");


                }
                if (rdbTimTen.Checked == true)
                {
                    if(txtTimTen.Text.Trim() != string.Empty)
                    {
                        dgvThongTin.DataSource = bus.BUS_TimTenKhachHang(txtTimTen.Text.Trim());

                    }
                    else
                        MessageBox.Show("Nhập tên khách hàng cần tìm kiếm");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void fmKhachHang_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Rectangle gradient_rectangle = new Rectangle(0, 0, Width, Height);
            Brush brush = new LinearGradientBrush(gradient_rectangle, Color.FromArgb(2, 10, 87), Color.FromArgb(242, 243, 245), 40f);
            g.FillRectangle(brush, gradient_rectangle);
        }

        
    }
}
