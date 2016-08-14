using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace PjBaySite.Services
{
    public class EmailVerification
    {
        private const string ApiUrl = @"https://api1.27hub.com/api/emh/a/v2";
        private const string QueryFormatString = @"{0}?e={1}&k={2}";
        private const string YourAPIKey = @"015A35E5";

        public static async Task<bool> IsValidEmail(string Email)
        {
            var requestUrl = string.Format(QueryFormatString, ApiUrl, Email, YourAPIKey);

            bool ret = false;

            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(requestUrl);
                    client.DefaultRequestHeaders.Accept.Clear();
                    var responseJson = await client.GetStringAsync(requestUrl);
                    var res = JObject.Parse(responseJson);
                    ret = res["result"].ToString() == "Ok";
                }
            }
            catch (Exception exception)
            {
                return true;
            }

            return ret;
        }
    }
}
