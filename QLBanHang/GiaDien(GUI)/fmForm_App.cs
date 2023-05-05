using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GiaDien_GUI_
{
    public partial class fmForm_App : Form
    {
        public fmForm_App()
        {
            InitializeComponent();
        }

        private void menuItemSP_Click(object sender, EventArgs e)
        {
            fmSanPham sanPham = new fmSanPham();
            sanPham.Show();
        }

        private void hóaĐơnToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            fmHDBanHang hd = new fmHDBanHang();
            hd.Show();
        }

        private void menuItemKH_Click(object sender, EventArgs e)
        {
            fmKhachHang kh = new fmKhachHang();
            kh.Show();
        }

        private void menuItemNV_Click(object sender, EventArgs e)
        {
            fmNhanVien nv = new fmNhanVien();
            nv.Show();
        }

        private void nhàCungCấpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fmNhaCungCap ncc = new fmNhaCungCap();
            ncc.Show();
        }

        private void fmForm_App_Load(object sender, EventArgs e)
        {

        }

        private void khuyếnMãiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fmKhuyenMai km = new fmKhuyenMai();
            km.Show();
        }
    }
}
