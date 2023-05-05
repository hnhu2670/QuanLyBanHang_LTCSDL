using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class NhanVien_DTO
    {
        private string maNV;
        private string tenNV;
        private string diaChi;
        private string dienThoai;
        private DateTime ngaySinh;

        public string MaNV
        {
            get { return maNV; }
            set { maNV = value; }
        }

        public string TenNV
        {
            get { return tenNV; }
            set {tenNV = value;}
        }

        public string DiaChi
        {
            get { return diaChi; }
            set { diaChi = value; }
        }

        public string DienThoai
        {
            get { return dienThoai; }
            set { dienThoai = value;}  
        }
        public DateTime NgaySinh
        {
            get { return ngaySinh; }
            set { ngaySinh = value; }

        }

        public NhanVien_DTO() { }

        public NhanVien_DTO(string maNV, string tenNV, string diaChi, string dienThoai, DateTime ngaySinh)
        {
            this.MaNV = maNV;
            this.TenNV = tenNV;
            this.DiaChi = diaChi;
            this.DienThoai = dienThoai;
            this.NgaySinh = ngaySinh;
        }
    }
}
