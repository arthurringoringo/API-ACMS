﻿using ACMS.DAL.Models;
using Microsoft.AspNetCore.Http;

namespace APIACMS.Services
{
    public interface IServiceExtension
    {
        bool Send(EmailDto content);
        public string Upload(IFormFile image);
    }
}