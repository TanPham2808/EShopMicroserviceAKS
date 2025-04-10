using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EShop.Core.DTO;
using FluentValidation;

namespace EShop.Core.Validators
{
    public class LoginRequestValidator : AbstractValidator<LoginRequest>
    {
        public LoginRequestValidator()
        {
            //Email
            RuleFor(temp => temp.Email)
              .NotEmpty().WithMessage("Không để trống email")
              .EmailAddress().WithMessage("Email không đúng format")
              ;

            //Password
            RuleFor(temp => temp.Password)
              .NotEmpty().WithMessage("Không để trống mật khẩu")
              ;
        }
    }
}
