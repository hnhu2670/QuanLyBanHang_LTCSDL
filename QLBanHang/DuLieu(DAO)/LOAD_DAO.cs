    using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DuLieu_DAO_
{
    public class LOAD_DAO
    {


        Connection c = new Connection();       
        public DataTable LoadSanPham()
        {
            SqlDataAdapter da;
            DataTable dt = new DataTable();

            //string query = "Select MaSanPham as 'Mã sản phẩm', TenSanPham as 'Tên sản phẩm', SoLuong as 'Số lượng'," +
            //    " GiaNhap as 'Giá nhập', GiaBan as 'Giá bán', MaNCC as 'Mã nhà cung cấp'" +
            //    "From SanPham";

            string query = "Select * from SanPham";
            da = new SqlDataAdapter(query, c.Connect());
            da.Fill(dt);
            return dt;
        }
        public DataTable LoadNhanVien()
        {
            SqlDataAdapter da;
            DataTable dt = new DataTable();
            string query = "Select * From NhanVien";
            da = new SqlDataAdapter(query, c.Connect());
            da.Fill(dt);
            return dt;
        }
        public DataTable LoadKhachHang()
        {
            SqlDataAdapter da;
            DataTable dt = new DataTable();
            string query = "Select * From KhachHang";
            da = new SqlDataAdapter(query, c.Connect());
            da.Fill(dt);
            return dt;
        }
        public DataTable TimMaSanPham(string id)
        {
            SqlDataAdapter da;
            DataTable dt = new DataTable();
            string query = "Select * From SanPham where MaSanPham like N'%" + id + "%'";
            da = new SqlDataAdapter(query, c.Connect());
            da.Fill(dt);
            return dt;
        }

        public DataTable TimTenSanPham(string name)
        {
            SqlDataAdapter da;
            DataTable dt = new DataTable();
            string query = "Select * From SanPham Where TenSanPham like N'%"+name+"%' ";
            da = new SqlDataAdapter(query, c.Connect());
            da.Fill(dt);
            return dt;
        }

        public DataTable TimMaNhanVien(string id)
        {
            SqlDataAdapter da;
            DataTable dt = new DataTable();
            string query = "Select * From NhanVien where MaNhanVien like N'%" + id + "%'";
            da = new SqlDataAdapter(query, c.Connect());
            da.Fill(dt);
            return dt;
        }

        public DataTable TimTenNhanVien(string name)
        {
            SqlDataAdapter da;
            DataTable dt = new DataTable();
            string query = "Select * From NhanVien Where TenNhanVien like N'%" + name + "%' ";
            da = new SqlDataAdapter(query, c.Connect());
            da.Fill(dt);
            return dt;
        }

        public DataTable TimMaKhachHang(string id)
        {
            SqlDataAdapter da;
            DataTable dt = new DataTable();
            string query = "Select * From KhachHang where MaKhachHang like N'%" + id + "%'";
            da = new SqlDataAdapter(query, c.Connect());
            da.Fill(dt);
            return dt;
        }

        public DataTable TimTenKhachHang(string name)
        {
            SqlDataAdapter da;
            DataTable dt = new DataTable();
            string query = "Select * From KhachHang Where TenKhachHang like N'%" + name + "%' ";
            da = new SqlDataAdapter(query, c.Connect());
            da.Fill(dt);
            return dt;
        }

        public DataTable TimMaHDBan(string id)
        {
            SqlDataAdapter da;
            DataTable dt = new DataTable();
            string query = "Select hd.MaHDBan as 'Mã hóa đơn', nv.TenNhanVien as 'Tên nhân viên'," +
               "hd.NgayXuatHD as 'Ngày xuất', k.TenKhachHang as 'Tên khách hàng'" +
               "From HoaDonBanHang hd, KhachHang k, NhanVien nv " +
               "Where hd.MaKhachHang = k.MaKhachHang and hd.MaNhanVien = nv.MaNhanVien and hd.MaHDBan like N'%"+id+"%' ";
            //string query = "Select * From HoaDonBanHang Where MaHDBan like N'%" + id + "%' ";
            da = new SqlDataAdapter(query, c.Connect());
            da.Fill(dt);
            return dt;
        }



    }
}
