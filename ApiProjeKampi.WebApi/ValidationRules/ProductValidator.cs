using ApiProjeKampi.WebApi.Entities;
using FluentValidation;

namespace ApiProjeKampi.WebApi.ValidationRules
{
    public class ProductValidator: AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(x=>x.ProductName).NotNull().WithMessage("Lüffen ürün adını boş geçmeyin");
            RuleFor(x=>x.ProductName).MinimumLength(2).WithMessage("Lüffen en az 2 karakter veri girişi yapın!");
            RuleFor(x=>x.ProductName).MaximumLength(100).WithMessage("Lüffen en fazla 100 karakter veri girişi yapın!");

            RuleFor(x=>x.Price).NotEmpty().WithMessage("Ürün fiyatı boş geçilmez").GreaterThan(0).WithMessage("Ürün fiyatı 0 ve 0 dan küçük olamaz").LessThan(5000).WithMessage("Ürün fiyatı 5000 üzeri olamaz");

            RuleFor(x => x.ProductDescription).NotEmpty().WithMessage("Ürün açılmama boş geçilemez");

        }
    }
}
