using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace EndToEndSamples.SOLID
{
    /***********************************
    *  To see the problem, look at Single Responsibility Example
    ***********************************/

    public class NotUsingDependencyInversion
    {
        public void Join(string userName, string password)
        {
            new MembershipValidator().ValidateUser(userName, password); 

            new MembershipService().Add(userName, password); // may have a dependency on EF?

            var message = new MessageFormatter().FormatMessage(userName);

            new Notifier().SendNotification(message); //may have a dependency on SMTP mail?
        }
    }

    // Include the interfaces in their own dll.
    // Include the implementations in separate dlls.
    // Now the implementations and the usage all depend upon the abstration.

    public interface IMembershipValidator
    {
        void ValidateUser(string userName, string password);
    }

    public interface IMembershipService
    {
        void Add(string userName, string password);
    }

    public interface IMessageFormatter
    {
        MailMessage FormatMessage(string userName);
    }

    public interface INotifier
    {
        void SendNotification(MailMessage message);
    }

    public class UsingDependencyInversion
    {
        IMembershipValidator _validator;
        IMembership _membership;
        IMessageFormatter _formatter;
        INotifier _notifier;

        public void Join(string userName, string password)
        {
            _validator.ValidateUser(userName, password); 

            _membership.Add(userName, password); 

            var message = _formatter().FormatMessage(userName);

            _notifier.SendNotification(message); 
        }
    }

}
