using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class KhuyenMai_DTO
    {
        private string idGiamGia;
        private float giaGtri;
        private DateTime ngayBD;
        private DateTime ngayKT;

        public string IdGiamGia { get => idGiamGia; set => idGiamGia = value; }
        public float GiaGtri { get => giaGtri; set => giaGtri = value; }
        public DateTime NgayBD { get => ngayBD; set => ngayBD = value; }
        public DateTime NgayKT { get => ngayKT; set => ngayKT = value; }

        public KhuyenMai_DTO() { }
        public KhuyenMai_DTO(string idGiamGia, float giaGtri, DateTime ngayBD, DateTime ngayKT)
        {
            this.idGiamGia = idGiamGia;
            this.giaGtri = giaGtri;
            this.ngayBD = ngayBD;
            this.ngayKT = ngayKT;
        }
    }
}
