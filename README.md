# 📚 MVC Kütüphane Otomasyonu

ASP.NET MVC ve Entity Framework mimarisi üzerine inşa edilmiş, modern kütüphane operasyonlarını (kitap, üye, emanet/ödünç alma, ceza ve kategori yönetimi) tek bir çatı altında toplayan kapsamlı bir yönetim otomasyonudur.

---

## 🚀 Proje Hakkında

Bu proje, geleneksel kütüphane süreçlerini dijitalleştirmek ve veri tutarlılığını sağlamak amacıyla geliştirilmiştir. Çok katmanlı mimari prensiplerine uygun olarak veri erişim katmanı ve iş katmanı ayrılmış; ilişkisel veri tabanı tasarımı ile verimli bir CRUD altyapısı sunulmuştur.

### 🌟 Temel Özellikler

* **Kitap & Kategori Yönetimi:** Kitap ekleme, silme, düzenleme, stok ve kategori bazlı filtreleme/listeleme.
* **Üye Yönetimi:** Kütüphane üyelerinin kayıt altına alınması, iletişim bilgileri ve geçmiş işlem takibi.
* **Emanet / Ödünç Takibi:** Kitapların üyelere belirli sürelerle verilmesi, iade durumlarının izlenmesi.
* **Ceza & Gecikme Hesaplama:** Teslim tarihi geciken emanet kitaplar için dinamik gecikme süresi ve ceza tutarı kontrolü.
* **Yazar & Yayınevi Yönetimi:** Kitaplarla ilişkili yazar ve yayınevi bilgilerinin modüler kontrolü.
* **İstatistik ve Raporlama:** En çok okunan kitaplar, aktif üyeler ve anlık kütüphane envanter özeti.

---

## 🛠️ Kullanılan Teknolojiler

* **Framework:** ASP.NET MVC (.NET Framework)
* **ORM:** Entity Framework (Code First / Database First)
* **Veritabanı:** Microsoft SQL Server (T-SQL)
* **Frontend:** HTML5, CSS3, Bootstrap, JavaScript, jQuery
* **Tasarım & UI:** Responsive Admin Dashboard Şablonu

---

## 🏗️ Mimari Yapı

```text
MVC_Kutuphane_Otomasyonu/
│
├── MVC_Kutuphane_Otomasyonu/           # Web / UI ve Sunum Katmanı
│   ├── Controllers/                    # MVC Controller sınıfları
│   ├── Views/                          # Razor (.cshtml) arayüz şablonları
│   └── Web.config                      # Uygulama ve bağlantı yapılandırmaları
│
├── MVC_Kutuphane_Otomasyonu_Entities/  # Varlık (Entity) ve Model Katmanı
│   └── Model / Veritabanı Sınıfları    # Tablo varlıkları ve ilişki tanımları
│
└── packages/                           # NuGet paket bağımlılıkları
