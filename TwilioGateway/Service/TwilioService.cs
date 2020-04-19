using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using TwilioGateway.Settings;

namespace TwilioGateway.Service
{
    public class TwilioService : ITwilioService
    {
        private readonly TwilioSettings _settings;
        public TwilioService(IOptions<TwilioSettings> options)
        {
            _settings = options?.Value;

            InitTwilio();
        }

        public void SendMessage(string msg, string phoneNumber)
        {
            MessageResource.Create(
                body: msg,
                from: new Twilio.Types.PhoneNumber(_settings.PhoneNumber),
                to: new Twilio.Types.PhoneNumber(phoneNumber));
        }        

        private void InitTwilio()
        {
            TwilioClient.Init(_settings.AccountSid, _settings.AuthToken);
        }
    }
}
