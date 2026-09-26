// <copyright file="EmployeeTests.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Application.UnitTests.HR;

using NSHub.Domain.Entities;
using NSHub.Domain.Enums;
using NSHub.Domain.Exceptions;
using NSHub.Domain.HR.ValueObjects;

public class EmployeeTests
{
    [Fact]
    public void Constructor_WithValidArguments_ShouldInitializeEmployee()
    {
        // Arrange
        var employeeId = EmployeeId.New();

        // Act
        var employee = new Employee(
            employeeId,
            "Elena",
            "Bernasconi",
            "elena.bernasconi@navasoft.ch",
            "Finance",
            40.0m,
            StatutoryWeeklyLimit.Hours45,
            Oll1Regime.StandardRecord,
            LanguageCode.It);

        // Assert
        _ = employee.Id.Should().Be(employeeId);
        _ = employee.FirstName.Should().Be("Elena");
        _ = employee.LastName.Should().Be("Bernasconi");
        _ = employee.Email.Should().Be("elena.bernasconi@navasoft.ch");
        _ = employee.Department.Should().Be("Finance");
        _ = employee.ContractualWeeklyHours.Should().Be(40.0m);
        _ = employee.IsActive.Should().BeTrue();
    }

    [Fact]
    public void Constructor_WithEmptyName_ShouldThrowBusinessRuleValidationException()
    {
        // Act
        var act = () => new Employee(
            EmployeeId.New(),
            "",
            "Bernasconi",
            "elena@navasoft.ch",
            "Finance",
            40.0m,
            StatutoryWeeklyLimit.Hours45,
            Oll1Regime.StandardRecord,
            LanguageCode.It);

        // Assert
        _ = act.Should().Throw<BusinessRuleValidationException>()
            .WithMessage("*First name*");
    }

    [Fact]
    public void UpdateContractualTerms_WithValidHours_ShouldUpdateTerms()
    {
        // Arrange
        var employee = new Employee(
            EmployeeId.New(),
            "Elena",
            "Bernasconi",
            "elena@navasoft.ch",
            "Finance",
            40.0m,
            StatutoryWeeklyLimit.Hours45,
            Oll1Regime.StandardRecord,
            LanguageCode.It);

        // Act
        employee.UpdateContractualTerms(35.0m, StatutoryWeeklyLimit.Hours50);

        // Assert
        _ = employee.ContractualWeeklyHours.Should().Be(35.0m);
        _ = employee.StatutoryWeeklyLimit.Should().Be(StatutoryWeeklyLimit.Hours50);
    }

    [Fact]
    public void UpdateContractualTerms_WithExcessiveHours_ShouldThrowBusinessRuleValidationException()
    {
        // Arrange
        var employee = new Employee(
            EmployeeId.New(),
            "Elena",
            "Bernasconi",
            "elena@navasoft.ch",
            "Finance",
            40.0m,
            StatutoryWeeklyLimit.Hours45,
            Oll1Regime.StandardRecord,
            LanguageCode.It);

        // Act
        var act = () => employee.UpdateContractualTerms(65.0m, StatutoryWeeklyLimit.Hours45);

        // Assert
        _ = act.Should().Throw<BusinessRuleValidationException>()
            .WithMessage("*between 1 and 60*");
    }

    [Fact]
    public void Deactivate_ShouldSetIsActiveToFalse()
    {
        // Arrange
        var employee = new Employee(
            EmployeeId.New(),
            "Elena",
            "Bernasconi",
            "elena@navasoft.ch",
            "Finance",
            40.0m,
            StatutoryWeeklyLimit.Hours45,
            Oll1Regime.StandardRecord,
            LanguageCode.It);

        // Act
        employee.Deactivate();

        // Assert
        _ = employee.IsActive.Should().BeFalse();
    }
}
