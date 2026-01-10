# DbFirstSampleApi

Yapılması gerekenler
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
Mapping  
Fluent Validation  
Sql Script çalıştırma ile veritabanı kurulumu



