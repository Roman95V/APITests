using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APITests.API
{
    public class ChangeFirstNameLastNameViaApiTests
    {

        [Test]
        public void CheckedForSuccessfulFirstNameLastNameChange()
        {
            var user = new Dictionary<string, string>
            {
                 { "email", $"Will{DateTime.Now:ddyyyymmHHssmm}@gmail.com" },
                { "first_name", "Will" },
                { "last_name", "Smith" },
                { "password", "123qweQWE1" },
                { "phone_number", "3453453454" }
            };
            var createdUser = AuthRequests.SendRequestClientSingUpPost(user);
            var _validNewFirstName = "Petro";
            var _validNewSecondName = "Shevchenko";
            var newPrimaryAccountHolderName = ClientRequestChangeFirstNameLastName.SendRequestChangeFirstNammeLastNamePatch(_validNewFirstName, _validNewSecondName, createdUser.TokenData.Token);

            Assert.Multiple(() =>
            {
                Assert.AreEqual(_validNewFirstName, newPrimaryAccountHolderName.FirstName);
                Assert.AreEqual(_validNewSecondName, newPrimaryAccountHolderName.LastName);
            });
        }
       
    }
}
