using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class MessageValidator:AbstractValidator<Message>
    {
        public MessageValidator() 
        {
            RuleFor(x => x.ReceiverMail).NotEmpty().WithMessage("E-posta adresi boş olamaz.").EmailAddress().WithMessage("Geçersiz e-posta adresi.");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Konuyu boş geçemezsiniz.");
            RuleFor(x => x.MessageContent).NotEmpty().WithMessage("Mesajı boş geçemezsiniz.");
            RuleFor(x => x.ReceiverMail).MinimumLength(11).WithMessage("E-posta addresiniz en az 11 karakter olmalıdır.").EmailAddress().WithMessage("Geçersiz e-posta adresi.");
            RuleFor(x => x.ReceiverMail).MaximumLength(50).WithMessage("E-posta addresiniz en fazla 50 karakter olmalıdır.").EmailAddress().WithMessage("Geçersiz e-posta adresi.");
            RuleFor(x => x.SenderMail).MinimumLength(11).WithMessage("E-posta addresiniz en az 11 karakter olmalıdır.").EmailAddress().WithMessage("Geçersiz e-posta adresi.");
            RuleFor(x => x.SenderMail).MaximumLength(50).WithMessage("E-posta addresiniz  en fazla 50 karakter olmalıdır.").EmailAddress().WithMessage("Geçersiz e-posta adresi.");
            RuleFor(x => x.Subject).MaximumLength(50).WithMessage("Konu en fazla 50 karakter olmalıdır.");
        }
    }
}
