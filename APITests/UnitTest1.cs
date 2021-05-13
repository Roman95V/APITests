using Newtonsoft.Json;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using RestSharp;
using System;
using System.Collections.Generic;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace APITests
{
    public class Tests
    {

        [Test]
        public void Test1()
        {
            var client = new RestClient("https://api.newbookmodels.com/api/v1/auth/client/signup/");
            var request = new RestRequest(Method.POST);
            var user = new Dictionary<string, string>
            {
                { "email", $"asda2sd2asd{DateTime.Now:ddyyyymmHHssmm}@asdasd.ert" },
                { "first_name", "asdasdasd" },
                { "last_name", "asdasdasd" },
                { "password", "123qweQWE" },
                { "phone_number", "3453453454" }
            };

            request.AddHeader("content-type", "application/json");
            request.AddJsonBody(user);
            request.RequestFormat = DataFormat.Json;
            var response = client.Execute(request);
        }

        [Test]
        public void CheckForSuccessfulEmailReplacemen()  
        {
            var expactedEmail = $"asda2sd2asd{DateTime.Now:ddyyyymmHHssmm}@asdasd.ert";

            var user = new Dictionary<string, string>
            {
                { "email", $"asda2sd2asd{DateTime.Now:ddyyyymmHHssmm}@gmail.com" },
                { "first_name", "asdasdasd" },
                { "last_name", "asdasdasd" },
                { "password", "123qweQWE!" },
                { "phone_number", "3453453454" }
            };
            var createdUser = AuthRequests.SendRequestClientSingUpPost(user);
            var chengedEmail = ClientReguests.SendRequestClientEmailPost("123qweQWE!", expactedEmail, createdUser.TokenData.Token);

            Assert.AreEqual(expactedEmail, chengedEmail);
        }

        [Test]
        public void CheckForSuccessfulPhoneNumberReplacemen()
        {
            var user = new Dictionary<string, string>
            {
                { "email", $"asda2sd2asd{DateTime.Now:ddyyyymmHHssmm}@gmail.com" },
                { "first_name", "asdasdasd" },
                { "last_name", "asdasdasd" },
                { "password", "123qweQWE!" },
                { "phone_number", "3453453454" }
            };
            var createdUser = Class2.SendRequestClientSingUpPost(user);
            var chengedNumber = Class1.SendRequestClientEmailPost("123qweQWE!","1111111111", createdUser.TokenData.Token);

            Assert.AreEqual("1111111111", chengedNumber);
        }
    }
}