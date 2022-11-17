using QuanLyKTX.DataProvider;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKTX.Dao
{
    public class ChiTietPhong_DAO
    {
        private DBConnection cnn = null;
        public ChiTietPhong_DAO()
        {
            cnn = new DBConnection();
        }
        public DataTable GetAllInformation(string maphong)
        {
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@MaPhong", System.Data.SqlDbType.Char);
            sqlParameters[0].Value = maphong;
            return cnn.executeReader("SELECT * FROM func_DanhSachSinhVienTheoPhong(@MaPhong)", sqlParameters);
        }
        public DataTable GetComboBox(string matoa)
        {
            string sql = "pro_DanhSachPhongTheoToa";
            string[] pNames = { "@matoa" };
            object[] pvalues = { matoa };
            return cnn.ExecuteProcedureDatatable(sql, pNames, pvalues);
        }
        public string MaToa(string manql)
        {
            string matoa = "Select TenToa from Toa Where MaNguoiQuanLy = @manql";
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@manql", System.Data.SqlDbType.VarChar);
            sqlParameters[0].Value = Convert.ToString(manql);
            object TenToa = cnn.executeScalar(matoa, sqlParameters);
            return Convert.ToString(TenToa);
        }
    }
}
