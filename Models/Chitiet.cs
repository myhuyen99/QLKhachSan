using System;
using System.Collections.Generic;

namespace QLKhachSan.Models
{
    public partial class Chitiet
    {
        public string CtMa { get; set; }
        public int? CtGia { get; set; }
        public int? CtThanhtien { get; set; }
        public string HdMa { get; set; }
        public string DvMa { get; set; }

        public virtual Dichvu DvMaNavigation { get; set; }
        public virtual Hoadon HdMaNavigation { get; set; }
    }
}
