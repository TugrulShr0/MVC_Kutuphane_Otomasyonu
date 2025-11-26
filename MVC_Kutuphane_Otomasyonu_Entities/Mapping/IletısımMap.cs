using MVC_Kutuphane_Otomasyonu_Entities.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Kutuphane_Otomasyonu_Entities.Mapping
{
    internal class IletısımMap:EntityTypeConfiguration<İletisim>
    {
        public IletısımMap()
        {
            this.ToTable("Iletisim");//Table Adı
            this.HasKey(x => x.ID);//Primary Key
            this.Property(x => x.ID).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity); //Identity
            this.Property(x => x.AdSoyad).IsRequired().HasMaxLength(200);
            this.Property(x => x.Email).IsRequired().HasMaxLength(200);
     
            this.Property(x => x.Mesaj).IsRequired().HasMaxLength(5000);
            this.Property(x => x.ID).HasColumnName("id");//Database deki kolon adı
            this.Property(x => x.AdSoyad).HasColumnName("AdSoyad");
            this.Property(x => x.Email).HasColumnName("Email");
 ;
            this.Property(x => x.Mesaj).HasColumnName("Mesaj");
            this.Property(x => x.Tarih).HasColumnName("Tarih");
        }
    }
}
