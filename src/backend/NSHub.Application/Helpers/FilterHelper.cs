// <copyright file="FilterHelper.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using System.Globalization;

namespace NSHub.Application.Helpers;

public static class FilterHelper
{
    public static bool TryParseArray(string? value, out string[] filters)
    {
        filters = [];

        try
        {
            if (string.IsNullOrEmpty(value))
            {
                return false;
            }

            filters = [.. EnumerateValue()];

            return true;

            IEnumerable<string> EnumerateValue()
            {
                var tokens = new List<string>();

                if (value.Contains('-', StringComparison.InvariantCulture))
                {
                    tokens = [.. value.Split('-')];
                }
                else if (value.Contains("###NSHub_split###", StringComparison.InvariantCulture))
                {
                    tokens = [.. value.Split("###NSHub_split###")];
                }
                else
                {
                    tokens.Add(value);
                }

                foreach (var token in tokens)
                {
                    yield return token;
                }
            }
        }
        catch (ArgumentException)
        {
            return false;
        }
        catch (FormatException)
        {
            return false;
        }
        catch (OverflowException)
        {
            return false;
        }
    }

    public static bool TryParseEnums<TEnum>(string? value, out TEnum[] filters)
        where TEnum : struct
    {
        filters = [];

        try
        {
            if (string.IsNullOrEmpty(value))
            {
                return false;
            }

            filters = [.. EnumerateValue()];

            return true;

            IEnumerable<TEnum> EnumerateValue()
            {
                var tokens = new List<string>();

                if (value.Contains('-', StringComparison.InvariantCulture))
                {
                    tokens = [.. value.Split('-')];
                }
                else if (value.Contains("###Progel_split###", StringComparison.InvariantCulture))
                {
                    tokens = [.. value.Split("###Progel_split###")];
                }
                else
                {
                    tokens.Add(value);
                }

                foreach (var token in tokens)
                {
                    if (Enum.TryParse(token, true, out TEnum filter))
                    {
                        yield return filter;
                    }
                }
            }
        }
        catch (ArgumentException)
        {
            return false;
        }
        catch (FormatException)
        {
            return false;
        }
        catch (OverflowException)
        {
            return false;
        }
    }

    public static bool TryParseDecimalRange(string? value, out decimal? from, out decimal? to)
    {
        from = null;
        to = null;

        try
        {
            if (string.IsNullOrEmpty(value))
            {
                return false;
            }

            var tokens = new List<string>();

            if (value.Contains('-', StringComparison.InvariantCulture))
            {
                tokens = [.. value.Split('-')];
            }
            else if (value.Contains("###Progel_split###", StringComparison.InvariantCulture))
            {
                tokens = [.. value.Split("###Progel_split###")];
            }
            else
            {
                tokens.Add(value);
            }

            if (tokens.Count != 2)
            {
                return false;
            }

            if (!string.IsNullOrEmpty(tokens[0]))
            {
                if (!decimal.TryParse(tokens[0], out var fromValue))
                {
                    return false;
                }

                from = fromValue;
            }

            if (!string.IsNullOrEmpty(tokens[1]))
            {
                if (!decimal.TryParse(tokens[1], out var toValue))
                {
                    return false;
                }

                to = toValue;
            }

            return from.HasValue || to.HasValue;
        }
        catch (ArgumentException)
        {
            return false;
        }
        catch (FormatException)
        {
            return false;
        }
        catch (OverflowException)
        {
            return false;
        }
    }

    public static bool TryParseDateRange(string? value, out DateTime? from, out DateTime? to)
    {
        from = null;
        to = null;

        try
        {
            if (string.IsNullOrEmpty(value))
            {
                return false;
            }

            var tokens = new List<string>();

            if (value.Contains('-', StringComparison.InvariantCulture))
            {
                tokens = [.. value.Split('-')];
            }
            else
                if (value.Contains("###Progel_split###", StringComparison.InvariantCulture))
            {
                tokens = [.. value.Split("###Progel_split###")];
            }
            else
            {
                tokens.Add(value);
            }

            if (tokens.Count != 2)
            {
                return false;
            }

            if (!string.IsNullOrEmpty(tokens[0]))
            {
                if (!DateTime.TryParseExact(tokens[0], "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.None, out var fromValue))
                {
                    return false;
                }

                from = fromValue;
            }

            if (!string.IsNullOrEmpty(tokens[1]))
            {
                if (!DateTime.TryParseExact(tokens[1], "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.None, out var toValue))
                {
                    return false;
                }

                to = toValue;
            }

            if (to > new DateTime(9999, 12, 31, 0, 0, 0, DateTimeKind.Local))
            {
                to = new DateTime(9999, 12, 31, 0, 0, 0, DateTimeKind.Local);
            }

            if (from < new DateTime(1753, 01, 01, 0, 0, 0, DateTimeKind.Local))
            {
                from = new DateTime(1753, 01, 01, 0, 0, 0, DateTimeKind.Local);
            }

            return from.HasValue || to.HasValue;
        }
        catch (ArgumentException)
        {
            return false;
        }
        catch (FormatException)
        {
            return false;
        }
        catch (OverflowException)
        {
            return false;
        }
    }

    public static bool TryParseGuids(string? value, out Guid[] filters)
    {
        filters = [];

        try
        {
            if (string.IsNullOrEmpty(value))
            {
                return false;
            }

            if (value.Contains("###Progel_split###", StringComparison.InvariantCulture))
            {
                var ids = value.Split("###Progel_split###").ToList();

                filters = [.. ids.Where(id => Guid.TryParse(id, out _)).Select(Guid.Parse)];
            }
            else
            {
                filters = [.. SplitGuids(value)];
            }

            return true;

            static IEnumerable<Guid> SplitGuids(string input, int guidLength = 36)
            {
                var list = new List<Guid>();

                var startIdx = 0;

                var hasMore = input.Length >= startIdx + guidLength;

                while (hasMore)
                {
                    var guidString = input.Substring(startIdx, guidLength);

                    if (Guid.TryParse(guidString, out var guid))
                    {
                        yield return guid;
                    }

                    list.Add(guid);

                    startIdx += guidLength + 1; // + 1 to skip the separator char

                    hasMore = input.Length >= startIdx + guidLength;
                }
            }
        }
        catch (ArgumentException)
        {
            return false;
        }
        catch (FormatException)
        {
            return false;
        }
        catch (OverflowException)
        {
            return false;
        }
    }
}
