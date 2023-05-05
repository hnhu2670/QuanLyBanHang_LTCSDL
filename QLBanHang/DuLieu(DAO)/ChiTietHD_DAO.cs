using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace DuLieu_DAO_
{
    public class ChiTietHD_DAO
    {
        QuanLyBanHangDataContext db = new QuanLyBanHangDataContext();
        Connection c= new Connection();
        public DataTable Load_CTHD(string maHDBan)
        {
          
                SqlDataAdapter da;
                DataTable dt = new DataTable();
                string query =
                    "select hd.MaHDBan, sp.MaSanPham, sp.TenSanPham,sp.GiaBan, km.GiamGia, ct.SLBan, ct.ThanhTien " +
                    "from ChiTietHoaDon ct , SanPham sp , HoaDonBanHang hd, KhuyenMai km " +
                    "where ct.MaSanPham = sp.MaSanPham and ct.MaHDBan = hd.MaHDBan and km.MaGiamGia = sp.MaGiamGia and hd.MaHDBan like '" + maHDBan + "'";

                da = new SqlDataAdapter(query, c.Connect());
                da.Fill(dt);
                return dt;
            
            
        }
        public DataTable Load_SP_CTHD(string maHDBan,string tensp)
        {

            SqlDataAdapter da;
            DataTable dt = new DataTable();
            string query =
                "select hd.MaHDBan, sp.MaSanPham, sp.TenSanPham,sp.GiaBan, km.GiamGia, ct.SLBan, ct.ThanhTien " +
                "from ChiTietHoaDon ct , SanPham sp , HoaDonBanHang hd, KhuyenMai km " +
                "where ct.MaSanPham = sp.MaSanPham and ct.MaHDBan = hd.MaHDBan and km.MaGiamGia = sp.MaGiamGia and hd.MaHDBan like '" + maHDBan + "' and sp.TenSanPham like '%" + tensp + "%'";

            da = new SqlDataAdapter(query, c.Connect());
            da.Fill(dt);
            return dt;


        }
        public void UpdateTien()
        {
            SqlDataAdapter da;
            DataTable dt = new DataTable();
            string query =
                "update ChiTietHoaDon set ThanhTien = sp.GiaBan*ct.SLBan-(sp.GiaBan*ct.SLBan)*km.GiamGia " +
                "from ChiTietHoaDon ct , SanPham sp, HoaDonBanHang hd, KhuyenMai km " +
                "where ct.MaSanPham = sp.MaSanPham and ct.MaHDBan = hd.MaHDBan and km.MaGiamGia = sp.MaGiamGia and km.ThoiGianKT > getdate()";
            //string query =
            //    "update ChiTietHoaDon set ThanhTien = sp.GiaBan*ct.SLBan-(sp.GiaBan*ct.SLBan)*km.GiamGia " +
            //    "from ChiTietHoaDon ct , SanPham sp, HoaDonBanHang hd, KhuyenMai km " +
            //    "where ct.MaSanPham = sp.MaSanPham and ct.MaHDBan = hd.MaHDBan and km.MaGiamGia = sp.MaGiamGia";
            da = new SqlDataAdapter(query, c.Connect());
            da.Fill(dt);
        }

        public void ThanhTien()
        {
            SqlDataAdapter da;
            DataTable dt = new DataTable();
            // string query = "update KhuyenMai set GiamGia = 0 from KhuyenMai where ThoiGianKT < GETDATE();";
            string query =
                "update ChiTietHoaDon set ThanhTien = sp.GiaBan*ct.SLBan-(sp.GiaBan*ct.SLBan)*0 " +
                "from ChiTietHoaDon ct , SanPham sp, HoaDonBanHang hd, KhuyenMai km " +
                "where ct.MaSanPham = sp.MaSanPham and ct.MaHDBan = hd.MaHDBan and km.MaGiamGia = sp.MaGiamGia and  km.ThoiGianKT < getdate()";
            da = new SqlDataAdapter(query, c.Connect());
            da.Fill(dt);
        }
        public bool Them_CTHD(ChiTietHD_DTO ct)
        {
            using (var cont = new QuanLyBanHangDataContext())
            {
                var ins = new ChiTietHoaDon()
                {
                    MaHDBan= ct.IdHD,
                    MaSanPham=ct.IdSP,
                    SLBan = ct.SlBan,
                    ThanhTien= ct.Tien
                };
                cont.ChiTietHoaDons.InsertOnSubmit(ins);
                cont.SubmitChanges();

            }
            return true;
        }
        //public bool thanhTien(KhuyenMai_DTO ct)
        //{
        //    using (var cont = new QuanLyBanHangDataContext())
        //    {
        //        var ngay = cont.KhuyenMais;

        //        //var orders = context.Orders;


        //    }
        //    return true;
        //}
        public string LayTen(string cmbMaSP)
        {
            // Lấy mã sản phẩm từ ComboBox
            string txtTenSP;
            // Tìm sản phẩm trong danh sách sản phẩm
            SanPham selectedProduct = db.SanPhams.FirstOrDefault(p => p.MaSanPham == cmbMaSP);

            // Nếu tìm thấy sản phẩm, hiển thị tên sản phẩm trên Textbox txtTenSP
            if (selectedProduct != null)
            {
                txtTenSP = selectedProduct.TenSanPham;
                return txtTenSP;
            }
            return "loi";

        }
        public string LayGia(string cmbMaSP)
        {
            // Lấy mã sản phẩm từ ComboBox
            string txt;
            // Tìm sản phẩm trong danh sách sản phẩm
            SanPham selectedProduct = db.SanPhams.FirstOrDefault(p => p.MaSanPham == cmbMaSP);

            // Nếu tìm thấy sản phẩm, hiển thị tên sản phẩm trên Textbox txtTenSP
            if (selectedProduct != null)
            {
                txt = selectedProduct.GiaBan.ToString();
                return txt;
            }
            return "loi";

        }
        public string LaySoluong(string cmbMaSP)
        {
            // Lấy mã sản phẩm từ ComboBox
            string txt;
            // Tìm sản phẩm trong danh sách sản phẩm
            SanPham selectedProduct = db.SanPhams.FirstOrDefault(p => p.MaSanPham == cmbMaSP);

            // Nếu tìm thấy sản phẩm, hiển thị tên sản phẩm trên Textbox txtTenSP
            if (selectedProduct != null)
            {
                txt = selectedProduct.SoLuong.ToString();
                return txt;
            }
            return "loi";

        }
        //public string LaySLTonKho(string cmbMaSP)
        //{
        //    // Lấy mã sản phẩm từ ComboBox
        //    string txt;
        //    // Tìm sản phẩm trong danh sách sản phẩm
        //    SanPham selectedProduct = db.SanPhams.FirstOrDefault(p => p.MaSanPham == cmbMaSP);

        //    // Nếu tìm thấy sản phẩm, hiển thị tên sản phẩm trên Textbox txtTenSP
        //    if (selectedProduct != null)
        //    {
        //        txt = selectedProduct.SoLuong.ToString();
        //        return txt;
        //    }
        //    return "loi";

        //}
        public string LayGiamGia(string ma)
        {
            // Lấy mã sản phẩm từ ComboBox
            string txt, txt2;

            // Tìm sản phẩm trong danh sách sản phẩm
            SanPham selectedProduct = db.SanPhams.FirstOrDefault(p => p.MaSanPham == ma);

            // Nếu tìm thấy sản phẩm, hiển thị tên sản phẩm trên Textbox txtTenSP
            if (selectedProduct != null)
            {
                txt = selectedProduct.MaGiamGia;

                KhuyenMai selectedProducts = db.KhuyenMais.FirstOrDefault(p => p.MaGiamGia == txt);

                // Nếu tìm thấy sản phẩm, hiển thị tên sản phẩm trên Textbox txtTenSP
                if (selectedProducts != null)
                {

                    txt2 = selectedProducts.GiamGia.ToString();
                    return txt2;
                }
            }
            return "loi";
        }

        public DateTime layNgayKM (string ma)
        {
            DateTime ngayKM;
            string txt;
            SanPham selectedProduct = db.SanPhams.FirstOrDefault(p => p.MaSanPham == ma);
            if(selectedProduct != null)
            {
                txt = selectedProduct.MaGiamGia;

                KhuyenMai selectedProducts = db.KhuyenMais.FirstOrDefault(p => p.MaGiamGia == txt);
                if (selectedProducts != null)
                {

                    ngayKM = selectedProducts.ThoiGianKT.Value;
                    return ngayKM;
                }
            }
            return DateTime.Now;
        }
        //public double LayThanhTien(string ma)
        //{
        //    QuanLyBanHangDataContext db1 = new QuanLyBanHangDataContext();
        //    // Lấy mã sản phẩm từ ComboBox
        //    string txt;
        //    double txt2;

        //    // Tìm sản phẩm trong danh sách sản phẩm
        //    SanPham selectedProduct = db1.SanPhams.FirstOrDefault(p => p.MaSanPham == ma);
        //    //SanPham selectedProduct = db1.SanPhams.First(p => p.MaSanPham == ma);

        //    // Nếu tìm thấy sản phẩm, hiển thị tên sản phẩm trên Textbox txtTenSP
        //    if (selectedProduct != null)
        //    {
        //        txt = selectedProduct.MaSanPham;

        //        //ChiTietHoaDon selectedProducts = db1.ChiTietHoaDons.FirstOrDefault(p => p.MaSanPham == txt);
        //        ChiTietHoaDon selectedProducts = db1.ChiTietHoaDons.FirstOrDefault(p => p.MaSanPham == txt);

        //        // Nếu tìm thấy sản phẩm, hiển thị tên sản phẩm trên Textbox txtTenSP
        //        if (selectedProducts != null)
        //        {

        //            txt2 = (double)selectedProducts.ThanhTien;
        //            return txt2;
        //        }
        //    }
        //    return -1;

        //}
        public bool Xoa_CTHD(string hd)
        {
            using (var context = new QuanLyBanHangDataContext())
            {
                //FirstOrDefault: lấy phần tử đầu
                var del = context.ChiTietHoaDons.FirstOrDefault(p => p.MaSanPham == hd);
                if (del != null)
                {
                    context.ChiTietHoaDons.DeleteOnSubmit(del);
                    context.SubmitChanges();
                }

            }
            return true;

        }

        public bool Sua_CTHD(String id, int slBan)
        {
            using (var cont_sua = new QuanLyBanHangDataContext())
            {
                //SingleOrDefault: lấy ra dữ liệu cần sửa
                var update = cont_sua.ChiTietHoaDons.SingleOrDefault(p => p.MaSanPham == id);
                if (update != null)
                {
                    update.SLBan = slBan;
                    UpdateTien();
                    cont_sua.SubmitChanges();
                }
            }
            return true;
        }
    }
}
