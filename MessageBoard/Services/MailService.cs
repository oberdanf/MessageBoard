using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace MessageBoard.Services
{
    public class MailService: IMailService

{
    public bool SendMail(string from, string to, string subject, string body)
    {
        try
        {
            var message = new MailMessage(from, to, subject, body);
            var client = new SmtpClient();
            client.Send(message);
        }
        catch (Exception)
        {
            //log exceptions is a good practice, isn't it?
            return false;
        }
        return true;
    }
}
}