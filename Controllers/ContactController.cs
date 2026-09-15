using Microsoft.AspNetCore.Mvc;
using Nascore.Models;
using Nascore.ViewModels;
using System;

namespace Nascore.Controllers
{
    public class ContactController : Controller
    {
        // Sayfa ilk açıldığında çalışacak GET metodu
        [HttpGet]
        public IActionResult Index()
        {
            var model = GetContactViewModel();
            return View(model);
        }

        // Form gönderildiğinde çalışacak POST metodu
        [HttpPost]
        public IActionResult Index(ContactViewModel model)
        {
            // Eğer modeldeki (özellikle Form kısmındaki) DataAnnotation kuralları ihlal edildiyse
            if (!ModelState.IsValid)
            {
                // Statik metinler POST ile gelmeyeceği için tekrar doldurmamız gerekir
                var refreshedModel = GetContactViewModel();
                refreshedModel.Form = model.Form; // Kullanıcının girdiği hatalı veriyi silmemek için
                
                return View(refreshedModel);
            }

            // Doğrulama başarılıysa: Gelen veriyi asıl veritabanı modeline (ContactMessage) aktar
            var newMessage = new ContactMessage
            {
                Name = model.Form.Name,
                Email = model.Form.Email,
                Phone = model.Form.Phone,
                Subject = model.Form.Subject,
                Message = model.Form.Message,
                IsKvkkAccepted = model.Form.IsKvkkAccepted,
                CreatedAt = DateTime.Now
            };

            // Burada veritabanına kaydetme işlemi yapılır
            // _context.ContactMessages.Add(newMessage);
            // _context.SaveChanges();

            // Başarılı bir şekilde kaydedildiğine dair TempData ile mesaj gönderilebilir
            TempData["SuccessMessage"] = "Mesajınız başarıyla iletildi. En kısa sürede size dönüş yapacağız.";

            // Formun içini boşaltıp sayfayı yenilemek için Redirect
            return RedirectToAction("Index");
        }

        // Statik verileri her defasında yazmamak için yardımcı bir metot
        private ContactViewModel GetContactViewModel()
        {
            return new ContactViewModel
            {
                BannerTitlePart1 = "Bizimle İletişime",
                BannerTitlePart2 = "Geçin.",
                BannerDescription = "Sorularınız, iş ortaklığı talepleriniz veya yeni projeleriniz için bize her zaman ulaşabilirsiniz. Size en kısa sürede dönüş yapacağız.",
                Address = "Büyükdere Cad. No: 142, Levent, Beşiktaş / İstanbul",
                Phone = "+90 (212) 555 01 23",
                Email = "info@nascore.com",
                WorkingHours = "Pazartesi - Cuma: 09:00 - 18:00",
                GoogleMapsUrl = "https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3008.277873919426!2d29.009477!3d41.077673!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x14cab65d642da659%3A0x63351ec646e7f7b!2sLevent%2C%20Be%C5%9Fikta%C5%9F%2F%C4%B0stanbul!5e0!3m2!1str!2str!4v1700000000000!5m2!1str!2str",
                Form = new ContactFormViewModel()
            };
        }
    }
}
