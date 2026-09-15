using Microsoft.AspNetCore.Mvc;
using Nascore.Models;
using Nascore.ViewModels;
using System.Collections.Generic;

namespace Nascore.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            var model = new AboutViewModel
            {
                // Banner
                BannerTitlePart1 = "İş ortaklarımız için",
                BannerTitlePart2 = "inşa ediyoruz",
                BannerDynamicWords = new List<string> { "marka kimliği", "tasarım çözümleri", "dijital stratejiler" },
                BannerDescription = "Modern web standartlarına tam uyumlu, estetik ve yüksek performanslı dijital deneyimler geliştiriyoruz. <strong>Nascore</strong> olarak, işletmenizin kurumsal vizyonunu yenilikçi teknolojiler ve yaratıcı tasarım disipliniyle geleceğe taşıyoruz.",
                BannerFeatures = new List<Feature>
                {
                    new Feature { Id = 1, Title = "Modern Tasarım", Description = "Kullanıcı deneyimini merkeze alan, estetik ve işlevselliği buluşturan çağdaş arayüzler tasarlıyoruz." },
                    new Feature { Id = 2, Title = "Temiz & Güçlü Kod", Description = "En güncel teknolojilerle geliştirilmiş, ölçeklenebilir, güvenli ve sürdürülebilir yazılım mimarileri kuruyoruz." },
                    new Feature { Id = 3, Title = "Tam Uyumlu (Responsive)", Description = "Mobil, tablet ve masaüstü tüm ekranlarda kusursuz çalışan, yüksek hızlı ve duyarlı deneyimler sunuyoruz." }
                },

                // Services
                ServicesTitle = "Temel Hizmetlerimiz.",
                ServicesDescription = "Fikirden nihai ürüne kadar markanızın tüm dijital dönüşüm süreçlerinde uçtan uca, yenilikçi ve sonuç odaklı çözümler üretiyoruz.",
                Services = new List<ServiceItem>
                {
                    new ServiceItem { Id = 1, Title = "Web Geliştirme", Description = "Hızlı, güvenli ve modern web uygulamaları ile markanızı dijital dünyada bir adım öne çıkarıyoruz.", IconClass = "ti-layout" },
                    new ServiceItem { Id = 2, Title = "Dijital Pazarlama", Description = "Veriye dayalı stratejilerle hedef kitlenize doğrudan ulaşın, dönüşüm oranlarınızı ve marka bilinirliğinizi artırın.", IconClass = "ti-announcement" },
                    new ServiceItem { Id = 3, Title = "Grafik & Görsel Tasarım", Description = "Markanızın karakterini yansıtan, akılda kalıcı ve etkileyici görsel kimlik unsurları oluşturuyoruz.", IconClass = "ti-layers" },
                    new ServiceItem { Id = 4, Title = "Marka Kimliği (Branding)", Description = "Logo tasarımından kurumsal kimlik rehberine kadar markanızı benzersiz kılacak bütünsel çözümler sunuyoruz.", IconClass = "ti-bookmark" },
                    new ServiceItem { Id = 5, Title = "Video & Prodüksiyon", Description = "Marka hikayenizi etkili animasyonlar ve dinamik video içeriklerle görsel bir şölene dönüştürüyoruz.", IconClass = "ti-video-camera" },
                    new ServiceItem { Id = 6, Title = "Mobil & Uygulama Tasarımı", Description = "Kullanıcı alışkanlıklarına odaklanan, modern ve akıcı mobil arayüz (UI/UX) deneyimleri inşa ediyoruz.", IconClass = "ti-mobile" }
                },

                // Skills
                SkillsImageUrl = "/user-interface/images/about-img.jpg",
                Skills = new List<Skill>
                {
                    new Skill { Id = 1, Name = "İş & Marka Stratejisi", Percentage = 80 },
                    new Skill { Id = 2, Name = "UI / UX & Arayüz Tasarımı", Percentage = 90 },
                    new Skill { Id = 3, Name = "Dijital Büyüme & Pazarlama", Percentage = 75 },
                    new Skill { Id = 4, Name = "Web & Yazılım Geliştirme", Percentage = 85 }
                },

                // Testimonials
                TestimonialsTitle = "İş Ortaklarımız Ne Diyor?",
                TestimonialsDescription = "Birlikte başarı hikayeleri yazdığımız değerli markaların Nascore hakkındaki samimi değerlendirmeleri.",
                Testimonials = new List<Testimonial>
                {
                    new Testimonial { Id = 1, AuthorName = "Caner Yılmaz", AuthorRole = "Genel Müdür", Company = "Nova Teknoloji", AvatarUrl = "/user-interface/images/blog/author1.jpg", Stars = 5, Quote = "Nascore ekibiyle çalışmak kurumsal dijital dönüşüm sürecimizde aldığımız en doğru karardı. Hem kullanıcı deneyimi odaklı yaklaşımları hem de teslimat hızları beklentilerimizin çok ötesindeydi." },
                    new Testimonial { Id = 2, AuthorName = "Selin Aktaş", AuthorRole = "Pazarlama Direktörü", Company = "Apex Retail", AvatarUrl = "/user-interface/images/blog/author2.jpg", Stars = 5, Quote = "Marka kimliğimizin ve e-ticaret altyapımızın yenilenmesinde gösterdikleri titizlik ve teknik uzmanlık sayesinde ilk 3 ayda %65'lik somut bir ciro artışı yakaladık." },
                    new Testimonial { Id = 3, AuthorName = "Murat Demir", AuthorRole = "Kurucu Ortak", Company = "Finova Yazılım", AvatarUrl = "/user-interface/images/blog/author3.jpg", Stars = 5, Quote = "Sadece bir ajans değil, projenin her aşamasında bizimle aynı heyecanı paylaşan gerçek bir teknoloji ortağı oldular. Satış sonrası 7/24 kesintisiz destek için minnettarız." }
                }
            };

            return View(model);
        }
    }
}
