using EntityLayer.Concrate;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BusinessLayer.FluentValidation
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.CategoryName).NotEmpty().WithMessage("Category name can not be empty.");
            RuleFor(x => x.CategoryName).MaximumLength(20).WithMessage("Category name can contain maximum 20 characters.");
            RuleFor(x => x.CategoryName).MinimumLength(3).WithMessage("Category name can contain minimum 3 characters.");

            RuleFor(x => x.CategoryDescription).NotEmpty().WithMessage("Category description can not be empty");
            RuleFor(x => x.CategoryDescription).MaximumLength(100).WithMessage("Category name can contain maximum 100 characters.");
            RuleFor(x => x.CategoryDescription).MinimumLength(5).WithMessage("Category name can contain minimum 3 characters.");

        }
    }
}