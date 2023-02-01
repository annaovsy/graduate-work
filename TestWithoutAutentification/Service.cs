﻿using Microsoft.Extensions.Logging;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace TestWithoutAutentification
{
    public static class Service
    {
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
