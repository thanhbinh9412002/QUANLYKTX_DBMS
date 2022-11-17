using QuanLyKTX.Bus;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKTX
{
    public partial class frm_ChiTietPhong : Form
    {
        private ChiTietPhong_BUS ChiTietPhongBUS;
        public frm_Phong frmPhong;
        public string maphong = null;
        public string matoa;
        public string manql;
        public frm_ChiTietPhong()
        {
            InitializeComponent();
            frmPhong = new frm_Phong();
            ChiTietPhongBUS = new ChiTietPhong_BUS();
            //manql = frmPhong.nv;
            //matoa = ChiTietPhongBUS.MaToa(manql);
        }
        public void LoadData()
        {
            dgvDSSV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDSSV.DataSource = ChiTietPhongBUS.GetAllInformation(maphong);
        }
        public void LoadComboBox()
        {
            /*cbbPhong.DataSource = ChiTietPhongBUS.GetComboBox(matoa);
            cbbPhong.DisplayMember = "MaPhong";
            cbbPhong.ValueMember = "MaPhong";*/

        }
        private void frm_ChiTietPhong_Load(object sender, EventArgs e)
        {
            LoadData();
            LoadComboBox();
            cbbPhong.Text = maphong;
        }

        private void cbbPhong_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvDSSV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDSSV.DataSource = ChiTietPhongBUS.GetAllInformation(cbbPhong.Text);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
