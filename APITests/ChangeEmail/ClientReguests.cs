using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APITests
{
    public class clientReguests
    {
        public string SendRequestClientEmailPost(string password, string email, string token)
        {
            var client = new RestClient("https://api.newbookmodels.com/api/v1/client/change_email/");
            var request = new RestRequest(Method.POST);
            var newElmaiModul = new Dictionary<string, string>
            {
                { "email",email },
                { "password", password },
               
            };

            request.AddHeader("content-type", "application/json");
            request.AddHeader("authorization", token);
            request.AddJsonBody(newElmaiModul);
            request.RequestFormat = DataFormat.Json;
            var response = client.Execute(request);
            var newEmail = JsonConvert.DeserializeObject<ClientAuthModel>(response.Content);

            return newEmail.Email;
        }
    }
}
