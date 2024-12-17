using FluentValidation;
using PhoneNumbers;
using School.Core.Abstractions.Services;
using School.Core.CQRS.Students.Commands;

namespace School.Handlers.Validations.Students
{
    public class AddStudentValidation : AbstractValidator<AddStudentCommand>
    {
        private IStudentService _studentService;
        public AddStudentValidation(IStudentService studentService)
        {
            _studentService = studentService;
            ApplyValidationRules();

        }
        public void ApplyValidationRules()
        {

            RuleFor(x => x.NameAr).Cascade(CascadeMode.Stop).NotEmpty().NotNull().MustAsync(async (name, _) => !await _studentService.IsNameExistAsync(name)).WithMessage("Name is Exists");
            RuleFor(x => x.NameEn).Cascade(CascadeMode.Stop).NotEmpty().NotNull().MustAsync(async (name, _) => !await _studentService.IsNameExistAsync(name)).WithMessage("Name is Exists"); ;
            RuleFor(x => x.Phone).Cascade(CascadeMode.Stop).Must(IsValidPhoneNumber).WithMessage("Invalid Phone Number");
            RuleFor(x => x.Address).Cascade(CascadeMode.Stop).NotEmpty().NotNull();
        }

        private bool IsValidPhoneNumber(string phoneNumber)
        {
            if (string.IsNullOrWhiteSpace(phoneNumber))
                return false;

            var phoneNumberUtil = PhoneNumberUtil.GetInstance();
            try
            {
                var parsedNumber = phoneNumberUtil.Parse(phoneNumber, "EG");
                return phoneNumberUtil.IsValidNumber(parsedNumber);
            }
            catch (NumberParseException)
            {
                return false;
            }
        }

    }
}
