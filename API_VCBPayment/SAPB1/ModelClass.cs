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
        #region
        public class PaymentReturn
        {
            public Context? context { get; set; }
            public Payload? payload { get; set; }
            public string? signature { get; set; }
        }
        #region Error Return
        public class ReturnContext
        {
            public ContextError? context { get; set; }
            public PayloadError? payload { get; set; }
            public string? signature { get; set; }
        }

        public class ContextError
        {
            public string? channelId { get; set; }
            public string? channelRefNumber { get; set; }
            public string? errorCode { get; set; }
            public string? errorMessage { get; set; }
            public string? requestDateTime { get; set; }
            public int responseMsgId { get; set; }
            public string? status { get; set; }
        }

        public class PayloadError
        {
        }
        #endregion
        public class Payload
        {
        }
        #endregion

        #region API_Return
        public class API_Return
        {
            public int? DocNum { get; set; }
            public int? Period { get; set; }
            public int? Instance { get; set; }
            public int? Series { get; set; }
            public string? Handwrtten { get; set; }
            public string? Status { get; set; }
            public string? RequestStatus { get; set; }
            public string? Creator { get; set; }
            public object? Remark { get; set; }
            public int DocEntry { get; set; }
            public string? Canceled { get; set; }
            public string? Object { get; set; }
            public object? LogInst { get; set; }
            public int UserSign { get; set; }
            public string? Transfered { get; set; }
            public DateTime CreateDate { get; set; }
            public string? CreateTime { get; set; }
            public DateTime UpdateDate { get; set; }
            public string? UpdateTime { get; set; }
            public string? DataSource { get; set; }
            public string? U_channelId { get; set; }
            public string? U_channelRefNumber { get; set; }
            public string? U_requestDateTime { get; set; }
            public string? U_providerId { get; set; }
            public string? U_serviceId { get; set; }
            public string? U_account { get; set; }
            public float U_amount { get; set; }
            public string? U_currency { get; set; }
            public float U_currentBal { get; set; }
            public float U_availBal { get; set; }
            public float U_holdAmount { get; set; }
            public string? U_dorc { get; set; }
            public string? U_transactionTime { get; set; }
            public string? U_remark { get; set; }
            public string? U_tellerId { get; set; }
            public string? U_seqNo { get; set; }
            public DateTime? U_hostDate { get; set; }
            public DateTime? U_pcTime { get; set; }
            public string? U_branch { get; set; }
            public string? U_signature { get; set; }
            public string? U_InputJson { get; set; }
            public object? U_internalRefNo { get; set; }
        }
        #endregion
    }
}









