// <copyright file="CodiceFiscaleHelper.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using System.Globalization;

namespace NSHub.Application.Helpers;

public static class CodiceFiscaleHelper
{
    private static readonly Dictionary<char, int> EvenValues = new()
    {
        { '0', 0 }, { '1', 1 }, { '2', 2 }, { '3', 3 }, { '4', 4 }, { '5', 5 }, { '6', 6 }, { '7', 7 }, { '8', 8 }, { '9', 9 },
        { 'A', 0 }, { 'B', 1 }, { 'C', 2 }, { 'D', 3 }, { 'E', 4 }, { 'F', 5 }, { 'G', 6 }, { 'H', 7 }, { 'I', 8 }, { 'J', 9 },
        { 'K', 10 }, { 'L', 11 }, { 'M', 12 }, { 'N', 13 }, { 'O', 14 }, { 'P', 15 }, { 'Q', 16 }, { 'R', 17 }, { 'S', 18 }, { 'T', 19 },
        { 'U', 20 }, { 'V', 21 }, { 'W', 22 }, { 'X', 23 }, { 'Y', 24 }, { 'Z', 25 },
    };

    private static readonly Dictionary<char, int> OddValues = new()
    {
        { '0', 1 }, { '1', 0 }, { '2', 5 }, { '3', 7 }, { '4', 9 }, { '5', 13 }, { '6', 15 }, { '7', 17 }, { '8', 19 }, { '9', 21 },
        { 'A', 1 }, { 'B', 0 }, { 'C', 5 }, { 'D', 7 }, { 'E', 9 }, { 'F', 13 }, { 'G', 15 }, { 'H', 17 }, { 'I', 19 }, { 'J', 21 },
        { 'K', 2 }, { 'L', 4 }, { 'M', 18 }, { 'N', 20 }, { 'O', 11 }, { 'P', 3 }, { 'Q', 6 }, { 'R', 8 }, { 'S', 12 }, { 'T', 14 },
        { 'U', 16 }, { 'V', 10 }, { 'W', 22 }, { 'X', 25 }, { 'Y', 24 }, { 'Z', 23 },
    };

    private static readonly char[] ControlCharacters =
    [
        'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T',
        'U', 'V', 'W', 'X', 'Y', 'Z'
    ];

    public static string GenerateFiscalCode(string? firstName, string? lastName, DateOnly? birthDate, string? gender, string? countryCode)
    {
        if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName) || birthDate == null || string.IsNullOrWhiteSpace(gender) || string.IsNullOrWhiteSpace(countryCode))
        {
            return string.Empty;
        }

        var surnameCode = GenerateSurnameCode(lastName);
        var nameCode = GenerateNameCode(firstName);
        var dateGenderCode = GenerateDateGenderCode(birthDate.Value, gender);
        var partialCode = surnameCode + nameCode + dateGenderCode + countryCode;

        return partialCode + CalculateFiscalCodeCheckSumDigit(partialCode);
    }

    private static string GenerateSurnameCode(string surname)
    {
		var consonants = ExtractConsonants(surname);
		var vowels = ExtractVowels(surname);
		var code = consonants + vowels + "XXX";
		return code[..3];
	}

    private static string GenerateNameCode(string name)
    {
        var consonants = ExtractConsonants(name);
        var vowels = ExtractVowels(name);

        if (consonants.Length >= 4)
        {
            consonants = consonants[0].ToString() + consonants[2] + consonants[3];
        }

        var code = consonants + vowels + "XXX";
        return code[..3];
    }

    private static string ExtractConsonants(string input) => string.Concat(input.Where(c => char.IsLetter(c) && IsConsonant(c))).ToUpper(CultureInfo.CurrentCulture);

    private static string ExtractVowels(string input) => string.Concat(input.Where(c => char.IsLetter(c) && IsVowel(c))).ToUpper(CultureInfo.CurrentCulture);

    private static string GenerateDateGenderCode(DateOnly birthDate, string gender)
    {
        var year = birthDate.Year % 100;
        var yearCode = year.ToString("D2", CultureInfo.CurrentCulture);

        var monthCode = "ABCDEHLMPRST"[birthDate.Month - 1].ToString();

        var day = birthDate.Day;
        if (gender.Equals("F", StringComparison.OrdinalIgnoreCase))
        {
            day += 40;
        }

        var dayCode = day.ToString("D2", CultureInfo.CurrentCulture);

        return yearCode + monthCode + dayCode;
    }

    private static char CalculateFiscalCodeCheckSumDigit(string codiceFiscale)
    {
        if (codiceFiscale.Length != 15)
        {
            throw new ArgumentException("The tax code must be 15 characters long.");
        }

        var sum = 0;
        for (var i = 0; i < 15; i++)
        {
            var c = codiceFiscale[i];
            if (i % 2 == 0)
            {
                sum += OddValues[c];
            }
            else
            {
                sum += EvenValues[c];
            }
        }

        var remainder = sum % 26;
        return ControlCharacters[remainder];
    }

    private static bool IsConsonant(char c) => "BCDFGHJKLMNPQRSTVWXYZ".Contains(char.ToUpper(c, CultureInfo.CurrentCulture), StringComparison.CurrentCulture);

    private static bool IsVowel(char c) => "AEIOU".Contains(char.ToUpper(c, CultureInfo.CurrentCulture), StringComparison.CurrentCulture);
}
