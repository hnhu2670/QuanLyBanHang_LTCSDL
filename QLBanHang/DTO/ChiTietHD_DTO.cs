using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ChiTietHD_DTO
    {
        private string idHD;
        private string idSP;
        private int slBan;
        private float tien;
        public string IdHD { get => idHD; set => idHD = value; }
        public string IdSP { get => idSP; set => idSP = value; }
        public int SlBan { get => slBan; set => slBan = value; }
        public float Tien { get => tien; set => tien = value; }

        public ChiTietHD_DTO() { }
        public ChiTietHD_DTO(string idHD, string idSP, int slBan, float tien)
        {
            this.idHD = idHD;
            this.idSP = idSP;
            this.slBan = slBan;
            this.tien = tien;
        }

       
    }
}
