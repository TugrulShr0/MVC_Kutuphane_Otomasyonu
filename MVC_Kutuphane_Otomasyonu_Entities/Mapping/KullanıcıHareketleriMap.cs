using MVC_Kutuphane_Otomasyonu_Entities.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Kutuphane_Otomasyonu_Entities.Mapping
{
    public class KullanıcıHareketleriMap:EntityTypeConfiguration<KullanıcıHareketleri>
    {
         public KullanıcıHareketleriMap()
        {
            this.ToTable("KullanıcıHareketleri");//Table Adı
            this.HasKey(x => x.ID);//Primary Key
            this.Property(x => x.ID).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity); //Identity
            this.Property(x => x.Aciklama).HasMaxLength(4000);

             this.HasRequired<Kullanicilar>(x => x.Kullanicilar).WithMany(x => x.KullanıcıHareketleri).HasForeignKey(x => x.KullanıcıID);
        }
    }
}
