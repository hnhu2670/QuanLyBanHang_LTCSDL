using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NghiepVu;
using DTO;
using System.Data.SqlClient;
using System.Drawing.Drawing2D;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace GiaDien_GUI_
{
    public partial class fmSanPham : Form
    {
        

        Load_BUS bus = new Load_BUS();
        ChucNang_BUS ch = new ChucNang_BUS();
        NhaCungCap_BUS ncc = new NhaCungCap_BUS();  
        KhuyenMai_BUS km = new KhuyenMai_BUS();
        public fmSanPham()
        {
            InitializeComponent();
        }

        
        private void TextBox_Load()
        {
            txtMaSP.Clear();
            txtTenSP.Clear();
            txtSL.Clear();
            txtGiaBan.Clear();
            txtGiaNhap.Clear();
            txtTimMa.Clear();
            txtTimTen.Clear();
            btnLuu.Enabled = false;
            btnLuu.BackColor = Color.FromArgb(226, 228, 233);
            btnThem.Enabled = true;
            btnSua.Enabled = btnXoa.Enabled = true;
            btnTim.BackColor=btnLoad.BackColor=btnThem.BackColor=btnSua.BackColor = btnXoa.BackColor = Color.FromArgb(116, 139, 184);
        }
        private void Load_ComboboxCNN()
        {
            cmbMaNCC.DataSource = ncc.BUS_LoadNCC();
            cmbMaNCC.DisplayMember = "MaNCC";

            cmbKM.DataSource=km.BUS_LoadKhuyenMai();
            cmbKM.DisplayMember = "MaGiamGia";
            //dgvThongTin.Columns[0].Width = 150;
            //dgvThongTin.Columns[1].Width = dgvThongTin.Columns[2].Width = 250;
            //dgvThongTin.Columns[3].Width = dgvThongTin.Columns[4].Width = dgvThongTin.Columns[5].Width = 170;
        }

        private void background_Form()
        {
            label1.ForeColor = label2.ForeColor =
            label3.ForeColor = label4.ForeColor =
            label5.ForeColor = label6.ForeColor = label7.ForeColor = label8.ForeColor = Color.White;
            rdbTimMa.ForeColor = rdbTimTen.ForeColor = Color.White;
            groupBox1.ForeColor = groupBox2.ForeColor = Color.White;
           

            dgvThongTin.ForeColor = Color.Black;

            txtMaSP.ForeColor =txtSL.ForeColor=txtTenSP.ForeColor= txtGiaBan.ForeColor=txtGiaNhap.ForeColor=cmbMaNCC.ForeColor= cmbKM.ForeColor = Color.DarkBlue;
            
        }
        private void SanPham_Load(object sender, EventArgs e)
        {
            background_Form();
            
            dgvThongTin.DataSource = bus.BUS_LoadSanPham();
            Load_ComboboxCNN();
            btnLuu.BackColor = Color.FromArgb(226, 228, 233);
            txtTimMa.Enabled = false;
            txtTimTen.Enabled = false;
            btnLuu.Enabled = false;
            btnTim.BackColor = btnLoad.BackColor = btnThem.BackColor = btnSua.BackColor = btnXoa.BackColor = Color.FromArgb(116, 139, 184);


        }

        private void dgvThongTin_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            txtMaSP.Enabled = false;
            int i;
            //truy cập vào hàng hiện tại
            i=dgvThongTin.CurrentRow.Index;
            txtMaSP.Text    =   dgvThongTin.Rows[i].Cells[0].Value.ToString();
            txtTenSP.Text   =   dgvThongTin.Rows[i].Cells[1].Value.ToString();
            txtSL.Text      =   dgvThongTin.Rows[i].Cells[2].Value.ToString();
            txtGiaNhap.Text =   dgvThongTin.Rows[i].Cells[3].Value.ToString();
            txtGiaBan.Text  =   dgvThongTin.Rows[i].Cells[4].Value.ToString();
            cmbMaNCC.Text = dgvThongTin.Rows[i].Cells[6].Value.ToString();
            cmbKM.Text = dgvThongTin.Rows[i].Cells[5].Value.ToString();

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            txtMaSP.Enabled = true;
            txtMaSP.Clear();
            txtTenSP.Clear();
            txtSL.Clear();
            txtGiaBan.Clear();
            txtGiaNhap.Clear();
            btnLuu.Enabled = true;
            btnLuu.BackColor = Color.FromArgb(116, 139, 184);
            btnThem.Enabled = false;
           
            btnSua.Enabled = btnXoa.Enabled = false;
            btnSua.BackColor = btnXoa.BackColor = btnThem.BackColor = Color.FromArgb(226, 228, 233);
            txtMaSP.Focus();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            Load_BUS bus = new Load_BUS();

            try
            {
                if (txtMaSP.Text == string.Empty)
                {
                    MessageBox.Show("Chưa nhập mã sản phẩm");
                }
                else
                {
                    string str = txtMaSP.Text.Trim();
                    //int sl = (txtSL.Text);
                    //MessageBox.Show(str.Length.ToString());
                    if (str.Length >= 4 && str.Contains("SP"))
                    {
                        if ( txtTenSP.Text.Trim() == string.Empty || txtGiaBan.Text.Trim() == string.Empty || txtGiaNhap.Text.Trim() == string.Empty || txtSL.Text.Trim() == string.Empty )
                        {
                            MessageBox.Show("Nhập chưa đủ thông tin !!!!!!!!!!!!!!!!!!");
                        }
                        else if(double.Parse(txtGiaBan.Text.Trim()) < 0 || double.Parse(txtGiaNhap.Text.Trim()) < 0 || int.Parse (txtSL.Text.Trim()) <= 0 )
                        {
                            MessageBox.Show("Không được nhập giá trị âm !!!!!!!!!!!!!!!!!!");
                        }    
                        else
                        {
                            
                            SanPham_DTO s = new SanPham_DTO(txtMaSP.Text.Trim(), txtTenSP.Text.Trim(), Int32.Parse(txtSL.Text.Trim()), decimal.Parse(txtGiaNhap.Text.Trim()), decimal.Parse(txtGiaBan.Text.Trim()), cmbMaNCC.Text, cmbKM.Text);

                            ch.ThemSP(s);
                            dgvThongTin.DataSource = bus.BUS_LoadSanPham();
                            MessageBox.Show("Thêm sản phẩm thành công");
                            TextBox_Load();
                        }
                    }
                    else MessageBox.Show("Mã sản phẩm chưa đúng định dạng");
                }  
            }
            catch (SqlException)
            {
                MessageBox.Show("Mã sản phẩm đã tồn tại");
            }

            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
                MessageBox.Show("Thông tin sản phẩm chưa đúng kiểu dữ liệu");
            }
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            Load_BUS bus = new Load_BUS();

            try
            {

                if (txtMaSP.Text.Trim() != string.Empty)
                {
                    SanPham_DTO s = new SanPham_DTO(txtMaSP.Text.Trim(), txtTenSP.Text.Trim(), Int32.Parse(txtSL.Text.Trim()), decimal.Parse(txtGiaNhap.Text.Trim()), decimal.Parse(txtGiaBan.Text.Trim()), cmbMaNCC.Text, cmbKM.Text);
                    ch.XoaSP(s);
                    dgvThongTin.DataSource = bus.BUS_LoadSanPham();
                    MessageBox.Show("Xóa sản phẩm thành công");
                    TextBox_Load();
                }
                else
                    MessageBox.Show("Chọn hàng cần xóa");
               
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message, "Error");
                MessageBox.Show("Không thể xóa sản phẩm này");

            }
            
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
           // txtMaSP.Enabled=true;
            Load_BUS bus = new Load_BUS();

            try
            {
               
                if (txtMaSP.Text.Trim() != string.Empty)
                {
                    if(txtTenSP.Text.Trim() == string.Empty || txtGiaBan.Text.Trim() == string.Empty || txtGiaNhap.Text.Trim() == string.Empty || txtSL.Text.Trim() == string.Empty)
                    {
                        MessageBox.Show("Chưa nhập đủ thông tin");
                    }    
                    else
                    {
                        if (double.Parse(txtGiaBan.Text) < 0 || double.Parse(txtGiaNhap.Text) < 0 || int.Parse(txtSL.Text) <= 0)
                        {
                            MessageBox.Show("Không được nhập giá trị âm !!!!!!!!!!");
                        }
                        else
                        {
                            SanPham_DTO s = new SanPham_DTO(txtMaSP.Text.Trim(), txtTenSP.Text.Trim(), Int32.Parse(txtSL.Text.Trim()), decimal.Parse(txtGiaNhap.Text.Trim()), decimal.Parse(txtGiaBan.Text.Trim()), cmbMaNCC.Text, cmbKM.Text);
                            ch.SuaSP(s);
                            dgvThongTin.DataSource = bus.BUS_LoadSanPham();
                            MessageBox.Show("Sửa thông tin sản phẩm thành công");
                            TextBox_Load();
                        }
                    }
                   
                }
                else
                    MessageBox.Show("Chọn hàng cần sửa thông tin");
            }

            catch (Exception ex)
            {
               // MessageBox.Show(ex.Message, "Error");
               MessageBox.Show("Thông tin không đúng kiểu dữ liêu");
            }
        }
       
        private void btnTim_Click(object sender, EventArgs e)
        {
            Load_BUS bus = new Load_BUS();

            try
            {
                Load_BUS b = new Load_BUS();

                if (rdbTimMa.Checked == true)
                {
                    if(txtTimMa.Text.Trim() != string.Empty)
                    {
                        dgvThongTin.DataSource = b.BUS_TimMaSanPham(txtTimMa.Text.Trim());
                    }
                    else
                        MessageBox.Show("Nhập mã sản phẩm cần tìm");

                }
                if(rdbTimTen.Checked == true)
                {
                    if(txtTimTen.Text.Trim() != string.Empty)
                    {
                        dgvThongTin.DataSource = b.BUS_TimTenSanPham(txtTimTen.Text.Trim());
                        
                    }    
                        
                    else
                        MessageBox.Show("Nhập tên sản phẩm cần tìm");

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            dgvThongTin.DataSource = bus.BUS_LoadSanPham();
            Load_ComboboxCNN();
            TextBox_Load();
        }

        private void rdbTimMa_CheckedChanged(object sender, EventArgs e)
        {
            if(rdbTimMa.Checked == true)
            {
                txtTimMa.Enabled = true;
                txtTimTen.Clear();

            }
            else txtTimMa.Enabled = false;
        }

        private void rdbTimTen_CheckedChanged(object sender, EventArgs e)
        {
            if(rdbTimTen.Checked == true)
            {
                txtTimTen.Enabled = true;
                txtTimMa.Clear();

            }
            else txtTimTen.Enabled = false;
        }

        private void fmSanPham_Paint_1(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
           // this.ForeColor = Color.Gray;
            Rectangle gradient_rectangle = new Rectangle(0, 0, Width, Height);
           // Brush brush = new LinearGradientBrush(gradient_rectangle, Color.Blue, Color.Black, 40f);
             Brush brush = new LinearGradientBrush(gradient_rectangle, Color.FromArgb(2, 10, 87), Color.FromArgb(242, 243, 245), 40f);
            g.FillRectangle(brush, gradient_rectangle);
           
        }
    }
}

