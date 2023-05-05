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
    public class KhuyenMai_BUS
    {
       KhuyenMai_DAO km = new KhuyenMai_DAO();
        //KhachHang_DTO k = new KhachHang_DTO();
        public DataTable BUS_LoadKhuyenMai()
        {
            return km.LoadKhuyenMai();
        }

        public DataTable BUS_TimMaKhuyenMai(string id)
        {
            return km.TimMaKM(id);
        }
        public bool ThemKM(KhuyenMai_DTO k)
        {
            return km.Them_KM(k);
        }

        public bool XoaKM(KhuyenMai_DTO k)
        {
            return km.Xoa_KM(k);
        }

        public bool SuaKM(KhuyenMai_DTO k)
        {
            return km.Sua_KM(k);
        }

    }
}
