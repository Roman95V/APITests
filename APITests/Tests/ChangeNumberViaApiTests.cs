using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APITests
{
    public class ChangeNumberViaApiTests
    {
        [Test]
        public void CheckForSuccessfulPhoneNumberReplacemen()
        {
            var user = new Dictionary<string, string>
            {
                { "email", $"Will{DateTime.Now:ddyyyymmHHssmm}@gmail.com" },
                { "first_name", "Will" },
                { "last_name", "Smith" },
                { "password", "123qweQWE1" },
                { "phone_number", "3453453454" }
            };
            var createdUser = AuthRequest.SendRequestClientSingUpPost(user);

            var chengedNumber = ClientReguestNumberChange.SendRequestClientPhoneNumberPost("123qweQWE!", "1111111111", createdUser.TokenData.Token);

            Assert.AreEqual("1111111111", chengedNumber);
        }
    }
}
