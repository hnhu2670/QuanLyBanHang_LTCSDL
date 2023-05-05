using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuLieu_DAO_
{
    public class NhanVien_DAO
    {
        Connection c= new Connection();
        NhanVien_DTO nv = new NhanVien_DTO();

        public bool Them_NV(NhanVien_DTO n)
        {
            using (var cont = new QuanLyBanHangDataContext())
            {
                var ins = new NhanVien()
                {
                    //thiết lập giá trị cho các cột
                    
                    MaNhanVien = n.MaNV,
                    TenNhanVien = n.TenNV,
                    DiaChi = n.DiaChi,
                    DienThoai = n.DienThoai,
                    NgaySinh = n.NgaySinh
                 
                };
                cont.NhanViens.InsertOnSubmit(ins);
                cont.SubmitChanges();
            }
            return true;
        }

        public bool Sua_NV(NhanVien_DTO n)
        {
            using (var cont_sua = new QuanLyBanHangDataContext())
            {
                //SingleOrDefault: lấy ra dữ liệu cần sửa
                var update = cont_sua.NhanViens.SingleOrDefault(p => p.MaNhanVien == n.MaNV);
                if (update != null)
                {
                    update.TenNhanVien = n.TenNV;
                    update.DiaChi = n.DiaChi;
                    update.DienThoai = n.DienThoai;
                    update.NgaySinh = n.NgaySinh;

                    cont_sua.SubmitChanges();
                }
            }
            return true;
        }

        public bool Xoa_NV(NhanVien_DTO s)
        {
            using (var context = new QuanLyBanHangDataContext())
            {
                //FirstOrDefault: lấy phần tử đầu
                var del = context.NhanViens.FirstOrDefault(p => p.MaNhanVien == s.MaNV);
                if (del != null)
                {
                    context.NhanViens.DeleteOnSubmit(del);
                    context.SubmitChanges();
                }

            }
            return true;


        }
    }
}
