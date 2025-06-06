﻿namespace API_VCBPayment.SAPB1
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

        #region Add IncomingPayments
        public class MIncomingPayments
        {
            public string? DocType { get; set; }
            public string? CashAccount { get; set; }
            public string? CardCode { get; set; }
            public string? BPLID { get; set; }
            public List<PaymentAccounts>? PaymentAccounts { get; set; }
            public List<Cashflowassignment>? CashFlowAssignments { get; set; }
            public double CashSum { get; set; }
            public string? TransferAccount { get; set; }
            public double? TransferSum { get; set; }
            public object? TransferDate { get; set; }
            public string? ControlAccount { get; set; }
        }

        public class Cashflowassignment
        {
            public double? AmountLC { get; set; }
            public string? PaymentMeans { get; set; }
        }
        public class PaymentAccounts
        {
            public string? AccountCode { get; set; }
            public double? GrossAmount { get; set; }
        }
        #endregion

        #region Return IncomingPayment
        public class IncomingPayment
        {
            public string? odatametadata { get; set; }
            public string? odataetag { get; set; }
            public int DocEntry { get; set; }
            public int DocNum { get; set; }
            public string? DocType { get; set; }
            public string? HandWritten { get; set; }
            public string? Printed { get; set; }
            public DateTime DocDate { get; set; }
            public DateTime DocDueDate { get; set; }
            public string? CardCode { get; set; }
            public string? CardName { get; set; }
            public object? Address { get; set; }
            public object? NumAtCard { get; set; }
            public float DocTotal { get; set; }
            public object? AttachmentEntry { get; set; }
            public string? DocCurrency { get; set; }
            public float DocRate { get; set; }
            public object? Reference1 { get; set; }
            public object? Reference2 { get; set; }
            public string? Comments { get; set; }
            public string? JournalMemo { get; set; }
            public int PaymentGroupCode { get; set; }
            public string? DocTime { get; set; }
            public int SalesPersonCode { get; set; }
            public int TransportationCode { get; set; }
            public string? Confirmed { get; set; }
            public object? ImportFileNum { get; set; }
            public string? SummeryType { get; set; }
            public int ContactPersonCode { get; set; }
            public string? ShowSCN { get; set; }
            public int Series { get; set; }
            public DateTime TaxDate { get; set; }
            public string? PartialSupply { get; set; }
            public string? DocObjectCode { get; set; }
            public string? ShipToCode { get; set; }
            public object? Indicator { get; set; }
            public string? FederalTaxID { get; set; }
            public float DiscountPercent { get; set; }
            public object? PaymentReference { get; set; }
            public DateTime CreationDate { get; set; }
            public DateTime UpdateDate { get; set; }
            public int FinancialPeriod { get; set; }
            public int UserSign { get; set; }
            public object? TransNum { get; set; }
            public float VatSum { get; set; }
            public float VatSumSys { get; set; }
            public float VatSumFc { get; set; }
            public string? NetProcedure { get; set; }
            public float DocTotalFc { get; set; }
            public float DocTotalSys { get; set; }
            public object? Form1099 { get; set; }
            public object? Box1099 { get; set; }
            public string? RevisionPo { get; set; }
            public object? RequriedDate { get; set; }
            public object? CancelDate { get; set; }
            public string? BlockDunning { get; set; }
            public string? Submitted { get; set; }
            public int Segment { get; set; }
            public string? PickStatus { get; set; }
            public string? Pick { get; set; }
            public string? PaymentMethod { get; set; }
            public string? PaymentBlock { get; set; }
            public object? PaymentBlockEntry { get; set; }
            public object? CentralBankIndicator { get; set; }
            public string? MaximumCashDiscount { get; set; }
            public string? Reserve { get; set; }
            public object? Project { get; set; }
            public object? ExemptionValidityDateFrom { get; set; }
            public object? ExemptionValidityDateTo { get; set; }
            public string? WareHouseUpdateType { get; set; }
            public string? Rounding { get; set; }
            public object? ExternalCorrectedDocNum { get; set; }
            public object? InternalCorrectedDocNum { get; set; }
            public object? NextCorrectingDocument { get; set; }
            public string? DeferredTax { get; set; }
            public object? TaxExemptionLetterNum { get; set; }
            public float WTApplied { get; set; }
            public float WTAppliedFC { get; set; }
            public string? BillOfExchangeReserved { get; set; }
            public object? AgentCode { get; set; }
            public float WTAppliedSC { get; set; }
            public float TotalEqualizationTax { get; set; }
            public float TotalEqualizationTaxFC { get; set; }
            public float TotalEqualizationTaxSC { get; set; }
            public int NumberOfInstallments { get; set; }
            public string? ApplyTaxOnFirstInstallment { get; set; }
            public string? TaxOnInstallments { get; set; }
            public float WTNonSubjectAmount { get; set; }
            public float WTNonSubjectAmountSC { get; set; }
            public float WTNonSubjectAmountFC { get; set; }
            public float WTExemptedAmount { get; set; }
            public float WTExemptedAmountSC { get; set; }
            public float WTExemptedAmountFC { get; set; }
            public float BaseAmount { get; set; }
            public float BaseAmountSC { get; set; }
            public float BaseAmountFC { get; set; }
            public float WTAmount { get; set; }
            public float WTAmountSC { get; set; }
            public float WTAmountFC { get; set; }
            public object? VatDate { get; set; }
            public int DocumentsOwner { get; set; }
            public object? FolioPrefixString { get; set; }
            public object? FolioNumber { get; set; }
            public string? DocumentSubType { get; set; }
            public object? BPChannelCode { get; set; }
            public object? BPChannelContact { get; set; }
            public string? Address2 { get; set; }
            public string? DocumentStatus { get; set; }
            public string? PeriodIndicator { get; set; }
            public string? PayToCode { get; set; }
            public object? ManualNumber { get; set; }
            public string? UseShpdGoodsAct { get; set; }
            public string? IsPayToBank { get; set; }
            public object? PayToBankCountry { get; set; }
            public object? PayToBankCode { get; set; }
            public object? PayToBankAccountNo { get; set; }
            public object? PayToBankBranch { get; set; }
            public int BPL_IDAssignedToInvoice { get; set; }
            public float DownPayment { get; set; }
            public string? ReserveInvoice { get; set; }
            public int LanguageCode { get; set; }
            public object? TrackingNumber { get; set; }
            public string? PickRemark { get; set; }
            public object? ClosingDate { get; set; }
            public object? SequenceCode { get; set; }
            public object? SequenceSerial { get; set; }
            public object? SeriesString { get; set; }
            public object? SubSeriesString { get; set; }
            public string? SequenceModel { get; set; }
            public string? UseCorrectionVATGroup { get; set; }
            public float TotalDiscount { get; set; }
            public float DownPaymentAmount { get; set; }
            public float DownPaymentPercentage { get; set; }
            public string? DownPaymentType { get; set; }
            public float DownPaymentAmountSC { get; set; }
            public float DownPaymentAmountFC { get; set; }
            public float VatPercent { get; set; }
            public float ServiceGrossProfitPercent { get; set; }
            public object? OpeningRemarks { get; set; }
            public object? ClosingRemarks { get; set; }
            public float RoundingDiffAmount { get; set; }
            public float RoundingDiffAmountFC { get; set; }
            public float RoundingDiffAmountSC { get; set; }
            public string? Cancelled { get; set; }
            public object? SignatureInputMessage { get; set; }
            public object? SignatureDigest { get; set; }
            public object? CertificationNumber { get; set; }
            public object? PrivateKeyVersion { get; set; }
            public object? ControlAccount { get; set; }
            public string? InsuranceOperation347 { get; set; }
            public string? ArchiveNonremovableSalesQuotation { get; set; }
            public object? GTSChecker { get; set; }
            public object? GTSPayee { get; set; }
            public int ExtraMonth { get; set; }
            public int ExtraDays { get; set; }
            public int CashDiscountDateOffset { get; set; }
            public string? StartFrom { get; set; }
            public string? NTSApproved { get; set; }
            public object? ETaxWebSite { get; set; }
            public object? ETaxNumber { get; set; }
            public object? NTSApprovedNumber { get; set; }
            public string? EDocGenerationType { get; set; }
            public object? EDocSeries { get; set; }
            public object? EDocNum { get; set; }
            public object? EDocExportFormat { get; set; }
            public string? EDocStatus { get; set; }
            public object? EDocErrorCode { get; set; }
            public object? EDocErrorMessage { get; set; }
            public string? DownPaymentStatus { get; set; }
            public object? GroupSeries { get; set; }
            public object? GroupNumber { get; set; }
            public string? GroupHandWritten { get; set; }
            public object? ReopenOriginalDocument { get; set; }
            public object? ReopenManuallyClosedOrCanceledDocument { get; set; }
            public string? CreateOnlineQuotation { get; set; }
            public object? POSEquipmentNumber { get; set; }
            public object? POSManufacturerSerialNumber { get; set; }
            public object? POSCashierNumber { get; set; }
            public string? ApplyCurrentVATRatesForDownPaymentsToDraw { get; set; }
            public string? ClosingOption { get; set; }
            public object? SpecifiedClosingDate { get; set; }
            public string? OpenForLandedCosts { get; set; }
            public string? AuthorizationStatus { get; set; }
            public float TotalDiscountFC { get; set; }
            public float TotalDiscountSC { get; set; }
            public string? RelevantToGTS { get; set; }
            public string? BPLName { get; set; }
            public object? VATRegNum { get; set; }
            public object? AnnualInvoiceDeclarationReference { get; set; }
            public object? Supplier { get; set; }
            public object? Releaser { get; set; }
            public object? Receiver { get; set; }
            public object? BlanketAgreementNumber { get; set; }
            public string? IsAlteration { get; set; }
            public string? CancelStatus { get; set; }
            public object? AssetValueDate { get; set; }
            public object? Requester { get; set; }
            public object? RequesterName { get; set; }
            public object? RequesterBranch { get; set; }
            public object? RequesterDepartment { get; set; }
            public object? RequesterEmail { get; set; }
            public object? SendNotification { get; set; }
            public int ReqType { get; set; }
            public object? ReqCode { get; set; }
            public string? InvoicePayment { get; set; }
            public string? DocumentDelivery { get; set; }
            public object? AuthorizationCode { get; set; }
            public object? StartDeliveryDate { get; set; }
            public object? StartDeliveryTime { get; set; }
            public object? EndDeliveryDate { get; set; }
            public object? EndDeliveryTime { get; set; }
            public object? VehiclePlate { get; set; }
            public object? ATDocumentType { get; set; }
            public object? ElecCommStatus { get; set; }
            public object? ElecCommMessage { get; set; }
            public string? ReuseDocumentNum { get; set; }
            public string? ReuseNotaFiscalNum { get; set; }
            public string? PrintSEPADirect { get; set; }
            public object? FiscalDocNum { get; set; }
            public object? POSDailySummaryNo { get; set; }
            public object? POSReceiptNo { get; set; }
            public object? PointOfIssueCode { get; set; }
            public object? Letter { get; set; }
            public object? FolioNumberFrom { get; set; }
            public object? FolioNumberTo { get; set; }
            public string? InterimType { get; set; }
            public int RelatedType { get; set; }
            public object? RelatedEntry { get; set; }
            public object? SAPPassport { get; set; }
            public object? DocumentTaxID { get; set; }
            public object? DateOfReportingControlStatementVAT { get; set; }
            public object? ReportingSectionControlStatementVAT { get; set; }
            public string? ExcludeFromTaxReportControlStatementVAT { get; set; }
            public object? POS_CashRegister { get; set; }
            public string? UpdateTime { get; set; }
            public object? CreateQRCodeFrom { get; set; }
            public object? PriceMode { get; set; }
            public object? DownPaymentTrasactionID { get; set; }
            public object? OriginalRefNo { get; set; }
            public object? OriginalRefDate { get; set; }
            public string? Revision { get; set; }
            public object? GSTTransactionType { get; set; }
            public object? OriginalCreditOrDebitNo { get; set; }
            public object? OriginalCreditOrDebitDate { get; set; }
            public object? ECommerceOperator { get; set; }
            public object? ECommerceGSTIN { get; set; }
            public object? TaxInvoiceNo { get; set; }
            public object? TaxInvoiceDate { get; set; }
            public string? ShipFrom { get; set; }
            public string? CommissionTrade { get; set; }
            public string? CommissionTradeReturn { get; set; }
            public string? UseBillToAddrToDetermineTax { get; set; }
            public int IssuingReason { get; set; }
            public object? Cig { get; set; }
            public object? Cup { get; set; }
            public string? EDocType { get; set; }
            public string? FCEAsPaymentMeans { get; set; }
            public float PaidToDate { get; set; }
            public float PaidToDateFC { get; set; }
            public float PaidToDateSys { get; set; }
            public object? FatherCard { get; set; }
            public string? FatherType { get; set; }
            public object? ShipState { get; set; }
            public object? ShipPlace { get; set; }
            public object? CustOffice { get; set; }
            public object? FCI { get; set; }
            public object? AddLegIn { get; set; }
            public object? LegTextF { get; set; }
            public object? DANFELgTxt { get; set; }
            public int DataVersion { get; set; }
            public object? LastPageFolioNumber { get; set; }
            public string? InventoryStatus { get; set; }
            public string? PlasticPackagingTaxRelevant { get; set; }
            public string? NotRelevantForMonthlyInvoice { get; set; }
            public object? U_CodeInv { get; set; }
            public object? U_InvSerial { get; set; }
            public object? U_InvCode { get; set; }
            public object? U_DeclarePd { get; set; }
            public string? U_CoName { get; set; }
            public string? U_CoAdd { get; set; }
            public string? U_CoTaxNo { get; set; }
            public string? U_DCgiaohang { get; set; }
            public object? U_HTTT { get; set; }
            public object? U_NNHG { get; set; }
            public object? U_NVKD1 { get; set; }
            public object? U_NVKD2 { get; set; }
            public object? U_NVKD3 { get; set; }
            public object? U_NCKD4 { get; set; }
            public string? U_Loaidonhang { get; set; }
            public object? U_BenGH { get; set; }
            public string? U_DHtinhthuong { get; set; }
            public string? U_Loaigia { get; set; }
            public string? U_NDD { get; set; }
            public string? U_Phongban { get; set; }
            public object? U_Macu { get; set; }
            public string? U_KHO { get; set; }
            public string? U_Diengiai { get; set; }
            public object? U_AdvHRCode { get; set; }
            public object? U_AdvHRName { get; set; }
            public string? U_GroupKH { get; set; }
            public string? U_Costcenter { get; set; }
            public object? U_BenGHPS { get; set; }
            public object? U_Loaiphieu { get; set; }
            public object? U_KH { get; set; }
            public object? U_PVTL { get; set; }
            public object? U_TraBH_Head { get; set; }
            public object? U_SoHD_Thaythe { get; set; }
            public object? U_Ghichu_HDDT { get; set; }
            public string? U_KhuVuc { get; set; }
            public string? U_LoaiDH { get; set; }
            public string? U_StatusOrder { get; set; }
            public string? U_RegionSO { get; set; }
            public object? U_LoaiNX { get; set; }
            public string? U_Tinh { get; set; }
            public object? U_BankCode { get; set; }
            public string? U_BankName { get; set; }
            public string? U_Account { get; set; }
            public object? U_Branch { get; set; }
            public object? U_SWIFT { get; set; }
            public string? U_ChuTK { get; set; }
            public object? U_Dcncc { get; set; }
            public string? U_LoaiKH { get; set; }
            public object? U_TenKH { get; set; }
            public object? U_Diachinguoithuhuong { get; set; }
            public object? U_Dcnganhangthuhuong { get; set; }
            public object? U_MIEN1 { get; set; }
            public object? U_thuonghieu { get; set; }
            public object? U_DiaDiemGiao { get; set; }
            public object? U_ThanhToan { get; set; }
            public object? U_NgayGiao { get; set; }
            public object? U_tax { get; set; }
            public object? U_BASETYPEUDF { get; set; }
            public object? U_Link { get; set; }
            public object? U_PhanLoai { get; set; }
            public object? U_Blocks { get; set; }
            public object? U_NM { get; set; }
            public object? U_MD { get; set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
            public object?[] Document_ApprovalRequests { get; set; }
            public List<Documentline> DocumentLines { get; set; }
            public Ewaybilldetails EWayBillDetails { get; set; }
            public object?[] ElectronicProtocols { get; set; }
            public object?[] DocumentAdditionalExpenses { get; set; }
            public object?[] DocumentDistributedExpenses { get; set; }
            public object?[] WithholdingTaxDataWTXCollection { get; set; }
            public object?[] WithholdingTaxDataCollection { get; set; }
            public object?[] DocumentPackages { get; set; }
            public object?[] DocumentSpecialLines { get; set; }
            public Documentinstallment[] DocumentInstallments { get; set; }
            public object?[] DownPaymentsToDraw { get; set; }
            public Taxextension TaxExtension { get; set; }
            public Addressextension AddressExtension { get; set; }
            public object?[] DocumentReferences { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
        }

        public class Ewaybilldetails
        {
        }

        public class Taxextension
        {
            public object? TaxId0 { get; set; }
            public object? TaxId1 { get; set; }
            public object? TaxId2 { get; set; }
            public object? TaxId3 { get; set; }
            public object? TaxId4 { get; set; }
            public object? TaxId5 { get; set; }
            public object? TaxId6 { get; set; }
            public object? TaxId7 { get; set; }
            public object? TaxId8 { get; set; }
            public object? TaxId9 { get; set; }
            public object? State { get; set; }
            public object? County { get; set; }
            public object? Incoterms { get; set; }
            public object? Vehicle { get; set; }
            public object? VehicleState { get; set; }
            public string? NFRef { get; set; }
            public object? Carrier { get; set; }
            public object? PackQuantity { get; set; }
            public object? PackDescription { get; set; }
            public object? Brand { get; set; }
            public object? ShipUnitNo { get; set; }
            public float NetWeight { get; set; }
            public float GrossWeight { get; set; }
            public string? StreetS { get; set; }
            public string? BlockS { get; set; }
            public string? BuildingS { get; set; }
            public string? CityS { get; set; }
            public string? ZipCodeS { get; set; }
            public string? CountyS { get; set; }
            public string? StateS { get; set; }
            public string? CountryS { get; set; }
            public object? StreetB { get; set; }
            public object? BlockB { get; set; }
            public object? BuildingB { get; set; }
            public object? CityB { get; set; }
            public object? ZipCodeB { get; set; }
            public object? CountyB { get; set; }
            public object? StateB { get; set; }
            public object? CountryB { get; set; }
            public object? ImportOrExport { get; set; }
            public object? MainUsage { get; set; }
            public string? GlobalLocationNumberS { get; set; }
            public object? GlobalLocationNumberB { get; set; }
            public object? TaxId12 { get; set; }
            public object? TaxId13 { get; set; }
            public object? BillOfEntryNo { get; set; }
            public object? BillOfEntryDate { get; set; }
            public object? OriginalBillOfEntryNo { get; set; }
            public object? OriginalBillOfEntryDate { get; set; }
            public string? ImportOrExportType { get; set; }
            public object? PortCode { get; set; }
            public int DocEntry { get; set; }
            public float BoEValue { get; set; }
            public object? ClaimRefund { get; set; }
            public object? DifferentialOfTaxRate { get; set; }
            public object? IsIGSTAccount { get; set; }
            public object? TaxId14 { get; set; }
        }

        public class Addressextension
        {
            public string? ShipToStreet { get; set; }
            public string? ShipToStreetNo { get; set; }
            public string? ShipToBlock { get; set; }
            public string? ShipToBuilding { get; set; }
            public string? ShipToCity { get; set; }
            public string? ShipToZipCode { get; set; }
            public string? ShipToCounty { get; set; }
            public string? ShipToState { get; set; }
            public string? ShipToCountry { get; set; }
            public string? ShipToAddressType { get; set; }
            public object? BillToStreet { get; set; }
            public object? BillToStreetNo { get; set; }
            public object? BillToBlock { get; set; }
            public object? BillToBuilding { get; set; }
            public object? BillToCity { get; set; }
            public object? BillToZipCode { get; set; }
            public object? BillToCounty { get; set; }
            public object? BillToState { get; set; }
            public object? BillToCountry { get; set; }
            public object? BillToAddressType { get; set; }
            public string? ShipToGlobalLocationNumber { get; set; }
            public object? BillToGlobalLocationNumber { get; set; }
            public string? ShipToAddress2 { get; set; }
            public string? ShipToAddress3 { get; set; }
            public object? BillToAddress2 { get; set; }
            public object? BillToAddress3 { get; set; }
            public object? PlaceOfSupply { get; set; }
            public object? PurchasePlaceOfSupply { get; set; }
            public int DocEntry { get; set; }
            public object? GoodsIssuePlaceBP { get; set; }
            public object? GoodsIssuePlaceCNPJ { get; set; }
            public object? GoodsIssuePlaceCPF { get; set; }
            public object? GoodsIssuePlaceStreet { get; set; }
            public object? GoodsIssuePlaceStreetNo { get; set; }
            public object? GoodsIssuePlaceBuilding { get; set; }
            public object? GoodsIssuePlaceZip { get; set; }
            public object? GoodsIssuePlaceBlock { get; set; }
            public object? GoodsIssuePlaceCity { get; set; }
            public object? GoodsIssuePlaceCounty { get; set; }
            public object? GoodsIssuePlaceState { get; set; }
            public object? GoodsIssuePlaceCountry { get; set; }
            public object? GoodsIssuePlacePhone { get; set; }
            public object? GoodsIssuePlaceEMail { get; set; }
            public object? GoodsIssuePlaceDepartureDate { get; set; }
            public object? DeliveryPlaceBP { get; set; }
            public object? DeliveryPlaceCNPJ { get; set; }
            public object? DeliveryPlaceCPF { get; set; }
            public object? DeliveryPlaceStreet { get; set; }
            public object? DeliveryPlaceStreetNo { get; set; }
            public object? DeliveryPlaceBuilding { get; set; }
            public object? DeliveryPlaceZip { get; set; }
            public object? DeliveryPlaceBlock { get; set; }
            public object? DeliveryPlaceCity { get; set; }
            public object? DeliveryPlaceCounty { get; set; }
            public object? DeliveryPlaceState { get; set; }
            public object? DeliveryPlaceCountry { get; set; }
            public object? DeliveryPlacePhone { get; set; }
            public object? DeliveryPlaceEMail { get; set; }
            public object? DeliveryPlaceDepartureDate { get; set; }
        }

        public class Documentline
        {
            public int LineNum { get; set; }
            public string? ItemCode { get; set; }
            public string? ItemDescription { get; set; }
            public float Quantity { get; set; }
            public DateTime ShipDate { get; set; }
            public float Price { get; set; }
            public float PriceAfterVAT { get; set; }
            public string? Currency { get; set; }
            public float Rate { get; set; }
            public float DiscountPercent { get; set; }
            public string? VendorNum { get; set; }
            public object? SerialNum { get; set; }
            public string? WarehouseCode { get; set; }
            public int SalesPersonCode { get; set; }
            public float CommisionPercent { get; set; }
            public string? TreeType { get; set; }
            public string? AccountCode { get; set; }
            public string? UseBaseUnits { get; set; }
            public string? SupplierCatNum { get; set; }
            public string? CostingCode { get; set; }
            public string? ProjectCode { get; set; }
            public object? BarCode { get; set; }
            public string? VatGroup { get; set; }
            public float Height1 { get; set; }
            public object? Hight1Unit { get; set; }
            public float Height2 { get; set; }
            public object? Height2Unit { get; set; }
            public float Lengh1 { get; set; }
            public object? Lengh1Unit { get; set; }
            public float Lengh2 { get; set; }
            public object? Lengh2Unit { get; set; }
            public float Weight1 { get; set; }
            public object? Weight1Unit { get; set; }
            public float Weight2 { get; set; }
            public object? Weight2Unit { get; set; }
            public float Factor1 { get; set; }
            public float Factor2 { get; set; }
            public float Factor3 { get; set; }
            public float Factor4 { get; set; }
            public int BaseType { get; set; }
            public int BaseEntry { get; set; }
            public int BaseLine { get; set; }
            public float Volume { get; set; }
            public int VolumeUnit { get; set; }
            public float Width1 { get; set; }
            public object? Width1Unit { get; set; }
            public float Width2 { get; set; }
            public object? Width2Unit { get; set; }
            public string? Address { get; set; }
            public object? TaxCode { get; set; }
            public string? TaxType { get; set; }
            public string? TaxLiable { get; set; }
            public string? PickStatus { get; set; }
            public float PickQuantity { get; set; }
            public object? PickListIdNumber { get; set; }
            public object? OriginalItem { get; set; }
            public string? BackOrder { get; set; }
            public string? FreeText { get; set; }
            public int ShippingMethod { get; set; }
            public object? POTargetNum { get; set; }
            public string? POTargetEntry { get; set; }
            public object? POTargetRowNum { get; set; }
            public string? CorrectionInvoiceItem { get; set; }
            public float CorrInvAmountToStock { get; set; }
            public float CorrInvAmountToDiffAcct { get; set; }
            public float AppliedTax { get; set; }
            public float AppliedTaxFC { get; set; }
            public float AppliedTaxSC { get; set; }
            public string? WTLiable { get; set; }
            public string? DeferredTax { get; set; }
            public float EqualizationTaxPercent { get; set; }
            public float TotalEqualizationTax { get; set; }
            public float TotalEqualizationTaxFC { get; set; }
            public float TotalEqualizationTaxSC { get; set; }
            public float NetTaxAmount { get; set; }
            public float NetTaxAmountFC { get; set; }
            public float NetTaxAmountSC { get; set; }
            public string? MeasureUnit { get; set; }
            public float UnitsOfMeasurment { get; set; }
            public float LineTotal { get; set; }
            public float TaxPercentagePerRow { get; set; }
            public float TaxTotal { get; set; }
            public string? ConsumerSalesForecast { get; set; }
            public float ExciseAmount { get; set; }
            public float TaxPerUnit { get; set; }
            public float TotalInclTax { get; set; }
            public object? CountryOrg { get; set; }
            public string? SWW { get; set; }
            public object? TransactionType { get; set; }
            public string? DistributeExpense { get; set; }
            public float RowTotalFC { get; set; }
            public float RowTotalSC { get; set; }
            public float LastBuyInmPrice { get; set; }
            public float LastBuyDistributeSumFc { get; set; }
            public float LastBuyDistributeSumSc { get; set; }
            public float LastBuyDistributeSum { get; set; }
            public float StockDistributesumForeign { get; set; }
            public float StockDistributesumSystem { get; set; }
            public float StockDistributesum { get; set; }
            public float StockInmPrice { get; set; }
            public string? PickStatusEx { get; set; }
            public float TaxBeforeDPM { get; set; }
            public float TaxBeforeDPMFC { get; set; }
            public float TaxBeforeDPMSC { get; set; }
            public object? CFOPCode { get; set; }
            public object? CSTCode { get; set; }
            public object? Usage { get; set; }
            public string? TaxOnly { get; set; }
            public int VisualOrder { get; set; }
            public float BaseOpenQuantity { get; set; }
            public float UnitPrice { get; set; }
            public string? LineStatus { get; set; }
            public float PackageQuantity { get; set; }
            public string? Text { get; set; }
            public string? LineType { get; set; }
            public string? COGSCostingCode { get; set; }
            public string? COGSAccountCode { get; set; }
            public string? ChangeAssemlyBoMWarehouse { get; set; }
            public float GrossBuyPrice { get; set; }
            public int GrossBase { get; set; }
            public float GrossProfitTotalBasePrice { get; set; }
            public string? CostingCode2 { get; set; }
            public string? CostingCode3 { get; set; }
            public string? CostingCode4 { get; set; }
            public string? CostingCode5 { get; set; }
            public object? ItemDetails { get; set; }
            public object? LocationCode { get; set; }
            public DateTime ActualDeliveryDate { get; set; }
            public float RemainingOpenQuantity { get; set; }
            public float OpenAmount { get; set; }
            public float OpenAmountFC { get; set; }
            public float OpenAmountSC { get; set; }
            public object? ExLineNo { get; set; }
            public object? RequiredDate { get; set; }
            public float RequiredQuantity { get; set; }
            public string? COGSCostingCode2 { get; set; }
            public string? COGSCostingCode3 { get; set; }
            public string? COGSCostingCode4 { get; set; }
            public string? COGSCostingCode5 { get; set; }
            public object? CSTforIPI { get; set; }
            public object? CSTforPIS { get; set; }
            public object? CSTforCOFINS { get; set; }
            public object? CreditOriginCode { get; set; }
            public string? WithoutInventoryMovement { get; set; }
            public object? AgreementNo { get; set; }
            public object? AgreementRowNumber { get; set; }
            public object? ActualBaseEntry { get; set; }
            public object? ActualBaseLine { get; set; }
            public int DocEntry { get; set; }
            public float Surpluses { get; set; }
            public float DefectAndBreakup { get; set; }
            public float Shortages { get; set; }
            public string? ConsiderQuantity { get; set; }
            public string? PartialRetirement { get; set; }
            public float RetirementQuantity { get; set; }
            public float RetirementAPC { get; set; }
            public string? ThirdParty { get; set; }
            public object? PoNum { get; set; }
            public object? PoItmNum { get; set; }
            public object? ExpenseType { get; set; }
            public object? ReceiptNumber { get; set; }
            public object? ExpenseOperationType { get; set; }
            public object? FederalTaxID { get; set; }
            public float GrossProfit { get; set; }
            public float GrossProfitFC { get; set; }
            public float GrossProfitSC { get; set; }
            public string? PriceSource { get; set; }
            public string? EnableReturnCost { get; set; }
            public float ReturnCost { get; set; }
            public string? LineVendor { get; set; }
            public int ReturnAction { get; set; }
            public int ReturnReason { get; set; }
            public object? StgSeqNum { get; set; }
            public object? StgEntry { get; set; }
            public object? StgDesc { get; set; }
            public int UoMEntry { get; set; }
            public string? UoMCode { get; set; }
            public float InventoryQuantity { get; set; }
            public float RemainingOpenInventoryQuantity { get; set; }
            public object? ParentLineNum { get; set; }
            public int Incoterms { get; set; }
            public int TransportMode { get; set; }
            public object? NatureOfTransaction { get; set; }
            public object? DestinationCountryForImport { get; set; }
            public object? DestinationRegionForImport { get; set; }
            public object? OriginCountryForExport { get; set; }
            public object? OriginRegionForExport { get; set; }
            public string? ItemType { get; set; }
            public string? ChangeInventoryQuantityIndependently { get; set; }
            public string? FreeOfChargeBP { get; set; }
            public object? SACEntry { get; set; }
            public object? HSNEntry { get; set; }
            public float GrossPrice { get; set; }
            public float GrossTotal { get; set; }
            public float GrossTotalFC { get; set; }
            public float GrossTotalSC { get; set; }
            public int NCMCode { get; set; }
            public object? NVECode { get; set; }
            public string? IndEscala { get; set; }
            public float CtrSealQty { get; set; }
            public object? CNJPMan { get; set; }
            public int CESTCode { get; set; }
            public object? UFFiscalBenefitCode { get; set; }
            public string? ReverseCharge { get; set; }
            public string? ShipToCode { get; set; }
            public string? ShipToDescription { get; set; }
            public object? ShipFromCode { get; set; }
            public object? ShipFromDescription { get; set; }
            public int OwnerCode { get; set; }
            public float ExternalCalcTaxRate { get; set; }
            public float ExternalCalcTaxAmount { get; set; }
            public float ExternalCalcTaxAmountFC { get; set; }
            public float ExternalCalcTaxAmountSC { get; set; }
            public int StandardItemIdentification { get; set; }
            public int CommodityClassification { get; set; }
            public float WeightOfRecycledPlastic { get; set; }
            public object? PlasticPackageExemptionReason { get; set; }
            public object? LegalText { get; set; }
            public object? Cig { get; set; }
            public object? Cup { get; set; }
            public object? UnencumberedReason { get; set; }
            public string? CUSplit { get; set; }
            public object? ListNum { get; set; }
            public object? RecognizedTaxCode { get; set; }
            public object? U_TraBH { get; set; }
            public string? U_NhomHH { get; set; }
            public string? U_NhomKH { get; set; }
            public object? U_NVKD { get; set; }
            public object? U_Cosan { get; set; }
            public object? U_SLdenghi { get; set; }
            public object? U_SLxemxet { get; set; }
            public string? U_Type { get; set; }
            public object? U_CTKM { get; set; }
            public object? U_Cardcode { get; set; }
            public object? U_Cardname { get; set; }
            public object? U_Cosan1 { get; set; }
            public object? U_GiaCataloge { get; set; }
            public object? U_TSKT { get; set; }
            public float U_SLVung { get; set; }
            public float U_QRegion { get; set; }
            public float U_QRequest { get; set; }
            public float U_QAvai { get; set; }
            public string? U_CheckStatus { get; set; }
            public string? U_U_Type { get; set; }
            public float U_U_GBD { get; set; }
            public float U_U_CKLoaiKH { get; set; }
            public float U_U_CKKM { get; set; }
            public float U_U_CKGiaHang { get; set; }
            public float U_U_LineTotal { get; set; }
            public object? U_U_CTKM { get; set; }
            public object? U_U_NoiDungCTKM { get; set; }
            public int U_SLthieu { get; set; }
            public object? U_PO1 { get; set; }
            public object? U_PO2 { get; set; }
            public float U_GBD { get; set; }
            public float U_CKLoaiKH { get; set; }
            public float U_CKKM { get; set; }
            public float U_CKGiaHang { get; set; }
            public float U_LineTotal { get; set; }
            public object? U_NoiDungCTKM { get; set; }
            public object? U_Macu { get; set; }
            public object? U_DienGiai { get; set; }
            public object? U_TTCT { get; set; }
            public object? U_tetich { get; set; }
            public object? U_PriceOrder { get; set; }
            public object? U_CTKMM { get; set; }
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
            public object?[] LineTaxJurisdictions { get; set; }

            public object?[] GeneratedAssets { get; set; }
            public object?[] EBooksDetails { get; set; }
            public object?[] DocumentLineAdditionalExpenses { get; set; }
            public object?[] WithholdingTaxLines { get; set; }
            public object?[] SerialNumbers { get; set; }
            public object?[] BatchNumbers { get; set; }
            public object?[] DocumentLinesBinAllocations { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
        }
        public class Documentinstallment
        {
            public DateTime DueDate { get; set; }
            public float Percentage { get; set; }
            public float Total { get; set; }
            public object? LastDunningDate { get; set; }
            public int DunningLevel { get; set; }
            public float TotalFC { get; set; }
            public int InstallmentId { get; set; }
            public string? PaymentOrdered { get; set; }
        }
        #endregion
    }
}









