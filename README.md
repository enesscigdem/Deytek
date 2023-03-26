# Deytek Proje Açıklaması 

Bir kullanıcı paneli geliştirildi ve bu panel aracılığıyla kullanıcıların isim, e-posta, kullanıcı adı, parola ve profil resmi gibi
bilgileri kaydedilip, bir tabloda listelenebiliyor. Ayrıca, bu panelde silme ve güncelleme işlevleri de mevcut. Projenin geliştirilmesinde 
.NET Core 7.0 kullanıldı, veritabanı olarak ise Azure Data Studio tercih edilmiştir.

Proje Katmanlı Mimari tasarım deseni ile geliştirilmiştir. EntityLayer, DataAccessLayer, UI ve BusinessLayer katmanları bu mimari tasarımın 
bir parçasıdır. 

Ayrıca projede identity kullanılmıştır. Ekstra olarak kullanılmıştır.

Projenin test aşamasında, XUnit testi kullanılmıştır. Testler, sadece user controller için yapılmıştır. Bu testler, uygulamanın doğru bir
şekilde çalıştığından emin olmak için geliştirilmiştir.

Projenin arayüz tasarımı, css kullanılarak gerçekleştirilmiştir. Bir tema paneli kullanılarak proje daha şık ve kullanıcı dostu bir hale getirilmiştir.

Veritabanı dosyası sizde çalışmassa, projedeki DataAccessLayer içinde Concrete klasörü altındaki Contex.cs sınıfındaki veritabanı adresini 
sizin adresiniz ile değiştirip, migration ile veritabanını oluşturabilirsiniz. 
