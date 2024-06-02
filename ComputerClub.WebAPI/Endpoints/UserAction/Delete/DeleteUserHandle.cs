using ComputerClub.DAL.Entities;
using ComputerClub.DAL.Models.UserModels;
using ComputerClub.Domain.Repositories.UserRepository;
using FastEndpoints;

namespace ComputerClub.WebAPI.Endpoints.UserAction.Delete;

public class DeleteUserHandle : EndpointWithoutRequest
{
    private readonly IUserRepository<User> _repository;

    public DeleteUserHandle(IUserRepository<User> repository)
    {
        _repository = repository;
    }

    public override void Configure()
    {
        Delete("user/{userId}");
        
        Summary(sum => { sum.Summary = "Deletes a User";});
        
        Options(opt => opt.WithTags("User"));

        Policies(Role.SuperAdmin, Role.ClubAdmin, Role.Manager);
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        Guid userId = Query<Guid>("userId");
        
        User? user = await _repository.GetByIdAsync(userId);

        if (user == null)
        {
            await SendErrorsAsync(404, ct);
        }

        await _repository.DeleteAsync(user);

        await SendOkAsync(ct);
    }
}