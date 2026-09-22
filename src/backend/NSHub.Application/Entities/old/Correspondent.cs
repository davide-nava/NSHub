using System;
using System.Collections.Generic;

using NSHub.Enums;

namespace NSHub.ApplicationCore.Entities;

public class Correspondent : BaseEntity
{
    public string Code { get; set; }

    public string Address { get; set; } = null!;

    public string AddressLocality { get; set; } = null!;

    public string AddressNation { get; set; } = null!;

    public string AddressPostalCode { get; set; } = null!;

    public string AddressPostOfficeBox { get; set; } = null!;

    public string AttentionTo { get; set; } = null!;

    public string EmailAddress { get; set; } = null!;

    public string Fax { get; set; } = null!;

    public string Language { get; set; } = null!;

    public string MobilePhone { get; set; } = null!;


    public IEnumerable<StringList> Names { get; set; }
    public IEnumerable<StringList> Telephones { get; set; }


    public string WebSite { get; set; } = null!;

    public string Title { get; set; } = null!;

    public string District { get; set; } = null!;

    public decimal Latitude { get; set; }

    public decimal Longitude { get; set; }

    public string PriceForCustomer { get; set; } = null!;

    public string DiscountForCustomer { get; set; } = null!;

    public string SupplierPrice { get; set; } = null!;

    public string SupplierDiscount { get; set; } = null!;

    public string Groups { get; set; } = null!;

    public Guid PaymentModeForCustomerId { get; set; }

    public Guid SupplierPaymentModeId { get; set; }

    public IEnumerable<StringList> Codes { get; set; }

    public IEnumerable<TranslationGroupList> Texts { get; set; }

    public IEnumerable<DateTimeList> Dates { get; set; }

    public Guid DocumentTypeId { get; set; }

    public IEnumerable<StringGroupList> NoticeTexts { get; set; }
    public IEnumerable<GuidList> Notices { get; set; }


    public Guid AgentId { get; set; }

    public Guid AgentCommissionId { get; set; }

    public string VatNumber { get; set; } = null!;

    public string PostfinanceBillerId { get; set; } = null!;

    public PostfinanceBillerStatusType PostfinanceBillerStatusType { get; set; }

    public IEnumerable<DecimalList> AmountBcs { get; set; }
    public IEnumerable<DecimalList> AmountFcs { get; set; }

    public string Note { get; set; } = null!;

    public decimal DiscountIncreaseCustomer { get; set; }

    public decimal DiscountIncreaseSupplier { get; set; }

    public bool SendReminder { get; set; }

    public Guid IdVatCustomerId { get; set; }

    public Guid VatSupplierId { get; set; }

    public decimal CreditLimitCustomer { get; set; }

    public decimal CreditLimitSupplier { get; set; }

    public decimal TurnoverFreeAmountCost { get; set; }

    public decimal TurnoverFreeAmountSale { get; set; }

    public Guid PaymentOrderGroupId { get; set; }

    public int CustomNumSoggetti { get; set; }

    public string AddressNationIso2 { get; set; } = null!;

    public DocumentGroupingModeType DocumentGroupingModeType { get; set; }

    public string PriceListsForCustomer { get; set; } = null!;

    public string SupplierPriceLists { get; set; } = null!;


    public Guid PriceListCustomerId { get; set; }

    public Guid PriceListSupplierId { get; set; }

    public decimal CreditLimitBlockingCustomer { get; set; }

    public decimal CreditLimitBlockingSupplier { get; set; }

    public Guid LastSaleDocumentId { get; set; }

    public Guid LastPurchaseDocumentId { get; set; }

    public string SocialInsuranceNumber { get; set; } = null!;

    public string GlnNumber { get; set; } = null!;

    public DateTime BirthDate { get; set; }

    public SexType SexType { get; set; }

    public Guid InsuranceTypeId { get; set; }

    public Guid WarehouseId { get; set; }


}
