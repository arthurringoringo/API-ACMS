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

            //_emailAddress = _configuration.GetValue<string>("EmailConfiguration:EmailAddress");

            //_emailPassword = _configuration.GetValue<string>("EmailConfiguration:Emailpassword");

            _emailAddress = "201700143@my.apiu.edu";

            _emailPassword = "@iloveyouverent22";

            _smtpHost = "smtp.office365.com";

            _smtpPort = 587;

        }
        public bool Send(EmailDto content)
        {
            #region Create Email
            var email = new MimeMessage();

            email.From.Add(MailboxAddress.Parse(_emailAddress));

            email.To.Add(MailboxAddress.Parse(content.To));

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

        public string Upload(IFormFile image)
        {
            var file = image;
            var folderName = Path.Combine("Resources", "Images", "BankReciept");
            var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
            if (file.Length > 0)
            {
                var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                var fullPath = Path.Combine(pathToSave, fileName);
                var dbPath = Path.Combine(folderName, fileName);
                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
                return dbPath;
            }
            else
            {
                var status = "Failed";

                return status;
            }

        }
    }
}
