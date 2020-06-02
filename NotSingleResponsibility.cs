using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Net.Mail;

namespace EndToEndSamples.SOLID
{
    public class NotSingleResponsibility
    {
        public void Join(string userName, string password)
        {
            //validate username
            if (userName.Length < 5)
                throw new Exception("invalid username");
            if (!userName.Contains("@"))
                throw new Exception("not an email address");
            //validate password
            if (password.Length < 5)
                throw new Exception("invalid password");
            
            
            //check for duplicate users
            if (Members.Contains(userName))
                throw new Exception("Duplicate username");
            
            //join
            AddUser(userName, password);
            
            //send email
            MailMessage message = new MailMessage();
            message.Subject = "Welcome";
            message.Body = "Thanks for joining!";
            message.To.Add(userName); 
            SmtpClient client = new SmtpClient();
            client.Send(message);

        }

        public List<string> Members { get; set; }

        public void AddUser(string userName, string password)
        {
            //pretend this is implemented :)
        }
    }
}