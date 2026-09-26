namespace NSHub.Domain.Common;

public interface IHasRowVersion
{
    byte[] RowVersion { get; set; }
}
