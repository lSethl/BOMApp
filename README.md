# BOMApp

**BOMApp**, elektronik üretim ve malzeme yönetimi süreçlerinde kullanılan **BOM (Bill of Materials)** listelerinin daha kolay yönetilebilmesi amacıyla geliştirilmiş bir Windows masaüstü uygulamasıdır.

Uygulama; Excel formatındaki BOM listelerinin sisteme aktarılması, malzemelerin kayıt altına alınması, miktar ve konum bilgilerinin yönetilmesi, ürün görsellerinin saklanması ve gerçekleştirilen işlemlerin takip edilmesi gibi temel ihtiyaçları tek bir masaüstü uygulaması üzerinden yönetmeyi amaçlamaktadır.

---

## 🎯 Projenin Amacı

BOM listelerinin yalnızca Excel dosyaları üzerinden takip edilmesi, özellikle malzeme sayısı arttıkça arama, stok takibi ve fiziksel konum yönetimini zorlaştırabilmektedir.

BOMApp ile bu sürecin daha düzenli hale getirilmesi hedeflenmiştir.

Uygulama sayesinde:

- Excel BOM listeleri sisteme aktarılabilir.
- Aynı malzeme tekrar geldiğinde mevcut kayıt güncellenebilir.
- Malzemeler farklı alanlar üzerinden aranabilir.
- Malzemelerin mevcut miktarları takip edilebilir.
- Kullanılan malzemelerin miktarları azaltılabilir.
- Malzemelerin fiziksel konum bilgileri saklanabilir.
- Ürünlere görsel atanabilir.
- Yapılan işlemler log sistemi üzerinden takip edilebilir.
- Uygulama verileri yerel SQLite veritabanında saklanabilir.
- Veritabanının otomatik yedekleri oluşturulabilir.

---

## 🛠️ Kullanılan Teknolojiler

BOMApp, **C# ve .NET ekosistemi** kullanılarak geliştirilmiştir.

| Teknoloji | Kullanım Amacı |
|---|---|
| **C#** | Uygulamanın ana programlama dili |
| **.NET 10** | Uygulama platformu |
| **Windows Forms** | Masaüstü kullanıcı arayüzü |
| **Entity Framework Core** | Veritabanı işlemleri ve veri erişimi |
| **SQLite** | Yerel veritabanı |
| **Dependency Injection** | Bağımlılıkların yönetimi |
| **Repository Pattern** | Veri erişim işlemlerinin ayrıştırılması |
| **Service Layer** | İş kurallarının yönetilmesi |
| **N-Katmanlı Mimari** | Uygulama sorumluluklarının katmanlara ayrılması |

---

## 🏗️ Proje Mimarisi

Proje, sorumlulukların birbirinden ayrılması amacıyla katmanlı bir yapı kullanılarak geliştirilmiştir.

```text
BOMProject.Entities
        │
        ▼
BOMProject.DataAccess
        │
        ▼
BOMProject.Business
        │
        ▼
bomApp (WinForms UI)
```

### Entities

Uygulamada kullanılan veri modellerini içerir.

### DataAccess

SQLite veritabanıyla gerçekleştirilen veri erişim işlemlerinden sorumludur.

Repository yapısı ve Entity Framework Core işlemleri bu katmanda bulunmaktadır.

### Business

Uygulamanın iş kurallarını ve servislerini içerir.

Kullanıcı arayüzü ile veri erişim katmanı arasındaki işlemler bu katman üzerinden yönetilir.

### Presentation — WinForms

Kullanıcının doğrudan etkileşim kurduğu masaüstü arayüzüdür.

Excel aktarımı, arama, güncelleme, miktar yönetimi, ürün görselleri ve log görüntüleme gibi işlemler buradan gerçekleştirilir.

---

## ✨ Temel Özellikler

### 📊 Excel BOM Import

Excel formatındaki BOM dosyaları uygulama üzerinden seçilerek sisteme aktarılabilir.

Mevcut bir malzemenin tekrar aktarılması durumunda yeni bir kayıt oluşturmak yerine ilgili malzemenin miktarı güncellenebilir.

### 🔎 Malzeme Arama

Veritabanındaki malzemeler uygulama içerisinden aranabilir ve ilgili kayıtlar hızlı şekilde görüntülenebilir.

### 📦 Miktar Yönetimi

Malzemelerin mevcut miktarları takip edilebilir ve kullanılan ürünlerin miktarları uygulama üzerinden azaltılabilir.

Miktarın sıfırın altına düşmesini engelleyen kontroller bulunmaktadır.

### 📍 Konum Yönetimi

Her malzeme için fiziksel konum bilgisi tutulabilir.

Böylece yalnızca ürünün sistemde bulunması değil, fiziksel olarak nerede bulunduğunun takip edilmesi de sağlanır.

### 🖼️ Ürün Görselleri

Malzemelere görsel atanabilir ve mevcut ürün görselleri değiştirilebilir.

Bir görsel değiştirildiğinde veya ürün silindiğinde eski görsel dosyalarının yönetimi de uygulama tarafından gerçekleştirilir.

### 📝 Log Sistemi

Gerçekleştirilen önemli işlemler kayıt altına alınır.

Log geçmişinde işlemler tarih ve saat bilgileriyle görüntülenebilir.

### 💾 Veritabanı ve Yedekleme

Uygulama **SQLite** kullanmaktadır.

Kullanıcı verileri uygulamanın çalıştırıldığı klasörden bağımsız olarak Windows kullanıcı profilinde saklanır.

Veritabanı için otomatik yedekleme mekanizması bulunmaktadır.

---

# 📥 Uygulamayı İndirme

BOMApp'ı kullanmak için kaynak kodu indirmenize veya Visual Studio kurmanıza gerek yoktur.

1. GitHub reposundaki **Releases** bölümünü açın.
2. En güncel BOMApp sürümünü seçin.
3. **Assets** bölümünü açın.
4. `BOMApp-v1.0.0-win-x64.zip` dosyasını indirin.
5. ZIP dosyasını bir klasöre çıkartın.
6. `bomApp.exe` dosyasını çalıştırın.

> **Önemli:** Uygulamayı ZIP dosyasının içerisinden doğrudan çalıştırmak yerine önce klasöre çıkartın.

---

## 💻 Sistem Gereksinimleri

- Windows 64-bit işletim sistemi
- x64 mimarisi

Dağıtım sürümü **Self-contained** olarak yayınlandığından kullanıcıların ayrıca .NET SDK veya Visual Studio kurmasına gerek yoktur.

---

## 📂 Verilerin Saklanması

Uygulama veritabanı Windows kullanıcı profilindeki yerel uygulama verileri altında saklanmaktadır.

```text
%LocalAppData%\BomApp
```

Bu yapı sayesinde uygulamanın çalıştırılabilir dosyaları ile kullanıcı verileri birbirinden ayrılmıştır.

Veritabanı, ürün görselleri ve oluşturulan yedekler bu yapı içerisinde yönetilmektedir.

---

## 🚀 Sürüm

### v1.0.0

BOMApp'ın ilk kararlı sürümüdür.

Bu sürüm;

- Excel BOM aktarımı
- Malzeme yönetimi
- Arama
- Miktar yönetimi
- Konum takibi
- Ürün görselleri
- Log sistemi
- SQLite veri saklama
- Otomatik yedekleme

özelliklerini içermektedir.

---

## 👨‍💻 Geliştirici

**Mert Akbıyık**

.NET / C# Backend Development
