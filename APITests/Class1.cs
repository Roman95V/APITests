using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APITests
{
    public static class Class1
    {
        public static string SendRequestClientEmailPost(string password, string phone_number, string token)
        {
            var client = new RestClient("https://api.newbookmodels.com/api/v1/client/change_phone/");
            var request = new RestRequest(Method.POST);
            var newNumberModul = new Dictionary<string, string>
            {
                { "phone_number", phone_number },
                { "password", password },

            };

            request.AddHeader("content-type", "application/json");
            request.AddHeader("authorization", token);
            request.AddJsonBody(newNumberModul);
            request.RequestFormat = DataFormat.Json;
            var response = client.Execute(request);
            var newNumber = JsonConvert.DeserializeObject<ClientAuthModel>(response.Content);

            return newNumber.Phone_number;
        }
    }
}
