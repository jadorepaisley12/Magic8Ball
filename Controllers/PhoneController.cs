using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Twilio.AspNet.Mvc;
using Twilio.TwiML;
using Twilio.TwiML.Voice;

namespace Magic8Ball.Controllers
{
    public class PhoneController : TwilioController
    {
        [HttpPost]
        public ActionResult ReceiveCall(string digits)
        {
            var response = new VoiceResponse();

            if (!string.IsNullOrEmpty(digits))
            {
                string[] answers = { "42", "My best guess is no" };
                Random rand = new Random();
                response.Say("The answer to your question is " + answers[rand.Next(answers.Length)] + ". You are allowed no more questions.");
            }
            else {
                response.Say("The Magic 8 Ball is ready to reveal its findings. Press one to hear your answer.").Append(new Gather(numDigits: 1));
                response.Redirect(new Uri("http://yourdomain/phone/receiveCall")); 
            }
            return TwiML(response);
        }
    }
}