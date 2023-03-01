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

            //string ttf = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "ARIALNBI.TTF");
            //var baseFont = BaseFont.CreateFont(ttf, BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
            var font = new Font(BaseFont.CreateFont(@"c:\Windows\Fonts\arial.ttf", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED), 20, Font.NORMAL, BaseColor.BLACK);
            var font1 = new Font(BaseFont.CreateFont(@"c:\Windows\Fonts\arial.ttf", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED), 14, Font.NORMAL, BaseColor.GRAY);
            var font2 = new Font(BaseFont.CreateFont(@"c:\Windows\Fonts\arial.ttf", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED), 14, Font.NORMAL, BaseColor.BLACK);

            using (var writer = PdfWriter.GetInstance(document, new FileStream("wwwroot/files/Resume.pdf", FileMode.Create)))
            {
                document.Open();
                document.NewPage();

                //Создаем объект таблицы и передаем в нее число столбцов таблицы из нашего датасета
                PdfPTable table = new PdfPTable(2);
                
                //Добавим в таблицу общий заголовок
                PdfPCell cell = new PdfPCell(new Phrase(resume.Position, font));

                cell.Colspan = 2;
                cell.HorizontalAlignment = 1;
                //Убираем границу первой ячейки, чтобы балы как заголовок
                cell.Border = 0;
                cell.PaddingBottom = 40;
                table.AddCell(cell);

                PdfPCell cell1 = new(new Phrase(new Phrase("Имя", font1)));
                cell1.Border = 0;
                cell1.PaddingBottom = 15;
                table.AddCell(cell1);
                //table.AddCell(new Phrase("Имя", font1));
                PdfPCell cell2 = new(new Phrase(new Phrase(resume.FullName, font2)));
                cell2.Border = 0;
                cell2.PaddingBottom = 15;
                table.AddCell(cell2);
                //table.AddCell(new Phrase(resume.FullName, font2));
                PdfPCell cell3 = new(new Phrase(new Phrase("Возраст", font1)));
                cell3.Border = 0;
                cell3.PaddingBottom = 15;
                table.AddCell(cell3);
                //table.AddCell(new Phrase("Возраст", font1));
                PdfPCell cell4 = new(new Phrase(new Phrase(resume.Age.ToString(), font2)));
                cell4.Border = 0;
                cell4.PaddingBottom = 15;
                table.AddCell(cell4);
                //table.AddCell(new Phrase(resume.Age.ToString(), font2));
                PdfPCell cell5 = new(new Phrase(new Phrase("Мобильный телефон", font1)));
                cell5.Border = 0;
                cell5.PaddingBottom = 15;
                table.AddCell(cell5);
                //table.AddCell(new Phrase("Мобильный телефон", font1));
                PdfPCell cell6 = new(new Phrase(new Phrase(resume.MobilePhone, font2)));
                cell6.Border = 0;
                cell6.PaddingBottom = 15;
                table.AddCell(cell6);
                //table.AddCell(new Phrase(resume.MobilePhone, font2));
                PdfPCell cell7 = new(new Phrase(new Phrase("Город проживания", font1)));
                cell7.Border = 0;
                cell7.PaddingBottom = 15;
                table.AddCell(cell7);
                //table.AddCell(new Phrase("Город проживания", font1));
                PdfPCell cell8 = new(new Phrase(new Phrase(resume.City.Name, font2)));
                cell8.Border = 0;
                cell8.PaddingBottom = 15;
                table.AddCell(cell8);
                //table.AddCell(new Phrase(resume.City.Name, font2));
                PdfPCell cell9 = new(new Phrase(new Phrase("Дата рождения", font1)));
                cell9.Border = 0;
                cell9.PaddingBottom = 15;
                table.AddCell(cell9);
                //table.AddCell(new Phrase("Дата рождения", font1));
                PdfPCell cell10 = new(new Phrase(new Phrase(resume.DateOfBirth.ToShortDateString(), font2)));
                cell10.Border = 0;
                cell10.PaddingBottom = 15;
                table.AddCell(cell10);
                //table.AddCell(new Phrase(resume.DateOfBirth.ToShortDateString(), font2));
                PdfPCell cell11 = new(new Phrase(new Phrase("Пол", font1)));
                cell11.Border = 0;
                cell11.PaddingBottom = 15;
                table.AddCell(cell11);
                //table.AddCell(new Phrase("Пол", font1));
                PdfPCell cell12 = new(new Phrase(new Phrase(resume.Gender.Name, font2)));
                cell12.Border = 0;
                cell12.PaddingBottom = 15;
                table.AddCell(cell12);
                //table.AddCell(new Phrase(resume.Gender.Name, font2));
                PdfPCell cell13 = new(new Phrase(new Phrase("Специализация", font1)));
                cell13.Border = 0;
                cell13.PaddingBottom = 15;
                table.AddCell(cell13);
                //table.AddCell(new Phrase("Специализация", font1));
                PdfPCell cell14 = new(new Phrase(new Phrase(resume.Specialization.Name, font2)));
                cell14.Border = 0;
                cell14.PaddingBottom = 15;
                table.AddCell(cell14);
                //table.AddCell(new Phrase(resume.Specialization.Name, font2));
                PdfPCell cell15 = new(new Phrase(new Phrase("Опыт работы", font1)));
                cell15.Border = 0;
                cell15.PaddingBottom = 15;
                table.AddCell(cell15);
                //table.AddCell(new Phrase("Опыт работы", font1));
                PdfPCell cell16 = new(new Phrase(new Phrase(resume.WorkExperience.Name, font2)));
                cell16.Border = 0;
                cell16.PaddingBottom = 15;
                table.AddCell(cell16);
                //table.AddCell(new Phrase(resume.WorkExperience.Name, font2));
                PdfPCell cell17 = new(new Phrase(new Phrase("Зарплата", font1)));
                cell17.Border = 0;
                cell17.PaddingBottom = 15;
                table.AddCell(cell17);
                //table.AddCell(new Phrase("Зарплата", font1));
                PdfPCell cell18 = new(new Phrase(new Phrase(resume.Salary.Amount + " " + resume.Salary.Currency.Name, font2)));
                cell18.Border = 0;
                cell18.PaddingBottom = 15;
                table.AddCell(cell18);
                //table.AddCell(new Phrase(resume.Salary.Amount + " " + resume.Salary.Currency.Name, font2));
                PdfPCell cell19 = new(new Phrase(new Phrase("Уровень образования", font1)));
                cell19.Border = 0;
                cell19.PaddingBottom = 15;
                table.AddCell(cell19);
                //table.AddCell(new Phrase("Уровень образования", font1));
                PdfPCell cell20 = new(new Phrase(new Phrase(resume.EducationLevel.Name, font2)));
                cell20.Border = 0;
                cell20.PaddingBottom = 15;
                table.AddCell(cell20);
                //table.AddCell(new Phrase(resume.EducationLevel.Name, font2));
                if (!String.IsNullOrEmpty(resume.AboutMyself))
                {
                    PdfPCell cell21 = new(new Phrase(new Phrase("О себе", font1)));
                    cell21.Border = 0;
                    cell21.PaddingBottom = 15;
                    table.AddCell(cell21);
                    //table.AddCell(new Phrase("О себе", font1));
                    PdfPCell cell22 = new(new Phrase(new Phrase(resume.AboutMyself, font2)));
                    cell22.Border = 0;
                    cell22.PaddingBottom = 15;
                    table.AddCell(cell22);
                    //table.AddCell(new Phrase(resume.AboutMyself, font2));
                }
                
                document.Add(table);

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
