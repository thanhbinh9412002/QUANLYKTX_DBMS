using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyKTX.DataProvider;
using QuanLyKTX.Class;
using System.Data.SqlClient;

namespace QuanLyKTX.DAO
{
    internal class TrangChu_DAO
    {
        private DBConnection cnn;
        public TrangChu_DAO()
        {
            cnn = new DBConnection();
        }
        public string TimMaNhanVien(string CMND_CCCD)
        {
            const string sql = "select MaNhanVien from NhanVien where CMND_CCCD = @CMND_CCCD";
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@CMND_CCCD", System.Data.SqlDbType.VarChar);
            sqlParameters[0].Value = Convert.ToString(CMND_CCCD);
            object a = cnn.executeScalar(sql, sqlParameters);
            return Convert.ToString(a);
        }
        public int TimSoLuongNhanVienTheoGioiTinh(string gioitinh)
        {
            string spName = "[dbo].[func_SoLuongNhanVienTheoGioiTinh]"; // Tên hàm
            // Tên các tham số trong thủ tục
            string[] pNames = { "@gioitinh"};
            // Giá trị tương ứng muốn gán cho từng tham số trên
            object[] pValues = {gioitinh};
            int count = cnn.ExecuteStoredProcedure(spName, pNames, pValues);
            return count;
        }
        public string TongSoNhanVien()
        {
            const string sql = "select count(MaNhanVien) from NhanVien";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            object sl = cnn.executeScalar(sql, sqlParameters);
            return Convert.ToString(sl);
        }
        public int TimSoLuongSinhVienTheoGioiTinh(string gioitinh)
        {
            string spName = "[dbo].[func_SoLuongSinhVienTheoGioiTinh]"; // Tên hàm
            // Tên các tham số trong thủ tục
            string[] pNames = { "@gioitinh" };
            // Giá trị tương ứng muốn gán cho từng tham số trên
            object[] pValues = { gioitinh };
            int count = cnn.ExecuteStoredProcedure(spName, pNames, pValues);
            return count;
        }
        public string TongSoSinhVien()
        {
            const string sql = "select count(MaSinhVien) from SinhVien";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            object sl = cnn.executeScalar(sql, sqlParameters);
            return Convert.ToString(sl);
        }
    }
}