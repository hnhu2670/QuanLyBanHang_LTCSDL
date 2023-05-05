using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class NhaCungCap_DTO
    {
        private string idNCC;
        private string nameNCC;
        private string diaChiNCC;
        private string dienThoaiNCC;

        public string IdNCC { get => idNCC; set => idNCC = value; }
        public string NameNCC { get => nameNCC; set => nameNCC = value; }
        public string DiaChiNCC { get => diaChiNCC; set => diaChiNCC = value; }
        public string DienThoaiNCC { get => dienThoaiNCC; set => dienThoaiNCC = value; }
        public NhaCungCap_DTO() { }
        public NhaCungCap_DTO(string idNCC, string nameNCC, string diaChiNCC, string dienThoaiNCC)
        {
            this.idNCC = idNCC;
            this.nameNCC = nameNCC;
            this.diaChiNCC = diaChiNCC;
            this.dienThoaiNCC = dienThoaiNCC;
        }

       
    }
}
