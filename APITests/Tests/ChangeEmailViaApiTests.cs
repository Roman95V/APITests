using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APITests
{
    public class ChangeEmailViaApiTests
    {
        [Test]
        public void CheckForSuccessfulEmailChange()
        {
            var expactedEmail = $"asda2sd2asd{DateTime.Now:ddyyyymmHHssmm}@asdasd.ert";

            var user = new Dictionary<string, string>
            {
                 { "email", $"Will{DateTime.Now:ddyyyymmHHssmm}@gmail.com" },
                { "first_name", "Will" },
                { "last_name", "Smith" },
                { "password", "123qweQWE1" },
                { "phone_number", "3453453454" }
            };
            var createdUser = AuthRequests.SendRequestClientSingUpPost(user);
            var chengedEmail = ClientReguests.SendRequestClientEmailPost("123qweQWE!", expactedEmail, createdUser.TokenData.Token);

            Assert.AreEqual(expactedEmail, chengedEmail);
        }
    }
}
