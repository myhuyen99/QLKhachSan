using System;
using System.Collections.Generic;

namespace QLKhachSan.Models
{
    public partial class Datphong
    {
        public string DpMa { get; set; }
        public DateTime? DpTgnhan { get; set; }
        public DateTime? DpTgtra { get; set; }
        public string KhMa { get; set; }
        public string NvMa { get; set; }

        public virtual Khachhang KhMaNavigation { get; set; }
        public virtual Nhanvien NvMaNavigation { get; set; }
    }
}
