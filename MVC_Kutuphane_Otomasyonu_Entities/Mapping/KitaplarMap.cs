using MVC_Kutuphane_Otomasyonu_Entities.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Kutuphane_Otomasyonu_Entities.Mapping
{
    public class KitaplarMap:EntityTypeConfiguration<Kitaplar>
    {
        public KitaplarMap()
        {
            this.ToTable("Kitaplar");//Table Adı
            this.HasKey(x => x.ID);
            this.Property(x => x.ID).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity); //Identity  
            this.Property(x => x.BarkodNo).IsRequired().HasMaxLength(200);
            this.Property(x => x.KitapAdı).IsRequired().HasMaxLength(500);  
            this.Property(x => x.Yazar).IsRequired().HasMaxLength(300);
            this.Property(x => x.Yayinevi).IsRequired().HasMaxLength(300);
            this.Property(x => x.Aciklama).HasMaxLength(5000);

            this.HasRequired(x => x.KitapTurleri).WithMany(x => x.Kitaplar).HasForeignKey(x => x.KitapTürüId);

        }
    }
}
