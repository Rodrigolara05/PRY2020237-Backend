using PRY2020237.Entity;

namespace PRY2020237.Service
{
     public interface IUserService : IService<User>
    {
            User Login(string email, string password);

    }
}
