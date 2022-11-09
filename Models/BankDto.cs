using System;
using FluentValidation;

namespace FairBankApi.Models
{
    public class BankDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Swift { get; set; }
        public string Address { get; set; }
        public int UserAdminId { get; set; }
    }

    public class BankValidator : AbstractValidator<BankDto>
    {
        public BankValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .MinimumLength(3)
                .MaximumLength(100);

            RuleFor(x => x.Swift)
                .NotEmpty()
                .MinimumLength(2)
                .MaximumLength(20);

            RuleFor(x => x.Address)
                .NotEmpty()
                .MinimumLength(4)
                .MaximumLength(100);
        }
    }
}

