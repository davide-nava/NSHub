// <copyright file="TranslationGroup.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Application.Entities;

public class TranslationGroup : BaseEntityType
{

    public Guid LanguageDefaultId { get; set; }

    public virtual ICollection<AccessClockingSourceType> AccessClockingSourceTypes { get; set; } = [];

    public virtual ICollection<AccountPriorityType> AccountPriorityTypes { get; set; } = [];

    public virtual ICollection<AccountRoundingType> AccountRoundingTypes { get; set; } = [];

    public virtual ICollection<AddressType> AddressTypes { get; set; } = [];
    public virtual ICollection<ApprovationModeType> ApprovationModeTypes { get; set; } = [];

    public virtual ICollection<ApprovationStatusType> ApprovationStatusTypes { get; set; } = [];

    public virtual ICollection<Canton> Cantons { get; set; } = [];
    public virtual ICollection<City> Cities { get; set; } = [];

    public virtual ICollection<CommunicationType> CommunicationTypes { get; set; } = [];

    public virtual ICollection<ComputationType> ComputationTypes { get; set; } = [];
    public virtual ICollection<Country> Countries { get; set; } = [];

    public virtual ICollection<Currency> Currencies { get; set; } = [];

    public virtual ICollection<District> Districts { get; set; } = [];
    public virtual ICollection<InsuranceType> InsuranceTypes { get; set; } = [];

    public virtual ICollection<IscoCode> IscoCodes { get; set; } = [];

    public virtual Language LanguageDefault { get; set; } = null!;

    public virtual ICollection<Language> Languages { get; set; } = [];

    public virtual ICollection<LogType> LogTypes { get; set; } = [];

    public virtual ICollection<NotificationType> NotificationTypes { get; set; } = [];
    public virtual ICollection<PaymentTerm> PaymentTerms { get; set; } = [];

    public virtual ICollection<Region> Regions { get; set; } = [];

    public virtual ICollection<Setting> Settings { get; set; } = [];

    public virtual ICollection<TaskStatusType> TaskStatusTypes { get; set; } = [];
    public virtual ICollection<TaxCode> TaxCodes { get; set; } = [];


    public virtual ICollection<TitleType> TitleTypes { get; set; } = [];

    public virtual ICollection<Title> Titles { get; set; } = [];

    public virtual ICollection<TotalType> TotalTypes { get; set; } = [];

    public virtual ICollection<Translation> Translations { get; set; } = [];
    public virtual ICollection<UnitOfMeasure> UnitOfMeasures { get; set; } = [];

    public virtual ICollection<Warehouse> Warehouses { get; set; } = [];

    public virtual ICollection<WorkflowStatusType> WorkflowStatusTypes { get; set; } = [];

    public virtual ICollection<WorkplaceType> WorkplaceTypes { get; set; } = [];

    public virtual ICollection<WorkflowAuthorizationType> WorkflowAuthorizationTypes { get; set; } = [];

    public virtual ICollection<WarehouseType> WarehouseTypes { get; set; } = [];

    public virtual ICollection<UserGroup> UserGroups { get; set; } = [];

    public virtual ICollection<ItemUomConversion> ItemUomConversions { get; set; } = [];

    public virtual ICollection<TaskType> TaskTypes { get; set; } = [];

}
