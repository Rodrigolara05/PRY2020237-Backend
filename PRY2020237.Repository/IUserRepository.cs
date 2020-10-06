using PRY2020237.Entity;

namespace PRY2020237.Repository
{
    public interface IUserRepository: IRepository<User>
    {
         User Login(string email, string password);
    }
}