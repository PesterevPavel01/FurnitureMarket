using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;

namespace InterfaceApplication.Services.Api
{
    public class HttpConnector
    {
        private const string Host = "https://localhost:7104/api/";

        public Task<string> GetDataByUrl(string url)
        {
            string result = string.Empty;

            WebRequest request = WebRequest.Create(Host + url);

            request.Method = "GET";

            WebResponse response = request.GetResponse();

            using (StreamReader reader = new StreamReader(response.GetResponseStream(),Encoding.UTF8)) 
            {
                string responseStr=reader.ReadToEnd(); 
                result = responseStr;
            }
            return Task.FromResult(result);
        }

        public async Task<String> GetDataByUrlAsync(string url, string bodyData, HttpMethod method)
        {

            string result = string.Empty;

            WebRequest request = WebRequest.Create(Host + url);

            request.ContentType = "application/json";

            request.Method = method.Method;

            using (var streamWriter = new StreamWriter(request.GetRequestStream(), Encoding.UTF8))
            {
                await streamWriter.WriteAsync(bodyData);
            }

            var httpResponse = (HttpWebResponse)request.GetResponse();

            using (StreamReader reader = new StreamReader(httpResponse.GetResponseStream(), Encoding.UTF8))
            {
                string responseStr = await reader.ReadToEndAsync();
                result = responseStr;
            }

            return result;
        }

        public async Task<string> DoActionWithDataByUrl(string url, string data,HttpMethod method) 
        { 
            HttpResponseMessage result = new HttpResponseMessage();

            HttpClient client = new HttpClient();

            var content = new StringContent(data, Encoding.UTF8, "application/json");

            if(method == HttpMethod.Post) 
            {
                result=client.PostAsync(Host + url, content).Result;
            }
            else if(method == HttpMethod.Patch)
            {
                result = client.PatchAsync(Host + url, content).Result;
            }
            else if (method == HttpMethod.Delete) 
            {
                var request = new HttpRequestMessage(HttpMethod.Delete, Host + url);
                request.Content = content;

                result = client.SendAsync(request).Result;
            }

            var resultContent=result.Content;

            string jsonContent = resultContent.ReadAsStringAsync().Result;

            return jsonContent;
        }
    }
}
