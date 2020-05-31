using Shopeee.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Shopeee.Common.DAl;
using Shopeee.Common.Rsp;

namespace Shopeee.DAL
{
    public class SanPhamRep : GenericRep<SteveJobsContext, Products>
    {
        #region -- Overrides --
        public override Products Read(int id)
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


        public SingleRsp CreateProduct(Products pro)
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


        public SingleRsp UpdateProduct(Products pro)
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
        #endregion
    }
}
