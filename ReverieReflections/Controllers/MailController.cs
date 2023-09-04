using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;
using System.Net;
using ReverieReflections.Data;

namespace ReverieReflections.Controllers
{
    public class MailController : Controller
    {

        public IActionResult Index()
        {
            //hedvdcjqbiipqrio

            return View();
        }

        [HttpPost]
        public IActionResult Index(Mail mail)
        {
            //hedvdcjqbiipqrio
            //bu gelen maili gönder !

            try
            {
                MailMessage mailMessage = new MailMessage();
                SmtpClient smtpClient = new SmtpClient();

                string gonderen = "sinantasyapar@gmail.com";



                mailMessage.From = new MailAddress(gonderen);  //gönderen belirtiliyor
                mailMessage.To.Add("ozngnc42@gmail.com");  //alıcı/lar belirtiliyor

                mailMessage.Subject = mail.Subject;   //konu belirtiliyor
                mailMessage.Body = mail.Body;   //içerik belirtiliyor

                smtpClient.Port = 587;   //sabit
                smtpClient.Host = "smtp.gmail.com";   //sabit

                smtpClient.EnableSsl = true;   //true olacak


                //Gönderen ve 2 factor authenticationdaki şifre yazılacak 
                //Mail adresi şifreniz DEĞİL !
                smtpClient.Credentials = new NetworkCredential(gonderen, "faraiuzbnojzvltw");

                smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;  //sabit
                smtpClient.Send(mailMessage);  //gönderme metodu


            }
            catch (Exception ex)
            {

            }


            return View();
        }
    }
}
