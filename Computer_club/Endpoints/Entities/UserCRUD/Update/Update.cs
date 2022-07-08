using Computer_club.Data.Repository.UserRepository;
using Computer_club.Models.UserModel;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Computer_club.Endpoints.Entities.UserCRUD.Update;

public class Update : EndpointBaseAsync
        .WithRequest<UpdateUserCommand>
        .WithActionResult<UpdateUserResult>
{
        private readonly IUserRepository<User> _repository;
        private readonly IMapper _mapper;

        public Update(IUserRepository<User> repository, IMapper mapper)
        {
                _repository = repository;
                _mapper = mapper;
        }

        [HttpPut("user/update")]
        [SwaggerOperation(
                Summary = "Updates a User",
                Description = "Updates a User",
                OperationId = "User.Update",
                Tags = new[] { "UserEndpoints" })
        ]
        public override async Task<ActionResult<UpdateUserResult>> HandleAsync
        ([FromBody]UpdateUserCommand request,
        CancellationToken token = default)
        {
                var user = await _repository.GetByIdAsync(request.Id, token);
                if (user == null) return NotFound();
                _mapper.Map(request, user);
                await _repository.UpdateAsync(user, token);
                var result = _mapper.Map<UpdateUserResult>(user);
                return result;
        }
}