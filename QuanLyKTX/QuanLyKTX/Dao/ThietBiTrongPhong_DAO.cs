﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyKTX.DataProvider;
using System.Data;
using System.Data.SqlClient;
namespace QuanLyKTX.Dao
{
    public class ThietBiTrongPhong_DAO
    {
        private DBConnection cnn = null;
        public ThietBiTrongPhong_DAO()
        {
            cnn = new DBConnection();
        }
        public DataTable GetAllInformation(string maphong)
        {
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@MaPhong", System.Data.SqlDbType.Char);
            sqlParameters[0].Value = maphong;
            return cnn.executeReader("select * from func_ThietBiQuanLy(@MaPhong)", sqlParameters);
        }
        public DataTable GetIdEq()
        {
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return cnn.executeReader("select * from func_ThietBiQuanLy()", sqlParameters);
        }
        public void AddEqRoom(string matb, string maphong, int slhong, int sltot, int sltoida)
        {
            string sql = "proc_ThemThietBiTrongPhong";
            string[] pNames = { "@matb", "@maphong", "@soluonghong", "@soluongtot", "@soluongtoida" };
            object[] pvalues = { matb, maphong, slhong, sltot, sltoida };
            cnn.ExecuteStoredProcedure_Update(sql, pNames, pvalues);
        }

        public void UpdateEqRoom(string matb, string maphong, int slhong, int sltot, int sltoida)
        {
            string sql = "proc_SuaThietBiTrongPhong";
            string[] pNames = { "@matb", "@maphong", "@soluonghong", "@soluongtot", "@soluongtoida" };
            object[] pvalues = { matb, maphong, slhong, sltot, sltoida };
            cnn.ExecuteStoredProcedure_Update(sql, pNames, pvalues);
        }

        public void DeleteEqRoom(string ma, string maphong)
        {
            string sql = "proc_XoaThietBiTrongPhong";
            string[] pNames = { "@matb", "@maphong" };
            object[] pvalues = { ma, maphong };
            cnn.ExecuteStoredProcedure_Update(sql, pNames, pvalues);
        }
    }
}
