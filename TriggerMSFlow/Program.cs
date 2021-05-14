using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace TriggerMSFlow
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Program program = new Program();
            //await program.SendEmailForCodeVerificationAsync(174582, "info@jd-bots.com", "JD Bots", "https://prod-02.centralindia.logic.azure.com:443/workflows/<your Power Automate POST URI>");
            await program.SaveNameInDataVerseAsync("Ajay", "Garg", "https://prod-19.centralindia.logic.azure.com:443/workflows/968c7cf4f4244f7fa90173e6d57e70c5/triggers/manual/paths/invoke?api-version=2016-06-01&sp=%2Ftriggers%2Fmanual%2Frun&sv=1.0&sig=etCxOzADwL1s3X7vn3977LJ_6cskXLK5TLH5DOaoCfI");
        }
        //public async Task SendEmailForCodeVerificationAsync(int verificationCode, string toAddress, string username, string uri)
        //{
        //    try
        //    {
        //        HttpClient client = new HttpClient();
        //        client.BaseAddress = new Uri(uri);
        //        client.DefaultRequestHeaders.Accept.Clear();
        //        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        //        HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, client.BaseAddress);
        //        var body = $"{{\"emailAddress\": \"{toAddress}\",\"emailSubject\":\"[NaamiChocos] Email Verification Code\",\"userName\":\"{username}\",\"OTP\":\"{verificationCode}\"}}";
        //        var content = new StringContent(body, Encoding.UTF8, "application/json");
        //        request.Content = content;
        //        var response = await MakeRequestAsync(request, client);
        //        Console.WriteLine(response);


        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e.Message);
        //        throw new Exception();
        //    }
        //}

        public async Task SaveNameInDataVerseAsync(string firstName, string lastName, string uri)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(uri);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, client.BaseAddress);
                var body = $"{{\"firstname\": \"{firstName}\",\"lastname\":\"{lastName}\"}}";
                var content = new StringContent(body, Encoding.UTF8, "application/json");
                request.Content = content;
                var response = await MakeRequestAsync(request, client);
                Console.WriteLine(response);


            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw new Exception();
            }
        }
        public async Task<string> MakeRequestAsync(HttpRequestMessage getRequest, HttpClient client)
        {
            var response = await client.SendAsync(getRequest).ConfigureAwait(false);
            var responseString = string.Empty;
            try
            {
                response.EnsureSuccessStatusCode();
                responseString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            }
            catch (HttpRequestException)
            {
                // empty responseString
            }

            return responseString;
        }
    }
}
