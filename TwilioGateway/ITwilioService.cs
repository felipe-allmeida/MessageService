using System;
using System.Collections.Generic;
using System.Text;

namespace TwilioGateway
{
    public interface ITwilioService
    {
        void SendMessage(string msg, string phoneNumber);
    }
}
