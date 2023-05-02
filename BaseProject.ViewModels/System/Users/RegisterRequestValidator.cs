using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseProject.ViewModels.System.Users
{
    public class RegisterRequestValidator : AbstractValidator<RegisterRequest>
    {
        public RegisterRequestValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Họ và tên không được để trống")
                .MaximumLength(50).WithMessage("Họ và tên không được quá 50 ký tự")
                .MinimumLength(6).WithMessage("Họ và tên không được ít hơn 6 ký tự");

            RuleFor(x => x.DateOfBir).GreaterThan(DateTime.Now.AddYears(-120)).WithMessage("Ngày sinh không được quá 120 tuổi");

            RuleFor(x => x.Email).NotEmpty().WithMessage("Email không được để trống")
                .Matches(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$")
                .WithMessage("Định dạng email không đúng");

            RuleFor(x => x.UserName).NotEmpty().WithMessage("Tên tài khoản không được để trống")
                .MaximumLength(20).WithMessage("Tên tài khoản không được quá 20 ký tự")
                .MinimumLength(6).WithMessage("Tên tài khoản không được ít hơn 6 ký tự");

            RuleFor(x => x.Password).NotEmpty().WithMessage("Mật khẩu không được để trống")
                .MinimumLength(6).WithMessage("Mật khẩu phải chứa ít nhất 6 ký tự (Hoa, thường và ký tự đặc biệt)");

            RuleFor(x => x).Custom((request, context) =>
            {
                if (request.Password != request.ConfirmPassword)
                {
                    context.AddFailure("Xác thực mật khẩu không khớp");
                }
            });
        }
    }
}
