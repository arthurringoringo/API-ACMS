using ACMS.DAL.Models;
using Microsoft.AspNetCore.Http;

namespace APIACMS.Services
{
    public interface IServiceExtension
    {
        bool Send(EmailDto content);
        public string Upload(PaidSessionDTOs image);
        public string CreateRegistrationReplyHTML(string studentName, string instructorName, string className, string InstructorEmail, string instuctorphone);
        public string CreateUploadReieptReplyHTML();
        public string CreateInvoice(string name, string teacher, string level, string amount, string typeofpayment);

    }
}