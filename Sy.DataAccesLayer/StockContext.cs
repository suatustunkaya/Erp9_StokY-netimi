using System;
using System.Collections.Generic;
using System.Data.Entity; // DbContext için ekledik
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sy.Core.Abstracts;
using Sy.Core.ComplexTypes;
using Sy.Core.Entities;

namespace Sy.DataAccesLayer
{
    public class StockContext : DbContext
    {
        public StockContext() : base("name=MyCon")
        {
        }
        public override int SaveChanges()
        {
            // Audit işlemleri
            if (StockSettings.UserInfo != null)
            {
                var selectedEntryLİst=ChangeTracker.Entries().Where(x => x.Entity is AuditBase && x.State == EntityState.Added);
                foreach (var item in selectedEntryLİst)
                {
                    ((AuditBase)item.Entity).CreatedUser = StockSettings.UserInfo.Email;
                    ((AuditBase)item.Entity).CreatedDate = DateTime.Now;
                }
                selectedEntryLİst = ChangeTracker.Entries().Where(x => x.Entity is AuditBase && x.State == EntityState.Modified);
                foreach (var item in selectedEntryLİst)
                {
                    ((AuditBase)item.Entity).UpdatedUser = StockSettings.UserInfo.Email;
                    ((AuditBase)item.Entity).UpdatedDate= DateTime.Now;
                }
            }
            return base.SaveChanges();
        }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
    }
}
