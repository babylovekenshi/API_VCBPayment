using Microsoft.AspNetCore.Mvc;
using System.Net;
using API_VCBPayment.SAPB1;
using Newtonsoft.Json;
using static API_VCBPayment.SAPB1.ModelClass;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.IO;
#pragma warning disable CS8602 // Dereference of a possibly null reference.
namespace API_VCBPayment.Controllers
{
    [ApiController]
    [Route("api/VCBPayment")]
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

                var _Login = Login.LogIn();
                var _API_POST = Login.API_POST("string ApiMESCD", "ACCOUNTADVICE");

                //var data = 0;
                return Ok(_API_POST);
            }
            catch (WebException ex)
            {
                using (var stream = ex.Response.GetResponseStream())
                using (var reader = new StreamReader(stream))
                {
                    return Ok(reader.ReadToEnd());

                }
            }
#pragma warning restore CS8602 // Dereference of a possibly null reference.
        }



        
    }
}
