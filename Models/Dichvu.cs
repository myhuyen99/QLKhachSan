using System;
using System.Collections.Generic;

namespace QLKhachSan.Models
{
    public partial class Dichvu
    {
        public Dichvu()
        {
            Chitiet = new HashSet<Chitiet>();
        }

        public string DvMa { get; set; }
        public string DvTen { get; set; }
        public int? DvGia { get; set; }
        public int? DvSlnhap { get; set; }
        public int? DvTonkho { get; set; }

        public virtual ICollection<Chitiet> Chitiet { get; set; }
    }
}
