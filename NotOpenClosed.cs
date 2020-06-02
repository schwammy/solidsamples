using System;
using System.Collections.Generic;

namespace EndToEndSamples.SOLID
{
    public class ClosedMembershipValidator
    {
        public void ValidateUser(Account account)
        {
            if (account.UserName.Length < 5)
                throw new Exception("invalid username");
            if (!account.UserName.Contains("@"))
                throw new Exception("not an email address");
            //validate password
            if (account.Password.Length < 5)
                throw new Exception("invalid username");
        }
    }

    public class OpenMembershipValidator
    {
        private readonly List<Rule> _rules;
        public OpenMembershipValidator(List<Rule> rules )
        {
            _rules = rules;
        }


        public void ValidateUser(Account account)
        {
            foreach (var rule in _rules)
            {
                rule.Validate(account);
            }
        }
    }

    public abstract class Rule
    {
        public abstract void Validate(Account account);
    }

    public class UserNameLengthRule : Rule
    {
        public override void Validate(Account account)
        {
            if (account.UserName.Length < 5)
                throw new Exception("invalid username");
        }
    }
    public class PasswordLengthRule : Rule
    {
        public override void Validate(Account account)
        {
            if (account.Password.Length < 5)
                throw new Exception("invalid password");
        }
    }
    public class Account
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
    
}