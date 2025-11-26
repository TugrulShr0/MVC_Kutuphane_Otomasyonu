using MVC_Kutuphane_Otomasyonu_Entities.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Kutuphane_Otomasyonu_Entities.Mapping
{
    public class EmanetKitaplarMap: EntityTypeConfiguration<EmanetKitaplar>
    {
        public EmanetKitaplarMap()
        {
            this.ToTable("EmanetKitaplar");//Table Adı
            this.HasKey(x => x.ID);//Primary Key
            this.Property(x => x.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity); //Identity
            this.Property(x => x.UyeID).IsRequired();
            this.Property(x => x.KitapID).IsRequired();
            this.Property(x => x.KitapSayisi).IsRequired();
            this.Property(x => x.EmanetTarihi).IsRequired();
            this.Property(x => x.IadeTarihi).IsRequired();
            this.Property(x => x.ID).HasColumnName("id");//Database deki kolon adı
            this.Property(x => x.UyeID).HasColumnName("UyeID");
            this.Property(x => x.KitapID).HasColumnName("KitapID");
            this.Property(x => x.KitapSayisi).HasColumnName("KitapSayisi");
            this.Property(x => x.EmanetTarihi).HasColumnName("EmanetTarihi");
            this.Property(x => x.IadeTarihi).HasColumnName("IadeTarihi");

            this.HasRequired(x => x.kitaplar).WithMany(x => x.EmanetKitaplar).HasForeignKey(x => x.KitapID);

            this.HasRequired(x => x.Uyeler).WithMany(x => x.EmanetKitaplar).HasForeignKey(x => x.UyeID);        
        }
    }
}
