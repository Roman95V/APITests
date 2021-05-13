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
    public class AuthClientViaApiTests
    {

        [Test]
        public void CheckSuccessfuAuthClient()
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
    }
}