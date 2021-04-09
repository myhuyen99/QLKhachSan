using System;
using System.Collections.Generic;

namespace QLKhachSan.Models
{
    public partial class ChitietGia
    {
        public string CtgMa { get; set; }
        public DateTime? CtgTgapdungTungay { get; set; }
        public DateTime? CtgTgapdungDenngay { get; set; }
        public string LpMa { get; set; }
        public string GpMa { get; set; }

        public virtual Giaphong GpMaNavigation { get; set; }
        public virtual Loaiphong LpMaNavigation { get; set; }
    }
}
