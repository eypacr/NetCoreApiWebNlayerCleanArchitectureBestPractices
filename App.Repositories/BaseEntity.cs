namespace App.Repositories.Products;

public class BaseEntity<T>
{
    public T Id { get; set; } = default!;
}