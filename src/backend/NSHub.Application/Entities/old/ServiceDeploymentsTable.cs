
using NSHub.Models;

namespace NSHub.ApplicationCore.Entities;

public class ServiceDeploymentsTable : BaseEntity
{
    public Guid ServiceDeploymentHash { get; set; }

    public string SiteName { get; set; } = null!;

    public string RelativeServicePath { get; set; } = null!;

    public string RelativeApplicationPath { get; set; } = null!;

    public string ServiceName { get; set; } = null!;

    public string ServiceNamespace { get; set; } = null!;
}
