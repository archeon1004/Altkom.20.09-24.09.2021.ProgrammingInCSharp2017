using System;
using System.IO;
using System.Text;
using FourthCoffee.DataService.Infrastructure;
using System.Net;
using System.Net.Http;

namespace Fourth_Coffee_Contact_Finder
{
    public class SalesDataLoader
    {
        Uri _serviceUri;
        HttpWebRequest _request;
  

        public SalesDataLoader(Uri serviceUri)
        {
            if(serviceUri ==null)
                 throw new NullReferenceException("serviceUri");

            this._serviceUri = serviceUri;
        }


        public SalesPerson GetPersonByEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
                return null;

            this.InitializeRequest();

            var rawData = Encoding.Default.GetBytes(
                "{\"emailAddress\":\"" + email.Trim() + "\"}");

            _request.Method = "POST";
            _request.ContentType = "application/json";
            _request.ContentLength = rawData.Length;
          

            this.WriteDataToRequestStream(rawData);

            return this.ReadDataFromResponseStream();
        }

        public SalesPerson GetPersonByEmail2(string email)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(@"http://localhost:8090/SalesService.svc/");
            var address = new Email { emailAddress = email };
            var response = httpClient.PostAsJsonAsync("GetSalesPerson", address);
            return response.Result.Content.ReadAsAsync<SalesPerson>().Result;
        }

        private class Email
        {
            public string emailAddress { get; set; }
        }

        private void InitializeRequest()
        {

            _request = WebRequest.Create(_serviceUri.AbsoluteUri) as HttpWebRequest;
         

            if (this._request == null)
                throw new NullReferenceException("_request");
        }

        private void WriteDataToRequestStream(byte[] data)
        {
            using (var stream = _request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }
        }

        private SalesPerson ReadDataFromResponseStream()
        {
            var response = _request.GetResponse() as HttpWebResponse;

            if (response.ContentLength == 0)
                return null;

            using (var stream = response.GetResponseStream())
                return SalesPerson.FromJson(stream);
        }
    }
}
