using NewsLetterApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsLetterApp.Service
{
    public interface IEmailService
    {
        void SendEmail(EmailInfo emailInfo);
    }
}
