using System.Collections.Generic;
using PRY2020237.Entity;
using PRY2020237.Repository;

namespace PRY2020237.Service.implementation
{
    public class UserService : IUserService
    {

        private IUserRepository userRepository;
        public UserService(IUserRepository userRepository)
        {
            this.userRepository=userRepository;
        }
        
        public bool Delete(int id)
        {
            return userRepository.Delete(id);
        }

        public User Get(int id)
        {
            return userRepository.Get(id);
        }

        public IEnumerable<User> GetAll()
        {
           return userRepository.GetAll();
        }

        public User Login(string email, string password)
        {
            return userRepository.Login(email,password);
        }

        public bool Save(User entity)
        {
            return userRepository.Save(entity);
        }

        public bool Update(User entity)
        {
            return userRepository.Update(entity);
        }
    }
}