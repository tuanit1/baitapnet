 using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaiTapNET
{
    public partial class Form1 : Form
    {
        public delegate void setInfomationCallBack(string key, HoaDon hd = null);
        public setInfomationCallBack setInfomation;

        public delegate bool Compare(HoaDon obj1, HoaDon obj2);

        public Form1()
        {
            InitializeComponent();
            LoadCBB();
            LoadCBBSort();
        }
        public void ReLoad()
        {
            HopDong i = (HopDong)cbb_HopDong.SelectedItem;
            List<HoaDon> hoadonlist = CSDL_OOP.Instance.getListByIDHopDong(i.IDHopDong);
            Show(hoadonlist);
        }
        public void LoadCBB()
        {
            HopDong hd = new HopDong("HD0", "All", DateTime.Now);
            cbb_HopDong.Items.Add(hd);
            foreach (HopDong i in CSDL_OOP.Instance.listHopDong)
            {
                cbb_HopDong.Items.Add(i);
            }
            cbb_HopDong.DisplayMember = "TenHopDong";
            cbb_HopDong.SelectedIndex = 0;
        }
        public void Show(List<HoaDon> list, Compare cmp = null)
        {

            if (cmp != null)
            {
                Sort(list, cmp);
            }

            dataGridView1.DataSource = CSDL_OOP.Instance.getDataTableHoaDon(list);
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            HopDong i = (HopDong)cbb_HopDong.SelectedItem;
            List<HoaDon> hoadonlist = CSDL_OOP.Instance.getListByIDHopDong(i.IDHopDong);
            Show(hoadonlist);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            const string KEY = "add";

            Form2 frm2 = new Form2();
            frm2.reloadDRGV += new Form2.ReLoadDRGVCallBack(ReLoad);

            this.setInfomation += new setInfomationCallBack(frm2.formInit);

            frm2.returnvalue += new Form2.ReturnValueCallBack(CSDL_OOP.Instance.addHoaDonToList);

            setInfomation(KEY);

            frm2.ShowDialog();

            CSDL.Instance.SyncToCSDL(CSDL_OOP.Instance.listHoaDon);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                const string KEY = "edit";

                Form2 frm2 = new Form2();
                frm2.reloadDRGV += new Form2.ReLoadDRGVCallBack(ReLoad);

                this.setInfomation += new setInfomationCallBack(frm2.formInit);

                frm2.returnvalue += new Form2.ReturnValueCallBack(CSDL_OOP.Instance.updateHoaDonToList);

                string mahoadon = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                HoaDon hoadon = CSDL_OOP.Instance.getHoaDonByMHD(mahoadon);

                setInfomation(KEY, hoadon);

                frm2.ShowDialog();

                CSDL.Instance.SyncToCSDL(CSDL_OOP.Instance.listHoaDon);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            List<HoaDon> hd = CSDL_OOP.Instance.getListHoaDonBySearch(txbSearch.Text);
            Show(hd);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                string name = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                string message = "You wanna detete " + name+"?";

                if (MessageBox.Show(message, "Warning", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    string mhd = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                    Show(CSDL_OOP.Instance.deletelist(mhd));
                    CSDL.Instance.SyncToCSDL(CSDL_OOP.Instance.listHoaDon);
                }
            }
        }

        private void btnSort_Click(object sender, EventArgs e)
        {

            switch (cbb_Sort.SelectedIndex)
            {
                case 0:
                    if (cbb_Sort.SelectedItem != null)
                    {
                        Show(CSDL_OOP.Instance.listHoaDon, HoaDon.CompareMHD);
                    }
                    break;
                case 1:
                    if (cbb_Sort.SelectedItem != null)
                    {
                        Show(CSDL_OOP.Instance.listHoaDon, HoaDon.CompareSoTien);
                    }
                    break;
            }
        }
        public void Sort(List<HoaDon> arr, Compare cmp) // hàm sắp xếp sử dụng delegate Compare
        {
            for (int i = 0; i < arr.Count - 1; i++)
            {
                for (int j = i + 1; j < arr.Count; j++)
                {
                    if (cmp(arr[i], arr[j]))
                    {
                        HoaDon temp = arr[i];
                        arr[i] = arr[j];
                        arr[j] = temp;
                    }
                }
            }
        }
        public void LoadCBBSort() 
        {
            List<HopDong> cbbSortList = new List<HopDong>
            {
                new HopDong("0", "MaHoaDon", DateTime.Now),
                new HopDong("1", "SoTien",DateTime.Now),
            };
            cbb_Sort.DataSource = cbbSortList;
            cbb_Sort.DisplayMember = "TenHopDong";
        }

        private void btnnew_Click(object sender, EventArgs e)
        {
            MessageBox.Show("newFunction");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("again");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Tuan dep trai");
        }
    }
}
