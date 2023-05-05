using DTO;
using DuLieu_DAO_;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DuLieu_DAO_;
namespace NghiepVu
{
    public class NhaCungCap_BUS
    {
        NhaCungCap_DAO ncc = new NhaCungCap_DAO();
        public DataTable BUS_LoadNCC()
        {
            return ncc.LoadNCC();
        }
        public bool BUS_ThemNCC(NhaCungCap_DTO n)
        {
            return ncc.Them_NCC(n);
        }

        public bool BUS_SuaNCC(NhaCungCap_DTO n)
        {
            return ncc.Sua_NCC(n);
        }

        public bool BUS_XoaNCC(NhaCungCap_DTO n)
        {
            return ncc.Xoa_NCC(n);
        }

        public DataTable BUS_TimMaNCC(string id)
        {
            return ncc.TimMaNCC(id);
        }
    }
   

}
