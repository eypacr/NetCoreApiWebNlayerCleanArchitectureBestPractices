namespace App.Repositories.Products;

public interface IAuditEntity
{
    public DateTime Created { get; set; }

    public DateTime? Updated { get; set; }
}