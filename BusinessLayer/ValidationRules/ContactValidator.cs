using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class ContactValidator : AbstractValidator<Contact>
    {
        public ContactValidator() 
        {
            RuleFor(x => x.UserMail).NotEmpty().WithMessage("Mail adresini boş geçemezsiniz");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Konuyu boş geçemezsiniz!");
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Kullanıcı adını boş geçemezsiniz!");
            RuleFor(x => x.UserMail).MinimumLength(3).WithMessage("Mail adresine en az 3 karakter girmelisiniz!");
            RuleFor(x => x.UserMail).MaximumLength(20).WithMessage("Mail adresine en fazla 20 karakter girebilirsiniz!");
            RuleFor(x => x.Message).MaximumLength(100).WithMessage("Mesaj açıklamasına en fazla 100 karakter girebilirsiniz!");
        }
    }
}
