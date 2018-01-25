using System;
using System.IO;
using System.Net;
using System.Web.Http;
using kemenagpocService.Helper;
using Microsoft.Azure.Mobile.Server.Config;
using Newtonsoft.Json;

namespace kemenagpocService.Controllers
{
    [MobileAppController]
    public class KontakKeluargaController : ApiController
    {
        public static string sessionUrl = "/api/data/v9.0/new_kontakkeluargas";
        [Route("KontakKeluarga")]
        // GET api/KontakKeluarga
        public object Get()
        {
            string GetUserSessionOperationPath = string.Format("{0}{1}", ClientConfiguration.Default.UriString.TrimEnd('/'), sessionUrl);

            try
            {
                // Creates an HttpWebRequest for user session URL.
                HttpWebRequest aadRequest = (HttpWebRequest)WebRequest.Create(GetUserSessionOperationPath);

                // Change TLS version of HTTP request if the TLS version value is defined in ClientConfiguration
                if (!string.IsNullOrWhiteSpace(ClientConfiguration.OneBox.TLSVersion))
                {
                    aadRequest.ProtocolVersion = Version.Parse(ClientConfiguration.OneBox.TLSVersion);
                }

                string tlsRequestVersion = aadRequest.ProtocolVersion.ToString();
                Console.WriteLine("The TLS protocol version for the HTTP request is {0}.", tlsRequestVersion);

                aadRequest.Headers[OAuthHelper.OAuthHeader] = OAuthHelper.GetAuthenticationHeader();
                aadRequest.Method = "GET";
                aadRequest.ContentLength = 0;

                // Get HttpWebResponse for the response
                var aadResponse = (HttpWebResponse)aadRequest.GetResponse();

                string tlsResponseVersion = aadResponse.ProtocolVersion.ToString();
                Console.WriteLine("The TLS protocol version of the server response is {0}.", tlsResponseVersion);

                if (aadResponse.StatusCode != HttpStatusCode.OK)
                {
                    Console.WriteLine("Could not get response from the server.");
                    //return;
                }

                // Get response string
                using (Stream responseStream = aadResponse.GetResponseStream())
                {
                    using (StreamReader streamReader = new StreamReader(responseStream))
                    {
                        string responseString = streamReader.ReadToEnd();

                        Console.WriteLine(string.Format("\nSuccessfully received response.\nResponse string: {0}.", responseString));
                        aadResponse.Close();
                        object parse = JsonConvert.DeserializeObject(responseString);
                        return parse;
                    }
                }


                // Releases the resources of the response.

            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed with the exception: {0} and stack trace: {1}.", ex.ToString(), ex.StackTrace);
                throw new Exception(ex.Message);
            }

            //  Console.ReadLine();
        }
    }
}
