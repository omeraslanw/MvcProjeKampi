using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class WriterValidator : AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Yazar adını boş geçemezsiniz!");
            RuleFor(x => x.WriterSurName).NotEmpty().WithMessage("Yazar soyadını boş geçemezsiniz!");
            RuleFor(x => x.WriterAbout).NotEmpty().WithMessage("Hakkımda kısmını boş geçemezsiniz!");
            RuleFor(x => x.WriterTitle).NotEmpty().WithMessage("Yazar unvanını boş geçemezsiniz!");
            RuleFor(x => x.WriterName).MinimumLength(2).WithMessage("Yazar adına en az 2 karakter girmelisiniz!");
            RuleFor(x => x.WriterName).MaximumLength(20).WithMessage("Yazar adına en fazla 20 karakter girebilirsiniz!");
            RuleFor(x => x.WriterSurName).MinimumLength(2).WithMessage("Yazar soyadına en az 2 karakter girmelisiniz!");
            RuleFor(x => x.WriterSurName).MaximumLength(20).WithMessage("Yazar soyadına en fazla 20 karakter girebilirsiniz!");
            RuleFor(x => x.WriterAbout).MaximumLength(100).WithMessage("Yazar açıklamasına en fazla 100 karakter girebilirsiniz!");
        }
    }
}
