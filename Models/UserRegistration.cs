using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace EmailSender.Models
{
    public class UserRegistration
    {
        public IFormFile File { get; set; }
    }
}
