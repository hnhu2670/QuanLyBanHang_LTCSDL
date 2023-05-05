using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuLieu_DAO_
{
   
    public class DangNhap_DAO
    {
        QuanLyBanHangDataContext db = new QuanLyBanHangDataContext();
        Connection c= new Connection();
        public DataTable DangNhap(string username, string mk)
        {
            SqlDataAdapter da;
            string query = "Select * From TaiKhoan Where TaiKhoan like '"+username+"' and MatKhau like '"+mk+"' ";
            da = new SqlDataAdapter(query, c.Connect());
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
            

        }
    }
}
