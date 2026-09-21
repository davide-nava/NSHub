// <copyright file="User.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Application.Entities.Json;
using NSHub.Application.PlanetHub.Models;

namespace NSHub.Application.Entities;

public class User : BaseEntity
{
    public string Username { get; set; } = null!;

    public string DisplayName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;


    public string WhatsApp { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string Note { get; set; } = null!;

    public Guid? ApplicationUserId { get; set; }

    public virtual ApplicationUser? ApplicationUser { get; set; }

    public virtual Guid  TenantUsedId { get; set; }

    public virtual Tenant? TenantUsed { get; set; }

    public UserConfigurationJson Configuration { get; set; } = new();

    public virtual ICollection<AccessClockingSourceType> AccessClockingSourceTypeUserInserts { get; set; } = [];

    public virtual ICollection<AccessClockingSourceType> AccessClockingSourceTypeUserUpdates { get; set; } = [];

    public virtual ICollection<AccountPriorityType> AccountPriorityTypeUserInserts { get; set; } = [];

    public virtual ICollection<AccountPriorityType> AccountPriorityTypeUserUpdates { get; set; } = [];

    public virtual ICollection<AccountRoundingType> AccountRoundingTypeUserInserts { get; set; } = [];
    public virtual ICollection<AccountRoundingType> AccountRoundingTypeUserUpdates { get; set; } = [];

    public virtual ICollection<AddressType> AddressTypeUserInserts { get; set; } = [];

    public virtual ICollection<AddressType> AddressTypeUserUpdates { get; set; } = [];
    public virtual ICollection<Address> AddressUserInserts { get; set; } = [];

    public virtual ICollection<Address> AddressUserUpdates { get; set; } = [];

    public virtual ICollection<ApprovationModeType> ApprovationModeTypeUserInserts { get; set; } = [];

    public virtual ICollection<ApprovationModeType> ApprovationModeTypeUserUpdates { get; set; } = [];

    public virtual ICollection<ApprovationStatusType> ApprovationStatusTypeUserInserts { get; set; } = [];

    public virtual ICollection<ApprovationStatusType> ApprovationStatusTypeUserUpdates { get; set; } = [];

    public virtual ICollection<Canton> CantonUserInserts { get; set; } = [];
    public virtual ICollection<Canton> CantonUserUpdates { get; set; } = [];

    public virtual ICollection<City> CityUserInserts { get; set; } = [];

    public virtual ICollection<City> CityUserUpdates { get; set; } = [];
    public virtual ICollection<CommunicationType> CommunicationTypeUserInserts { get; set; } = [];

    public virtual ICollection<CommunicationType> CommunicationTypeUserUpdates { get; set; } = [];

    public virtual ICollection<ComputationType> ComputationTypeUserInserts { get; set; } = [];
    public virtual ICollection<ComputationType> ComputationTypeUserUpdates { get; set; } = [];

    public virtual ICollection<Country> CountryUserInserts { get; set; } = [];

    public virtual ICollection<Country> CountryUserUpdates { get; set; } = [];

    public virtual ICollection<Currency> CurrencyUserInserts { get; set; } = [];

    public virtual ICollection<Currency> CurrencyUserUpdates { get; set; } = [];
    public virtual ICollection<District> DistrictUserInserts { get; set; } = [];

    public virtual ICollection<District> DistrictUserUpdates { get; set; } = [];

    public virtual ICollection<InsuranceType> InsuranceTypeUserInserts { get; set; } = [];
    public virtual ICollection<InsuranceType> InsuranceTypeUserUpdates { get; set; } = [];

    public virtual ICollection<User> InverseUserInsert { get; set; } = [];

    public virtual ICollection<User> InverseUserUpdate { get; set; } = [];
    public virtual ICollection<IscoCode> IscoCodeUserInserts { get; set; } = [];

    public virtual ICollection<IscoCode> IscoCodeUserUpdates { get; set; } = [];

    public virtual ICollection<Language> LanguageUserInserts { get; set; } = [];
    public virtual ICollection<Language> LanguageUserUpdates { get; set; } = [];

    public virtual ICollection<LogType> LogTypeUserInserts { get; set; } = [];

    public virtual ICollection<LogType> LogTypeUserUpdates { get; set; } = [];
    public virtual ICollection<Log> LogUserInserts { get; set; } = [];

    public virtual ICollection<Log> LogUserUpdates { get; set; } = [];

    public virtual ICollection<NotificationType> NotificationTypeUserInserts { get; set; } = [];
    public virtual ICollection<NotificationType> NotificationTypeUserUpdates { get; set; } = [];

    public virtual ICollection<Notification> NotificationUserInserts { get; set; } = [];

    public virtual ICollection<Notification> NotificationUserUpdates { get; set; } = [];
    public virtual ICollection<PaymentTerm> PaymentTermUserInserts { get; set; } = [];

    public virtual ICollection<PaymentTerm> PaymentTermUserUpdates { get; set; } = [];

    public virtual ICollection<Region> RegionUserInserts { get; set; } = [];
    public virtual ICollection<Region> RegionUserUpdates { get; set; } = [];

    public virtual ICollection<Setting> SettingUserInserts { get; set; } = [];

    public virtual ICollection<Setting> SettingUserUpdates { get; set; } = [];

    public virtual ICollection<TaskStatusType> TaskStatusTypeUserInserts { get; set; } = [];
    public virtual ICollection<TaskStatusType> TaskStatusTypeUserUpdates { get; set; } = [];

    public virtual ICollection<TaxCode> TaxCodeUserInserts { get; set; } = [];

    public virtual ICollection<TaxCode> TaxCodeUserUpdates { get; set; } = [];

    public virtual ICollection<Tenant> TenantUserInserts { get; set; } = [];

    public virtual ICollection<Tenant> TenantUserUpdates { get; set; } = [];

    public virtual ICollection<TitleType> TitleTypeUserInserts { get; set; } = [];
    public virtual ICollection<TitleType> TitleTypeUserUpdates { get; set; } = [];

    public virtual ICollection<Title> TitleUserInserts { get; set; } = [];

    public virtual ICollection<Title> TitleUserUpdates { get; set; } = [];
    public virtual ICollection<TotalType> TotalTypeUserInserts { get; set; } = [];

    public virtual ICollection<TotalType> TotalTypeUserUpdates { get; set; } = [];

    public virtual ICollection<TranslationGroup> TranslationGroupUserInserts { get; set; } = [];
    public virtual ICollection<TranslationGroup> TranslationGroupUserUpdates { get; set; } = [];

    public virtual ICollection<Translation> TranslationUserInserts { get; set; } = [];

    public virtual ICollection<Translation> TranslationUserUpdates { get; set; } = [];
    public virtual ICollection<UnitOfMeasure> UnitOfMeasureUserInserts { get; set; } = [];

    public virtual ICollection<UnitOfMeasure> UnitOfMeasureUserUpdates { get; set; } = [];



    public virtual ICollection<Warehouse> WarehouseUserInserts { get; set; } = [];

    public virtual ICollection<Warehouse> WarehouseUserUpdates { get; set; } = [];


    public virtual ICollection<WorkflowStatusType> WorkflowStatusTypeUserInserts { get; set; } = [];
    public virtual ICollection<WorkflowStatusType> WorkflowStatusTypeUserUpdates { get; set; } = [];

    public virtual ICollection<WorkplaceType> WorkplaceTypeUserInserts { get; set; } = [];
    public virtual ICollection<WorkplaceType> WorkplaceTypeUserUpdates { get; set; } = [];

    public virtual ICollection<WorkflowAuthorizationType> WorkflowAuthorizationTypeUserInserts { get; set; } = [];
    public virtual ICollection<WorkflowAuthorizationType> WorkflowAuthorizationTypeUserUpdates { get; set; } = [];

    public virtual ICollection<WarehouseType> WarehouseTypeUserInserts { get; set; } = [];
    public virtual ICollection<WarehouseType> WarehouseTypeUserUpdates { get; set; } = [];

    public virtual ICollection<UserGroupUser> UserGroupUsers { get; set; } = [];

    public virtual ICollection<UserGroup> UserGroupUserInserts { get; set; } = [];
    public virtual ICollection<UserGroup> UserGroupUserUpdates { get; set; } = [];

    public virtual ICollection<UserGroupUser> UserGroupUserUserInserts { get; set; } = [];
    public virtual ICollection<UserGroupUser> UserGroupUserUserUpdates { get; set; } = [];

    public virtual ICollection<UserTenant> UserTenantUserInserts { get; set; } = [];
    public virtual ICollection<UserTenant> UserTenantUserUpdates { get; set; } = [];
    public virtual ICollection<UserTenant> UserTenants { get; set; } = [];

    public virtual ICollection<Log> LogUsers { get; set; } = [];

    public virtual ICollection<TaskType> TaskTypeUserInserts { get; set; } = [];
    public virtual ICollection<TaskType> TaskTypeUserUpdates { get; set; } = [];



}

