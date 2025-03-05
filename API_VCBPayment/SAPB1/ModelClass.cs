namespace API_VCBPayment.SAPB1
{
    public class ModelClass
    {
        public class UserDto
        {
            public string UserName { get; set; } = string.Empty;
            public string Password { get; set; } = string.Empty;
            public string CompanyDB { get; set; } = string.Empty;
        }
        public class Api_Json_SessionId
        {
            public string? odatametadata { get; set; }
            public string? SessionId { get; set; }
            public string? Version { get; set; }
            public int SessionTimeout { get; set; }
            public DateTime Timeout { get; set; }
        }


        public class PaymentReturn
        {
            public Context? context { get; set; }
            public Payload? payload { get; set; }
            public string? signature { get; set; }
        }

        public class Context
        {
            public string? channelId { get; set; }
            public string? channelRefNumber { get; set; }
            public int errorCode { get; set; }
            public string? errorMessage { get; set; }
            public string? requestDateTime { get; set; }
            public string? responseMsgId { get; set; }
            public string? status { get; set; }
        }

        public class Payload
        {
        }
    }
}





