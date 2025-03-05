namespace API_VCBPayment
{
    public class AccountAdvice
    {
        public Context? context { get; set; }
        public Payload? payload { get; set; }
        public string? signature { get; set; }
    }

    public class Context
    {
        public string? channelId { get; set; }
        public string? channelRefNumber { get; set; }
        public string? requestDateTime { get; set; }
    }

    public class Payload
    {
        public string? providerId { get; set; }
        public string? serviceId { get; set; }
        public string? account { get; set; }
        public string? amount { get; set; }
        public string? currency { get; set; }
        public string? currentBal { get; set; }
        public string? availBal { get; set; }
        public string? holdAmount { get; set; }
        public string? dorc { get; set; }
        public string? transactionTime { get; set; }
        public string? remark { get; set; }
        public Hostinfo? hostInfo { get; set; }
    }

    public class Hostinfo
    {
        public string? tellerId { get; set; }
        public string? seqNo { get; set; }
        public string? branch { get; set; }
    }



    public class SAP_AccountAdvice
    {
        public int DocNum { get; set; }
        public string? U_channelId { get; set; }
        public object? U_channelRefNumber { get; set; }
        public object? U_requestDateTime { get; set; }
        public object? U_providerId { get; set; }
        public object? U_serviceId { get; set; }
        public object? U_account { get; set; }
        public float? U_amount { get; set; }
        public object? U_currency { get; set; }
        public float U_currentBal { get; set; }
        public float U_availBal { get; set; }
        public float U_holdAmount { get; set; }
        public object? U_dorc { get; set; }
        public object? U_transactionTime { get; set; }
        public object? U_remark { get; set; }
        public object? U_tellerId { get; set; }
        public object? U_seqNo { get; set; }
        public object? U_hostDate { get; set; }
        public object? U_pcTime { get; set; }
        public object? U_branch { get; set; }
        public object? U_signature { get; set; }
        public object? U_InputJson { get; set; }
        public object? U_internalRefNo { get; set; }
    }


}













































