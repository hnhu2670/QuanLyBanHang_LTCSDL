using DTO;
using DuLieu_DAO_;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NghiepVu
{
    public class HDBanHang_BUS
    {
        HDBanHang_DAO dao = new HDBanHang_DAO();
        public DataTable BUS_LoadHoaDonBan()
        {
            return dao.Load_HoaDon();
        }

        //public DataTable BUS_LoadCombobox()
        //{
        //   // return dao.Load_Combobox();
        //}

        public bool BUS_ThemHD(HoaDon_DTO hd)
        {
            return dao.Them_HD(hd);
        }

        public bool BUS_XoaHD(HoaDon_DTO hd)
        {
            return dao.Xoa_HD(hd);
        }

        //----------------------------------------------------------------------
        //public DataTable BUS_LoadChiTietHD(string id)
        //{
        //    return dao.Load_CTHD(id);
        //}
        //public DataTable BUS_TinhTien()
        //{
        //    return dao.TinhTien();
        //}

        //public bool BUS_ThemCTHD(CTHoaDon_DTO hd)
        //{
        //    return dao.Them_CTHD(hd);
        //}
        //public bool BUS_XoaCTHD(string hd)
        //{
        //    return dao.Xoa_CTHD(hd);
        //}
        //public bool BUS_SuaCTHD(CTHoaDon_DTO hd)
        //{
        //    return dao.Sua_CTHD(hd);
        //}
        //public string LayTenSP(string ma)
        //{
        //    return dao.LayTen(ma);
        //}
       
       
        
    }
}
