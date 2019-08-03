using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
// using SendGrid's C# Library
// https://github.com/sendgrid/sendgrid-csharp
using SendGrid;
using SendGrid.Helpers.Mail;


namespace TRHDipComp_Project.Models
{

    // MessageManager handles the SMS and eMail API invocations to the Twilio SMS and SendGrid eMail systems 
    public class MessageManager
    {

        // Find your Account Sid and Token at twilio.com/console
        // DANGER! This is insecure. See http://twil.io/secure

        public MessageManager(string accountSid,
                                   string authToken)
        {
            TwilioClient.Init(accountSid, authToken);
        }

        public void SendSMSMessage(string targetPhoneNumber, 
                                   string SMSMessage,
                                   string myTwilioPhoneNumber
                                   )
        {            
            var message = MessageResource.Create(
                from: new Twilio.Types.PhoneNumber(myTwilioPhoneNumber),
                body: SMSMessage,
                to: new Twilio.Types.PhoneNumber(targetPhoneNumber)
            );
            
        }

        public async Task SendEmailMessage(string sourceEmailAddress,
                                         string targetEmailAddress,
                                         string subject,
                                         string plainTextContent,
                                         string htmlContent)
        {
            string apiKey = Environment.GetEnvironmentVariable("SENDGRID_API_KEY");
            
            if (String.IsNullOrEmpty(apiKey))
            {
                throw new Exception("Error, cannot send email. SENDGRID_API_KEY environment variable is not set.");
            }
            var client = new SendGridClient(apiKey);

            var from = new EmailAddress(sourceEmailAddress, sourceEmailAddress);
            var to = new EmailAddress(targetEmailAddress, targetEmailAddress);

            // As a workaround to a SendGrid trial account email issue, I've put the email body content in the html tag                                    
            htmlContent = $"<p>{plainTextContent}</p>";

            var msg = MailHelper.CreateSingleEmail(from, 
                                                   to, 
                                                   subject, 
                                                   plainTextContent, 
                                                   htmlContent);
            
            Response response = await client.SendEmailAsync(msg);
            
        }
    }
}
