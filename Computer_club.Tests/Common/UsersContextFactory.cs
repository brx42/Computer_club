using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Computer_club.WebAPI;

namespace Computer_club.Tests.Common;

public class CustomFactory<TProgram> 
{
    public static Guid UserAId = Guid.NewGuid();
    public static Guid UserBId = Guid.NewGuid();
    
    public static Guid UserIdForDelete = Guid.NewGuid();
    public static Guid UserIdForUpdate = Guid.NewGuid();
    
}