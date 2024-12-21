using FluentValidation;
using Microsoft.Extensions.Localization;
using PhoneNumbers;
using School.Core.Abstractions.Services;
using School.Core.CQRS.Students.Commands;
using School.Core.Resources;
using School.Data.Constants.AppMetaData;

namespace School.Handlers.Validations.Students
{
    public class AddStudentValidation : AbstractValidator<AddStudentCommand>
    {
        private IStudentService _studentService;
        private IStringLocalizer<SharedResource> _stringLocalizer;
        public AddStudentValidation(IStudentService studentService, IStringLocalizer<SharedResource> stringLocalizer)
        {
            _studentService = studentService;
            _stringLocalizer = stringLocalizer;
            ApplyValidationRules();

        }
        public void ApplyValidationRules()
        {

            RuleFor(x => x.NameAr).Cascade(CascadeMode.Stop)
                .NotEmpty().NotNull().WithMessage(_stringLocalizer[Localization.Validations.NotEmpty])
                .MustAsync(async (name, _) => !await _studentService.IsNameExistAsync(name))
                .WithMessage(_stringLocalizer[Localization.Validations.Exists]);


            RuleFor(x => x.NameEn).Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage(_stringLocalizer[Localization.Validations.NotEmpty]).NotNull()
                .WithMessage(_stringLocalizer[Localization.Validations.NotEmpty
                ]).MustAsync(async (name, _) => !await _studentService.IsNameExistAsync(name))
                .WithMessage(_stringLocalizer[Localization.Validations.Exists]);

            RuleFor(x => x.Phone).Cascade(CascadeMode.Stop).Must(IsValidPhoneNumber).WithMessage(_stringLocalizer[Localization.Validations.InValid]);
            RuleFor(x => x.Address).Cascade(CascadeMode.Stop).NotEmpty().WithMessage(_stringLocalizer[Localization.Validations.NotEmpty])
                .NotNull().WithMessage(_stringLocalizer[Localization.Validations.NotEmpty]);
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
