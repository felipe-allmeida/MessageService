using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MessagesService.Models
{
    public class SendSMS
    {
        public string PhoneNumber { get; set; }
        public string Message { get; set; }
    }
}
