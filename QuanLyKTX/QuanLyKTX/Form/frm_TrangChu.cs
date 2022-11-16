using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyKTX.Class;
using QuanLyKTX.BUS;

namespace QuanLyKTX
{
    public partial class frm_TrangChu : Form
    {
        public frm_DangNhap fmDangNhap;
        public frm_NhanVien fmNhanVien;
        public string chucvu = null;
        public string MNV = null;                   // Mã của người quản lý, dùng cho các form sau, gọi MNV là sẽ ra;
        public string CMND_CCCD = null;
        private string user;
        private string role;
        public frm_TrangChu(string user = "", string role = "")
        {
            InitializeComponent();
            this.user = user;
            this.role = role;
        }

        private void frm_TrangChu_Load(object sender, EventArgs e)
        {
            timer1.Start();
            timer2.Start();
            LoadPicture();
            if (role == "Admin")
            {
                MainEnabled();
            }
            else
            {
                MainNoEnabled();
            }
        }
        private void MainEnabled()  // quyền admin
        {
            btn_Toa.Enabled = true;
            btn_NhanVien.Enabled = true;
            btn_Phong.Visible = false;
            btn_Phong.Enabled = false;
        }
        private void MainNoEnabled()  // quyền quản lý
        {
            btn_NhanVien.Enabled = false;
            btn_NhanVien.Visible = false;
            btn_Toa.Visible = false;
            btn_Toa.Enabled = false;
            btn_CaiDat.Location = new Point(12, 267);
            TrangChu_BUS tcBUS = new TrangChu_BUS();
            CMND_CCCD = user;
            MNV = tcBUS.TimMaNhanVien(CMND_CCCD);
        }

        private void LoadPicture()
        {
            pictureBox2.Visible = false;
            pictureBox3.Visible = false;
        }

        private void btn_TrangChu_Click(object sender, EventArgs e)
        {
           
        }

        private void btn_HoaDon_Click(object sender, EventArgs e)
        {
            
        }

        private void btn_Toa_Click(object sender, EventArgs e)
        {

        }

        private void btn_SinhVien_Click(object sender, EventArgs e)
        {

        }

        private void btn_NhanVien_Click(object sender, EventArgs e)
        {
            this.Hide();
            fmNhanVien = new frm_NhanVien(user, role);
            fmNhanVien.ShowDialog();
        }

        private void btn_ThietBi_Click(object sender, EventArgs e)
        {

        }

        private void btn_CaiDat_Click(object sender, EventArgs e)
        {

        }

        private void btn_Phong_Click(object sender, EventArgs e)
        {

        }

        private void frm_TrangChu_HelpButtonClicked(object sender, CancelEventArgs e)
        {
            DialogResult dr;
            dr = MessageBox.Show("\t\tQUẢN LÝ KÝ TÚC XÁ\nNhóm 07\nThành viên:\n" +
                                                         "\n\t1. Nguyễn Thanh Bình\tMSSV: 20133025" +
                                                         "\n\t2. Nguyễn Nhật Triều\tMSSV: 20133102" +
                                                         "\n\t3. Đoàn Quốc Trung\tMSSV: 20133104", 
                            "Thông tin", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if(dr == DialogResult.OK)
            {
                e.Cancel = true;
            }    
        }

        private void frm_TrangChu_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dr;
            dr = MessageBox.Show("Bạn muốn thoát khỏi chương trình ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                Application.Exit();
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(pictureBox1.Visible == true)
            {
                pictureBox1.Visible = false;
                pictureBox2.Visible = true;
                pictureBox3.Visible = false;
            }
            else if (pictureBox2.Visible == true)
            {
                pictureBox1.Visible = false;
                pictureBox2.Visible = false;
                pictureBox3.Visible = true;
            }
            else if (pictureBox3.Visible == true)
            {
                pictureBox1.Visible = true;
                pictureBox2.Visible = false;
                pictureBox3.Visible = false;
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            txt_time.Text = DateTime.Now.ToLongTimeString();
            txt_day.Text = DateTime.Now.Date.ToString();
        }
    }
}
