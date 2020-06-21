using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Shopeee.DAL.Models;
using Shopeee.Common.DAl;
using Shopeee.Common.Rsp;
namespace Shopeee.DAL
{
    public class GioHangRep : GenericRep<SteveJobsContext, GioHang>
    {
        public object GioHang_Insert(int idSanPham, int idUser)
        {
            List<object> res = new List<object>();
            var cnn = (SqlConnection)Context.Database.GetDbConnection();
            if (cnn.State == ConnectionState.Closed)
            {
                cnn.Open();
            }
            try
            {
                SqlDataAdapter da = new SqlDataAdapter();
                DataSet ds = new DataSet();

                var cmd = cnn.CreateCommand();

                cmd.CommandText = "GioHang_Insert";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdSanPham", idSanPham);
                cmd.Parameters.AddWithValue("@IdUsers", idUser);

                da.SelectCommand = cmd;
                da.Fill(ds);

                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        var x = new
                        {
                        };
                        res.Add(x);
                    }
                }
            }
            catch (Exception)
            {
                res = null;
            }
            return res;
        }
    }
}
