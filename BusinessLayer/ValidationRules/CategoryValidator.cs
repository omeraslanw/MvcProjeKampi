﻿using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.CategoryName).NotEmpty().WithMessage("Kategori adını boş geçemezsiniz!");
            RuleFor(x => x.CategoryDescription).NotEmpty().WithMessage("Kategori açıklamasını boş geçemezsiniz!");
            RuleFor(x => x.CategoryName).MinimumLength(3).WithMessage("Kategori adına en az 3 karakter girmelisiniz!");
            RuleFor(x => x.CategoryName).MaximumLength(20).WithMessage("Kategori adına en fazla 20 karakter girebilirsiniz!");
            RuleFor(x => x.CategoryDescription).MaximumLength(100).WithMessage("Kategori açıklamasına en fazla 100 karakter girebilirsiniz!");
        }
    }
}
