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
        public int errorCode { get; set; }
        public string? errorMessage { get; set; }
        public string? requestDateTime { get; set; }
        public string? responseMsgId { get; set; }
        public string? status { get; set; }
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
        public string? internalTransactionRefNo { get; set; }
        public string? remark { get; set; }
        public string? hostInfo { get; set; }
        public string? tellerId { get; set; }
        public string? seqNo { get; set; }
        public string? hostDate { get; set; }
        public string? pcTime { get; set; }
        public string? branch { get; set; }
    }

}

 









































