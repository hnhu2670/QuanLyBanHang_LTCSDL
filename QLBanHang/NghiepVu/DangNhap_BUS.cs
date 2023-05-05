using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DuLieu_DAO_;
using System.Data;

namespace NghiepVu
{

    public class DangNhap_BUS
    {
        LOAD_DAO dao = new LOAD_DAO();
        DangNhap_DAO dn = new DangNhap_DAO();

       public DataTable BUS_Login(string username, string password)
        {
            return dn.DangNhap(username, password);
        }
    }
}
