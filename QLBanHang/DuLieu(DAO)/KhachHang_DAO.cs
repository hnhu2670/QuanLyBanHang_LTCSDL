using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuLieu_DAO_
{
    public class ChucNang_KH
    {
        Connection c = new Connection();
        NhanVien_DTO nv = new NhanVien_DTO();

        public bool Them_KH(KhachHang_DTO n)
        {
            using (var cont = new QuanLyBanHangDataContext())

            {
                var ins = new KhachHang()
                {
                    //thiết lập giá trị cho các cột

                    MaKhachHang = n.MaKH,
                    TenKhachHang = n.TenKH,
                    DiaChi = n.DiaChi,
                    DienThoai = n.DienThoai,
                    NgaySinh = n.NgaySinh

                };
                cont.KhachHangs.InsertOnSubmit(ins);
                cont.SubmitChanges();
            }
            return true;
        }

        public bool Sua_KH(KhachHang_DTO n)
        {
            using (var cont_sua = new QuanLyBanHangDataContext())
            {
                //SingleOrDefault: lấy ra dữ liệu cần sửa
                var update = cont_sua.KhachHangs.SingleOrDefault(p => p.MaKhachHang == n.MaKH);
                if (update != null)
                {
                    update.TenKhachHang = n.TenKH;
                    update.DiaChi = n.DiaChi;
                    update.DienThoai = n.DienThoai;
                    update.NgaySinh = n.NgaySinh;

                    cont_sua.SubmitChanges();
                }
            }
            return true;
        }

        public bool Xoa_KH(KhachHang_DTO s)
        {
            using (var context = new QuanLyBanHangDataContext())
            {
                //FirstOrDefault: lấy phần tử đầu
                var del = context.KhachHangs.FirstOrDefault(p => p.MaKhachHang == s.MaKH);
                if (del != null)
                {
                    context.KhachHangs.DeleteOnSubmit(del);
                    context.SubmitChanges();
                }

            }
            return true;


        }
    
}
}
