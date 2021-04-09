using System;
using System.Collections.Generic;

namespace QLKhachSan.Models
{
    public partial class Nhanvien
    {
        public Nhanvien()
        {
            Datphong = new HashSet<Datphong>();
            Hoadon = new HashSet<Hoadon>();
        }

        public string NvMa { get; set; }
        public string NvTendn { get; set; }
        public string NvMatkhau { get; set; }

        public virtual ICollection<Datphong> Datphong { get; set; }
        public virtual ICollection<Hoadon> Hoadon { get; set; }
    }
}
