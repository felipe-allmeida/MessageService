using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MessagesService.Models;
using TwilioGateway;

namespace MessagesService.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ITwilioService _twilioService;

        public HomeController(ILogger<HomeController> logger, ITwilioService twilioService)
        {
            _logger = logger;
            _twilioService = twilioService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SendSMS([FromBody] SendSMS sendSMS)
        {
            _twilioService.SendMessage(sendSMS.Message, sendSMS.PhoneNumber);

            return Ok();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
