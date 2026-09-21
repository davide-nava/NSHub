// <copyright file="GpsCoordinate.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Domain.ValueObjects;

/// <summary>
/// Represents punctual geographic coordinates captured at the moment of clocking in or out.
/// </summary>
/// <remarks>
/// SWISS LEGAL COMPLIANCE (OLL 3 art. 26 and FADP/nLPD):
/// Pursuant to Art. 26 of Ordinance 3 on the Labor Law (OLL 3) and the Swiss Federal Act on Data Protection (FADP),
/// any continuous behavioral surveillance of employees is strictly prohibited.
/// Geolocation is strictly PUNCTUAL: captured solely as an instant snapshot upon user-initiated clock-in or clock-out
/// to validate physical presence, without any periodic or continuous background tracking.
/// </remarks>
public record GpsCoordinate
{
    /// <summary>
    /// Initializes a new instance of the <see cref="GpsCoordinate"/> class.
    /// Required by Entity Framework Core.
    /// </summary>
    protected GpsCoordinate()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="GpsCoordinate"/> class with coordinates, optional accuracy, and timestamp.
    /// </summary>
    /// <param name="latitude">The latitude in decimal degrees (-90 to 90).</param>
    /// <param name="longitude">The longitude in decimal degrees (-180 to 180).</param>
    /// <param name="accuracyMeters">The optional GPS accuracy radius in meters.</param>
    /// <param name="timestampUtc">The UTC timestamp when the coordinate was sampled.</param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when latitude or longitude is out of valid range.</exception>
    public GpsCoordinate(double latitude, double longitude, double? accuracyMeters = null, DateTime? timestampUtc = null)
    {
        if (latitude is < -90.0 or > 90.0)
        {
            throw new ArgumentOutOfRangeException(nameof(latitude), "Latitude must be between -90 and 90 degrees.");
        }

        if (longitude is < -180.0 or > 180.0)
        {
            throw new ArgumentOutOfRangeException(nameof(longitude), "Longitude must be between -180 and 180 degrees.");
        }

        Latitude = latitude;
        Longitude = longitude;
        AccuracyMeters = accuracyMeters;
        TimestampUtc = timestampUtc ?? DateTime.UtcNow;
    }

    /// <summary>
    /// Gets the latitude in decimal degrees.
    /// </summary>
    public double Latitude { get; init; }

    /// <summary>
    /// Gets the longitude in decimal degrees.
    /// </summary>
    public double Longitude { get; init; }

    /// <summary>
    /// Gets the estimated horizontal accuracy radius in meters, if provided by the device.
    /// </summary>
    public double? AccuracyMeters { get; init; }

    /// <summary>
    /// Gets the UTC timestamp when the coordinate fix was obtained.
    /// </summary>
    public DateTime TimestampUtc { get; init; }

    /// <summary>
    /// Calculates the approximate geodesic distance in meters to another GPS coordinate using the Haversine formula.
    /// </summary>
    /// <param name="other">Target geographic coordinate.</param>
    /// <returns>Calculated distance in meters.</returns>
    public double DistanceToInMeters(GpsCoordinate other)
    {
        ArgumentNullException.ThrowIfNull(other);

        const double earthRadiusMeters = 6371000.0;
        double dLat = (other.Latitude - Latitude) * Math.PI / 180.0;
        double dLon = (other.Longitude - Longitude) * Math.PI / 180.0;

        double lat1Rad = Latitude * Math.PI / 180.0;
        double lat2Rad = other.Latitude * Math.PI / 180.0;

        double a = (Math.Sin(dLat / 2.0) * Math.Sin(dLat / 2.0)) +
                   (Math.Sin(dLon / 2.0) * Math.Sin(dLon / 2.0) * Math.Cos(lat1Rad) * Math.Cos(lat2Rad));
        double c = 2.0 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1.0 - a));

        return earthRadiusMeters * c;
    }
}
