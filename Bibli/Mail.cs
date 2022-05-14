using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mime;
using System.IO;

namespace Bibli
{
    public class Mail
    {
        public static async Task SendEmailAsync(string massage)
        {
                MailAddress from = new MailAddress("zakirtest2@gmail.com", "Zakir");
                MailAddress to = new MailAddress($"{massage}");
                MailMessage m = new MailMessage(from, to);
                m.Attachments.Add(new Attachment("C:\\Users\\Admin\\Desktop\\2\\Exam1\\Exam1\\bin\\Debug\\Result_2022.xlsx"));
                m.Subject = "Тест";
                m.Body = $"{massage}";
                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                smtp.Credentials = new NetworkCredential("zakirtest2@gmail.com", "123456789z+");
                smtp.EnableSsl = true;
                await smtp.SendMailAsync(m);
        }
    }
}
