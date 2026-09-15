using Microsoft.AspNetCore.Mvc;
using Nascore.Models;
using Nascore.ViewModels;
using Nascore.Services.Abstract;
using System;
using System.Threading.Tasks;

namespace Nascore.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactMessageService _contactService;

        public ContactController(IContactMessageService contactService)
        {
            _contactService = contactService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var model = GetContactViewModel();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Index(ContactViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var refreshedModel = GetContactViewModel();
                refreshedModel.Form = model.Form; 
                return View(refreshedModel);
            }

            var newMessage = new ContactMessage
            {
                Name = model.Form.Name,
                Email = model.Form.Email,
                Phone = model.Form.Phone,
                Subject = model.Form.Subject,
                Message = model.Form.Message,
                IsKvkkAccepted = model.Form.IsKvkkAccepted,
                CreatedAt = DateTime.UtcNow
            };

            // Hizmet katmanı üzerinden veritabanına kayıt işlemi (Validasyonlar Service içinde yapılır)
            await _contactService.AddAsync(newMessage);

            TempData["SuccessMessage"] = "Mesajınız başarıyla iletildi. En kısa sürede size dönüş yapacağız.";

            return RedirectToAction("Index");
        }

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
