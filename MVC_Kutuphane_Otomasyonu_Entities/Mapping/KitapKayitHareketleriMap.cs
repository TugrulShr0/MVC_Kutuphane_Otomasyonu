using MVC_Kutuphane_Otomasyonu_Entities.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Kutuphane_Otomasyonu_Entities.Mapping
{
    public class KitapKayitHareketleriMap: EntityTypeConfiguration<KitapKayitHareketleri>
    {
        public KitapKayitHareketleriMap()
        {
            this.ToTable("KitapkayitHareketleri");//Table Adı
            this.HasKey(x => x.ID);//Primary Key
            this.Property(x => x.ID).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity); //Identity
            this.Property(x => x.KitapID).IsRequired();

            this.Property(x => x.ID).HasColumnName("id");//Database deki kolon adı
            this.Property(x => x.KitapID).HasColumnName("KitapID");

            this.Property(x => x.Tarih).HasColumnName("Tarih");
            this.HasRequired(x => x.Kitaplar).WithMany(x => x.KitapKayitHareketleri).HasForeignKey(x => x.KitapID);
        }
    }
}
