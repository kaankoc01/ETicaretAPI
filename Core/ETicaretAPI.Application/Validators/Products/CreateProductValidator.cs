using ETicaretAPI.Application.ViewModels.Products;
using FluentValidation;

namespace ETicaretAPI.Application.Validators.Products
{
    public class CreateProductValidator : AbstractValidator<VM_Create_Product>
    {
        public CreateProductValidator()
        {
            RuleFor(x => x.Name).NotEmpty().NotNull().WithMessage("Lütfen ürün adını boş geçmeyiniz").MaximumLength(150).MinimumLength(5).WithMessage("Lütfen ürün adını 5 ile 150 arasında giriniz.");
            RuleFor(x => x.Price).NotEmpty().NotNull().WithMessage("Lütfen ürün bilgisini boş geçmeyiniz.").Must(y => y >= 0).WithMessage("ürün bilgisi negatif olamaz");
            RuleFor(x => x.Stock).NotEmpty().NotNull().WithMessage("Lütfen stok bilgisini boş geçmeyiniz.").Must(y => y >= 0).WithMessage("Stok bilgisi negatif olamaz");
        }
    }
}
