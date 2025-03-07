using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.IO;
using System.Net;
using System.Reflection.PortableExecutable;
using System.Security.Cryptography;
using System.Text;
using static API_VCBPayment.SAPB1.ModelClass;
using static System.Net.Mime.MediaTypeNames;

namespace API_VCBPayment.SAPB1
{

    public class Login
    {

        public string? IPServer = "117.4.122.18";
        public static List<Api_Json_SessionId> LogIn()
        {
            List<Api_Json_SessionId>? ApiJsonSessionId = new List<Api_Json_SessionId>();
            try
            {
#pragma warning disable CS8602 // Dereference of a possibly null reference.

                string? IPServer;
                IPServer = "117.4.122.18";//GetLocalIPAddress();
                UserDto _NewUser = new UserDto
                {
                    UserName = "manager",
                    Password = "Admin@123",
                    CompanyDB = "SIMON_TEST",
                };
                var NewUserJson = JsonConvert.SerializeObject(_NewUser);

#pragma warning disable SYSLIB0014 // Type or member is obsolete
                var httpWebRequest = (HttpWebRequest)WebRequest.Create($"https://{IPServer}:50000/b1s/v1/Login");
#pragma warning restore SYSLIB0014 // Type or member is obsolete
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";
                httpWebRequest.KeepAlive = true;
                httpWebRequest.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => true;
                //ServicePointManager.SecurityProtocol = (SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 ); ;
                //httpWebRequest.ServicePoint.SetTcpKeepAlive(true,30,40);
                httpWebRequest.Headers.Add("B1S-WCFCompatible", "true");
                httpWebRequest.Headers.Add("B1S-MetadataWithoutSession", "true");
                httpWebRequest.Accept = "*/*";
                httpWebRequest.ServicePoint.Expect100Continue = false;
                httpWebRequest.Headers.Add("Accept-Encoding", "gzip, deflate, br");
                httpWebRequest.AutomaticDecompression = DecompressionMethods.GZip;

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                { streamWriter.Write(NewUserJson); }

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();

                    var Obj = JsonConvert.DeserializeObject<Api_Json_SessionId?>(result);
                    var _InSessionId = new Api_Json_SessionId()
                    {
                        SessionId = Obj.SessionId,
                        SessionTimeout = Obj.SessionTimeout,
                        Timeout = System.DateTime.Now.AddMinutes(Obj.SessionTimeout),
                    };


                    ApiJsonSessionId.Add(_InSessionId);

                    return ApiJsonSessionId;
                }
            }
            catch (WebException ex)
            {

                using (var stream = ex.Response.GetResponseStream())
                using (var reader = new StreamReader(stream))
                {
                    return ApiJsonSessionId;
                }
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            }
        }
#pragma warning disable CS8602 // Dereference of a possibly null reference.
        public static string API_POST(string ApiMESCD, string TableName, string channelId, string channelRefNumber)
        {
            if (LogIn().ToList().Count() == 0)
            {
                Login.LogIn();
            }
            List<PaymentReturn> PaymentReturn = new List<PaymentReturn>();
            List<ReturnContext> ReturnContext = new List<ReturnContext>();
            string? IPServer = "117.4.122.18";
#pragma warning disable SYSLIB0014 // Type or member is obsolete
            var httpWebRequestMESLSX = (HttpWebRequest)WebRequest.Create($"https://{IPServer}:50000/b1s/v1/{TableName}");
#pragma warning restore SYSLIB0014 // Type or member is obsolete
            httpWebRequestMESLSX.ContentType = "application/json";
            httpWebRequestMESLSX.Method = "POST";
            httpWebRequestMESLSX.KeepAlive = true;
            httpWebRequestMESLSX.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => true;
            httpWebRequestMESLSX.Headers.Add("B1S-WCFCompatible", "true");
            httpWebRequestMESLSX.Headers.Add("B1S-MetadataWithoutSession", "true");
            httpWebRequestMESLSX.Accept = "*/*";
            httpWebRequestMESLSX.ServicePoint.Expect100Continue = false;
            httpWebRequestMESLSX.Headers.Add("Accept-Encoding", "gzip, deflate, br");
            httpWebRequestMESLSX.AutomaticDecompression = DecompressionMethods.GZip;
            CookieContainer cookies = new CookieContainer();

            cookies.Add(new Cookie("B1SESSION", LogIn().ToList().FirstOrDefault().SessionId) { Domain = IPServer });

            cookies.Add(new Cookie("ROUTEID", ".node1") { Domain = IPServer });
            httpWebRequestMESLSX.CookieContainer = cookies;

            using (var streamWriter = new StreamWriter(httpWebRequestMESLSX.GetRequestStream()))
            { streamWriter.Write(ApiMESCD); }
            try
            {
                var httpResponseMESCD = (HttpWebResponse)httpWebRequestMESLSX.GetResponse();

                using (var streamReaderMESCD = new StreamReader(httpResponseMESCD.GetResponseStream()))
                {
                    var resultMESLSX = streamReaderMESCD.ReadToEnd();
                    Console.WriteLine(resultMESLSX);

                    var _ReturnContext = new ReturnContext()
                    {
                        channelId = channelId,
                        channelRefNumber = channelRefNumber,
                        errorCode = 0,
                        errorMessage = "SUCCESS",
                        requestDateTime = DateTime.Now.ToString("dd-mm-yyyy HH24:MI:SS"),
                        responseMsgId = "",
                        status = "SUCCESS",
                    };
                    return JsonConvert.SerializeObject(_ReturnContext);
                }

            }
            catch (WebException ex)
            {
                using (var stream = ex.Response.GetResponseStream())
                using (var reader = new StreamReader(stream))
                {
                    var _ReturnContext = new ReturnContext()
                    {
                        channelId = channelId,
                        channelRefNumber = channelRefNumber,
                        errorCode = 1,
                        errorMessage = "FAILURE",
                        requestDateTime = DateTime.Now.ToString("dd-mm-yyyy HH24:MI:SS"),
                        responseMsgId = "",
                        status = "FAILURE",
                    };
                    return JsonConvert.SerializeObject(_ReturnContext);
                }
            }
        }
#pragma warning restore CS8602 // Dereference of a possibly null reference.
        static string GetLocalIPAddress()
        {
            string hostName = Dns.GetHostName();
            var hostAddresses = Dns.GetHostAddresses(hostName);

            foreach (var ip in hostAddresses)
            {
                if (ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }

            return "Không tìm thấy địa chỉ IP!";
        }
        static string ComputeMD5Hash(string input)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                // Convert byte array to hexadecimal string
                StringBuilder sb = new StringBuilder();
                foreach (byte b in hashBytes)
                {
                    sb.Append(b.ToString("x2")); // Converts byte to lowercase hexadecimal
                }
                return sb.ToString();
            }
        }
        public static bool VerifyMD5Hash(string input, string hash)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                StringBuilder sb = new StringBuilder();
                foreach (byte b in hashBytes)
                {
                    sb.Append(b.ToString("x2"));
                }

                return sb.ToString().Equals(hash, StringComparison.OrdinalIgnoreCase);
            }
        }

        public static string API_Return(string channelId, string channelRefNumber, int errorCode, string errorMessage)
        {
            var _ReturnContext = new ReturnContext()
            {
                channelId = channelId,
                channelRefNumber = channelRefNumber,
                errorCode = 0,
                errorMessage = "FAILURE",
                requestDateTime = DateTime.Now.ToString("dd-mm-yyyy HH24:MI:SS"),
                responseMsgId = "",
                status = "FAILURE",
            };
            var s = JsonConvert.SerializeObject(_ReturnContext).ToString();
            return Ok(JsonConvert.SerializeObject(_ReturnContext).ToString());
        }
    }
}
