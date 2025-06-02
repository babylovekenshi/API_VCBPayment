using Newtonsoft.Json;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using static API_VCBPayment.SAPB1.ModelClass;
#pragma warning disable CS8602 // Dereference of a possibly null reference.
#pragma warning disable CS8603 // Possible null reference return.
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
#pragma warning disable SYSLIB0014 // Type or member is obsolete
#pragma warning disable SYSLIB0014 // Type or member is obsolete
namespace API_VCBPayment.SAPB1
{

    public class Login
    {


        public static List<Api_Json_SessionId> LogIn()
        {
            List<Api_Json_SessionId>? ApiJsonSessionId = new List<Api_Json_SessionId>();
            try
            {
                string? IPServer;
                IPServer = "117.4.122.18";//GetLocalIPAddress();
                UserDto _NewUser = new UserDto
                {
                    UserName = "manager",
                    Password = "Admin@123",
                    CompanyDB = "SIMON_TEST08042025",
                };
                var NewUserJson = JsonConvert.SerializeObject(_NewUser);


                var httpWebRequest = (HttpWebRequest)WebRequest.Create($"https://{IPServer}:50000/b1s/v1/Login");

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
            }
        }
        public static string API_PATCH(string Input_PATCH, string TableName, string DocNum)
        {
            string? IPServer = "117.4.122.18";//GetLocalIPAddress();
#pragma warning disable SYSLIB0014 // Type or member is obsolete
            var httpWebRequestMESLSX = (HttpWebRequest)WebRequest.Create($"https://{IPServer}:50000/b1s/v1/{TableName}({DocNum})");
#pragma warning restore SYSLIB0014 // Type or member is obsolete
            httpWebRequestMESLSX.ContentType = "application/json";
            httpWebRequestMESLSX.Method = "PATCH";
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
            { streamWriter.Write(Input_PATCH); }
            try
            {
                var httpResponseMESCD = (HttpWebResponse)httpWebRequestMESLSX.GetResponse();
                string Error = string.Empty;
                using (var streamReaderMESCD = new StreamReader(httpResponseMESCD.GetResponseStream()))
                {
    
                    return Error;
                }

            }
            catch (WebException ex)
            {
                using (var stream = ex.Response.GetResponseStream())
                using (var reader = new StreamReader(stream))
                {
                    
                    return reader.ReadToEnd();
                }
            }
        }
        public static string API_POST(string ApiMESCD, string TableName, string channelId, string channelRefNumber, MNotifyTrans BodyJson)
        {
            if (LogIn().ToList().Count() == 0)
            {
                LogIn();
            }
            string? IPServer = "117.4.122.18";//GetLocalIPAddress();

#pragma warning disable SYSLIB0014 // Type or member is obsolete
            var httpWebRequestMESLSX = (HttpWebRequest)WebRequest.Create($"https://{IPServer}:50000/b1s/v1/{TableName}");


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


            cookies.Add(new Cookie("B1SESSION", LogIn().FirstOrDefault().SessionId) { Domain = IPServer });


            cookies.Add(new Cookie("ROUTEID", ".node1") { Domain = IPServer });
            httpWebRequestMESLSX.CookieContainer = cookies;

            using (var streamWriter = new StreamWriter(httpWebRequestMESLSX.GetRequestStream()))
            { streamWriter.Write(ApiMESCD); }
            try
            {
                var httpResponseMESCD = (HttpWebResponse)httpWebRequestMESLSX.GetResponse();
                string Error = string.Empty;
                using (var streamReaderMESCD = new StreamReader(httpResponseMESCD.GetResponseStream()))
                {
                    var resultMESLSX = streamReaderMESCD.ReadToEnd();
                    if (TableName == "ACCOUNTADVICE")
                    {
                        
                        Console.WriteLine(resultMESLSX);
                        var SAP_API_Return = JsonConvert.DeserializeObject<API_Return>(resultMESLSX);
                        int SAP_channelRefNumber = SAP_API_Return.DocEntry;
                        Error = Login.API_Return(channelId.ToString(), channelRefNumber.ToString(), 0, "Success", SAP_channelRefNumber, "Truy vấn, thanh toán thành công", "");
                    }
                    if(TableName == "NOTR")
                    {
                        string errorcode = "00", errormessage = "Nhận giao dịch thành công";
                        string signature = string.Empty;
                        signature += channelId + errorcode + errormessage;
                        var cerFilePathEncrypt = "/usr/sap/API_VCB_PAYMENT_PRD/SimonERP_Hana.p12";
                        var cerFilePath1 = "/usr/sap/API_VCB_PAYMENT_PRDT/SimonERP_Hana.cer";
                        var StringEncryptSHA256 = Certificate.EncryptSHA256(signature, cerFilePathEncrypt);
                        var boolVerify = Certificate.Verify(signature, StringEncryptSHA256, cerFilePath1);

                        var _JsonReturnNotifytrans = JsonConvert.DeserializeObject<JsonReturnNT>(JsonConvert.SerializeObject(BodyJson));

                        _JsonReturnNotifytrans.errorCode = errorcode;
                        _JsonReturnNotifytrans.errorDesc = errormessage;
                        _JsonReturnNotifytrans.signature = StringEncryptSHA256;

                        Error = _JsonReturnNotifytrans.ToString();

                    }
                    //if (TableName == "IncomingPayments")
                    //{
                    //    var SAP_IncomingPayment_Return = JsonConvert.DeserializeObject<IncomingPayment>(resultMESLSX);
                    //    API_PATCH("{\"U_DocNum\": \"MBVCB.6960980.B T T chuyen tien.CT tu 0011000994178 BTT toi 0011004110847 C N O VIETC1\"}", "IncomingPayments", SAP_IncomingPayment_Return.DocNum.ToString());
                    //    Error = SAP_IncomingPayment_Return.DocNum.ToString();
                    //}


                    return Error;


                }

            }
            catch (WebException ex)
            {
                using (var stream = ex.Response.GetResponseStream())
                using (var reader = new StreamReader(stream))
                {
                    string Error = string.Empty;

                    if (TableName == "ACCOUNTADVICE")
                    {
                        Error = Login.API_Return(channelId.ToString(), channelRefNumber.ToString(), 400, "BAD_REQUEST", 0, "BAD_REQUEST", "");
                    }
                    if (TableName == "NOTR")
                    {
                        var data = new
                        {
                            errorcode = "99",
                            errormessage = "Lỗi không xác định",
                        };
                        Error = JsonConvert.SerializeObject(data).ToString();
                    }
                    return (Error);
                }
            }
        }

        public static string API_GET(string FormDate, string ToDate)
        {
            try
            {
                if (LogIn().ToList().Count() == 0)
                {
                    Login.LogIn();
                }
                string? IPServer = "117.4.122.18";
#pragma warning disable SYSLIB0014 // Type or member is obsolete
                var httpWebRequest = (HttpWebRequest)WebRequest.Create($"https://{IPServer}:50000/b1s/v1/BusinessPartners?$select=CardCode,CardName,CardType&$filter=CreateDate ge datetime'{FormDate}' AND  CreateDate le datetime'{ToDate}'&$orderby=CardCode");
#pragma warning restore SYSLIB0014 // Type or member is obsolete
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "GET";
                httpWebRequest.KeepAlive = true;
                httpWebRequest.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => true;
                httpWebRequest.Headers.Add("B1S-WCFCompatible", "true");
                httpWebRequest.Headers.Add("B1S-MetadataWithoutSession", "true");
                httpWebRequest.Headers.Add("Prefer", "odata.maxpagesize=2000");
                httpWebRequest.Accept = "*/*";
                httpWebRequest.ServicePoint.Expect100Continue = false;
                httpWebRequest.Headers.Add("Accept-Encoding", "gzip, deflate, br");
                httpWebRequest.AutomaticDecompression = DecompressionMethods.GZip;
                CookieContainer cookies = new CookieContainer();
                cookies.Add(new Cookie("B1SESSION", LogIn().ToList().FirstOrDefault().SessionId) { Domain = IPServer });
                cookies.Add(new Cookie("ROUTEID", ".node1") { Domain = IPServer });
                httpWebRequest.CookieContainer = cookies;

                //using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))


                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();

                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    Console.WriteLine(result);

                    string cerFilePath = "/usr/sap/Simon_NotifyTrans/SimonERP_Hana.cer";
                    string cerFilePathEncrypt = "/usr/sap/Simon_NotifyTrans/SimonERP_Hana.p12";
                    var StringEncryptSHA256 = Certificate.EncryptSHA256("AoCZLV57NJy2X6PfCGWOX0AOdTEENFca", cerFilePathEncrypt);
                    var boolVerify = Certificate.Verify("AoCZLV57NJy2X6PfCGWOX0AOdTEENFca", StringEncryptSHA256, cerFilePath);
                    if (boolVerify == false)
                    {
                        var VietTinReturn = new
                        {
                            code = 1,
                            message = "Verify string error. Please check secret key. Verify string is invalid."
                        };
                        var Error = JsonConvert.SerializeObject(VietTinReturn).ToString();
                        return Error;
                    }
                    else
                    {


                        var COnvertJson = JsonConvert.DeserializeObject<JsonReturnBP>(result);
                        COnvertJson.signature = StringEncryptSHA256;
                        var error = COnvertJson.ToString();
                        return error.ToString();
                    }
                }

            }
            catch (Exception ex)
            {
                var Error = ex.Message.ToString();
                return Error ;
            }
        }



        #region

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
        public static string ComputeMD5Hash(string input)
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
        public static bool VerifyHMACMD5(string input, string secretKey, string expectedHash)
        {
            using (HMACMD5 hmac = new HMACMD5(Encoding.UTF8.GetBytes(secretKey)))
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(input);
                byte[] hashBytes = hmac.ComputeHash(inputBytes);
                string computedHash = BitConverter.ToString(hashBytes).Replace("-", "").ToLower();

                return computedHash == expectedHash.ToLower();
            }
        }

        public static string API_Return(string channelId, string channelRefNumber, int errorCode, string errorMessage, int responseMsgId, string status, string signature1)
        {
            string Input = channelId + "|" + channelRefNumber + "|" + responseMsgId + "|" + "Simon@VCBPayment2503";
            string _ComputeMD5Hash = ComputeMD5Hash(Input);
            bool signature = Login.VerifyMD5Hash(Input, _ComputeMD5Hash.ToString());

            List<ReturnContext> ReturnContext = new List<ReturnContext>();
            var _ContextError = new ContextError()
            {
                channelId = channelId,
                channelRefNumber = channelRefNumber,
                errorCode = errorCode.ToString(),
                errorMessage = errorMessage,
                requestDateTime = DateTime.Now.ToString("dd-mm-yyyy HH24:MI:SS"),
                responseMsgId = responseMsgId,
                status = status,
            };
            var _PayloadError = new PayloadError()
            {

            };
            var _ReturnContext = new ReturnContext()
            {
                context = null,
                payload = null,
                signature = _ComputeMD5Hash
            };
            _ReturnContext.context = _ContextError;
            _ReturnContext.payload = _PayloadError;
            return JsonConvert.SerializeObject(_ReturnContext).ToString();
        }

        #endregion

    }
}
