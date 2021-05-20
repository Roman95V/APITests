using APITests.ChangePassword;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APITests.Tests
{
    public class ChangePasswordViaApiTests
    {
        [Test]
        public void CheckForNotChangePassword()
        {
            var user = new Dictionary<string, string>
            {
                 { "email", $"Will{DateTime.Now:ddyyyymmHHssmm}@gmail.com" },
                { "first_name", "Will" },
                { "last_name", "Smith" },
                { "password", "123qweQWE!" },
                { "phone_number", "3453453454" }
            };
            var createdUser = AuthRequests.SendRequestClientSingUpPost(user);
            var oldToken = createdUser.TokenData.Token;
            var clientRequestChangePassword = new ClientRequestChangePassword();
            var newToken = clientRequestChangePassword.SendRequestClientPasswordPost("123qweQWE!!", "123qweQWE!!", createdUser.TokenData.Token);

            Assert.AreEqual(oldToken, newToken);

        }
       
        [Test]
        public void CheckedForSuccessfulChangePassword()
        {
            var user = new Dictionary<string, string>
            {
                 { "email", $"Will{DateTime.Now:ddyyyymmHHssmm}@gmail.com" },
                { "first_name", "Will" },
                { "last_name", "Smith" },
                { "password", "123qweQWE!" },
                { "phone_number", "3453453454" }
            };
            var createdUser = AuthRequests.SendRequestClientSingUpPost(user);
            var oldToken = createdUser.TokenData.Token;
            var clientRequestChangePassword = new ClientRequestChangePassword();
            var newToken = clientRequestChangePassword.SendRequestClientPasswordPost("123qweQWE!!", "123qweQWE!!", createdUser.TokenData.Token);

            Assert.AreNotEqual(oldToken, newToken);
        }
        
    }
}
