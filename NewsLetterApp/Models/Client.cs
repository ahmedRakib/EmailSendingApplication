using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NewsLetterApp.Models
{
    public class Client
    {
        public int Id { get; set; }

        public string Name  { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public int NewsLetterGroupId { get; set; }
    }
}
