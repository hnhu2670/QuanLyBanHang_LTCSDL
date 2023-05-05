using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class SanPham_DTO
    {
        private string maSanPham;
        private string tenSanPham;
        private int soLuong;
        private decimal giaNhap;
        private decimal giaBan;
        private string maNCC;
        private string maKM;

        public string MaSanPham { get => maSanPham; set => maSanPham = value; }
        public string TenSanPham { get => tenSanPham; set => tenSanPham = value; }
        public int SoLuong { get => soLuong; set => soLuong = value; }
        public decimal GiaNhap { get => giaNhap; set => giaNhap = value; }
        public decimal GiaBan { get => giaBan; set => giaBan = value; }
        public string MaNCC { get => maNCC; set => maNCC = value; }
        public string MaKM { get => maKM; set => maKM = value; }

        public SanPham_DTO() { }
        public SanPham_DTO(string maSanPham, string tenSanPham, int soLuong, decimal giaNhap, decimal giaBan, string maNCC, string maKM)
        {
            this.MaSanPham = maSanPham;
            this.TenSanPham = tenSanPham;
            this.SoLuong = soLuong;
            this.GiaNhap = giaNhap;
            this.GiaBan = giaBan;
            this.maNCC = maNCC;
            this.maKM = maKM;
            this.MaKM = maKM;
        }


    }
}
