using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class KhachHang_DTO
    {
        private string maKH;
        private string tenKH;
        private string diaChi;
        private string dienThoai;
        private DateTime ngaySinh;

        public string MaKH
        {
            get { return maKH; }
            set { maKH = value; }
        }

        public string TenKH
        {
            get { return tenKH; }
            set { tenKH = value; }
        }

        public string DiaChi
        {
            get { return diaChi; }
            set { diaChi = value; }
        }

        public string DienThoai
        {
            get { return dienThoai; }
            set { dienThoai = value; }
        }
        public DateTime NgaySinh
        {
            get { return ngaySinh; }
            set { ngaySinh = value; }


        }

        public KhachHang_DTO() { }
        public KhachHang_DTO(string maKH, string tenKH, string diaChi, string dienThoai, DateTime ngaySinh) 
        { 
            this.MaKH = maKH;
            this.tenKH = tenKH;
            this.DiaChi = diaChi;
            this.DienThoai = dienThoai;
            this.NgaySinh = ngaySinh;
           
        }
    }
}
