using proDuck.Application.ViewModels.Products;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proDuck.Application.Validators.Products
{
    public class CreateProductValidatior : AbstractValidator<VM_Create_Product>
    {
        public CreateProductValidatior()
        {
            RuleFor(x=>x.Name)
                .NotEmpty()
                .NotNull()
                .WithMessage("Name is required")
                .MaximumLength(150)
                .MinimumLength(3)
                .WithMessage("Name must be between 3 and 150 characters");

            RuleFor(x=>x.Stock)
                .NotNull().
                WithMessage("Stock is required")
                .Must(x=>x>=0)
                .WithMessage("Stock must be greater than 0");
            RuleFor(x=>x.Price)
                .NotNull()
                .WithMessage("Price is required")
                .Must(x=>x>=0)
                .WithMessage("Price must be greater than 0");
        }
    }
}
