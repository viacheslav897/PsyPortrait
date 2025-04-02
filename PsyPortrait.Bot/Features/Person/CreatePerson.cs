using FluentValidation;
using MediatR;
using Newsletter.Api.Shared;
using PsyPortrait.Bot.Database;

namespace PsyPortrait.Bot.Features.Person;

public static class CreatePerson
{
    public class Command : IRequest<Result<Guid>>
    {
        public DateOnly DateOfBirth { get; set; }
    }

    public class Validator : AbstractValidator<Command>
    {
        public Validator()
        {
            RuleFor(c => c.DateOfBirth).NotEmpty();
        }
    }

    internal sealed class Handler : IRequestHandler<Command, Result<Guid>>
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IValidator<Command> _validator;
        
        public Handler(ApplicationDbContext dbContext, IValidator<Command> validator)
        {
            _dbContext = dbContext;
            _validator = validator;
        }
        
        public async Task<Result<Guid>> Handle(Command request, CancellationToken cancellationToken)
        {
            var validationResult = _validator.Validate(request);
            if (!validationResult.IsValid)
            {
                return Result.Failure<Guid>(new Error(
                    "CreateArticle.Validation",
                    validationResult.ToString()));
            }

            var person = new Entities.Person(request.DateOfBirth);
            
            // _dbContext.Add(person);
            // await _dbContext.SaveChangesAsync(cancellationToken);
            
            return person.Id;
        }
    }
}