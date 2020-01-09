using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewsLetterApp.Models;
using NewsLetterApp.Service;

namespace NewsLetterApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        IEmailService _emailService;

        public EmailController(IEmailService emailService)
        {
            _emailService = emailService;
        }

        [HttpPost]
        public IActionResult SendEmail(EmailInfo emailInfo)
        {
            try
            {
                _emailService.SendEmail(emailInfo);

                return Ok("Sent Successfully");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}