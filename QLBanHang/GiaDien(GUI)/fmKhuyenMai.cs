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
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GiaDien_GUI_
{
    public partial class fmKhuyenMai : Form
    {

        KhuyenMai_BUS bus = new KhuyenMai_BUS();
        public fmKhuyenMai()
        {
            InitializeComponent();
        }


        public void Load_KhuyenMai()
        {
           
        }
        private void dgvThongTin_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            txtMaKM.Enabled= false;
            int i;
            i = dgvThongTin.CurrentRow.Index;
            txtMaKM.Text= dgvThongTin.Rows[i].Cells[0].Value.ToString();
            txtGiaTri.Text = dgvThongTin.Rows[i].Cells[1].Value.ToString();
            dateBD.Text = dgvThongTin.Rows[i].Cells[2].Value.ToString();
            dateKT.Text = dgvThongTin.Rows[i].Cells[3].Value.ToString();
        }

       
        private void TextBox_Load()
        {
            txtMaKM.Clear();
            txtGiaTri.Clear();

            txtMaKM.Focus();
            txtMaKM.Enabled= true; 
            txtTimMa.Enabled = false;

            btnLuu.Enabled = false;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnTim.Enabled = true;

            rdbTimMa.Checked = false;
            
            btnLuu.Enabled = false;
            btnLuu.BackColor = Color.FromArgb(226, 228, 233);
            btnThem.Enabled = true;
            btnSua.Enabled = btnXoa.Enabled = true;
            btnTim.BackColor = btnLoad.BackColor = btnThem.BackColor = btnSua.BackColor = btnXoa.BackColor = Color.FromArgb(116, 139, 184);
        }
        private void background_Form()
        {
            label1.ForeColor = label2.ForeColor =
            label3.ForeColor = label4.ForeColor =
            label5.ForeColor =  Color.White;
            rdbTimMa.ForeColor =  Color.White;
            groupBox1.ForeColor = groupBox2.ForeColor = Color.White;


            dgvThongTin.ForeColor = Color.Black;

            txtMaKM.ForeColor=txtGiaTri.ForeColor =Color.DarkBlue;

        }
        private void fmKhuyenMai_Load(object sender, EventArgs e)
        {
            background_Form();
            dgvThongTin.DataSource = bus.BUS_LoadKhuyenMai();

            btnLuu.BackColor = Color.FromArgb(226, 228, 233);
            txtTimMa.Enabled = false;
            btnLuu.Enabled = false;
            btnTim.BackColor = btnLoad.BackColor = btnThem.BackColor = btnSua.BackColor = btnXoa.BackColor = Color.FromArgb(116, 139, 184);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            txtMaKM.Clear();
            txtGiaTri.Clear();
            
            btnLuu.Enabled = true;
            btnLuu.BackColor = Color.FromArgb(116, 139, 184);
            btnThem.Enabled = false;
            txtMaKM.Enabled= true; 
            btnSua.Enabled = btnXoa.Enabled = false;
            btnSua.BackColor = btnXoa.BackColor = btnThem.BackColor = Color.FromArgb(226, 228, 233);
            txtMaKM.Focus();
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            DateTime ngayKT = dateKT.Value;
            DateTime ngayBD = dateBD.Value;
            try
            {
                if (txtMaKM.Text == string.Empty)
                {
                    MessageBox.Show("Chưa nhập mã khuyến mãi");
                }
                else
                {
                    string str = txtMaKM.Text;
                    //MessageBox.Show(str.Length.ToString());
                    if (str.Length >= 4 && str.Contains("KM"))
                    {
                        if ( txtGiaTri.Text == string.Empty)
                        {
                            MessageBox.Show("Nhập chưa đủ thông tin!!!!!!!!!!!!!!!!!!");
                        }
                        else
                        {
                            if(float.Parse(txtGiaTri.Text.Trim()) < 0 || float.Parse(txtGiaTri.Text.Trim())>1)
                            {
                                MessageBox.Show("Khuyến mãi có giá trị từ 0 - 1");
                            }    
                            else
                            {
                                if(ngayBD>ngayKT)
                                {
                                    MessageBox.Show("Ngày bắt đầu KM phải trước ngày KT khuyến mãi");
                                }    
                                else
                                { 
                                    KhuyenMai_DTO k = new KhuyenMai_DTO(txtMaKM.Text.Trim(), float.Parse(txtGiaTri.Text.Trim()), dateBD.Value, dateKT.Value);
                                    bus.ThemKM(k);
                                    dgvThongTin.DataSource = bus.BUS_LoadKhuyenMai();
                                    MessageBox.Show("Thêm khuyến mãi thành công");
                                    TextBox_Load();
                                }    
                                
                            }
                           
                        }
                    }
                    else MessageBox.Show("Mã khuyến mãi chưa đúng định dạng");
                }
               
            }
            catch (SqlException)
            {
                MessageBox.Show("Mã khuyến mãi đã tồn tại");
            }

            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
                MessageBox.Show("Kiểu dữ liệu chưa chính xác");
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            DateTime ngayKT = dateKT.Value;
            DateTime ngayBD = dateBD.Value;
            txtMaKM.Enabled= false;
            try
            {
                
                if (txtMaKM.Text.Trim() != string.Empty)
                {
                    if(txtGiaTri.Text == string.Empty)
                        MessageBox.Show("Chưa nhập đủ thông tin !!!!!!!!!!!!!!!");
                    else
                    {
                        if (float.Parse(txtGiaTri.Text.Trim()) < 0 || float.Parse(txtGiaTri.Text.Trim()) > 1)
                        {
                            MessageBox.Show("Khuyến mãi có giá trị từ 0 - 1");
                        }
                        else
                        {
                            if (ngayBD > ngayKT)
                            {
                                MessageBox.Show("Ngày bắt đầu KM phải trước ngày KT khuyến mãi");
                            }
                            else
                            {
                                KhuyenMai_DTO k = new KhuyenMai_DTO(txtMaKM.Text.Trim(), float.Parse(txtGiaTri.Text.Trim()), dateBD.Value, dateKT.Value);
                                bus.SuaKM(k);
                                dgvThongTin.DataSource = bus.BUS_LoadKhuyenMai();
                                MessageBox.Show("Sửa thông tin khuyến mãi thành công");
                                TextBox_Load();
                            }
                            
                        }
                    }    
                }

                else
                    MessageBox.Show("Chọn hàng cần sửa thông tin");
            }

            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message, "Error");
                MessageBox.Show("Thông tin không đúng kiểu dữ liêu");
                //MessageBox.Show("");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {

                if (txtMaKM.Text != string.Empty)
                {
                    KhuyenMai_DTO k = new KhuyenMai_DTO(txtMaKM.Text, float.Parse(txtGiaTri.Text), dateBD.Value, dateKT.Value);
                    bus.XoaKM(k);
                    dgvThongTin.DataSource = bus.BUS_LoadKhuyenMai();
                    MessageBox.Show("Xóa khuyến mãi thành công");
                    TextBox_Load();
                }
                else
                    MessageBox.Show("Chọn hàng cần xóa");

            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message, "Error");
                MessageBox.Show("Không thể xóa khuyến mãi này");

            }
        }
        private void btnLoad_Click(object sender, EventArgs e)
        {
            dgvThongTin.DataSource = bus.BUS_LoadKhuyenMai();
            TextBox_Load();
        }
        private void rdbTimMa_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbTimMa.Checked == true)
            {
                txtTimMa.Enabled = true;
            }
            else txtTimMa.Enabled = false;
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            try
            {
                if (rdbTimMa.Checked == true)
                {
                    if (txtTimMa.Text != string.Empty) 
                        dgvThongTin.DataSource = bus.BUS_TimMaKhuyenMai(txtTimMa.Text);
                    else MessageBox.Show("Chưa nhập thông tin cần tìm");
                }
                else
                {
                    txtTimMa.Enabled = false;
                    MessageBox.Show("Chưa nhập thông tin cần tìm");

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void fmKhuyenMai_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Rectangle gradient_rectangle = new Rectangle(0, 0, Width, Height);
            Brush brush = new LinearGradientBrush(gradient_rectangle, Color.FromArgb(2, 10, 87), Color.FromArgb(242, 243, 245), 40f);
            g.FillRectangle(brush, gradient_rectangle);
        }
    }
}
