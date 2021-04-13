using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTapNET
{
    public class HopDong
    {
        public string IDHopDong { get; set; }
        public string TenHopDong { get; set; }
        public DateTime NgayHetHan { get; set; }

        public HopDong(string id, string tenhopdong, DateTime ngayhethan)
        {
            this.IDHopDong = id;
            this.TenHopDong = tenhopdong;
            this.NgayHetHan = ngayhethan;
        }
    }
}
