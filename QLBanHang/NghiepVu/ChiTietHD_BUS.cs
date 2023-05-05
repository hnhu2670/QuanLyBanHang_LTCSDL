using DuLieu_DAO_;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DuLieu_DAO_;
using DTO;

namespace NghiepVu
{
    public class ChiTietHD_BUS
    {
        ChiTietHD_DAO ct = new ChiTietHD_DAO();
        public DataTable BUS_LoadCTHD(string maHD)
        {
            return ct.Load_CTHD(maHD);
        }
        public DataTable BUS_SP_LoadCTHD(string maHD, string tenSp )
        {
            return ct.Load_SP_CTHD(maHD,tenSp);
        }
        public bool BUS_ThemCTHD(ChiTietHD_DTO them)
        {
            return ct.Them_CTHD(them);
        }
        public bool BUS_SuaCTHD(string hd, int slBan)
        {
            return ct.Sua_CTHD(hd, slBan);
        }
        public bool BUS_XoaCTHD(string sp)
        {
            return ct.Xoa_CTHD(sp);
        }
        public void UpdateTien()
        {
            ct.UpdateTien();
        }
        public void BUS_ThanhTien()
        {
            ct.ThanhTien();
        }
        public String LayTen_ByCBB(String masp)
        {
            return ct.LayTen(masp);
        }
        public string LayGiaSP_ByCBB(string ma)
        {
            return ct.LayGia(ma);
        }
        public string LaySoLuong_ByCBB(string ma)
        {
            return ct.LaySoluong(ma);
        }
        public string LayGiamGia_ByCBB(string ma)
        {
            return ct.LayGiamGia(ma);
        }
        public DateTime LayNgayKM_ByCBB(string ma)
        {
            return ct.layNgayKM(ma);
        }



    }


}
