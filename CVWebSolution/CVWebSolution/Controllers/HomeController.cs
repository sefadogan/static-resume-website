using CVWebSolution.Helpers;
using System.Collections.Generic;
using System.Web.Mvc;

namespace CVWebSolution.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SendEmail(string adSoyad, string email, string mesaj)
        {
            JsonResult jsonResult = new JsonResult();
            if (string.IsNullOrWhiteSpace(adSoyad) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(mesaj))
            {
                jsonResult.Data = new { success = false, message = "Alanlar boş geçilemez." };
                return jsonResult;
            }
            bool isSentSuccess = MailSender.ContactSendMail(email,
                    "Sefa DOĞAN Kişisel Web Sitesi İletişim Talebi",
                    string.Format(
                        "<p><b>Ad Soyad:</b> {0}</p> " +
                        "<p><b>Email:</b> {1}</p> " +
                        "<p><b>Mesaj:</b> {2}</p>", adSoyad, email, mesaj), new List<string>() { "sefa@sefadogan.com" });
            if (isSentSuccess)
                jsonResult.Data = new { success = true, message = "İletişim talebiniz başarıyla kaydedilmiştir." };
            else
                jsonResult.Data = new { success = false, message = "İletişim talebiniz kaydedilirken bir hata oluştu. Lütfen daha sonra tekrar deneyiniz." };
            return jsonResult;
        }
    }
}