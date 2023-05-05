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
    public class KhuyenMai_DAO
    {
        Connection c = new Connection();

        public DataTable LoadKhuyenMai()
        {
            SqlDataAdapter da;
            DataTable dt = new DataTable();
            string query = "Select MaGiamGia, GiamGia, ThoiGianBD, ThoiGianKT From KhuyenMai";
            da = new SqlDataAdapter(query, c.Connect());
            da.Fill(dt);
            return dt;
        }

        public DataTable TimMaKM(string id)
        {
            SqlDataAdapter da;
            DataTable dt = new DataTable();
            string query = "Select * From KhuyenMai Where  MaGiamGia like N'%" + id + "%' ";
            da = new SqlDataAdapter(query, c.Connect());
            da.Fill(dt);
            return dt;
        }

        public bool Them_KM(KhuyenMai_DTO k)
        {
            using (var cont = new QuanLyBanHangDataContext())
            {
                var ins = new KhuyenMai
                {
                    //thiết lập giá trị cho các cột
                    MaGiamGia = k.IdGiamGia,
                    GiamGia=k.GiaGtri,
                    ThoiGianBD=k.NgayBD,
                    ThoiGianKT=k.NgayKT,
                };
                cont.KhuyenMais.InsertOnSubmit(ins);
                cont.SubmitChanges();
            }
            return true;
        }
        public bool Sua_KM(KhuyenMai_DTO k)
        {
            using (var cont_sua = new QuanLyBanHangDataContext())
            {
                //SingleOrDefault: lấy ra dữ liệu cần sửa
                var update = cont_sua.KhuyenMais.SingleOrDefault(p => p.MaGiamGia == k.IdGiamGia);
                if (update != null)
                {
                    update.GiamGia = k.GiaGtri;
                    update.ThoiGianBD = k.NgayBD;
                    update.ThoiGianKT = k.NgayKT;
                    cont_sua.SubmitChanges();
                }
            }
            return true;
        }
        public bool Xoa_KM(KhuyenMai_DTO k)
        {
            using (var context = new QuanLyBanHangDataContext())
            {
                //FirstOrDefault: lấy phần tử đầu
                var del = context.KhuyenMais.FirstOrDefault(p => p.MaGiamGia ==k.IdGiamGia) ;
                if (del != null)
                {
                    context.KhuyenMais.DeleteOnSubmit(del);
                    context.SubmitChanges();
                }

            }
            return true;
        }
    }
}
