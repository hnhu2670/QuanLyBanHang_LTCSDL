using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DuLieu_DAO_
{
    
    public class HDBanHang_DAO
    {
        QuanLyBanHangDataContext db = new QuanLyBanHangDataContext();
        Connection c = new Connection();    
        public DataTable Load_HoaDon()
        {
            SqlDataAdapter da;
            DataTable dt = new DataTable();
            string query = "Select hd.MaHDBan as 'Mã hóa đơn', nv.TenNhanVien as 'Tên nhân viên'," +
                "hd.NgayXuatHD as 'Ngày xuất', k.TenKhachHang as 'Tên khách hàng'" +
                "From HoaDonBanHang hd, KhachHang k, NhanVien nv " +
                "Where hd.MaKhachHang = k.MaKhachHang and hd.MaNhanVien = nv.MaNhanVien ";
            da = new SqlDataAdapter(query, c.Connect());
            da.Fill(dt);
            return dt;
        }

        //public bool Them_HD(HoaDon_DTO hd)
        //{
        //    Connection cnn = new Connection();
        //    cnn.Connect().Open();
        //    string query = "Insert into HoaDonBanHang (MaHDBan, MaKhachHang, MaNhanVien, NgayXuatHD) values (hd.MaHD, hd.MaKH, hd.MaNV, hd.NgayXuatHD)";
        //    SqlCommand command = new SqlCommand(query, cnn.Connect());


        //    command.ExecuteNonQuery();

        //    return true;
        //}

        public bool Them_HD(HoaDon_DTO hd)
        {
            using (var cont = new QuanLyBanHangDataContext())
            {
                var ins = new HoaDonBanHang()
                {
                    //thiết lập giá trị cho các cột
                    MaHDBan = hd.MaHD,
                    MaNhanVien = hd.MaNV,
                    MaKhachHang = hd.MaKH,
                    NgayXuatHD = hd.NgayXuatHD
                };
                
                cont.HoaDonBanHangs.InsertOnSubmit(ins);
                //cont.KhachHangs.InsertOnSubmit(them);

                cont.SubmitChanges();
            }
            return true;
        }

        public bool Xoa_HD(HoaDon_DTO hd)
        {
            using (var context = new QuanLyBanHangDataContext())
            {
                //FirstOrDefault: lấy phần tử đầu
                var del = context.HoaDonBanHangs.FirstOrDefault(p => p.MaHDBan == hd.MaHD);
                if (del != null)
                {
                    context.HoaDonBanHangs.DeleteOnSubmit(del);
                    context.SubmitChanges();
                }

            }
            return true;

        }
        //------------------------------------------------------------------------
        //public DataTable Load_CTHD(string maHDBan)
        //{
        //    SqlDataAdapter da;
        //    DataTable dt = new DataTable();
        //    //string query = "Select * From ChiTietHoaDon Where MaHDBan like '"+maHDBan+ "'";
        //    string query =
        //        "select ct.MaCTHoaDon, sp.MaSanPham, sp.TenSanPham, sp.GiaBan, km.GiamGia, ct.SoLuongBan, ct.ThanhTien"
        //    + " from ChiTietHoaDon ct, SanPham sp, KhuyenMai km " +
        //     " where ct.MaSanPham = sp.MaSanPham and km.MaGiamGia = sp.MaGiamGia and  ct.MaHDBan like '" + maHDBan + "'";
        //    da = new SqlDataAdapter(query, c.Connect());
        //    da.Fill(dt);
        //    return dt;
        //}
        //public DataTable TinhTien()
        //{
        //    SqlDataAdapter da;
        //    DataTable dt = new DataTable();
        //    string query = "UPDATE ChiTietHoaDon SET ThanhTien = (sp.GiaBan * ct.SoLuongBan)" +
        //        " FROM SanPham sp, ChiTietHoaDon ct " +
        //        "where sp.MaSanPham = ct.MaSanPham ";
        //    da = new SqlDataAdapter(query, c.Connect());
        //    da.Fill(dt);
        //    return dt;
        //}
        //public bool Xoa_CTHD(string cthd)
        //{
        //    using (var context = new QuanLyBanHangDataContext())
        //    {
        //        //FirstOrDefault: lấy phần tử đầu
        //        var del = context.ChiTietHoaDons.FirstOrDefault(p => p.MaCTHoaDon == cthd);
        //        if (del != null)
        //        {
        //            context.ChiTietHoaDons.DeleteOnSubmit(del);
        //            context.SubmitChanges();
        //        }

        //    }
        //    return true;

        //}
        //public bool Them_CTHD(CTHoaDon_DTO hd)
        //{
        //    using (var cont = new QuanLyBanHangDataContext())
        //    {
        //        var ins = new ChiTietHoaDon()
        //        {
        //            //thiết lập giá trị cho các cột
        //            MaCTHoaDon = hd.MaCTHD,
        //            MaHDBan = hd.MaHD,
        //            MaSanPham = hd.MaSP,
        //            SoLuongBan=hd.SoLuong,
        //            ThanhTien=hd.ThanhTien
        //        };
        //        cont.ChiTietHoaDons.InsertOnSubmit(ins);
        //        cont.SubmitChanges();
        //    }
        //    return true;

        //}

        //public bool Sua_CTHD(CTHoaDon_DTO hd)
        //{
        //    using (var cont_sua = new QuanLyBanHangDataContext())
        //    {
        //        //SingleOrDefault: lấy ra dữ liệu cần sửa
        //        var update = cont_sua.ChiTietHoaDons.SingleOrDefault(p => p.MaCTHoaDon == hd.MaCTHD);
        //        if (update != null)
        //        {
        //            update.MaCTHoaDon=hd.MaCTHD;
        //            update.MaSanPham = hd.MaSP;
        //            update.SoLuongBan = hd.SoLuong;
        //            cont_sua.SubmitChanges();
        //        }
        //    }
        //    return true;
        //}

       
       

    }
}
