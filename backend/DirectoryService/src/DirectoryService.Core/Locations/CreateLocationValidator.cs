using DirectoryService.Contracts;
using FluentValidation;

namespace DirectoryService.Core.Locations;

public sealed class CreateLocationValidator : AbstractValidator<CreateLocationDto>
{
    public CreateLocationValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name cannot be empty")
            .MaximumLength(150).WithMessage("Name cannot be more than 150 characters");
        
        RuleFor(x => x.Country)
            .NotEmpty().WithMessage("Country cannot be empty")
            .MaximumLength(100).WithMessage("Country cannot be more than 100 characters");
        
        RuleFor(x => x.Region)
            .NotEmpty().WithMessage("Region cannot be empty")
            .MaximumLength(100).WithMessage("Region cannot be more than 100 characters");
        
        RuleFor(x => x.City)
            .NotEmpty().WithMessage("City cannot be empty")
            .MaximumLength(100).WithMessage("City cannot be more than 100 characters");
            
        RuleFor(x => x.Street)
            .NotEmpty().WithMessage("Street cannot be empty")
            .MaximumLength(100).WithMessage("Street cannot be more than 100 characters");
            
        RuleFor(x => x.HouseNumber)
            .NotEmpty().WithMessage("HouseNumber cannot be empty")
            .MaximumLength(50).WithMessage("HouseNumber cannot be more than 50 characters");
    }
}