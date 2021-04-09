using System;
using System.Collections.Generic;

namespace QLKhachSan.Models
{
    public partial class Hoadon
    {
        public Hoadon()
        {
            Chitiet = new HashSet<Chitiet>();
        }

        public string HdMa { get; set; }
        public DateTime? HdTgnhan { get; set; }
        public DateTime? HdTgtra { get; set; }
        public int? HdTongtien { get; set; }
        public string KhMa { get; set; }
        public string NvMa { get; set; }
        public string PMa { get; set; }

        public virtual Khachhang KhMaNavigation { get; set; }
        public virtual Nhanvien NvMaNavigation { get; set; }
        public virtual Phong PMaNavigation { get; set; }
        public virtual ICollection<Chitiet> Chitiet { get; set; }
    }
}
