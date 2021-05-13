using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APITests
{
    public static class AuthViaApi
    {
        public static ClientAuthModel CreateUserViaApi()
        {
            var client = new RestClient("https://api.newbookmodels.com/api/v1/auth/client/signup/");
            var request = new RestRequest(Method.POST);    
            var user = new Dictionary<string, string>    
            { 
                { "email", $"Will{DateTime.Now:ddyyyymmHHssmm}@gmail.com" },           
                { "first_name", "Will" },            
                { "last_name", "Smith" },             
                { "password", "123qweQWE1" },             
                { "phone_number", "3453453454" }             
            };
            
            request.AddHeader("content-type", "application/json"); 
            request.AddJsonBody(user); 
            request.RequestFormat = DataFormat.Json; 
            var response = client.Execute(request); 
            var createdUser = JsonConvert.DeserializeObject<ClientAuthModel>(response.Content); 
            return createdUser;
        }

    }
}
