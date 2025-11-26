using MVC_Kutuphane_Otomasyonu_Entities.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Kutuphane_Otomasyonu_Entities.Mapping
{
    public class KitapHareketleriMap: EntityTypeConfiguration<KitapHareketleri>
    {
        public KitapHareketleriMap()
        {
            this.ToTable("KitapHareketleri");//Table Adı
            this.HasKey(x => x.ID);//Primary Key
            this.Property(x => x.ID).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity); //Identity
            this.Property(x => x.KitapID).IsRequired();
            
            this.Property(x => x.Aciklama).IsOptional().HasMaxLength(5000);
            this.Property(x => x.ID).HasColumnName("id");//Database deki kolon adı
            this.Property(x => x.KitapID).HasColumnName("KitapID");
  
            this.Property(x => x.Aciklama).HasColumnName("Aciklama");
            this.HasRequired(x => x.Kitaplar).WithMany(x => x.KitapHareketleri).HasForeignKey(x => x.KitapID);
        }
    }
}
