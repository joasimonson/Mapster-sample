using Mapster;

namespace MapsterSample;

public class UserService(IAppDbContext context)
{
    public IQueryable<UserDTO> GetUsers() => context.Users.ProjectToType<UserDTO>();
}