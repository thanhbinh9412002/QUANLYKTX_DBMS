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
        private DBConnection conn;
        public TrangChu_DAO()
        {
            conn = new DBConnection();
        }
        public string TimMaNhanVien(string CMND_CCCD)
        {
            const string sql = "select MaNhanVien from NhanVien where CMND_CCCD = @CMND_CCCD";
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@CMND_CCCD", System.Data.SqlDbType.VarChar);
            sqlParameters[0].Value = Convert.ToString(CMND_CCCD);
            object a = conn.executeScalar(sql, sqlParameters);
            return Convert.ToString(a);
        }

    }
}