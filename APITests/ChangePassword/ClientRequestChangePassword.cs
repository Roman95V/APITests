using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APITests.ChangePassword
{
    public class ClientRequestChangePassword
    {
        public string SendRequestClientPasswordPost(string password, string newpassword, string token)
        {
            var client = new RestClient("https://api.newbookmodels.com/api/v1/password/change/");
            var request = new RestRequest(Method.POST);
            var newPasswordModul = new Dictionary<string, string>
            {
                { "password", password },
                { "password1", newpassword },
               
            };

            request.AddHeader("content-type", "application/json");
            request.AddHeader("authorization", token);
            request.AddJsonBody(newPasswordModul);
            request.RequestFormat = DataFormat.Json;
            var response = client.Execute(request);
            var newPassword = JsonConvert.DeserializeObject<ClientAuthModel>(response.Content);

            return newPassword.NewPassword;
        }
    }
}
