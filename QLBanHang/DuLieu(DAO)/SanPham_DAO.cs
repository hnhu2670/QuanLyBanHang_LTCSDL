using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
namespace DuLieu_DAO_
{

    public class SanPham_DAO
    {
        QuanLyBanHangDataContext db = new QuanLyBanHangDataContext();
        Connection c = new Connection();

        //LOAD_DAO load = new LOAD_DAO(); 
        SanPham prod = new SanPham();

        public bool Them_SP(SanPham_DTO s)
        {
            using (var cont = new QuanLyBanHangDataContext())
            {
                var ins = new SanPham
                {
                    //thiết lập giá trị cho các cột
                    MaSanPham = s.MaSanPham,
                    TenSanPham = s.TenSanPham,
                    SoLuong = s.SoLuong,
                    GiaNhap = s.GiaNhap,
                    GiaBan = s.GiaBan,
                    MaNCC = s.MaNCC,
                    MaGiamGia=s.MaKM
                };
                cont.SanPhams.InsertOnSubmit(ins);
                cont.SubmitChanges();
            }
            return true;
        }



        public bool Xoa_SP(SanPham_DTO s)
        {
            using (var context = new QuanLyBanHangDataContext())
            {
                //FirstOrDefault: lấy phần tử đầu
                var del = context.SanPhams.FirstOrDefault(p => p.MaSanPham == s.MaSanPham);
                if (del != null)
                {
                    context.SanPhams.DeleteOnSubmit(del);
                    context.SubmitChanges();
                }

            }
            return true;
        }

        public bool Sua_SP(SanPham_DTO s)
        {
            using (var cont_sua = new QuanLyBanHangDataContext())
            {
                //SingleOrDefault: lấy ra dữ liệu cần sửa
                var update = cont_sua.SanPhams.SingleOrDefault(p => p.MaSanPham == s.MaSanPham);
                if (update != null)
                {
                    update.TenSanPham = s.TenSanPham;
                    update.SoLuong = s.SoLuong;
                    update.GiaBan = s.GiaBan;
                    update.GiaNhap = s.GiaNhap;
                    update.MaNCC = s.MaNCC;
                    update.MaGiamGia = s.MaKM;
                    cont_sua.SubmitChanges();
                }
            }
            return true;
        }
        //LayThongTinSanPham

        public bool LayThongTinSp(string id)
        {
            SanPham_DTO s;
            using (var con = new QuanLyBanHangDataContext())
            {
                var lay = con.SanPhams.FirstOrDefault(p => p.MaSanPham == id);

            }
            return true;

        }

        //public DataTable GetAllProducts()
        //{
        //    DataTable dataTable = new DataTable();

           
        //        string query = "SELECT MaSanPham, TenSanPham FROM SanPham";

        //        SqlCommand command = new SqlCommand(query, c.Connect());

        //        SqlDataAdapter dataAdapter = new SqlDataAdapter(command);

        //        dataAdapter.Fill(dataTable);
            

        //    return dataTable;
        //}
    }
}
