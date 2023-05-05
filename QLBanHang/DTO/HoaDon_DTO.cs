using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class HoaDon_DTO
    {
        private string maHD;
        private string maNV;
        private string maKH;
        private DateTime ngayXuatHD;

        public string MaHD { get; set; }
        public string MaNV { get; set; }
        public string MaKH { get; set; }
        public DateTime NgayXuatHD { get; set; }
        public int SoLuong { get; set; }

        public HoaDon_DTO() { }

        public HoaDon_DTO(string maHD, string maNV, string tenNV, DateTime ngayXuatHD)
        {
            this.maHD = maHD;
            this.MaNV = maNV;
            this.MaKH = maKH;
            this.NgayXuatHD = ngayXuatHD;
        }

        
    }
}
