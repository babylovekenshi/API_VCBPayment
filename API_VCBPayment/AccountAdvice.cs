namespace API_VCBPayment
{
    #region AccountAdvice
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
    #endregion

    #region SAP_AccountAdvice
    public class SAP_AccountAdvice
    {
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
        public string? U_DocNum { get; set; }
    }
    #endregion

    #region MNotifyTrans
    public class MNotifyTrans
    {
        public string? msgId { get; set; }
        public string? providerId { get; set; }
        public string? transId { get; set; }
        public string? transTime { get; set; }
        public string? transType { get; set; }
        public string? custCode { get; set; }
        public string? sendBankId { get; set; }
        public string? sendBranchId { get; set; }
        public string? sendAcctId { get; set; }
        public string? sendAcctName { get; set; }
        public string? recvAcctId { get; set; }
        public string? recvAcctName { get; set; }
        public string? recvVirtualAcctId { get; set; }
        public string? recvVirtualAcctName { get; set; }
        public string? bankTransId { get; set; }
        public string? amount { get; set; }
        public string? remark { get; set; }
        public string? currencyCode { get; set; }
        public string? signature { get; set; }
    }
    #endregion

    #region MInsertNotifyTrans
    public class MInsertNotifyTrans
    {
        public string Code { get; set; } = string.Empty;
        public string U_msgId { get; set; } = string.Empty;
        public string U_msgType { get; set; } = string.Empty;
        public string U_channelId { get; set; } = string.Empty;
        public string U_providerId { get; set; } = string.Empty;
        public string U_merchantId { get; set; } = string.Empty;
        public string U_productId { get; set; } = string.Empty;
        public string U_timestamp { get; set; } = string.Empty;
        public string U_recordNum { get; set; } = string.Empty;
        public string U_signature { get; set; } = string.Empty;
        public string U_encrypt { get; set; } = string.Empty;
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public List<NOTR_LCollection> NOTR_LCollection { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    }

    public class NOTR_LCollection
    {
        public string U_transId { get; set; } = string.Empty;
        public string U_originalId { get; set; } = string.Empty;
        public string U_channelId { get; set; } = string.Empty;
        public string U_priority { get; set; } = string.Empty;
        public string U_recordNo { get; set; } = string.Empty;
        public string U_transTime { get; set; } = string.Empty;
        public string U_transType { get; set; } = string.Empty;
        public string U_serviceType { get; set; } = string.Empty;
        public string U_paymentType { get; set; } = string.Empty;
        public string U_paymentMethod { get; set; } = string.Empty;
        public string U_custCode { get; set; } = string.Empty;
        public string U_custName { get; set; } = string.Empty;
        public string U_custAcct { get; set; } = string.Empty;
        public string U_idCard { get; set; } = string.Empty;
        public string U_phoneNo { get; set; } = string.Empty;
        public string U_email { get; set; } = string.Empty;
        public string U_sendBankId { get; set; } = string.Empty;
        public string U_sendBranchId { get; set; } = string.Empty;
        public string U_sendAcctId { get; set; } = string.Empty;
        public string U_sendAcctName { get; set; } = string.Empty;
        public string U_sendVirtualAcctId { get; set; } = string.Empty;
        public string U_sendVirtualAcctName { get; set; } = string.Empty;
        public string U_sendAddr { get; set; } = string.Empty;
        public string U_sendCity { get; set; } = string.Empty;
        public string U_sendCountry { get; set; } = string.Empty;
        public string U_recvBankId { get; set; } = string.Empty;
        public string U_recvBranchId { get; set; } = string.Empty;
        public string U_recvAcctId { get; set; } = string.Empty;
        public string U_recvAcctName { get; set; } = string.Empty;
        public string U_recvVirtualAcctId { get; set; } = string.Empty;
        public string U_recvVirtualAcctName { get; set; } = string.Empty;
        public string U_recvAddr { get; set; } = string.Empty;
        public string U_recvCity { get; set; } = string.Empty;
        public string U_recvCountry { get; set; } = string.Empty;
        public string U_billId { get; set; } = string.Empty;
        public string U_billTerm { get; set; } = string.Empty;
        public string U_amount { get; set; } = string.Empty;
        public string U_fee { get; set; } = string.Empty;
        public string U_vat { get; set; } = string.Empty;
        public string U_balance { get; set; } = string.Empty;
        public string U_payRefNo { get; set; } = string.Empty;
        public string U_payRefInfo { get; set; } = string.Empty;
        public string U_bankTransId { get; set; } = string.Empty;
        public string U_remark { get; set; } = string.Empty;
        public string U_code { get; set; } = string.Empty;
        public string U_message { get; set; } = string.Empty;
        public string U_currencyCode { get; set; } = string.Empty;
    }
    #endregion

    #region Rootobject
    public class Rootobject
    {
        public Error? error { get; set; }
    }

    public class Error
    {
        public int code { get; set; }
        public Message? message { get; set; }
    }

    public class Message
    {
        public string? lang { get; set; }
        public string? value { get; set; }
    }



    public class JsonReturnNT
    {
        public string? transId { get; set; }
        public string? providerId { get; set; }
        public string? errorCode { get; set; }
        public string? errorDesc { get; set; }
        public string? signature { get; set; }
    }
    #endregion

    #region JsonBusinessPartners
    public class JsonBusinessPartners
    {
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public string? signature { get; set; }
    }
    #endregion

    #region JsonReturnBP
    public class JsonReturnBP
    {
        public List<Value>? value { get; set; }
        public string? signature { get; set; }

    }
    public class Value
    {
        public string? CardCode { get; set; }
        public string? CardName { get; set; }
        public string? CardType { get; set; }
    }
    #endregion

}