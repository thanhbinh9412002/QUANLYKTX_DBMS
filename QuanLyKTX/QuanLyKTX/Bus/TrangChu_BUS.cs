using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyKTX.DAO;
using QuanLyKTX.Class;


namespace QuanLyKTX.BUS
{
    internal class TrangChu_BUS
    {
        private TrangChu_DAO tcDAO;
        public TrangChu_BUS()
        {
            tcDAO = new TrangChu_DAO();
        }
        public string TimMaNhanVien(string CMND_CCCD)
        {
            return tcDAO.TimMaNhanVien(CMND_CCCD);
        }
    }
}
