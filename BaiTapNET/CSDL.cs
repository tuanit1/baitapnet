using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTapNET
{
    public class CSDL
    {
        public DataTable DataHoaDon { get; set; }
        public DataTable DataHopDong { get; set; }

        private static CSDL _Instance;
        public static CSDL Instance
        {
            get { if (_Instance == null) { _Instance = new CSDL(); } return CSDL._Instance; }
            private set { }
        }
        private CSDL()
        {
            DataHoaDon = new DataTable();
            DataHoaDon.Columns.AddRange(new DataColumn[]
            {
                new DataColumn("MaHoaDon", typeof(string)),
                new DataColumn("NgayXuat", typeof(DateTime)),
                new DataColumn("SoTien", typeof(double)),
                new DataColumn("IDHopDong", typeof(string)),
            });

            DataHopDong = new DataTable();
            DataHopDong.Columns.AddRange(new DataColumn[]
            {
                new DataColumn("IDHopDong", typeof(string)),
                new DataColumn("TenHopDong", typeof(string)),
                new DataColumn("NgayHetHan", typeof(DateTime)),
            });

            //hoa don
            List<HoaDon> listHoaDon = new List<HoaDon>()
            {
                new HoaDon("MaHoaDon1", Convert.ToDateTime("4/6/2007"), 250000, "HD1"),
                new HoaDon("MaHoaDon3", Convert.ToDateTime("4/6/2006"), 350000, "HD1"),
                new HoaDon("MaHoaDon5", Convert.ToDateTime("4/6/2005"), 450000, "HD1"),
                new HoaDon("MaHoaDon4", Convert.ToDateTime("4/6/2004"), 550000, "HD2"),
                new HoaDon("MaHoaDon6", Convert.ToDateTime("4/6/2003"), 650000, "HD2"),
                new HoaDon("MaHoaDon4", Convert.ToDateTime("4/6/2002"), 750000, "HD2"),
                new HoaDon("MaHoaDon2", Convert.ToDateTime("4/6/2001"), 965353989, "HD2"),

            };
            foreach (HoaDon item in listHoaDon)
            {
                DataRow dr = DataHoaDon.NewRow();
                dr["MaHoaDon"] = item.MHD;
                dr["NgayXuat"] = item.NgayXuat;
                dr["SoTien"] = item.SoTien;
                dr["IDHopDong"] = item.IDHopDong;
                DataHoaDon.Rows.Add(dr);
            }

            //hopdong
            List<HopDong> listHopDong = new List<HopDong>()
            {
                new HopDong("HD1", "HopDong1", DateTime.Now),
                new HopDong("HD2", "HopDong2", DateTime.Now),
            };
            foreach (HopDong item in listHopDong)
            {
                DataRow dr = DataHopDong.NewRow();
                dr["IDHopDong"] = item.IDHopDong;
                dr["TenHopDong"] = item.TenHopDong;
                dr["NgayHetHan"] = item.NgayHetHan;
                DataHopDong.Rows.Add(dr);
            }
        }
        public void SyncToCSDL(List<HoaDon> list)
        {
            foreach (HoaDon item in list)
            {
                DataRow dr = DataHoaDon.NewRow();
                dr["MaHoaDon"] = item.MHD;
                dr["NgayXuat"] = item.NgayXuat;
                dr["SoTien"] = item.SoTien;
                dr["IDHopDong"] = item.IDHopDong;
                DataHoaDon.Rows.Add(dr);
            }
        }
    }
}


// Hello anh tuanit1
// hello anh tuanit2
