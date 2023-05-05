using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DuLieu_DAO_;

namespace NghiepVu
{
    public class Load_BUS
    {
        //QLBanHangDataContext db = new QLBanHangDataContext();
        QuanLyBanHangDataContext db = new QuanLyBanHangDataContext();
        LOAD_DAO dao = new LOAD_DAO();


        //gọi các hàm từ hàm load_DAO
        public DataTable BUS_LoadSanPham()
        {
            return dao.LoadSanPham();
        }
       
        public DataTable BUS_TimMaSanPham(string id)
        {
            return dao.TimMaSanPham(id);
        }
        public DataTable BUS_TimTenSanPham(string name)
        {
            return dao.TimTenSanPham(name);
        }
      
        /// ----------------------------------------------------------------------------------------
 
        public DataTable BUS_LoadNhanVien()
        {
            return dao.LoadNhanVien();
        }
        public DataTable BUS_TimMaNhanVien(string id)
        {
            return dao.TimMaNhanVien(id);
        }
        public DataTable BUS_TimTenNhanVien(string name)
        {
            return dao.TimTenNhanVien(name);
        }
        //--------------------------------------------------------------------------------------------
        public DataTable BUS_LoadKhachHang()
        {
            return dao.LoadKhachHang();
        }

        public DataTable BUS_TimMaKhachHang(string id)
        {
            return dao.TimMaKhachHang(id);
        }
        public DataTable BUS_TimTenKhachHang(string name)
        {
            return dao.TimTenKhachHang(name);
        }
        //--------------------------------------------------------------------------------------------
        public DataTable BUS_MaHD(string id)
        {
            return dao.TimMaHDBan(id);
        }


    }
}
