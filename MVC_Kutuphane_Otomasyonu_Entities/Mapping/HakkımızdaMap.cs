using MVC_Kutuphane_Otomasyonu_Entities.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Kutuphane_Otomasyonu_Entities.Mapping
{
    public class HakkımızdaMap: EntityTypeConfiguration<Hakkimizda>
    {
        public HakkımızdaMap()
        {
            this.ToTable("Hakkimizda");//Table Adı
            this.HasKey(x => x.ID);//Primary Key
            this.Property(x => x.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity); //Identity
            this.Property(x => x.Icerik).IsRequired().HasMaxLength(5000);
            this.Property(x => x.Aciklama).IsRequired().HasMaxLength(5000);

        }
    }
}
