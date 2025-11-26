using MVC_Kutuphane_Otomasyonu_Entities.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Kutuphane_Otomasyonu_Entities.Mapping
{
    public class UyelerMap: EntityTypeConfiguration<Uyeler>
    {
        public UyelerMap()
        {
            this.ToTable("Uyeler");//Table Adı
            this.HasKey(x => x.ID);//Primary Key
            this.Property(x => x.ID).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity); //Identity
            this.Property(x => x.AdSoyad).IsRequired().HasMaxLength(200);
            this.Property(x => x.Email).IsRequired().HasMaxLength(200);
            this.Property(x => x.Telefon).HasMaxLength(20);
            this.Property(x => x.Adres).IsRequired().HasMaxLength(500);
       
        }
    }
}
