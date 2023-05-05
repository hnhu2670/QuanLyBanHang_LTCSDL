using DTO;
using NghiepVu;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using System.Drawing.Drawing2D;
using System.Reflection.Emit;

namespace GiaDien_GUI_
{
    public partial class fmChiTietHD : Form
    {
       // HDBanHang_BUS bus = new HDBanHang_BUS();
        Load_BUS load = new Load_BUS();
        ChiTietHD_BUS ct = new ChiTietHD_BUS();
        ChucNang_BUS bus = new ChucNang_BUS();
        
        bool co= false;

        public string maHDBan;
        public fmChiTietHD()
        {
            InitializeComponent();
        }

        private void LayCTHD(string ma)
        {
            ct.BUS_ThanhTien();
            ct.UpdateTien();
            dgvThongTin.DataSource =ct.BUS_LoadCTHD (ma);
            txtMaHD.Text = ma;
        }

        private void Load_Combobox()
        {
            //List<SanPham_DTO> productList = bus.BUS_GetAllProducts();
            DataTable data = load.BUS_LoadSanPham();

            cmbMaSP.DataSource = data;
            cmbMaSP.DisplayMember = "MaSanPham";
            cmbMaSP.ValueMember = "MaSanPham";
        }
        private void background_Form()
        {
            label1.ForeColor = label2.ForeColor =
            label3.ForeColor = label5.ForeColor =  Color.White;
            labelTienThoi.BackColor = Color.White;
            labelTienThoi.ForeColor = Color.Red;
            rdbTimTen.ForeColor = Color.White;
            groupBox1.ForeColor = groupBox2.ForeColor = Color.White;


            dgvThongTin.ForeColor = Color.Black;

            txtMaHD.ForeColor = Color.DarkBlue;


        }
        void TextBox_Load()
        {
            txtTenSP.Clear();
            txtGia.Clear();
            txtGiamGia.Clear();
            txtThanhTien.Clear();
            txtTong.Clear();
            labelTienThoi.Text = string.Empty;
            //numKhachDua.Value= 0;
            cmbMaSP.Enabled = true;
            numSLMua.Enabled = true;

            btnLuu.Enabled = false;
            btnLuu.BackColor = Color.FromArgb(226, 228, 233);
            btnThem.Enabled = true;
            btnXoa.Enabled = true;
            btnTong.BackColor=btnTim.BackColor = btnLoad.BackColor = btnThem.BackColor =  btnXoa.BackColor = Color.FromArgb(116, 139, 184);


        }

        private void fmChiTietHD_Load(object sender, EventArgs e)
        {
            background_Form();  
            LayCTHD(maHDBan);
            Load_Combobox();
            btnLuu.BackColor = Color.FromArgb(226, 228, 233);
            txtTimTen.Enabled = false;
            btnLuu.Enabled = false;
            btnTong.BackColor=btnTim.BackColor = btnLoad.BackColor = btnThem.BackColor = btnXoa.BackColor = Color.FromArgb(116, 139, 184);

            // cmbMaSP.SelectedIndex = 1; 
            //co = true;
        }

        private void dgvThongTin_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            cmbMaSP.Enabled = false;
            numSLMua.Enabled = false;
           
            int i;
            //truy cập vào hàng hiện tại
            i = dgvThongTin.CurrentRow.Index;
           
            cmbMaSP.Text       =     dgvThongTin.Rows[i].Cells[1].Value.ToString();
            txtTenSP.Text      =     dgvThongTin.Rows[i].Cells[2].Value.ToString();
            txtGia.Text        =     dgvThongTin.Rows[i].Cells[3].Value.ToString();
            txtGiamGia.Text    =     dgvThongTin.Rows[i].Cells[4].Value.ToString();
            numSLMua.Text      =     dgvThongTin.Rows[i].Cells[5].Value.ToString();
            txtThanhTien.Text  =     dgvThongTin.Rows[i].Cells[6].Value.ToString();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {

            txtTenSP.Clear();
            txtGia.Clear();
            txtGiamGia.Clear();
            txtThanhTien.Clear();
            txtTong.Clear();
            labelTienThoi.Text = string.Empty;
            cmbMaSP.Enabled = true;
            numSLMua.Enabled = true;
            btnLuu.Enabled = true;
            
            btnLuu.BackColor = Color.FromArgb(116, 139, 184);
            btnThem.Enabled = false;
            btnXoa.Enabled = false;
            btnXoa.BackColor = btnThem.BackColor = Color.FromArgb(226, 228, 233);
           
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                if(txtTenSP.Text.Trim() == string.Empty || txtGia.Text.Trim() == string.Empty || txtGiamGia.Text.Trim() == string.Empty || numSLMua.Value == 0)
                {
                    MessageBox.Show("Chưa đủ thông tin ");
                }   
                else
                {
                    ChiTietHD_DTO c = new ChiTietHD_DTO();

                    c.IdHD = txtMaHD.Text.Trim();
                    c.IdSP = cmbMaSP.Text.Trim();
                    c.SlBan = int.Parse(numSLMua.Text);
                    c.Tien = 0;

                    ct.BUS_ThanhTien();
                    ct.UpdateTien();

                    //MessageBox.Show(ct.BUS_ThanhTien().ToString());
                    ct.BUS_ThemCTHD(c);
                    LayCTHD(maHDBan);
                    MessageBox.Show("Thêm sản phẩm thành công");
                    TextBox_Load();
                }    
                

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            } 
            
        }

        private void cmbMaSP_SelectedIndexChanged(object sender, EventArgs e)
        {
            numSLMua.Text = null;
            txtThanhTien.Text = null;
            //SanPham_DTO s = new SanPham_DTO();
            //string name = cmbMaSP.SelectedValue.ToString();
            //string id = cmbMaSP.Text;
            ct.BUS_ThanhTien();

            ct.UpdateTien();

            txtTenSP.Text = ct.LayTen_ByCBB(cmbMaSP.Text);
            txtGia.Text = ct.LayGiaSP_ByCBB(cmbMaSP.Text);
            txtGiamGia.Text = ct.LayGiamGia_ByCBB(cmbMaSP.Text);

            DataTable dataTable = load.BUS_LoadSanPham();
           // DataRow[] rows = dataTable.Select(id);

            //if (rows.Length > 0)
            //{
            //    string price = rows[0]["Giá bán"].ToString();
            //    txtGia.Text = price;
            //}
        }

        private void txtSLMua_TextChanged(object sender, EventArgs e)
        {
            try
            {
                ct.BUS_ThanhTien();

                 ct.UpdateTien();

                //double gia = double.Parse(txtGia.Text);
                //double sl = double.Parse(txtSLMua.Text);
                //double giamgia = double.Parse(txtGiamGia.Text);

                if (numSLMua.Text != null)
                {
                    string gia = txtGia.Text;
                    string sl = numSLMua.Text;
                    string giamgia = txtGiamGia.Text;

                    double tong = (double.Parse(gia) * int.Parse(sl) - double.Parse(gia) * int.Parse(sl) * double.Parse(giamgia));
                    txtThanhTien.Text = tong.ToString();
                }
                //DateTime ngayKM = ct.LayNgayKM_ByCBB(cmbMaSP.Text);

                //if (numSLMua.Text != null)
                //{

                //    string gia = txtGia.Text;
                //    string sl = numSLMua.Text;
                //    string giamgia = txtGiamGia.Text;
                //    double tong = 0;
                //    if (ngayKM < DateTime.Now)
                //    {
                //        MessageBox.Show(ngayKM.ToString() + "Mã khuyến mãi hết hạn");
                //        tong = (double.Parse(gia) * int.Parse(sl) - double.Parse(gia) * int.Parse(sl) * 0);
                //        txtThanhTien.Text = tong.ToString();
                //    }
                //    else
                //    {
                //        MessageBox.Show(ngayKM.ToString() + "Mã khuyến mãi hợp lệ");
                //        tong = (double.Parse(gia) * int.Parse(sl) - double.Parse(gia) * int.Parse(sl) * double.Parse(giamgia));
                //        txtThanhTien.Text = tong.ToString();
                //    }

                //}


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            };
        }

        private void numSLMua_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                ct.BUS_ThanhTien();

                ct.UpdateTien();
                //double gia = double.Parse(txtGia.Text);
                //double sl = double.Parse(txtSLMua.Text);
                //double giamgia = double.Parse(txtGiamGia.Text);
                DateTime ngayKM = ct.LayNgayKM_ByCBB(cmbMaSP.Text);
                
                string soluong = ct.LaySoLuong_ByCBB(cmbMaSP.Text);
                double SoLuong = double.Parse(soluong);
                if(double.Parse(numSLMua.Text) <= SoLuong)
                {
                    if (numSLMua.Text != null)
                    {
                        
                        string gia = txtGia.Text;
                        string sl = numSLMua.Text;
                        string giamgia = txtGiamGia.Text;
                        double tong = 0;
                        if(ngayKM < DateTime.Now)
                        {
                            MessageBox.Show(ngayKM.ToString() + " Mã khuyến mãi hết hạn");
                            tong = (double.Parse(gia) * int.Parse(sl) - double.Parse(gia) * int.Parse(sl) * 0);
                            txtThanhTien.Text = tong.ToString();
                        }
                        else
                        {
                            MessageBox.Show(ngayKM.ToString() + " Mã khuyến mãi hợp lệ");
                            tong = (double.Parse(gia) * int.Parse(sl) - double.Parse(gia) * int.Parse(sl) * double.Parse(giamgia));
                            txtThanhTien.Text = tong.ToString();
                        }
                        
                    }
                }else
                {
                    MessageBox.Show("Số lượng mua vượt quá số lượng trong kho");
                    numSLMua.Text = ct.LaySoLuong_ByCBB(cmbMaSP.Text);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Đã xảy ra lỗi");
            };
        }

        //private void btnSua_Click(object sender, EventArgs e)
        //{
        //    //try
        //    //{
        //        //ChiTietHD_DTO hd = new ChiTietHD_DTO(txtMaHD.Text,cmbMaSP.Text,int.Parse(numSLMua.Text),float.Parse(txtThanhTien.Text));
        //        if (txtMaHD.Text != String.Empty)
        //        {
        //            ct.BUS_SuaCTHD(cmbMaSP.Text, int.Parse(numSLMua.Text));
        //            ct.UpdateTien();
        //            dgvThongTin.DataSource = ct.BUS_LoadCTHD(txtMaHD.Text);
        //            MessageBox.Show("Sửa thông tin chi tiet hoa don thành công");
        //        }
        //        else MessageBox.Show("Chọn hàng cần sửa");
        //    //}
        //    //catch (Exception ex)
        //    //{
        //    //    MessageBox.Show(ex.Message, "Error");
        //    //}
        //}

        private void btnLoad_Click(object sender, EventArgs e)
        {
            //LayCTHD(maHDBan);
            Load_Combobox();
            TextBox_Load();
            txtTong.Text = null;
            numKhachDua.Text = null;
            dgvThongTin.DataSource = ct.BUS_LoadCTHD(txtMaHD.Text);

        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                ct.BUS_XoaCTHD(cmbMaSP.Text);
                dgvThongTin.DataSource = ct.BUS_LoadCTHD(txtMaHD.Text);
                MessageBox.Show("Xóa sản phẩm thành công");
            }
            catch(Exception ex)
            {
                //MessageBox.Show(ex.Message);
                MessageBox.Show("Không thể xóa sản phẩm này");
            }
        }

        private void btnTong_Click(object sender, EventArgs e)
        {
            //dgvThongTin.DataSource = ct.BUS_LoadCTHD(txtMaHD.Text);
            double tong = 0;
            int colIndex = dgvThongTin.Columns["ThanhTien"].Index;
            for (int i = 0; i < dgvThongTin.RowCount - 1; i++)
            {
                tong += double.Parse(dgvThongTin.Rows[i].Cells[colIndex].Value.ToString());
            }
            txtTong.Text = tong.ToString(); 
        }

        private void numKhachDua_ValueChanged(object sender, EventArgs e)
        {
            
            try
            {
                ct.BUS_ThanhTien();

                ct.UpdateTien();

                if (txtTong.Text != null)
                {
                    string tong = txtTong.Text;
                    string tienkhachdua = numKhachDua.Text;
                    //MessageBox.Show(tong + "xxxxxxxxxx " + tienkhachdua);
                    double tienthoi = double.Parse(tong) - double.Parse(tienkhachdua);
                    if (tienthoi <= 0)
                    {
                        labelTienThoi.Text = (tienthoi * -1).ToString();
                    }
                    else
                    {
                        MessageBox.Show("Số tiền chưa đủ !!!!");
                    }
                }
                else
                    MessageBox.Show("bug");
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            };
        }

        private void fmChiTietHD_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Rectangle gradient_rectangle = new Rectangle(0, 0, Width, Height);
            Brush brush = new LinearGradientBrush(gradient_rectangle, Color.FromArgb(2, 10, 87), Color.FromArgb(242, 243, 245), 40f);
            g.FillRectangle(brush, gradient_rectangle);
        }

        private void rdbTimMa_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbTimTen.Checked == true)
            {
                txtTimTen.Enabled = true;
            }
            else txtTimTen.Enabled = false;
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            ChiTietHD_BUS c = new ChiTietHD_BUS();
            try
            {
                if (rdbTimTen.Checked == true)
                {
                    if(txtTimTen.Text.Trim() != string.Empty)
                    {
                        dgvThongTin.DataSource = c.BUS_SP_LoadCTHD(txtMaHD.Text, txtTimTen.Text);
                    }
                    else
                    {
                        MessageBox.Show("Nhập tên sản phẩm cần tìm");
                    }    
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
