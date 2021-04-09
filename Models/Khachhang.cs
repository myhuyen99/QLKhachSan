using System;
using System.Collections.Generic;

namespace QLKhachSan.Models
{
    public partial class Khachhang
    {
        public Khachhang()
        {
            Datphong = new HashSet<Datphong>();
            Hoadon = new HashSet<Hoadon>();
        }

        public string KhMa { get; set; }
        public string KhHoten { get; set; }
        public string KhGioitinh { get; set; }
        public string KhSdt { get; set; }
        public string KhDiachi { get; set; }
        public string KhCmnd { get; set; }
        public string KhEmail { get; set; }

        public virtual ICollection<Datphong> Datphong { get; set; }
        public virtual ICollection<Hoadon> Hoadon { get; set; }
    }
}
