using System;
using System.Collections.Generic;

namespace QLKhachSan.Models
{
    public partial class Phong
    {
        public Phong()
        {
            Hoadon = new HashSet<Hoadon>();
            Trangbi = new HashSet<Trangbi>();
        }

        public string PMa { get; set; }
        public string PTen { get; set; }
        public int? PSlgiuong { get; set; }
        public string PMota { get; set; }
        public string PTrangthai { get; set; }
        public string LpMa { get; set; }

        public virtual Loaiphong LpMaNavigation { get; set; }
        public virtual ICollection<Hoadon> Hoadon { get; set; }
        public virtual ICollection<Trangbi> Trangbi { get; set; }
    }
}
