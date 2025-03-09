using Microsoft.AspNetCore.Mvc;
using System.Net;
using API_VCBPayment.SAPB1;
using Newtonsoft.Json;
using static API_VCBPayment.SAPB1.ModelClass;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.IO;
using System.Threading.Channels;
using System.Reflection.PortableExecutable;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Http.HttpResults;
#pragma warning disable CS8602 // Dereference of a possibly null reference.
namespace API_VCBPayment.Controllers
{
    [ApiController]
    [Route("/api/VCBPayment/")]
    public class VCB_PaymentController : Controller
    {
        public List<Api_Json_SessionId> ApiJsonSessionId = new List<Api_Json_SessionId>();
        public VCB_PaymentController()
        {
            
        }
        [HttpPost("AccountAdvice")]
        public IActionResult AccountAdvice(AccountAdvice BodyJson)
        {
            try
            {
                List<ReturnContext> ReturnContext = new List<ReturnContext>();
                if (string.IsNullOrEmpty(BodyJson.context.channelId) || BodyJson.context.channelId.ToString() == "string")
                {
                    var Error = Login.API_Return(BodyJson.context.channelId.ToString(), BodyJson.context.channelId.ToString(), 1, "FAILURE", "");
                    return Ok(Error);
                }
                List<SAP_AccountAdvice> SAP_AccountAdvice = new List<SAP_AccountAdvice>();
                var _SAP_AccountAdvice = new SAP_AccountAdvice()
                {
                    U_channelId = BodyJson.context.channelId,
                    U_channelRefNumber = BodyJson.context.channelRefNumber,
                    U_requestDateTime = BodyJson.context.requestDateTime,
                    U_providerId = BodyJson.payload.providerId,
                    U_serviceId = BodyJson.payload.serviceId,
                    U_account = BodyJson.payload.account,
                    U_amount = float.Parse(BodyJson.payload.amount.ToString()),
                    U_currency = BodyJson.payload.currency,
                    U_currentBal = float.Parse(BodyJson.payload.currentBal.ToString()),
                    U_availBal = float.Parse(BodyJson.payload.availBal.ToString()),
                    U_holdAmount = float.Parse(BodyJson.payload.holdAmount.ToString()),
                    U_dorc = BodyJson.payload.dorc,
                    U_transactionTime = BodyJson.payload.transactionTime,
                    U_remark = BodyJson.payload.remark,
                    U_tellerId = BodyJson.payload.hostInfo.tellerId,
                    U_seqNo = BodyJson.payload.hostInfo.seqNo,
                    U_hostDate = DateTime.Now,
                    U_pcTime = DateTime.Now,
                    U_branch = BodyJson.payload.hostInfo.branch,
                    U_signature = BodyJson.signature,
                    U_InputJson = JsonConvert.SerializeObject(BodyJson),
                    U_internalRefNo = null,
                };
                bool signature = Login.VerifyMD5Hash(BodyJson.signature.ToString(), System.IO.File.ReadAllText(@"/usr/sap/API_VCB_PAYMENT/VerifyMD5Hash.txt"));
                if (signature == true)
                {
                    var ACCOUNTADVICE = JsonConvert.SerializeObject(_SAP_AccountAdvice);
                    var _API_POST = Login.API_POST(ACCOUNTADVICE, "ACCOUNTADVICE", BodyJson.context.channelId.ToString(), BodyJson.context.channelRefNumber.ToString());
                    return Ok(_API_POST);
                }
                else
                {
                    var Error = Login.API_Return(BodyJson.context.channelId.ToString(), BodyJson.context.channelId.ToString(), 1, "FAILURE", "");
                    return Ok(Error);
                }              
            }
            catch (WebException ex)
            {
                using (var stream = ex.Response.GetResponseStream())
                using (var reader = new StreamReader(stream))
                {
                    return StatusCode(400, "BAD_REQUEST");

                }
            }
#pragma warning restore CS8602 // Dereference of a possibly null reference.
        }

        [HttpGet]
        public IActionResult health()
        {
            return Ok(new { message = "API is working!" });
        }


    }
}
