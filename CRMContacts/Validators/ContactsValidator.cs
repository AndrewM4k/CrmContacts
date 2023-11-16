using CRMContacts.Dtos;
using CRMContacts.Persistance;
using FluentValidation;
using System.Text.RegularExpressions;

namespace CRMContacts.Validators
{
    public class ContactsValidator: AbstractValidator<AddContactDto>
    {
        private readonly ContactsDbContext _context;
        public ContactsValidator(ContactsDbContext context)
        {
            _context = context;

            RuleFor(e => e.MobilePhone)
            .NotEmpty().WithMessage("Phone Number is required.")
            .MinimumLength(10).WithMessage("PhoneNumber must not be less than 10 characters.")
            .MaximumLength(20).WithMessage("PhoneNumber must not exceed 50 characters.");

            RuleFor(e => e.BirthDate)
                .LessThanOrEqualTo(DateTime.Now);

            RuleFor(e => e.Name)
                .NotEmpty()
                .MinimumLength(2);

            RuleFor(s => s.JobTitle)
                .NotEmpty()
                .MinimumLength(2);

        }
    }
}
