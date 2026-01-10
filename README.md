# DbFirstSampleApi

$\color{red}{\underline{{kırmızı}}}$

_Özet_
----------------------
<p style="text-indent:1.5em">Bu proje, mimarisi Db First yaklaşımı ile geliştirilmiş bir Web API projesidir. Proje içerisinde Dapper kullanılarak MSSQL veritabanı ile etkileşim sağlanmıştır. Katmanlı mimari yapısı ile projenin sürdürülebilirliği ve genişletilebilirliği hedeflenmiştir.</p>

_Mimari Yapı_
----------------------
- <span style="color:purple;text-decoration:underline">DataAccess</span> katmanında Generic Repository deseni kullanılarak veri erişim işlemleri soyutlanmıştır. Bu sayede farklı veri kaynaklarına kolayca adapte olunabilir  
- <label style="color:purple;text-decoration:underline">Entities</label>   katmanında veritabanı tablolarına karşılık gelen sınıflar yer almaktadır. AutoMapper kullanılarak veri transferi sırasında nesneler arasında kolayca dönüşüm sağlanmıştır  
- <label style="color:purple;text-decoration:underline">Services</label>   katmanında https://fakestoreapi.com/products üzerinden ürün verileri çekilerek <label style="color:red;text-decoration:underline">Products</label> tablosuna eklenmesi ve veritabanındaki ürünlerle dış kaynaktan çekilen ürün listesi karşılaştırma işlemleri gerçekleştirilmiştir  
- <label style="color:purple;text-decoration:underline">Mapping</label>    katmanında AutoMapper profilleri tanımlanmıştır  
- <label style="color:purple;text-decoration:underline">Filters</label>    katmanında isteklerin doğrulanması için Fluent Validation kullanılmıştır  
- <label style="color:purple;text-decoration:underline">Sql Script</label> klasöründe veritabanı tabloları ve prosedürlerin oluşturulması için gerekli SQL script dosyası bulunmaktadır  
- <label style="color:purple;text-decoration:underline">Utility</label>    katmanında JWT Token oluşturma işlemi ve şifre hash değerinin hesaplanması gerçekleştirilmiştir  
- <label style="color:purple;text-decoration:underline">Response</label>   katmanında API yanıt modeli tanımlanmıştır  

_Nasıl çalıştırılır?_
-----------------------
1- <label style="color:orange;text-decoration:underline">MSSQL</label>'de veritabanı yaratılır  
2- <label style="color:olive;text-decoration:underline">Connection string</label> düzenlenir  
3- <label style="color:green;text-decoration:underline">Swagger</label> ile <label style="color:blue">/api/Database</label> tetiklenerek <label style="color:olive;text-decoration:underline">Sql Script\Init.sql</label> script dosyası çalıştırılarak veritabanı tabloları ve prosedürler örnek veriler ile birlikte kurulur   
4- <label style="color:green;text-decoration:underline">Swagger</label> ile <label style="color:blue">/api/Token</label> demo kullanıcı ile tetiklenir  
5- <label style="color:green;text-decoration:underline">Swagger</label> ile <label style="color:blue">/api/ExternalProduct/BulkInsertToDatabaseWithRandomPrice</label> tetiklenerek test verisi rastgele seçilen ürünlerin fiyat bilgisi değiştirilerek <label style="color:orange;text-decoration:underline">Products</label> tablosuna yazdırılır  
6- <label style="color:green;text-decoration:underline">Swagger</label> ile <label style="color:blue">/api/ExternalProduct/GetDifferentProducts</label> ile veritabanındaki ürünlerle dış kaynaktan çekilen ürün listesi karşılaştırma raporu alınır

_Token almak için_
-----------------------
*Kullanıcı adı*  : demo  
*Şifre*          : demo  

_Kullanılan Teknolojiler_
-----------------------
C#  
Dapper  
MSSQL  

_Kullanılan Teknikler_
-----------------------
JWT Token  
Generic Repository  
Mapping (AutoMapper)  
Dependency Injection  
Fluent Validation  
Linq  
Sql Script çalıştırma ile veritabanı kurulumu
 



