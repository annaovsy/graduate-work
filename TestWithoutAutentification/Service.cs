using iTextSharp.text;
using iTextSharp.text.pdf;
using MimeKit;
using System;
using System.IO;
using System.Net;
using TestWithoutAutentification.Models;

namespace TestWithoutAutentification
{
    public static class Service
    {
        public static void CreatePDF(Resume resume)
        {
            Document document = new(PageSize.A4, 20, 20, 30, 20);

            string ttf = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "ARIALNBI.TTF");
            var baseFont = BaseFont.CreateFont(ttf, BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
            var font = new Font(baseFont, Font.DEFAULTSIZE, Font.NORMAL);

            using (var writer = PdfWriter.GetInstance(document, new FileStream("wwwroot/files/Resume.pdf", FileMode.Create)))
            {
                document.Open();
                document.NewPage();
                document.Add(new Paragraph(resume.Position, font));
                document.Add(new Paragraph("Имя " + resume.FullName, font));
                document.Add(new Paragraph("Мобильный телефон " + resume.MobilePhone, font));
                document.Add(new Paragraph("Город проживания " + resume.MobilePhone, font));
                document.Add(new Paragraph("Дата рождения " + resume.MobilePhone, font));
                document.Add(new Paragraph("Пол " + resume.MobilePhone, font));
                document.Add(new Paragraph("Специализация " + resume.MobilePhone, font));
                document.Add(new Paragraph("Опыт работы " + resume.MobilePhone, font));
                document.Add(new Paragraph("Зарплата " + resume.MobilePhone, font));
                document.Add(new Paragraph("О себе " + resume.MobilePhone, font));
                document.Add(new Paragraph("Уровень образования " + resume.MobilePhone, font));
                document.Close();
                writer.Close();            
            }
        }

        public static void SendEmailToCandidate(string senderName, string senderEmail, string recipient, string title, string text)
        {
            try
            {
                MimeMessage message = new MimeMessage();
                message.From.Add(new MailboxAddress("Поиск работы", "anna.ovsyann1kova@yandex.ru")); //отправитель сообщения
                message.To.Add(new MailboxAddress(recipient, recipient)); //адресат сообщения
                if (title == null)
                    message.Subject = "Без темы";
                else
                    message.Subject = title; //тема сообщения
                text = text.Replace("\r\n", "<br>");
                message.Body = new BodyBuilder() { HtmlBody = "<div>" + text + "</div>"+
                                                              "<br/><p><div>" + "Сообщение отправлено от <span style=\"font-weight: bold; color: #2C8E8B;\">" + 
                                                              senderName + "</span><br/>" + senderEmail + "</div></p>"
                }.ToMessageBody(); //тело сообщения (так же в формате HTML)

                using (MailKit.Net.Smtp.SmtpClient client = new MailKit.Net.Smtp.SmtpClient())
                {
                    client.Connect("smtp.yandex.ru", 465, true); //либо использум порт 465
                    client.Authenticate("anna.ovsyann1kova@yandex.ru", "saxmalutka"); //логин-пароль от аккаунта
                    client.Send(message);
                   
                    client.Disconnect(true);
                }
            }
            catch (Exception e)
            {
               var s = e.Message;
            }
        }
        
        public static void SendEmailToCompany(string senderName, string senderEmail, int resumeId, int vacancyId, string position, string recipient, string text)
        {
            try
            {
                MimeMessage message = new MimeMessage();
                message.From.Add(new MailboxAddress("Поиск работы", "anna.ovsyann1kova@yandex.ru")); //отправитель сообщения
                message.To.Add(new MailboxAddress(recipient, recipient)); //адресат сообщения
                message.Subject = "Отклик на вакансию";
                
                text = text.Replace("\r\n", "<br>");

                message.Body = new BodyBuilder()
                {
                    HtmlBody = "<div>Создан отклик на вакансию <a href='https://localhost:44319/Vacancies/ShowVacancy/" + vacancyId + "'>" + position + "</a></div>" +
                                "<br/><div>" + text + "</div>" +                               
                                "<br/><p><div>" + "Резюме можно посмотреть по <a href='https://localhost:44319/Resumes/ShowResume/" + resumeId + "'>Ссылке</a><br/>" +
                                "Сообщение отправлено от <span style=\"font-weight: bold; color: #2C8E8B;\">" +
                                senderName + "</span><br/>" + senderEmail + "</div></p>"
                }.ToMessageBody();

                using (MailKit.Net.Smtp.SmtpClient client = new MailKit.Net.Smtp.SmtpClient())
                {
                    client.Connect("smtp.yandex.ru", 465, true); //либо использум порт 465
                    client.Authenticate("anna.ovsyann1kova@yandex.ru", "saxmalutka"); //логин-пароль от аккаунта
                    client.Send(message);

                    client.Disconnect(true);
                }
            }
            catch (Exception e)
            {
                var s = e.Message;
            }
        }

    }
}
