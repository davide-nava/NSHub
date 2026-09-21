// <copyright file="CultureInfoHelper.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using System.Globalization;

namespace NSHub.Application.Localizations.Helpers;

public static class CultureInfoHelper
{
	public static void SetCultureInfo(string cultureName, string numberDecimalSeparator = ".", string numberGroupSeparator = ",", int decimalDigits = 10, string dateFormat = "dd/MM/yyyy")
	{
		if (string.IsNullOrWhiteSpace(numberDecimalSeparator))
		{
			numberDecimalSeparator = ".";
		}

		if (string.IsNullOrWhiteSpace(numberGroupSeparator))
		{
			numberGroupSeparator = ",";
		}

		CultureInfo newCulture = new(cultureName)
		{
			NumberFormat =
			{
				NumberDecimalSeparator = numberDecimalSeparator,
				NumberGroupSeparator = numberGroupSeparator,
				NumberDecimalDigits = decimalDigits,
			},
			DateTimeFormat =
			{
			ShortDatePattern = dateFormat,
			},
		};

		CultureInfo.CurrentCulture = newCulture;
		CultureInfo.CurrentUICulture = newCulture;
		CultureInfo.DefaultThreadCurrentCulture = newCulture;
		CultureInfo.DefaultThreadCurrentUICulture = newCulture;
		Thread.CurrentThread.CurrentCulture = newCulture;
		Thread.CurrentThread.CurrentUICulture = newCulture;

		Thread.CurrentThread.CurrentCulture.DateTimeFormat.ShortDatePattern = dateFormat;
		Thread.CurrentThread.CurrentUICulture.DateTimeFormat.ShortDatePattern = dateFormat;
		Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator = numberDecimalSeparator;
		Thread.CurrentThread.CurrentUICulture.NumberFormat.NumberDecimalSeparator = numberDecimalSeparator;
		Thread.CurrentThread.CurrentCulture.NumberFormat.NumberGroupSeparator = numberGroupSeparator;
		Thread.CurrentThread.CurrentUICulture.NumberFormat.NumberGroupSeparator = numberGroupSeparator;
		Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalDigits = decimalDigits;
		Thread.CurrentThread.CurrentUICulture.NumberFormat.NumberDecimalDigits = decimalDigits;

		CultureInfo.DefaultThreadCurrentCulture.DateTimeFormat.ShortDatePattern = dateFormat;
		CultureInfo.DefaultThreadCurrentUICulture.DateTimeFormat.ShortDatePattern = dateFormat;
		CultureInfo.DefaultThreadCurrentCulture.NumberFormat.NumberDecimalSeparator = numberDecimalSeparator;
		CultureInfo.DefaultThreadCurrentUICulture.NumberFormat.NumberDecimalSeparator = numberDecimalSeparator;
		CultureInfo.DefaultThreadCurrentCulture.NumberFormat.NumberGroupSeparator = numberGroupSeparator;
		CultureInfo.DefaultThreadCurrentCulture.NumberFormat.NumberDecimalDigits = decimalDigits;
		CultureInfo.DefaultThreadCurrentUICulture.NumberFormat.NumberGroupSeparator = numberGroupSeparator;
		CultureInfo.DefaultThreadCurrentUICulture.NumberFormat.NumberDecimalDigits = decimalDigits;
	}
}
