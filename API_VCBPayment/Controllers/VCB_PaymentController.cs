using Microsoft.AspNetCore.Mvc;
using System.Net;
using API_VCBPayment.SAPB1;
using Newtonsoft.Json;
using static API_VCBPayment.SAPB1.ModelClass;

#pragma warning disable CS8602 // Dereference of a possibly null reference.
namespace API_VCBPayment.Controllers
{
    [ApiController]
    [Route("/api")]
    public class VCB_PaymentController : Controller
    {
        public List<Api_Json_SessionId> ApiJsonSessionId = new List<Api_Json_SessionId>();
        public VCB_PaymentController()
        {

        }
        [HttpPost("/VCBPayment/AccountAdvice")]
        public IActionResult AccountAdvice(AccountAdvice BodyJson)
        {
            try
            {
                List<ReturnContext> ReturnContext = new List<ReturnContext>();
                if (string.IsNullOrEmpty(BodyJson.context.channelId) || BodyJson.context.channelId.ToString() == "string")
                {
                    var Error = Login.API_Return(BodyJson.context.channelId.ToString(), BodyJson.context.channelId.ToString(), 21, "FIELD_VALUE_ERROR", 0, "Giá trị các trường thông tin không hợp lệ", "");
                    return StatusCode(200, Error);
                }

                bool signature = Login.VerifyMD5Hash(BodyJson.context.channelId + "|" + BodyJson.context.channelRefNumber + "|" + "Simon@VCBPayment2503", BodyJson.signature.ToString());
                if (signature == true)
                {
                    #region Add MIncomingPayments
                    var _PostIncoming = new MIncomingPayments()
                    {
                        DocType = "rCustomer",
                        CardCode = "",
                        BPLID = "1",
                        TransferAccount = "",
                        TransferSum = 0,
                        TransferDate = "",
                        ControlAccount = ""

                    };
                    var MIncomingPayments = JsonConvert.SerializeObject(_PostIncoming);
                    var IncomingPayments = Login.API_POST(MIncomingPayments, "IncomingPayments", "", "",null);
                    #endregion

                    #region Log AccountAdvice
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
                        U_DocNum = null,
                    };
                    var ACCOUNTADVICE = JsonConvert.SerializeObject(_SAP_AccountAdvice);
                    var _API_POST = Login.API_POST(ACCOUNTADVICE, "ACCOUNTADVICE", BodyJson.context.channelId.ToString(), BodyJson.context.channelRefNumber.ToString(),null);
                    #endregion

                    return Ok(_API_POST);
                }
                else
                {
                    var Error = Login.API_Return(BodyJson.context.channelId.ToString(), BodyJson.context.channelId.ToString(), 18, "INVALID_SIGNATURE", 0, "Chữ ký không hợp lệ", "");
                    return StatusCode(200, Error);
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
        }

        [HttpPost("BusinessPartners")]
        public IActionResult BusinessPartners(JsonBusinessPartners BodyJson)
        {

            try
            {
                var FormDate = (BodyJson.FromDate).ToString("yyyy-MM-dd");
                var ToDate = (BodyJson.ToDate).ToString("yyyy-MM-dd");
                var BusinessPartners = Login.API_GET(FormDate, ToDate);
                return Ok(BusinessPartners);
            }
            catch (WebException ex)
            {
                using (var stream = ex.Response.GetResponseStream())
                using (var reader = new StreamReader(stream))
                {
                    return StatusCode(400, "BAD_REQUEST");
                }


            }


        }

        [HttpPost("NotifyTrans")]
        public IActionResult NotifyTrans(MNotifyTrans BodyJson)
        {
            try
            {
                var re = Request;
                var headers = re.Headers;
                string Headersignature = string.Empty;

                var x_ibm_client_secret = Request.Headers.Keys.Where(it => it.Contains("x-ibm-client-secret")).FirstOrDefault();
                var x_ibm_client_id = Request.Headers.Keys.Where(it => it.Contains("x-ibm-client-id")).FirstOrDefault();
                var x_ibm_client_secretValue = Request.Headers.Values.Where(it => it.Contains("2cd7b943f4d7c5115d44b81487497ae3")).FirstOrDefault();
                var x_ibm_client_idValue = Request.Headers.Values.Where(it => it.Contains("fbbf1989a3ad0de68446317f5f104df0")).FirstOrDefault();
                //if ((x_ibm_client_secret != "x-ibm-client-secret" && x_ibm_client_secretValue != "2cd7b943f4d7c5115d44b81487497ae3") || (x_ibm_client_id != "x-ibm-client-id" && x_ibm_client_idValue != "fbbf1989a3ad0de68446317f5f104df0"))
                //{
                //    return StatusCode(StatusCodes.Status401Unauthorized, new { httpCode = "401", httpMessage = "Unauthorized", moreInformation = "Invalid client id or secret." });
                //}
                //string cerFilePath = "D:\\TAMKIM\\BA\\SimonERPNotifyTrans\\SimonERPNotifyTrans\\bin\\Debug\\net7.0\\opensuse.15.1-x64\\publish\\TEST_VIETINBANK_CERT_NOTIFY.txt";
                string cerFilePath = "/usr/sap/Simon_NotifyTrans/TEST_VIETINBANK_CERT_NOTIFY.txt";
                Headersignature = BodyJson.transId + BodyJson.transTime + BodyJson.custCode + BodyJson.amount +
                        BodyJson.bankTransId +
                        BodyJson.remark;
                var _Boool = Certificate.Verify(Headersignature, BodyJson.signature, cerFilePath);
                if (_Boool == false)
                {
                    //return StatusCode(StatusCodes.Status400BadRequest, new { code = 1, message = "Verify string error. Please check secret key. Verify string is invalid." });
                }

                List<NOTR_LCollection> NOTR_Lcollection = new List<NOTR_LCollection>();
                List<MInsertNotifyTrans> MInsertNotifyTrans = new List<MInsertNotifyTrans>();
                NOTR_LCollection _NOTR_Lcollection = new NOTR_LCollection()
                {
                    U_transId = BodyJson.transId == null ? "" : BodyJson.transId,
                    U_transTime = BodyJson.transTime == null ? "" : BodyJson.transTime,
                    U_transType = BodyJson.transType == null ? "" : BodyJson.transType,
                    U_custCode = BodyJson.custCode == null ? "" : BodyJson.custCode,
                    U_sendBankId = BodyJson.sendBankId == null ? "" : BodyJson.sendBankId,
                    U_sendBranchId = BodyJson.sendBranchId == null ? "" : BodyJson.sendBranchId,
                    U_sendAcctId = BodyJson.sendAcctId == null ? "" : BodyJson.sendAcctId,
                    U_sendAcctName = BodyJson.sendAcctName == null ? "" : BodyJson.sendAcctName,
                    U_recvAcctId = BodyJson.recvAcctId == null ? "" : BodyJson.recvAcctId,
                    U_recvAcctName = BodyJson.recvAcctName == null ? "" : BodyJson.recvAcctName,
                    U_recvVirtualAcctId = BodyJson.recvVirtualAcctId == null ? "" : BodyJson.recvVirtualAcctId,
                    U_amount = BodyJson.amount == null ? "" : BodyJson.amount,
                    U_bankTransId = BodyJson.bankTransId == null ? "" : BodyJson.bankTransId,
                    U_remark = BodyJson.remark == null ? "" : BodyJson.remark,
                    U_currencyCode = BodyJson.currencyCode == null ? "" : BodyJson.currencyCode,
                };
                NOTR_Lcollection.Add(_NOTR_Lcollection);
                MInsertNotifyTrans _MInsertNotifyTrans = new MInsertNotifyTrans()
                {
                    Code = BodyJson.msgId == null ? "" : BodyJson.msgId,
                    U_providerId = BodyJson.providerId == null ? "" : BodyJson.providerId,
                    U_signature = BodyJson.signature == null ? "" : BodyJson.signature,
                };
                MInsertNotifyTrans.Add(_MInsertNotifyTrans);
                _MInsertNotifyTrans.NOTR_LCollection = NOTR_Lcollection;

                var JsonInput = JsonConvert.SerializeObject(_MInsertNotifyTrans);
                var NOTR = Login.API_POST(JsonInput, "NOTR", "", "", BodyJson);

                return Ok("NOTR");

            }
            catch (WebException)
            {
                var error = new { Message = "Something went wrong", Code = "SAP" };
                return StatusCode(400, error);
            }


        }
    }
}
