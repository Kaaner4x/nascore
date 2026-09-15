-- Nascore PostgreSQL Örnek Veri (Mock Data) Ekleme Scripti

INSERT INTO "News" ("Title", "ImageUrl", "PublishedDate", "Category", "Content") VALUES
('Yeni projeler ve sektörel gelişmeler hakkında önemli duyurular.', '/user-interface/images/blog/minimal-1.jpg', '2024-06-17 10:00:00', 'Tasarım', '<h2>Ana Başlık</h2><p>Bu haberin içeriğinde bazı <span style=''color:red;''>kırmızı kelimeler</span> var.</p><h3>Alt Başlık</h3><p>Devam eden metin...</p>'),
('Modern web ve tasarım trendlerinde öne çıkan yenilikler.', '/user-interface/images/blog/minimal-2.jpg', '2024-06-15 14:30:00', 'Teknoloji', '<p>Bu haber <strong>kalın yazılar</strong> ve <em>eğik yazılar</em> içeriyor.</p>');

INSERT INTO "Feature" ("Title", "Description") VALUES
('Modern Tasarım', 'Kullanıcı deneyimini merkeze alan, estetik ve işlevselliği buluşturan çağdaş arayüzler tasarlıyoruz.'),
('Temiz & Güçlü Kod', 'En güncel teknolojilerle geliştirilmiş, ölçeklenebilir, güvenli ve sürdürülebilir yazılım mimarileri kuruyoruz.'),
('Tam Uyumlu (Responsive)', 'Mobil, tablet ve masaüstü tüm ekranlarda kusursuz çalışan, yüksek hızlı ve duyarlı deneyimler sunuyoruz.');

INSERT INTO "ServiceItem" ("Title", "Description", "IconClass") VALUES
('Web Geliştirme', 'Hızlı, güvenli ve modern web uygulamaları ile markanızı dijital dünyada bir adım öne çıkarıyoruz.', 'ti-layout'),
('Dijital Pazarlama', 'Veriye dayalı stratejilerle hedef kitlenize doğrudan ulaşın, dönüşüm oranlarınızı ve marka bilinirliğinizi artırın.', 'ti-announcement'),
('Grafik & Görsel Tasarım', 'Markanızın karakterini yansıtan, akılda kalıcı ve etkileyici görsel kimlik unsurları oluşturuyoruz.', 'ti-layers');

INSERT INTO "Skill" ("Name", "Percentage") VALUES
('İş & Marka Stratejisi', 80),
('UI / UX & Arayüz Tasarımı', 90),
('Dijital Büyüme & Pazarlama', 75),
('Web & Yazılım Geliştirme', 85);

INSERT INTO "Testimonial" ("AuthorName", "AuthorRole", "Company", "AvatarUrl", "Stars", "Quote") VALUES
('Caner Yılmaz', 'Genel Müdür', 'Nova Teknoloji', '/user-interface/images/blog/author1.jpg', 5, 'Nascore ekibiyle çalışmak kurumsal dijital dönüşüm sürecimizde aldığımız en doğru karardı.'),
('Selin Aktaş', 'Pazarlama Direktörü', 'Apex Retail', '/user-interface/images/blog/author2.jpg', 5, 'İlk 3 ayda %65''lik somut bir ciro artışı yakaladık.'),
('Murat Demir', 'Kurucu Ortak', 'Finova Yazılım', '/user-interface/images/blog/author3.jpg', 5, 'Sadece bir ajans değil, gerçek bir teknoloji ortağı oldular.');

INSERT INTO "ProjectCategory" ("Name", "FilterValue") VALUES
('UI/UX Tasarım', 'design'),
('Marka Kimliği', 'branding'),
('Web Geliştirme', 'illustration'),
('Fotoğrafçılık', 'photo');

INSERT INTO "ProjectItem" ("Title", "SubTitle", "ImageUrl", "FilterGroups") VALUES
('Resim & Çizim', 'Tasarım', '/user-interface/images/portfolio/1.jpg', ARRAY['design', 'illustration']),
('Web Uygulaması', 'E-Ticaret', '/user-interface/images/portfolio/bag.jpg', ARRAY['branding']),
('Kurumsal', 'Pazarlama', '/user-interface/images/portfolio/3.jpg', ARRAY['illustration']),
('Portfolyo', 'Tasarım', '/user-interface/images/portfolio/m-3.jpg', ARRAY['design', 'branding']);

INSERT INTO "ContactMessage" ("Name", "Email", "Phone", "Subject", "Message", "IsKvkkAccepted", "CreatedAt") VALUES
('Ahmet Yılmaz', 'ahmet@nascore.com', '+905551234567', 'Proje Talebi', 'Merhaba, yeni e-ticaret sitemiz için fiyat teklifi almak istiyoruz.', true, CURRENT_TIMESTAMP);
