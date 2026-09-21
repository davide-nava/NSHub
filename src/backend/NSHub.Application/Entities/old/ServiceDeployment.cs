using PlanetHub.Models;

namespace PlanetHub.ApplicationCore.Entities;

public class ServiceDeployment : BaseEntity
{
    public string SiteName { get; set; } = null!;

    public string RelativeServicePath { get; set; } = null!;

    public string RelativeApplicationPath { get; set; } = null!;

    public string ServiceName { get; set; } = null!;

    public string ServiceNamespace { get; set; } = null!;
}
