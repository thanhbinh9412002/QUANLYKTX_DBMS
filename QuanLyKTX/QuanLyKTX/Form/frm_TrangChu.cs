﻿using System;
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
        public frm_Toa fmToa;
        public frm_Phong fmPhong;
        //public frm_Phong fmPhong;
        public string MNV = null;                   // Mã của người quản lý, dùng cho các form sau, gọi MNV là sẽ ra;
        public string CMND_CCCD = null;
        private string user;
        private string role;


        //-----------//Hiệu ứng//------------//

        public bool kt_caidat = true;    // biến dùng lưu sự kiện đóng tắt pannel cài đặt
        public bool kt_trangchu = true;    // biến dùng lưu sự kiện đóng tắt pannel cài đặt

        //--------------//-------------------//

        public frm_TrangChu(string user = "", string role = "")
        {
            InitializeComponent();
            this.user = user;
            this.role = role;
        }

        private void frm_TrangChu_Load(object sender, EventArgs e)   // sự kiện form load
        {
            timer2.Start();
            if (role == "Admin")
            {
                MainEnabled();
                LoadPicture();
            }
            else
            {
                MainNoEnabled();
                LoadPicture();
            }
        }
        private void MainEnabled()  // quyền admin sẽ xuất hiện tất cả button
        {
            btn_Toa.Enabled = true;
            btn_NhanVien.Enabled = true;
            btn_Phong.Visible = false;
            btn_Phong.Enabled = false;
            panel_caidat.Visible = false;
        }
        private void MainNoEnabled()  // quyền quản lý sẽ ẩn một số button
        {
            btn_NhanVien.Enabled = false;
            btn_NhanVien.Visible = false;
            btn_Toa.Visible = false;
            btn_Toa.Enabled = false;
            panel_caidat.Visible = false;
            btn_CaiDat.Location = new Point(12, 267);
            TrangChu_BUS tcBUS = new TrangChu_BUS();
            CMND_CCCD = user;
            MNV = tcBUS.TimMaNhanVien(CMND_CCCD);
        }

        private void LoadPicture()  // hiệu ungws tự động chuyển hình trên form trang chủ
        {
            pictureBox1.Visible = true;
            pictureBox2.Visible = false;
            pictureBox3.Visible = false;
            timer1.Start();
            panel_thongke.Visible = false;
        }

        private void btn_TrangChu_Click(object sender, EventArgs e)  // sự kiện khi nhấn nút trang chủ
        {
            TrangChu_BUS tcBUS = new TrangChu_BUS();
            if (kt_trangchu)
            {
                pictureBox1.Visible = false;
                pictureBox2.Visible = false;
                pictureBox3.Visible = false;
                panel_caidat.Visible = false;
                panel_thongke.Visible = true;
                if (role != "Admin")
                {
                    panel_taikhoan.Visible = false;
                    panel_toa.Visible = false;
                    
                }
                else
                {
                    panel_taikhoan.Visible = true;
                    panel_toa.Visible = true;
                    lb_nvnam.Text = Convert.ToString(tcBUS.TimSoLuongNhanVienTheoGioiTinh("Nam"));
                    lb_nvnu.Text = Convert.ToString(tcBUS.TimSoLuongNhanVienTheoGioiTinh("Nữ"));
                    lb_nvtong.Text = Convert.ToString(tcBUS.TongSoNhanVien());
                    lb_svnam.Text = Convert.ToString(tcBUS.TimSoLuongSinhVienTheoGioiTinh("Nam"));
                    lb_svnu.Text = Convert.ToString(tcBUS.TimSoLuongSinhVienTheoGioiTinh("Nữ"));
                    lb_svtong.Text = Convert.ToString(tcBUS.TongSoSinhVien());
                }
                kt_trangchu = false;
            }
            else
            {
                LoadPicture();
                kt_trangchu = true;
            }    
        }

        private void btn_HoaDon_Click(object sender, EventArgs e)  // chuyển sang form hóa đơn
        {
            
        }

        private void btn_Toa_Click(object sender, EventArgs e)  // chuyển sang form tòa
        {
            this.Hide();
            fmToa = new frm_Toa(user, role);
            fmToa.ShowDialog();
            this.Show();
        }

        private void btn_SinhVien_Click(object sender, EventArgs e)  // chuyển sang form sinh viên
        {
            
        }

        private void btn_NhanVien_Click(object sender, EventArgs e)  // chuyển sang form nhân viên
        {
            this.Hide();
            fmNhanVien = new frm_NhanVien(user, role);
            fmNhanVien.ShowDialog();
            this.Show();
        }

        private void btn_ThietBi_Click(object sender, EventArgs e)  // chuyển sang form thiết bị
        {

        }

        private void btn_CaiDat_Click(object sender, EventArgs e)  // sự kiện nhấn button cài đặt để xuất hiện nút đăng xuất và đổi mật khẩu
        {
            if (kt_caidat)
            {
                panel_caidat.Visible = true;
                kt_caidat = false;
            }
            else
            {
                panel_caidat.Visible = true;
                kt_caidat = true;
            }

        }

        private void btn_Phong_Click(object sender, EventArgs e)   // chuyển sang form phòng cho quyền quản lý
        {
            this.Hide();
            fmPhong = new frm_Phong(user, role);
            fmPhong.manv = MNV;
            fmPhong.ShowDialog();
            this.Show();
        }

        private void frm_TrangChu_HelpButtonClicked(object sender, CancelEventArgs e)   // sự kiện nhấn nút ? trên form
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

        private void timer1_Tick(object sender, EventArgs e)  // hiệu ứng chuyển ảnh trong trang chủ
        {
            if(pictureBox1.Visible == true && (DateTime.Now.Second == 0 || DateTime.Now.Second % 30 == 1))
            {
                pictureBox1.Visible = false;
                pictureBox2.Visible = true;
                pictureBox3.Visible = false;
            }
            else if (pictureBox2.Visible == true && (DateTime.Now.Second % 10 == 1 || DateTime.Now.Second % 40 == 1))
            {
                pictureBox1.Visible = false;
                pictureBox2.Visible = false;
                pictureBox3.Visible = true;
            }
            else if (pictureBox3.Visible == true && (DateTime.Now.Second % 20 == 1 || DateTime.Now.Second % 50 == 1))
            {
                pictureBox1.Visible = true;
                pictureBox2.Visible = false;
                pictureBox3.Visible = false;
            }
        }

        private void timer2_Tick(object sender, EventArgs e)   // hiệu ứng đồng hồ
        {
            txt_time.Text = DateTime.Now.ToLongTimeString();
            txt_day.Text = DateTime.Now.Date.ToString();
        }

        private void btn_resetpass_Click(object sender, EventArgs e)   // đổi mật khẩu
        {

        }

        private void btn_logout_Click(object sender, EventArgs e)  // đăng xuất
        {
            DialogResult dr;
            dr = MessageBox.Show("Bạn muốn thoát khỏi chương trình ?", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
            if (dr == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        private void frm_TrangChu_FormClosing(object sender, FormClosingEventArgs e)  // sự kiện nhấn nút x trên form
        {
            if (MessageBox.Show("Bạn có chắc là muốn thoát không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}
