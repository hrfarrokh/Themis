using FluentValidation;
using Themis.Application.Contracts;
using Themis.Domain;

namespace Themis.Application
{
    public class PlaceExhibitionOrderRequestValidator : AbstractValidator<PlaceExhibitionOrderRequest>
    {
        public PlaceExhibitionOrderRequestValidator()
        {
            RuleFor(e => e.FullName)
                .NotEmpty()
                .NotNull();

            RuleFor(e => e.PhoneNumber)
                .Matches(PhoneNumber.Pattern)
                .NotEmpty()
                .NotNull();

            RuleForEach(e => e.Items)
                .NotNull()
                .NotEmpty()
                .ChildRules(icr =>
                {
                    icr.RuleFor(e => e.OrderId)
                       .NotEmpty()
                       .NotNull();

                    icr.RuleFor(e => e.PackageId)
                       .NotEmpty()
                       .NotNull();

                    icr.RuleFor(e => e.Appointment)
                        .NotNull()
                        .ChildRules(vcr =>
                        {
                            vcr.RuleFor(e => e.FromDateTime)
                               .NotEmpty()
                               .NotNull();

                            vcr.RuleFor(e => e.ToDateTime)
                               .NotEmpty()
                               .NotNull();
                        });
                });

            RuleFor(e => e.CityId)
                .NotEmpty()
                .NotNull();

        }
    }
}
