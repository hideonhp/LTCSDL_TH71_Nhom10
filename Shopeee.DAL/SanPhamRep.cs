using Shopeee.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Shopeee.Common.DAl;
using Shopeee.Common.Rsp;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Shopeee.DAL
{
    public class SanPhamRep : GenericRep<SteveJobsContext, SanPham>
    {
        #region -- Overrides --
        public override SanPham Read(int id)
        {
            var res = All.FirstOrDefault(p => p.IdSanPham == id);
            return res;
        }
        public int Remove(int id)
        {
            var m = base.All.First(i => i.IdSanPham == id);
            m = base.Delete(m);
            return m.IdSanPham;
        }


        public SingleRsp CreateProduct(SanPham pro)
        {
            var res = new SingleRsp();
            using (var context = new SteveJobsContext())
            {
                using(var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var t = context.SanPham.Add(pro);
                        context.SaveChanges();
                        tran.Commit();

                    }catch(Exception ex)
                    {
                        tran.Rollback();
                        res.SetError(ex.StackTrace);
                    }
                }
            }return res;
        }


        public SingleRsp UpdateProduct(SanPham pro)
        {
            var res = new SingleRsp();
            using (var context = new SteveJobsContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var t = context.SanPham.Update(pro);
                        context.SaveChanges();
                        tran.Commit();

                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        res.SetError(ex.StackTrace);
                    }
                }
            }
            return res;
        }
        public object SanPham_Select_by_Id(int idLoai)
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

                cmd.CommandText = "SanPham_Select_by_Id";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", idLoai);

                da.SelectCommand = cmd;
                da.Fill(ds);

                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        var x = new
                        {
                            IdSanPham = row["IdSanPham"],
                            IdLoai = row["IdLoai"],
                            Ten = row["Ten"],
                            MoTa = row["MoTa"],
                            Gia = row["Gia"],
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
        #endregion
    }
}
