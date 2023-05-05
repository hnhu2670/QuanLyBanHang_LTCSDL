using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class User_DTO
    {
        private string tk;
        private string mk;
        public string TaiKhoan
        {
            get { return tk; } 
            set { tk = value; }
        }
        public string MatKhau
        {
            get { return mk; }
            set { mk = value; }
        }
        public User_DTO()
        {
            
        }
        public User_DTO(string taiKhoan, string matKhau)
        {
            this.tk = taiKhoan;
            this.mk = matKhau;
        }
    }
}
