using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmailSender.Models
{
    public class UserInfoAsPDF
    {
        public string Information { get; set; }
        public string NameSurname { get; set; }
        public int MemberCount { get; set; }
        public int Age { get; set; }
        public string EMail { get; set; }
        public string MobileNumber { get; set; }
        public string Facebook { get; set; }
    }
}
