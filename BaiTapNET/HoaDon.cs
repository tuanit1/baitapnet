using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTapNET
{
    public class HoaDon
    {
        public string MHD { get; set; }
        public DateTime NgayXuat { get; set; }
        public double SoTien { get; set; }
        public string IDHopDong { get; set; }

        public HoaDon(string mhd, DateTime ngayxuat, double sotien, string idhopdong)
        {
            this.MHD = mhd;
            this.NgayXuat = ngayxuat;
            this.SoTien = sotien;
            this.IDHopDong = idhopdong;
        }
        public static bool CompareMHD(HoaDon h1, HoaDon h2)
        {
            int x = String.Compare(h1.MHD, h2.MHD);
            if(x > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool CompareSoTien(HoaDon h1, HoaDon h2)
        {
            double x1 = Convert.ToDouble(h1.SoTien);
            double x2 = Convert.ToDouble(h2.SoTien);
            return (x1 > x2) ? true : false;
        }
    }
}
