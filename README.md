# DbFirstSampleApi

Bu proje, mimarisi Db First yaklaşımı ile geliştirilmiş bir Web API projesidir. Proje içerisinde Dapper kullanılarak MSSQL veritabanı ile etkileşim sağlanmıştır. Katmanlı mimari yapısı ile projenin sürdürülebilirliği ve genişletilebilirliği hedeflenmiştir.

Mimari Yapı
----------------------
- DataAccess katmanında Generic Repository deseni kullanılarak veri erişim işlemleri soyutlanmıştır. Bu sayede farklı veri kaynaklarına kolayca adapte olunabilir  
- Entities   katmanında veritabanı tablolarına karşılık gelen sınıflar yer almaktadır. AutoMapper kullanılarak veri transferi sırasında nesneler arasında kolayca dönüşüm sağlanmıştır  
- Services   katmanında https://fakestoreapi.com/products üzerinden ürün verileri çekilerek Products tablosuna eklenmesi ve veritabanındaki ürünlerle dış kaynaktan çekilen ürün listesi karşılaştırma işlemleri gerçekleştirilmiştir  
- Mapping    katmanında AutoMapper profilleri tanımlanmıştır  
- Filters    katmanında isteklerin doğrulanması için Fluent Validation kullanılmıştır  
- Sql Script klasöründe veritabanı tabloları ve prosedürlerin oluşturulması için gerekli SQL script dosyası bulunmaktadır  
- Utility    katmanında JWT Token oluşturma işlemi ve şifre hash değerinin hesaplanması gerçekleştirilmiştir  
- Response   katmanında API yanıt modeli tanımlanmıştır  

Nasıl çalıştırılır?
----------------------
1- MSSQL'de veritabanı yaratılır  
2- Connection string düzenlenir  
3- Swagger ile /api/Database tetiklenerek Sql Script\Init.sql script dosyası çalıştırılarak veritabanı tabloları ve prosedürler örnek veriler ile birlikte kurulur   
4- Swagger ile /api/Token demo kullanıcı ile tetiklenir  
5- Swagger ile /api/ExternalProduct/BulkInsertToDatabaseWithRandomPrice tetiklenerek test verisi fiyat bilgisi değiştirilerek Products tablosuna yazdırılır
6- Swagger ile /api/ExternalProduct/GetDifferentProducts ile veritabanındaki ürünlerle dış kaynaktan çekilen ürün listesi karşılaştırma raporu alınır

Token almak için
-----------------------
Kullanıcı adı  : demo  
Şifre          : demo  

Kullanılan Teknolojiler
-----------------------
C#  
Dapper  
MSSQL  

Kullanılan Teknikler
-----------------------
JWT Token  
Generic Repository  
Mapping (AutoMapper)  
Dependency Injection  
Fluent Validation  
Linq  
Sql Script çalıştırma ile veritabanı kurulumu
 



