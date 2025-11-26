namespace MVC_Kutuphane_Otomasyonu_Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Duyurulars",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Baslik = c.String(),
                        Duyuru = c.String(),
                        Aciklama = c.String(),
                        Tarih = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.EmanetKitaplars",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UyeID = c.Int(nullable: false),
                        KitapID = c.Int(nullable: false),
                        KitapSayisi = c.Int(nullable: false),
                        EmanetTarihi = c.DateTime(nullable: false),
                        IadeTarihi = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Hakkimizdas",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Icerik = c.String(),
                        Aciklama = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.İletisim",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        AdSoyad = c.String(),
                        Email = c.String(),
                        Baslik = c.String(),
                        Mesaj = c.String(),
                        Aciklama = c.String(),
                        Tarih = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.KitapHareketleris",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        KullanıcıID = c.Int(nullable: false),
                        UyeID = c.Int(nullable: false),
                        KitapID = c.Int(nullable: false),
                        YapılanIslem = c.String(),
                        Aciklama = c.String(),
                        Tarih = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.KitapkayitHareketleris",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        KullanıcıID = c.Int(nullable: false),
                        KitapID = c.Int(nullable: false),
                        YapılanIslem = c.String(),
                        Aciklama = c.String(),
                        Tarih = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Kitaplars",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        BarkodNo = c.String(),
                        KitapTürüId = c.String(),
                        KitapAdı = c.String(),
                        Yazar = c.String(),
                        Yayinevi = c.String(),
                        SayfaSayisi = c.Int(nullable: false),
                        StokAdedi = c.Int(nullable: false),
                        Aciklama = c.String(),
                        EklenmeTarihi = c.DateTime(nullable: false),
                        GuncellenmeTarihi = c.DateTime(nullable: false),
                        SilindiMi = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.KitapTurleris",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        KitapTuru = c.String(),
                        Aciklama = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.KullanıcıHareketleri",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        KullanıcıID = c.Int(nullable: false),
                        Aciklama = c.String(),
                        Tarih = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.KullanıcıRolleri",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        KullanıcıID = c.Int(nullable: false),
                        RolId = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Kullanicilars",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        AdSoyad = c.String(),
                        KullanıcıAdı = c.String(),
                        Sifre = c.String(),
                        Telefon = c.String(),
                        Email = c.String(),
                        Adres = c.String(),
                        KayitTarihi = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Rollers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Rol = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Uyelers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        AdSoyad = c.String(),
                        Resim = c.String(),
                        Telefon = c.String(),
                        Email = c.String(),
                        Adres = c.String(),
                        OkuKitapSayisi = c.Int(nullable: false),
                        KayitTarihi = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Uyelers");
            DropTable("dbo.Rollers");
            DropTable("dbo.Kullanicilars");
            DropTable("dbo.KullanıcıRolleri");
            DropTable("dbo.KullanıcıHareketleri");
            DropTable("dbo.KitapTurleris");
            DropTable("dbo.Kitaplars");
            DropTable("dbo.KitapkayitHareketleris");
            DropTable("dbo.KitapHareketleris");
            DropTable("dbo.İletisim");
            DropTable("dbo.Hakkimizdas");
            DropTable("dbo.EmanetKitaplars");
            DropTable("dbo.Duyurulars");
        }
    }
}
