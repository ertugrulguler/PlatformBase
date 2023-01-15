namespace PlatformBase.Domain;

public interface IDbContextHandler
{
    Task SaveChangesAsync();
}