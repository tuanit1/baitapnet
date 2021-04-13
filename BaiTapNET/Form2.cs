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
    public partial class Form2 : Form
    {
        public delegate void ReLoadDRGVCallBack();
        public ReLoadDRGVCallBack reloadDRGV;

        public delegate void ReturnValueCallBack(HoaDon hoadon);
        public ReturnValueCallBack returnvalue;

        public Form2()
        {
            InitializeComponent();
        }
        public void LoadCBB()
        {
            foreach (HopDong i in CSDL_OOP.Instance.listHopDong)
            {
                cbb_HopDong.Items.Add(i);
            }
            cbb_HopDong.DisplayMember = "TenHopDong";
            cbb_HopDong.SelectedIndex = 0;
        }
        public void formInit(string KEY, HoaDon hd = null)
        {
            LoadCBB();
            switch (KEY)
            {
                case ("add"):
                    lbText.Text = "Add Information";

                    this.btnOK.Click += new System.EventHandler(AddHoaDon);

                    break;

                case ("edit"):
                    lbText.Text = "Edit Information";

                    this.btnOK.Click += new System.EventHandler(EditHoaDon);

                    txbMaHoaDon.Enabled = false;
                    txbMaHoaDon.Text = hd.MHD;
                    txbSoTien.Text = hd.SoTien.ToString();
                    dateTimePicker2.Value = hd.NgayXuat;

                    cbb_HopDong.SelectedIndex = CSDL_OOP.Instance.getInDexByIDHopDong(hd.IDHopDong);

                    break;
            }

        }
        public void AddHoaDon(object obj, EventArgs e)
        {
            if(txbMaHoaDon.Text == "" || txbSoTien.Text == "" || txbMaHoaDon.Text.Length != 9)
            {
                MessageBox.Show("Please fill correct infomation", "Warning");
            }
            else
            {
                string mhd = txbMaHoaDon.Text;
                string idhd = ((HopDong)cbb_HopDong.SelectedItem).IDHopDong;
                double sotien = Convert.ToDouble(txbSoTien.Text);
                DateTime day = Convert.ToDateTime(dateTimePicker2.Value.ToString("MM/dd/yyyy"));

                HoaDon hd = new HoaDon(mhd, day, sotien, idhd);

                this.returnvalue(hd);
                this.reloadDRGV();
                this.Close();
            }
        }
        public void EditHoaDon(object obj, EventArgs e)
        {
            if (txbMaHoaDon.Text == "" || txbSoTien.Text == "" || txbMaHoaDon.Text.Length != 9)
            {
                MessageBox.Show("Please fill conrect information!", "Warning");
            }
            else
            {
                string mhd = txbMaHoaDon.Text;
                string idhd = ((HopDong)cbb_HopDong.SelectedItem).IDHopDong;
                double sotien = Convert.ToDouble(txbSoTien.Text);
                DateTime day = Convert.ToDateTime(dateTimePicker2.Value.ToString("MM/dd/yyyy"));

                HoaDon hd = new HoaDon(mhd, day, sotien, idhd);

                this.returnvalue(hd);
                this.reloadDRGV();
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
