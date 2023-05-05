using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DuLieu_DAO_;
namespace NghiepVu
{
    public class ChucNang_BUS
    {
        DuLieu_DAO_.SanPham_DAO sp = new DuLieu_DAO_.SanPham_DAO();
        NhanVien_DAO nv = new NhanVien_DAO();
        ChucNang_KH kh = new ChucNang_KH();

        public bool ThemSP(SanPham_DTO s)
        {
            return sp.Them_SP(s);
        }

        public bool XoaSP(SanPham_DTO s)
        {
            return sp.Xoa_SP(s);
        }

        public bool SuaSP(SanPham_DTO s)
        {
            return sp.Sua_SP(s);
        }

        //lấy thông tin sản phẩm
        //public List<SanPham_DTO> BUS_GetAllProducts()
        //{
        //    return sp.GetAllProducts();
        //}
        //---------------------------------------------------------------------
        public bool ThemNV (NhanVien_DTO n)
        {
            return nv.Them_NV(n);
        }
        public bool SuaNV(NhanVien_DTO n)
        {
            return nv.Sua_NV(n);
        }
        public bool XoaNV(NhanVien_DTO n)
        {
            return nv.Xoa_NV(n);
        }

        //-----------------------------------------------------------------------
        public bool ThemKH(KhachHang_DTO k)
        {
            return kh.Them_KH(k);
        }
        public bool SuaKH(KhachHang_DTO k)
        {
            return kh.Sua_KH(k);
        }
        public bool XoaKH(KhachHang_DTO k)
        {
            return kh.Xoa_KH(k);    
        }

        
    }
}
