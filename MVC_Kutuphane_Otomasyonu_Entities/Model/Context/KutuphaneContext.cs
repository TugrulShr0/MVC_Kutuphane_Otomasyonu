using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Kutuphane_Otomasyonu_Entities.Model.Context
{
    public class KutuphaneContext : DbContext
    {
        public KutuphaneContext() : base("Kutuphane")
        {


        }
        public DbSet<Duyurular> Duyurular { get; set; }
        public DbSet<EmanetKitaplar> EmanetKitaplar { get; set; }
        public DbSet<Hakkimizda> Hakkimizda { get; set; }
        public DbSet<İletisim> Iletısım { get; set; }
        public DbSet<KitapHareketleri> KitapHareketleri { get; set; }
        public DbSet<KitapKayitHareketleri> KitapkayitHareketleri { get; set; }
        public DbSet<Kitaplar> Kitaplar { get; set; }
        public DbSet<KitapTurleri> KitapTurleri { get; set; }
        public DbSet<KullanıcıHareketleri> KullanıcıHareketleri { get; set; }
        public DbSet<Kullanicilar> Kullanicilar { get; set; }
        public  DbSet<KullanıcıRolleri> KullanıcıRolleri { get; set; }
        public DbSet<Roller> Roller { get; set; }
        public DbSet<Uyeler> Uyeler { get; set; }

       protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new Mapping.DuyurularMap());
            modelBuilder.Configurations.Add(new Mapping.EmanetKitaplarMap());
            modelBuilder.Configurations.Add(new Mapping.HakkımızdaMap());
            modelBuilder.Configurations.Add(new Mapping.IletısımMap());
            modelBuilder.Configurations.Add(new Mapping.KitapHareketleriMap());
            modelBuilder.Configurations.Add(new Mapping.KitapKayitHareketleriMap());
            modelBuilder.Configurations.Add(new Mapping.KitaplarMap());
            modelBuilder.Configurations.Add(new Mapping.KitapTurleriMap());
            modelBuilder.Configurations.Add(new Mapping.KullanıcıHareketleriMap());
            modelBuilder.Configurations.Add(new Mapping.KullanıcılarMap());
            modelBuilder.Configurations.Add(new Mapping.KullanıcıRolleriMap());
            modelBuilder.Configurations.Add(new Mapping.RollerMap());
            modelBuilder.Configurations.Add(new Mapping.UyelerMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
