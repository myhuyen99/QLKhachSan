using System;
using System.Collections.Generic;

namespace QLKhachSan.Models
{
    public partial class Loaiphong
    {
        public Loaiphong()
        {
            ChitietGia = new HashSet<ChitietGia>();
            Phong = new HashSet<Phong>();
        }

        public string LpMa { get; set; }
        public string LpTenloai { get; set; }

        public virtual ICollection<ChitietGia> ChitietGia { get; set; }
        public virtual ICollection<Phong> Phong { get; set; }
    }
}
