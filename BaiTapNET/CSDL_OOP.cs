using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTapNET
{
    public class CSDL_OOP
    {
        public List<HoaDon> listHoaDon { get; set; }
        public List<HopDong> listHopDong { get; set; }
        private static CSDL_OOP _Instance;
        public static CSDL_OOP Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new CSDL_OOP();
                }
                return _Instance;
            }

            private set { }
        }
        private CSDL_OOP()
        {
            listHoaDon = new List<HoaDon>();
            foreach(DataRow item in CSDL.Instance.DataHoaDon.Rows)
            {
                listHoaDon.Add(getHOADONByDataRow(item));
            }

            listHopDong = new List<HopDong>();
            foreach(DataRow item in CSDL.Instance.DataHopDong.Rows)
            {
                listHopDong.Add(getHOPDONGByDataRow(item));
            }
        }

        public HoaDon getHOADONByDataRow(DataRow row)
        {
            string mhd = row["MaHoaDon"].ToString().Trim();
            DateTime day = Convert.ToDateTime(row["NgayXuat"]);
            double sotien = Convert.ToDouble(row["SoTien"]);
            string idhopdong = row["IDHopDong"].ToString().Trim();
            return new HoaDon(mhd, day, sotien, idhopdong);
        }
        public HopDong getHOPDONGByDataRow(DataRow row)
        {
            string id = row["IDHopDong"].ToString().Trim();
            string tenhopdong = row["TenHopDong"].ToString().Trim();
            DateTime day = Convert.ToDateTime(row["NgayHetHan"]);
            return new HopDong(id, tenhopdong, day);
        }
        public DataTable getDataTableHoaDon(List<HoaDon> list)
        {
            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[]
            {
                new DataColumn("MaHoaDon", typeof(string)),
                new DataColumn("NgayXuat", typeof(DateTime)),
                new DataColumn("SoTien", typeof(double)),
                new DataColumn("TenHopDong", typeof(string)),
            });

            foreach (HoaDon i in list)
            {
                DataRow dr = dt.NewRow();
                dr["MaHoaDon"] = i.MHD;
                dr["NgayXuat"] = i.NgayXuat;
                dr["SoTien"] = i.SoTien;
                dr["TenHopDong"] = CSDL_OOP.Instance.getNameHopDongbyID(i.IDHopDong);
                dt.Rows.Add(dr);
            }
            return dt;
        }
        public string getNameHopDongbyID(string id)
        {
            foreach (HopDong item in listHopDong)
            {
                if(item.IDHopDong == id)
                {
                    return item.TenHopDong;
                }
            }
            return "";
        }

        public List<HoaDon> getListByIDHopDong(string idhopdong)
        {
            List<HoaDon> lt = new List<HoaDon>();
            if (idhopdong == "HD0")
            {
                return listHoaDon;
            }
            else
            {
                foreach (HoaDon i in listHoaDon)
                {
                    if (i.IDHopDong == idhopdong)
                    {
                        lt.Add(i);
                    }
                }
                return lt;
            }
        }
        public List<HoaDon> getListHoaDonBySearch(string text)
        {
            List<HoaDon> l = new List<HoaDon>();
            foreach (HoaDon i in listHoaDon)
            {
                if (i.MHD.ToLower().Contains(text.ToLower()))
                {
                    l.Add(i);
                }
            }
            return l;
        }
        public HoaDon getHoaDonByMHD(string mhd)
        {
            foreach (HoaDon item in listHoaDon)
            {
                if (item.MHD == mhd)
                {
                    return item;
                }
            }
            return null;
        }

        public int getInDexByIDHopDong(string id)
        {
            int n = 0;
            foreach(HopDong item in listHopDong)
            {
                if(item.IDHopDong == id)
                {
                    return n;
                }
                n++;
            }
            return -1;
        }
        public int getIndexbymaHoaDon(string id)
        {
            int n = 0;
            foreach(HoaDon item in listHoaDon)
            {
                if(item.MHD == id)
                {
                    return n;
                }
                n++;
            }
            return -1;
        }
        public void addHoaDonToList(HoaDon hd)
        {
            listHoaDon.Add(hd);
        }
        public void updateHoaDonToList(HoaDon hd)
        {
            int index = getIndexbymaHoaDon(hd.MHD);
            listHoaDon.RemoveAt(index);
            listHoaDon.Insert(index, hd);
        }
        public List<HoaDon> deletelist(string mhd)
        {
            int index = getIndexbymaHoaDon(mhd);
            listHoaDon.RemoveAt(index);
            return listHoaDon;
        }

    }
}
