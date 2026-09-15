-- Nascore PostgreSQL Zengin Örnek Veri (Rich Mock Data) Ekleme Scripti

-- Eski verilerin üzerine yazmak yerine, test verilerini önce temizleyelim ki çift kayıt (duplicate) oluşmasın
TRUNCATE TABLE "News", "Feature", "ServiceItem", "Skill", "Testimonial", "ProjectCategory", "ProjectItem", "ContactMessage" RESTART IDENTITY;

-- HABERLER (15 Adet)
INSERT INTO "News" ("Title", "ImageUrl", "PublishedDate", "Category", "Content") VALUES
('Yeni projeler ve sektörel gelişmeler hakkında önemli duyurular.', '/user-interface/images/blog/minimal-1.jpg', '2024-06-17 10:00:00', 'Tasarım', '<h2>Ana Başlık</h2><p>Modern arayüz tasarımlarında dikkat etmeniz gereken <span style=''color:red;''>kritik</span> noktalar.</p>'),
('Modern web ve tasarım trendlerinde öne çıkan yenilikler.', '/user-interface/images/blog/minimal-2.jpg', '2024-06-15 14:30:00', 'Teknoloji', '<p>Bu yılın en popüler <strong>kodlama dilleri</strong> ve <em>geliştirme araçları</em>.</p>'),
('Kullanıcı deneyimi odaklı arayüz tasarımı çözümleri.', '/user-interface/images/blog/minimal-3.jpg', '2024-06-10 11:15:00', 'UX / UI', '<p>Etkili bir UX araştırması nasıl yapılır?</p>'),
('Geliştirme süreçlerinde verimliliği artıran yeni yaklaşımlar.', '/user-interface/images/blog/minimal-4.jpg', '2024-06-05 09:45:00', 'Yazılım', '<p>Çevik (Agile) geliştirme modelleri ile proje teslimatlarınızı hızlandırın.</p>'),
('Sektörde çığır açan yeni tasarım ilkeleri.', '/user-interface/images/blog/s-1.jpg', '2024-05-28 16:20:00', 'Tasarım', '<p>Minimalizmin gücünü keşfedin.</p>'),
('Dijital dönüşümde dikkat edilmesi gerekenler.', '/user-interface/images/blog/s-2.jpg', '2024-05-25 10:30:00', 'İş Dünyası', '<p>Şirketlerin dijital dönüşüm süreçlerinde en sık yaptığı hatalar.</p>'),
('Etkili kullanıcı deneyimi için kritik ipuçları.', '/user-interface/images/blog/s-1.jpg', '2024-05-18 13:00:00', 'UX / UI', '<p>Müşteriyi elde tutmanın yolu iyi bir deneyimden geçer.</p>'),
('2026 web geliştirme trendleri ve yenilikler.', '/user-interface/images/blog/s-2.jpg', '2024-05-10 09:00:00', 'Yazılım', '<p>Gelecek yıl bizi web dünyasında neler bekliyor?</p>'),
('Yapay zeka araçlarının kreatif süreçlere etkisi.', '/user-interface/images/blog/01.jpg', '2024-05-05 14:10:00', 'Yapay Zeka', '<p>ChatGPT, Midjourney ve diğer AI araçları tasarım dünyasını nasıl dönüştürüyor?</p>'),
('Büyük veri (Big Data) analitiği ile pazar araştırması.', '/user-interface/images/blog/02.jpg', '2024-04-22 11:30:00', 'Veri Bilimi', '<p>Doğru kararlar almak için veriyi nasıl anlamlandırmalıyız?</p>'),
('E-Ticaret sitelerinde dönüşüm oranını artırma taktikleri.', '/user-interface/images/blog/03.jpg', '2024-04-15 15:45:00', 'E-Ticaret', '<p>Sepeti terk etme oranlarını düşürmek için 10 harika ipucu.</p>'),
('Mobil uygulama geliştirirken dikkat edilmesi gerekenler.', '/user-interface/images/blog/minimal-1.jpg', '2024-04-02 09:20:00', 'Mobil', '<p>iOS ve Android dünyasında başarılı bir uygulama yayınlamanın sırları.</p>'),
('Kripto paralar ve blokzincir teknolojisinin geleceği.', '/user-interface/images/blog/minimal-2.jpg', '2024-03-20 16:00:00', 'Blokzincir', '<p>Web3 dünyası nereye evriliyor?</p>'),
('Kurumsal SEO stratejileri ile organik trafiğinizi uçurun.', '/user-interface/images/blog/minimal-3.jpg', '2024-03-10 10:15:00', 'SEO', '<p>Google algoritmalarına uyumlu içerik üretim rehberi.</p>'),
('Uzaktan çalışma (Remote Work) kültürünü yönetmek.', '/user-interface/images/blog/minimal-4.jpg', '2024-03-01 13:45:00', 'İnsan Kaynakları', '<p>Ekiplerin verimliliğini uzaktan nasıl sağlayabilirsiniz?</p>');

-- ÖZELLİKLER (6 Adet)
INSERT INTO "Feature" ("Title", "Description") VALUES
('Modern Tasarım', 'Kullanıcı deneyimini merkeze alan, estetik ve işlevselliği buluşturan çağdaş arayüzler tasarlıyoruz.'),
('Temiz & Güçlü Kod', 'En güncel teknolojilerle geliştirilmiş, ölçeklenebilir, güvenli ve sürdürülebilir yazılım mimarileri kuruyoruz.'),
('Tam Uyumlu (Responsive)', 'Mobil, tablet ve masaüstü tüm ekranlarda kusursuz çalışan, yüksek hızlı ve duyarlı deneyimler sunuyoruz.'),
('SEO Optimizasyonu', 'Arama motorlarında üst sıralara çıkmanızı sağlayacak altyapı kodlamaları gerçekleştiriyoruz.'),
('Yüksek Performans', 'Milisaniyeler içinde yüklenen sayfalar ile kullanıcı kaybını en aza indiriyoruz.'),
('7/24 Kesintisiz Destek', 'Proje tesliminden sonra da yanınızdayız. Gelişim süreçlerinize sürekli destek sağlıyoruz.');

-- HİZMETLER (8 Adet)
INSERT INTO "ServiceItem" ("Title", "Description", "IconClass") VALUES
('Web Geliştirme', 'Hızlı, güvenli ve modern web uygulamaları ile markanızı dijital dünyada bir adım öne çıkarıyoruz.', 'ti-layout'),
('Dijital Pazarlama', 'Veriye dayalı stratejilerle hedef kitlenize doğrudan ulaşın, dönüşüm oranlarınızı ve marka bilinirliğinizi artırın.', 'ti-announcement'),
('Grafik & Görsel Tasarım', 'Markanızın karakterini yansıtan, akılda kalıcı ve etkileyici görsel kimlik unsurları oluşturuyoruz.', 'ti-layers'),
('Marka Kimliği (Branding)', 'Logo tasarımından kurumsal kimlik rehberine kadar markanızı benzersiz kılacak bütünsel çözümler sunuyoruz.', 'ti-bookmark'),
('Video & Prodüksiyon', 'Marka hikayenizi etkili animasyonlar ve dinamik video içeriklerle görsel bir şölene dönüştürüyoruz.', 'ti-video-camera'),
('Mobil & Uygulama Tasarımı', 'Kullanıcı alışkanlıklarına odaklanan, modern ve akıcı mobil arayüz (UI/UX) deneyimleri inşa ediyoruz.', 'ti-mobile'),
('E-Ticaret Danışmanlığı', 'Satışlarınızı roketleyecek, güvenli ödeme altyapısına sahip mağazalar kuruyoruz.', 'ti-shopping-cart'),
('Bulut Bilişim & DevOps', 'Uygulamalarınızın kesintisiz ve yüksek performansla çalışması için profesyonel sunucu mimarileri kuruyoruz.', 'ti-cloud-up');

-- YETENEKLER (6 Adet)
INSERT INTO "Skill" ("Name", "Percentage") VALUES
('İş & Marka Stratejisi', 85),
('UI / UX & Arayüz Tasarımı', 95),
('Dijital Büyüme & Pazarlama', 80),
('Web & Yazılım Geliştirme', 98),
('Mobil Uygulama (iOS/Android)', 88),
('Arama Motoru Optimizasyonu (SEO)', 92);

-- MÜŞTERİ YORUMLARI (10 Adet)
INSERT INTO "Testimonial" ("AuthorName", "AuthorRole", "Company", "AvatarUrl", "Stars", "Quote") VALUES
('Caner Yılmaz', 'Genel Müdür', 'Nova Teknoloji', '/user-interface/images/blog/author1.jpg', 5, 'Nascore ekibiyle çalışmak kurumsal dijital dönüşüm sürecimizde aldığımız en doğru karardı. Hem kullanıcı deneyimi odaklı yaklaşımları hem de teslimat hızları beklentilerimizin çok ötesindeydi.'),
('Selin Aktaş', 'Pazarlama Direktörü', 'Apex Retail', '/user-interface/images/blog/author2.jpg', 5, 'Marka kimliğimizin ve e-ticaret altyapımızın yenilenmesinde gösterdikleri titizlik ve teknik uzmanlık sayesinde ilk 3 ayda %65''lik somut bir ciro artışı yakaladık.'),
('Murat Demir', 'Kurucu Ortak', 'Finova Yazılım', '/user-interface/images/blog/author3.jpg', 5, 'Sadece bir ajans değil, projenin her aşamasında bizimle aynı heyecanı paylaşan gerçek bir teknoloji ortağı oldular. Satış sonrası 7/24 kesintisiz destek için minnettarız.'),
('Ayşe Yılmaz', 'Ürün Yöneticisi', 'Global Medya', '/user-interface/images/profile.jpg', 4, 'Tasarım vizyonumuzu tam olarak anlayıp beklentilerimizin bile ötesinde bir görsel estetik sundular.'),
('Burak Eren', 'CTO', 'LogiTech Global', '/user-interface/images/profile.jpg', 5, 'Geliştirdikleri yüksek performanslı web arayüzü ve modern kod mimarisi sayesinde sayfa açılış hızlarımız iki katına çıktı. Ekibin profesyonelliği takdire şayan.'),
('Ece Soylu', 'Kreatif Direktör', 'Studio Pulse', '/user-interface/images/profile.jpg', 5, 'Markamızın prestijini bambaşka bir seviyeye taşıdılar. Artık rakiplerimizden çok daha öndeyiz.'),
('Kemal Tekin', 'CEO', 'Tekin İnşaat', '/user-interface/images/blog/author1.jpg', 4, 'Sektörümüzü o kadar iyi analiz ettiler ki, bize sundukları kurumsal kimlik nokta atışı oldu.'),
('Zeynep Arslan', 'İnsan Kaynakları', 'İK Plus', '/user-interface/images/blog/author2.jpg', 5, 'Hazırladıkları işe alım portali o kadar sezgisel oldu ki, başvuru oranlarımız %40 arttı.'),
('Oğuzhan Mert', 'E-Ticaret Müdürü', 'Trend Giyim', '/user-interface/images/blog/author3.jpg', 5, 'Mobil uyumluluk konusunda mükemmel bir iş çıkardılar. Ciromuzun çoğu artık mobilden geliyor.'),
('Merve Çelik', 'Girişimci', 'EcoLife', '/user-interface/images/profile.jpg', 5, 'Sıfırdan kurduğum markamı kendi markaları gibi benimsediler ve harika bir iş çıkardılar.');

-- PROJE KATEGORİLERİ
INSERT INTO "ProjectCategory" ("Name", "FilterValue") VALUES
('UI/UX Tasarım', 'design'),
('Marka Kimliği', 'branding'),
('Web Geliştirme', 'illustration'),
('Fotoğrafçılık', 'photo'),
('Mobil Uygulama', 'mobile'),
('3D Modelleme', '3d');

-- PROJELER (15 Adet)
INSERT INTO "ProjectItem" ("Title", "SubTitle", "ImageUrl", "FilterGroups") VALUES
('Resim & Çizim', 'Tasarım', '/user-interface/images/portfolio/1.jpg', ARRAY['design', 'illustration']),
('Web Uygulaması', 'E-Ticaret', '/user-interface/images/portfolio/bag.jpg', ARRAY['branding', 'illustration']),
('Kurumsal', 'Pazarlama', '/user-interface/images/portfolio/3.jpg', ARRAY['illustration']),
('Portfolyo', 'Tasarım', '/user-interface/images/portfolio/m-3.jpg', ARRAY['design', 'branding']),
('Modern Web', 'SEO', '/user-interface/images/portfolio/bottle.jpg', ARRAY['illustration', 'design']),
('Ajans Web', 'Tasarım', '/user-interface/images/portfolio/6.jpg', ARRAY['design', 'photo']),
('E-Ticaret Paneli', 'Web Geliştirme', '/user-interface/images/portfolio/1.jpg', ARRAY['illustration', 'mobile']),
('Mobil Bankacılık', 'UI/UX', '/user-interface/images/portfolio/3.jpg', ARRAY['design', 'mobile']),
('Kafe Menü Uygulaması', 'Mobil', '/user-interface/images/portfolio/m-3.jpg', ARRAY['mobile']),
('Kurumsal Kimlik Çalışması', 'Branding', '/user-interface/images/portfolio/bag.jpg', ARRAY['branding', 'photo']),
('Ürün Çekimi', 'Fotoğrafçılık', '/user-interface/images/portfolio/6.jpg', ARRAY['photo']),
('Mimari Render', '3D Tasarım', '/user-interface/images/portfolio/1.jpg', ARRAY['3d', 'design']),
('Oyun Arayüzü', 'UI/UX', '/user-interface/images/portfolio/3.jpg', ARRAY['design', 'illustration', '3d']),
('Spor Salonu Otomasyonu', 'Web', '/user-interface/images/portfolio/bottle.jpg', ARRAY['illustration', 'mobile']),
('Kahve Markası Logosu', 'Marka Kimliği', '/user-interface/images/portfolio/m-3.jpg', ARRAY['branding', 'design']);

-- İLETİŞİM MESAJLARI (10 Adet)
INSERT INTO "ContactMessage" ("Name", "Email", "Phone", "Subject", "Message", "IsKvkkAccepted", "CreatedAt") VALUES
('Ahmet Yılmaz', 'ahmet@nascore.com', '+905551234567', 'Proje Talebi', 'Merhaba, yeni e-ticaret sitemiz için fiyat teklifi almak istiyoruz.', true, CURRENT_TIMESTAMP - INTERVAL '10 days'),
('Mehmet Demir', 'mehmet.demir@gmail.com', '+905329876543', 'İş Başvurusu', 'Web geliştirici pozisyonu için CV''mi nereden iletebilirim?', true, CURRENT_TIMESTAMP - INTERVAL '9 days'),
('Ayşe Kaya', 'ayse.kaya@holding.com.tr', '+905441112233', 'Kurumsal Kimlik Yenileme', 'Şirketimizin 20. yılına özel logomuzu ve kurumsal kimliğimizi yenilemek istiyoruz.', true, CURRENT_TIMESTAMP - INTERVAL '8 days'),
('Fatma Şahin', 'fatma@startup.com', '+905305556677', 'Mobil Uygulama', 'Yeni girişimimiz için bir mobil uygulama yazdırmak istiyoruz. Bütçe görüşebilir miyiz?', true, CURRENT_TIMESTAMP - INTERVAL '7 days'),
('Ali Vefa', 'ali.vefa@hastane.com', '+905332224455', 'Randevu Sistemi', 'Özel hastanemiz için online randevu sistemi yaptırmak istiyoruz.', true, CURRENT_TIMESTAMP - INTERVAL '6 days'),
('Canan Karaca', 'canan.k@moda.net', '', 'SEO Danışmanlığı', 'Web sitemizin Google sıralamaları çok düşük, SEO hizmeti veriyor musunuz?', true, CURRENT_TIMESTAMP - INTERVAL '5 days'),
('Hakan Yurt', 'hakan@lojistik.com', '+905417778899', 'B2B Portal', 'Bayilerimiz için özel bir B2B sipariş portalı kurmak istiyoruz.', true, CURRENT_TIMESTAMP - INTERVAL '4 days'),
('Elif Nur', 'elif.n@ajans.com', '', 'Freelance Destek', 'Yoğunluktan dolayı projelerimizin bir kısmını size outsource edebilir miyiz?', true, CURRENT_TIMESTAMP - INTERVAL '3 days'),
('Cem Yıldız', 'cem@oyun.com', '+905051239876', '3D Modelleme', 'Geliştirdiğimiz mobil oyun için 3D karakter modellemesi desteğine ihtiyacımız var.', true, CURRENT_TIMESTAMP - INTERVAL '2 days'),
('Deniz Ak",', 'deniz@akdeniz.com.tr', '+905321110000', 'Teşekkür', 'Yaptığınız web sitesi harika oldu, tüm ekibinize teşekkürler!', true, CURRENT_TIMESTAMP - INTERVAL '1 day');

TRUNCATE TABLE "SiteSetting" RESTART IDENTITY CASCADE;
TRUNCATE TABLE "MenuItem" RESTART IDENTITY CASCADE;

INSERT INTO "SiteSetting" ("Key", "Value") VALUES
('ContactEmail', 'merhaba@nascore.com'),
('ContactPhone', '+90 (212) 555 00 00'),
('ContactAddress', 'Nascore Plaza, Maslak Mah. No:1, Şişli/İstanbul'),
('ContactMapEmbed', 'https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3007.458763567156!2d29.020352515416246!3d41.10904097929007!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x14cab5dd5345a909%3A0xc3c9a0c1071d79bc!2sMaslak%2C%20Sar%C4%B1yer%2F%C4%B0stanbul!5e0!3m2!1str!2str!4v1619864275000!5m2!1str!2str'),
('FacebookUrl', 'https://facebook.com/nascore'),
('TwitterUrl', 'https://twitter.com/nascore'),
('InstagramUrl', 'https://instagram.com/nascore'),
('LinkedInUrl', 'https://linkedin.com/company/nascore');

INSERT INTO "MenuItem" ("Title", "Url", "DisplayOrder", "IsActive", "Position") VALUES
('Ana Sayfa', '/', 1, TRUE, 'Header'),
('Hakkımızda', '/About', 2, TRUE, 'Header'),
('Projelerimiz', '/Project', 3, TRUE, 'Header'),
('İletişim', '/Contact', 4, TRUE, 'Header');
