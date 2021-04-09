using System;
using System.Collections.Generic;

namespace QLKhachSan.Models
{
    public partial class Giaphong
    {
        public Giaphong()
        {
            ChitietGia = new HashSet<ChitietGia>();
        }

        public string GpMa { get; set; }
        public int? GpTheongay { get; set; }
        public int? GpTheotuan { get; set; }
        public int? GpTheothang { get; set; }
        public int? GpQuadem { get; set; }

        public virtual ICollection<ChitietGia> ChitietGia { get; set; }
    }
}
