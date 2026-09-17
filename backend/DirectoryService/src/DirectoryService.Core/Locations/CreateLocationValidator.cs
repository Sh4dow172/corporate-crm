using DirectoryService.Contracts;
using FluentValidation;

namespace DirectoryService.Core.Locations;

public sealed class CreateLocationValidator : AbstractValidator<CreateLocationDto>
{
    public CreateLocationValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Название не может быть пустым")
            .MaximumLength(150).WithMessage("Название не может превышать 150 символов");
        
        RuleFor(x => x.Country)
            .NotEmpty().WithMessage("Страна не может быть пустой")
            .MaximumLength(100).WithMessage("Название страны не может превышать 100 symbols");
        
        RuleFor(x => x.Region)
            .NotEmpty().WithMessage("Регион не может быть пустым")
            .MaximumLength(100).WithMessage("Название региона не может превышать 100 символов");
        
        RuleFor(x => x.City)
            .NotEmpty().WithMessage("Город не может быть пустым")
            .MaximumLength(100).WithMessage("Название города не может превышать 100 символов");
            
        RuleFor(x => x.Street)
            .NotEmpty().WithMessage("Улица не может быть пустой")
            .MaximumLength(100).WithMessage("Название улицы не может превышать 100 символов");
            
        RuleFor(x => x.HouseNumber)
            .NotEmpty().WithMessage("Номер дома не может быть пустым")
            .MaximumLength(50).WithMessage("Номер дома не может превышать 50 символов");
    }
}