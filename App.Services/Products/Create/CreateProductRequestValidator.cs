using FluentValidation;

namespace App.Services.Products.Create;

public class CreateProductRequestValidator : AbstractValidator<CreateProductRequest>
{
    public CreateProductRequestValidator()
    {
        RuleFor(x => x.Name)
               //.NotNull().WithMessage("Ürün ismi gereklidir.")
               .NotEmpty().WithMessage("ürün ismi gereklidir.")
               .Length(3, 10).WithMessage("ürün ismi  3 ile 10 karakter arasında olmalıdır.");
        //.MustAsync(MustUniqueProductNameAsync).WithMessage("ürün ismi veritabanında bulunmaktadır.");
        //.Must(MustUniqueProductName).WithMessage("ürün ismi veritabanında bulunmaktadır.");

        // price validation
        RuleFor(x => x.Price)
            .GreaterThan(0).WithMessage("ürün fiyatı 0'dan büyük olmalıdır.");

        //stock inclusiveBetween validation
        RuleFor(x => x.Stock)
            .InclusiveBetween(1, 100).WithMessage("stok adedi 1 ile 100 arasında olmalıdır");
    }
}
