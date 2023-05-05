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
    public class NhaCungCap_DAO
    {
        Connection c = new Connection();
        NhaCungCap_DTO ncc = new NhaCungCap_DTO();
        public DataTable LoadNCC()
        {
            SqlDataAdapter da;
            DataTable dt = new DataTable();
            string query = "Select * From NhaCungCap";
            da = new SqlDataAdapter(query, c.Connect());
            da.Fill(dt);
            return dt;
        }

        public bool Them_NCC(NhaCungCap_DTO n)
        {
            using (var cont = new QuanLyBanHangDataContext())
            {
                var ins = new NhaCungCap()
                {
                    //thiết lập giá trị cho các cột

                    MaNCC = n.IdNCC,
                    TenNCC = n.NameNCC,
                    DiaChi = n.DiaChiNCC,
                    DienThoai = n.DienThoaiNCC

                };
                cont.NhaCungCaps.InsertOnSubmit(ins);
                cont.SubmitChanges();
            }
            return true;
        }

        public bool Sua_NCC(NhaCungCap_DTO n)
        {
            using (var cont_sua = new QuanLyBanHangDataContext())
            {
                //SingleOrDefault: lấy ra dữ liệu cần sửa
                var update = cont_sua.NhaCungCaps.SingleOrDefault(p => p.MaNCC == n.IdNCC);
                if (update != null)
                {
                    update.TenNCC = n.NameNCC;
                    update.DiaChi = n.DiaChiNCC;
                    update.DienThoai = n.DienThoaiNCC;

                    cont_sua.SubmitChanges();
                }
            }
            return true;
        }

        public bool Xoa_NCC(NhaCungCap_DTO n)
        {
            using (var context = new QuanLyBanHangDataContext())
            {
                //FirstOrDefault: lấy phần tử đầu
                var del = context.NhaCungCaps.FirstOrDefault(p => p.MaNCC == n.IdNCC);
                if (del != null)
                {
                    context.NhaCungCaps.DeleteOnSubmit(del);
                    context.SubmitChanges();
                }
            }
            return true;
        }

        public DataTable TimMaNCC(string id)
        {
            SqlDataAdapter da;
            DataTable dt = new DataTable();
            //string query = "Select MaNCC as 'Mã nhà cung cấp', TenNCC as 'Tên nhà cung cấp'," +
            //    "DiaChi as 'Địa chỉ', DienThoai as 'Điện thoại' " +
            //    "From NhaCungCap Where MaNCC like N'%" + id + "%' ";

            string query = "Select * From NhaCungCap Where MaNCC like N'%" + id + "%'";
            da = new SqlDataAdapter(query, c.Connect());
            da.Fill(dt);
            return dt;
        }
    }
}
