using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using MVC_Kutuphane_Otomasyonu_Entities.Model;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_Kutuphane_Otomasyonu_Entities.Mapping
{
    public class DuyurularMap:EntityTypeConfiguration<Duyurular>
    {
        public DuyurularMap()
        {
            this.ToTable("Duyurular");//Table Adı
            this.HasKey(x => x.ID);//Primary Key
            this.Property(x => x.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity); //Identity
            this.Property(x => x.Baslik).HasColumnType("varchar"); //Veri tipi
            this.Property(x => x.Baslik).IsRequired().HasMaxLength(200); //Boş geçilemez ve max uzunluk
            this.Property(x => x.Duyuru).IsRequired().HasMaxLength(500);
            this.Property(x => x.Aciklama).IsRequired().HasMaxLength(5000);

            this.Property(x => x.ID).HasColumnName("ID");//Database deki kolon adı
            this.Property(x => x.Baslik).HasColumnName("Baslık");
            this.Property(x => x.Duyuru).HasColumnName("Duyuru");
            this.Property(x => x.Aciklama).HasColumnName("Aciklama");
            this.Property(x => x.Tarih).HasColumnName("Tarih");
        }
    }
}
