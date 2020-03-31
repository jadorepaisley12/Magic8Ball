using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Twilio.AspNet.Common;
using Twilio.AspNet.Mvc;
using Twilio.TwiML;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace Magic8Ball.Controllers
{
    public class SmsController : TwilioController
    {
        // GET: Sms
        public ActionResult SendSMS(string phone)
        {
            TwilioClient.Init(HttpContext.Application["accountSid"].ToString(), HttpContext.Application["authToken"].ToString());

            var message = MessageResource.Create(body: "All of life's questions answered. Ask the Magic 8 Ball a question.",
                from: new Twilio.Types.PhoneNumber("+1YourPhoneNumber"), to: new Twilio.Types.PhoneNumber("+1" + phone));

            bool messageSent = true; 
            return RedirectToAction("Index", "Home", new { messageSent});
        }

        public TwiMLResult ReceiveSMS(SmsRequest incomingMessage)
        {
            var messagingResponse = new MessagingResponse();
            messagingResponse.Message("The Magic 8 Ball has decided your question is worthy. To hear the answer, call +1PhoneNumber");
            return TwiML(messagingResponse); 
        }
    }
}