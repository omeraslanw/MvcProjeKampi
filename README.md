# MVC Sözlük Uygulaması

<p align="center">
  <img src="https://img.shields.io/badge/ASP.NET-5C2D91?style=for-the-badge&logo=.net&logoColor=white" alt="ASP.NET">
  <img src="https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white" alt="C#">
  <img src="https://img.shields.io/badge/MVC_5-0078D4?style=for-the-badge" alt="MVC 5">
  <img src="https://img.shields.io/badge/MS%20SQL%20Server-CC2927?style=for-the-badge&logo=microsoft-sql-server&logoColor=white" alt="MS SQL Server">
</p>

## Açıklama

Bu proje, Ekşi Sözlük benzeri bir yapıda, kullanıcıların çeşitli başlıklar altına yorum (entry) girebildiği, interaktif bir sözlük platformudur. ASP.NET MVC 5 teknolojisi kullanılarak geliştirilmiştir. Proje, hem kullanıcıların içerik üretebildiği bir ön yüze (frontend) hem de sitenin yönetiminin yapıldığı bir admin paneline sahiptir.

## Uygulama Özellikleri

### Kullanıcı Özellikleri
- **Üyelik Sistemi:** Kullanıcı kaydı, girişi ve profil yönetimi.
- **Başlık Yönetimi:** Yeni başlık açma, mevcut başlıkları arama ve listeleme.
- **Entry Yönetimi:** Başlıklar altına yeni entry girme, kendi entry'lerini düzenleme.
- **Mesajlaşma:** Adminler ve diğer kullanıcılar ile mesajlaşma .
- **Sayfalama:** Başlıklardaki entry'lerin sayfalar halinde gösterimi.

### Admin Paneli Özellikleri
- **Kullanıcı Yönetimi:** Üyeleri listeleme, rol atama (admin/yazar), kullanıcı engelleme.
- **İçerik Yönetimi:** Başlıkları veya entry'leri silme, uygunsuz içeriği denetleme.
- **Kategori Yönetimi:** Başlıkları kategorize etmek için kategori ekleme/silme/düzenleme.
- **Dashboard:** Siteyle ilgili temel istatistikleri (toplam yazar, başlık, entry sayısı vb.) görüntüleme.
- **Mesajlaşma:** Adminler ve diğer kullanıcılar ile mesajlaşma .

## Kullanılan Teknolojiler

- **Web Çatısı:** ASP.NET MVC 5
- **Programlama Dili:** C#
- **Veritabanı:** Microsoft SQL Server
- **ORM:** Entity Framework 6 (Code First veya Database First)
- **Ön Yüz (Frontend):** HTML5, CSS3, JavaScript, jQuery, Bootstrap
- **Geliştirme Ortamı:** Visual Studio 2019/2022

## Kurulum Anlatımı

Projeyi yerel makinenizde çalıştırmak için aşağıdaki adımları izleyin.

### Ön Gereksinimler

- **Visual Studio 2019/2022:** "ASP.NET and web development" iş yükünün (workload) kurulu olduğundan emin olun.
- **.NET Framework:** 4.7.2 veya üstü (Genellikle Visual Studio ile gelir).
- **Microsoft SQL Server:** Express, Developer veya tam sürüm.

### Kurulum Adımları

1.  **Projeyi Klonlayın veya İndirin:**
    ```sh
    git clone https://github.com/omeraslanw/MvcProjeKampi.git
    ```

2.  **Veritabanını Oluşturun:**
    * **Yöntem A: SQL Script ile**
        1.  Proje içerisindeki `Database` veya `SQL_Scripts` klasöründe bulunan `.sql` dosyasını Microsoft SQL Server Management Studio (SSMS) ile açın.
        2.  Script'i çalıştırarak veritabanını ve tabloları oluşturun.
    * **Yöntem B: Entity Framework Code First Migrations ile**
        1.  Visual Studio'da `Araçlar > NuGet Paket Yöneticisi > Paket Yöneticisi Konsolu` yolunu izleyerek konsolu açın.
        2.  `Update-Database` komutunu çalıştırın. Bu komut, veritabanını migration dosyalarına göre oluşturacaktır.

3.  **Bağlantı Dizesini (Connection String) Yapılandırın:**
    1.  Solution Explorer'da projenin ana dizinindeki `Web.config` dosyasını açın.
    2.  `<connectionStrings>` bölümündeki bağlantı dizesini kendi SQL Server bilgilerinize göre güncelleyin.
        ```xml
        <connectionStrings>
          <add name="YourDbContextName" 
               connectionString="Data Source=SUNUCU_ADINIZ;Initial Catalog=SozlukDb;Integrated Security=True;" 
               providerName="System.Data.SqlClient" />
        </connectionStrings>
        ```
        -   `SUNUCU_ADINIZ`: Kendi SQL Server sunucu adınız (örn: `.` veya `DESKTOP-ABC\SQLEXPRESS`).
        -   `SozlukDb`: Oluşturduğunuz veritabanının adı.

4.  **Projeyi Çalıştırın:**
    1.  Visual Studio'da projeyi (`.sln` dosyası) açın ve gerekli NuGet paketlerinin geri yüklendiğinden emin olun (Restore NuGet Packages).
    2.  Projeyi derleyin (`Build > Build Solution`).
    3.  Visual Studio'da Projeyi `IIS Express` ile başlatmak için `Start` (Yeşil ok) butonuna basın. Proje varsayılan tarayıcınızda açılacaktır.

## Uygulama Görselleri

![Kategoriler](https://github.com/omeraslanw/MvcProjeKampi/blob/master/Proje/Ekran%20g%C3%B6r%C3%BCnt%C3%BCs%C3%BC%202024-03-13%20000306.png)
![Kategori Ekeleme](https://github.com/omeraslanw/MvcProjeKampi/blob/master/Proje/Ekran%20g%C3%B6r%C3%BCnt%C3%BCs%C3%BC%202024-03-13%20000347.png)
![Başlıklar](https://github.com/omeraslanw/MvcProjeKampi/blob/master/Proje/Ekran%20g%C3%B6r%C3%BCnt%C3%BCs%C3%BC%202024-03-13%20000439.png)
![Başlık Yorumları](https://github.com/omeraslanw/MvcProjeKampi/blob/master/Proje/Ekran%20g%C3%B6r%C3%BCnt%C3%BCs%C3%BC%202024-03-13%20000518.png)
![Başlık Güncelleme](https://github.com/omeraslanw/MvcProjeKampi/blob/master/Proje/Ekran%20g%C3%B6r%C3%BCnt%C3%BCs%C3%BC%202024-03-13%20000546.png)
![Başlık Ekleme](https://github.com/omeraslanw/MvcProjeKampi/blob/master/Proje/Ekran%20g%C3%B6r%C3%BCnt%C3%BCs%C3%BC%202024-03-13%20000657.png)
![Yazarlar](https://github.com/omeraslanw/MvcProjeKampi/blob/master/Proje/Ekran%20g%C3%B6r%C3%BCnt%C3%BCs%C3%BC%202024-03-13%20001419.png)
![Yazar Güncelleme](https://github.com/omeraslanw/MvcProjeKampi/blob/master/Proje/Ekran%20g%C3%B6r%C3%BCnt%C3%BCs%C3%BC%202024-03-13%20001459.png)
![Hakkımda](https://github.com/omeraslanw/MvcProjeKampi/blob/master/Proje/Ekran%20g%C3%B6r%C3%BCnt%C3%BCs%C3%BC%202024-03-13%20001604.png)
![İletişim Sayfası](https://github.com/omeraslanw/MvcProjeKampi/blob/master/Proje/Ekran%20g%C3%B6r%C3%BCnt%C3%BCs%C3%BC%202024-03-13%20001710.png)
![Gelen Kutusu](https://github.com/omeraslanw/MvcProjeKampi/blob/master/Proje/Ekran%20g%C3%B6r%C3%BCnt%C3%BCs%C3%BC%202024-03-13%20001758.png?raw=true)
![Gelen Mesaj Detayları](https://github.com/omeraslanw/MvcProjeKampi/blob/master/Proje/Ekran%20g%C3%B6r%C3%BCnt%C3%BCs%C3%BC%202024-03-13%20001816.png?raw=true)
![Sözlük Galerisi](https://github.com/omeraslanw/MvcProjeKampi/blob/master/Proje/Ekran%20g%C3%B6r%C3%BCnt%C3%BCs%C3%BC%202024-03-13%20001816.png?raw=true)
![Resim Detayı](https://github.com/omeraslanw/MvcProjeKampi/blob/master/Proje/Ekran%20g%C3%B6r%C3%BCnt%C3%BCs%C3%BC%202024-03-13%20002013.png?raw=true)
![404](https://github.com/omeraslanw/MvcProjeKampi/blob/master/Proje/Ekran%20g%C3%B6r%C3%BCnt%C3%BCs%C3%BC%202024-03-13%20002036.png?raw=true)
![SQL](https://github.com/omeraslanw/MvcProjeKampi/blob/master/Proje/Ekran%20g%C3%B6r%C3%BCnt%C3%BCs%C3%BC%202024-03-13%20002459.png?raw=true)
![Admin](https://github.com/omeraslanw/MvcProjeKampi/blob/master/Proje/admingiris.png)
![Yazar](https://github.com/omeraslanw/MvcProjeKampi/blob/master/Proje/yazargirisi.png)
![raporlama](https://github.com/omeraslanw/MvcProjeKampi/blob/master/Proje/raporlama.png)
![landingpage](https://github.com/omeraslanw/MvcProjeKampi/blob/master/Proje/landingpage.png)
![yetkilendirme](https://github.com/omeraslanw/MvcProjeKampi/blob/master/Proje/yetkilendirme.png)
