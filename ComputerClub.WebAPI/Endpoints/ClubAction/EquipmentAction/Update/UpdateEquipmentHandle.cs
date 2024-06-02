using ComputerClub.DAL.Models.ClubModels;
using ComputerClub.DAL.Models.UserModels;
using ComputerClub.Domain.Repositories.BaseClubRepository;
using FastEndpoints;
using IMapper = MapsterMapper.IMapper;

namespace ComputerClub.WebAPI.Endpoints.ClubAction.EquipmentAction.Update;

public class UpdateEquipmentHandle : Endpoint<UpdateEquipmentRequest, UpdateEquipmentResponse>
{
    private readonly IMapper _mapper;
    private readonly IBaseClubRepository<Equipment> _service;

    public UpdateEquipmentHandle(IMapper mapper, IBaseClubRepository<Equipment> service)
    {
        _mapper = mapper;
        _service = service;
    }

    public override void Configure()
    {
        Put("club/place/device-set/equipment");

        Summary(sum => { sum.Summary = "Equipment update"; });
        
        Options(opt => opt.WithTags("Equipment"));
        
        Policies(Role.SuperAdminAndManager);
    }

    public override async Task HandleAsync(UpdateEquipmentRequest request, CancellationToken ct)
    {
        Equipment? findEquipment = await _service.GetByIdAsync(request.Id);

        if (findEquipment == null)
        {
            await SendErrorsAsync(404, ct);
        }
        
        _mapper.Map(request, findEquipment);
        
        await _service.UpdateAsync(findEquipment, ct);
        
        UpdateEquipmentResponse response = _mapper.Map<UpdateEquipmentResponse>(findEquipment);

        await SendOkAsync(response, ct);
    }
}