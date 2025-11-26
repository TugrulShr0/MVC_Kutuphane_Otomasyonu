using MVC_Kutuphane_Otomasyonu_Entities.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Kutuphane_Otomasyonu_Entities.Mapping
{
    public class KullanıcıRolleriMap: EntityTypeConfiguration<KullanıcıRolleri>
    {
        public KullanıcıRolleriMap()
        {
            this.ToTable("KullanıcıRolleri");//Table Adı
            this.HasKey(x => x.ID);//Primary Key
            this.Property(x => x.ID).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity); //Identity
            //this.Property(x => x.RolId).IsRequired().HasMaxLength(100);

            this.HasRequired<Kullanicilar>(x => x.Kullanicilar).WithMany(x => x.KullanıcıRolleri).HasForeignKey(x => x.KullanıcıID);
            this.HasRequired<Roller>(x => x.Roller).WithMany(x => x.KullanıcıRolleri).HasForeignKey(x => x.RolId);
        }
    }
}
