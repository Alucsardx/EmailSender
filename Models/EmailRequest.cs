using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace EmailSender.Models
{
    public class EmailRequest
    {
        [Required]
        public string ToAddress { get; set; }
        [Required]
        public string Body { get; set; }
        [Required]
        public string Subject { get; set; }
        public IFormFile Attachment { get; set; }
    }
}
