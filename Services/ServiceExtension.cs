using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using MimeKit;
using MimeKit.Text;
using MailKit.Net.Smtp;
using MailKit.Security;
using ACMS.DAL.Models;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Net.Http.Headers;
using System.Text;
using MailKit.Net.Imap;
using System.Drawing;

namespace APIACMS.Services
{

    public class ServiceExtension : IServiceExtension
    {
        private readonly IConfiguration _configuration;

        private readonly string _emailAddress;

        private readonly string _emailPassword;

        private readonly string _smtpHost;

        private readonly int _smtpPort;

        public ServiceExtension(IConfiguration configuration)
        {
            _configuration = configuration;

            _emailAddress = _configuration.GetValue<string>("EmailConfiguration:Email");

            _emailPassword = _configuration.GetValue<string>("EmailConfiguration:Password");

            _smtpHost = "smtp.office365.com";

            _smtpPort = 587;

        }
        public bool Send(EmailDto content)
        {
            #region Create Email
            var email = new MimeMessage();

            

            email.From.Add(MailboxAddress.Parse("ACMS@apiu.edu"));

            email.To.Add(MailboxAddress.Parse(content.To));

            if (content.Cc != null)
            {
                email.Cc.Add(MailboxAddress.Parse(content.Cc));
            } 


            email.Subject = content.Subject;

            email.Body = new TextPart(TextFormat.Html) { Text = content.Body };




            #endregion

            #region Send Email

            using var smtp = new SmtpClient();
            try
            {
                smtp.Connect(_smtpHost, _smtpPort);

                smtp.Authenticate(_emailAddress, _emailPassword);

                smtp.Send(email);

                smtp.Disconnect(true);

                return true;
            }

            catch (Exception e) 
            {
                Console.WriteLine(e.ToString());

                return false;
            }

            #endregion

        }

        public string Upload(PaidSessionDTOs image)
        {
            var file = image;


            var folderName = Path.Combine("Resources", "Images", "BankReciept");
            var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
            if (file.Image.Length> 0)
            {
                var fileName = image.PictureLink;
                var fullPath = Path.Combine(pathToSave, fileName);
                var dbPath = Path.Combine(folderName, fileName);
                using (var stream = new FileStream(fullPath,FileMode.Create))
                {
                    file.Image.CopyTo(stream);
                }
                return dbPath;
            }
            else
            {
                var status = "Failed";

                return status;
            }

        }

        public string CreateRegistrationReplyHTML(string studentName, string instructorName, string className, string InstructorEmail, string instuctorphone)
        {
            return " Dear "+studentName+",<br><br>This email is to confirm your registration at AIU Community Music School" +
                "<table><tr> <td> Name:</td><td> " + studentName + "</td></tr><tr><td> Instument:</td><td>" + className + " </td>" +
                "</tr> <tr><td> Instructor:</td> <td> " + instructorName + " </td> </tr> <tr><td> Instructor's Email:</td>" +
                "<td> " + InstructorEmail + " </td> </tr> <tr><td> Instructor's Phone Number:</td> <td> " + instuctorphone + " </td>" +
                "</tr></table><br> Please contact your teacher through email or phone to arrange for assessment and schedule.<br>" +
                "After doing so, kindly proceed to pay and send the receipt to us through email or website." +
                " <br><span style = \"color: red;\"><strong> Don't forget to indicate in back note: AIU Community Music School</strong></span>" +
                "<br> <br> Then you can start your lesson.<br><br> We are excited to have you with us. <br> <br> Sincerly,<br>  <br>" +
                " <br> The AIU Community Music School Team <style>  table, th, td {  border: 1px solid black;border - collapse: collapse; padding: 10px;" +
                " } </style> ";
            

            
        }


        public string CreateUploadReieptReplyHTML()
        {
            return "Thankyou for the payment <br><br>Your reciept is uploaded to the system and will be reviwed during office hours." +
                "<br><br>Sincerly, <br> <br> <br>The AIU Community Music School Team";
        }

        public string CreateInvoice(string name, string teacher, string level, string amount, string typeofpayment)
        {
            return "<div style=\"width:500px;height:250px;border-style:solid;\"><div style=\"text-align: center; font-family:'Times New Roman',Times,serif;\">ASIA PACIFIC INTERNATIONAL UNIVERSITY<br>AIU COMMUNITY MUSIC SCHOOL<br>" +
                   "<br>INVOICE</div><br><br>Name:___" + name + "___  ID:____________ (For AIU student)" +
                   "<br>Teacher:___ " + teacher + "___ Level:___ " + level + "___<br>Payment Amount:___" + amount + "___ Bath<br>Type of Payment:___" + typeofpayment + "___</div>";

        }
    }
}
