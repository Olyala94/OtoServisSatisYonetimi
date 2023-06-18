using OtoServisSatis.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace OtoServisSatis.DAL
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Arac> Araclar { get; set; }

        public DbSet<Kullanici> Kullanicilar { get; set; }

        public DbSet<Marka> Markalar { get; set; }

        public DbSet<Musteri> Miusteriler { get; set; }

        public DbSet<Role> Roller { get; set; }

        public DbSet<Satis> Satislar { get; set; }

        public DbSet<Servis> Servisler { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }
        public class DatabaseInitializer : CreateDatabaseIfNotExists<DatabaseContext> 
        {
            protected override void Seed(DatabaseContext context)
            {
                //if (!context.Kullanicilar.Any())
                //{
                //    var rol = context.Roller.Add(new Role()
                //    {
                //        Adi = "Admin"
                //    });
                //    context.Kullanicilar.Add(new Kullanici()
                //    {
                //        Adi = "Admin",
                //        AktifMi = true,
                //        EklenmeTarihi = DateTime.Now,
                //        Email = "admin@otoservissatis.tc",
                //        KullaniciAdi = "admin",
                //        Sifre = "123456",
                //        Role = rol,
                //        RoleId = rol.Id
                //    });
                //    context.SaveChanges();
                //}
                base.Seed(context);
            }
        }
        public DatabaseContext() : base("name=DatabaseContext")
        {
            Database.SetInitializer(new DatabaseInitializer());
        }
    }
}
